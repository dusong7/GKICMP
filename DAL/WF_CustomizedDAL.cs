/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      袁纪坤
** 创建日期:      2017年11月09日 09时48分24秒
** 描    述:      自由流审核实体类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;


namespace GK.GKICMP.DAL
{
    public partial class WF_CustomizedDAL : DataEntity<WF_CustomizedEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public string Edit(WF_CustomizedEntity model)
        {
            string result = "";
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_Customized_Add";
            DataAccessChannelProtection = true;
            //DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("WFFID", model.WFFID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CState", model.CState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FAID", model.FAID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LastDate", model.LastDate, DatabaseType.SQL_DateTime, 4));


            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            try
            {
                result = stmessage.DataRecords.Tables[0].Rows[0]["CID"].ToString();
            }
            catch
            {
                if (stmessage.SqlMessage == "muti")
                    result = "自由流名称重复";
            }

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
        public WF_CustomizedEntity GetObjByID(string cid)
        {
            string sql = String.Format("select * from Tb_WF_Customized where [CID]='{0}' ", cid);
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
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, string uid = "", string wffid = "")
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_Customized_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CreateUser", uid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("WFFID", wffid, DatabaseType.SQL_NVarChar, 40));

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
        public DataTable GetSendPagedList(int pagesize, int pageindex, ref int recordCount, string uid = "")
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_CustomizedSend_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("URID", uid, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion
        

        #region 获取数据集，返回DataSet
        /// <summary>
        /// 获取数据集，返回DataSet
        /// </summar

        public DataTable GetTable(string uid = "", string wffid = "")
        {
            string sql = "select a.*,b.FormName from [Tb_WF_Customized] a,[Tb_WF_Form] b where a.WFFID=b.WFFID ";
            if (!string.IsNullOrEmpty(uid))
            {
                sql = sql + " and a.[CreateUser]='" + uid + "' ";
            }
            if (!string.IsNullOrEmpty(wffid))
            {
                sql = sql + " and a.wffid='" + wffid + "' ";
            }
            sql = sql + " order by [CreateDate] desc";

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

        public DataTable GetSendTable(string uid)
        {
            string sql = "select *,dbo.getUserName(a.CreateUser) as 'CreateUserName' from [Tb_WF_Customized] a,[Tb_WF_FormAuditValue] b,[Tb_WF_Form] c where a.WFFID=b.WFFID and a.WFFID=c.WFFID and b.FAVType=2 and b.URID='" + uid + "' ";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


    }


}
