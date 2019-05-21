/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月24日 05点34分
** 描   述:      日志实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SpaceLogEntity
    {

        /// <summary>
        /// SpaceLog表实体
        ///</summary>
        public SpaceLogEntity()
        {
        }


        /// <summary>
        /// SpaceLog表实体
        /// </summary>
        /// <param name="sysid">用户ID</param>
        /// <param name="ispublish">是否公布</param>
        /// <param name="claid">班级ID</param>
        /// <param name="aduitstate">审核状态</param>
        public SpaceLogEntity(string sysid, int ispublish, int claid,int aduitstate)
        {
            this.SysID = sysid;
            this.IsPublish = ispublish;
            this.ClaID = claid;
            this.AduitState = aduitstate;
        }

        private int egid;//日志ID
        private string sysid;//用户ID
        private string logtext;//日志内容
        private DateTime createdate;//发布时间
        private int ispublish;//是否公布
        private int peonum;//点赞人数
        private int claid;//班级ID
        private int isaduit;//是否审核
        private int aduitstate;//审核状态
        private string logtitle;
        private string sysusername;
        private int sflag;//标识 1：空间日志 2：学生活动日志
        private string said;//学生活动ID

        /// <summary>
        /// 学生活动ID
        /// </summary>
        public string SAID
        {
            get { return said; }
            set { said = value; }
        }

        /// <summary>
        /// 标识 1：空间日志 2：学生活动日志
        /// </summary>
        public int SFlag
        {
            get { return sflag; }
            set { sflag = value; }
        }

        public string SysUserName
        {
            get { return sysusername; }
            set { sysusername = value; }
        }

        /// <summary>
        /// 日志标题
        /// </summary>
        public string LogTitle
        {
            get { return logtitle; }
            set { logtitle = value; }
        }


        ///<summary>
        ///日志ID
        ///</summary>
        public int EGID
        {
            get
            {
                return egid;
            }
            set
            {
                egid = value;
            }
        }

        ///<summary>
        ///用户ID
        ///</summary>
        public string SysID
        {
            get
            {
                return sysid;
            }
            set
            {
                sysid = value;
            }
        }

        ///<summary>
        ///日志内容
        ///</summary>
        public string LogText
        {
            get
            {
                return logtext;
            }
            set
            {
                logtext = value;
            }
        }

        ///<summary>
        ///发布时间
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
        ///是否公布
        ///</summary>
        public int IsPublish
        {
            get
            {
                return ispublish;
            }
            set
            {
                ispublish = value;
            }
        }

        ///<summary>
        ///点赞人数
        ///</summary>
        public int PeoNum
        {
            get
            {
                return peonum;
            }
            set
            {
                peonum = value;
            }
        }

        ///<summary>
        ///班级ID
        ///</summary>
        public int ClaID
        {
            get
            {
                return claid;
            }
            set
            {
                claid = value;
            }
        }

        ///<summary>
        ///是否审核
        ///</summary>
        public int IsAduit
        {
            get
            {
                return isaduit;
            }
            set
            {
                isaduit = value;
            }
        }

        ///<summary>
        ///审核状态
        ///</summary>
        public int AduitState
        {
            get
            {
                return aduitstate;
            }
            set
            {
                aduitstate = value;
            }
        }
    }
}

