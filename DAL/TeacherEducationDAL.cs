/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年02月27日
** 描 述:       年级页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;
using System.Transactions;

namespace GK.GKICMP.DAL
{
    public partial class TeacherEducationDAL : DataEntity<Teacher_EducationEntity>
    {
        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Teacher_EducationEntity model, string realname)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Education_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EMajor", model.EMajor, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("RealName", realname, DatabaseType.SQL_NVarChar, 50));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据老师ID查询学历信息
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetListByTID(string tid, int isdel)
        {
            string sql = "SELECT *,dbo.getBaseDataName(EduCountry) as EduCountryName,dbo.getBaseDataName(CompanyType) as CompanyTypeName,dbo.getBaseDataName(EduCountry) as EduCountryName,dbo.getBaseDataName(CompanyType) as CompanyTypeName FROM [Tb_Teacher_Education] where Isdel='" + isdel + "' and TID='" + tid + "' ORDER BY [CreateDate] DESC";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Education_DelBat";
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
        public Teacher_EducationEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getUserName(TID) as TName from Tb_Teacher_Education where TEID='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Teacher_EducationEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Education_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("TEID", model.TEID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Education", model.Education, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTeach", model.IsTeach, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DegreeLevel", model.DegreeLevel, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("DegreeName", model.DegreeName, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StudyType", model.StudyType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CompanyType", model.CompanyType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EduCountry", model.EduCountry, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeCountry", model.GradeCountry, DatabaseType.SQL_Int, 4));


            DbParameters.Add(new DatabaseParameter("InDate", model.InDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("OutDate", model.OutDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EduSchool", model.EduSchool, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("EMajor", model.EMajor, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("GradeSchool", model.GradeSchool, DatabaseType.SQL_NVarChar, 500));


            DbParameters.Add(new DatabaseParameter("GrantDate", model.GrantDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
        }
        #endregion

        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Education_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 1000));
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



        #region 考勤信息导入
        /// <summary>
        /// 学生信息导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string  Import(Teacher_EducationEntity[] list)
        {
            string resultvalue ="";
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        int result = 0;
                        Teacher_EducationEntity model = list[i];
                        result = Edits(model);
                        if (result == -1)
                        {
                            resultvalue = "第" + (i + 1) + "行数据导入失败，请重新导入";
                            return resultvalue;
                        }
                        if (result == -2)
                        {
                            resultvalue ="第" + (i + 1) + "行数据已存在，请重新导入";
                            break;
                        }
                    }
                    if (resultvalue == "")
                    {
                        ts.Complete();
                    }
                }
                catch (Exception ex)
                {
                    resultvalue =ex.Message;
                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }
        #endregion


        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edits(Teacher_EducationEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Education_Adds";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Education", model.Education, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTeach", model.IsTeach, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DegreeLevel", model.DegreeLevel, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("DegreeName", model.DegreeName, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StudyType", model.StudyType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CompanyType", model.CompanyType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EduCountry", model.EduCountry, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeCountry", model.GradeCountry, DatabaseType.SQL_Int, 4));


            DbParameters.Add(new DatabaseParameter("InDate", model.InDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("OutDate", model.OutDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EduSchool", model.EduSchool, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("EMajor", model.EMajor, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("GradeSchool", model.GradeSchool, DatabaseType.SQL_NVarChar, 500));


            DbParameters.Add(new DatabaseParameter("GrantDate", model.GrantDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
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


        public DataTable GetList()
        {
            string sql = "SELECT * FROM [Tb_Teacher_Education] WHERE IsDel=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }
}
