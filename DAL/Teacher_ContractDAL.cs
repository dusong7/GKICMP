/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月15日 10时09分45秒
** 描    述:      数据的基本操作类
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
    public partial class Teacher_ContractDAL : DataEntity<Teacher_ContractEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Teacher_ContractEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Contract_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TCID", model.TCID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CType", model.CType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TCycle", model.TCycle, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("TStartDate", model.TStartDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TEndDate", model.TEndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TCFile", model.TCFile, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("TState", model.TState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));

            //DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));

            // DbParameters.Add(new DatabaseParameter("result", DatabaseType.SQL_Int, 4));
            //STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            //if (stmessage.SqlCode != 0)
            //{
            //    throw new Exception(DataReturn.SqlMessage);
            //}
            //DataAccessChannel.CommitRelease();
            //DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Contract_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
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
        public Teacher_ContractEntity GetObjByID(string id)
        {
            string sql = "SELECT a.*,b.RealName,dbo.getDataName(CType) CTypeName FROM [Tb_Teacher_Contract] a inner join Tb_Teacher b on a.TID=b.TID WHERE [TCID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Teacher_ContractEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Contract_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", model.EndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CType", model.CType, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据编号（主键）获取项
        /// <summary>
        /// 根据编号（主键）获取项
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(string Id)
        {
            //DataTable dt = null;
            //string sql = "select * from Tb_Teacher_Contract where TCID='" + Id + "'";
            //DataSet ds = DbHelper.ExecuteDataSet(sql);
            //if (ds != null && ds.Tables[0] != null)
            //{
            //    dt = ds.Tables[0];
            //}
            //return dt;

            string sql = "select * from Tb_Teacher_Contract  where  TCID='" + Id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 返回DataSet
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedHistory(string tcid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Contract_PagedHistory";
            DbParameters.Add(new DatabaseParameter("TCID", tcid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;

        }
        #endregion


        #region 根据TCID获取TID合同信息
        /// <summary>
        /// 根据TCID获取TID合同信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetObjByTCID(string tcid)
        {
            string sql = "SELECT a.*,b.RealName,dbo.getDataName(CType) CTypeName FROM Tb_Teacher_Contract a inner join Tb_Teacher b on a.TID=b.TID WHERE a.TID in (select TID from Tb_Teacher_Contract where TCID = '" + tcid + "') and a.IsReport=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据主键修改合同解除日期
        /// <summary>
        /// 根据主键修改合同解除日期
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int RemoveDate(string ids, int state, DateTime overdate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Contract_Remove";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("OverDate", overdate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TState", state, DatabaseType.SQL_NVarChar, 4));
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

        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Contract_Update";
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

    }

}

