/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      fzh
** 创建日期:      2016年11月11日 15时12分35秒
** 描    述:      宿舍楼的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using GK.GKICMP.Entities;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class BuildingDAL : DataEntity<BuildingEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(BuildingEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Building_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("BID", model.BID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BName", model.BName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BNumber", model.BNumber, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("BType", model.BType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AllBuilding", model.AllBuilding, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("AllUseArea", model.AllUseArea, DatabaseType.SQL_Decimal, 9));
            DbParameters.Add(new DatabaseParameter("BAddress", model.BAddress, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("FloorNum", model.FloorNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BState", model.BState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BOrder", model.BOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BPhoto", model.BPhoto, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BFlag", model.BFlag, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value.ToString());
        }
        #endregion


        #region 设置宿舍楼管理员
        /// <summary>
        /// 设置宿舍楼管理员
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AdminSet(int bid, string admin)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Building_AdminSet";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("BID", bid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BAdmin", admin, DatabaseType.SQL_NVarChar, 40));

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


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Building_DelBat";
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
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public BuildingEntity GetObjByID(int id)
        {
            string sql = "SELECT *,dbo.getCampusName(CID) as CampusName FROM [Tb_Building] WHERE [BID] =" + id;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, BuildingEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Building_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("BName", model.BName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("BType", model.BType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BFlag", model.BFlag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 根据校区ID获取宿舍楼信息
        /// <summary>
        /// 根据校区ID获取宿舍楼信息
        ///</summary>
        public DataTable GetList(int cid, int isdel, int bflag)
        //public DataTable GetList(int isdel, int bflag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Building_GetList";
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BFlag", bflag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据校区ID获取教学楼名称
        /// <summary>
        /// 根据校区ID获取教学楼名称
        ///</summary>
        public DataTable Get(int isdel, int bflag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Building_Table";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("BFlag", bflag, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}