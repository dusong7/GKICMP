/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2019年05月09日 17时22分16秒
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
    public partial class Project_ContractDAL : DataEntity<Project_ContractEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Project_ContractEntity model, AccessoryEntity amodel)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Contract_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ID", model.ID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Name", model.Name, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("PartyA", model.PartyA, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("PartyB", model.PartyB, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("SignDate", model.SignDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("Price", model.Price, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("StartTime", model.StartTime, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PCDesc", model.PCDesc, DatabaseType.SQL_NVarChar, -1));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BidNumber", model.BidNumber, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("ServerYears", model.ServerYears, DatabaseType.SQL_NChar, 10));
            DbParameters.Add(new DatabaseParameter("ServerDate", model.ServerDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("ServerLinkUser", model.ServerLinkUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("ServerPhone", model.ServerPhone, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FileID", model.FileID, DatabaseType.SQL_NVarChar, 50));

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
            string a = DbParameters[0].Value.ToString();
            result = Convert.ToInt32(DbParameters[0].Value.ToString());
            DataAccessChannelProtection = false;
            return result;
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids,int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Contract_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
        public Project_ContractEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Contract_Get";
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        public int Update(string ids)
        {
            string sql = "update tb_project_contract set isreport=1 where id in (select col from dbo.f_split('" + ids + "',','))";
            DataAccessChannelProtection = true;
            STMessage stmessage = ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION,sql).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Project_ContractEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Contract_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Name", model.Name, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("PartyB", model.PartyB, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("BidNumber", model.BidNumber, DatabaseType.SQL_NVarChar, 500));

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

