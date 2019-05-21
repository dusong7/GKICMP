/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年02月13日 09时55分58秒
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
    public partial class Questionnaire_OptionDAL : DataEntity<Questionnaire_OptionEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Questionnaire_OptionEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Option_Add";
            DataAccessChannelProtection = true;

            // DbParameters.Add(new DatabaseParameter("OID", model.OID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("QSID", model.QSID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("OptionContent", model.OptionContent, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("OptionVlaue", model.OptionVlaue, DatabaseType.SQL_NVarChar, 5));

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
        public int DeleteBat(int ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Option_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("QSID", ids, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Questionnaire_OptionEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Option_Paged";
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


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedByQSID(int QSID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Option_PagedByQSID";
            DbParameters.Add(new DatabaseParameter("QSID", QSID, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        //public DataTable GetPagedByQSID(int QSID,int type)
        //{
        //    DbParameters.Clear();
        //    ProcedureName = "up_Tb_Questionnaire_Option_PagedByQSID";
        //    DbParameters.Add(new DatabaseParameter("QSID", QSID, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("Type", type, DatabaseType.SQL_Int, 4));
        //    if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return DataReflectionContainer;
        //}
        #endregion
    }
}
