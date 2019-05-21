/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年04月26日 16时30分45秒
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
using System.Transactions;


namespace GK.GKICMP.DAL
{
    public partial class JZProjectManageDAL : DataEntity<JZProjectManageEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(JZProjectManageEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_JZProjectManage_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ProName", model.ProName, DatabaseType.SQL_NVarChar, 100));
            // DbParameters.Add(new DatabaseParameter("ProCode", model.ProCode, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("ProBudget", model.ProBudget, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Financed", model.Financed, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProArea", model.ProArea, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("DepPerson", model.DepPerson, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DepLinkno", model.DepLinkno, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("Amount", model.Amount, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProType", model.ProType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProContent", model.ProContent, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("State", model.State, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProDate", model.ProDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("ChangeDate", model.ChangeDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("ChangeUser", model.ChangeUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("BuildAddr", model.BuildAddr, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ProDesc", model.ProDesc, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Type", model.Type, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PType", model.PType, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("PCFile", model.PCFile, DatabaseType.SQL_NVarChar, 500));

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
            ProcedureName = "up_Tb_JZProjectManage_DelBat";
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
        public JZProjectManageEntity GetObjByID(string id)
        {
            string sql = "SELECT *,dbo.getData1Name(ProType) as ProTypeName,dbo.getData1Name(ProContent) as ProContentName FROM [Tb_JZProjectManage] WHERE [PID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }

        #endregion

        #region 获取教装项目审核状态为未通过的项目
        /// <summary>
        /// 获取教装项目审核状态为未通过的项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetObjByState()
        {
            string sql = "select * from Tb_JZProjectManage where year(ProDate)>( YEAR(GETDATE())-1 ) and State=1";
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
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_JZProjectManage_Update";
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

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, JZProjectManageEntity model, DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_JZProjectManage_Paged";
            DbParameters.Add(new DatabaseParameter("ProName", model.ProName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Financed", model.Financed, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ProType", model.ProType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("State", model.State, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[3].Value);
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
        public DataTable GetPagedByImprot(int pagesize, int pageindex, ref int recordCount, JZProjectManageEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_JZProjectManage_PagedByImprot";
            DbParameters.Add(new DatabaseParameter("ProName", model.ProName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[3].Value);
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
        public DataTable GetList(int isdel)
        {
            string sql = "select * from Tb_JZProjectManage where State=2   and Isdel=" + isdel;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 获取没验收的项目名称
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetListByIsCheck(int isdel)
        {
            string sql = "select * from Tb_JZProjectManage where State=2 and Isdel=" + isdel + " and IsChecked =0";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        public DataTable GetTable(string pid)
        {
            string sql = "select * from Tb_JZProjectManage where Isdel=0 and PID ='" + pid + "'";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
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
        public DataTable GetProList()
        {
            string sql = "select * from vw_Tb_Project_All order by type desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 更新教装项目的审核状态
        /// <summary>
        /// 更新教装项目的审核状态
        ///</summary>
        public int JZUpdate(List<JZProjectManageEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (JZProjectManageEntity emodel in list)
                    {
                        int result = 0;
                        JZProjectManageEntity model = emodel;  // 如果PID在校平台不存在，在更新操作后返回-1
                        if (model != null) ;
                        {
                            result = UpdateToState(model);
                            if (result <= -2)
                            {
                                resultvalue = -2;
                                // return resultvalue;
                            }
                            else
                            {
                                resultvalue = 2; //表示 更新 成功
                                //return resultvalue;
                            }
                        }
                    }

                    if (resultvalue == 2)
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

        public int UpdateToState(JZProjectManageEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_JZProjectManage_JZUpdate";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("ProName", model.ProName, DatabaseType.SQL_NVarChar, 100));
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
    }
}

