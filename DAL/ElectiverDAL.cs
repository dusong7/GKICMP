/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月03日 08时46分45秒
** 描    述:      报修操作类
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
    public partial class ElectiverDAL : DataEntity<ElectiverEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ElectiverEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EleID", model.EleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ElectiverName", model.ElectiverName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EBegin", model.EBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EEnd", model.EEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TermID", model.TermID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EstimateBDate", model.EstimateBDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EstimateEDate", model.EstimateEDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EStopDate", model.EStopDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EState", model.EState, DatabaseType.SQL_Int, 4));


            DbParameters.Add(new DatabaseParameter("Ecount", model.Ecount, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EIsAudit", model.EIsAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsEstmate", model.IsEstmate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRelation", model.IsRelation, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value.ToString());
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
            ProcedureName = "up_Tb_Electiver_DelBat";
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int StopEle(int id, int state)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Stop";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("EleID", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EState", state, DatabaseType.SQL_Int, 4));
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
        public ElectiverEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Get";
            DbParameters.Add(new DatabaseParameter("EleID", id, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ElectiverEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Paged";
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


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedApp(int pagesize, int pageindex, ref int recordCount, ElectiverEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_PagedApp";
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



        #region 获取任务 返回dataset
        public DataTable GetTable()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_GetTable";
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
        public DataTable PagedOnlineAPP(int pagesize, int pageindex, ref int recordCount, ElectiverEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_PagedOnlineAPP";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            //DbParameters.Add(new DatabaseParameter("ElectiverName", model.ElectiverName, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EState", model.EState, DatabaseType.SQL_Int, 4));

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
