/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月01日 09时18分45秒
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
    public partial class EduResourceDAL : DataEntity<EduResourceEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(EduResourceEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Erid", model.Erid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ResourseName", model.ResourseName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ResourseUrl", model.ResourseUrl, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("RSize", model.RSize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RFormat", model.RFormat, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("DownLoadNum", model.DownLoadNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsExcellent", model.IsExcellent, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsOpen", model.IsOpen, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("AuditDate", model.AuditDate, DatabaseType.SQL_DateTime, 8));

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
        public DataTable GetTable(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_GetTable";
            DbParameters.Add(new DatabaseParameter("Erid", id, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
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
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
        public EduResourceEntity GetObjByID(int id)
        {
            string sql = "SELECT *,dbo.getCourseName(CID) SubtypeName,dbo.[getUserName](CreateUser) CreateUser FROM [Tb_EduResource] WHERE Erid =" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 根据主键编号集合更新状态
        /// <summary>
        /// 根据主键编号集合更新状态
        ///</summary>
        public int Update(string ids, int nstate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("nstate", nstate, DatabaseType.SQL_Int, 4));
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

        #region 更新下载次数
        /// <summary>
        /// 更新下载次数
        ///</summary>
        public int DownLoad(string erid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_DownLoad";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Erid", erid, DatabaseType.SQL_NVarChar, 40));
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


        #region 更新一条记录
        /// <summary>
        /// 更新一条记录
        ///</summary>
        public void UpdateNum(int RID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_UpdateNum";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Erid", RID, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;


        }
        #endregion
        #region 根据主键编号集合更新状态
        /// <summary>
        /// 根据主键编号集合更新状态
        ///</summary>
        public int Audit(EduResourceEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_Audit";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Erid", model.Erid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsExcellent", model.IsExcellent, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditState", model.AuditState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AuditUser", model.AuditUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AuditDate", model.AuditDate, DatabaseType.SQL_DateTime, 20));
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


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, EduResourceEntity model, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("ResourseName", model.ResourseName, DatabaseType.SQL_NVarChar, 100));
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
        public DataTable GetPagedZyptByFlag(int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_PagedByflag";
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
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
        public DataTable GetPagedZypt(int pagesize, int pageindex, ref int recordCount, EduResourceEntity model, string txtall, int RType)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_PagedZypt";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("txtall", txtall, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("EType", RType, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 资源首页数据top
        /// <summary>
        /// 资源首页数据top
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_GetData";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 教师排行榜数据
        /// <summary>
        /// 教师排行榜数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTop(DateTime date)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_GetTop";

            DbParameters.Add(new DatabaseParameter("FirstDate", date, DatabaseType.SQL_DateTime, 8));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取资源总量
        /// <summary>
        /// 获取资源总量
        /// </summary>
        /// <param name="flag">区分类型与学科 1：类型 2：学科</param>
        /// <returns></returns>
        public DataTable GetResourceData( int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_GetResourceData";

            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        } 
        #endregion

        public int AddEncrypt(int erid,string psw)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_EduResource_AddEncrypt";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Erid", erid , DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ERPwd", psw, DatabaseType.SQL_NVarChar, 200));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;

        }
    }
}