/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年11月15日 09时19分47秒
** 描    述:      数据的基本操作类
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


namespace GK.GKICMP.DAL
{
    public partial class NetworkTeachDAL : DataEntity<NetworkTeachEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(NetworkTeachEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("NTID", model.NTID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("NTTName", model.NTTName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("EPID", model.EPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TeaBegin", model.TeaBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TeaEnd", model.TeaEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("NTTUrl", model.NTTUrl, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("IsCommunication", model.IsCommunication, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Cla", model.Cla, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("ImgUrl", model.ImgUrl, DatabaseType.SQL_NVarChar, 2000));
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_DelBat";
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
        public NetworkTeachEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_Get";
            DbParameters.Add(new DatabaseParameter("NTID", id, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, NetworkTeachEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("NTTName", model.NTTName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("EPID", model.EPID, DatabaseType.SQL_NVarChar, 10));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region (学生页面)根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// (学生页面)根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedByStu(int pagesize, int pageindex, ref int recordCount, NetworkTeachEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_PagedByStu";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("NTTName", model.NTTName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }

        #endregion

        #region (教师页面)根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// (教师页面)根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedByTea(int pagesize, int pageindex, ref int recordCount, NetworkTeachEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_PagedByTea";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("NTTName", model.NTTName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EPID", model.EPID, DatabaseType.SQL_NVarChar, 100));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }

        #endregion

        #region 根据id获取课程所对应所有班级
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetClass(string ntid)
        {
            string sql = "select *,dbo.getDepOtherName(ClaID)ClaName from Tb_NetworkTeach_Class where ntid='" + ntid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 获取网络课程科目分析数据
        public DataTable GetData(DateTime begindate,DateTime enddate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_GetNetworkTeachData";

            DbParameters.Add(new DatabaseParameter("BeginDate",begindate,DatabaseType.SQL_DateTime,8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取教师排行榜信息
        public DataTable GetTeachTop(DateTime begindate,DateTime enddate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_GetTeachTop";

            DbParameters.Add(new DatabaseParameter("BeginDate",begindate,DatabaseType.SQL_DateTime,8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取课程信息
        public DataTable GetCourseData(string createuser, int cid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_NetworkTeach_GetCourseData";

            DbParameters.Add(new DatabaseParameter("CreateUser", createuser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}

