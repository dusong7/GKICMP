/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月29日 14时23分12秒
** 描    述:      学生活动管理基本操作类
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
    public partial class StudentActivityDAL : DataEntity<StudentActivityEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(StudentActivityEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ActUsers", model.ActUsers, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("SAID", model.SAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ActName", model.ActName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ActType", model.ActType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ActAddress", model.ActAddress, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Counselor", model.Counselor, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("ActContent", model.ActContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("ActDesc", model.ActDesc, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LogoUrl", model.LogoUrl, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ClosingDate", model.ClosingDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("ActivityTemp", model.ActivityTemp, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("ABegin", model.ABegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AEnd", model.AEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsSign", model.IsSign, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

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


        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int DeleteByID(string id, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_DelBat";
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
        public StudentActivityEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getDataName(ActType) ActTypeName,dbo.getUserNames(Counselor) CounselorName,dbo.getActUsersBySAID(SAID) ActUsers,dbo.getActUsersNameBySAID(SAID) ActUsersName,dbo.getUserName(CreateUser) CreateUserName from Tb_StudentActivity where SAID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, StudentActivityEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ActName", model.ActName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ActType", model.ActType, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 学生活动报名列表页面
        public DataTable GetPersonPaged(int pagesize, int pageindex, ref int recordCount, StudentActivityEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_PersonPaged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ActName", model.ActName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ActType", model.ActType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSign", model.IsSign, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsPublish", model.IsPublish, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 发布活动记录
        public int ActPublish(string ids, int ispublish)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("IDS", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("IsPublish", ispublish, DatabaseType.SQL_Int, 4));

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


        #region 添加报名学生信息
        public int ActUserAdd(string users, string said)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_User_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ActUsers", users, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("SAID", said, DatabaseType.SQL_NVarChar, 40));

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


        #region 获取活动列表数据
        public DataTable GetList(int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_GetList";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端--校内活动
        /// <summary>
        /// 手机端--校内活动
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedAPP(int pagesize, int pageindex, ref int recordCount, StudentActivityEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_StudentActivity_PagedAPP";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ActName", model.ActName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ActType", model.ActType, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

    }
}

