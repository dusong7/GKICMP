/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月14日 09时54分59秒
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
    public partial class Teacher_PaperDAL : DataEntity<Teacher_PaperEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Teacher_PaperEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Paper_Add";
            DataAccessChannelProtection = true;
            int resultvalue = 0;
            DbParameters.Add(new DatabaseParameter("result", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TPID", model.TPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Publication", model.Publication, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("PaperName", model.PaperName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("PubDate", model.PubDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Volume", model.Volume, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("TermNum", model.TermNum, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BeginPage", model.BeginPage, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EndPage", model.EndPage, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("URoles", model.URoles, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SubjectArea", model.SubjectArea, DatabaseType.SQL_NVarChar, 10));
            DbParameters.Add(new DatabaseParameter("Included", model.Included, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            string a = DbParameters[0].Value.ToString();
            resultvalue = int.Parse(DbParameters[0].Value.ToString());
            return resultvalue;
        }
        #endregion

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Update(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Paper_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("TPID", id, DatabaseType.SQL_NVarChar, 2000));
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
            ProcedureName = "up_Tb_Teacher_Paper_DelBat";
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
        public Teacher_PaperEntity GetObjByID(string id)
        {
            string sql = "SELECT *,DBO.getUserName(TID) TeacherName,dbo.getBaseDataName(Included)IncludedName,dbo.getBaseDataName(SubjectArea)SubjectAreaName FROM [Tb_Teacher_Paper] WHERE [TPID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Teacher_PaperEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Paper_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
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

