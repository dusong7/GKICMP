/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年07月06日 14时51分38秒
** 描    述:      数据的基本操作类
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
    public partial class LeaveDAL : DataEntity<LeaveEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(LeaveEntity model, int isadd, string ddlbegin, string ddlend)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Isadd", isadd, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LeaveUser", model.LeaveUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("ddlbegin", ddlbegin, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ddlend", ddlend, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LeaveDays", model.LeaveDays, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("LeaveMark", model.LeaveMark, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("LeaveState", model.LeaveState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveFile", model.LeaveFile, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("LFlag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LType", model.LType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsOK", model.IsOK, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTeacher", model.IsTeacher, DatabaseType.SQL_Int, 4));
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

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int EditAPP(LeaveEntity model, string ddlbegin, string ddlend)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_AddAPP";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LeaveUser", model.LeaveUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("ddlbegin", ddlbegin, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ddlend", ddlend, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LeaveDays", model.LeaveDays, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("LeaveMark", model.LeaveMark, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("LeaveState", model.LeaveState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveFile", model.LeaveFile, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("LFlag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LType", model.LType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsOK", model.IsOK, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTeacher", model.IsTeacher, DatabaseType.SQL_Int, 4));
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_DelBat";
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


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public LeaveEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getUserName(LeaveUser)LeaveUserName,dbo.getBaseDataNameByDcode(CAST( LType as nvarchar)) LTypeName FROM [Tb_Leave] WHERE [LID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 获取附件
        public DataTable GetTable(string lid)
        {
            string sql = "SELECT * FROM dbo.Tb_Leave WHERE LID='" + lid + "'";
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
        public DataTable GetPagedAudit(int pagesize, int pageindex, ref int recordCount, LeaveEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_PagedAudit";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("LType", model.LType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("lflag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveState", model.LeaveState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUserName", model.LeaveUserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUser", model.LeaveUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, LeaveEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 18));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 18));
            DbParameters.Add(new DatabaseParameter("LType", model.LType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("lflag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveState", model.LeaveState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUserName", model.LeaveUserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUser", model.LeaveUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
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
        public DataTable GetPagedDKAP(int pagesize, int pageindex, ref int recordCount, LeaveEntity model, int term, string eyear)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_PagedDKAP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("LType", model.LType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveState", model.LeaveState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUserName", model.LeaveUserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("term", term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("eyear", eyear, DatabaseType.SQL_NVarChar, 50));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 获取我发起的请假或外出，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedApp(int pagesize, int pageindex, ref int recordCount, LeaveEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_PagedApp";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("lflag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUser", model.LeaveUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        public DataTable GetList(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_GetList";
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 4000));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetList(string begin, string end, string uid)
        {
            string sql = "select *,(case when LFlag=1 then  dbo.getBaseDataNameByDcode(LType) else '外出' end)TypeName from Tb_Leave where BeginDate between '" + begin + "' and '" + end + "' and  LeaveUser='" + uid + "' ";
            //string sql = "select *,(case when LFlag=1 then  dbo.getBaseDataNameByDcode(LType) else '外出' end)TypeName from Tb_Leave where '" + begin + "' between BeginDate and EndDate or '" + end + "' between BeginDate and EndDate and  LeaveUser='" + uid + "' ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetListDay(string begin, string end, string uid)
        {
            string sql = "select *,(case when LFlag=1 then  dbo.getBaseDataNameByDcode(LType) else '外出' end)TypeName  from Tb_Leave_Info where( LeaveUser='" + uid + "' or '" + uid + "'='')  and LeaveDate between '" + begin + "' and '" + end + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
       
        public int GetCount(DateTime Date)
        {
            string sql = "  select Count(*) from  Tb_Leave where  BeginDate>='" + Date.ToString("yyyy-MM-dd") + "' and BeginDate<'" + Date.AddDays(1).ToString("yyyy-MM-dd") + "' and LFlag=1 ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return Convert.ToInt32(DataReflectionContainer.Rows[0][0]);
        }

        public int GetCountByLType(DateTime BeginDate,DateTime EndDate, int LType)
        {
            string sql = "  select Count(*) from  Tb_Leave where  BeginDate>='" + BeginDate.ToString("yyyy-MM-dd") + "' and EndDate<='" + EndDate.ToString("yyyy-MM-dd") + "' and LFlag=1 and LType=" + LType;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return Convert.ToInt32(DataReflectionContainer.Rows[0][0]);
        }
    }
}

