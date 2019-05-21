/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2016年11月09日 16时08分56秒
** 描    述:      供应商数据的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;
namespace GK.GKICMP.DAL
{
    public partial class SupplierDAL : DataEntity<SupplierEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SupplierEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Supplier_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SupplierName", model.SupplierName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Enterprise", model.Enterprise, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("LinkUser", model.LinkUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("LinkPost", model.LinkPost, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("LinkPhone", model.LinkPhone, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("MainAssest", model.MainAssest, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("BankName", model.BankName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BankNum", model.BankNum, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Qualifications", model.Qualifications, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Legal", model.Legal, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
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

        #region 根据数据名称获取ID
        /// <summary>
        /// 根据数据名称获取ID
        /// </summary>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public string TableByName(string SupplierName, int isdel)
        {
            string a = "";
            DbParameters.Clear();
            ProcedureName = "up_Tb_Supplier_GetList";
            DbParameters.Add(new DatabaseParameter("SupplierName", SupplierName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            if (DataReflectionContainer != null && DataReflectionContainer.Rows.Count > 0)
                a = DataReflectionContainer.Rows[0]["SDID"].ToString();
            return a;

        }
        #endregion
        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Supplier_DelBat";
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
        public SupplierEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_Supplier where SDID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SupplierEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Supplier_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SupplierName", model.SupplierName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("LinkUser", model.LinkUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("LinkPhone", model.LinkPhone, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 资产管理获取供应商
        /// <summary>
        /// 资产管理获取供应商
        ///</summary>
        public DataTable GetList(int isdel, string SupplierName)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Supplier_GetList";
            DbParameters.Add(new DatabaseParameter("SupplierName", SupplierName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 通过ID来获取供应商名称
        /// <summary>
        /// 通过ID来获取供应商名称
        ///</summary>
        public SupplierEntity GetList(string sdid)
        {
            string sql = "SELECT [SDID],[SupplierName] FROM [Tb_Supplier] WHERE [SDID] = '" + sdid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
    }
}