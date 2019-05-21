/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月11日 13时53分00秒
** 描    述:      数据的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;



namespace GK.GKICMP.DAL
{
    public partial class Exam_StudentDAL : DataEntity<Exam_StudentEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Exam_StudentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Student_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ESID", model.ESID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ERID", model.ERID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StID", model.StID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Score1", model.Score1, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score2", model.Score2, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score3", model.Score3, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score4", model.Score4, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score5", model.Score5, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score6", model.Score6, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score7", model.Score7, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score8", model.Score8, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score9", model.Score9, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score10", model.Score10, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score11", model.Score11, DatabaseType.SQL_Decimal, 5));
            DbParameters.Add(new DatabaseParameter("Score12", model.Score12, DatabaseType.SQL_Decimal, 5));

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
        public int update(Exam_CJ model) 
        {
            DbParameters.Clear();
            int result = 0;
            string sql = "update tb_exam_student set " + model.Code + "=" + model.Score + " where eid=" + model.EID + " and stid='" + model.StID + "'";
            ProcedureName = "up_Tb_Exam_Student_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("sql", sql, DatabaseType.SQL_NVarChar,4000));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[1].Value);



            //DataAccessChannelProtection = true;
            //string sql = "update tb_exam_student set "+model.Code+"="+model.Score+" where eid="+model.EID+" and stid='"+model.StID+"'";
            //STMessage stmessage = ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION,sql).DataReturn;
            //DataAccessChannelProtection = false;
            //return stmessage.AffectRows;
        }

        public int UpdateByScore(List<Exam_CJ> list) 
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (Exam_CJ ec in list)
                    {
                        int result = 0;
                        Exam_CJ model = ec;
                        result = update(model);
                        if (result == -1)
                        {
                            resultvalue = -1;
                            return resultvalue;
                        }
                        if (result == -2)
                        {
                            resultvalue = -2;
                            break;
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
                    }
                    else if (resultvalue == -2)
                    {
                        resultvalue = -2;
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

        public int UpdateByImport(List<Exam_StudentEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (Exam_StudentEntity ec in list)
                    {
                        int result = 0;
                        Exam_StudentEntity model = ec;
                        result = UpdateImport(model);
                        if (result == -1)
                        {
                            resultvalue = -1;
                            return resultvalue;
                        }
                        if (result == -2)
                        {
                            resultvalue = -2;
                            break;
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
                    }
                    else if (resultvalue == -2)
                    {
                        resultvalue = -2;
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

        public int UpdateImport(Exam_StudentEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Student_UpdateImport ";
            string update = "set ";
            if (model.Score1 != 0)
                update += "Score1=" + (model.Score1 == -1 ? 0 : model.Score1) + ",";
            if (model.Score2 != 0)
                update += "Score2=" + (model.Score2 == -1 ? 0 : model.Score2) + ",";
            if (model.Score3 != 0)
                update += "Score3=" + (model.Score3 == -1 ? 0 : model.Score3) + ",";
            if (model.Score4 != 0)
                update += "Score4=" + (model.Score4 == -1 ? 0 : model.Score4) + ",";
            if (model.Score5 != 0)
                update += "Score5=" + (model.Score5 == -1 ? 0 : model.Score5) + ",";
            if (model.Score6 != 0)
                update += "Score6=" + (model.Score6 == -1 ? 0 : model.Score6) + ",";
            if (model.Score7 != 0)
                update += "Score7=" + (model.Score7 == -1 ? 0 : model.Score7) + ",";
            if (model.Score8 != 0)
                update += "Score8=" + (model.Score8 == -1 ? 0 : model.Score8) + ",";
            if (model.Score9 != 0)
                update += "Score9=" + (model.Score9 == -1 ? 0 : model.Score9) + ",";
            if (model.Score10 != 0)
                update += "Score10=" + (model.Score10 == -1 ? 0 : model.Score10) + ",";
            if (model.Score11 != 0)
                update += "Score11=" + (model.Score11 == -1 ? 0 : model.Score11) + ",";
            if (model.Score12 != 0)
                update += "Score12=" + (model.Score12 == -1 ? 0 : model.Score12) + ",";
            string sql = "update tb_exam_student " + update.TrimEnd(',') + " where eid=" + model.EID + " and stid=dbo.getIDCard('" + model.StID+"')";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            //DbParameters.Add(new DatabaseParameter("IDCard", model.StID, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("sql", sql, DatabaseType.SQL_NVarChar, 2000));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Student_DelBat";
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


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetStuByEid(int eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Student_GetStuByEid";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据考试id获取学生成绩统计
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetScore(int eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Score_Paged";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        #region 根据考试id获取学生成绩统计
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetList(int eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Score_GetList";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetZH(int eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Score_GetZH";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_Int, 4));

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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Exam_StudentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Student_Paged";
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

        #region 我的考试-成绩详情
        /// <summary>
        /// 我的考试-成绩详情
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetMyStuByEid(int eid,string userid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Student_GetMyStuByEid";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

    }
}

