/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年08月17日 16时27分43秒
** 描    述:      缴费项基本操作类
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
    public partial class PayProjectDAL : DataEntity<PayProjectEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        //public int Edit(PayProjectEntity model, string ids)
        public int Edit(PayProjectEntity model, int issad)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PPID", model.PPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ProjectName", model.ProjectName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("PayCount", model.PayCount, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("IsDisable", model.IsDisable, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isaad", issad, DatabaseType.SQL_Int, 4));

            // DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));

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

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(PayProjectEntity model, string ids)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PPID", model.PPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ProjectName", model.ProjectName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("PayCount", model.PayCount, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("IsDisable", model.IsDisable, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            // DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));

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

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_DelBat";
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
        public PayProjectEntity GetObjByID(string id)
        {
            string sql = "SELECT * FROM [Tb_PayProject] WHERE [PPID] = '" + id + "'";

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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, PayProjectEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("ProjectName", model.ProjectName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsDisable", model.IsDisable, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 停用
        /// <summary>
        /// 停用
        ///</summary>
        public int UpdateByID(string ppid, int isdisable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("PPID", ppid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("isdisable", isdisable, DatabaseType.SQL_Int, 4));

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

        #region 获取已启用的缴费项目
        /// <summary>
        /// 获取已启用的缴费项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int isdel, int isdisable)
        {
            string sql = "SELECT * FROM [Tb_PayProject] WHERE Isdel = " + isdel + " and IsDisable =" + isdisable;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据缴费项目获取金额
        /// <summary>
        /// 根据缴费项目获取金额
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string ppid, int isdel, int isdisable)
        {
            string sql = "SELECT * FROM [Tb_PayProject] WHERE Isdel = " + isdel + " and IsDisable =" + isdisable + " and PPID = '" + ppid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

    }

}

