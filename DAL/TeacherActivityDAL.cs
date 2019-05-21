/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月15日 08时47分10秒
** 描    述:      教学活动操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class TeacherActivityDAL : DataEntity<TeacherActivityEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(TeacherActivityEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherActivity_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SAID", model.SAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ActName", model.ActName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ActType", model.ActType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ActAddress", model.ActAddress, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Counselor", model.Counselor, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("ActContent", model.ActContent, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("ActDesc", model.ActDesc, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("ABegin", model.ABegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AEnd", model.AEnd, DatabaseType.SQL_DateTime, 8));
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids,int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherActivity_DelBat";
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
        public TeacherActivityEntity GetObjByID(string id)
        {
            DbParameters.Clear();
              ProcedureName = "up_Tb_TeacherActivity_Get";
            DbParameters.Add(new DatabaseParameter("SAID", id, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, TeacherActivityEntity model,DateTime begindate,DateTime enddate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherActivity_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ActName",model.ActName,DatabaseType.SQL_NVarChar,200));
            DbParameters.Add(new DatabaseParameter("ActType", model.ActType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

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