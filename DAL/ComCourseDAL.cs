/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年02月27日 17时05分33秒
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
    public partial class ComCourseDAL : DataEntity<ComCourseEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ComCourseEntity model)
        {
            DbParameters.Clear();
            int result = 0;
            ProcedureName = "up_Tb_ComCourse_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.InputOutput));
            DbParameters.Add(new DatabaseParameter("CCID", model.CCID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ChapterName", model.ChapterName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("RegDate", model.RegDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("Xyear", model.Xyear, DatabaseType.SQL_NVarChar, 50));
            //DbParameters.Add(new DatabaseParameter("XTerm", model.XTerm, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DID", model.DID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClassNum", model.ClassNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return int.Parse(DbParameters[0].Value.ToString());
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids,int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComCourse_DelBat";
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
        public ComCourseEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComCourse_Get";
            DbParameters.Add(new DatabaseParameter("CCID", id, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ComCourseEntity model,DateTime begin,DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ComCourse_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));

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

