/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月04日 09时01分37秒
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
    public partial class BuildApplyDAL : DataEntity<BuildApplyEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(BuildApplyEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BuildApply_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("BAID", model.BAID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ProName", model.ProName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ApplyDep", model.ApplyDep, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("ApplyDate", model.ApplyDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("BuildContent", model.BuildContent, DatabaseType.SQL_Text, 16));

            DbParameters.Add(new DatabaseParameter("Acreage", model.Acreage, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("Layers", model.Layers, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BudgetAmount", model.BudgetAmount, DatabaseType.SQL_Decimal, 9));




            DbParameters.Add(new DatabaseParameter("Structure", model.Structure, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BuildNature", model.BuildNature, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BSources", model.BSources, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("BuildAddr", model.BuildAddr, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DutyNO", model.DutyNO, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DepUser", model.DepUser, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DepNO", model.DepNO, DatabaseType.SQL_NVarChar, 50));

            DbParameters.Add(new DatabaseParameter("BuildReason", model.BuildReason, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("Arrangement", model.Arrangement, DatabaseType.SQL_Text, 16));

            //DbParameters.Add(new DatabaseParameter("ApplyUser", model.ApplyUser, DatabaseType.SQL_NVarChar, 50));
            //DbParameters.Add(new DatabaseParameter("BDesc", model.BDesc, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("AState", model.AState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsReport", model.IsReport, DatabaseType.SQL_Int, 4));

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
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BuildApply_Update";
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

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BuildApply_DelBat";
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
        public BuildApplyEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_BuildApply where BAID='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 获取基建项目审核状态为未通过的项目
        /// <summary>
        /// 获取基建项目审核状态为未通过的项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetObjByState(int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BuildApply_GetByState";

            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, BuildApplyEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BuildApply_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("ProName", model.ProName, DatabaseType.SQL_NVarChar, 500));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 更新基建项目的审核状态
        /// <summary>
        /// 更新基建项目的审核状态
        ///</summary>
        public int JZUpdate(List<BuildApplyEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (BuildApplyEntity emodel in list)
                    {
                        int result = 0;
                        BuildApplyEntity model = emodel;  // 如果PID在校平台不存在，在更新操作后返回-1
                        if (model != null)
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

        public int UpdateToState(BuildApplyEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BuildApply_JJUpdate";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("BAID", model.BAID, DatabaseType.SQL_NVarChar, 40));
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

