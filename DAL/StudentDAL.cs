/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月16日 08时30分53秒
** 描    述:      学生信息的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;

namespace GK.GKICMP.DAL
{
    public partial class StudentDAL : DataEntity<StudentEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(StudentEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resutl", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("StID", model.StID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ClaID", model.ClaID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UsedName", model.UsedName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Photos", model.Photos, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("RegistType", model.RegistType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Guardian", model.Guardian, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("GuardNum", model.GuardNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EnterDate", model.EnterDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("RegisteredPlace", model.RegisteredPlace, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("IsLeftBehind", model.IsLeftBehind, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsField", model.IsField, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PlaceOrigin", model.PlaceOrigin, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Politics", model.Politics, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LoinDate", model.LoinDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsFlow", model.IsFlow, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("IsOnly", model.IsOnly, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GEnrollment", model.GEnrollment, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("PEnrollment", model.PEnrollment, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));


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


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public StudentEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getBaseDataName(IsFlow) IsFlowName,dbo.getUstate(UState) UStateName,dbo.getDepName(ClaID) ClaIDName from Tb_Student where StID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, StudentEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion

        public int Edit(int cid, Student model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_AddReg";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resutl", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StID", model.ID, DatabaseType.SQL_NVarChar, 40));


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

        #region 新生分班--按性别分班
        public int Update(List<ClassStuEntity> stu)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    for (int i = 0; i < stu.Count; i++)
                    {
                        int result = 0;
                        ClassStuEntity model = stu[i];
                        if (model != null)
                        {
                            foreach (Student s in model.Stu)
                            {
                                result = Edit(int.Parse(model.ClassID), s);
                                if (result == -1)
                                {
                                    resultvalue = -1;
                                    return resultvalue;
                                }
                            }
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
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
        #endregion



        #region 新生分班--平均分班

        public int UpdateAvg(List<StuDivideClassEntity> stu)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    for (int i = 0; i < stu.Count; i++)
                    {
                        int result = 0;
                        StuDivideClassEntity model = stu[i];
                        if (model != null)
                        {
                            foreach (WeightingData2 s in model.UserList)
                            {
                                //result = EditAvg(int.Parse(model.ID), s);
                                result = EditAvg(model.ID, s);
                                if (result == -1)
                                {
                                    resultvalue = -1;
                                    return resultvalue;
                                }
                            }
                        }
                    }
                    if (resultvalue == 0)
                    {
                        ts.Complete();
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

        public int EditAvg(int cid, WeightingData2 model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_AddReg";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resutl", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StID", model.Name, DatabaseType.SQL_NVarChar, 40));
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
        public DataTable GetStuRegPaged(int pagesize, int pageindex, ref int recordCount, StudentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_GetStuRegPaged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            //if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            //{
            //    throw new Exception(DataReturn.SqlMessage);
            //}
            //return DataReflectionContainer;
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
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
        public DataTable GetStuReg()
        {
            string sql = "select *,datediff(year,birthday,getdate())Age from Tb_Student where ClaID='' or ClaID is null order by StuMark desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        #region 获取全部新生
        /// <summary>
        /// 获取全部新生
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetStuAvg(int cid)
        {
            //string sql = "select *,datediff(year,birthday,getdate())Age from Tb_Student where ClaID='' or ClaID is null and HighEducation is not null and LevelCommunication is not null and Isdel=0 order by StuMark desc";
            //string sql = "select *,datediff(year,birthday,getdate())Age from Tb_Student where  ClaID is null and HighEducation is not null and LevelCommunication is not null and Isdel=0 order by StuMark desc";
            string sql = "select *,datediff(year,birthday,getdate())Age from Tb_Student where  ClaID is null and HighEducation is not null and LevelCommunication is not null and Isdel=0 and CID = '" + cid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        #region 根据班级id获取改版所有学生
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetStuByClass(int claid)
        {
            string sql = "select *,dbo.getGradeNameByDepID(depid)GName from Tb_SysUser where isdel=0 and UserType=2 and  ustate=0 and " + claid + " in (select col from dbo.f_split(depid,','))";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public DataTable GetUIDByDid(string did)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_GetUidsByDID";
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_NVarChar, 4000));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        public DataTable GetList()
        {
            string sql = "select a.RealName,a.UserSex,b.GID from Tb_Student a,Tb_Department b,Tb_Grade c where a.Isdel=0 and (a.UState=0 or UState=12 or UState=13) and a.ClaID=b.DID and b.GID=c.GID";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        //public int GetCount()
        //{
        //    string sql = "SELECT Count(*) FROM [Tb_Student] WHERE IsDel=0 and UState=0";
        //    if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return Convert.ToInt32(DataReflectionContainer.Rows[0][0]);
        //}
    }
}

