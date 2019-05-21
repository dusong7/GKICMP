/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月20日 17时25分35秒
** 描    述:      备课操作类
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
    public partial class LessonDAL : DataEntity<LessonEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(LessonEntity model, int isprepare)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("LesID", model.LesID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LDID", model.LDID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ActivityAddress", model.ActivityAddress, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("PDate", model.PDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AContent", model.AContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ActivityPre", model.ActivityPre, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ActivityTarget", model.ActivityTarget, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("ActivityContent", model.ActivityContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("Speaker", model.Speaker, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Assistant", model.Assistant, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ClaIDs", model.ClaIDs, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LastUser", model.LastUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsPrepare", isprepare, DatabaseType.SQL_Int, 4));

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
            ProcedureName = "up_Tb_Lesson_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
        public LessonEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Get";
            DbParameters.Add(new DatabaseParameter("LesID", id, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, LessonEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据备课计划清单ID获取备课信息
        /// <summary>
        /// 根据备课计划清单ID获取备课信息
        /// </summary>
        /// <param name="id">备课计划清单ID</param>
        /// <returns></returns>
        public DataTable GetList(string id)
        {
            string sql = "select * from Tb_Lesson where LDID='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        public DataTable GetList(string tid, int term, string year)
        {
            string sql = "select a.*,b.Lname,b.LType,dbo.getUserNames(Speaker)SpeakerNames,dbo.getUserNames(Assistant)AssistantNames,dbo.getClassNames(ClaIDs)ClaIDName from Tb_Lesson a inner join Tb_LessonPlan b on a.lid=b.lid where a.LID in (select lid from Tb_LessonPlan_Detail where TIDS  like '%" + tid + "%' and lid in (select lid from Tb_LessonPlan where LYear='" + year + "' and TID=" + term + ")) ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }
}