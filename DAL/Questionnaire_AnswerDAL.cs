/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年03月27日 17时09分49秒
** 描    述:      资源管理的基本操作类
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
    public partial class Questionnaire_AnswerDAL : DataEntity<Questionnaire_AnswerEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Questionnaire_AnswerEntity model, string QSID)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Answer_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("QAID", model.QAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("QID", model.QID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("QSID", QSID, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("OID", model.OID, DatabaseType.SQL_NVarChar, 4000));
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
            ProcedureName = "up_Tb_Questionnaire_Answer_PagedByQSID";
            DbParameters.Add(new DatabaseParameter("QSID", QSID, DatabaseType.SQL_Int, 4));

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
        public DataTable GetResult(int QSID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Questionnaire_Answer_ResultList";
            DbParameters.Add(new DatabaseParameter("QSID", QSID, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #endregion
    }

}

