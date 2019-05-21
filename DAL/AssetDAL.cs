/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      俞桂宝
** 创建日期:      2016年11月07日 14时38分19秒
** 描    述:      角色数据的基本操作类
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
using System.Transactions;

namespace GK.GKICMP.DAL
{
    public partial class AssetDAL : DataEntity<AssetEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(AssetEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AID", model.AID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AssetName", model.AssetName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("SpecificationModel", model.SpecificationModel, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Brand", model.Brand, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Suppliers", model.Suppliers, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("APrice", model.APrice, DatabaseType.SQL_Decimal, 10));
            DbParameters.Add(new DatabaseParameter("AUnit", model.AUnit, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("BuyDate", model.BuyDate, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("PlanYear", model.PlanYear, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BuyUser", model.BuyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("AssetMark", model.AssetMark, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AImage", model.AImage, DatabaseType.SQL_NVarChar, 300));
            DbParameters.Add(new DatabaseParameter("AssetNum", model.AssetNum, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Flag", model.Flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsChecked", model.IsChecked, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AssetGroup", model.AssetGroup, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
        }
        #endregion

        #region 资产导入
        public int Import(AssetEntity[] list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    for (int i = 0; i < list.Length; i++)
                    {
                        int result = 0;
                        AssetEntity model = list[i];
                        result = Import(model);
                        if (result == -1)
                        {
                            resultvalue = -1;
                            return resultvalue;
                        }
                        if (result == -2)
                        {
                            resultvalue = -2;
                            break;
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
                    }
                    else if (resultvalue == -2)
                    {
                        resultvalue = -2;
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


        #region 资产导入--插入
        /// <summary>
        /// 资产导入--插入
        ///</summary>
        public int Import(AssetEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Import";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AID", model.AID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AssetName", model.AssetName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("SpecificationModel", model.SpecificationModel, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Brand", model.Brand, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Suppliers", model.Suppliers, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("APrice", model.APrice, DatabaseType.SQL_Decimal, 10));
            DbParameters.Add(new DatabaseParameter("AUnit", model.AUnit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BuyDate", model.BuyDate, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AssetNum", model.AssetNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", model.Flag, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("PlanYear", model.PlanYear, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AssetMark", model.AssetMark, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AssetGroup", model.AssetGroup, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsChecked", model.IsChecked, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
        }
        #endregion


        #endregion

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, AssetEntity model, ref decimal sum)
        {

            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("zh", sum, DatabaseType.SQL_Float, 18, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AssetName", model.AssetName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AssetGroup", model.AssetGroup, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", model.Flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            sum = Convert.ToDecimal(DbParameters[3].Value); ;
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
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, string PID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_PagedList";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PID", PID, DatabaseType.SQL_NVarChar, 100));

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
            ProcedureName = "up_Tb_Asset_DelBat";
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
        public AssetEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getSupplierName(Suppliers)SuppliersName,dbo.getUserName(CreateUser)CreateUserName,dbo.getUserName(BuyUser)BuyUserName,dbo.getAssetTypeName(DataType)DataTypeName,dbo.getDataName(DataType) OfficeTypeName,dbo.getDataName(AUnit)as AUnitName,dbo.getProNameByJZ(PID) as ProName,dbo.getCampusName(CID) CName,dbo.getDataName(AssetGroup)AssetGroupName FROM [Tb_Asset] WHERE	[AID] ='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 更新 资产管理 字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_UpdateByIds";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 9999));
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

        #region 更新 供货清单里的资产 字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int UpdateByPIDs(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_UpdateByPIDs";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 1000));
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

        #region 验收成功后 更新 供货清单里的资产的验收状态
        /// <summary>
        /// 验收成功后 更新 供货清单里的资产的验收状态
        ///</summary>
        public int UpdateIsChecked(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_UpdateIsChecked";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 1000));
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


        #region 验收管理 根据PCID来查询已经上报的资产
        /// <summary>
        /// 验收管理 根据PCID来查询已经上报的资产
        /// </summary>
        /// <returns></returns>
        //public DataTable GetListByPID(string pid,int isdel)
        public DataTable GetListByPID(string pcid, int isdel)
        {
            string sql = "SELECT * FROM [Tb_Asset] WHERE Isdel=" + isdel + " and IsReport =1 and PID in (select PID from Tb_Project_Check where PCID in (select * from f_split('" + pcid + "',',')))";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 验收管理 根据PCID来查询资产
        /// <summary>
        /// 根据PID来查询资产
        /// </summary>
        /// <returns></returns>
        public DataTable GetListByPCID(string pcid, int isdel)
        {
            string sql = "SELECT * FROM [Tb_Asset] WHERE Isdel=" + isdel + " and IsReport=0 and PID =(select PID from Tb_Project_Check where PCID in (select * from f_split('" + pcid + "',',')))";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 供货清单 根据PID来查询未上报资产
        /// <summary>
        /// 供货清单 根据PID来查询未上报资产
        /// </summary>
        /// <returns></returns>
        //public DataTable GetListByPID(string pid,int isdel)
        public DataTable GetPID(string pid, int isdel)
        {
            string sql = "SELECT *,dbo.getDataName(AUnit) as AUnitName FROM	[Tb_Asset] WHERE  PID = '" + pid + "' and Isdel=" + isdel + " and IsReport = 0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 资产折旧列表页面数据
        public DataTable GetPagedDepre(int pagesize, int pageindex, ref int recordCount, AssetEntity model, DateTime begindate, DateTime enddate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_PagedDepre";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AssetName", model.AssetName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", model.Flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 更新资产折旧率
        public int UpdateRate(string aid, decimal assrate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_UpdateRate";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("AID", aid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AssRate", assrate, DatabaseType.SQL_Decimal, 10));

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


        #region 停止折旧
        public int StopRate(string aid, int stoprate)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_StopRate";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AID", aid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsStopRate", stoprate, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value);
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
        public DataTable GetPagedS(int pagesize, int pageindex, ref int recordCount, AssetEntity model, ref decimal sum, int deep, string parmid)
        {

            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_PagedS";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("zh", sum, DatabaseType.SQL_Float, 18, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AssetName", model.AssetName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DataDesc", model.DataDesc, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DataType", model.DataType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ParmID", parmid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("deep", deep, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            sum = Convert.ToDecimal(DbParameters[3].Value); ;
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion
    }
}
