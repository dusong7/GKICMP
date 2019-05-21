/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年12月01日 02点56分
** 描   述:      我的答题实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ExamPaper_EeStuEntity
    {

        /// <summary>
        /// ExamPaper_EeStu表实体
        ///</summary>
        public ExamPaper_EeStuEntity()
        {
        }


        /// <summary>
        /// ExamPaper_EeStu表实体
        /// </summary>
        /// <param name="epeid">ID</param>
        /// <param name="eid">题目ID</param>
        /// <param name="epid">试卷ID</param>
        /// <param name="eppid">练习ID</param>
        /// <param name="eanswer">答案</param>
        /// <param name="escore">得分</param>
        /// <param name="stuid">学生</param>
        public ExamPaper_EeStuEntity(int epeid, int eid, string epid, string eppid, string eanswer, decimal escore, string stuid)
        {
            this.EPEID = epeid;
            this.EID = eid;
            this.EPID = epid;
            this.EPPID = eppid;
            this.EAnswer = eanswer;
            this.EScore = escore;
            this.StuID = stuid;
        }

        private int epeid;//ID
        private int eid;//题目ID
        private string epid;//试卷ID
        private string eppid;//练习ID
        private string eanswer;//答案
        private decimal escore;//得分
        private string stuid;//学生
        private string stuIDName;//姓名

        public string StuIDName
        {
            get { return stuIDName; }
            set { stuIDName = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public int EPEID
        {
            get
            {
                return epeid;
            }
            set
            {
                epeid = value;
            }
        }

        ///<summary>
        ///题目ID
        ///</summary>
        public int EID
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
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
        ///练习ID
        ///</summary>
        public string EPPID
        {
            get
            {
                return eppid;
            }
            set
            {
                eppid = value;
            }
        }

        ///<summary>
        ///答案
        ///</summary>
        public string EAnswer
        {
            get
            {
                return eanswer;
            }
            set
            {
                eanswer = value;
            }
        }

        ///<summary>
        ///得分
        ///</summary>
        public decimal EScore
        {
            get
            {
                return escore;
            }
            set
            {
                escore = value;
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
    }
}

