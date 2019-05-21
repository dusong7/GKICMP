/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月19日 03点24分
** 描   述:      备课计划实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LessonPlanEntity
    {

        /// <summary>
        /// LessonPlan表实体
        ///</summary>
        public LessonPlanEntity()
        {
        }


        /// <summary>
        /// LessonPlan表实体
        /// </summary>
        /// <param name="lid"></param>
        /// <param name="lname"></param>
        /// <param name="lyear"></param>
        /// <param name="tid"></param>
        /// <param name="cid"></param>
        /// <param name="ltype"></param>
        /// <param name="createuser"></param>
        /// <param name="createdate"></param>
        public LessonPlanEntity(string lname, int cid, int ltype)
        {
            this.LName = lname;
            this.CID = cid;
            this.LType = ltype;
        }

        private string lid;//计划ID
        private string lname;//计划名称
        private string lyear;//学年
        private int tid;//学期
        private int cid;//校区
        private int ltype;//类型
        private string createuser;//录入人
        private string createusername;//录入人姓名
        private DateTime createdate;//录入时间
        private string teachids;//执教教师集合

        public string CampusName { get; set; }//校区名称
        public string TypeName { get; set; }//课程类型
        public string TeacherName { get; set; }//执教教师

        /// <summary>
        /// 录入人姓名
        /// </summary>
        public string CreateUserName
        {
            get
            {
                return createusername;
            }
            set
            {
                createusername = value;
            }
        }

        /// <summary>
        /// 执教教师集合
        /// </summary>
        public string TeachIDS
        {
            get { return teachids; }
            set { teachids = value; }
        }


        ///<summary>
        ///计划ID
        ///</summary>
        public string LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }

        ///<summary>
        ///计划名称
        ///</summary>
        public string LName
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }

        ///<summary>
        ///学年
        ///</summary>
        public string LYear
        {
            get
            {
                return lyear;
            }
            set
            {
                lyear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int TID
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
        ///校区
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
        ///类型
        ///</summary>
        public int LType
        {
            get
            {
                return ltype;
            }
            set
            {
                ltype = value;
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
        ///录入日期
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

