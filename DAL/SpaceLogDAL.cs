/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月25日 08时39分22秒
** 描    述:      空间日志操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class SpaceLogDAL : DataEntity<SpaceLogEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SpaceLogEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("EGID", model.EGID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LogTitle", model.LogTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("LogText", model.LogText, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PeoNum", model.PeoNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsAduit", model.IsAduit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SFlag", model.SFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SAID", model.SAID, DatabaseType.SQL_NVarChar, 40));

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
            ProcedureName = "up_Tb_SpaceLog_DelBat";
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
        /// <returns></returns>
        public SpaceLogEntity GetObjByID(int id)
        {
            string sql = "select *,dbo.getUserName(SysID) as SysUserName from Tb_SpaceLog where EGID=" + id;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SpaceLogEntity model, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SFlag", model.SFlag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据实体条件分页获取数据集，返回DataSet(日志审核)
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet(日志审核)
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetAuditPaged(int pagesize, int pageindex, ref int recordCount, SpaceLogEntity model, DateTime begindate, DateTime enddate, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_AuditPaged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LogTitle", model.LogTitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 批量审核日志
        /// <summary>
        /// 批量审核日志
        ///</summary>
        public int LogAudit(string ids, SpaceLogEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_Audit";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("IDS", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("IsAduit", model.IsAduit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
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


        #region 更新私密日志
        /// <summary>
        /// 更新私密日志
        /// </summary>
        /// <param name="egid"></param>
        /// <returns></returns>
        public int UpdateIsPublish(int egid, int ispublish)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_UpdateIsPublish";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("EGID", egid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsPublish", ispublish, DatabaseType.SQL_Int, 4));
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


        #region 更新点赞人数
        /// <summary>
        /// 更新点赞
        /// </summary>
        /// <param name="egid">日志id</param>
        /// <param name="userid">当前登录用户</param>
        /// <param name="flag">标识1.日志  2.图片</param>
        /// <returns></returns>
        public int UpdatePeoNum(int egid, string userid, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_UpdatePeoNum";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("EGID", egid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SysID", userid, DatabaseType.SQL_NVarChar, 40));
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


        #region 获取学生活动日志
        public DataTable GetList(string said, int sflag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceLog_GetList";
            DbParameters.Add(new DatabaseParameter("SAID", said, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SFlag", sflag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        } 
        #endregion
    }
}