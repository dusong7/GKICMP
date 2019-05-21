/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       基础数据页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;
using gk.rjb_Y.Libraries;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;


namespace GK.GKICMP.DAL
{
    public partial class SysDataDAL : DataEntity<SysDataEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SysDataEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DataName", model.DataName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("IsSysSet", model.IsSysSet, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            //DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

            resultvalue = Convert.ToInt32(DbParameters[5].Value);
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
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, SysDataEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData_PagedList";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("DataName", model.DataName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }


        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SysDataEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("DataType", Flag, DatabaseType.SQL_Int, 4));

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
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysDate_DelBat";
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

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public SysDataEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_SysData where SDID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public DataTable GetList(int isdel, int datatype)
        {
            string sql = "select * from Tb_SysData where DataType=" + datatype + " and Isdel=" + isdel + " order by SDID ASC";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public DataTable GetProList(int isdel, int datatype, int pid)
        {
            string sql = "select * from Tb_SysData1 where pid=" + pid + " and DataType=" + datatype + " and Isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        public DataTable GetAssetType(int isdel, int datatype, int pid)
        {
            string sql = "select * from Tb_SysData where pid=" + pid + " and DataType=" + datatype + " and Isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 根据数据名称获取ID
        /// <summary>
        /// 根据数据名称获取ID
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public int GetSDID(string dataname, int datatype)
        {
            int id = -1;

            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData_GetSDID";
            DbParameters.Add(new DatabaseParameter("DataName", dataname, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataType", datatype, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = Convert.ToInt32(dv.Table.Rows[0]["SDID"].ToString());
            }
            return id;
        }
        #endregion

        #region 根据数据名称获取ID
        /// <summary>
        /// 根据数据名称获取ID
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public string GetSDIDByName(string dataname, int isdel, int datatype)
        {
            string id = "-1";

            DbParameters.Clear();
            ProcedureName = "up_Tb_SysData_GetSDIDByName";
            DbParameters.Add(new DatabaseParameter("DataName", dataname, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataType", datatype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = dv.Table.Rows[0]["SDID"].ToString();
            }
            return id;
        }
        #endregion
    }
}
