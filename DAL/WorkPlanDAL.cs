/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年07月10日 17时23分15秒
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
    public partial class WorkPlanDAL : DataEntity<WorkPlanEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(WorkPlanEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("PlanID", model.PlanID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WeekNum", model.WeekNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ExamName", model.ExamName, DatabaseType.SQL_Text, 1000));
            DbParameters.Add(new DatabaseParameter("AllUsers", model.AllUsers, DatabaseType.SQL_Text, 9999));
            DbParameters.Add(new DatabaseParameter("AlluserID", model.AlluserID, DatabaseType.SQL_Text, 9999));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsComplete", model.IsComplete, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSendMess", model.IsSendMess, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("NID", model.NID, DatabaseType.SQL_Int, 4));

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

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int EditAPP(WorkPlanEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_AddAPP";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("PlanID", model.PlanID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WeekNum", model.WeekNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ExamName", model.ExamName, DatabaseType.SQL_Text, 1000));
            DbParameters.Add(new DatabaseParameter("AllUsers", model.AllUsers, DatabaseType.SQL_Text, 9999));
            DbParameters.Add(new DatabaseParameter("AlluserID", model.AlluserID, DatabaseType.SQL_Text, 9999));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsComplete", model.IsComplete, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSendMess", model.IsSendMess, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("NID", model.NID, DatabaseType.SQL_Int, 4));

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
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_DelBat";
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


        #region 计划完成
        /// <summary>
        /// 计划完成
        ///</summary>
        public int CompLete(string ids, int comp)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_CompLete";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Comp", comp, DatabaseType.SQL_Int, 4));
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
        public WorkPlanEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getDepName(depid)DepIDName,dbo.getUserName(dutyuser)DutyUserName,dbo.getWorkPlanUserList(PlanID)AlluserID,dbo.getUserName(CreateUser)CreateUserName,CreateDate FROM [Tb_WorkPlan] WHERE [PlanID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, WorkPlanEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("EndDate", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        public DataTable GetMainTable(WorkPlanEntity model,int weeks)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_MainTable";
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WeekNum", weeks, DatabaseType.SQL_Int, 4));
            //string sql = "select top 7 *,dbo.getUserName(DutyUser)DutyUserName,dbo.getDepName(DepID)DepName from Tb_WorkPlan where WeekNum=" + weeks + " and isdel=0 and (CreateUser='" + model.CreateUser + "' or DutyUser='" + model.CreateUser + "' or cast(AllUsers as nvarchar(max))='全体人员' or cast(AllUsers as nvarchar(max)) like '%'+dbo.getUserName('" + model.CreateUser + "')+'%') and dbo.getUserName(DutyUser) like '%" + model.DutyUserName + "%' order by EndDate desc";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端工作计划
        /// <summary>
        /// 手机端工作计划
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedAPP(int pagesize, int pageindex, ref int recordCount, WorkPlanEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WorkPlan_PagedAPP";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("BeginDate", begin, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("EndDate", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
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

