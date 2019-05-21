/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月16日 15时54分10秒
** 描    述:      调代课操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class SubstituteDAL : DataEntity<SubstituteEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SubstituteEntity model, string ecid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_Add";
            DataAccessChannelProtection = true;

            // DbParameters.Add(new DatabaseParameter("SubID", model.SubID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ApplyUser", model.ApplyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ApplyReason", model.ApplyReason, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("SubBegin", model.SubBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("SubEnd", model.SubEnd, DatabaseType.SQL_DateTime, 8));

            DbParameters.Add(new DatabaseParameter("SubBegin1", model.SubBegin1, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("SubEnd1", model.SubEnd1, DatabaseType.SQL_DateTime, 8));

            // DbParameters.Add(new DatabaseParameter("SubUser", model.SubUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SubCount", model.SubCount, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubState", model.SubState, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("SubCoruse", model.SubCoruse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubName", model.SubName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("SubType", model.SubType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ECID", ecid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        /// <summary>
        /// 代课登记
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int Add(SubstituteEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_AddByDK";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SubID", model.SubID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ApplyUser", model.ApplyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ApplyReason", model.ApplyReason, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("SubBegin", model.SubBegin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("SubEnd", model.SubEnd, DatabaseType.SQL_DateTime, 20));

            //DbParameters.Add(new DatabaseParameter("SubBegin1", model.SubBegin1, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("SubEnd1", model.SubEnd1, DatabaseType.SQL_DateTime, 8));

            // DbParameters.Add(new DatabaseParameter("SubUser", model.SubUser, DatabaseType.SQL_NVarChar, 40));
            // DbParameters.Add(new DatabaseParameter("SubCount", model.SubCount, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubState", model.SubState, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("SubCoruse", model.SubCoruse, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("SubName", model.SubName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("SubType", model.SubType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("ECID", ecid, DatabaseType.SQL_NVarChar, 40));
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


        #region 审核
        /// <summary>
        /// 调课审核
        ///</summary>
        public int Audit(int subid, int state, string uid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_Audit";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SubID", subid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("State", state, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditUser", uid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        /// <summary>
        /// 代课审核通过方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AuditByDK(SubstituteEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_AuditByDK";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SubID", model.SubID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("State", model.SubState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SubUser", model.SubUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditDate", model.AuditDate, DatabaseType.SQL_Date, 20));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        ///// <summary>
        // /// 代课审核驳回方法
        ///// </summary>
        ///// <param name="subid"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        // public int AuditByDKBH(string subid,string audituser,int state)
        // {
        //     DbParameters.Clear();
        //     ProcedureName = "up_Tb_Substitute_AuditByDKBH";
        //     DataAccessChannelProtection = true;

        //     DbParameters.Add(new DatabaseParameter("SubID", subid, DatabaseType.SQL_Int, 4));
        //     DbParameters.Add(new DatabaseParameter("State", state, DatabaseType.SQL_Int, 4));
        //     DbParameters.Add(new DatabaseParameter("AuditUser", audituser, DatabaseType.SQL_NVarChar, 40));
        //     STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
        //     if (stmessage.SqlCode != 0)
        //     {
        //         throw new Exception(DataReturn.SqlMessage);
        //     }
        //     DataAccessChannel.CommitRelease();
        //     DataAccessChannelProtection = false;
        //     return stmessage.AffectRows;
        // }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_DelBat";
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
        public SubstituteEntity GetObjByID(int id)
        {
            string sql = "SELECT *,dbo.getUserName(ApplyUser)ApplyUserName,dbo.getUserName(SubUser)SubUserName,dbo.getUserName(AuditUser)AuditUserName,dbo.getCourseName(SubCoruse)SubCoruseName,dbo.getCourseName(SubCoruse1)SubCoruse1Name FROM [Tb_Substitute] WHERE [SubID] = " + id;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SubstituteEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("SubType", model.SubType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubUser", model.SubUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.SubBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.SubEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        public DataTable GetPagedAudit(int pagesize, int pageindex, ref int recordCount, SubstituteEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Substitute_PagedAudit";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("SubType", model.SubType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubUser", model.SubUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.SubBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.SubEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubState", model.SubState, DatabaseType.SQL_Int, 4));
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