/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月11日 10时31分22秒
** 描    述:      校区数据的基本操作类
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
    public partial class CampusDAL : DataEntity<CampusEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(CampusEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Campus_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CampusName", model.CampusName, DatabaseType.SQL_NVarChar, 150));
            DbParameters.Add(new DatabaseParameter("ButtonCode", model.ButtonCode, DatabaseType.SQL_NVarChar, 300));
            DbParameters.Add(new DatabaseParameter("LinkNum", model.LinkNum, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DutyUser", model.DutyUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AreaSize", model.AreaSize, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("BuiltupAea", model.BuiltupAea, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("EquipmentValue", model.EquipmentValue, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("FixedAssets", model.FixedAssets, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("BeginDate", model.BeginDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int Isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Campus_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", Isdel, DatabaseType.SQL_Int, 4));
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
        public CampusEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_Campus where CID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 查询校区表所有信息
        /// <summary>
        /// 查询校区表所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Campus_GetList";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
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
        public DataTable GetPaged()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Campus_Paged";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 通过CID来获取校区名称
        /// <summary>
        /// 通过CID来获取校区名称
        ///</summary>
        public CampusEntity GetTable(int cid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Campus_GetByCID";
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 获取ID
        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public int GetByCID(int cid, int isdel)
        {
            int id = -1;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Campus_GetCID";
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = Convert.ToInt32(dv.Table.Rows[0]["CID"].ToString());
            }
            return id;
        }
        #endregion

    }
}
