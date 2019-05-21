/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 15时30分27秒
** 描    述:      排课计划的基本操作类
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
using System.Transactions;


namespace GK.GKICMP.DAL
{
    public partial class TeacherPlaneDAL : DataEntity<TeacherPlaneEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(TeacherPlaneEntity model, string nec, string forbid, string rec)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TPID", model.TPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CTID", model.CTID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CourseID", model.CourseID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeacherID", model.TeacherID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("JieShu", model.JieShu, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LianJie", model.LianJie, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LianCi", model.LianCi, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("nec", nec, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("forbid", forbid, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("rec", rec, DatabaseType.SQL_NVarChar, 100));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value);

            return result;
        }
        #endregion



        #region 批量修改一条记录
        /// <summary>
        /// 批量修改一条记录
        ///</summary>
        public int PLXG(TeacherPlaneEntity model, string nec, string forbid, string rec)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_PLXG";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TPID", model.TPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CTID", model.CTID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CourseID", model.CourseID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeacherID", model.TeacherID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("JieShu", model.JieShu, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LianJie", model.LianJie, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LianCi", model.LianCi, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("nec", nec, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("forbid", forbid, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("rec", rec, DatabaseType.SQL_NVarChar, 100));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value);

            return result;
        }
        #endregion


        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int DeleteByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", id, DatabaseType.SQL_NVarChar, 4000));

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
        public TeacherPlaneEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getUserName(TeacherID) as TeacherName from Tb_TeacherPlane where TPID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, TeacherPlaneEntity model, ref int totalCount)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("totalCount", totalCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            totalCount = Convert.ToInt32(DbParameters[1].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 判断是否课程都有老师
        public DataTable GetDatatable()
        {
            string sql = "select dbo.getDepOtherName(ClaID),dbo.getCourseother(CourseID) from Tb_TeacherPlane where TeacherID='' and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and (b.IsGraduate=1 or a.Isdel=1 or b.Isdel=1)) order by dbo.getDepOtherName(ClaID)";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 获取所有的计划
        public DataTable GetAllPlanByWhere(string sqlWhere)
        {
            DbParameters.Clear();
            ProcedureName = "select * from dbo.Tb_TeacherPlane where 1=1" + sqlWhere;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, ProcedureName).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 获取班级计划最多数量
        /// <summary>
        /// 获取班级计划最多数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleSet_GetCount";
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            result = Convert.ToInt32(DbParameters[0].Value);
            return result;
        }
        #endregion


        #region 根据教师ID查找教师班级表年级信息
        /// <summary>
        /// 根据教师ID查找教师班级表年级信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetGIDByUID(string uid)
        {
            string sql = "SELECT distinct GID,dbo.getGradeName(GID) as GradeName FROM Tb_TeacherPlane a inner join Tb_Department b on a.ClaID = b.DID WHERE TeacherID = '" + uid + "' and b.Isdel=0 and DepType=-1";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 根据教师ID查找教师班级表信息
        /// <summary>
        /// 根据教师ID查找教师班级表信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetClaIDByUID(string uid, int gid)
        {
            string sql = "SELECT distinct DID,DepName FROM Tb_TeacherPlane a inner join Tb_Department b on a.ClaID = b.DID WHERE TeacherID = '" + uid + "' and b.GID='" + gid + "' and b.Isdel=0 and DepType=-1";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        //2版
        #region 获取所有的计划的班级ID
        public DataTable GetAllPlanClaIDByWhere()
        {
            DbParameters.Clear();
            ProcedureName = "select ClaID,dbo.getDepOtherName(ClaID) from dbo.Tb_TeacherPlane where ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and (b.IsGraduate=1 or a.Isdel=1 or b.Isdel=1))   group  by ClaID";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, ProcedureName).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 根据班级ID获取班级计划
        /// <summary>
        /// 根据班级ID获取班级计划
        /// </summary>
        /// <param name="claid">班级ID</param>
        public DataTable GetClByClaID(int claid)
        {
            string sql = "select *,dbo.getUserName(TeacherID) as TeacherName,dbo.getCourseName(CourseID) CourseIDName from Tb_TeacherPlane where ClaID = " + claid;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 添加一个年级信息
        public string TyAdd(List<TeacherPlaneEntity> list, string nec, string forbid, string rec)
        {
            string resultvalue = "";
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    int result = 0;
                    foreach (TeacherPlaneEntity tp in list)
                    {
                        TeacherPlaneEntity model = tp;
                        result = PLXG(model, nec, forbid, rec);
                        if (result == -1)
                        {
                            resultvalue = "保存失败";
                            break;
                        }
                    }
                    if (result == 0)
                    {
                        ts.Complete();
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }
        #endregion


        public TeacherPlaneEntity GetTPID(int isdel, int GID)
        {
            string sql = "select top 1 * from Tb_Department where GID='" + GID + "' and DepType=-1 and Isdel=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetNJPaged(int gid, ref int totalCount)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_NJPaged";
            DbParameters.Add(new DatabaseParameter("totalCount", totalCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("GID", gid, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            totalCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion



        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int NJDeleteByID(string id, int GID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_NJDelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", id, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("GID", GID, DatabaseType.SQL_Int, 4));
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


        #region 获取班级课程数量
        public DataTable GetCountByClaid(int claid, int cid, ref int result)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_GetCountByClaid";
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("claid", claid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("cid", cid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            result = Convert.ToInt32(DbParameters[0].Value);
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DataReflectionContainer; ;
        }
        #endregion


        #region 更新配置教师
        public int Update(string ClaIDs, int CID, string TID)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_UpdateByClaid";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ClaIDs", ClaIDs, DatabaseType.SQL_NVarChar, 400));
            DbParameters.Add(new DatabaseParameter("CID", CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TID", TID, DatabaseType.SQL_NVarChar, 40));
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


        #region 获取配置教师信息
        /// <summary>
        /// 获取配置教师信息
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetTeacherDetail(int gid, int cid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Detail";
            DbParameters.Add(new DatabaseParameter("GID", gid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DataReflectionContainer; ;
        }
        #endregion


        #region 同步更新教师信息
        public DataTable UpdateTeacher(string oldtid, string newtid, int newcrid, int term, string EYear)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduCourse_UpdateTeacher";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("oldtid", oldtid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("newtid", newtid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("newcrid", newcrid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EYear", EYear, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("term", term, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DataReflectionContainer; ;
        }
        #endregion


        #region 根据编号（主键）获取项:批量修改排课计划
        /// <summary>
        /// 根据编号（主键）获取项:批量修改排课计划
        /// </summary>
        /// <returns></returns>
        public TeacherPlaneEntity GetPLXG(int gid, int cid)
        {
            string sql = " select top 1 a.* from Tb_TeacherPlane a ,Tb_Department b where a.ClaID=b.DID and Isdel=0 and b.GID=" + gid + " and a.CourseID=" + cid + "";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        public DataTable GetTeacByDep(int depid) 
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_GetTeacByDep";
            DbParameters.Add(new DatabaseParameter("depid", depid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DataReflectionContainer; ;
        }
    }
}

