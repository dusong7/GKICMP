/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月15日 10时13分33秒
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
    public partial class Teacher_HolidayDAL : DataEntity<Teacher_HolidayEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Teacher_HolidayEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Holiday_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("THID", model.THID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("HType", model.HType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("HStartDate", model.HStartDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("HEndDate", model.HEndDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("HolidayDesc", model.HolidayDesc, DatabaseType.SQL_NVarChar, 300));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("HFile", model.HFile, DatabaseType.SQL_NVarChar, 300));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("HDays", model.HDays, DatabaseType.SQL_Decimal, 16));
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
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Holiday_DelBat";
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
        public Teacher_HolidayEntity GetObjByID(string id)
        {
            //string sql = "select h.*,dbo.getTeahName(h.tid) as TeacherName,dbo.getDepName(h.depid) as DepName,dbo.getDataName(t.MainCourse) as TCourseName from Tb_Teacher_Holiday h inner join Tb_Teacher t on h.TID=t.TID where h.THID='" + id + "'";
            string sql = "select h.*,dbo.getTeahName(h.tid) as TeacherName,dbo.getDepName(h.depid) as DepName from Tb_Teacher_Holiday h inner join Tb_Teacher t on h.TID=t.TID where h.THID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Teacher_HolidayEntity model, string teacname, int tcourse)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Holiday_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TeacName", teacname, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TCourse", tcourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("HType", model.HType, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Holiday_Update";
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

