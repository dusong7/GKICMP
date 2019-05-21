/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年01月03日 15时38分00秒
** 描    述:      学生选课基本操作类
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
    public partial class Electiver_StuDAL : DataEntity<Electiver_StuEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Electiver_StuEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Stu_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ESID", model.ESID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EleID", model.EleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CorseID", model.CorseID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StuID", model.StuID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EleDate", model.EleDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
          //  DbParameters.Add(new DatabaseParameter("GroupID", model.GroupID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsBack", model.IsBack, DatabaseType.SQL_Int, 4));
           // DbParameters.Add(new DatabaseParameter("BackDate", model.BackDate, DatabaseType.SQL_DateTime, 8));

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
        public DataTable GetPaged(Electiver_StuEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Stu_Get";
            DbParameters.Add(new DatabaseParameter("EleID", model.EleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GroupID", model.GroupID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsBack", model.IsBack, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));

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
        public DataTable GetCourseByStu(int pagesize, int pageindex, ref int recordCount, string stuid, string year, int term)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Stu_GetCourseByStu";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("StuID", stuid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("year", year, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("term", term, DatabaseType.SQL_Int, 4));

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
        public DataTable GetList(int eleid,int cid,int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Stu_GetList";
            DbParameters.Add(new DatabaseParameter("EleID", eleid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        public int Check(string userid,int eleid)
        {
            DbParameters.Clear();
            int result = 0;
            ProcedureName = "up_Tb_Electiver_Stu_Check";
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EleID", eleid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            result = Convert.ToInt32(DbParameters[0].Value);
            return result;
        }
    }

}

