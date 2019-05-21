/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年03月02日 10时58分13秒
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
    public partial class CourseDAL : DataEntity<CourseEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(CourseEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CourseName", model.CourseName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CourseOther", model.CourseOther, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("MaterialNum", model.MaterialNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EditionNum", model.EditionNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsOpen", model.IsOpen, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsStanard", model.IsStanard, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CourseGrade", model.CourseGrade, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsMain", model.IsMain, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsElective", model.IsElective, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("result", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            resultvalue = Convert.ToInt32(DbParameters[12].Value);
            return resultvalue;
        }
        #endregion


        #region 是否开设
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Update(int cid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));

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
            ProcedureName = "up_Tb_Course_DelBat";
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
        public CourseEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_Course where CID=" + id;
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
        public DataTable GetList()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_GetList";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        public int GetCID(string coursename)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_GetCID";
            DbParameters.Add(new DatabaseParameter("CourseName", coursename, DatabaseType.SQL_NVarChar, 100));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            if (DataReflectionContainer!=null&&DataReflectionContainer.Rows.Count>0)
            {
                return int.Parse(DataReflectionContainer.Rows[0]["CID"].ToString());
            }

            return 0;
        }

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, CourseEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CourseName", model.CourseName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[4].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 获取课程信息
        /// <summary>
        /// 根据条件获取课程信息
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetCourseByWhere(string sqlWhere)
        {
            DbParameters.Clear();
            ProcedureName = "select * from dbo.Tb_Course where 1=1" + sqlWhere;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, ProcedureName).DataReturn.SqlCode != 0)
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
        public DataTable GetCourse(int IsElective)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_GetCourse";
            DbParameters.Add(new DatabaseParameter("IsElective", IsElective, DatabaseType.SQL_Int, 4));
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
        public DataTable GetCourseAll(string tid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Course_ALL";
            DbParameters.Add(new DatabaseParameter("tid", tid, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetCourse(string tid)
        {
            string sql = "select CourseID CID,dbo.getCourseName(CourseID)CourseName  from [dbo].[Tb_TeacherPlane] where ClaID in(select  DepID from tb_sysuser where UID='" + tid + "')";
           
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }

}
