/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月19日 14时05分31秒
** 描    述:      排课课程表的基本操作类
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
    public partial class ScheduleCourseDAL : DataEntity<ScheduleCourseEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ScheduleCourseEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("SCID", model.SCID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Position", model.Position, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ShouKeZhou", model.ShouKeZhou, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CourseID", model.CourseID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 50));

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



        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ScheduleCourseEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 清空课表数据
        /// <summary>
        /// 清空课表数据
        /// </summary>
        public void Tb_ScheduleCourseDelete(string EYear, int Term)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_ByTerm";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("EYear", EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Term", Term, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
        }
        #endregion


        #region 获取课表信息
        /// <summary>
        /// 根据条件获取课表信息
        /// </summary>
        /// <param name="sqlWhere">查询条件</param>
        /// <returns></returns>
        public DataTable GetAllScheduleCourseByWhere(string sqlWhere)
        {
            DbParameters.Clear();
            ProcedureName = "select SCID,ClaID,CID,TID,CRID,Position,ShouKeZhou,CourseID,dbo.getCourseName(CID) CourseRepeat,dbo.getUserName(TID) TeacherRepeat,dbo.getDepName(ClaID) ClaIDName,dbo.getDepOtherName(ClaID) DepOtherName,case when CRID=-2 then '' else dbo.getClassRoomName(CRID) end CRIDName  from dbo.Tb_ScheduleCourse where 1=1" + sqlWhere;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, ProcedureName).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion
        #region 调课 （根据申请人查询所在班级所调节次无课的，以及申请人所调课节次无课的教师列表）
        /// <summary>
        /// 调课 （根据申请人查询所在班级所调节次无课的，以及申请人所调课节次无课的教师列表）
        /// </summary>
        /// <param name="jc">节次</param>
        /// <param name="tid">教师id</param>
        /// <returns>教师列表</returns>
        public DataTable getTeaByClass(int jc, string tid)
        {
            string sql = "select TID,dbo.getTeahName(tid)TName from Tb_ScheduleCourse where ClaID =(select top 1 ClaID from Tb_ScheduleCourse where TID='" + tid + "') and Position <>" + jc + " and Position not in(select Position from Tb_ScheduleCourse where TID='" + tid + "' group by Position) group by TID";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 添加排课信息
        /// <summary>
        /// 排课过程中向课表中添加排课信息
        /// </summary>
        /// <param name="sql"></param>
        public void Insert_Tb_ScheduleCourse(string sql)
        {
            DbParameters.Clear();
            DataAccessChannelProtection = true;
            if (ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
        }
        #endregion


        #region 修改排课信息
        /// <summary>
        /// 修改排课信息
        /// </summary>
        /// <param name="sql"></param>
        public void Update_Tb_ScheduleCourse(string sql)
        {
            DbParameters.Clear();
            ProcedureName = sql;
            DataAccessChannelProtection = true;
            if (ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION, ProcedureName).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
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
        public DataTable GetClaID(string EYear, int Term)
        {
            string sql = "select ClaID,dbo.getDepOtherName(ClaID) ClaIDName from Tb_ScheduleCourse where Isdel=0 and EYear='" + EYear + "' and Term='" + Term + "'and ClaID not in (select DID from Tb_Department a,Tb_Grade b where a.GID=b.GID and a.DepType=-1 and b.IsGraduate=1) group by ClaID order by ClaIDName ";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion



        #region 删除课表数据根据单元格id
        /// <summary>
        /// 删除课表数据根据单元格id
        /// </summary>
        public int Delete(string scid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleSet_Delete";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("scid", scid, DatabaseType.SQL_NVarChar, 50));
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


        #region 根据实体条件获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件获取数据集，返回DataSet
        /// </summary>            
        public DataTable GetByclaidorpos(int Claid, int pos, string EYear, int Term)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_GetByclaidorpos";
            DbParameters.Add(new DatabaseParameter("Claid", Claid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pos", pos, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EYear", EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Term", Term, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 修改课表
        /// <summary>
        /// 修改课表
        ///</summary>
        public int Update(string scid, int pos)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("SCID", scid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("pos", pos, DatabaseType.SQL_Int, 4));

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


        #region 根据实体条件获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件获取数据集，返回DataSet
        /// </summary>            
        public DataTable GetShowTeacher(string Position, DateTime data, string TID, string EYear, int Term)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_GetShowTeacher";
            DbParameters.Add(new DatabaseParameter("Position", Position, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("data", data, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TID", TID, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EYear", EYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Term", Term, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据实体条件获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件获取数据集，返回DataSet
        /// </summary>            
        public DataTable GetTables(string scid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_GetTables";
            DbParameters.Add(new DatabaseParameter("scid", scid, DatabaseType.SQL_NVarChar, 4000));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据实体条件获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件获取数据集，返回DataSet
        /// </summary>            
        public DataTable GetEYear()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_GetEYear";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 引用上学期课表
        /// <summary>
        /// 引用上学期课表
        ///</summary>
        public int YYSXQKB(string oldEYear,int oldTerm,string EYear,int Term)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleCourse_YYSXQKB";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("oldTerm", oldTerm, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("oldEYear", oldEYear, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Term", Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EYear", EYear, DatabaseType.SQL_NVarChar, 50));
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
    }

}

