/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月07日
** 描 述:       日志管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;

namespace GK.GKICMP.DAL
{
    public partial class FloorDAL : DataEntity<FloorEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(FloorEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Floor_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("BID", model.BID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FloorName", model.FloorName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("FNumber", model.FNumber, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("FOrder", model.FOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;
        }
        #endregion

        #region 获取楼层名称
        /// <summary>
        /// 获取楼层名称
        /// </summary>
        /// <returns></returns>
        public FloorEntity GetObj(string fid)
        {
            string sql = "SELECT * FROM [Tb_Floor] WHERE [FID] = '" + fid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 删除栏目
        /// <summary>
        /// 删除栏目
        ///</summary>
        public int DeleteBat(string mid)
        {
            int result = 0;

            DbParameters.Clear();
            ProcedureName = "up_Tb_Floor_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("FID", mid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[1].Value);
            return result;
        }
        #endregion


        #region 绑定树-获取校区
        /// <summary>
        /// 绑定树-获取校区
        ///</summary>
        public DataTable GetTable(int isdel)
        {
            string sql = "select a.* from dbo.Tb_Campus a where Isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 绑定子节点-获取楼层
        /// <summary>
        /// 绑定子节点-获取宿楼层
        ///</summary>
        public DataTable GetByBID(int bid, int isdel)
        {
            string sql = "select a.* from dbo.Tb_Floor a inner join Tb_Building b on a.BID = b.BID where a.Isdel=" + isdel + " and a.BID = " + bid + " order by FOrder desc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}
