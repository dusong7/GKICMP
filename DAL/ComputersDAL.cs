/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月06日 16时51分30秒
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
    public partial class ComputersDAL : DataEntity<ComputersEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ComputersEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_Add";
            DataAccessChannelProtection = true;
            int result = 0;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4,ParameterDirection.InputOutput));
            DbParameters.Add(new DatabaseParameter("Guid", model.Guid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ComputerName", model.ComputerName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LanIP", model.LanIP, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Mac", model.Mac, DatabaseType.SQL_NVarChar, 40));
            // DbParameters.Add(new DatabaseParameter("LastActiveTime", model.LastActiveTime, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("OnlineMinutes", model.OnlineMinutes, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_NVarChar, 40));
            //   DbParameters.Add(new DatabaseParameter("SoftVersion", model.SoftVersion, DatabaseType.SQL_Char, 10));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("CFlag", model.CFlag, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return int.Parse( DbParameters[0].Value.ToString());
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_DelBat";
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
        public ComputersEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_Computers where [Guid]='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        public ComputersEntity GetObjByMac(string id)
        {
            string sql = "select * from Tb_Computers where [MAC]='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion



        public DataTable CourseList(string mac) 
        {
            //string sql = "select ClaID,dbo.getGIDByDepID(ClaID)GID,CourseID,dbo.getCourseName(CourseID)CourseName,TeacherID,"
            //    + "dbo.getUserName(TeacherID)UserName from Tb_TeacherPlane "
            //    + "where (ClaID=(select did from Tb_ClassRoom where "
            //    + "CRID=(select CRID from Tb_Computers where Mac='" + mac + "')) or (select CRID from Tb_Computers where Mac='" + mac + "') is null)";
            //if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            //{
            //    throw new Exception(DataReturn.SqlMessage);
            //}
            //return DataReflectionContainer;


            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_CourseList";
            DbParameters.Add(new DatabaseParameter("Mac", mac, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public DataTable Search(string mac, ref int num)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_Search";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("MAC", mac, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("num", num, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            num = Convert.ToInt32(DbParameters[1].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 获取所有的班班通电脑
        /// <summary>
        /// 获取所有的班班通电脑
        ///</summary>
        public DataTable GetList(int cflag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_GetList";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("CFlag", cflag, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ComputersEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ComputerName", model.ComputerName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Mac", model.Mac, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CFlag", model.CFlag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion



        #region 获取所有的班班通电脑
        /// <summary>
        /// 获取所有的班班通电脑
        ///</summary>
        public DataTable GetCRoomList(int cflag,string CCID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Computers_GetCRoomList";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("CFlag", cflag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CCID", CCID, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }

}

