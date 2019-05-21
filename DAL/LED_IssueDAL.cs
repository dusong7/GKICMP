/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年11月29日 10时56分33秒
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
    public partial class LED_IssueDAL : DataEntity<LED_IssueEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(LED_IssueEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LED_Issue_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("LIID", model.LIID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LID", model.LID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IContent", model.IContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("FontSize", model.FontSize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FontType", model.FontType, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("StopTime", model.StopTime, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Translate", model.Translate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LWidth", model.LWidth, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IFlag", model.IFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("BeginTime", model.BeginTime, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("EndTime", model.EndTime, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("IName", model.IName, DatabaseType.SQL_NVarChar, 100));
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
            ProcedureName = "up_Tb_LED_Issue_DelBat";
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
        public LED_IssueEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LED_Issue_Get";
            DbParameters.Add(new DatabaseParameter("LIID", id, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, LED_IssueEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_LED_Issue_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LName", model.LName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
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

