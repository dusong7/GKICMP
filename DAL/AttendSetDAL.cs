/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      俞桂宝
** 创建日期:      2016年11月07日 14时38分19秒
** 描    述:      考勤设置
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
    public class AttendSetDAL : DataEntity<AttendSetEntity>
    {

        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(AttendSetEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ASID", model.ASID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MBegin", model.MBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("MEnd", model.MEnd, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("ABegin", model.ABegin, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("AEnd", model.AEnd, DatabaseType.SQL_DateTime, 8));
            //DbParameters.Add(new DatabaseParameter("Roles", model.Roles, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsUse", model.IsUse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AType", model.AType, DatabaseType.SQL_Int, 4));

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
        public int Edit1(AttendSetEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet1_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ASID", model.ASID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MBegin", model.MBegin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("MEnd", model.MEnd, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("Roles", model.Roles, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("IsUse", model.IsUse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("OutType", model.OutType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AName", model.AName, DatabaseType.SQL_NVarChar, 200));
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
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet_DelBat";
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

        public int DeleteBat1(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet1_DelBat";
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

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public AttendSetEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet_Get";
            DbParameters.Add(new DatabaseParameter("ASID", id, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        public AttendSetEntity GetObjByID1(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet1_Get";
            DbParameters.Add(new DatabaseParameter("ASID", id, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
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
        //public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, AttendSetEntity model, DateTime begin, DateTime end)
        public DataTable GetPagedList(int pagesize, int pageindex, ref int recordCount, AttendSetEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("IsUse", model.IsUse, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("Begin", begin, DatabaseType.SQL_DateTime, 20));
            //DbParameters.Add(new DatabaseParameter("End", end, DatabaseType.SQL_DateTime, 20));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, AttendSetEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet1_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));


            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 是否启用考勤节点
        /// <summary>
        /// 是否启用考勤节点
        ///</summary>
        public int UpdateByID(int asid, int isuse)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ASID", asid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsUse", isuse, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        public int UpdateByID1(int asid, int isuse)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_AttendSet1_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ASID", asid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsUse", isuse, DatabaseType.SQL_Int, 4));

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


        #region 获取已启用的考勤节点
        public DataTable GetTable()
        {
            string sql = "select * from Tb_AttendSet where IsUse=1";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion

        public static object locker = new object();

        public DataTable GetList()
        {
            lock (locker)
            {
                string sql = "select * from Tb_AttendSet1 where IsUse=1 order by MBegin";

                if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
                {
                    throw new Exception(DataReturn.SqlMessage);
                }
            }

            return DataReflectionContainer;
        }
        public DataTable List()
        {
            string sql = "select CONVERT(varchar(100), MBegin, 8) MBegin ,CONVERT(varchar(100), MEnd, 8) MEnd ,AType from Tb_AttendSet where IsUse=1 order by  CONVERT(varchar(100), MBegin, 8)";

                if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
                {
                    throw new Exception(DataReturn.SqlMessage);
                }
            

            return DataReflectionContainer;
        }

        #region 获取已启用的考勤节点
        public DataTable GetTableIsuse()
        {
            string sql = "select AType,dbo.getBaseDataName(AType) ATypeName from Tb_AttendSet  where IsUse=1 and AType<>372 group by AType";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion
    }
}
