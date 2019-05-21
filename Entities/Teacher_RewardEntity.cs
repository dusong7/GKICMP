/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月14日 09点56分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_RewardEntity
    {

        /// <summary>
        /// Teacher_Reward表实体
        ///</summary>
        public Teacher_RewardEntity()
        {
        }


        /// <summary>
        /// Teacher_Reward表实体
        /// </summary>
        /// <param name="tpid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="rewardtype">奖励类别</param>
        /// <param name="pubdate">获奖年月</param>
        /// <param name="rewardname">奖励名称</param>
        /// <param name="rgrade">奖励级别</param>
        /// <param name="ranking">本人排名</param>
        /// <param name="lunit">授奖单位</param>
        /// <param name="rfile">附件</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_RewardEntity(string tpid, string tid, int rewardtype, DateTime pubdate, string rewardname, string rgrade, int ranking, string lunit, string rfile, int isdel)
        {
            this.TPID = tpid;
            this.TID = tid;
            this.RewardType = rewardtype;
            this.PubDate = pubdate;
            this.RewardName = rewardname;
            this.RGrade = rgrade;
            this.Ranking = ranking;
            this.Lunit = lunit;
            this.RFile = rfile;
            this.Isdel = isdel;
        }

        private string tpid;//ID
        private string tid;//教师ID
        private int rewardtype;//奖励类别
        private DateTime pubdate;//获奖年月
        private string rewardname;//奖励名称
        private string rgrade;//奖励级别
        private int ranking;//本人排名
        private string lunit;//授奖单位
        private string rfile;//附件
        private int isdel;//是否删除
        private int isreport;//是否上报
        private DateTime begin;//开始时间
        private DateTime end;//结束时间
        private string realname;
        public string RealName
        {
            get
            {
                return realname;
            }
            set
            {
                realname = value;
            }
        }
        public DateTime Begin { get { return begin; } set { begin = value; } }
        public DateTime End { get { return end; } set { end = value; } }
        public int IsReport
        {
            get
            {
                return isreport;
            }
            set
            {
                isreport = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string TPID
        {
            get
            {
                return tpid;
            }
            set
            {
                tpid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TID
        {
            get
            {
                return tid;
            }
            set
            {
                tid = value;
            }
        }

        ///<summary>
        ///奖励类别
        ///</summary>
        public int RewardType
        {
            get
            {
                return rewardtype;
            }
            set
            {
                rewardtype = value;
            }
        }

        ///<summary>
        ///获奖年月
        ///</summary>
        public DateTime PubDate
        {
            get
            {
                return pubdate;
            }
            set
            {
                pubdate = value;
            }
        }

        ///<summary>
        ///奖励名称
        ///</summary>
        public string RewardName
        {
            get
            {
                return rewardname;
            }
            set
            {
                rewardname = value;
            }
        }

        ///<summary>
        ///奖励级别
        ///</summary>
        public string RGrade
        {
            get
            {
                return rgrade;
            }
            set
            {
                rgrade = value;
            }
        }

        ///<summary>
        ///本人排名
        ///</summary>
        public int Ranking
        {
            get
            {
                return ranking;
            }
            set
            {
                ranking = value;
            }
        }

        ///<summary>
        ///授奖单位
        ///</summary>
        public string Lunit
        {
            get
            {
                return lunit;
            }
            set
            {
                lunit = value;
            }
        }

        ///<summary>
        ///附件
        ///</summary>
        public string RFile
        {
            get
            {
                return rfile;
            }
            set
            {
                rfile = value;
            }
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
    }
}

