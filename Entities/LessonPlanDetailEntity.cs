/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月19日 03点25分
** 描   述:      备课计划清单实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LessonPlan_DetailEntity
    {

        /// <summary>
        /// LessonPlan_Detail表实体
        ///</summary>
        public LessonPlan_DetailEntity()
        {
        }


        /// <summary>
        /// LessonPlan_Detail表实体
        /// </summary>
        /// <param name="ldid"></param>
        /// <param name="weeknum"></param>
        /// <param name="pdate"></param>
        /// <param name="acontent"></param>
        /// <param name="tids"></param>
        /// <param name="lid"></param>
        public LessonPlan_DetailEntity(string ldid, int weeknum, DateTime pdate, string acontent, string tids, string lid)
        {
            this.LDID = ldid;
            this.WeekNum = weeknum;
            this.PDate = pdate;
            this.AContent = acontent;
            this.TIDS = tids;
            this.LID = lid;
        }

        private string ldid;//清单ID
        private int weeknum;//周次
        private DateTime pdate;//时间
        private string acontent;//活动内容
        private string tids;//教师ID
        private string lid;//计划ID
        private int isprepare;//是否备课

        /// <summary>
        /// 是否备课
        /// </summary>
        public int IsPrepare
        {
            get { return isprepare; }
            set { isprepare = value; }
        }

        ///<summary>
        ///清单ID
        ///</summary>
        public string LDID
        {
            get
            {
                return ldid;
            }
            set
            {
                ldid = value;
            }
        }

        ///<summary>
        ///周次
        ///</summary>
        public int WeekNum
        {
            get
            {
                return weeknum;
            }
            set
            {
                weeknum = value;
            }
        }

        ///<summary>
        ///时间
        ///</summary>
        public DateTime PDate
        {
            get
            {
                return pdate;
            }
            set
            {
                pdate = value;
            }
        }

        ///<summary>
        ///活动内容
        ///</summary>
        public string AContent
        {
            get
            {
                return acontent;
            }
            set
            {
                acontent = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TIDS
        {
            get
            {
                return tids;
            }
            set
            {
                tids = value;
            }
        }

        ///<summary>
        ///计划ID
        ///</summary>
        public string LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }
    }
}

