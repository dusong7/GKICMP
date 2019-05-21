/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月09日 09时48分24秒
** 描    述:      视频配置实体类
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
    public partial class VideoDAL : DataEntity<VideoEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(VideoEntity model)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Video_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("VID", model.VID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("EquipName", model.EquipName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("EquipIP", model.EquipIP, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("PotNum", model.PotNum, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("UserPwd", model.UserPwd, DatabaseType.SQL_NVarChar, 200));
            DbParameters.Add(new DatabaseParameter("EquipPotNum", model.EquipPotNum, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("EquipPre", model.EquipPre, DatabaseType.SQL_NVarChar, 500));


            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            //return stmessage.AffectRows;

            resultvalue = Convert.ToInt32(DbParameters[0].Value);
            return resultvalue;

        }
        #endregion

        #region 根据主键编号集合删除记录
        /// <summary>
        /// 根据主键编号集合删除记录
        ///</summary>
        public int DeleteBat(string ids)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Video_DelBat";
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
        public VideoEntity GetObjByID(int id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Video_Get";
            DbParameters.Add(new DatabaseParameter("VID", id, DatabaseType.SQL_Int, 4));
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
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, VideoEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Video_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));

            DbParameters.Add(new DatabaseParameter("EquipName", model.EquipName, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("UserName", model.UserName, DatabaseType.SQL_NVarChar, 200));

           

            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion 

        #region 获取数据集，返回DataSet
        /// <summary>
        /// 获取数据集，返回DataSet
        /// </summar

        public DataTable GetTable()
        {
            string sql = "select * from Tb_Video";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

    }


}
