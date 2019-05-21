/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      CZZ
** 创建日期:    2017年02月27日
** 描 述:       年级页面
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
    public partial class GradeDAL : DataEntity<GradeEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(GradeEntity model, int classnum)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grade_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GradeName", model.GradeName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("GradeYear", model.GradeYear, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("IsGraduate", model.IsGraduate, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GraduatePhoto", model.GraduatePhoto, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("ShortName", model.ShortName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("GradeDuty", model.GradeDuty, DatabaseType.SQL_NVarChar, 1000));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime));
            DbParameters.Add(new DatabaseParameter("Notes", model.Notes, DatabaseType.SQL_Text));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ClassNum", classnum, DatabaseType.SQL_Int, 4));

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

        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, GradeEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grade_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("GradeName", model.GradeName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 删除年级
        /// <summary>
        /// 删除栏目
        ///</summary>
        public int DeleteBat(string ids, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grade_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("IDS", ids, DatabaseType.SQL_NVarChar, 2000));
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
        //public GradeEntity GetObjByID(int id)
        //{
        //    string sql = "SELECT * FROM Tb_Grade WHERE GID = " + id;
        //    if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return First();
        //}
        #endregion

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public GradeEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grade_Get";
            DbParameters.Add(new DatabaseParameter("GID", id, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 获取年级名称
        /// <summary>
        /// 获取年级名称
        ///</summary>
        public DataTable GetListAll(int isdel)
        {
            string sql = "SELECT *,dbo.getGradeLevelName(ShortName) ShortGName FROM [Tb_Grade] WHERE [Isdel] = " + isdel + " and IsGraduate=" + isdel+" order by shortname";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        public DataTable GetGradeLevel()
        {
            //string sql = "SELECT * FROM [Tb_Grade_Level] WHERE [IsUse] =1 ";
            string sql = "SELECT * FROM [Tb_Grade_Level] WHERE [IsUse] =1 ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #region 根据年级名称获取ID
        /// <summary>
        /// 根据年级名称获取
        ///</summary>
        public DataTable GetIDByName(string name, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grade_GetIDByName";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("GradeName", name, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据年级名称获取ID
        /// <summary>
        /// 根据年级名称获取ID
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public int GetGIDByName(string name, int isdel)
        {
            int id = -1;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Grade_GetGIDByName";
            DbParameters.Add(new DatabaseParameter("GradeName", name, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = Convert.ToInt32(dv.Table.Rows[0]["SDID"].ToString());
            }
            return id;
        }
        #endregion

        #region 根据用户查询负责的年级
        /// <summary>
        /// 获取年级名称
        ///</summary>
        public DataTable GetList(int isdel, string uid)
        {
            string sql = "SELECT *,dbo.getGradeLevelName(ShortName) ShortGName FROM [Tb_Grade] WHERE  IsGraduate=" + isdel + "and Isdel = " + isdel + " and GradeDuty like '%" + uid + "%' ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取当前教师所在的年级
        public DataTable GetGradeByUID(string uid)
        {
            string sql = "select *,dbo.getGradeLevelName(ShortName) ShortGName from Tb_Grade a,Tb_Department b ,Tb_TeacherPlane c where a.GID=b.GID and b.DID=c.ClaID and TeacherID='" + uid + "' and DepType=-1 and IsGraduate=0 and a.Isdel=0 and b.Isdel=0 ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}
