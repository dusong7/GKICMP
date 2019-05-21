/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月26日 10时03分41秒
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
    public partial class Web_NewsDAL : DataEntity<Web_NewsEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Web_NewsEntity model,ref int nid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("NewsID", nid, DatabaseType.SQL_Int, 4,ParameterDirection.InputOutput));
            DbParameters.Add(new DatabaseParameter("NID", model.NID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NewsTitle", model.NewsTitle, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ImageUrl", model.ImageUrl, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("NContent", model.NContent, DatabaseType.SQL_Text, 20000));
            DbParameters.Add(new DatabaseParameter("LinkUrl", model.LinkUrl, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("NOrder", model.NOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ReadCount", model.ReadCount, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("MSourse", model.MSourse, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("NColor", model.NColor, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("IsTop", model.IsTop, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MDescription", model.MDescription, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRecommend", model.IsRecommend, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsImgNews", model.IsImgNews, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsComment", model.IsComment, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Nstate", model.Nstate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NTtitle", model.NTtitle, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("NKeyWords", model.NKeyWords, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("NDep", model.NDep, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NDescription", model.NDescription, DatabaseType.SQL_NVarChar, 200));
            // DbParameters.Add(new DatabaseParameter("PreStr", model.PreStr, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CommentNumber", model.CommentNumber, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UpdateUser", model.UpdateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UpdateDate", model.UpdateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("NAuthor", model.NAuthor, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("AduitDate", model.AduitDate, DatabaseType.SQL_DateTime, 8));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            nid =int.Parse(DbParameters[0].Value.ToString());
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
            ProcedureName = "up_Tb_Web_News_DelBat";
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
        public Web_NewsEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getUserName(NAuthor) NAuthorName,dbo.getWebMenuName(MID) as MName,dbo.getUserName(AduitUser) AduitUserName FROM [Tb_Web_News] WHERE [NID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Web_NewsEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("NewsTitle", model.NewsTitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NAuthor", model.NAuthor, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nstate", model.Nstate, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 查询需要审核文章列表（根据用户）
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetNewsAuditPaged(int pagesize, int pageindex, ref int recordCount, Web_NewsEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_NewsAuditPaged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("NewsTitle", model.NewsTitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion
        #region 查询需要审核文章列表（根据用户）
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetNewsPublishPaged(int pagesize, int pageindex, ref int recordCount, Web_NewsEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_NewsPublishPaged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("NewsTitle", model.NewsTitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Nstate", model.Nstate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据主键编号集合更新状态
        /// <summary>
        /// 根据主键编号集合更新状态
        ///</summary>
        public int Update(string ids, int nstate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("nstate", nstate, DatabaseType.SQL_Int, 4));
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


        #region 文章审核
        /// <summary>
        /// 文章审核
        ///</summary>
        public int NewsAudit(Web_NewsEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_Audit";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("NID", model.NID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsAudit", model.IsAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
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
        

        #region 新闻发布综合查询
        /// <summary>
        /// 新闻发布综合查询
        /// </summary>
        public DataTable GetNewsSearch(string realname, DateTime begindate, DateTime enddate, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_NewsSearch";
            DbParameters.Add(new DatabaseParameter("RealName", realname, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        /// <summary>
        /// 新闻发布综合查询详情
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetSearchDetail(string uid)
        {
            string sql = "select *  from Tb_Web_News where NAuthor='" + uid + "' and Isdel=0";
            
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        

        #region 网页爬虫-判断已存在的数据就不执行插入操作
        public int GetToNID(string ti, DateTime ne)
        {
            int id = -1;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_GetNID";
            DbParameters.Add(new DatabaseParameter("Title", ti, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("NewDate", ne, DatabaseType.SQL_DateTime, 8));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = Convert.ToInt32(dv.Table.Rows[0]["NID"].ToString());
            }
            return id;
        }
        #endregion

        #region 网页爬虫 添加一条记录
        /// <summary>
        /// 网页爬虫 添加一条记录
        ///</summary>
        public int EditAccept(Web_NewsEntity model, ref int nid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_AddAccept";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("NewsID", nid, DatabaseType.SQL_Int, 4, ParameterDirection.InputOutput));
            DbParameters.Add(new DatabaseParameter("NID", model.NID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NewsTitle", model.NewsTitle, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ImageUrl", model.ImageUrl, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("NContent", model.NContent, DatabaseType.SQL_Text, 20000));
            DbParameters.Add(new DatabaseParameter("LinkUrl", model.LinkUrl, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("NOrder", model.NOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ReadCount", model.ReadCount, DatabaseType.SQL_Int, 4));
           
            DbParameters.Add(new DatabaseParameter("NColor", model.NColor, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("IsTop", model.IsTop, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MDescription", model.MDescription, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRecommend", model.IsRecommend, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsImgNews", model.IsImgNews, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsComment", model.IsComment, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Nstate", model.Nstate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NTtitle", model.NTtitle, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("NKeyWords", model.NKeyWords, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("NDep", model.NDep, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NDescription", model.NDescription, DatabaseType.SQL_NVarChar, 200));
          
            DbParameters.Add(new DatabaseParameter("CommentNumber", model.CommentNumber, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UpdateUser", model.UpdateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UpdateDate", model.UpdateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("NAuthor", model.NAuthor, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));

            DbParameters.Add(new DatabaseParameter("IsAudit", model.IsAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitDate", model.AduitDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            nid = int.Parse(DbParameters[0].Value.ToString());
            return stmessage.AffectRows;
        }
        #endregion

    }
}

