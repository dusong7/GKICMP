﻿/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月26日 10时02分34秒
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
    public partial class Web_MenuDAL : DataEntity<Web_MenuEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Web_MenuEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Menu_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("MID", model.MID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MName", model.MName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("MOrder", model.MOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MType", model.MType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MContent", model.MContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("ImageUrl", model.ImageUrl, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("LinkUrl", model.LinkUrl, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("MenuTitle", model.MenuTitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("MKeyWords", model.MKeyWords, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("MDescription", model.MDescription, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EngName", model.EngName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("MNanner", model.MNanner, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("MenuTemplate", model.MenuTemplate, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("DetailTemplate", model.DetailTemplate, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsOpen", model.IsOpen, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsComment", model.IsComment, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsCommentAudit", model.IsCommentAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsNavigation", model.IsNavigation, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsAudit", model.IsAudit, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PublishRoles", model.PublishRoles, DatabaseType.SQL_NVarChar, 500));
            // DbParameters.Add(new DatabaseParameter("PreStr", model.PreStr, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));

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
            ProcedureName = "up_Tb_Web_Menu_DelBat";
            DataAccessChannelProtection = true;
            int result = 0;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public Web_MenuEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_Web_Menu where MID=" + id;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Web_MenuEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_News_Paged";
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
        #region 根据条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetTable(int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Menu_GetTable";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion
        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public DataTable GetTable(string pid, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Menu_GetList";
            DbParameters.Add(new DatabaseParameter("PID", pid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }

}

