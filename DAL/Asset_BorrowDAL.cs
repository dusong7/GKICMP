/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      fzh
** 创建日期:      2016年11月10日 17时37分48秒
** 描    述:      资产借出/领用的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;



namespace GK.GKICMP.DAL
{
    public partial class AssetBorrowDAL : DataEntity<Asset_BorrowEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Asset_BorrowEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Borrow_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ABID", model.ABID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AID", model.AID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ABUser", model.ABUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ABFlag", model.ABFlag, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("ABState", model.ABState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ABMak", model.ABMak, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));

            DbParameters.Add(new DatabaseParameter("AssetNum", model.AssetNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserDate", model.UserDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Flag", model.Flag, DatabaseType.SQL_Int, 4));

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


        #region 根据主键编号集合修改状态
        /// <summary>
        /// 根据主键编号集合修改状态
        ///</summary>
        public int UpdateBack(string ids, int state)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Borrow_UpdateBack";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("ABState", state, DatabaseType.SQL_Int, 4));
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
            ProcedureName = "up_Tb_Asset_Borrow_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
        public Asset_BorrowEntity GetObjByID(int id)
        {
            string sql = "select a.*,dbo.getUserName(ABUser) as ABUserName,(case when a.Flag=2 then dbo.getDataName(DataType) else dbo.getAssetTypeName(DataType) end) as TypeName,b.DataDesc,b.AssetName FROM [Tb_Asset_Borrow] a inner join Tb_Asset b on a.AID = b.AID WHERE ABID=" + id;

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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, string assetname, int datatype, string abusername, Asset_BorrowEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Borrow_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AssetName", assetname, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataType", datatype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ABUserName", abusername, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("ABFlag", model.ABFlag, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("Flag", model.Flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));


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

