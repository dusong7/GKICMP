/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月24日 10时46分47秒
** 描    述:      退费管理基本操作类
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
    public partial class PayBackDAL : DataEntity<PayBackEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(PayBackEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayBack_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PBID", model.PBID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PRID", model.PRID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BackUser", model.BackUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BackCount", model.BackCount, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("IsAudit", model.IsAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            result = Convert.ToInt32(DbParameters[0].Value);
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return result;
        }
        #endregion



        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int Update(PayBackEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayBack_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("PBID", model.PBID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsAudit", model.IsAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
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



        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, PayBackEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayBack_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StuName", model.StuName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsAudit", model.IsAudit, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 获取数据集，返回DataSet
        /// <summary>
        /// 获取数据集，返回DataSet
        /// </summary>    
        public DataTable GetTable(string PRID, string StuID)
        {
            string sql = "select *,dbo.getUserName(AduitUser ) AduitUserName from Tb_PayBack where PRID='" + PRID + "' and BackUser='" + StuID + "' and Isdel=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }

}

