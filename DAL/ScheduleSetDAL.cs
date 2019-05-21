/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月19日 10时03分32秒
** 描    述:      排课设置的基本操作类
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
    public partial class ScheduleSetDAL : DataEntity<ScheduleSetEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ScheduleSetEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ScheduleSet_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CourseDay", model.CourseDay, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MorningPitch", model.MorningPitch, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AfterPitch", model.AfterPitch, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EveningPitch", model.EveningPitch, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsMorningRead", model.IsMorningRead, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsSingle", model.IsSingle, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsOptional", model.IsOptional, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsWeekly", model.IsWeekly, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("NoTimetable", model.NoTimetable, DatabaseType.SQL_NVarChar, 200));
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


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public ScheduleSetEntity GetObjByID()
        {
            string sql = "select * from Tb_ScheduleSet";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
    }
}

