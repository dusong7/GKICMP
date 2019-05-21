/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2016年12月24日 10时39分25秒
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
    public partial class Asset_RepairDAL : DataEntity<Asset_RepairEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Asset_RepairEntity model)
        {
            int result = 0;
            DbParameters.Clear();

            ProcedureName = "up_Tb_Asset_Repair_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ARID", model.ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("RepairObj", model.RepairObj, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("RepairContent", model.RepairContent, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DutyDep", model.DutyDep, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", model.ARState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARFile", model.ARFile, DatabaseType.SQL_NVarChar, 2000));
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


        #region 添加一条记录APP
        /// <summary>
        /// 添加一条记录APP
        ///</summary>
        public int EditAPP(Asset_RepairEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_AddAPP";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARID", model.ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("RepairObj", model.RepairObj, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("RepairContent", model.RepairContent, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DutyDep", model.DutyDep, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", model.ARState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SDID", model.SDID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ARFile", model.ARFile, DatabaseType.SQL_NVarChar, 500));
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
            ProcedureName = "up_Tb_Asset_Repair_DelBat";
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
        public Asset_RepairEntity GetObjByID(string id)
        {
            string sql = "SELECT a.*,dbo.getDepName(DutyDep) DutyDepName,dbo.getDepName(b.UserType) UserTypeName,dbo.getUserName(DutyUser) DutyUserName,dbo.getUserName(CreaterUser) CreaterUserName,dbo.getUserName(TransferUser) TransferName FROM [Tb_Asset_Repair] a left join Tb_SysUser b on a.CreaterUser =b.UID WHERE [ARID] = '" + id + "' and b.Isdel =0";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Asset_RepairEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RepairObj", model.RepairObj, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", model.ARState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
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
        public DataTable GetPagedBywsld(int pagesize, int pageindex, ref int recordCount, Asset_RepairEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_Pagedwsld";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
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
        public DataTable GetPagedByYJ(int pagesize, int pageindex, ref int recordCount, Asset_RepairEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_PagedYJ";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 获取维修人员信息
        /// <summary>
        ///    获取维修人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSysUserType(int SType)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetbySTYpe";
            DbParameters.Add(new DatabaseParameter("SType", SType, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据主键编号更新数据
        /// <summary>
        /// 根据主键编号更新数据
        ///</summary>
        public int Update(string ARID, string CompDesc, int ARState)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ARID", ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CompDesc", CompDesc, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("ARState", ARState, DatabaseType.SQL_Int, 4));

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

        #region 根据主键编号更新数据
        /// <summary>
        /// 根据主键编号更新数据
        ///</summary>
        public int UpdateApp(string ARID, int ARState)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_UpdateApp";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ARID", ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", ARState, DatabaseType.SQL_Int, 4));

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

        #region 根据主键编号更新数据
        /// <summary>
        /// 根据主键编号更新数据
        ///</summary>
        public int UpdateYJ(Asset_RepairEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_UpdateYJ";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ARID", model.ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", model.ARState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TransferUser", model.TransferUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TransferDesc", model.TransferDesc, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("TransferDate", model.TransferDate, DatabaseType.SQL_DateTime, 20));

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
            //string sql = "select datename(year,ARDate)+'年'+datename(month,ARDate)+'月' as ym ,count(DATEPART(month,ARDate)) as counts " +
            //             "from [dbo].[Tb_Asset_Repair] where Isdel =0 and ARDate between '" + begin + "' and  '" + end + "'" +
            //             "group by datename(year,ARDate)+'年'+datename(month,ARDate)+'月'";

            string sql = "select datename(year,ARDate)+'年'+datename(month,ARDate)+'月' as ym ,count(DATEPART(month,ARDate)) as counts " +
                        "from [dbo].[Tb_Asset_Repair] where Isdel =0 and ARDate between '" + begin + "' and  '" + end + "'" +
                        "group by datename(year,ARDate)+'年'+datename(month,ARDate)+'月'" +
                        "order by datename(year,ARDate)+'年'+datename(month,ARDate)+'月' desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
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
        public DataTable GetPagedByfalg(int pagesize, int pageindex, ref int recordCount, Asset_RepairEntity model, DateTime begin, DateTime end, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_PagedByflag";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RepairObj", model.RepairObj, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", model.ARState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreaterUser", model.CreaterUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

       


        public int IsConfirm(string arid, int IsConfirm, int state)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_IsConfirm";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ARID", arid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsConfirm", IsConfirm, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ARState", state, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

        public int SL(string arid, int state)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_SL";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ARID", arid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", state, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

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
            //DbParameters.Clear();

            //ProcedureName = "up_Tb_Asset_Repair_GetList";
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));

            string sql = "select CreaterUser,(case when dbo.getUserName(CreaterUser)='' then '暂无' else dbo.getUserName(CreaterUser) end)CreaterUserName, sum(z)zg,sum(wcl)wcl,SUM(qr)sl,SUM(wc)wc,SUM(qrwc)qrwc from( select " +
                         "CreaterUser,1 z, (case when ARState=0 then 1 else 0 end)wcl,(case when ARState=1 then 1 else 0 end)qr,(case when ARState=2 then 1 else 0 end)wc,(case when ARState=3 then 1 else 0 end)qrwc " +
                         "from Tb_Asset_Repair where ARDate between '" + begin + "' and  '" + end + "' )a group by CreaterUser order by zg desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetListSum(DateTime begin, DateTime end)
        {
            //DbParameters.Clear();

            //ProcedureName = "up_Tb_Asset_Repair_GetList";
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));

            string sql = "select sum(z)zg,sum(wcl)wcl,SUM(qr)sl,SUM(wc)wc,SUM(qrwc)qrwc,SUM(yj)yj from( select " +
                         "CreaterUser,1 z, (case when ARState=0 then 1 else 0 end)wcl,(case when ARState=1 then 1 else 0 end)qr,(case when ARState=2 then 1 else 0 end)wc,(case when ARState=3 then 1 else 0 end)qrwc,(case when ARState=-3 then 1 else 0 end)yj " +
                         "from Tb_Asset_Repair where ARDate between '" + begin + "' and  '" + end + "' )a ";

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
            ProcedureName = "up_Tb_Asset_Repair_GetListDep";
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            //DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            //recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据维修员统计
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetMaintenanceList(DateTime begin, DateTime end)
        {
            string sql = "select TransferUser,(case when dbo.getUserName(TransferUser)='' then '学校自主维修' else dbo.getUserName(TransferUser) end)CreaterUserName, sum(z)zg,sum(wcl)wcl,SUM(qr)sl,SUM(wc)wc,SUM(qrwc)qrwc,SUM(yj)yj from( select " +
                         "TransferUser,1 z, (case when ARState=0 then 1 else 0 end)wcl,(case when ARState=1 then 1 else 0 end)qr,(case when ARState=2 then 1 else 0 end)wc,(case when ARState=3 then 1 else 0 end)qrwc,(case when ARState=-3 then 1 else 0 end)yj " +
                         "from Tb_Asset_Repair where ARDate between '" + begin + "' and  '" + end + "' )a group by TransferUser";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
      
        #endregion


        public DataTable GetView(string createuser, int arstate, DateTime begin, DateTime end)
        {
            //DbParameters.Clear();

            //ProcedureName = "up_Tb_Asset_Repair_GetList";
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));

            string sql = "select (case when dbo.getUserName(CreaterUser)='' then '暂无' else dbo.getUserName(CreaterUser) end)CreaterUserName,* from Tb_Asset_Repair where ARDate between '" + begin + "' and  '" + end + "'  and createuser='" + createuser + "' and arstate=" + arstate;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }


        public int Reject(string arid, string opinion, int state) 
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Repair_Reject";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ARID", arid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ARState", state, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitDesc", opinion, DatabaseType.SQL_NVarChar, 100));
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

