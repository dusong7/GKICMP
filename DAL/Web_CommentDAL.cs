/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月01日 08点39分
** 描   述:      评论与留言实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;
using gk.rjb_Y.Libraries;
using GK.GKICMP.Entities;
using System;
using System.Data;

namespace GK.GKICMP.DAL
{
    public partial class Web_CommentDAL : DataEntity<Web_CommentEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Web_CommentEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Comment_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ComTitle", model.ComTitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("ComContent", model.ComContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("LinkUser", model.LinkUser, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("LinkType", model.LinkType, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("ConState", model.ConState, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CFlag", model.CFlag, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Web_CommentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Comment_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("ComTitle", model.ComTitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CFlag", model.CFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("SID", model.SID, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
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
            ProcedureName = "up_Tb_Web_Comment_DelBat";
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
        public Web_CommentEntity Get(int id)
        {
            string sql = "SELECT * FROM [Tb_Web_Comment] WHERE [CID] = " + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 根据主键编号集合更新状态
        /// <summary>
        /// 根据主键编号集合更新状态
        ///</summary>
        public int Update(Web_CommentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Comment_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ReplyContent", model.ReplyContent, DatabaseType.SQL_NVarChar, 500));

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


        #region 根据主键编号集合更新是否公开
        /// <summary>
        /// 根据主键编号集合更新是否公开
        ///</summary>
        public int UpdatePublish(Web_CommentEntity model, string cids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Comment_UpdatePublish";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("CIDs", cids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("ConState", model.ConState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
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


    }
}
