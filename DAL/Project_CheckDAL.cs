/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月20日 08时50分53秒
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
    public partial class Project_CheckDAL : DataEntity<Project_CheckEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Project_CheckEntity model, int flag = 1)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Check_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("PCID", model.PCID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));

            DbParameters.Add(new DatabaseParameter("BrandChecked", model.BrandChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SpecificationChecked", model.SpecificationChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ConfigChecked", model.ConfigChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CountChecked", model.CountChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DebuggingChecked", model.DebuggingChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GuaranteeChecked", model.GuaranteeChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PackingChecked", model.PackingChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ContractChecked", model.ContractChecked, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("Evaluate", model.Evaluate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Opinion", model.Opinion, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("PCDate", model.PCDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PCFile", model.PCFile, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

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
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Check_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            //DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
            ProcedureName = "up_Tb_Project_Check_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
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
        /// <param name="id"></param>
        /// <param name="flag">区分教装与采购，默认1为教装，采购为2</param>
        /// <returns></returns>
        public Project_CheckEntity GetObjByID(string id, int flag = 1)
        {
            //DbParameters.Clear();
            //ProcedureName = "up_Tb_Project_Check_Get";
            //DbParameters.Add(new DatabaseParameter("PCID", id, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("ExceptionCode", id, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("ExceptionMessage", id, DatabaseType.SQL_VarChar, 2048));
            string sql = "";
            if (flag == 1)
                sql = "select *,dbo.getProNameByJZ(PID) as PName,dbo.getUserName(CreateUser) as CreateUserName from Tb_Project_Check where PCID='" + id + "'";
            else
                sql = "select a.*,b.ptitle as PName,dbo.getUserName(a.CreateUser) as CreateUserName from Tb_Project_Check a inner join tb_purchase b on a.pid=b.pid where PCID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Project_CheckEntity model, int flag = 1)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Project_Check_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(string pcid)
        {
            string sql = "select *,dbo.getProNameByJZ(PID) as PName,dbo.getUserName(CreateUser) as CreateUserName from Tb_Project_Check where PCID='" + pcid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}

