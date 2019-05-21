/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      FSC
** 创建日期:    2017年02月27日
** 描 述:       学段
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
    public partial class GradeLevelDAL : DataEntity<GradeLevelEntity>
    {
        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public GradeLevelEntity GetGradeLevelByGLID(int id)
        {
            string sql = "select * from Tb_Grade_Level where GLID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 获取年级等级列表
        /// <summary>
        /// 获取年级等级列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetList()
        {
            string sql = "SELECT * FROM Tb_Grade_Level where IsUse=1";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}
