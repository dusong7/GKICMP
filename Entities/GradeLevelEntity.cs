/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      fsc
** 创建日期:      2017年05月27日 09点15分
** 描   述:      学段类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class GradeLevelEntity
    {
        private int glid;//GLID
        private string gradeLevelName;//年级名称
        private string shortName;//年级简称
        private int gradeLever;//学段

        ///<summary>
        ///GLID
        ///</summary>
        public int GLID
        {
            get
            {
                return glid;
            }
            set
            {
                glid = value;
            }
        }

        /// <summary>
        /// 年级名称
        /// </summary>
        public string GradeLevelName
        {
            get
            {
                return gradeLevelName;
            }
            set
            {
                gradeLevelName = value;
            }
        }

        /// <summary>
        /// 年级简称
        /// </summary>
        public string ShortName
        {
            get
            {
                return shortName;
            }
            set
            {
                shortName = value;
            }
        }

        /// <summary>
        /// 学段
        /// </summary>
        public int GradeLever
        {
            get
            {
                return gradeLever;
            }
            set
            {
                gradeLever = value;
            }
        }
    }
}
