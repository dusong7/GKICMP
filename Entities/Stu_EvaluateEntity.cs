/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月15日 05点55分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Stu_EvaluateEntity
    {

        /// <summary>
        /// Stu_Evaluate表实体
        ///</summary>
        public Stu_EvaluateEntity()
        {
        }


        /// <summary>
        /// Stu_Evaluate表实体
        /// </summary>
        /// <param name="seid">奖励ID</param>
        /// <param name="evaluate"></param>
        /// <param name="stuid">学生</param>
        /// <param name="term"></param>
        /// <param name="eyear"></param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        public Stu_EvaluateEntity(string seid, string evaluate, string stuid, int term, string eyear, string createuser, DateTime createdate)
        {
            this.SEID = seid;
            this.Evaluate = evaluate;
            this.StuID = stuid;
            this.Term = term;
            this.EYear = eyear;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private string seid;//奖励ID
        private string evaluate;//
        private string stuid;//学生
        private int term;//
        private string eyear;//
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private string studentname;

        public string StudentName
        {
            get { return studentname; }
            set { studentname = value; }
        }

        ///<summary>
        ///奖励ID
        ///</summary>
        public string SEID
        {
            get
            {
                return seid;
            }
            set
            {
                seid = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string Evaluate
        {
            get
            {
                return evaluate;
            }
            set
            {
                evaluate = value;
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
        ///
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
        ///
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

