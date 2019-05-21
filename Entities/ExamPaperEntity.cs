/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年09月04日 03点33分
** 描   述:      试卷实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ExamPaperEntity
    {

        /// <summary>
        /// ExamPaper表实体
        ///</summary>
        public ExamPaperEntity()
        {
        }


        /// <summary>
        /// ExamPaper表实体
        /// </summary>
        /// <param name="epid">试卷ID</param>
        /// <param name="papername">试卷名称</param>
        /// <param name="cid">科目</param>
        /// <param name="term">学期</param>
        /// <param name="gradeid">年级</param>
        /// <param name="totelscore">满分</param>
        /// <param name="passscore">及格分</param>
        /// <param name="minutes">练习时间（分)</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        public ExamPaperEntity(string epid, string papername, int cid, int term, int gradeid, int totelscore, int passscore, int minutes, string createuser, DateTime createdate)
        {
            this.EPID = epid;
            this.PaperName = papername;
            this.CID = cid;
            this.Term = term;
            this.GradeID = gradeid;
            this.TotelScore = totelscore;
            this.PassScore = passscore;
            this.Minutes = minutes;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private string epid;//试卷ID
        private string papername;//试卷名称
        private int cid;//科目
        private int term;//学期
        private int gradeid;//年级
        private int totelscore;//满分
        private int passscore;//及格分
        private int minutes;//练习时间（分)
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private string cIDName;//课程名称
        private int eType;//生成方式

        public int EType
        {
            get { return eType; }
            set { eType = value; }
        }

        public string CIDName
        {
            get { return cIDName; }
            set { cIDName = value; }
        }


        ///<summary>
        ///试卷ID
        ///</summary>
        public string EPID
        {
            get
            {
                return epid;
            }
            set
            {
                epid = value;
            }
        }

        ///<summary>
        ///试卷名称
        ///</summary>
        public string PaperName
        {
            get
            {
                return papername;
            }
            set
            {
                papername = value;
            }
        }

        ///<summary>
        ///科目
        ///</summary>
        public int CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
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
        ///年级
        ///</summary>
        public int GradeID
        {
            get
            {
                return gradeid;
            }
            set
            {
                gradeid = value;
            }
        }

        ///<summary>
        ///满分
        ///</summary>
        public int TotelScore
        {
            get
            {
                return totelscore;
            }
            set
            {
                totelscore = value;
            }
        }

        ///<summary>
        ///及格分
        ///</summary>
        public int PassScore
        {
            get
            {
                return passscore;
            }
            set
            {
                passscore = value;
            }
        }

        ///<summary>
        ///练习时间（分)
        ///</summary>
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
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
    }
}

