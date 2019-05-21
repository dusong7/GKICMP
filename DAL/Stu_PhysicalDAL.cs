/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月16日 08时09分40秒
** 描    述:      学生体质健康的基本操作类
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
    public partial class Stu_PhysicalDAL : DataEntity<Stu_PhysicalEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Stu_PhysicalEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Stu_Physical_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("SPID", model.SPID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("StuID", model.StuID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("StuWeight", model.StuWeight, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("StuHeight", model.StuHeight, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Bust", model.Bust, DatabaseType.SQL_Decimal, 9));

            DbParameters.Add(new DatabaseParameter("LVision", model.LVision, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("RVision", model.RVision, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Lhearing", model.Lhearing, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Rhearing", model.Rhearing, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Vitalcapacity", model.Vitalcapacity, DatabaseType.SQL_Decimal, 9));

            DbParameters.Add(new DatabaseParameter("DentalCaries", model.DentalCaries, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Term", model.Term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));


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
            ProcedureName = "up_Tb_Stu_Physical_DelBat";
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
        public Stu_PhysicalEntity GetObjByID(string id)
        {
            string sql = "select *,dbo.getUserName(StuID) as RealName from Tb_Stu_Physical where SPID='" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Stu_PhysicalEntity model,int type)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Stu_Physical_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));


            DbParameters.Add(new DatabaseParameter("StuID", model.StuID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EYear", model.EYear, DatabaseType.SQL_NVarChar, 30));

            DbParameters.Add(new DatabaseParameter("type", type, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据学年学期导出学生身体状况信息到报告单
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetStu(string year, int term, int did)
        {
            string sql = "select * from Tb_Stu_Physical where EYear='" + year + "' and Term=" + term + " and dbo.getDepByTID(stuid)="+did+" order by stuid desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据学年学期等级(平时 期终 综合 )  导出学生身体状况信息到报告单
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetToCountStu(string year, int term, int did,int ps,int qz,int zh)
        {
            string sql = "select *  from dbo.Vw_Exam_Score a inner join Tb_Exam b on a.EID =b.EID where b.EYear='" + year + "' and b.Term=" + term + " and dbo.getDepByTID(a.stid)=" + did + " order by stid desc";
            //string sql = "select * from Tb_Stu_Physical where EYear='" + year + "' and Term=" + term + " and dbo.getDepByTID(stuid)=" + did +  " and EID="+ ps + " order by stuid desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据学年学期等级(平时 期终 综合 )  导出学生身体状况信息到报告单
        /// <summary>
        /// 根据学年学期等级(平时 期终 综合 )  导出学生身体状况信息到报告单
        /// </summary>
        /// <returns></returns>
        public DataTable GetToStu(string year, int term, int did, int ps, int qz, int zh)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Exam_GetStuScore";

            DbParameters.Add(new DatabaseParameter("EYear", year, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Term", term, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PS", ps, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("QZ", qz, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ZH", zh, DatabaseType.SQL_Int, 4));
           

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #endregion

        #region 体质健康信息导入
        /// <summary>
        /// 体质健康信息导入
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Import(Stu_PhysicalEntity[] list)
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
                        Stu_PhysicalEntity model = list[i];
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
    }
}
