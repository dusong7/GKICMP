/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年06月1日 10时03分11秒
** 描    述:      教材操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.Entities;
using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;

namespace GK.GKICMP.DAL
{
    public partial class TeachMaterialVersionDAL : DataEntity<TeachMaterialVersionEntity>
    {
        #region 获取教材年级列表(根据课程)
        /// <summary>
        /// 获取教材年级列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(int cid)
        {
            string sql = "SELECT distinct TMVID,VersionName  FROM Tb_TeachMaterial a inner join Tb_TeachMaterial_Version b on a.TEdition=b.TMVID where a.Isdel=0 and TMCourses=" + cid;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取教材年级列表
        /// <summary>
        /// 获取教材年级列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetListAll()
        {
            string sql = "SELECT * FROM Tb_TeachMaterial_Version" ;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
    }
}
