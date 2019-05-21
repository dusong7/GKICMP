/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年10月07日 10时51分27秒
** 描    述:      排课计划的节课选填基本操作类
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
    public partial class TeacherPlane_InfoDAL : DataEntity<TeacherPlane_InfoEntity>
    {

        #region 根据班级排课计划id查询
        /// <summary>
        /// 根据班级排课计划id查询
        ///</summary>
        public DataTable Get(string TPID)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeacherPlane_Info_Get";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("TPID", TPID, DatabaseType.SQL_NVarChar, 40));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DataReflectionContainer;
        }
        #endregion



    }

}

