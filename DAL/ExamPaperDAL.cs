/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年09月04日 15时34分23秒
** 描    述:      试卷管理基本操作类
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
    public partial class ExamPaperDAL : DataEntity<ExamPaperEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ExamPaperEntity model, string eids)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EPID", model.EPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PaperName", model.PaperName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeID", model.GradeID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Minutes", model.Minutes, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("eids", eids, DatabaseType.SQL_NVarChar, 4000));
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
        public int DeleteByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", id, DatabaseType.SQL_NVarChar, 2000));

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
        public ExamPaperEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getCourseName(CID) CIDName from Tb_ExamPaper where EPID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ExamPaperEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("GradeID", model.GradeID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PaperName", model.PaperName, DatabaseType.SQL_NVarChar, 200));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 添加一条组卷记录
        /// <summary>
        /// 添加一条组卷记录
        ///</summary>
        public int Update(ExamPaperEntity model, int dxx, int dxt, int tkt, int pdt, int zgt, int Difficulty)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EPID", model.EPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PaperName", model.PaperName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeID", model.GradeID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Minutes", model.Minutes, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("dxx", dxx, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("dxt", dxt, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("tkt", tkt, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pdt", pdt, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("zgt", zgt, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Difficulty", Difficulty, DatabaseType.SQL_Int, 4));
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
    }
}

