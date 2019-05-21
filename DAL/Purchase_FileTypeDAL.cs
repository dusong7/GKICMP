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
    public partial class Purchase_FileTypeDAL : DataEntity<Purchase_FileTypeEntity>
    {
        #region 根据PTpye获取Name
        /// <summary>
        /// 根据ID和类型获取附件
        /// </summary>
        /// <returns></returns>
        public DataTable GetNameByType(string pid)
        {
            string sql = @"select pf.*,dbo.getPurchaseFiles('" + pid + "',pf.ID) FileName ,dbo.[getPurchaseFilespfid]('" + pid + "',pf.ID) PFID,dbo.[getPurchaseFilesDate]('" + pid + "',pf.ID) CreateDate,dbo.getUserName(dbo.[getPurchaseUsername]('" + pid + "',pf.ID)) as UserName from Tb_Purchase_FileType pf where PurchaseTypeID=(select PType from Tb_Purchase	where pid='" + pid + "' )";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据ID和类型获取附件
        /// <summary>
        /// 根据ID和类型获取附件
        /// </summary>
        /// <returns></returns>
        public DataTable GetListProState(string id, int prostate)
        {
            string sql = "SELECT *,dbo.getProNameByJZ(PID) as PName,dbo.getUserName(CreateUser) as UserName FROM [Tb_Project_File] WHERE [PID] = '" + id + "' and ProStage=" + prostate + " order by ProStage";
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, PurchaseEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "[up_Tb_Purchase_File_Paged]";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("PTitle", model.PTitle, DatabaseType.SQL_NVarChar, 100));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion

        #region 根据项目ID获取数据
        /// <summary>
        /// 根据项目ID获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetFile(string id)
        {
            string sql = "select * FROM [Tb_Project_File] WHERE [PFID] = '" + id + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string pid)
        {
            string sql = "select * FROM [Tb_Project_File] WHERE [PID] = '" + pid + "' and IsReport=0";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 更新字段为 已上报
        /// <summary>
        /// 更新字段为 已上报
        ///</summary>
        public int Update(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Purchase_File_Update";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("ids", ids, DatabaseType.SQL_NVarChar, 1000));
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
