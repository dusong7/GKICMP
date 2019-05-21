/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年04月26日 16时35分11秒
** 描    述:      数据的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;


namespace GK.GKICMP.DAL
{
    public partial class Project_TenderDAL : DataEntity<Project_TenderEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Project_TenderEntity model, AccessoryEntity amodel)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Tender_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PTID", model.PTID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SID", model.SID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BAmount", model.BAmount, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("BDate", model.BDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("BSDate", model.BSDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("BEDate", model.BEDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Bond", model.Bond, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("BondDate", model.BondDate, DatabaseType.SQL_DateTime, 8));
            // DbParameters.Add(new DatabaseParameter("IsReturn", model.IsReturn, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PTDesc", model.PTDesc, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BidNumber", model.BidNumber, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("FileID", model.FileID, DatabaseType.SQL_NVarChar, 40));

            DbParameters.Add(new DatabaseParameter("AccessName", amodel.AccessName, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("AccessUrl", amodel.AccessUrl, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("ObjID", amodel.ObjID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AccessFlag", amodel.AccessFlag, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            result = Convert.ToInt32(DbParameters[0].Value);
            DataAccessChannelProtection = false;
            return result;
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Tender_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        #endregion

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int Update(string ids, DateTime returntime)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Tender_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("PTID", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("ReturnDate", returntime, DatabaseType.SQL_DateTime, 20));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        #endregion
        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Tender_UpdateReport";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("PTID", ids, DatabaseType.SQL_NVarChar, 2000));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        #endregion
        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public Project_TenderEntity GetObjByID(string id)
        {
            string sql = "SELECT *,[BidNumber],dbo.getSupplierName(sid) SupplierName,dbo.getProNameByJZ(PID) ProName,dbo.getUserName(CreateUser)CreateUserName FROM [Tb_Project_Tender] WHERE [PTID] ='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public Project_TenderEntity GetPurchaseByID(string id)
        {
            string sql = "SELECT a.*,[BidNumber],dbo.getSupplierName(sid) SupplierName,b.ptitle ProName,dbo.getUserName(a.CreateUser)CreateUserName FROM [Tb_Project_Tender] a inner join tb_purchase b on a.pid=b.pid WHERE [PTID] ='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable getReturn(string ptid)
        {
            string sql = "SELECT * FROM [Tb_Project_Tender] WHERE [PTID] = '" + ptid + "'";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Project_TenderEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Tender_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 100));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedByPurchase(int pagesize, int pageindex, ref int recordCount, Project_TenderEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Tender_PagedByPurchase";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 100));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion
    }

}

