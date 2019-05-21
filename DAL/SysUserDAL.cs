/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      fsc
** 创建日期:      2017年02月27日 14时38分19秒
** 描    述:      用户角色数据的基本操作类
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
using System.Data;
using System.Transactions;

namespace GK.GKICMP.DAL
{
    public partial class SysUserDAL : DataEntity<SysUserEntity>
    {
        #region 获取同班同学信息
        public DataTable GetTable(string depid)
        {
            string sql = "SELECT [UID],UserID,UserName,DepID,IDCard,UserPwd,CellPhone,Address,CompanyNum,MailNum,QQNum,WeiNum,BirthDay,UserSex,UserType,RealName,CreateDate,CreateUser,Nation,isnull(Photos,'') Photos,LastDate,UState,UserDesc,CardNum,Isdel,CID,ASID,FaceNum,Followed  FROM Tb_SysUser where DepID='" + depid + "' and UserType=2 and Isdel=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取学生手机端通讯录信息
        public DataTable GetLink(string depid, string name)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetLink";
            DbParameters.Add(new DatabaseParameter("DepID", depid, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("RealName", name, DatabaseType.SQL_NVarChar, 50));

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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SysUserEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("ClassID", model.ClassID, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("RoleID", model.RoleID, DatabaseType.SQL_NVarChar, 50));

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
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetStuRegPaged(int pagesize, int pageindex, ref int recordCount, SysUserEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetStuRegPaged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 18));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 添加一条用户记录
        /// <summary>
        /// 添加一条用户记录
        ///</summary>
        public int Edit(SysUserEntity model, int id, int isnot)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Photos", model.Photos, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("roles", model.Roles, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("isnot", isnot, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FaceNum", model.FaceNum, DatabaseType.SQL_NVarChar, 200));

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
        public int Update(SysUserEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Photos", model.Photos, DatabaseType.SQL_NVarChar, 200));
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

        public int StuRegAdd(SysUserEntity model, int id, decimal mark)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_StuRegAdd";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Mark", mark, DatabaseType.SQL_Decimal, 7));
            DbParameters.Add(new DatabaseParameter("roles", model.Roles, DatabaseType.SQL_NVarChar, 2000));

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
        /// <summary>
        /// 更新用户的微信id
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int UpdateUserID(string uid)
        {

            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_UpdateUserID";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("UID", uid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

        public int EditAPP(SysUserEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_AddAPP";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            // DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            //DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            // DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            // DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 50));
            //   DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            //  DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            //  DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            //  DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            //  DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            //   DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
            //return stmessage.AffectRows;
        }
        #endregion

        #region 教师 学生导入
        public int Import(SysUserEntity[] list, int id)
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
                        SysUserEntity model = list[i];
                        if (model != null)
                        {
                            result = AddImport(model, id);
                            if (result == -1)
                            {
                                resultvalue = -1;
                                return resultvalue;
                            }
                            else if (result == -2)
                            {
                                resultvalue = -2;
                                return resultvalue;
                            }
                            else if (result == -3)
                            {
                                resultvalue = -3;
                                return resultvalue;
                            }
                            else if (result == -4)
                            {
                                resultvalue = -4;
                                return resultvalue;
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
                catch (Exception ex)
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


        public int AddImport(SysUserEntity model, int id)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_AddImport";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("roles", model.Roles, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));



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

        #region 新生导入
        public int StuImport(SysUserEntity[] list, int id, int higheducation, int levelcommunication)
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
                        SysUserEntity model = list[i];
                        if (model != null)
                        {
                            result = AddStuImport(model, id, higheducation, levelcommunication);
                            if (result == -1)
                            {
                                resultvalue = -1;
                                return resultvalue;
                            }
                            else if (result == -2)
                            {
                                resultvalue = -2;
                                return resultvalue;
                            }
                            else if (result == -3)
                            {
                                resultvalue = -3;
                                return resultvalue;
                            }
                            else if (result == -4)
                            {
                                resultvalue = -4;
                                return resultvalue;
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
                catch (Exception ex)
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


        public int AddStuImport(SysUserEntity model, int id, int higheducation, int levelcommunication)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_StuUser_AddImport";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("roles", model.Roles, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("HighEducation", higheducation, DatabaseType.SQL_Int, 4));//家长最高学历
            DbParameters.Add(new DatabaseParameter("LevelCommunication", levelcommunication, DatabaseType.SQL_Int, 4));//交流水平



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

        #region 新生添加
        public int StuAvgAdd(SysUserEntity model, int id, decimal mark, int higheducation, int levelcommunication)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_StuAvgAdd";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("CompanyNum", model.CompanyNum, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("MailNum", model.MailNum, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("QQNum", model.QQNum, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("WeiNum", model.WeiNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BirthDay", model.BirthDay, DatabaseType.SQL_DateTime, 10));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            // DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Nation", model.Nation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserDesc", model.UserDesc, DatabaseType.SQL_Text));
            //DbParameters.Add(new DatabaseParameter("CardNum", model.CardNum, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("roles", model.Roles, DatabaseType.SQL_NVarChar, 2000));

            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Mark", mark, DatabaseType.SQL_Decimal, 7));
            DbParameters.Add(new DatabaseParameter("HighEducation", higheducation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LevelCommunication", levelcommunication, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));

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

        #region 新生入学页面删除
        /// <summary>
        /// 新生入学页面删除
        ///</summary>
        public int DeleteStuBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_DelStuBat";
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


        #region 根据部门查询用户信息
        /// <summary>
        /// 根据部门查询用户信息
        ///</summary>
        public DataTable GetSysUserByDepid(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetTeacherByDepID";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", id.ToString(), DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据部门查询用户信息
        /// <summary>
        /// 根据部门查询用户信息
        ///</summary>
        public DataTable GetSysUserByDepid(int usertype, int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetUserByDepID";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", id.ToString(), DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserType", usertype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion 

        #region 根据部门查询用户信息
        /// <summary>
        /// 根据部门查询用户信息
        ///</summary>
        public DataTable GetUserByRYFL(int usertype, int did)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetUserByRYFL";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserType", usertype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion 


        #region 根据角色查询用户信息
        public DataTable GetSysUserByRole(int roleid, int isdel)
        {
            //string sql = "SELECT *  FROM [Tb_SysUser] WHERE UserType=" + id + " and Isdel=" + isdel;
            string sql = " select a.* from Tb_SysUser a,Tb_SysRole_User b,Tb_SysRole c where a.UID=b.SysID and b.RoleID=c.RoleID and c.RoleID=" + roleid + " and a.isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据部门获取数据集，返回DataSet(学生)
        /// <summary>
        /// 根据部门获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetTeacherByDepID(int depid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetTeacherByDepID";
            DbParameters.Add(new DatabaseParameter("DID", depid.ToString(), DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            // recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 查询所有教师，用于更新加密身份证查询
        /// <summary>
        /// 查询所有教师
        ///</summary>
        public DataTable GetSysUserByType(int id, int isdel)
        {
            //string sql = "SELECT *  FROM [Tb_SysUser] WHERE UserType=" + id + " and Isdel=" + isdel;
            string sql = "SELECT *  FROM [Tb_SysUser] WHERE UserType=" + id + " and Isdel=" + isdel + " and Len(IDCard) >18";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public DataTable GetSysUserByTeac(int id, int isdel)
        {
            //string sql = "SELECT *  FROM [Tb_SysUser] WHERE UserType=" + id + " and Isdel=" + isdel;
            //string sql = "SELECT [UID],UserID,UserName,DepID,IDCard,UserPwd,CellPhone,Address,CompanyNum,MailNum,QQNum,WeiNum,BirthDay,UserSex,UserType,RealName,CreateDate,CreateUser,Nation,isnull(Photos,'') Photos,LastDate,UState,UserDesc,CardNum,Isdel,CID,ASID,FaceNum,Followed  FROM [Tb_SysUser] WHERE UserType=" + id + " and Isdel=" + isdel;
            string sql = "SELECT [UID],UserID,UserName,DepID,IDCard,UserPwd,CellPhone,Address,CompanyNum,MailNum,QQNum,WeiNum,BirthDay,UserSex,UserType,RealName,CreateDate,CreateUser,Nation,isnull(Photos,'') Photos,LastDate,UState,UserDesc,CardNum,Isdel,CID,FaceNum,Followed  FROM [Tb_SysUser] WHERE UserType=" + id + " and Isdel=" + isdel;
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
            ProcedureName = "up_Tb_SysUser_DelBat";
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
        public SysUserEntity GetObjByID(string id)
        {
            string sql = "SELECT *,[dbo].getUstate(UState) UStateName,dbo.getDepName(DepID) DepName,dbo.getStuMark(UID) Mark,dbo.getCampusName(CID) as CampusName FROM [Tb_SysUser] WHERE [UID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }

        #region 查询学生信息
        public SysUserEntity GetStuByID(string id)
        {
            string sql = "SELECT *,[dbo].getUstate(a.UState) UStateName,dbo.getDepName(a.DepID) DepName,dbo.getStuMark(a.UID) Mark,dbo.getCampusName(a.CID) as CampusName,b.HighEducation,b.LevelCommunication FROM [Tb_SysUser] a inner join Tb_Student b on a.UID=b.StID WHERE [UID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        public SysUserEntity GetLogin(string username)
        {
            string sql = "SELECT *,[dbo].getUstate(UState) UStateName,dbo.getDepName(DepID) DepName,dbo.getStuMark(UID) Mark,dbo.getCampusName(CID) as CampusName FROM [Tb_SysUser] WHERE [UserName] = '" + username + "' and isdel=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        /// <summary>
        /// 验证微信用户登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="id">用户微信id</param>
        /// <returns>用户实体</returns>
        public SysUserEntity GetObjByID(string phone, string id, int fllow)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetByWX";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("CellPhone", phone, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("WeiNum", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Followed", fllow, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return First();
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        ///</summary>
        public int PwdSet(string Ids, string pwd)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_PwdSet";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Ids", Ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("PassWord", pwd, DatabaseType.SQL_NVarChar, 100));

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

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public SysUserEntity UserLogin(string name, string pwd)
        {
            //SysUserEntity user = null;
           // string UID = "";
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_Login";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("UserName", name, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserPwd", pwd, DatabaseType.SQL_NVarChar, 100));
            //DbParameters.Add(new DatabaseParameter("UID", UID, DatabaseType.SQL_NVarChar, 40, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return First();
            //UID = DbParameters[2].Value.ToString();
            //DataAccessChannel.CommitRelease();
            //DataAccessChannelProtection = false;
            //if (UID != "")
            //    user = GetObjByID(UID);
            //return user;

        }

        public SysUserEntity UserLoad(string name, string pwd, ref int result)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_UserLoad";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_NVarChar, 40, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UserName", name, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserPwd", pwd, DatabaseType.SQL_NVarChar, 100));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = int.Parse(DbParameters[0].Value.ToString());
            return First();
        }
        public DataTable GetLDAP()
        {
            string sql = "select * from tb_LDAP";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #endregion


        public DataTable GetUserByDep(string depid)
        {
            string sql = "select * from Tb_SysUser where ('" + depid + "' in (select col from f_split( DepID,',')) or '" + depid + "'='-2') and Isdel=0 AND UserType=1";

            //string tsql = "select * from Tb_SysUser where DepID='" + depid + "DepID like" + "' and Isdel=0 and UserType=1";

            //DepID='3' or DepID like '%,3' or DepID like '%,3,%' or DepID like '3,%'

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public string GetUID(string idcard)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetUID";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_NVarChar, 40, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("IDCard", idcard, DatabaseType.SQL_NVarChar, 100));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DbParameters[0].Value.ToString();
        }
        public DataTable GetToUser(string touser)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_GetToUser";
            DbParameters.Add(new DatabaseParameter("ToUser", touser, DatabaseType.SQL_NVarChar));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        //public DataTable GetTest()
        //{
        //    DbParameters.Clear();
        //    string sql = "select * from ";
        //    DbParameters.Add(new DatabaseParameter("ToUser", touser, DatabaseType.SQL_NVarChar));
        //    if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return DataReflectionContainer;
        //}

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetStudent(int pagesize, int pageindex, ref int recordCount, SysUserEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Student_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserType", model.UserType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("UserSex", model.UserSex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("UState", model.UState, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion



        #region 根据用户名获取项:返回实体对象
        /// <summary>
        /// 根据用户名获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public SysUserEntity GetByUserName(string UserName)
        {
            string sql = "SELECT *,[dbo].getUstate(UState) UStateName,dbo.getDepName(DepID) DepName,dbo.getStuMark(UID) Mark,(select IsSeries from Tb_Teacher where TID=UID and IsDel=0) IsSeries  FROM [Tb_SysUser] WHERE	UserName = '" + UserName + "' and UserType=1 and UState=0 and Isdel=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion




        #region 更新身份证
        /// <summary>
        /// 更新身份证
        ///</summary>
        public int UpdateIDCard(string tid, string idcard)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_UpdateIDCard";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("UID", tid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IDCard", idcard, DatabaseType.SQL_NVarChar, 100));
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

        public DataTable GetPhone(int type)
        {
            DbParameters.Clear();
            string sql = "select  cellphone,userid  from Tb_SysUser where UID in (select UID from Tb_SysUser_Type where SType=" + type + ")";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

        



        public DataTable GetPhone(string uid)
        {
            DbParameters.Clear();
            string sql = "select  cellphone,userid  from Tb_SysUser where UID in (select * from dbo.f_split('" + uid + "',','))";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        public DataTable GetUserID()
        {
            DbParameters.Clear();
            string sql = "select UserID from Tb_SysUser where isdel=0 and ustate=0 and UserType=1 and( UserID is not null and UserID<>'')";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public DataTable GetMsgIdByDep(string depid ,bool isteac=false)
        {
            DbParameters.Clear();
            string sql="";
           // "select * from Tb_SysUser where ','+DepID+',' like '%,'+@DID+',%' and Isdel=0 and UState=0";
            //string sql = "select  cellphone,userid  from Tb_SysUser where UID in ((SELECT  a.UID FROM    (SELECT  UID, DepIDs= CAST( '<x>'+ REPLACE (DepID, ',', '</x><x>')+ '</x>'  AS XML) FROM Tb_SysUser where Isdel=0  and UState=0 ) a OUTER APPLY (SELECT DepIDs= N.v.value ('.', 'varchar(10)') FROM a.DepIDs.nodes ('/x') N( v) ) b where b.DepIDs in (select * from dbo.f_split('" + depid + "',',')) group by UID)union (select TeacherID from Tb_TeacherPlane where ClaID in (select * from dbo.f_split('" + depid + "',','))))";

            if (isteac)
                sql = "select  cellphone,userid  from Tb_SysUser where UID is not null and  UID in ((SELECT  a.UID FROM    (SELECT  UID, DepIDs= CAST( '<x>'+ REPLACE (DepID, ',', '</x><x>')+ '</x>'  AS XML) FROM Tb_SysUser where Isdel=0  and UState=0 ) a OUTER APPLY (SELECT DepIDs= N.v.value ('.', 'varchar(10)') FROM a.DepIDs.nodes ('/x') N( v) ) b where b.DepIDs in (select * from dbo.f_split('" + depid + "',',')) group by UID)union (select TeacherID from Tb_TeacherPlane where ClaID in (select * from dbo.f_split('" + depid + "',','))))";
            else
                sql = "select  cellphone,userid  from Tb_SysUser where UID is not null and UID in ((SELECT  a.UID FROM    (SELECT  UID, DepIDs= CAST( '<x>'+ REPLACE (DepID, ',', '</x><x>')+ '</x>'  AS XML) FROM Tb_SysUser where Isdel=0  and UState=0 ) a OUTER APPLY (SELECT DepIDs= N.v.value ('.', 'varchar(10)') FROM a.DepIDs.nodes ('/x') N( v) ) b where b.DepIDs in (select * from dbo.f_split('" + depid + "',',')) group by UID))";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        public DataTable GetUserID(int type)
        {
            DbParameters.Clear();
            string sql = "select  UserID  from Tb_SysUser where UID in (select UID from Tb_SysUser_Type where SType=" + type + ")";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        public SysUserEntity GetFaceNum(string CardNum)
        {
            DbParameters.Clear();
            lock (locker)
            {
                string sql = "select * from Tb_SysUser where Isdel=0 and FaceNum='" + CardNum + "'";
                if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
                {
                    throw new Exception(DataReturn.SqlMessage);
                }
            }
            return First();
        }

        public static object locker = new object();
        public SysUserEntity GetCardNum(string CardNum)
        {
            lock (locker)
            {
                string sql = "select * from Tb_SysUser where Isdel=0 and CardNum='" + CardNum + "'";
                if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
                {
                    throw new Exception(DataReturn.SqlMessage);
                }
            }

            return First();
        }

        #region 更新状态
        /// <summary>
        /// 更新状态
        ///</summary>
        public int UpdateUState(string ids, int ustate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_UpdateUState";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("ustate", ustate, DatabaseType.SQL_Int, 4));
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

        public string Import(SysUserEntity[] list)
        {
            string resultvalue = "-99";
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = "0";
                    for (int i = 0; i < list.Length; i++)
                    {
                        string result = "0";
                        SysUserEntity model = list[i];
                        if (model != null)
                        {
                            result = AddImport(model);
                            if (result == "-1")
                            {
                                resultvalue = "-1";
                                return resultvalue;
                            }
                            else if (result == "0")
                            {
                            }
                            else
                            {
                                resultvalue = result;
                                return resultvalue;
                            }

                        }
                    }
                    if (resultvalue == "0")
                    {
                        ts.Complete();
                    }
                    else
                    {
                        resultvalue = "-99";
                    }
                }
                catch (Exception ex)
                {
                    resultvalue = "-99";
                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }

        public string AddImport(SysUserEntity model)
        {
            string resultvalue = "0";
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_AddImportDep";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_NVarChar, 100, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("IDCard", model.IDCard, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DepID", model.DepID, DatabaseType.SQL_NVarChar, 100));



            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            resultvalue = DbParameters[0].Value.ToString();
            return resultvalue;
        }

        public DataTable GetNotice()
        {
            DbParameters.Clear();
            string sql = "select  *,dbo.getusername(SendUser)SendUserName  from Tb_SysNotice where IsSendWX =0 and stype=1";//weixin

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

        #region 根据通知信息表未发送消息
        /// <summary>
        /// 根据通知信息表未发送消息
        ///</summary>
        public DataTable GetNoNotice()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysNotice_GetNo";
            DataAccessChannelProtection = true;

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion 



        public int UpdateNotice(string snid)
        {
            DbParameters.Clear();
            string sql = "update Tb_SysNotice set IsSendWX =1 where snid='" + snid + "'";
            DataAccessChannelProtection = true;
            STMessage stmessage = ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION, sql).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }


        #region 根据自定义分组id查询用户信息
        /// <summary>
        /// 根据部门查询用户信息
        ///</summary>
        public DataTable GetSysUserByGroupid(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetTeacherGroupid";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", id.ToString(), DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取DataSet(学生)
        /// <summary>
        ///获取DataSet(学生)

        public DataTable GetStudent()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysUser_GetStudent";

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            // recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        public int Subscribe(int flag, string phone)
        {
            string sql = "update Tb_SysUser set Followed =" + flag + " where CellPhone='" + phone + "'";
            DbParameters.Clear();
            //DbParameters.Clear();
            //ProcedureName = "up_Tb_SysUser_GetTeacherGroupid";
            //DataAccessChannelProtection = true;
            //DbParameters.Add(new DatabaseParameter("DID", id.ToString(), DatabaseType.SQL_NVarChar, 40));
            DataAccessChannelProtection = true;
            STMessage stmessage = ExecuteStoredCommandtext(DataOperationValue.IDU_OPERATION, sql).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }


        public DataTable GetUList(string uid,int isdel ,int ustate) 
        {
            string sql = "select UID ,RealName from tb_SysUser where CellPhone=(select CellPhone from tb_SysUser where UID='" + uid + "') and Isdel=" + isdel + " and UState=" + ustate;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public DataTable List()
        {
            string sql = "select UID ,RealName from tb_SysUser where Isdel=0 and UState=0 and usertype=1 and  CardNum<>''";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }



        #region 根据用户名查询用户是否已存在(新生导入)
        public DataTable GetUserName(string username, int isdel,int usertype)
        {
            string sql = "select UID ,RealName from tb_SysUser where UserName='" + username + "' and Isdel=" + isdel + " and UserType=" + usertype;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #endregion
        #region 根据手机号查询用户是否已存在(新生导入)
        public DataTable GetCellPhone(string cellphone, int isdel, int usertype)
        {
            string sql = "select UID ,RealName from tb_SysUser  CellPhone=='" + cellphone + "' and Isdel=" + isdel + " and UserType=" + usertype;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #endregion
        #region 根据身份证查询用户是否已存在(新生导入)
        public DataTable GetIDCard(string idcard, int isdel, int usertype)
        {
            string sql = "select UID ,RealName from tb_SysUser where IDCard='" + idcard + "' and Isdel=" + isdel + " and UserType=" + usertype;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #endregion


        #region 钉钉免登查询
        public SysUserEntity DDLogin(string name, string mobile, string dd)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Directories_Login";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DDUserID", dd, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("RealName", name, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Mobile", mobile, DatabaseType.SQL_NVarChar, 30));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return First();
        }
        #endregion
        

    }
}
