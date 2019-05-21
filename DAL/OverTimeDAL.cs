/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年04月08日 11时06分35秒
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
    public partial class OverTimeDAL : DataEntity<OverTimeEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(OverTimeEntity model,int isadd,string users)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_OverTime_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("OID", model.OID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ApplyUser", model.ApplyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ApplyDate", model.ApplyDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("ODays", model.ODays, DatabaseType.SQL_Decimal));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("OType", model.OType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("OMark", model.OMark, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("OState", model.OState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("isadd", isadd, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("users", users, DatabaseType.SQL_NVarChar, 8000));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = Convert.ToInt32(DbParameters[0].Value);
            return result;
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_OverTime_DelBat";
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
        public OverTimeEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_OverTime_Get";
            DbParameters.Add(new DatabaseParameter("OID", id, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, OverTimeEntity model,DateTime begin,DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_OverTime_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("ApplyUser", model.ApplyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("OState", model.OState, DatabaseType.SQL_Int, 4));
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
        //public DataTable GetStatistcs(int pagesize, int pageindex, ref int recordCount, DateTime begin, DateTime end, int state)
        public DataTable GetStatistcs(DateTime begin, DateTime end, int state)
        {


            string sql = "select dbo.getUserName(SysUserID) username, SysUserID,sum(cast(dbo.getBaseDataDcode(OType) as decimal(16,2)) ) overdays from Tb_OverTime_User a inner join Tb_OverTime b on a.OID=b.OID  where BeginDate between '" + begin + "'  and '" + end + "'  AND (OState=" + state + " OR " + state + " =-2) group by SysUserID order by overdays desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            //DbParameters.Clear();
            //ProcedureName = "up_Tb_OverTime_Statistcs";
            //DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("OState", state, DatabaseType.SQL_Int, 4));
            //if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            //{
            //    throw new Exception(DataReturn.SqlMessage);
            //}
            //recordCount = Convert.ToInt32(DbParameters[2].Value);


            return DataReflectionContainer;
        }
        #endregion

        #region 获取教师在某个时间段加班记录
        /// <summary>
        /// 获取教师在某个时间段加班记录
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        //public DataTable GetStatistcs(int pagesize, int pageindex, ref int recordCount, DateTime begin, DateTime end, string username)
        public DataTable GetStatistcs(DateTime begin, DateTime end, string username)
        {


            string sql = "	select  dbo.getUserName(SysUserID)UserName,dbo.getBaseDataName(OType)OTypeName,dbo.getBaseDataDcode(OType)overdays ,BeginDate from Tb_OverTime_User a inner join Tb_OverTime b on a.oid=b.OID where  BeginDate between '" + begin + "' and '" + end + "' and SysUserID='" + username + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            //DbParameters.Clear();
            //ProcedureName = "up_Tb_OverTime_Statistcs";
            //DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("username", username, DatabaseType.SQL_NVarChar, 40));
            //if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            //{
            //    throw new Exception(DataReturn.SqlMessage);
            //}
            //recordCount = Convert.ToInt32(DbParameters[2].Value);


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
        public DataTable GetList(string oids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_OverTime_GetList";
            DbParameters.Add(new DatabaseParameter("Ids", oids, DatabaseType.SQL_NVarChar,9000));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }

}

