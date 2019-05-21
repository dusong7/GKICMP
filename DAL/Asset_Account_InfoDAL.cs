/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月20日 14时54分55秒
** 描    述:      资产详细表基本操作类
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
    public partial class Asset_Account_InfoDAL : DataEntity<Asset_Account_InfoEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Asset_Account_InfoEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Account_Info_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AAIID", model.AAIID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AAID", model.AAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AccName", model.AccName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("AccNum", model.AccNum, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("AccUnit", model.AccUnit, DatabaseType.SQL_NVarChar, 10));
            DbParameters.Add(new DatabaseParameter("AccountCash", model.AccountCash, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("AIType", model.AIType, DatabaseType.SQL_Int, 4));

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



        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int DeleteByID(int aaiid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Account_Info_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("aaiid", aaiid, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(string  aaid,int aitype)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Account_Info_Paged";
            DbParameters.Add(new DatabaseParameter("aaid", aaid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("aitype", aitype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion



    }

}

