/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年12月01日 08时12分46秒
** 描    述:      我的练习基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;


namespace GK.GKICMP.DAL
{
    public partial class ExamPaper_PractStuDAL : DataEntity<ExamPaper_PractStuEntity>
    {
      

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public ExamPaper_PractStuEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_PractStu_Get";
            DbParameters.Add(new DatabaseParameter("PPSID", id, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, DateTime begin, DateTime end, string name, DateTime createbegin, DateTime createend, string createuser, int isdel, string uid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_PractStu_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("name", name, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 16));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 16));
            DbParameters.Add(new DatabaseParameter("createbegin", createbegin, DatabaseType.SQL_DateTime, 9));
            DbParameters.Add(new DatabaseParameter("createend", createend, DatabaseType.SQL_DateTime, 9));
            DbParameters.Add(new DatabaseParameter("createuser", createuser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("uid", uid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public ExamPaper_PractStuEntity GetByEPPID(string EPPID, string UID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ExamPaper_PractStu_GetByEPPID";
            DbParameters.Add(new DatabaseParameter("EPPID", EPPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UID", UID, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
    }

}

