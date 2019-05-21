/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月22日 14时40分52秒
** 描    述:      基础数据1表基本操作类
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
using System.Transactions;


namespace GK.GKICMP.DAL
{
    public partial class SysData1DAL : DataEntity<SysData1Entity>
    {
        #region 获取数据源
        /// <summary>
        /// 获取数据源
        ///</summary>
        public DataTable GetTable(int isdel, int datatype, int pid)
        {
            string sql = "SELECT * FROM [Tb_SysData1] WHERE Isdel=" + isdel + " and DataType=" + datatype + " and PID=" + pid + " order by SDID";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData1_DelBat";
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
        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public DataTable GetList(int isdel, int datatype)
        {
            string sql = "SELECT * FROM [Tb_SysData1] WHERE DataType = " + datatype + " and Isdel=" + isdel + " order by SDID ASC";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        public int UpdateType(SysData1Entity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData1_AddProType";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DataName", model.DataName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public int UpdateProType(List<SysData1Entity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (SysData1Entity emodel in list)
                    {
                        int result = 0;
                        SysData1Entity model = emodel;
                        if (model != null)
                        {
                            result = UpdateType(model);
                            if (result == -1)
                            {
                                resultvalue = -1;
                                return resultvalue;
                            }
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
                    }
                    else
                    {
                        resultvalue = -99;
                    }
                }
                catch (Exception)
                {
                    resultvalue = -99;
                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }
        #endregion
    }

}

