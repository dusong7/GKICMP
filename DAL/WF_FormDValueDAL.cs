/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      袁纪坤
** 创建日期:      2017年11月09日 09时48分24秒
** 描    述:      自由流表单数据值类
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
    public partial class WF_FormDValueDAL : DataEntity<WF_FormDValueEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(WF_FormDValueEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_FormDValue_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("FDVID", model.FDVID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FDID", model.FDID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FDValue", model.FDValue, DatabaseType.SQL_NVarChar, 200));

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



        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public WF_FormDValueEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_WF_FormDValue where [FDVID]='" + id + "'";
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

        public DataTable GetTable(string fdid = "")
        {
            string sql = "select * from Tb_WF_FormDValue where [FDVID]>0 ";
            if (!string.IsNullOrEmpty(fdid))
            {
                sql = sql + " and [FDID]=" + fdid;
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
