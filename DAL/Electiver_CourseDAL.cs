/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年01月03日 09时15分43秒
** 描    述:      数据的基本操作类
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
    public partial class Electiver_CourseDAL : DataEntity<Electiver_CourseEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Electiver_CourseEntity model,string grades)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Course_Add";
            DataAccessChannelProtection = true;
            int result = 0;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("ECID", model.ECID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EleID", model.EleID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CourseID", model.CourseID, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("Clevel", model.Clevel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("MaxCount", model.MaxCount, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("grades", grades, DatabaseType.SQL_NVarChar, 500));

           

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return  Convert.ToInt32(DbParameters[0].Value);
        }
        #endregion




        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Course_DelBat";
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

        public int Delete(int ecid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Course_Del";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("ecid", ecid, DatabaseType.SQL_Int, 4));
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
        public Electiver_CourseEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Course_Get";
            DbParameters.Add(new DatabaseParameter("ECID", id, DatabaseType.SQL_Int, 4));
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
        public DataTable GetList(int eleid)
        {
            string sql = "select a.*,CourseName,dbo.getBaseDataName(Clevel)ClevelName,dbo.getBaseDataName(Clevel)ClevelName,dbo.getDataName(CourseType) CourseTypeName,(CASE WHEN DY IS NULL THEN 0 ELSE DY END)DY from Tb_Electiver_Course a left join Tb_ECourse b on a.CourseID=b.CID LEFT JOIN " +
                         "(SELECT DID,CorseID, COUNT(*)DY FROM (select *,dbo.getDepByTID(StuID)DID from Tb_Electiver_Stu where EleID=" + eleid + " and IsBack=0)A GROUP BY DID,CorseID)C ON A.CourseID=C.CorseID" +
                         " where eleid=" + eleid;
            //string sql = "select dbo.getEleSignExists(EleID,CourseID,1),dbo.getEleSignNumber(EleID,CourseID),*,dbo.getECourseName(CourseID), dbo.getBaseDataName(Clevel)ClevelName,dbo.getDataName(CourseType) CourseTypeName from Tb_Electiver_Course a inner join Tb_ECourse b on a.CourseID=b.CID where EleID=15  and Isdel=0";

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
        public DataTable GetListNew(int eleid,string uid)
        {
            string sql = "select (select count(*) from Tb_Electiver_Stu where EleID=" + eleid + " and StuID='" + uid + "' and IsBack=0)SignCount,(select Ecount from Tb_Electiver where EleID=" + eleid + ")Ecount,  dbo.getEleSignExists(EleID,CourseID,'" + uid + "')IsIn,dbo.getEleSignNumber(EleID,CourseID)DY,*,dbo.getECourseName(CourseID), dbo.getBaseDataName(Clevel)ClevelName,dbo.getDataName(CourseType) CourseTypeName from Tb_Electiver_Course a inner join Tb_ECourse b on a.CourseID=b.CID where EleID=" + eleid + "  and Isdel=0";

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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, Electiver_CourseEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Electiver_Paged";
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
    }

}

