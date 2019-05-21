/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年09月11日 10时08分46秒
** 描    述:      补卡审核基本操作类
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
    public partial class NoCardApplyDAL : DataEntity<NoCardApplyEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(NoCardApplyEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_NoCardApply_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ID", model.ID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("NoCardApplyUser", model.NoCardApplyUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("NoCardApplyDate", model.NoCardApplyDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("NoCardState", model.NoCardState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NoCardApplyDesc", model.NoCardApplyDesc, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("NoCardAuditUser", model.NoCardAuditUser, DatabaseType.SQL_NVarChar, 50));

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


        #region 获取补卡记录，返回DataSet
        /// <summary>
        /// 获取补卡记录，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedApp(int pagesize, int pageindex, ref int recordCount, NoCardApplyEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NoCardApply_PagedApp";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NoCardState", model.NoCardState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NoCardApplyUser", model.NoCardApplyUser, DatabaseType.SQL_NVarChar, 50));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NoCardApply_DelBat";
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
        public NoCardApplyEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NoCardApply_Get";
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_VarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion



        #region 审核
        /// <summary>
        /// 审核
        ///</summary>
        public int Audit(NoCardApplyEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NoCardApply_Audit";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("NoCardState", model.NoCardState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NoCardAuditDesc", model.NoCardAuditDesc, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("ID", model.ID, DatabaseType.SQL_VarChar, 40));
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


        //#region 根据实体条件获取数据集，返回实体集合
        ///// <summary>
        ///// 根据实体条件获取数据集，返回实体集合
        ///// </summary>
        ///// <param name="model">条件实体</param>
        //public List<NoCardApplyEntity> GetList(NoCardApplyEntity model)
        //{  
        //   DbParameters.Clear();
        //   ProcedureName ="up_Tb_ScoreEvent_Paged";
        //    List<NoCardApplyEntity> res = new List<NoCardApplyEntity>();
        //    DbParameter[] parms = {
        //             DbParameters.Add(new DatabaseParameter("EventName", (DbType)SqlDbType.SQL_NVarChar, 200, model.EventName);
        //             DbParameters.Add(new DatabaseParameter("EType", (DbType)SqlDbType.SQL_Int, 4, model.EType);
        //             DbParameters.Add(new DatabaseParameter("SFlag", (DbType)SqlDbType.SQL_Int, 4, model.SFlag);
        //             DbParameters.Add(new DatabaseParameter("begin", (DbType)SqlDbType.SQL_DateTime, 8, model.begin);
        //             DbParameters.Add(new DatabaseParameter("end", (DbType)SqlDbType.SQL_DateTime, 8, model.end);
        //             DbParameters.Add(new DatabaseParameter("isdel", (DbType)SqlDbType.SQL_Int, 4, model.isdel);
        //             DbParameters.Add(new DatabaseParameter("pagesize", (DbType)SqlDbType.SQL_Int, 4, model.pagesize);
        //             DbParameters.Add(new DatabaseParameter("pageindex", (DbType)SqlDbType.SQL_Int, 4, model.pageindex);
        //             DbParameters.Add(new DatabaseParameter("recordCount", (DbType)SqlDbType.SQL_Int, 4, model.recordCount);
        //             DbParameters.Add(new DatabaseParameter("ExceptionCode", (DbType)SqlDbType.SQL_Int, 4, model.ExceptionCode);
        //             DbParameters.Add(new DatabaseParameter("ExceptionMessage", (DbType)SqlDbType.SQL_VarChar, 2048, model.ExceptionMessage);
        //     if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    recordCount = Convert.ToInt32(DbParameters[2].Value);
        //    return DataReflectionContainer;
        //}
        //#endregion 

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, NoCardApplyEntity model, DateTime begin, DateTime end,int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NoCardApply_PagedPC";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NoCardState", model.NoCardState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("NoCardApplyUser", model.NoCardApplyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("NoCardAuditUser", model.NoCardAuditUser, DatabaseType.SQL_NVarChar, 40));
           
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

    }

}

