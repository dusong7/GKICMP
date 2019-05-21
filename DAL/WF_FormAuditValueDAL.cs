/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      袁纪坤
** 创建日期:      2017年11月09日 09时48分24秒
** 描    述:      自由流审核值实体类
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
    public partial class WF_FormAuditValueDAL : DataEntity<WF_FormAuditValueEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(WF_FormAuditValueEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_FormAuditValue_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("FAVID", model.FAVID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WFFID", model.WFFID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FAID", model.FAID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("URID", model.URID, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("FAVType", model.FAVType, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            try
            {
                result = Convert.ToInt32(stmessage.DataRecords.Tables[0].Rows[0]["FAVID"]);
            }
            catch
            {
                result = -1;
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return result;
        }
        #endregion


        #region 根据删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int Delete(string wffid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_FormAuditValue_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("WFFID", wffid, DatabaseType.SQL_NVarChar, 1000));
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
        public WF_FormAuditValueEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_WF_FormAuditValue where [FAVID]='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public WF_FormAuditValueEntity GetObjByUID(string uid, string faid)
        {
            string sql = "select * from Tb_WF_FormAuditValue where [URID]='" + uid + "' and [FAID]='" + faid + "'";
            
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

     

        #region 获取数据集，返回DataSet
        /// <summary>
        /// 获取数据集，返回DataSet
        /// </summar

        public DataTable GetTable(int faid, int type = 1, string wffid = "")
        {
            string sql = "select * " + (type == 1 ? ",dbo.getUserName(URID) as 'Name'" : ",dbo.getRoleName(URID) as 'Name'") + " from Tb_WF_FormAuditValue where [FAVID]>0 and [FAID]='" + faid + "'";
            if (!string.IsNullOrEmpty(wffid))
            {
                sql = sql + " and [WFFID]='" + wffid + "'";
            }
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

    }


}
