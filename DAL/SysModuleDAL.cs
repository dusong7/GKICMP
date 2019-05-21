using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;
using gk.rjb_Y.Libraries;
using GK.GKICMP.Entities;
using System;
using System.Data;


namespace GK.GKICMP.DAL
{
    public partial class SysModuleDAL : DataEntity<SysModuleEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SysModuleEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ModuleID", model.ModuleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ModuleName", model.ModuleName, DatabaseType.SQL_NVarChar, 60));
            DbParameters.Add(new DatabaseParameter("ModuleUrl", model.ModuleUrl, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ModuleIcon", model.ModuleIcon, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("ParentID", model.ParentID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ModuleOrder", model.ModuleOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsRight", model.IsRight, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ModuleButton", model.ModuleButton, DatabaseType.SQL_NVarChar, 240));

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


        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public DataTable GetTable(int Id)
        {
            string sql = "select a.* from dbo.Tb_SysModule a where ParentID=" + Id + " order by a.ModuleOrder asc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取模块名称
        /// <summary>
        /// 获取模块名称
        /// </summary>
        /// <returns></returns>
        public SysModuleEntity GetObj(int id)
        {
            string sql = "select *,[dbo].[getSysModuleName]([ParentID]) as ParentName from Tb_SysModule where ModuleID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 获取按钮
        /// <summary>
        /// 获取按钮
        /// </summary>
        /// <returns></returns>
        public DataTable GetButton()
        {
            string sql = "SELECT * from Tb_SysButton order by BID";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 删除栏目
        /// <summary>
        /// 删除栏目
        ///</summary>
        public int DeleteBat(int mid)
        {
            int result = 0;

            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("MID", mid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            // return stmessage.AffectRows;

            result = Convert.ToInt32(DbParameters[1].Value);
            return result;
        }
        #endregion

        #region 获取app模块
        /// <summary>
        /// 获取app模块
        /// </summary>
        /// <returns></returns>
        public DataTable GetAPPs()
        {
            string sql = "SELECT * from Tb_AppModule order by ModuleID";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据用户权限查询菜单
        /// <summary>
        /// 根据用户权限查询菜单
        ///</summary>
        public DataTable GetListByUserID(int pid, string uid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_GetByUID";
            DbParameters.Add(new DatabaseParameter("ModuleID", pid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UID", uid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据用户和父级ID查询菜单
        /// <summary>
        /// 根据用户权限查询菜单
        ///</summary>
        public DataTable GetTableByUID(int pid, string uid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SysModule_GetTableByUID";
            DbParameters.Add(new DatabaseParameter("ParentID", pid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UID", uid, DatabaseType.SQL_NVarChar, 40));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        public int RemindUpdate(int moduleID, string UserID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_RemindUpdate_RemindUpdate";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ModuleID", moduleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", UserID, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
    }
}
