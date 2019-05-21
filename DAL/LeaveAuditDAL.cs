/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2016年12月03日 08时44分48秒
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
    public class LeaveAuditDAL : DataEntity<Leave_AuditEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Leave_AuditEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LIDS", model.LID, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditMark", model.AuditMark, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AuditResult", model.AuditResult, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditOrder", model.AuditOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsDisplay", model.IsDisplay, DatabaseType.SQL_Int, 4));

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


        #region 更新请假审核数据
        /// <summary>
        /// 更新请假审核数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateState(Leave_AuditEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LAID", model.LAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditMark", model.AuditMark, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AuditResult", model.AuditResult, DatabaseType.SQL_Int));

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

        public int UpdateOvetTimeState(Leave_AuditEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_OvetTimeUpdate";
            //ProcedureName = "up_Tb_Leave_Audit_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LAID", model.LAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditMark", model.AuditMark, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AuditResult", model.AuditResult, DatabaseType.SQL_Int));

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



        #region 添加一条审核信息
        /// <summary>
        /// 添加一条审核信息
        ///</summary>
        public int AuditEdit(Leave_AuditEntity model, int state)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_Edit";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("AuditResult", model.AuditResult, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("state", state, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsCurrent", model.IsCurrent, DatabaseType.SQL_Int, 4));
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

        #region 删除审核人信息
        /// <summary>
        /// 删除审核人信息
        ///</summary>
        public int DeleteBat(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("LAID", id, DatabaseType.SQL_NVarChar, 40));

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


        #region 获取请假审核人信息
        /// <summary>
        /// 获取请假审核人信息
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>
        public DataTable GetList(string lid)
        {
            //string sql = "SELECT *,dbo.getusername(AuditUser)AuditName,STUFF((  SELECT ','+(case when  dbo.getUserName(a.AuditUser)='' then  a.AuditUser else dbo.getUserName(a.AuditUser) end)  FROM Tb_Leave_Audit a WHERE b.AuditOrder = a.AuditOrder and LID='" + lid + "'  FOR XML PATH('') ),1 ,1, '') RealName  FROM dbo.Tb_Leave_Audit b WHERE LID ='" + lid + "'  order by AuditOrder asc";

            string sql = "SELECT *,dbo.getusername(AuditUser)AuditName,DBO.getLeaveAudits(LID,AuditOrder) RealName  FROM dbo.Tb_Leave_Audit b WHERE LID in (select * from dbo.f_split('"+lid+"',','))  order by AuditOrder asc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion
        #region 获取请假审核人信息
        /// <summary>
        /// 获取请假审核人信息
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>
        public DataTable GetList(LeaveEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_GetList";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, LeaveEntity model, string userid, int isdidplay)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LFlag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsDisplay", isdidplay, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.LeaveUserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("LType", model.LType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveState", model.LeaveState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region(加班审核列表) 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// (加班审核列表)根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, OverTimeEntity model, string userid, int isdidplay)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_OverTimePaged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsDisplay", isdidplay, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ApplyUser", model.ApplyUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("OType", model.OType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("OState", model.OState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));

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
        public DataTable GetPagedAPP(int pagesize, int pageindex, ref int recordCount, LeaveEntity model, string userid, int isdidplay)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Leave_Audit_PagedAPP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LFlag", model.LFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsDisplay", isdidplay, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion
    }
}
