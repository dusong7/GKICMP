/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年10月12日 04点56分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Stu_QualityEntity
    {

        /// <summary>
        /// Stu_Quality表实体
        ///</summary>
        public Stu_QualityEntity()
        {
        }


        /// <summary>
        /// Stu_Quality表实体
        /// </summary>
        /// <param name="sqid">评价ID</param>
        /// <param name="sxdd">思想道德</param>
        /// <param name="qfxx">勤奋学习</param>
        /// <param name="stsz">身体素质</param>
        /// <param name="smsmnl">审美塑美能力</param>
        /// <param name="shldjn">生活劳动技能</param>
        /// <param name="czjscznl">创造精神创造能力</param>
        /// <param name="pre1">预览字段1</param>
        /// <param name="pre2">预留字段2</param>
        /// <param name="term">学期</param>
        /// <param name="eyear">学年</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        public Stu_QualityEntity(string sqid, string sxdd, string qfxx, string stsz, string smsmnl, string shldjn, string czjscznl, string pre1, string pre2, int term, string eyear, string createuser, DateTime createdate)
        {
            this.SQID = sqid;
            this.SXDD = sxdd;
            this.QFXX = qfxx;
            this.STSZ = stsz;
            this.SMSMNL = smsmnl;
            this.SHLDJN = shldjn;
            this.CZJSCZNL = czjscznl;
            this.Pre1 = pre1;
            this.Pre2 = pre2;
            this.Term = term;
            this.EYear = eyear;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private string sqid;//评价ID
        private string sxdd;//思想道德
        private string qfxx;//勤奋学习
        private string stsz;//身体素质
        private string smsmnl;//审美塑美能力
        private string shldjn;//生活劳动技能
        private string czjscznl;//创造精神创造能力
        private string pre1;//预览字段1
        private string pre2;//预留字段2
        private int term;//学期
        private string eyear;//学年
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        public string StID { get; set; }
        public string StuName { get; set; }

        ///<summary>
        ///评价ID
        ///</summary>
        public string SQID
        {
            get
            {
                return sqid;
            }
            set
            {
                sqid = value;
            }
        }

        ///<summary>
        ///思想道德
        ///</summary>
        public string SXDD
        {
            get
            {
                return sxdd;
            }
            set
            {
                sxdd = value;
            }
        }

        ///<summary>
        ///勤奋学习
        ///</summary>
        public string QFXX
        {
            get
            {
                return qfxx;
            }
            set
            {
                qfxx = value;
            }
        }

        ///<summary>
        ///身体素质
        ///</summary>
        public string STSZ
        {
            get
            {
                return stsz;
            }
            set
            {
                stsz = value;
            }
        }

        ///<summary>
        ///审美塑美能力
        ///</summary>
        public string SMSMNL
        {
            get
            {
                return smsmnl;
            }
            set
            {
                smsmnl = value;
            }
        }

        ///<summary>
        ///生活劳动技能
        ///</summary>
        public string SHLDJN
        {
            get
            {
                return shldjn;
            }
            set
            {
                shldjn = value;
            }
        }

        ///<summary>
        ///创造精神创造能力
        ///</summary>
        public string CZJSCZNL
        {
            get
            {
                return czjscznl;
            }
            set
            {
                czjscznl = value;
            }
        }

        ///<summary>
        ///预览字段1
        ///</summary>
        public string Pre1
        {
            get
            {
                return pre1;
            }
            set
            {
                pre1 = value;
            }
        }

        ///<summary>
        ///预留字段2
        ///</summary>
        public string Pre2
        {
            get
            {
                return pre2;
            }
            set
            {
                pre2 = value;
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

