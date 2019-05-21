/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年01月05日 09时04分57秒
** 描    述:      晨检申报基本操作类
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
    public partial class StuAttendDAL : DataEntity<StuAttendEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(StuAttendEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuAttend_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("STID", model.STID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LeaveUserName", model.LeaveUserName, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("InfectiousName", model.InfectiousName, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("DID", model.DID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CompassionateName", model.CompassionateName, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("SickName", model.SickName, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("RealCOunt", model.RealCOunt, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AllIns", model.AllIns, DatabaseType.SQL_Int, 4));

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
        public StuAttendEntity GetObjByID(int DID, DateTime CreateDate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuAttend_Get";
            DbParameters.Add(new DatabaseParameter("CreateDate", CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("DID", DID, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, string DIDName, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuAttend_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("DIDName", DIDName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
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
        public DataTable GetPageds(int pagesize, int pageindex, ref int recordCount, string DIDName, int month)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuAttend_Pageds";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("DIDName", DIDName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("month", month, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
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
        public DataTable GetPagedByDID(int pagesize, int pageindex, ref int recordCount, int month, int did, int attendtype, string LeaveUserName, string DIDName, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuLeave_GetPaged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("month", month, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("did", did, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("attendtype", attendtype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LeaveUserName", LeaveUserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DIDName", DIDName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public StuAttendEntity GetByDIDanddate(int DID, DateTime CreateDate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuAttend_GetByDIDanddate";
            DbParameters.Add(new DatabaseParameter("CreateDate", CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("DID", DID, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion



    }

}

