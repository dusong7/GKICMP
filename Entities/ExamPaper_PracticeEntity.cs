/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年11月30日 09点18分
** 描   述:      发布练习实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ExamPaper_PracticeEntity
    {

        /// <summary>
        /// ExamPaper_Practice表实体
        ///</summary>
        public ExamPaper_PracticeEntity()
        {
        }


        /// <summary>
        /// ExamPaper_Practice表实体
        /// </summary>
        /// <param name="eppid">练习ID</param>
        /// <param name="epid">试卷ID</param>
        /// <param name="excdesc">练习要求</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="createuser">录入人</param>
        /// <param name="completedate">完成时间</param>
        /// <param name="isdel">是否删除</param>
        public ExamPaper_PracticeEntity(string eppid, string epid, string excdesc, DateTime createdate, string createuser, DateTime completedate, int isdel)
        {
            this.EPPID = eppid;
            this.EPID = epid;
            this.ExcDesc = excdesc;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.CompleteDate = completedate;
            this.Isdel = isdel;
        }

        private string eppid;//练习ID
        private string epid;//试卷ID
        private string excdesc;//练习要求
        private DateTime createdate;//录入时间
        private string createuser;//录入人
        private DateTime completedate;//完成时间
        private int isdel;//是否删除
        private string createUserName;//录入人

        public string CreateUserName
        {
            get { return createUserName; }
            set { createUserName = value; }
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
        ///练习要求
        ///</summary>
        public string ExcDesc
        {
            get
            {
                return excdesc;
            }
            set
            {
                excdesc = value;
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
        ///完成时间
        ///</summary>
        public DateTime CompleteDate
        {
            get
            {
                return completedate;
            }
            set
            {
                completedate = value;
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

