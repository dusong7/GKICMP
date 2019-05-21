/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年02月27日 14时38分19秒
** 描    述:      教师信息
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;
using gk.rjb_Y.Libraries;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace GK.GKICMP.DAL
{
    public partial class TeacherDAL : DataEntity<TeacherEntity>
    {
        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("IsDel", isdel, DatabaseType.SQL_Int, 4));
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
        public TeacherEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getBaseDataName(ProfessGrade) as ProfessGradeName,dbo.getCourseName(TeaQualCourse)TeaQualCourseName FROM [Tb_Teacher] WHERE [TID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        public DataTable GetList()
        {
            string sql = "SELECT * FROM [Tb_Teacher] WHERE IsDel=0 and TeaState=100";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public int Import(TeacherEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("OldName", model.OldName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TSex", model.TSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeacherCode", model.TeacherCode, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Nationality", model.Nationality, DatabaseType.SQL_NVarChar, 5));
            DbParameters.Add(new DatabaseParameter("CardType", model.CardType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IDCardNum", model.IDCardNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Birthday", model.Birthday, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PlaceOrigin", model.PlaceOrigin, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("OneNative", model.OneNative, DatabaseType.SQL_NVarChar, 15));
            DbParameters.Add(new DatabaseParameter("MaritalStatus", model.MaritalStatus, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("HealthStatus", model.HealthStatus, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("JodDate", model.JodDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("JoinSchool", model.JoinSchool, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TeaSource", model.TeaSource, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaType", model.TeaType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSeries", model.IsSeries, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EmploymentType", model.EmploymentType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ContractState", model.ContractState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsFulltime", model.IsFulltime, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSpecialTrain", model.IsSpecialTrain, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSpecialEdu", model.IsSpecialEdu, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("InformationLevel", model.InformationLevel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTeaStu", model.IsTeaStu, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsGrassService", model.IsGrassService, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GrassStartDate", model.GrassStartDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("GrassEndDate", model.GrassEndDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsSpecialTea", model.IsSpecialTea, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsCountyLevel", model.IsCountyLevel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsHealthTeahcer", model.IsHealthTeahcer, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaState", model.TeaState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Photos", model.Photos, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("TCourse", model.TCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TNation", model.TNation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Politics", model.Politics, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("TeaAddress", model.TeaAddress, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("LinkPhone", model.LinkPhone, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 11));
            DbParameters.Add(new DatabaseParameter("Email", model.Email, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("OtherLink", model.OtherLink, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("IsDel", model.IsDel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PartyTme", model.PartyTme, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PostRole", model.PostRole, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("SalaryGrade", model.SalaryGrade, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CurrentProfessional", model.CurrentProfessional, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeType", model.GradeType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProfessGrade", model.ProfessGrade, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsFull", model.IsFull, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("TeaAddress", model.TeaAddress, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Section", model.Section, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTea", model.IsTea, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeDate", model.GradeDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TeaQualiType", model.TeaQualiType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaQualCode", model.TeaQualCode, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("TeaQualCourse", model.TeaQualCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaQualDate", model.TeaQualDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TeaQualRegDate", model.TeaQualRegDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Mandarin", model.Mandarin, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRetire", model.IsRetire, DatabaseType.SQL_Int, 4));


            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        public int Import(TeacherEntity[] list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    for (int i = 0; i < list.Length; i++)
                    {
                        int result = 0;
                        TeacherEntity model = list[i];
                        result = Import(model);
                        if (result == -1)
                        {
                            resultvalue = -1;
                            return resultvalue;
                        }
                        if (result == -2)
                        {
                            resultvalue = -2;
                            break;
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
                    }
                    else if (resultvalue == -2)
                    {
                        resultvalue = -2;
                    }
                    else
                    {
                        resultvalue = -99;
                    }
                }
                catch (Exception)
                {
                    resultvalue = -99;
                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }

        #region 获取教师信息（统计表）
        /// <summary>
        /// 获取教师信息（统计表）
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="isseries"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetTeacher(int pagesize, int pageindex, ref int recordCount, TeacherEntity model, DateTime begindate, DateTime enddate, DateTime jbegin, DateTime jend, DateTime pbegin, DateTime pend, int education)
        {
            //string sql = "select * from Tb_Teacher where IsDel="+isdel+" and CID=";
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetTeacher";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("Campus", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSeries", model.IsSeries, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.IsDel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TSex", model.TSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Nation", model.TNation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("JBegin", jbegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("JEnd", jend, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PBegin", pbegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PEnd", pend, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PostRole", model.PostRole, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("Politics", model.Politics, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Education", education, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Course", model.TCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CurrentPro", model.CurrentProfessional, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCardNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("LinkNum", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Email", model.Email, DatabaseType.SQL_NVarChar, 200));


            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        public DataTable GetTID(string idcard)
        {
            DbParameters.Clear();
            DbParameters.Add(new DatabaseParameter("IDCard", idcard, DatabaseType.SQL_NVarChar, 20));
            ProcedureName = "up_Tb_Teacher_GetTID";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, TeacherEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TSex", model.TSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Politics", model.Politics, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TCourse", model.TCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSeries", model.IsSeries, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsDel", model.IsDel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaState", model.TeaAddress, DatabaseType.SQL_NVarChar, 100));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据部门ID查找教师
        /// <summary>
        /// 根据部门ID查找教师
        /// </summary>
        /// <param name="depid"></param>
        /// <param name="usertype"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetByDepID(int depid, int usertype, int isdel)
        {
            string sql = "SELECT * FROM [Tb_SysUser] WHERE ','+DepID+',' like '%," + depid + ",%' and UserType=" + usertype + " and Isdel=" + isdel + " order by RealName ";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion
        public DataTable GetByAssetUser(int depid, int stype, int isdel)
        {
            string sql = "SELECT * FROM [Tb_SysUser] a inner join Tb_SysUser_Type b on a.uid=b.uid  WHERE b.stype=" + stype + " and  ','+DepID+',' like '%," + depid + ",%'  and Isdel=" + isdel;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

        #region 获取教师职务角色
        /// <summary>
        /// 获取教师职务角色
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public DataTable GetRole(string tid)
        {
            string sql = "select * from Tb_Teacher_Role where TID='" + tid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据TID获取教师职务角色名称
        /// <summary>
        /// 根据TID获取教师职务角色名称
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public DataTable GetRoleTable(string tid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Role_GetTable";
            DbParameters.Add(new DatabaseParameter("TID", tid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        public DataTable GetMailList(string tname)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetMailList";
            DbParameters.Add(new DatabaseParameter("TName", tname, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

        #region 根据传进来的实体参数,修改记录
        /// <summary>
        /// 根据传进来的实体参数,修改记录
        ///</summary>
        public int Update(TeacherEntity model)
        {
            //int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_Update";
            DataAccessChannelProtection = true;
            //DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsSpecialEdu", model.IsSpecialEdu, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsTeaStu", model.IsTeaStu, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsGrassService", model.IsGrassService, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsCountyLevel", model.IsCountyLevel, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("IsHealthTeahcer", model.IsHealthTeahcer, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaState", model.TeaState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSeries", model.IsSeries, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsFulltime", model.IsFulltime, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSpecialTrain", model.IsSpecialTrain, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("IsSpecialTea", model.IsSpecialTea, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TNation", model.TNation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Politics", model.Politics, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("HealthStatus", model.HealthStatus, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TSex", model.TSex, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("TeaType", model.TeaType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MaritalStatus", model.MaritalStatus, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CardType", model.CardType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaSource", model.TeaSource, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EmploymentType", model.EmploymentType, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("ContractState", model.ContractState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("InformationLevel", model.InformationLevel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Birthday", model.Birthday, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("JodDate", model.JodDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("JoinSchool", model.JoinSchool, DatabaseType.SQL_DateTime, 20));

            DbParameters.Add(new DatabaseParameter("GrassStartDate", model.GrassStartDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("GrassEndDate", model.GrassEndDate, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("OldName", model.OldName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TeacherCode", model.TeacherCode, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Nationality", model.Nationality, DatabaseType.SQL_NVarChar, 5));

            DbParameters.Add(new DatabaseParameter("IDCardNum", model.IDCardNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("PlaceOrigin", model.PlaceOrigin, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("OneNative", model.OneNative, DatabaseType.SQL_NVarChar, 15));


            DbParameters.Add(new DatabaseParameter("TCourse", model.TCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PartyTme", model.PartyTme, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("PostRole", model.PostRole, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("PostName", model.PostName, DatabaseType.SQL_NVarChar, 1000));

            DbParameters.Add(new DatabaseParameter("SalaryGrade", model.SalaryGrade, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CurrentProfessional", model.CurrentProfessional, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeType", model.GradeType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProfessGrade", model.ProfessGrade, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsFull", model.IsFull, DatabaseType.SQL_Int, 4));

            // DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));

            //DbParameters.Add(new DatabaseParameter("MainCourse",model.MainCourse, DatabaseType.SQL_Int, 4 ));
            //DbParameters.Add(new DatabaseParameter("AduitState",model.AduitState, DatabaseType.SQL_Int, 4 ));


            //DbParameters.Add(new DatabaseParameter("RealName",model.RealName, DatabaseType.SQL_NVarChar, 50 ));
            //DbParameters.Add(new DatabaseParameter("Photos",model.Photos, DatabaseType.SQL_NVarChar, 1000 ));
            //DbParameters.Add(new DatabaseParameter("CreateDate",model.CreateDate, DatabaseType.SQL_DateTime, 20 ));
            //DbParameters.Add(new DatabaseParameter("CreateUser",model.CreateUser, DatabaseType.SQL_NVarChar, 40 ));
            //DbParameters.Add(new DatabaseParameter("IsDel",model.IsDel, DatabaseType.SQL_Int, 4 ));

            DbParameters.Add(new DatabaseParameter("IsTea", model.IsTea, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeDate", model.GradeDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Mandarin", model.Mandarin, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaQualiType", model.TeaQualiType, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("TeaQualCode", model.TeaQualCode, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("TeaQualCourse", model.TeaQualCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TeaQualDate", model.TeaQualDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("TeaQualRegDate", model.TeaQualRegDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Section", model.Section, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("IsRetire", model.IsRetire, DatabaseType.SQL_Int, 4));



            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            // resultvalue = Convert.ToInt32(DbParameters[0].Value);
            // return resultvalue;
            return stmessage.AffectRows;
        }
        #endregion


        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int InUpdate(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_InUpdate";
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

        #region 是否存在教师工号
        /// <summary>
        /// 是否存在教师工号
        /// </summary>
        /// <param name="depid"></param>
        /// <param name="usertype"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetUserNum(string teachercode, int isdel)
        {
            string sql = "SELECT * FROM [Tb_Teacher] WHERE TeacherCode='" + teachercode + "' and IsDel=" + isdel;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        #region 教师分析
        /// <summary>
        /// 年龄分析
        /// </summary>
        /// <returns></returns>
        public DataTable GetAge()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetAge";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        /// <summary>
        /// 学历分析
        /// </summary>
        /// <returns></returns>
        public DataTable GetEdu()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetEdu";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        /// <summary>
        /// 在编比例
        /// </summary>
        /// <returns></returns>
        public DataTable TState()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetState";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 获取未删除的教师--修改身份证
        public DataTable GetT()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetT";

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 更新身份证
        /// <summary>
        /// 更新身份证
        ///</summary>
        public int InUpdate(string tid, string idcard)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_UpdateIDCard";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("TID", tid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IDCardNum", idcard, DatabaseType.SQL_NVarChar, 50));
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

        public DataTable GetTStatistics(int IsSeries)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_GetTStatistics";
            DbParameters.Add(new DatabaseParameter("IsSeries", IsSeries, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

        #region 查询所有教师，用于更新加密身份证查询
        /// <summary>
        /// 查询所有教师
        ///</summary>
        public DataTable GetTeacherByIsDel(int isdel)
        {
            string sql = "SELECT *  FROM Tb_Teacher WHERE IsDel=" + isdel + " and Len(IDCardNum) >18";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 更新身份证
        /// <summary>
        /// 更新身份证
        ///</summary>
        public int UpdateTeacherIDCard(string tid, string idcard)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Teacher_UpdateIDCard";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("TID", tid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IDCardNum", idcard, DatabaseType.SQL_NVarChar, 100));
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


        //public int GetCount()
        //{
        //    string sql = "SELECT Count(*) FROM [Tb_Teacher] WHERE IsDel=0 and TeaState=100";
        //    if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return Convert.ToInt32(DataReflectionContainer.Rows[0][0]);
        //}

    }
}
