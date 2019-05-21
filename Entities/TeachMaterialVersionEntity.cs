/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年06月1日 10点05分
** 描   述:      教材版本实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class TeachMaterialVersionEntity
    {
        /// <summary>
        /// TeachMaterialVersionEntity表实体
        ///</summary>
        public TeachMaterialVersionEntity()
        {
        }


        /// <summary>
        /// TeachMaterialVersionEntity表实体
        /// </summary>
        public TeachMaterialVersionEntity(int tmvid, string versionname)
        {
            this.TMVID = tmvid;
            this.VersionName = versionname;
        }

        private int tmvid;//教材版本ID
        private string versionname;//版本名称

        /// <summary>
        /// 教材版本ID
        /// </summary>
        public int TMVID
        {
            get
            {
                return tmvid;
            }
            set
            {
                tmvid = value;
            }
        }

        /// <summary>
        /// 版本名称
        /// </summary>
        public string VersionName
        {
            get { return versionname; }
            set { versionname = value; }
        }
    }
}
