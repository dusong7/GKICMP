/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年09月08日 08时23分59秒
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


namespace GK.GKICMP.DAL
{
    public partial class RestTimeDAL : DataEntity<RestTimeEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(RestTimeEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_RestTime_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("RTID", model.RTID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RestName", model.RestName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("BeginTime", model.BeginTime, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndTime", model.EndTime, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("BeginTime", model.BeginTime, DatabaseType.SQL_Time, 8));
            //DbParameters.Add(new DatabaseParameter("EndTime", model.EndTime, DatabaseType.SQL_Time, 8));
            DbParameters.Add(new DatabaseParameter("BMID", model.BMID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EMID", model.EMID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RMID", model.RMID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Weeks", model.Weeks, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsUse", model.IsUse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRecording", model.IsRecording, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsGetSet", model.IsGetSet, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
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
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_RestTime_DelBat";
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


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, RestTimeEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_RestTime_Paged";
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


        #region 根据主键编号获取信息
        /// <summary>
        /// 根据主键编号获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public RestTimeEntity GetObj(int id)
        //{
        //    string sql = "select * from Tb_RestTime where RTID=" + id;
        //    if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return First();
        //}

        public DataTable GetObj(int id)
        {
            string sql = "select * from Tb_RestTime where RTID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        public DataTable GetList()
        {
            string sql = "select *,dbo.getRing(BMID)BMName,dbo.getRing(EMID)EMName,dbo.getRing(RMID)RMName from Tb_RestTime where Isdel=0 and IsUse=1";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }
}

