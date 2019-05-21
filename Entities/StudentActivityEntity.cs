/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月29日 02点19分
** 描   述:      学生活动实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class StudentActivityEntity
    {

        /// <summary>
        /// StudentActivity表实体
        ///</summary>
        public StudentActivityEntity()
        {
        }


        /// <summary>
        /// StudentActivity表实体
        /// </summary>
        /// <param name="said">ID</param>
        /// <param name="actname">活动名称</param>
        /// <param name="acttype">活动类型</param>
        /// <param name="actdate">活动日期</param>
        /// <param name="actaddress">活动地点</param>
        /// <param name="counselor">指导教师</param>
        /// <param name="actcontent">活动内容</param>
        /// <param name="actdesc">备注</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="isdel">是否删除</param>
        public StudentActivityEntity(string said, string actname, int acttype, DateTime actdate, string actaddress, string counselor, string actcontent, string actdesc, string createuser, DateTime createdate, int isdel)
        {
            this.SAID = said;
            this.ActName = actname;
            this.ActType = acttype;
            this.ActAddress = actaddress;
            this.Counselor = counselor;
            this.ActContent = actcontent;
            this.ActDesc = actdesc;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string said;//ID
        private string actname;//活动名称
        private int acttype;//活动类型
        private string actaddress;//活动地点
        private string counselor;//指导教师
        private string actcontent;//活动内容
        private string actdesc;//备注
        private string createuser;//活动管理员
        private DateTime createdate;//录入时间
        private string logourl;//活动LOGO
        private DateTime closingdate;//报名截止日期
        private string activitytemp;//活动模板
        private DateTime abegin;//活动开始时间
        private DateTime aend;//活动结束时间
        private int isdel;//是否删除
        private int issign;//是否可报名
        private int ispublish;//是否发布
        private DateTime pubdate;//发布日期
        private string actUsers;//参与人
        private string actTypeName;
        private string counselorName;
        private string actUsersName;

        public string CreateUserName
        {
            get;
            set;
        }

        ///<summary>
        ///ID
        ///</summary>
        public string SAID
        {
            get
            {
                return said;
            }
            set
            {
                said = value;
            }
        }

        ///<summary>
        ///活动名称
        ///</summary>
        public string ActName
        {
            get
            {
                return actname;
            }
            set
            {
                actname = value;
            }
        }

        ///<summary>
        ///活动类型
        ///</summary>
        public int ActType
        {
            get
            {
                return acttype;
            }
            set
            {
                acttype = value;
            }
        }

        ///<summary>
        ///活动地点
        ///</summary>
        public string ActAddress
        {
            get
            {
                return actaddress;
            }
            set
            {
                actaddress = value;
            }
        }

        ///<summary>
        ///指导教师
        ///</summary>
        public string Counselor
        {
            get
            {
                return counselor;
            }
            set
            {
                counselor = value;
            }
        }

        ///<summary>
        ///活动内容
        ///</summary>
        public string ActContent
        {
            get
            {
                return actcontent;
            }
            set
            {
                actcontent = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string ActDesc
        {
            get
            {
                return actdesc;
            }
            set
            {
                actdesc = value;
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

        /// <summary>
        /// 活动LOGO
        /// </summary>
        public string LogoUrl
        {
            get { return logourl; }
            set { logourl = value; }
        }

        /// <summary>
        /// 报名截止日期
        /// </summary>
        public DateTime ClosingDate
        {
            get { return closingdate; }
            set { closingdate = value; }
        }

        /// <summary>
        /// 活动模板
        /// </summary>
        public string ActivityTemp
        {
            get { return activitytemp; }
            set { activitytemp = value; }
        }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime ABegin
        {
            get { return abegin; }
            set { abegin = value; }
        }


        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime AEnd
        {
            get { return aend; }
            set { aend = value; }
        }

        ///<summary>
        ///是否删除
        ///</summary>
        public int Isdel
        {
            get
            {
                return isdel;
            }
            set
            {
                isdel = value;
            }
        }

        /// <summary>
        /// 是否可报名
        /// </summary>
        public int IsSign
        {
            get { return issign; }
            set { issign = value; }
        }

        /// <summary>
        /// 是否发布
        /// </summary>
        public int IsPublish
        {
            get { return ispublish; }
            set { ispublish = value; }
        }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime PubDate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }

        public string ActUsersName
        {
            get { return actUsersName; }
            set { actUsersName = value; }
        }

        public string CounselorName
        {
            get { return counselorName; }
            set { counselorName = value; }
        }

        public string ActTypeName
        {
            get { return actTypeName; }
            set { actTypeName = value; }
        }

        public string ActUsers
        {
            get { return actUsers; }
            set { actUsers = value; }
        }
    }
}

