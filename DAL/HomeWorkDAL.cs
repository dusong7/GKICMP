/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年07月01日 11时08分04秒
** 描    述:      作业布置基本操作类
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
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class HomeWorkDAL : DataEntity<HomeWorkEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(HomeWorkEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_HomeWork_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("HWID", model.HWID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("HomeWork", model.HomeWork, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("CompleteTime", model.CompleteTime, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClaName", model.ClaName, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsSend", model.IsSend, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Claids", model.Claids, DatabaseType.SQL_NVarChar, 4000));
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_HomeWork_DelBat";
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
        public HomeWorkEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getCourseName (cid) CidName,dbo.getCidsByID(HWID) Claids from Tb_HomeWork where HWID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, HomeWorkEntity model, DateTime begindate, DateTime enddate,int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_HomeWork_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSend", model.IsSend, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 12));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 12));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 个人空间作业信息
        /// <summary>
        /// 个人空间作业信息
        /// </summary>
        /// <param name="claid"></param>
        /// <returns></returns>
        public DataTable GetList(string id,int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_HomeWork_GetList";

            DbParameters.Add(new DatabaseParameter("UserID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion



        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int EditApp(HomeWorkEntity model,string uids)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_HomeWork_AddApp";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("HWID", model.HWID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("HomeWork", model.HomeWork, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("CompleteTime", model.CompleteTime, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClaName", model.ClaName, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsSend", model.IsSend, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Claids", model.Claids, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("uids", uids, DatabaseType.SQL_NVarChar, 4000));
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
    }
}

