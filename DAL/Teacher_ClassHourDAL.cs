/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月15日 10时03分05秒
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
using System.Transactions;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;


namespace GK.GKICMP.DAL
{
    public partial class Teacher_ClassHourDAL : DataEntity<Teacher_ClassHourEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Teacher_ClassHourEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_ClassHour_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("THID", model.THID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("GradeID", model.GradeID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MainSubject", model.MainSubject, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("MainHours", model.MainHours, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PartSubject", model.PartSubject, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PartHours", model.PartHours, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("TotelHours", model.TotelHours, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Executive", model.Executive, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SchoolYear", model.SchoolYear, DatabaseType.SQL_NVarChar, 10));
            DbParameters.Add(new DatabaseParameter("Semester", model.Semester, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubDesc", model.SubDesc, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("THDesc", model.THDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("result", DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = Convert.ToInt32(DbParameters[0].Value);
            return result;

        }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_ClassHour_DelBat";
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
        public Teacher_ClassHourEntity GetObjByID(string id)
        {
            string sql = "SELECT a.*,b.RealName,b.IDCardNum FROM [Tb_Teacher_ClassHour] a inner join Tb_Teacher b on a.TID=b.TID WHERE [THID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Teacher_ClassHourEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_ClassHour_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            // DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MainSubject", model.MainSubject, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Semester", model.Semester, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SchoolYear", model.SchoolYear, DatabaseType.SQL_NVarChar, 10));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 教师课时导入
        /// <summary>
        /// 教师课时导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Import(Teacher_ClassHourEntity[] list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    for (int i = 0; i < list.Length; i++)
                    {
                        int result = 0;
                        Teacher_ClassHourEntity model = list[i];
                        if (model != null)
                        {
                            result = Edit(model);
                            if (result == -1)
                            {
                                resultvalue = -1;
                                return resultvalue;
                            }
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
        #endregion

        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_ClassHour_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 1000));
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

