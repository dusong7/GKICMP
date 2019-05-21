/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      袁纪坤
** 创建日期:      2017年06月09日 09时48分24秒
** 描    述:      自由流表单实体类
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
    public partial class WF_FormDAL : DataEntity<WF_FormEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public string Edit(WF_FormEntity model)
        {
            string result = "";
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_Form_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("WFFID", model.WFFID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("FormName", model.FormName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsEnable", model.IsEnable, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSetAuditor", model.IsSetAuditor, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));


            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            try
            {
                if (stmessage.SqlMessage == "muti")
                {
                    result = "自由流名称重复";
                }
                else
                {
                    result = stmessage.DataRecords.Tables[0].Rows[0]["WFFID"].ToString();
                }
            }
            catch
            {

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
        public WF_FormEntity GetObjByID(string id)
        {
            string sql = String.Format("select * from Tb_WF_Form where [Isdel]=0 and [WFFID]='{0}'", id);
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
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, int issetauditor,int isenable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_Form_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("IsSetAuditor", issetauditor, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsEnable", isenable, DatabaseType.SQL_Int, 4));
            
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

        public DataTable GetTable(bool issetauditor = false)
        {
            string sql = " select *,dbo.getFormUserCount(WFFID) as 'UserCount',dbo.getUserName(CreateUser) as CreateUserName from [Tb_WF_Form] where Isdel=0 and IsEnable=1 ";
            if (issetauditor)
            {
                sql = sql + " and IsSetAuditor=1 ";
            }
            sql = sql + " order by CreateDate desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 删除事件
        public int Deleted(string id, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_Form_Delete";

            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("WFFID", id, DatabaseType.SQL_NVarChar, 40));
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


        #region 禁用启用事件
        public int IsEnable(string id, int isenable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_WF_Form_IsEnable";

            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("WFFID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsEnable", isenable, DatabaseType.SQL_Int, 4));

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
