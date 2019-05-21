/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:     ygb
** 创建日期:      2018年04月04日 17时12分19秒
** 描    述:      积分的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;


namespace GK.GKICMP.DAL
{
  public   class IntegralInfoDAL : DataEntity<IntegralInfoEntity>
    {
    

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(string  uname,int type)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_IntegralInfo_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("IType", type, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", uname, DatabaseType.SQL_NVarChar, 40));
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

   

