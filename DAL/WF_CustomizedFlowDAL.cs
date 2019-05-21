/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      袁纪坤
** 创建日期:      2017年11月09日 09时48分24秒
** 描    述:      自由流审核传递类
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
    public partial class WF_CustomizedFlowDAL : DataEntity<WF_CustomizedFlowEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(WF_CustomizedFlowEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_CustomizedFlow_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CFID", model.CFID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UID", model.UID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FAID", model.FAID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CStauts", model.CStauts, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Remark", model.Remark, DatabaseType.SQL_Text, 1000));
            DbParameters.Add(new DatabaseParameter("AuditDate", model.AuditDate, DatabaseType.SQL_DateTime, 4));
            DbParameters.Add(new DatabaseParameter("FAVID", model.FAVID, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            try
            {
                result = Convert.ToInt32(stmessage.DataRecords.Tables[0].Rows[0]["FAVID"]);
            }
            catch
            {
                result = -1;
            }
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
        public DataTable GetUserPagedList(int pagesize, int pageindex, ref int recordCount, string uid = "", int cstauts = -1)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_CustomizedFlowUser_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("UID", uid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CStauts", cstauts, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 修改审核状态（type=1 修改对应uid type=2 修改除uid以外）
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Set(string cid, string uid, int faid, int cstate, string remark, int type)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_CustomizedFlow_Set";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("UID", uid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FAID", faid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CStauts", cstate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Type", type, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Remark", remark, DatabaseType.SQL_Text, 1000));
            DbParameters.Add(new DatabaseParameter("AuditDate", DateTime.Now, DatabaseType.SQL_DateTime, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return result;
        }
        #endregion



        #region 根据删除记录
        /// <summary>
        /// 根据CID删除记录
        ///</summary>
        public int Delete(string cid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_CustomizedFlow_Delete";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_NVarChar, 40));
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
        public WF_CustomizedFlowEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_WF_CustomizedFlow where [CFID]='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public WF_CustomizedFlowEntity GetObjByID(string cid, int faid, string uid = "", int cstate = 99)
        {
            string sql = "select * from Tb_WF_CustomizedFlow where [CID]='" + cid + "' and [FAID]='" + faid + "'";
            if (!string.IsNullOrEmpty(uid))
            {
                sql = sql + " and [UID]='" + uid + "'";
            }
            if (cstate != 99)
            {
                sql = sql + " and [CStauts]='" + cstate + "'";
            }
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 获取数据集，返回DataSet
        /// <summary>
        /// 获取数据集，返回DataSet
        /// </summar

        public DataTable GetTable(string cid, int faid = 0)
        {
            string sql = "select * from Tb_WF_CustomizedFlow where [CID]='" + cid + "'";
            if (faid != 0)
            {
                sql = sql + " and [FAID]='" + faid + "'";
            }
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取数据集，返回DataSet
        /// <summary>
        /// 获取数据集，返回DataSet
        /// </summar

        public DataTable GetUserTable(string uid, int cstauts)
        {
            string sql = "select *,dbo.getUserName(b.CreateUser) as 'UserName' from [Tb_WF_CustomizedFlow] a,[Tb_WF_Customized] b,[Tb_WF_Form] c where a.CID=b.CID and c.WFFID=b.WFFID and a.[UID]='" + uid + "' and a.[CStauts]='" + cstauts + "' order by b.CreateDate desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

    }


}
