/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月12日 10点49分
** 描   述:      打卡实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
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
    public partial class AttendRecordDAL : DataEntity<AttendRecordEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Add(AttendRecordEntity model)
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_Edit";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ARID", model.ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserNum", model.UserNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("MachineCode", model.MachineCode, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("RecordDate", model.RecordDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AttendType", model.AttendType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsAnalysis", model.IsAnalysis, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AttendDesc", model.AttendDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("OutType", model.OutType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AttImg", model.AttImg, DatabaseType.SQL_NVarChar, 500));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value);

            sw.Stop();

            TimeSpan ts2 = sw.Elapsed;
            double time = ts2.TotalMilliseconds;
            return result;
        }
        #endregion

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(AttendRecordEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ARID", model.ARID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserNum", model.UserNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("MachineCode", model.MachineCode, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("RecordDate", model.RecordDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AttendType", model.AttendType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsAnalysis", model.IsAnalysis, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AttendDesc", model.AttendDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("OutType", model.OutType, DatabaseType.SQL_Int, 4));


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

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
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
        public AttendRecordEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getusername(UserNum) UserName from Tb_AttendRecord where ARID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, AttendRecordEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AttendType", model.AttendType, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("MachineCode", model.MachineCode, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserNum", model.UserNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("UserNumName", model.UserName, DatabaseType.SQL_NVarChar, 40));

            DbParameters.Add(new DatabaseParameter("IsAnalysis", model.IsAnalysis, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 考勤信息导入
        /// <summary>
        /// 学生信息导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Import(AttendRecordEntity[] list)
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
                        AttendRecordEntity model = list[i];
                        result = Edit(model);
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
        #endregion


        public DataTable GetList()
        {
            string sql = "select * from Tb_AttendMachine";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetList(string begin,string end,string uid)
        {
            string sql = "select * from Tb_AttendRecord where RecordDate between '" + begin + " 00:00:01' and '" + end + " 23:01:59' and  (UserNum='" + uid + "' or '" + uid + "'='') order by UserNum, RecordDate desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>up_Tb_Asset_Account_Analysis
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable Analysis(int pagesize, int pageindex, ref int recordCount, AttendRecordEntity model, int type, string depid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Asset_Account_Analysis";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 40));

            DbParameters.Add(new DatabaseParameter("DepID", depid, DatabaseType.SQL_NVarChar, 50));

            DbParameters.Add(new DatabaseParameter("UserType", type, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 获取打卡记录信息
        /// <summary>
        /// 获取打卡记录信息
        /// </summary>
        /// <param name="begindate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public DataTable GetRecordList(DateTime begindate, DateTime enddate, DateTime mbegin, DateTime mend)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_GetRecord";

            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("MBegin", mbegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("MEnd", mend, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("UserNum", usernum, DatabaseType.SQL_NVarChar, 50));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 修改打卡记录分析结果
        /// <summary>
        /// 修改打卡记录分析结果
        /// </summary>
        /// <param name="arid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateAnalysis(DateTime mbegin, DateTime mend, DateTime begindate, DateTime enddate, int atype)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_Update";
            DataAccessChannelProtection = true;
            //DbParameters.Add(new DatabaseParameter("ARID", arid, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("IsAnalysis", state, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MBegin", mbegin, DatabaseType.SQL_DateTime, 4));
            DbParameters.Add(new DatabaseParameter("MEnd", mend, DatabaseType.SQL_DateTime, 4));
            DbParameters.Add(new DatabaseParameter("BeginDate", begindate, DatabaseType.SQL_DateTime, 4));
            DbParameters.Add(new DatabaseParameter("EndDate", enddate, DatabaseType.SQL_DateTime, 4));
            DbParameters.Add(new DatabaseParameter("AType", atype, DatabaseType.SQL_Int, 4));

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


        #region 获取打卡记录表中的人员信息(即使只有一条打卡记录未分析也会显示)
        /// <summary>
        /// 获取打卡记录表中的人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserNum()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_GetUserNum";

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        public DataTable Abnormal(DateTime mbegin, DateTime mend, int outtype)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_Abnormal";
            DbParameters.Add(new DatabaseParameter("MBegin", mbegin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("MEnd", mend, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("OutType", outtype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

        public DataTable AbnormalStatistics(int pagesize, int pageindex, DateTime mbegin, DateTime mend, int outtype, string asid, ref int recordCount)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_AbnormalStatistics";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MBegin", mbegin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("MEnd", mend, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("OutType", outtype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ASID", asid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }


        #region 根据TID查询分析结果为迟到的考勤时间
        /// <summary>
        /// 根据TID查询分析结果为迟到的考勤时间
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedSelect(int pagesize, int pageindex, ref int recordCount, string usernum, int isasync, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_PagedSelect";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("UserNum", usernum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("IsAnalysis", isasync, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion



        public DataTable PagedByuid(string uid, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_PagedBy";
            DbParameters.Add(new DatabaseParameter("uid", uid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }


        public DataTable GetTableByUid(string uid, int year, int month,string dep)
        {
            string sql = "select COUNT(IsAnalysis) counts,IsAnalysis from Tb_AttendRecord where  UserNum='" + uid + "' and year( RecordDate)=" + year + " and MONTH(RecordDate)="+month+" and ('" + dep + "' in (select col from f_split( 'DepID',',')) or '" + dep + "'='-2')  and IsAnalysis in(select AType from Tb_AttendSet where isuse=1 and AType<>372)  group by IsAnalysis";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 手机端考勤统计
        /// <summary>
        /// 手机端考勤统计
        /// </summary>up_Tb_Asset_Account_Analysis
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable AnalysisCounts(int pagesize, int pageindex, ref int recordCount, AttendRecordEntity model, int type)
        {
            DbParameters.Clear();
            //ProcedureName = "up_Tb_AttendRecord_AnalysisCounts";
            ProcedureName = "up_Tb_Leave_Analysis";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UserType", type, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("DepID", depid, DatabaseType.SQL_NVarChar, 50));
           
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端考勤详细页面
        /// <summary>
        /// 手机端考勤详细页面
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable AnalysisDetails(int pagesize, int pageindex, ref int recordCount, AttendRecordEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendRecord_DetailsAPP";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("UserType", type, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        public DataTable DakaRenshuTongJi(string time)
        {
            //string sql = "select RealName,(select count(*) from tb_SysUser where Isdel=0 and UState=0 and usertype=1 and  CardNum<>'')zongrenshu from tb_SysUser where Isdel=0 and UState=0 and usertype=1 and  CardNum<>'' and uid not in (select UserNum from Tb_AttendRecord where RecordDate between '" + time + " 00:00:00' and '" + time + " 20:00:00' group by UserNum) ";
            string sql = "select RealName,(select count(*) from tb_SysUser where Isdel=0 and UState=0 and usertype=1 and  CardNum<>'' and UID not in (select LeaveUser from Tb_Leave where CONVERT(nvarchar(20), BeginDate,23)<='" + time + "' and CONVERT(nvarchar(20), EndDate,23)>='" + time + "' and isdel=0 ) )zongrenshu from tb_SysUser  where Isdel=0 and UState=0 and usertype=1 and  CardNum<>'' and uid not in (select UserNum from Tb_AttendRecord    where RecordDate between '" + time + " 00:00:00' and '" + time + " 20:00:00' group by UserNum  union   select LeaveUser from Tb_Leave where   CONVERT(nvarchar(20), BeginDate,23)<='" + time + "' and CONVERT(nvarchar(20), EndDate,23)>='" + time + "' and isdel=0 ) ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable DakaChiDao(string time)
        {
            string sql = "SELECT  dbo.getUserName(UserNum)RealName ,value = ( STUFF(( SELECT    ',' + CONVERT(nvarchar(20), RecordDate,20) FROM Tb_AttendRecord  WHERE UserNum = Test.UserNum and RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00' and IsAnalysis=373 FOR XML PATH('') ), 1, 1, '') ),(select count(*)from (select UserNum from Tb_AttendRecord where RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00' and IsAnalysis=373 group by UserNum)a)zongrenshu FROM tb_AttendRecord AS Test where RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00' and IsAnalysis=373 GROUP BY UserNum";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable DakaZaoTui(string time)
        {
            string sql = "SELECT  dbo.getUserName(UserNum)RealName ,value = ( STUFF(( SELECT    ',' + CONVERT(nvarchar(20), RecordDate,20) FROM Tb_AttendRecord  WHERE UserNum = Test.UserNum and RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00' and IsAnalysis=374 FOR XML PATH('') ), 1, 1, '') ),(select count(*)from (select UserNum from Tb_AttendRecord where RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00' and IsAnalysis=374 group by UserNum)a)zongrenshu FROM tb_AttendRecord AS Test where RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00' and IsAnalysis=374 GROUP BY UserNum";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public DataTable DakaQingJia(string time)
        {
            //string sql = " select  dbo.getUserName(LeaveUser)RealName,BeginDate,EndDate,LFlag,LeaveDays from Tb_Leave where CONVERT(nvarchar(20), BeginDate,23)<='" + time + "' and CONVERT(nvarchar(20), EndDate,23)>='" + time + "' and LeaveState=2 ";
            string sql = " select  dbo.getUserName(LeaveUser)RealName,BeginDate,EndDate,LFlag,LeaveDays,dbo.getBaseDataNameByDcode(CAST( LType as nvarchar)) LTypeName from Tb_Leave where CONVERT(nvarchar(20), BeginDate,23)<='" + time + "' and CONVERT(nvarchar(20), EndDate,23)>='" + time + "' and isdel=0 order by ltype  desc ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public DataTable DakaQueKa(string time)
        {
            //string sql = "select dbo.getUserName(UserNum)RealName,* from Tb_AttendRecord    where RecordDate between '" + time + " 00:00:00' and '" + time + " 20:00:00' ";
            string sql = "SELECT  dbo.getUserName(UserNum)RealName ,value = ( STUFF(( SELECT    ',' + CONVERT(nvarchar(20), RecordDate,20) FROM Tb_AttendRecord  WHERE UserNum = Test.UserNum and RecordDate  between '" + time + " 00:00:00' and '" + time + " 20:00:00'  FOR XML PATH('') ), 1, 1, '') ) FROM tb_AttendRecord AS Test where RecordDate  between '" + time + " 00:00:00' and '" + time + " 23:00:00' and UserNum not in (select LeaveUser from Tb_Leave where LeaveDate between '" + time + " 00:00:00' and '" + time + " 23:00:00' ) GROUP BY UserNum";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }
}
