/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
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
    public class BigDataDAL : DataEntity<AccessoryEntity>
    {
        #region 根据实体条件分页获取数据集，返回DataTable
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable GetzZiYuanList(DateTime begin,DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BigDataZiYuan";
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        #region 根据实体条件分页获取数据集，返回DataTable
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable GetJiaoKeYanList(DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BigDataJiaoKeYan";
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        #region 根据实体条件分页获取数据集，返回DataTable
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public DataTable GetJiaoWuList(DateTime begin, DateTime end)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BigDataJiaoWu";
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 20));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 20));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}
