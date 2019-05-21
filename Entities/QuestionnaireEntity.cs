/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年02月10日 02点10分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class QuestionnaireEntity
    {

        /// <summary>
        /// Questionnaire表实体
        ///</summary>
        public QuestionnaireEntity()
        {
        }


        /// <summary>
        /// Questionnaire表实体
        /// </summary>
        /// <param name="qid">ID</param>
        /// <param name="questname">问卷名称</param>
        /// <param name="questxplain">投票说明</param>
        /// <param name="isrealname">是否实名</param>
        /// <param name="lastdate">截止日期</param>
        /// <param name="qestcrowd">投票人群</param>
        /// <param name="ispublish">立即发布</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建日期</param>
        /// <param name="isdel">是否删除</param>
        public QuestionnaireEntity(string qid, string questname, string questxplain, int isrealname, DateTime lastdate, string qestcrowd, int ispublish, string createuser, DateTime createdate, int isdel)
        {
            this.QID = qid;
            this.QuestName = questname;
            this.Questxplain = questxplain;
            this.IsRealName = isrealname;
            this.LastDate = lastdate;
            this.QestCrowd = qestcrowd;
            this.IsPublish = ispublish;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string qid;//ID
        private string questname;//问卷名称
        private string questxplain;//投票说明
        private int isrealname;//是否实名
        private DateTime lastdate;//截止日期
        private string qestcrowd;//投票人群
        private int ispublish;//立即发布
        private string createuser;//创建人
        private DateTime createdate;//创建日期
        private int isdel;//是否删除
        private string createusername;

        /// <summary>
        /// 姓名
        /// </summary>
        public string CreateUserName
        {
            get { return createusername; }
            set { createusername = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string QID
        {
            get
            {
                return qid;
            }
            set
            {
                qid = value;
            }
        }

        ///<summary>
        ///问卷名称
        ///</summary>
        public string QuestName
        {
            get
            {
                return questname;
            }
            set
            {
                questname = value;
            }
        }

        ///<summary>
        ///投票说明
        ///</summary>
        public string Questxplain
        {
            get
            {
                return questxplain;
            }
            set
            {
                questxplain = value;
            }
        }

        ///<summary>
        ///是否实名
        ///</summary>
        public int IsRealName
        {
            get
            {
                return isrealname;
            }
            set
            {
                isrealname = value;
            }
        }

        ///<summary>
        ///截止日期
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
        ///投票人群
        ///</summary>
        public string QestCrowd
        {
            get
            {
                return qestcrowd;
            }
            set
            {
                qestcrowd = value;
            }
        }

        ///<summary>
        ///立即发布
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
        ///创建人
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
        ///创建日期
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
