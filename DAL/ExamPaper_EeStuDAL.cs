/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年12月01日 14时59分09秒
** 描    述:      我的答题基本操作类
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
    public partial class ExamPaper_EeStuDAL : DataEntity<ExamPaper_EeStuEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ExamPaper_EeStuEntity model, int type, DateTime begin, DateTime end, int ppsid)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_EeStu_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EPEID", model.EPEID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EPID", model.EPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EPPID", model.EPPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EAnswer", model.EAnswer, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("EScore", model.EScore, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("StuID", model.StuID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("type", type, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 16));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 16));
            DbParameters.Add(new DatabaseParameter("ppsid", ppsid, DatabaseType.SQL_Int, 4));
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



        //#region 根据主键编号删除记录
        ///// <summary>
        ///// 根据主键编号删除记录
        /////</summary>
        //public int DeleteByID(string id)
        //{
        //    DbParameters.Clear();
        //    ProcedureName = "up_Tb_ExamPaper_Practice_DelBat";
        //    DataAccessChannelProtection = true;

        //    DbParameters.Add(new DatabaseParameter("Ids", id, DatabaseType.SQL_NVarChar, 2000));
        //    DbParameters.Add(new DatabaseParameter("Isdel", id, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("ExceptionCode", id, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("ExceptionMessage", id, DatabaseType.SQL_VarChar, 2048));

        //    STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
        //    if (stmessage.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    DataAccessChannel.CommitRelease();
        //    DataAccessChannelProtection = false;
        //    return stmessage.AffectRows;
        //}
        //#endregion



        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public ExamPaper_EeStuEntity GetObj(string EPPID, string EPID, string UID, int EID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_EeStu_GetByEPPID";
            DbParameters.Add(new DatabaseParameter("EPPID", EPPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EPID", EPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UID", UID, DatabaseType.SQL_VarChar, 40));
            DbParameters.Add(new DatabaseParameter("EID", EID, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion




        //#region 根据实体条件分页获取数据集，返回DataSet
        ///// <summary>
        ///// 根据实体条件分页获取数据集，返回DataSet
        ///// </summary>
        ///// <param name="pagesize">每页显示条数</param>
        ///// <param name="pageindex">当前页码,从1开始</param>
        ///// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        ///// <param name="model">条件实体</param>
        //public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ExamPaper_EeStuEntity model)
        //{
        //    DbParameters.Clear();
        //    ProcedureName = "up_Tb_ExamPaper_PractStu_Paged";
        //    DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
        //    DbParameters.Add(new DatabaseParameter("name", model.name, DatabaseType.SQL_NVarChar, 40));
        //    DbParameters.Add(new DatabaseParameter("createbegin", model.createbegin, DatabaseType.SQL_DateTime, 8));
        //    DbParameters.Add(new DatabaseParameter("createend", model.createend, DatabaseType.SQL_DateTime, 8));
        //    DbParameters.Add(new DatabaseParameter("createuser", model.createuser, DatabaseType.SQL_NVarChar, 40));
        //    DbParameters.Add(new DatabaseParameter("isdel", model.isdel, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("pagesize", model.pagesize, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("pageindex", model.pageindex, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("recordCount", model.recordCount, DatabaseType.SQL_Int, 4));

        //    if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    recordCount = Convert.ToInt32(DbParameters[2].Value);
        //    return DataReflectionContainer;
        //}
        //#endregion


    }

}

