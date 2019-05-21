/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年10月06日 11时05分17秒
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
    public partial class FileBoxDAL : DataEntity<FileBoxEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(FileBoxEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_FileBox_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("FBID", model.FBID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FBName", model.FBName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("CreateUser", model.CreateUser, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CreateDate", model.CreateDate, DatabaseType.SQL_DateTime, 8));
            DbParameters.Add(new DatabaseParameter("AdminID", model.AdminID, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FileUrl", model.FileUrl, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("RSize", model.RSize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("RFormat", model.RFormat, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("DownLoadNum", model.DownLoadNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FFlag", model.FFlag, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        #endregion

        #region 文件夹重命名
        public int Update(FileBoxEntity model)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_FileBox_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("FBID", model.FBID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FBName", model.FBName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("PID", model.PID, DatabaseType.SQL_Int, 4));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        } 
        #endregion



        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids,string userid)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_FileBox_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("CreateUser", userid, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("Ids", ids, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return Convert.ToInt32(DbParameters[0].Value);
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public FileBoxEntity GetObjByID(string id)
        {
           
            DbParameters.Clear();
            ProcedureName = "up_Tb_FileBox_Get";
            DbParameters.Add(new DatabaseParameter("FBID", id, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        public int DownLoad( string fbid) 
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_FileBox_DownLoad";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("FBID", fbid, DatabaseType.SQL_NVarChar, 40));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, int pid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_FileBox_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("pid",pid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("FBName", "", DatabaseType.SQL_NVarChar, 200));

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }

        public DataTable GetPaged( int pid)
        {
            DbParameters.Clear();
            //ProcedureName = "up_Tb_FileBox_List";
            string sql = "select *,dbo.getUserName(CreateUser)CreateUserName from Tb_FileBox where pid=" + pid + "order by FFlag ,CreateDate desc";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
         
            return DataReflectionContainer;
        }
        #endregion
        public DataTable GetPid(int pid)
        {
            DbParameters.Clear();
            //ProcedureName = "up_Tb_FileBox_List";
            string sql = "select top 1 * from Tb_FileBox where fbid=" + pid;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }

    }

}

