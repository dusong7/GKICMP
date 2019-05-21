/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月12日 09时34分28秒
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
    public partial class ComputerRegDAL : DataEntity<ComputerRegEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ComputerRegEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Guid", model.Guid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ChapterName", model.ChapterName, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("ComputerName", model.ComputerName, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("IP", model.IP, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("RegDate", model.RegDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("UploadMD5", model.UploadMD5, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Xyear", model.Xyear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("XTerm", model.XTerm, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RegType", model.RegType, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

        public int Add(ComputerRegEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_AddBate";
            DataAccessChannelProtection = true;
            //string sql = "insert into Tb_ComputerReg(CRID,Guid,SysID,CID,ChapterName,Xyear,XTerm,RegDate,RegType) select "++",{1},{2},{3},{4},{5},{6},{7},{8},{9}  from Tb_SysSetConfig";
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Guid", model.Guid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ChapterName", model.ChapterName, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("ComputerName", model.ComputerName, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("IP", model.IP, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("RegDate", model.RegDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("UploadMD5", model.UploadMD5, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("Xyear", model.Xyear, DatabaseType.SQL_NVarChar, 50));
            //DbParameters.Add(new DatabaseParameter("XTerm", model.XTerm, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RegType", model.RegType, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        #endregion

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public ComputerRegEntity GetObjByID(string id)
        {
            //string sql = "SELECT *,dbo.getCourseName(cid)CIDName from tb_computerreg where crid='" + id + "'";
            string sql = "SELECT *,dbo.getCourseName(cid)CIDName,dbo.getUserName(SysID)UserName from tb_computerreg where crid='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 添加一条记录(补录)
        /// <summary>
        /// 添加一条记录(补录)
        ///</summary>
        public int RecEdit(ComputerRegEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_RecAdd";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ChapterName", model.ChapterName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("RegDate", model.RegDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Xyear", model.Xyear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("XTerm", model.XTerm, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RegType", model.RegType, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value.ToString());
            return result;
        }
        #endregion


        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int AddPIC(string mac, string images, string crid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScreenImages_AddPIC";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Image", images, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("CRID", crid, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("MAC", mac, DatabaseType.SQL_NVarChar, 40));
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
            ProcedureName = "up_Tb_ComputerReg_DelBat";
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
        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteReg(string crid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_DeleteReg";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("CRID", crid, DatabaseType.SQL_NVarChar, 40));
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


        public DataTable GetResult(DateTime start, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_GetResult";
            DbParameters.Add(new DatabaseParameter("Start", start, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 20));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;

        }

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ComputerRegEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据月份查询报修次数
        /// <summary>
        /// 根据月份查询报修次数
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>

        public DataTable GetListCounts(DateTime begin, DateTime end)
        {
            string sql = "select datename(year,RegDate)+'年'+datename(month,RegDate)+'月' as ym ,count(DATEPART(month,RegDate)) as counts " +
                         "from [dbo].[Tb_ComputerReg] where RegDate between '" + begin + "' and  '" + end + "'" +
                         "group by datename(year,RegDate)+'年'+datename(month,RegDate)+'月' order by datename(year,RegDate)+'年'+datename(month,RegDate)+'月' desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据教师统计
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetList(DateTime begin, DateTime end)
        {
            string sql = "select SysID,(case when dbo.getUserName(SysID)='' then '暂无' else dbo.getUserName(SysID) end)CreaterUserName, sum(z)zg from( select " +
                         "SysID,1 z " +
                         "from Tb_ComputerReg where RegDate between '" + begin + "' and  '" + end + "' )a group by SysID  order by zg desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetListSum(DateTime begin, DateTime end)
        {
            string sql = "select sum(z)zg from( select " +
                         "SysID,1 z  " +
                         "from Tb_ComputerReg where RegDate between '" + begin + "' and  '" + end + "' )a ";

            //string sql = "select sum(z)zg from( select " +
            //            "SysID,1 z " +
            //            "from Tb_ComputerReg where RegDate between '" + begin + "' and  '" + end + "' )a ";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }


        #endregion

        #region 按班级统计
        /// <summary>
        /// 按班级统计
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable Counts(DateTime begin, DateTime end)
        {
            string sql = "select ComputerName,(case when ComputerName='' then '暂无' else ComputerName end)CreaterUserName, sum(z)zg from( select " +
                         "ComputerName,1 z " +
                         "from Tb_ComputerReg where RegDate between '" + begin + "' and  '" + end + "' )a group by ComputerName order by zg desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 按学科统计
        /// <summary>
        /// 按学科统计
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable CountsCID(DateTime begin, DateTime end)
        {
            string sql = "select CID,(case when dbo.getCourseName(cid)='' then '暂无' else dbo.getCourseName(cid) end)CName, sum(z)zg from( select " +
                         "CID,1 z " +
                         "from Tb_ComputerReg where RegDate between '" + begin + "' and  '" + end + "' )a group by CID order by zg desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 按部门统计
        /// <summary>
        /// 按部门统计
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetListDep(DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComputerReg_GetListDep";
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


    }

}

