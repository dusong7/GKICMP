/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月07日 14时38分19秒
** 描    述:      角色数据的基本操作类
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
using System.Transactions;

namespace GK.GKICMP.DAL
{
    public partial class PayProject_ItemDAL : DataEntity<PayProject_ItemEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(PayProject_ItemEntity model, string button)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_Item_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("PPIID", model.PPIID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PPID", model.PPID, DatabaseType.SQL_NVarChar, 40));
            //DbParameters.Add(new DatabaseParameter("PIID", model.PIID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PIIDs", button, DatabaseType.SQL_NVarChar, 2000));

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

        #region 根据PPID获取缴费项的ID
        /// <summary>
        /// 根据PPID获取缴费项的ID
        /// </summary>
        /// <returns></returns>
        public DataTable GetByPPID(string id)
        {
            string sql = "SELECT *,b.PayName,b.PayCount FROM [Tb_PayProject_Item] a inner join Tb_PayItem b on a.PIID= b.PIID WHERE [PPID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_PayProject_Item_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
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
