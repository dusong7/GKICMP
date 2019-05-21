/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年10月21日 09点33分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Lesson_EvaluateEntity
    {

        /// <summary>
        /// Lesson_Evaluate表实体
        ///</summary>
        public Lesson_EvaluateEntity()
        {
        }


        /// <summary>
        /// Lesson_Evaluate表实体
        /// </summary>
        /// <param name="leid">考试科目ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="term">学期</param>
        /// <param name="evaldate">评价日期</param>
        /// <param name="evaluser">评价人</param>
        /// <param name="remark">评语</param>
        /// <param name="degree">等级</param>
        /// <param name="eyear">学年</param>
        /// <param name="isdel">是否删除</param>
        public Lesson_EvaluateEntity(string leid, string tid, int term, DateTime evaldate, string evaluser, string remark, string degree, string eyear, int isdel)
        {
            this.LEID = leid;
            this.TID = tid;
            this.Term = term;
            this.EvalDate = evaldate;
            this.EvalUser = evaluser;
            this.Remark = remark;
            this.Degree = degree;
            this.EYear = eyear;
            this.Isdel = isdel;
        }

        private string leid;//考试科目ID
        private string tid;//教师ID
        private int term;//学期
        private DateTime evaldate;//评价日期
        private string evaluser;//评价人
        private string remark;//评语
        private string degree;//等级
        private string eyear;//学年
        private int isdel;//是否删除


        ///<summary>
        ///考试科目ID
        ///</summary>
        public string LEID
        {
            get
            {
                return leid;
            }
            set
            {
                leid = value;
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
        ///评价日期
        ///</summary>
        public DateTime EvalDate
        {
            get
            {
                return evaldate;
            }
            set
            {
                evaldate = value;
            }
        }

        ///<summary>
        ///评价人
        ///</summary>
        public string EvalUser
        {
            get
            {
                return evaluser;
            }
            set
            {
                evaluser = value;
            }
        }

        ///<summary>
        ///评语
        ///</summary>
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        ///<summary>
        ///等级
        ///</summary>
        public string Degree
        {
            get
            {
                return degree;
            }
            set
            {
                degree = value;
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

