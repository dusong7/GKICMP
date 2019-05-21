/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      袁纪坤
** 创建日期:      2017年11月09日 09时48分24秒
** 描    述:      自由流表单数据类
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
    public partial class WF_FormDataDAL : DataEntity<WF_FormDataEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(WF_FormDataEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_FormData_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("FDID", model.FDID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WFFID", model.WFFID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FPID", model.FPID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FDOrder", model.FDOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FDType", model.FDType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FDValue", model.FDValue, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsRequired", model.IsRequired, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            try
            {
                result = Convert.ToInt32(stmessage.DataRecords.Tables[0].Rows[0]["FDID"]);
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
            ProcedureName = "up_Tb_WF_FormData_DelBat";
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
        public WF_FormDataEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_WF_FormData where [FDID]='" + id + "'";
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

        public DataTable GetTable(string wffid = "", int isrequired = 0, bool isdel = false)
        {
            string sql = "select * from Tb_WF_FormData where [FDID]>0 ";
            if (!string.IsNullOrEmpty(wffid))
            {
                sql = sql + " and [WFFID]='" + wffid + "'";
            }
            if (isrequired != 0)
            {
                sql = sql + " and [IsRequired]='" + isrequired + "'";
            }
            if (isdel)
            {
                sql = sql + " and [IsDel]=0";
            }
            sql = sql + " order by [WFFID],[FDOrder]";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

    }


}
