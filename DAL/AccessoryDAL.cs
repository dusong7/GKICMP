/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月27日 17时42分24秒
** 描    述:      附件数据的基本操作类
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
    public partial class AccessoryDAL : DataEntity<AccessoryEntity>
    {
        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Accessory_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("AccessID", ids, DatabaseType.SQL_NVarChar, 40));
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
        public AccessoryEntity GetObjByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Accessory_GetByid";
            DbParameters.Add(new DatabaseParameter("AccessID", id, DatabaseType.SQL_NVarChar, 40));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 根据实体条件分页获取数据集，返回DataTable
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable GetList(int flag, string AccessObjID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Accessory_GetList";
            DbParameters.Add(new DatabaseParameter("AccessObjID", AccessObjID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AccessFlag", flag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据主键修改一条记录
        /// <summary>
        /// 根据主键修改一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit(AccessoryEntity model)
        {

            DbParameters.Clear();
            DataAccessChannelProtection = true;
            ProcedureName = "up_Tb_Accessory_UpdateAOrder";

            DbParameters.Add(new DatabaseParameter("AccessID", model.AccessID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AOrder", model.AOrder, DatabaseType.SQL_Int, 4));

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
