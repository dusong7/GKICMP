/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月24日 14时38分19秒
** 描    述:      角色数据的基本操作类
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
    public partial class Asset_ScrapDAL : DataEntity<Asset_ScrapEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Asset_ScrapEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Scrap_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ASID", model.ASID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AID", model.AID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ASNum", model.ASNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ASMark", model.ASMark, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ASDate", model.ASDate, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Asset_ScrapEntity model, string assetname)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Scrap_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AssetName", assetname, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string asid, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Scrap_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ASID", asid, DatabaseType.SQL_NVarChar, 2000));
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
        public Asset_ScrapEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_Asset_Scrap where ASID in (select * from dbo.f_split('" + id + "',','))";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Scrap_Update";
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
