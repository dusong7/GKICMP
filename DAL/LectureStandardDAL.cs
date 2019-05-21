/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 15时33分48秒
** 描    述:      评分标准操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;


namespace GK.GKICMP.DAL
{
    public partial class Lecture_StandardDAL : DataEntity<Lecture_StandardEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Lecture_StandardEntity model)
        {
            int result = 0;

            DbParameters.Clear();
            ProcedureName = "up_Tb_Lecture_Standard_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("LSID", model.LSID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("StandardContent", model.StandardContent, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("LScore", model.LScore, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ParentID", model.ParentID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("SOrder", model.SOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("LSFlag", model.LSFlag, DatabaseType.SQL_Int, 4));//标识 1：听课标准 2：考核标准
            DbParameters.Add(new DatabaseParameter("PFID", model.PFID, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[0].Value.ToString());
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
            ProcedureName = "up_Tb_Lecture_Standard_DelBat";
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
        public Lecture_StandardEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_Lecture_Standard where LSID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 根据父级获取子标准列表
        /// <summary>
        /// 根据父级获取子标准列表
        /// </summary>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetList(int isdel, int parentid, int lsflag)
        {
            string sql = "SELECT * FROM [Tb_Lecture_Standard] where isdel=" + isdel + " and ParentID=" + parentid + " and LSFlag=" + lsflag + " order by SOrder";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据父级获取子标准列表(绩效考核)
        /// <summary>
        /// 根据父级获取子标准列表(绩效考核)
        /// </summary>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetListByPFID(int isdel, int parentid, int lsflag, int pfid)
        {
            string sql = "SELECT * FROM [Tb_Lecture_Standard] where isdel=" + isdel + " and ParentID=" + parentid + " and LSFlag=" + lsflag + " and PFID=" + pfid + " order by SOrder";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION,sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        public DataTable GetScoreList(int isdel, int parentid, string userid, string lid, int flag)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Lecture_Standard_GetScoreList";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ParentID", parentid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserID", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("LID", lid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Flag", flag, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
    }
}