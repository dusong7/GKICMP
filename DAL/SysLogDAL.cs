/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月07日 16时38分19秒
** 描    述:      系统日志的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;

namespace GK.GKICMP.DAL
{
    public partial class SysLogDAL : DataEntity<SysLogEntity>
    {
        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SysLogEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysLog_Paged";        
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin,DatabaseType.SQL_DateTime, 40));
            DbParameters.Add(new DatabaseParameter("End", model.End,DatabaseType.SQL_DateTime, 40));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("LogFlag", model.LogFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LogType", model.LogType,DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[7].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SysLogEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysLog_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("LogType", model.LogType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LogContent", model.LogContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LogFlag", model.LogFlag, DatabaseType.SQL_Int, 4));
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



    }
}
