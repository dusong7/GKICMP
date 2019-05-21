/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月08日 10时40分33秒
** 描    述:      选课分数操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Transactions;
using System.Collections.Generic;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;



namespace GK.GKICMP.DAL
{
    public partial class Electiver_ScoreDAL : DataEntity<Electiver_ScoreEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Electiver_ScoreEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Score_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SSID", model.SSID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EleID", model.EleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StID", model.StID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Score", model.Score, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CourseID", model.CourseID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TermID", model.TermID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));

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
            ProcedureName = "up_Tb_Electiver_Score_DelBat";
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
        public Electiver_ScoreEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Score_Get";
            DbParameters.Add(new DatabaseParameter("SSID", id, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Electiver_ScoreEntity model, string elename)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Score_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("ElectiverName", elename, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TermID", model.TermID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CourseID", model.CourseID, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据实体条件分页获取选课任务数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取选课任务数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetScorePaged(int pagesize, int pageindex, ref int recordCount, ElectiverEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_PagedScore";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("ElectiverName", model.ElectiverName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TermID", model.TermID, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        public int Import(List<Electiver_ScoreEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (Electiver_ScoreEntity ec in list)
                    {

                        Electiver_ScoreEntity model = ec;
                        int result = Edit(model);
                        if (result <= 0)
                        {
                            resultvalue = -1;
                            return resultvalue;
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
                    }
                    else
                    {
                        resultvalue = -99;
                    }
                }
                catch (Exception)
                {
                    resultvalue = -99;
                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }
    }
}