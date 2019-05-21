/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月20日 05点20分
** 描   述:      备课实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LessonEntity
    {

        /// <summary>
        /// Lesson表实体
        ///</summary>
        public LessonEntity()
        {
        }


        /// <summary>
        /// Lesson表实体
        /// </summary>
        /// <param name="lesid">ID</param>
        /// <param name="ldid">详细ID</param>
        /// <param name="lid">备课计划ID</param>
        /// <param name="activityaddress">活动地点</param>
        /// <param name="pdate">活动时间1</param>
        /// <param name="acontent">活动内容</param>
        /// <param name="tids">教师ID</param>
        /// <param name="activitypre">活动准备</param>
        /// <param name="crid">活动地点ID</param>
        /// <param name="activitytarget">活动目标</param>
        /// <param name="activitycontent">活动安排</param>
        /// <param name="speaker">主讲人</param>
        /// <param name="assistant">助教</param>
        /// <param name="claids">上课班级</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="lastdate">最后修改时间</param>
        /// <param name="lastuser">最后变更人</param>
        public LessonEntity(string lesid, string ldid, string lid, string activityaddress, DateTime pdate, string acontent, string tids, string activitypre, int crid, string activitytarget, string activitycontent, string speaker, string assistant, string claids, string createuser, DateTime createdate, DateTime lastdate, string lastuser)
        {
            this.LesID = lesid;
            this.LDID = ldid;
            this.LID = lid;
            this.ActivityAddress = activityaddress;
            this.PDate = pdate;
            this.AContent = acontent;
            this.TIDS = tids;
            this.ActivityPre = activitypre;
            this.CRID = crid;
            this.ActivityTarget = activitytarget;
            this.ActivityContent = activitycontent;
            this.Speaker = speaker;
            this.Assistant = assistant;
            this.ClaIDs = claids;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.LastDate = lastdate;
            this.LastUser = lastuser;
        }

        private string lesid;//ID
        private string ldid;//详细ID
        private string lid;//备课计划ID
        private string activityaddress;//活动地点
        private DateTime pdate;//活动时间1
        private string acontent;//活动内容
        private string tids;//教师ID
        private string activitypre;//活动准备
        private int crid;//活动地点ID
        private string activitytarget;//活动目标
        private string activitycontent;//活动安排
        private string speaker;//主讲人
        private string assistant;//助教
        private string claids;//上课班级
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private DateTime lastdate;//最后修改时间
        private string lastuser;//最后变更人


        ///<summary>
        ///ID
        ///</summary>
        public string LesID
        {
            get
            {
                return lesid;
            }
            set
            {
                lesid = value;
            }
        }

        ///<summary>
        ///详细ID
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
        ///备课计划ID
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

        ///<summary>
        ///活动地点
        ///</summary>
        public string ActivityAddress
        {
            get
            {
                return activityaddress;
            }
            set
            {
                activityaddress = value;
            }
        }

        ///<summary>
        ///活动时间1
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
        ///活动准备
        ///</summary>
        public string ActivityPre
        {
            get
            {
                return activitypre;
            }
            set
            {
                activitypre = value;
            }
        }

        ///<summary>
        ///活动地点ID
        ///</summary>
        public int CRID
        {
            get
            {
                return crid;
            }
            set
            {
                crid = value;
            }
        }

        ///<summary>
        ///活动目标
        ///</summary>
        public string ActivityTarget
        {
            get
            {
                return activitytarget;
            }
            set
            {
                activitytarget = value;
            }
        }

        ///<summary>
        ///活动安排
        ///</summary>
        public string ActivityContent
        {
            get
            {
                return activitycontent;
            }
            set
            {
                activitycontent = value;
            }
        }

        ///<summary>
        ///主讲人
        ///</summary>
        public string Speaker
        {
            get
            {
                return speaker;
            }
            set
            {
                speaker = value;
            }
        }

        ///<summary>
        ///助教
        ///</summary>
        public string Assistant
        {
            get
            {
                return assistant;
            }
            set
            {
                assistant = value;
            }
        }

        ///<summary>
        ///上课班级
        ///</summary>
        public string ClaIDs
        {
            get
            {
                return claids;
            }
            set
            {
                claids = value;
            }
        }

        ///<summary>
        ///录入人
        ///</summary>
        public string CreateUser
        {
            get
            {
                return createuser;
            }
            set
            {
                createuser = value;
            }
        }

        ///<summary>
        ///录入时间
        ///</summary>
        public DateTime CreateDate
        {
            get
            {
                return createdate;
            }
            set
            {
                createdate = value;
            }
        }

        ///<summary>
        ///最后修改时间
        ///</summary>
        public DateTime LastDate
        {
            get
            {
                return lastdate;
            }
            set
            {
                lastdate = value;
            }
        }

        ///<summary>
        ///最后变更人
        ///</summary>
        public string LastUser
        {
            get
            {
                return lastuser;
            }
            set
            {
                lastuser = value;
            }
        }
    }
}

