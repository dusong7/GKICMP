/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年05月27日 09时27分11秒
** 描    述:      教材操作类
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
using System.Transactions;


namespace GK.GKICMP.DAL
{
    public partial class TeachMaterialDAL : DataEntity<TeachMaterialEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(TeachMaterialEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeachMaterial_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("TMID", model.TMID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TMName", model.TMName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("TEdition", model.TEdition, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TMCourses", model.TMCourses, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TermID", model.TermID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

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
        public int DeleteBat(int tmid, int tvmid, int cid, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeachMaterial_DelBat";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("TMID", tmid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TVMID", tvmid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
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
        public TeachMaterialEntity GetObjByID(int id)
        {
            string sql = "select  * from Tb_TeachMaterial where TMID=" + id;
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, TeachMaterialEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeachMaterial_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TMName", model.TMName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("TEdition", model.TEdition, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CID", model.TMCourses, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 获取教材年级列表
        /// <summary>
        /// 获取教材年级列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetGradeList()
        {
            string sql = "SELECT distinct GID,GradeLevelName,TermID  FROM [Tb_TeachMaterial] a inner join Tb_Grade_Level b on a.GID=b.GLID";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据版本和课程获取教材信息
        /// <summary>
        /// 根据版本和课程获取教材信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(int tmvid, int cid, int isdel)
        {
            string sql = "SELECT * FROM [Tb_TeachMaterial] where TEdition=" + tmvid + " and TMCourses=" + cid + " and Isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据版本和课程获取教材信息
        /// <summary>
        /// 根据版本和课程获取教材信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetList( int cid, int isdel)
        {
            string sql = "SELECT * FROM [Tb_TeachMaterial] where  TMCourses=" + cid + " and Isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 导入教材章节
        /// <summary>
        /// 导入教材章节
       /// </summary>
       /// <param name="list">教材章节列表</param>
       /// <returns></returns>
        public string Import(List<TeachMaterialImport> list) 
        {
            string resultvalue = "-99";
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    resultvalue = "0";
                    foreach (TeachMaterialImport tmi in list)
                    {
                        string result = "0";
                        TeachMaterialImport model = tmi;
                        if (model != null)
                        {
                            result = AddImport(model);
                            if (result == "-1")
                            {
                                resultvalue = "-1";
                                return resultvalue;
                            }
                            else if (result == "0")
                            {
                            }
                            else
                            {
                                resultvalue = result;
                                return resultvalue;
                            }

                        }
                    }
                    if (resultvalue == "0")
                    {
                        ts.Complete();
                    }
                    else
                    {
                        resultvalue = "-99";
                    }
                }
                catch (Exception ex)
                {
                    resultvalue = "-99";
                }
                finally
                {
                    ts.Dispose();
                }
            }
            return resultvalue;
        }
        public string AddImport(TeachMaterialImport model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_TeachMaterial_AddImport";
            DataAccessChannelProtection = true;
            string resultvalue = "";
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_NVarChar, 100, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("TMName", model.TMName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("TEdition", model.TEdition, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TMCourses", model.TMCourse, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("TermID", model.TermID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("ChapterName", model.ChapterName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("ChapterContent", model.ChapterContent, DatabaseType.SQL_Text));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return DbParameters[0].Value.ToString();
        }
        #endregion
    }
}

