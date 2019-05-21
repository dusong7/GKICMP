/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月20日 11时20分55秒
** 描    述:      备课计划清单操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class LessonPlan_DetailDAL : DataEntity<LessonPlan_DetailEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(LessonPlan_DetailEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LDID", model.LDID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("WeekNum", model.WeekNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PDate", model.PDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AContent", model.AContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("TIDS", model.TIDS, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsPrepare", model.IsPrepare, DatabaseType.SQL_Int, 4));

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
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_DelBat";
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
        public LessonPlan_DetailEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_Get";
            DbParameters.Add(new DatabaseParameter("LDID", id, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, LessonPlan_DetailEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_Paged";
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


        #region 根据备课计划ID查找计划清单
        /// <summary>
        /// 根据备课计划ID查找计划清单
        /// </summary>
        public DataTable GetList(string lid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_GetList";
            DbParameters.Add(new DatabaseParameter("LID", lid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 获取最大周次信息
        public int GetMaxWeekNum(string lid)
        {
            int week = 1;
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_GetWeek";
            DbParameters.Add(new DatabaseParameter("LID", lid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                week = Convert.ToInt32(dv.Table.Rows[0]["WeekNum"].ToString());
            }
            return week;
        } 
        #endregion


        #region 我的备课页面
        public DataTable GetPersonPaged(int pagesize, int pageindex, ref int recordCount, string lname, string acontent, int ltype, string userid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_PersonPaged";

            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LName", lname, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("LType", ltype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AContent", acontent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        } 
        #endregion


        #region 备课综合查询
        public DataTable GetSerachPaged(int pagesize, int pageindex, ref int recordCount, string lname, string acontent, int ltype, string lyear, int tid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LessonPlan_Detail_SerachPaged";

            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LName", lname, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("LType", ltype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AContent", acontent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("LYear", lyear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TID", tid, DatabaseType.SQL_Int, 4));

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