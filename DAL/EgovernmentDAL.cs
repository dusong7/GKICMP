/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2016年11月21日 15时54分29秒
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
    public partial class EgovernmentDAL : DataEntity<EgovernmentEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(EgovernmentEntity model, Egovernment_FlowEntity model_flow, int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ID", id, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Etitle", model.Etitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Ecode", model.Ecode, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EKey", model.EKey, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EDepartment", model.EDepartment, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EtitleType", model.EtitleType, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EContent", model.EContent, DatabaseType.SQL_Text, 2000000));
            DbParameters.Add(new DatabaseParameter("Opened", model.Opened, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Completed", model.Completed, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsApproved", model.IsApproved, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Etype", model.Etype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Estate", model.Estate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSave", model.IsSave, DatabaseType.SQL_Int, 4));//增加保存或提交状态
            DbParameters.Add(new DatabaseParameter("IsSuperior", model.IsSuperior, DatabaseType.SQL_Int, 4));//增加是否上级公文状态

            DbParameters.Add(new DatabaseParameter("Comment", model_flow.Comment, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("IsSendMess", model_flow.IsSendMess, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model_flow.AcceptUser, DatabaseType.SQL_NVarChar));
            DbParameters.Add(new DatabaseParameter("State", model_flow.State, DatabaseType.SQL_Int, 8));
            DbParameters.Add(new DatabaseParameter("IsRead", model_flow.IsRead, DatabaseType.SQL_Int, 4));
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

        public int ReceiveOA(List<EgovernmentEntity> list)
        {
            int resultvalue = -99;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = 0;
                    foreach (EgovernmentEntity emodel in list)
                    {
                        int result = 0;
                        EgovernmentEntity model = emodel;
                        if (model != null)
                        {
                            result = ImportEdit(model);
                            if (result == -1)
                            {
                                resultvalue = -1;
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
        public int ImportEdit(EgovernmentEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Receive";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Etitle", model.Etitle, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Ecode", model.Ecode, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EKey", model.EKey, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EDepartment", model.EDepartment, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EtitleType", model.EtitleType, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EContent", model.EContent, DatabaseType.SQL_Text, 2000000));
            DbParameters.Add(new DatabaseParameter("Opened", model.Opened, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Completed", model.Completed, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsApproved", model.IsApproved, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Etype", model.Etype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Estate", model.Estate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSave", model.IsSave, DatabaseType.SQL_Int, 4));//增加保存或提交状态
            DbParameters.Add(new DatabaseParameter("IsSuperior", model.IsSuperior, DatabaseType.SQL_Int, 4));//增加保存或提交状态
            //DbParameters.Add(new DatabaseParameter("Comment", model_flow.Comment, DatabaseType.SQL_NVarChar, 200));
            //DbParameters.Add(new DatabaseParameter("IsSendMess", model_flow.IsSendMess, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("AcceptUser", model_flow.AcceptUser, DatabaseType.SQL_NVarChar, 2000));
            //DbParameters.Add(new DatabaseParameter("State", model_flow.State, DatabaseType.SQL_Int, 8));
            //DbParameters.Add(new DatabaseParameter("IsRead", model_flow.IsRead, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
        public EgovernmentEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_Egovernment where EID='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
        #region 根据主键编号归档
        /// <summary>
        /// 根据主键编号归档
        ///</summary>
        public int GD(string fid, string etype,string userid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Update";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("FID", fid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EType", etype, DatabaseType.SQL_NVarChar, 20));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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
        public DataTable GDList(int pagesize, int pageindex, ref int recordCount, EgovernmentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_GDList";
            DbParameters.Add(new DatabaseParameter("ETitle", model.Etitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("EType", model.Etype, DatabaseType.SQL_Int, 4));

            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[6].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据FID获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetTable(string Fid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_GetTable";
            DbParameters.Add(new DatabaseParameter("FID", Fid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Eid"></param>
        /// <returns></returns>
        public DataTable GetTableGD(string Eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_GetTableGD";
            DbParameters.Add(new DatabaseParameter("EID", Eid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetTableAPP(string fid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_GetTableAPP";
            DbParameters.Add(new DatabaseParameter("FID", fid, DatabaseType.SQL_NVarChar, 40));

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
        /// </summary>GetFlow
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, EgovernmentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Paged";
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


        #region 网页爬虫-判断已存在的数据就不执行插入操作
        public int GetToEID(string ti, DateTime ne)
        {
            int id = -1;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_GetEID";
            DbParameters.Add(new DatabaseParameter("Title", ti, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("NewDate", ne, DatabaseType.SQL_DateTime, 8));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = Convert.ToInt32(dv.Table.Rows[0]["EID"].ToString());
            }
            return id;
        }
        #endregion
    }

}

