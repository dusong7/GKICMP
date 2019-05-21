/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月16日 10时45分21秒
** 描    述:      学生变动信息的基本操作类
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
    public partial class SchoolChangeDAL : DataEntity<SchoolChangeEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SchoolChangeEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_SchoolChange_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("StuID", model.StuID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("SCType", model.SCType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SCReason", model.SCReason, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("SCDesc", model.SCDesc, DatabaseType.SQL_Text, 4000));
            DbParameters.Add(new DatabaseParameter("SCDate", model.SCDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
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


        #region 根据主键编号删除记录
        /// <summary>
        /// 根据主键编号删除记录
        ///</summary>
        public int DeleteByID(string id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SchoolChange_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", id, DatabaseType.SQL_NVarChar, 2000));
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
        public SchoolChangeEntity GetObjByID(string id)
        {
            //string sql = "SELECT a.*,dbo.getUserName(StuID) StuIDName,dbo.getDepName(b.ClaID) ClaIDName,dbo.getGradeName((select DepID from Tb_SysUser where UID=a.StuID)) GradeName FROM [Tb_SchoolChange] a inner join Tb_Student b on a.StuID=b.StID WHERE [TID] = '" + id + "'";
            string sql = "SELECT a.*,dbo.getUserName(StuID) StuIDName,dbo.getDepName(b.ClaID) ClaIDName,dbo.getGradeName((select GID from Tb_Department where DID=b.ClaID)) GradeName FROM [Tb_SchoolChange] a inner join Tb_Student b on a.StuID=b.StID WHERE [TID] = '" + id + "'";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, SchoolChangeEntity model, DateTime begin, DateTime end, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SchoolChange_Paged";
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("begin", begin, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("end", end, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("RealName", model.RealName, DatabaseType.SQL_VarChar, 40));
            DbParameters.Add(new DatabaseParameter("SCType", model.SCType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[0].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 更新审核信息
        /// <summary>
        /// 更新审核信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateAduit(SchoolChangeEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SchoolChange_UpdateAduit";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("TID", model.TID, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("AduitUser", model.AduitUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("AduitState", model.AduitState, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("AduitDesc", model.AduitDesc, DatabaseType.SQL_Text));

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

