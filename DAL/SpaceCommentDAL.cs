/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月25日 08时37分22秒
** 描    述:      空间日志、照片评论留言操作类
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
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class SpaceCommentDAL : DataEntity<SpaceCommentEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(SpaceCommentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceComment_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SysID", model.SysID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("MContent", model.MContent, DatabaseType.SQL_Text, 16));
            DbParameters.Add(new DatabaseParameter("ObjectID", model.ObjectID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SCFlag", model.SCFlag, DatabaseType.SQL_Int, 4));

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
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceComment_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Isdel", ids, DatabaseType.SQL_Int, 4));
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


        #region 根据ObjectID查找相关评论留言数据
        /// <summary>
        /// 根据ObjectID查找相关评论留言数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(int flag, int objectid)
        {
            string sql = "SELECT *,dbo.getUserName(SysID) as CreateName FROM [Tb_SpaceComment] WHERE SCFlag=" + flag + " and ObjectID=" + objectid + " order by CreateDate";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, int claid, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_SpaceComment_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("ClaID", claid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SCFlag", flag, DatabaseType.SQL_Int, 4));//Flag 1:日志评论 2：照片评论 3：留言

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion
    }
}