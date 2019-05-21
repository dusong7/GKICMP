/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2016年11月21日 15时55分53秒
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


namespace GK.GKICMP.DAL
{
    public partial class Egovernment_FlowDAL : DataEntity<Egovernment_FlowEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Egovernment_FlowEntity model, int egstate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Comment", model.Comment, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar));
            DbParameters.Add(new DatabaseParameter("FOpinion", model.FOpinion, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SendDate", model.SendDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AcceptDate", model.AcceptDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("State", model.State, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSendMess", model.IsSendMess, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EGState", egstate, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        public int EditAPP(Egovernment_FlowEntity model, int egstate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_AddAPP";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Comment", model.Comment, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("FOpinion", model.FOpinion, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SendDate", model.SendDate, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("AcceptDate", model.AcceptDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("State", model.State, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRead", model.IsRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSendMess", model.IsSendMess, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EGState", egstate, DatabaseType.SQL_Int, 4));
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
            //ProcedureName = "up_Tb_Egovernment_Flow_DelBat";
            ProcedureName = "up_Tb_Egovernment_DelBatByFID";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
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

        #region 根据主键编号集合更新记录
        /// <summary>
        /// 根据主键编号集合更新记录
        ///</summary>
        public int UpdateBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_UpdateBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
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



        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>q
        /// <returns></returns>
        public Egovernment_FlowEntity GetObjByID(string id)
        {
            string sql = "select * from Tb_Egovernment_Flow where FID='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        public int IsRead(string Fid, string userid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_IsRead";
            DataAccessChannelProtection = true;

            // DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FID", Fid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AcceptUser", userid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        public int Read(string fid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_Read";
            DataAccessChannelProtection = true;

            // DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FID", fid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }

        public int IsReadAPP(string fid, string userid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_IsReadAPP";
            DataAccessChannelProtection = true;

            // DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FID", fid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AcceptUser", userid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Egovernment_FlowEntity model, int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_Paged";

            DbParameters.Add(new DatabaseParameter("ETitle", model.ETitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));


            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("id", id, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
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
        public DataTable GetSendPaged(int pagesize, int pageindex, ref int recordCount, EgovernmentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_SendPaged";

            DbParameters.Add(new DatabaseParameter("ETitle", model.Etitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
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
        public DataTable GetFlow(string fid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_GetFlow";
            DbParameters.Add(new DatabaseParameter("FID", fid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetFlowGD(string eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_GetFlowGD";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetFlowAPP(string fid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_GetFlowAPP";
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
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetTable(string eid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_GetTable";
            DbParameters.Add(new DatabaseParameter("EID", eid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        //#region 根据实体条件分页获取数据集，返回DataSet
        ///// <summary>
        ///// 根据实体条件分页获取数据集，返回DataSet
        ///// </summary>
        ///// <param name="pagesize">每页显示条数</param>
        ///// <param name="pageindex">当前页码,从1开始</param>
        ///// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        ///// <param name="model">条件实体</param>
        //public DataTable GetFJX(int pagesize, int pageindex, ref int recordCount, Egovernment_FlowEntity model)
        //{
        //    DbParameters.Clear();
        //    ProcedureName = "up_Tb_Egovernment_Flow_SJX";
        //    DbParameters.Add(new DatabaseParameter("ETitle", model.ETitle, DatabaseType.SQL_NVarChar, 100));
        //    DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
        //    DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));


        //    DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
        //    DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 100));

        //    if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    recordCount = Convert.ToInt32(DbParameters[5].Value);
        //    return DataReflectionContainer;
        //}
        //#endregion

        #region 查询所有的政务
        /// <summary>
        /// 查询所有的政务
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetALLPaged(int pagesize, int pageindex, ref int recordCount, EgovernmentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_ALLPaged";

            DbParameters.Add(new DatabaseParameter("ETitle", model.Etitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 手机端电子政务
        /// <summary>
        /// 手机端电子政务
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedAPP(int pagesize, int pageindex, ref int recordCount, Egovernment_FlowEntity model, int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_PagedAPP";

            DbParameters.Add(new DatabaseParameter("ETitle", model.ETitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));


            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("id", id, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 手机端电子政务
        /// <summary>
        /// 手机端电子政务   1待处理2已发
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPagedAPPByFlag(int pagesize, int pageindex, ref int recordCount, Egovernment_FlowEntity model, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Egovernment_Flow_PagedAPPByFlag";

            DbParameters.Add(new DatabaseParameter("ETitle", model.ETitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Begin", model.Begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("End", model.End, DatabaseType.SQL_DateTime, 20));


            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("flag", flag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[5].Value);
            return DataReflectionContainer;
        }
        #endregion



        public DataTable GetNoReadList() 
        {
            string sql = "select UserID,b.CellPhone,COUNT(*) from Tb_Egovernment_Flow a  inner join Tb_SysUser b on a.AcceptUser=b.UID  where IsRead=0 group by UserID ,CellPhone";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }

}
