/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2016年11月17日 16时21分08秒
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
    public partial class GrantDAL : DataEntity<GrantEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(GrantEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grant_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("GType", model.GType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GMark", model.GMark, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("ApplyUrl", model.ApplyUrl, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("AduitDate", model.AduitDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
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

        #region 获取楼层名称
        /// <summary>
        /// 获取楼层名称
        /// </summary>
        /// <returns></returns>
        public GrantEntity GetObj(string fid)
        {
            string sql = "select *,dbo.getUserName(UID) UserName,dbo.getUserName(AduitUser) as AduitName from Tb_Grant where GID='" + fid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grant_DelBat";
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

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int Update(GrantEntity grant)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grant_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("GID", grant.GID, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("AduitDate", grant.AduitDate, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AduitState", grant.AduitState, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AduitUser", grant.AduitUser, DatabaseType.SQL_NVarChar, 40));
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

        public DataTable GetTable(string gid)
        {
            string sql = "SELECT * FROM [Tb_Grant] WHERE [GID] = '" + gid + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, GrantEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grant_Paged";
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
            return DataReflectionContainer;
        }
        public DataTable GetPagedSerach(int pagesize, int pageindex, ref int recordCount, GrantEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grant_PagedSerach";
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据实体条件分页获取数据集，返回DataSet ---助学金查询
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet ---助学金查询
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedSearch(int pagesize, int pageindex, ref int recordCount, GrantEntity model, string userid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grant_PagedSearch";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));

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
