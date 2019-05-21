/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月18日 11时04分07秒
** 描    述:      邮件的基本操作类
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
    public partial class EmailDAL : DataEntity<EmailEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(EmailEntity model, int isadd)
        {
            //int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_Add";
            DataAccessChannelProtection = true;
            //DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Isadd", isadd, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EmailContent", model.EmailContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("EmailTitle", model.EmailTitle, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 4000));
            DbParameters.Add(new DatabaseParameter("IsSubmit", model.IsSubmit, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            //result = Convert.ToInt32(DbParameters[0].Value);
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
            ProcedureName = "up_Tb_Email_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("isdel", isdel, DatabaseType.SQL_Int, 4));
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


        #region 根据主键编号集合删除记录()
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int Delete(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_User_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("isdel", isdel, DatabaseType.SQL_Int, 4));
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
        public EmailEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_Get";
            DbParameters.Add(new DatabaseParameter("EID", id, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
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
        public DataTable GetObj(string id, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_GetByFlag";
            DbParameters.Add(new DatabaseParameter("EID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, EmailEntity model, DateTime begin, DateTime end, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EmailTitle", model.EmailTitle, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("BeginDate", begin, DatabaseType.SQL_DateTime, 18));
            DbParameters.Add(new DatabaseParameter("EndDate", end, DatabaseType.SQL_DateTime, 18));
            DbParameters.Add(new DatabaseParameter("EType", model.EType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SendUser", model.SendUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 更改已读状态
        /// <summary>
        /// 更改已读状态
        ///</summary>
        public int Update(string id, int isread, DateTime AcceptDate)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_User_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("EUID", id, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("IsRead", isread, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AcceptDate", AcceptDate, DatabaseType.SQL_DateTime, 18));
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
        public EmailEntity GetObjByEUID(string id)
        {
            string sql = "SELECT a.*,b.*,dbo.getUserName(a.AcceptUser) AcceptName,dbo.getUserName (b.SendUser) SendUserName FROM [Tb_Email_User] a inner join Tb_Email b on a.EID =b.EID WHERE [EUID] ='" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Add(EmailEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_User_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("EID", model.EID, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("AcceptUser", model.AcceptUser, DatabaseType.SQL_NVarChar, 4000));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            result = Convert.ToInt32(DbParameters[0].Value);
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return result;
        }
        #endregion


        #region 更新提交
        /// <summary>
        /// 更新提交
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="issubmit"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public int UpdateSubmit(string ids, int issubmit, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Email_User_Submit";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("IsSubmit", issubmit, DatabaseType.SQL_Int, 4));
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
    }
}
