/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年03月02日 11时03分41秒
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
    public partial class SysRoleDAL : DataEntity<SysRoleEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SysRoleEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_Add";
            DataAccessChannelProtection = true;
           
            DbParameters.Add(new DatabaseParameter("RoleID", model.RoleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RoleName", model.RoleName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("RoleDesc", model.RoleDesc, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("RoleType", model.RoleType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AppRole", model.AppRole, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = Convert.ToInt32(DbParameters[6].Value);
            return result;
        }
        #endregion

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        { 
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_DelBat";
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
      
        public SysRoleEntity GetObjByID(int id)
        {
            string sql = "SELECT * FROM [Tb_SysRole]  WHERE   [RoleID] =" + id;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SysRoleEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_Paged";
            DbParameters.Add(new DatabaseParameter("RoleName", model.RoleName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("RoleType", model.RoleType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[4].Value);
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
        public DataTable GetTable(int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_GetTable";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据编号（主键）返回表格
        /// <summary>
        /// 根据编号（主键）返回表格
        ///</summary>
        public DataTable GetTable(string Id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_User_Get";
            DbParameters.Add(new DatabaseParameter("SysID", Id, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据类型查询数据列表
        /// <summary>
        /// 根据类型查询数据列表
        /// </summary>
        /// <param name="isdel"></param>
        /// <param name="type">数据类型</param>
        /// <returns></returns>
        public DataTable GetList(int type, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_GetList";
            DbParameters.Add(new DatabaseParameter("RoleType", type, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 角色ID和父级PID查询
        /// <summary>
        /// 角色ID和父级PID查询
        ///</summary>
        public DataTable GetTableByRole(int rid, int pid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysRole_Right_GetTable";
            DbParameters.Add(new DatabaseParameter("RoleID", rid, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("PID", pid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据模块ID和角色ID返回表格
        /// <summary>
        /// 根据模块ID和角色ID返回表格
        ///</summary>
        public DataTable GetButtonsByRid(int mid, int rid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_RoleRightButton";
            DbParameters.Add(new DatabaseParameter("MID", mid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RID", rid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int RoleRightAdd(int rid, string mids, string bids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_RoleRight";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("IDS", mids, DatabaseType.SQL_NVarChar, 9999));
            DbParameters.Add(new DatabaseParameter("RID", rid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Buttons", bids, DatabaseType.SQL_NVarChar, 9999));
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

        public DataTable GetRoleButton(string UserID,int mid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_GetRoleButton";
            DbParameters.Add(new DatabaseParameter("ModuleID", mid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", UserID, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }

}
