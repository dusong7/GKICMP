/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月15日 08时28分01秒
** 描    述:      会议的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;

namespace GK.GKICMP.DAL
{
    public partial class MeetingDAL : DataEntity<MeetingEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(MeetingEntity model, int isadd)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("MTitle", model.MTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("MContent", model.MContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("MeetingRoom", model.MeetingRoom, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MBegin", model.MBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("MEnd", model.MEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("LinkUser", model.LinkUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LinkNum", model.LinkNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserList", model.UserList, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("MeetingUsers", model.MeetingUsers, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isadd", isadd, DatabaseType.SQL_Int, 4));


            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = Convert.ToInt32(DbParameters[0].Value.ToString());
            return result;
        }
        #endregion


        #region 更新会议纪要信息
        /// <summary>
        /// 更新会议纪要信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSummary(MeetingEntity model, string absenduser, string lateuser)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_UpdateSummary";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("MeetingHost", model.MeetingHost, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Minutes", model.Minutes, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("AbsendUser", absenduser, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("LateUser", lateuser, DatabaseType.SQL_NVarChar, 2000));

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


        #region 审核会议信息
        /// <summary>
        /// 审核会议信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AuditMeet(MeetingEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_Audit";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 40));

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


        #region 根据会议ID查询会议人员信息
        /// <summary>
        /// 根据会议ID查询会议人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetByMID(string mid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_User_GetByMID";
            DbParameters.Add(new DatabaseParameter("MID", mid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据会议ID查询会议人员信息1
        /// <summary>
        /// 根据会议ID查询会议人员信息1
        /// </summary>
        /// <returns></returns>
        public DataTable GetMeetUser(string mid)
        {
            string sql = "select *,dbo.getUserName(MeetingUser) as MeetUserName from Tb_Meeting_User a left join Tb_SysUser b on a.MeetingUser=b.UID where b.Isdel=0 and MID='" + mid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据会议ID查找参会人员情况
        /// <summary>
        /// 根据会议ID查找参会人员情况
        /// </summary>
        /// <returns></returns>
        public DataTable GetUser(string mid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_User_GetTable";
            DbParameters.Add(new DatabaseParameter("MID", mid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_DelBat";
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
        public MeetingEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getClassRoomName(MeetingRoom) as MRName,dbo.getUserName(MeetingHost) MeetingHostName,dbo.getUserName(LinkUser) as LinkUserName FROM [Tb_Meeting] WHERE	[MID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, MeetingEntity model, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("MTitle", model.MTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("MeetingRoom", model.MeetingRoom, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

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
        public DataTable GetAllPaged(int pagesize, int pageindex, ref int recordCount, MeetingEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Meeting_AllPaged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("MTitle", model.MTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("MeetingRoom", model.MeetingRoom, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 查询一周的会议预约信息
        /// <summary>
        /// 查询一周的会议预约信息
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="astate"></param>
        /// <returns></returns>
        public DataView GetApplyList(DateTime begin, DateTime end, int isdel)
        {
            string sql = "select *,dbo.getUserName(CreateUser) as UserName from Tb_Meeting where ((MBegin>='" + begin.ToString("yyyy-MM-dd HH:MM:ss") + "' and MBegin<='" + end.ToString("yyyy-MM-dd HH:MM:ss") + "') or (MEnd>='" + begin.ToString("yyyy-MM-dd HH:MM:ss") + "' and MEnd<='" + end.ToString("yyyy-MM-dd HH:MM:ss") + "')) and Isdel=" + isdel + " and AuditState=1";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer.DefaultView;
        }
        #endregion
    }
}
