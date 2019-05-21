/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月14日 11点02分
** 描   述:      著作实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_JournalEntity
    {

        /// <summary>
        /// Teacher_Journal表实体
        ///</summary>
        public Teacher_JournalEntity()
        {
        }


        /// <summary>
        /// Teacher_Journal表实体
        /// </summary>
        /// <param name="tpid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="journaltype">著作类别</param>
        /// <param name="pubdate">出版日期</param>
        /// <param name="rewardname">著作名称</param>
        /// <param name="subjectarea">学科领域</param>
        /// <param name="pubname">出版社名称</param>
        /// <param name="pubnum">出版号</param>
        /// <param name="onwernum">本人撰写字数(字)</param>
        /// <param name="totelnum">总字数(字)</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="isreport"></param>
        public Teacher_JournalEntity(string tpid, string tid, int journaltype, DateTime pubdate, string rewardname, string subjectarea, string pubname, string pubnum, int onwernum, int totelnum, int isdel, int isreport)
        {
            this.TPID = tpid;
            this.TID = tid;
            this.JournalType = journaltype;
            this.PubDate = pubdate;
            this.RewardName = rewardname;
            this.SubjectArea = subjectarea;
            this.PubName = pubname;
            this.PubNum = pubnum;
            this.OnwerNum = onwernum;
            this.TotelNum = totelnum;
            this.Isdel = isdel;
            this.IsReport = isreport;
        }

        private string tpid;//ID
        private string tid;//教师ID
        private int journaltype;//著作类别
        private DateTime pubdate;//出版日期
        private string rewardname;//著作名称
        private string subjectarea;//学科领域
        private string pubname;//出版社名称
        private string pubnum;//出版号
        private int onwernum;//本人撰写字数(字)
        private int totelnum;//总字数(字)
        private int isdel;//是否删除
        private int isreport;//上报
        private string tidName;

        public string TidName
        {
            get { return tidName; }
            set { tidName = value; }
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
        ///著作类别
        ///</summary>
        public int JournalType
        {
            get
            {
                return journaltype;
            }
            set
            {
                journaltype = value;
            }
        }

        ///<summary>
        ///出版日期
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
        ///著作名称
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
        ///学科领域
        ///</summary>
        public string SubjectArea
        {
            get
            {
                return subjectarea;
            }
            set
            {
                subjectarea = value;
            }
        }

        ///<summary>
        ///出版社名称
        ///</summary>
        public string PubName
        {
            get
            {
                return pubname;
            }
            set
            {
                pubname = value;
            }
        }

        ///<summary>
        ///出版号
        ///</summary>
        public string PubNum
        {
            get
            {
                return pubnum;
            }
            set
            {
                pubnum = value;
            }
        }

        ///<summary>
        ///本人撰写字数(字)
        ///</summary>
        public int OnwerNum
        {
            get
            {
                return onwernum;
            }
            set
            {
                onwernum = value;
            }
        }

        ///<summary>
        ///总字数(字)
        ///</summary>
        public int TotelNum
        {
            get
            {
                return totelnum;
            }
            set
            {
                totelnum = value;
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

        ///<summary>
        ///
        ///</summary>
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
    }
}

