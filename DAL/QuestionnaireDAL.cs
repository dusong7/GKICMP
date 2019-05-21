/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年02月10日 14时16分42秒
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
    public partial class QuestionnaireDAL : DataEntity<QuestionnaireEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(int id, QuestionnaireEntity model, string roles)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("QID", model.QID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("QuestName", model.QuestName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Questxplain", model.Questxplain, DatabaseType.SQL_Text, 9000));
            DbParameters.Add(new DatabaseParameter("IsRealName", model.IsRealName, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LastDate", model.LastDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("QestCrowd", model.QestCrowd, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Roles", roles, DatabaseType.SQL_NVarChar, 200));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
        }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_DelBat";
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
        public QuestionnaireEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getUserName(CreateUser) as CreateUserName FROM [Tb_Questionnaire] WHERE [QID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 根据问卷id获取投票角色
        /// <summary>
        /// 根据问卷id获取投票角色
        /// </summary>
        /// <param name="qid"></param>
        /// <returns></returns>
        public DataTable GetRoleTable(string qid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Role_Paged";
            DbParameters.Add(new DatabaseParameter("QID", qid, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, QuestionnaireEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("QuestName", model.QuestName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[6].Value);
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
        public DataTable GetPagedByRoleid(int pagesize, int pageindex, ref int recordCount, QuestionnaireEntity model, DateTime begin, DateTime end, string uid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_PagedByRoleid";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("QuestName", model.QuestName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("uid", uid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 是否发布
        /// <summary>
        /// 是否发布
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateIsPublic(QuestionnaireEntity model, string qids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_UpdateIsPublish";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("QIDs", qids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

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
