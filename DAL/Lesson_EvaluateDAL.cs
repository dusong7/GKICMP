/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年10月21日 09时40分47秒
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
    public partial class Lesson_EvaluateDAL : DataEntity<Lesson_EvaluateEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Lesson_EvaluateEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Evaluate_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("LEID", model.LEID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EvalDate", model.EvalDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EvalUser", model.EvalUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Remark", model.Remark, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("Degree", model.Degree, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 30));
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




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids,int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Evaluate_DelBat";
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
        public Lesson_EvaluateEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Evaluate_Get";
            DbParameters.Add(new DatabaseParameter("LEID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ExceptionCode", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ExceptionMessage", id, DatabaseType.SQL_VarChar, 2048));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        public DataTable GetList(int isdel,string tid)
        {
            string sql = "select * from Tb_Lesson_Evaluate where TID='"+tid+"' and isdel="+isdel;
            //DbParameters.Clear();
            //ProcedureName = "up_Tb_Lesson_Evaluate_Paged";
            //DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredCommandtext (DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            
            return DataReflectionContainer;
        }


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Lesson_EvaluateEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lesson_Evaluate_Paged";
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


    }

}

