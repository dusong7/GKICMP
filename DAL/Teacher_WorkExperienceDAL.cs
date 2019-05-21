/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年03月09日 13时53分29秒
** 描    述:      考核的基本操作类
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
    public partial class Teacher_WorkExperienceDAL : DataEntity<Teacher_WorkExperienceEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Teacher_WorkExperienceEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_WorkExperience_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TWEID", model.TWEID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TrainAddress", model.TrainAddress, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("TStartDate", model.TStartDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TEndDate", model.TEndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TrainContent", model.TrainContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("TType", model.TType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));


            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_WorkExperience_DelBat";
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
        public Teacher_WorkExperienceEntity GetObjByID(string id)
        {
            string sql = "SELECT *,b.RealName,b.TSex,b.IDCardNum,dbo.getUserName(a.TID) as TName FROM [Tb_Teacher_WorkExperience] a inner join dbo.Tb_Teacher b on a.TID=b.TID WHERE [TWEID] = '" + id + "'";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 根据老师ID查询工作信息
        /// <summary>
        /// 根据老师ID查询工作信息
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetListByTID(string tid, int isdel)
        {

            string sql = "SELECT *,dbo.getBaseDataName(TType) as TTypeName FROM [Tb_Teacher_WorkExperience] where Isdel=" + isdel + " and TID='" + tid + "' ORDER BY [TWEID] DESC";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Teacher_WorkExperienceEntity model,string realname)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_WorkExperience_Page";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TType", model.TType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TrainContent", model.TrainContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("TrainAddress", model.TrainAddress, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("RealName", realname, DatabaseType.SQL_NVarChar, 50));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


    }

}

