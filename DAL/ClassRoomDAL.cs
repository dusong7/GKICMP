/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2016年12月28日 15时54分38秒
** 描    述:      教室基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

//using GK.GKICMP.Entities;
//using gk.rjb_Y.DataEntityProvider;
//using gk.rjb_Y.Libraries;
//using gk.rjb_Y.DBAccessConvertorProvider;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;



namespace GK.GKICMP.DAL
{
    public partial class ClassRoomDAL : DataEntity<ClassRoomEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(ClassRoomEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CRID", model.CRID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("RoomName", model.RoomName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("RoomDesc", model.RoomDesc, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsUseable", model.IsUseable, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RFlag", model.RFlag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsCome", model.IsCome, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CType", model.CType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DID", model.DID, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = Convert.ToInt32(DbParameters[0].Value);
            return result;
        }
        #endregion


        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_DelBat";
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
        public ClassRoomEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_ClassRoom where CRID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 根据楼层ID获取教室信息
        /// <summary>
        /// 根据楼层ID获取教室信息
        ///</summary>
        public DataTable GetList(string fid, int rflag, int isdel, int isuseable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_GetList";
            DbParameters.Add(new DatabaseParameter("FID", fid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("RFlag", rflag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsUseable", isuseable, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据教学楼ID获取教室信息
        /// <summary>
        /// 根据楼层ID获取教室信息
        ///</summary>
        public DataTable GetByBID(string bid, int isdel, int isuseable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_GetListByBID";
            DbParameters.Add(new DatabaseParameter("BID", bid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsUseable", isuseable, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        public DataTable GetList(string name, int isdel)
        {
            string sql = "select * from tb_ClassRoom where roomname='" + name + "' and isdel=" + isdel;
    
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 获取教室信息
        /// <summary>
        /// 获取教室信息
        ///</summary>
        public DataTable GetTable(int isdel, int isuseable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_GetTable";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsUseable", isuseable, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 获取教室信息
        /// <summary>
        /// 获取教室信息
        ///</summary>
        public DataTable GetTable(int isdel, int isuseable,int flag)
        {
            DbParameters.Clear();
            string sql = "select *,dbo.getBNameByFID(FID) as BName,(roomname+'【'+ dbo.getDepOtherName(DID)+'】')RName from Tb_ClassRoom where IsUseable=" + isuseable + " and Isdel=" + isdel + " and( RFlag=" + flag + " or " + flag + " =-2)";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, ClassRoomEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("RoomName", model.RoomName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("IsUseable", model.IsUseable, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FID", model.FID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("RFlag", model.RFlag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 获取场地信息--预约
        /// <summary>
        /// 获取场地信息--预约
        ///</summary>
        public DataTable Table(int isdel, int isuseable)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_ClassRoom_Table";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsUseable", isuseable, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}

