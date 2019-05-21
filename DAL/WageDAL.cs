/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月26日 10时40分29秒
** 描    述:      工资管理基本操作类
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
    public partial class WageDAL : DataEntity<WageEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(WageEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Wage_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("WYear", model.WYear, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WMonth", model.WMonth, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PostWage", model.PostWage, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("SalaryScale", model.SalaryScale, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Allowance", model.Allowance, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("TeachNursing", model.TeachNursing, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("BasicPay", model.BasicPay, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Rewarding", model.Rewarding, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("ShouldWage", model.ShouldWage, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Accumulation", model.Accumulation, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Unemployment", model.Unemployment, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("MedicalFee", model.MedicalFee, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Insurance", model.Insurance, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Union", model.Union, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("AssessWage", model.AssessWage, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Income", model.Income, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Serious", model.Serious, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Withhold", model.Withhold, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("ActualWages", model.ActualWages, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("RentalFee", model.RentalFee, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("WDesc", model.WDesc, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("WFlag", model.WFlag, DatabaseType.SQL_Int, 4));
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



        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int DeleteByID(string id, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Wage_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", id, DatabaseType.SQL_NVarChar, 2000));
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
        public WageEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getUserName(TID) TIDName from Tb_Wage where SID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, WageEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Wage_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WFlag", model.WFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TIDName", model.TIDName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("WYear", model.WYear, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("WMonth", model.WMonth, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 导入
        public string Import(WageEntity[] list)
        {
            string resultvalue = "";
            using (TransactionScope ts = new TransactionScope())
            {
                int result = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    WageEntity model = list[i];
                    if (model != null)
                    {
                        result = Edit(model);
                        if (result == 0)
                        {
                            resultvalue = "";
                        }
                        else if (result == -1)
                        {
                            resultvalue = "第" + (i + 1) + "条数据添加失败";
                        }
                        else
                        {
                            resultvalue = "第" + (i + 1) + "条数据已存在";
                        }
                    }
                }
                if (resultvalue == "")
                {
                    ts.Complete();
                }
                else
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public WageEntity GetByTID(string id)
        {
            string sql = "select top 1 *,dbo.getUserName(TID) TIDName FROM [Tb_Wage] WHERE TID = '" + id + "' and Isdel=0 order by WYear ,WMonth desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
    }
}

