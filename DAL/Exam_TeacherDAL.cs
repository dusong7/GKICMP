/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月11日 13时55分15秒
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
using System.Collections.Generic;
using System.Transactions;


namespace GK.GKICMP.DAL
{
    public partial class Exam_TeacherDAL : DataEntity<Exam_TeacherEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Exam_TeacherEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Teacher_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ETID", model.ETID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ERID", model.ERID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));

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

        public int SetTeacher(ExamSetEntity model)
        {
            DbParameters.Clear();
            int result = 0;
            ProcedureName = "up_Tb_Exam_Teacher_SetTeacher";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));//科目id
            DbParameters.Add(new DatabaseParameter("EID", model.Exam, DatabaseType.SQL_NVarChar, 40));//考试id
            DbParameters.Add(new DatabaseParameter("ERID", model.ERoom, DatabaseType.SQL_Int, 4));//考场id
            DbParameters.Add(new DatabaseParameter("RoomNum", model.RoomNum, DatabaseType.SQL_Int, 4));//考场号
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 500));//监考教师
            DbParameters.Add(new DatabaseParameter("TNum", model.TNum, DatabaseType.SQL_Int, 4));//教师数
            DbParameters.Add(new DatabaseParameter("StuNum", model.StuNum, DatabaseType.SQL_Int, 4));//学生数

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        public int SetTeacher(List<ExamSetEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (ExamSetEntity es in list)
                    {
                        int result = 0;
                        ExamSetEntity model = es;
                        result = SetTeacher(model);
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Teacher_DelBat";
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

        /// <summary>
        /// 获取符合条件的监考老师列表
        /// </summary>
        /// <param name="eid">考试id</param>
        /// <returns></returns>
        public DataTable GetTList(int eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Teacher_GetTList";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }


        /// <summary>
        /// 获取监考老师
        /// </summary>
        /// <param name="eid">考试ID</param>
        /// <param name="erid">考场ID</param>
        /// <param name="cid">监考科目</param>
        /// <returns></returns>
        public DataTable GetByObj(string eid, int erid, int cid)
        {
            //DbParameters.Clear();
            //ProcedureName = "up_Tb_Exam_Teacher_Get";

            //DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("ERID", erid, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            string sql = "SELECT * FROM [Tb_Exam_Teacher] WHERE [EID] = '" + eid + "' AND ERID=" + erid + " AND CID=" + cid;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Exam_TeacherEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Teacher_Paged";
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


        /// <summary>
        /// 获取监考老师
        /// </summary>
        /// <param name="eid">考试ID</param>
        /// <param name="erid">考场ID</param>
        /// <param name="cid">监考科目</param>
        /// <returns></returns>
        public DataTable GetByEID(string eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_Teacher_GetByEID";

            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }

}

