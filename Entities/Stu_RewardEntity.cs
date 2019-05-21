/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月16日 02点32分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Stu_RewardEntity
    {

        /// <summary>
        /// Stu_Reward表实体
        ///</summary>
        public Stu_RewardEntity()
        {
        }


        /// <summary>
        /// Stu_Reward表实体
        /// </summary>
        /// <param name="srid">奖励ID</param>
        /// <param name="stuid">学生</param>
        /// <param name="eyear">学年</param>
        /// <param name="term">学期</param>
        /// <param name="rewardname">奖励名称</param>
        /// <param name="rewardgrade">奖励级别</param>
        /// <param name="rewardtype">奖励类别</param>
        /// <param name="rewardreason">奖励原因</param>
        /// <param name="rewardcash">奖励金额</param>
        /// <param name="rewarddep">奖励单位</param>
        /// <param name="rstyle">奖励类型</param>
        /// <param name="rmode">奖励方式</param>
        /// <param name="rdate">奖励时间</param>
        /// <param name="isachievement">是否计入绩效</param>
        /// <param name="teaid">辅导老师</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="rfile">证书附件</param>
        /// <param name="isdel">是否删除</param>
        public Stu_RewardEntity(string srid, string stuid, string eyear, int term, string rewardname, int rewardgrade, int rewardtype, string rewardreason, decimal rewardcash, string rewarddep, int rstyle, int rmode, DateTime rdate, int isachievement, string teaid, string createuser, DateTime createdate, string rfile, int isdel)
        {
            this.SRID = srid;
            this.StuID = stuid;
            this.EYear = eyear;
            this.Term = term;
            this.RewardName = rewardname;
            this.RewardGrade = rewardgrade;
            this.RewardType = rewardtype;
            this.RewardReason = rewardreason;
            this.RewardCash = rewardcash;
            this.RewardDep = rewarddep;
            this.RStyle = rstyle;
            this.RMode = rmode;
            this.RDate = rdate;
            this.IsAchievement = isachievement;
            this.TeaID = teaid;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.RFile = rfile;
            this.Isdel = isdel;
        }

        private string srid;//奖励ID
        private string stuid;//学生
        private string eyear;//学年
        private int term;//学期
        private string rewardname;//奖励名称
        private int rewardgrade;//奖励级别
        private int rewardtype;//奖励类别
        private string rewardreason;//奖励原因
        private decimal rewardcash;//奖励金额
        private string rewarddep;//奖励单位
        private int rstyle;//奖励类型
        private int rmode;//奖励方式
        private DateTime rdate;//奖励时间
        private int isachievement;//是否计入绩效
        private string teaid;//辅导老师
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private string rfile;//证书附件
        private int isdel;//是否删除

        public int RewardRand { get; set; }
        ///<summary>
        ///奖励ID
        ///</summary>
        public string SRID
        {
            get
            {
                return srid;
            }
            set
            {
                srid = value;
            }
        }

        ///<summary>
        ///学生
        ///</summary>
        public string StuID
        {
            get
            {
                return stuid;
            }
            set
            {
                stuid = value;
            }
        }

        ///<summary>
        ///学年
        ///</summary>
        public string EYear
        {
            get
            {
                return eyear;
            }
            set
            {
                eyear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int Term
        {
            get
            {
                return term;
            }
            set
            {
                term = value;
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
        public int RewardGrade
        {
            get
            {
                return rewardgrade;
            }
            set
            {
                rewardgrade = value;
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
        ///奖励原因
        ///</summary>
        public string RewardReason
        {
            get
            {
                return rewardreason;
            }
            set
            {
                rewardreason = value;
            }
        }

        ///<summary>
        ///奖励金额
        ///</summary>
        public decimal RewardCash
        {
            get
            {
                return rewardcash;
            }
            set
            {
                rewardcash = value;
            }
        }

        ///<summary>
        ///奖励单位
        ///</summary>
        public string RewardDep
        {
            get
            {
                return rewarddep;
            }
            set
            {
                rewarddep = value;
            }
        }

        ///<summary>
        ///奖励类型
        ///</summary>
        public int RStyle
        {
            get
            {
                return rstyle;
            }
            set
            {
                rstyle = value;
            }
        }

        ///<summary>
        ///奖励方式
        ///</summary>
        public int RMode
        {
            get
            {
                return rmode;
            }
            set
            {
                rmode = value;
            }
        }

        ///<summary>
        ///奖励时间
        ///</summary>
        public DateTime RDate
        {
            get
            {
                return rdate;
            }
            set
            {
                rdate = value;
            }
        }

        ///<summary>
        ///是否计入绩效
        ///</summary>
        public int IsAchievement
        {
            get
            {
                return isachievement;
            }
            set
            {
                isachievement = value;
            }
        }

        ///<summary>
        ///辅导老师
        ///</summary>
        public string TeaID
        {
            get
            {
                return teaid;
            }
            set
            {
                teaid = value;
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
        ///证书附件
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

