using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;
using System.Data;
using System.Transactions;

namespace GK.GKICMP.DAL
{
    public partial class AssetTypeDAL : DataEntity<AssetTypeEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(AssetTypeEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Type_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DataName", model.DataName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MaxID", model.MaxID, DatabaseType.SQL_Int, 4));
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Type_DelBat";
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
            string sql = "SELECT * FROM Tb_Asset_Type WHERE DataType = " + datatype + " and Isdel=" + isdel + " order by SDID ASC";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public AssetTypeEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_Asset_Type where SDID=" + id;
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
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, AssetTypeEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Type_PagedList";
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
        #endregion

        public int Update(AssetTypeEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Type_AddAssetType";
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
        public int UpdateAssetType(List<AssetTypeEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (AssetTypeEntity emodel in list)
                    {
                        int result = 0;
                        AssetTypeEntity model = emodel;
                        if (model != null)
                        {
                            result = Update(model);
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

        #region 根据数据名称获取ID
        /// <summary>
        /// 根据资产数据名称获取资产ID
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public string GetSDIDByName(string dataname, int isdel, int datatype)
        {
            string id = "-1";

            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Type_GetSDIDByName";
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


        #region 查询资产类型数据
        /// <summary>
        /// 查询资产类型数据
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="pid"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetAssetType(string dataname, int pid, int isdel)
        {
            string sql = "select * from Tb_Asset_Type where DataName='" + dataname + "' and PID=" + pid + " and Isdel=" + isdel + " and DataType=1";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        public DataTable GetAssetType(string dataname,  int isdel)
        {
            string sql = "select * from Tb_Asset_Type where DataName='" + dataname + "'  and Isdel=" + isdel + " and DataType=1 order by SDID desc ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 查询资产类型数据
        /// <summary>
        /// 查询资产类型数据
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="pid"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetType(int pid, int isdel, int datatype)
        {
            string sql = "select * from Tb_Asset_Type where DataType=" + datatype + " and  PID=" + pid + " and Isdel=" + isdel + " order by DataDesc ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}
