/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月17日 11点00分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_GuidanceEntity
    {

        /// <summary>
        /// Teacher_Guidance表实体
        ///</summary>
        public Teacher_GuidanceEntity()
        {
        }


        /// <summary>
        /// Teacher_Guidance表实体
        /// </summary>
        /// <param name="tgid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="rewardname">奖励名称</param>
        /// <param name="pubdate">获奖年月</param>
        /// <param name="rgrade">奖项等级</param>
        /// <param name="grole">本人角色</param>
        /// <param name="lunit">授奖单位</param>
        /// <param name="guidesc">本人承担工作描述</param>
        /// <param name="rfile">附件</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_GuidanceEntity(string tgid, string tid, string rewardname, DateTime pubdate, string rgrade, int grole, string lunit, string guidesc, string rfile, int isdel)
        {
            this.TGID = tgid;
            this.TID = tid;
            this.RewardName = rewardname;
            this.PubDate = pubdate;
            this.RGrade = rgrade;
            this.GRole = grole;
            this.Lunit = lunit;
            this.GuiDesc = guidesc;
            this.RFile = rfile;
            this.Isdel = isdel;
        }

        private string tgid;//ID
        private string tid;//教师ID
        private string rewardname;//奖励名称
        private DateTime pubdate;//获奖年月
        private string rgrade;//奖项等级
        private int grole;//本人角色
        private string lunit;//授奖单位
        private string guidesc;//本人承担工作描述
        private string rfile;//附件
        private int isdel;//是否删除
        public string TeacherName { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int IsReport { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public string TGID
        {
            get
            {
                return tgid;
            }
            set
            {
                tgid = value;
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
        ///奖项等级
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
        ///本人角色
        ///</summary>
        public int GRole
        {
            get
            {
                return grole;
            }
            set
            {
                grole = value;
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
        ///本人承担工作描述
        ///</summary>
        public string GuiDesc
        {
            get
            {
                return guidesc;
            }
            set
            {
                guidesc = value;
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

