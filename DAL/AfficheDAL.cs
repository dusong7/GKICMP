/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月09日 09时48分24秒
** 描    述:      通知公告的基本操作类
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
    public partial class AfficheDAL : DataEntity<AfficheEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(AfficheEntity model, string ids)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AContent", model.AContent, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsDisplay", model.IsDisplay, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AFlag", model.AFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar));

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
        public int DeleteByID(string id, string user)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("AID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
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



        #region 根据主键更新是否已读状态
        /// <summary>
        /// 根据主键更新是否已读状态
        ///</summary>
        public int Update(string id, string user, int isread)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("AID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("isread", isread, DatabaseType.SQL_Int, 4));

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
        public AfficheEntity GetObjByID(string id, string user)
        {
            string sql = "SELECT *,dbo.getUserName(SendUser) SendUserName,dbo.getDataName(atype) ATypeName,dbo.getUserName('" + user + "') AcceptUserName,(select IsRead from Tb_Affiche_User where AID='" + id + "' and AcceptUser='" + user + "') IsRead FROM [Tb_Affiche] where AID='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion



        #region 查询已读未读通知
        /// <summary>
        /// 已读未读
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetTableAPP(string aid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_GetTableAPP";
            DbParameters.Add(new DatabaseParameter("AID", aid, DatabaseType.SQL_NVarChar, 40));

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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, DateTime begin, DateTime end, int flag, string user)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("isRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }

        public DataTable GetPagedClass(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, DateTime begin, DateTime end, string user, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_PagedClass";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("isRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SendUser", user, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        public DataTable GetPagedSchool(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, DateTime begin, DateTime end, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_PagedSchool";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        public DataTable GetAfficheTable(string useid)
        {
            string sql = "SELECT a.*,b.IsRead,dbo.getUserName(SendUser) SendUserName,dbo.getUserName(b.AcceptUser) AcceptUserName,dbo.getDataName(AType) ATypeName,b.AcceptUser FROM [Tb_Affiche] a left join Tb_Affiche_User b on a.AID=b.AID  where b.AcceptUser ='" + useid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public int Audit(string userid, int state, string AID)
        {
            DbParameters.Clear();
            // ProcedureName = "up_Tb_Absent_Audit";
            DataAccessChannelProtection = true;
            string sql = "update Tb_Affiche set IsDisplay=" + state + ",AuditDate=getdate(),AuditUser='" + userid + "' where aid='" + AID + "'";
            STMessage stmessage = ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION, sql).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

        public int Send(string AID)
        {
            DbParameters.Clear();

            DataAccessChannelProtection = true;
            string sql = "update Tb_Affiche set IsSend=1 where aid='" + AID + "'";
            STMessage stmessage = ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION, sql).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

        #region 根据班级ID获取班级公告
        /// <summary>
        /// 根据班级ID获取班级公告
        /// </summary>
        /// <param name="claid"></param>
        /// <returns></returns>
        public DataTable GetInfo(int claid)
        {
            string sql = "select top 5 *,dbo.getUserName(SendUser) as SendUserName from Tb_Affiche where AFlag=2 and IsDisplay=1 and ClaID=" + claid + " order by SendDate desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端已收通知公告
        /// <summary>
        /// 手机端已收通知公告
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedAPP(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, int flag, string user)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_PagedAPP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("isRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端已发通知公告
        /// <summary>
        /// 手机端已发通知公告
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedSendAPP(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, string user)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_PagedSendAPP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        public int GetCount(DateTime BeginDate, DateTime EndDate, int AType)
        {
            string sql = "select Count(*) from Tb_Affiche where  SendDate>='" + BeginDate.ToString("yyyy-MM-dd") + "' and SendDate<='" + EndDate.ToString("yyyy-MM-dd") + "' and AType=" + AType;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return Convert.ToInt32(DataReflectionContainer.Rows[0][0]);
        }


        #region 教研活动参与审核
        /// <summary>
        /// 教研活动参与审核
        ///</summary>
        public int AuditEdit(AfficheEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_User_Audit";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("AID", model.AID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditMark", model.AuditMark, DatabaseType.SQL_NVarChar, 4000));
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


        #region 手机端已收教研活动
        /// <summary>
        /// 手机端已收教研活动
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetAfficheAcceptAPP(int pagesize, int pageindex, ref int recordCount, AfficheEntity model,string user)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AfficheAcceptAPP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("isRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端已发教研活动
        /// <summary>
        /// 手机端已发教研活动
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetAfficheSendAPP(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, string user)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AfficheSendAPP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("user", user, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 添加教研活动记录
        /// <summary>
        /// 添加教研活动记录
        ///</summary>
        public int ResearchEdit(AfficheEntity model, string ids)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_ResearchAdd";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AContent", model.AContent, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsDisplay", model.IsDisplay, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AFlag", model.AFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar));

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

        #region 教研活动不参与原因
        /// <summary>
        /// 已读未读
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetIsRead(string aid, int atype)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_GetIsRead";
            DbParameters.Add(new DatabaseParameter("AID", aid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AType", atype, DatabaseType.SQL_Int, 4));

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
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, AfficheEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Affiche_GetList";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
           
            DbParameters.Add(new DatabaseParameter("AfficheTitle", model.AfficheTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", end, DatabaseType.SQL_DateTime, 8));
           

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

