/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月15日 10点00分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_ClassHourEntity
    {

        /// <summary>
        /// Teacher_ClassHour表实体
        ///</summary>
        public Teacher_ClassHourEntity()
        {
        }
        public Teacher_ClassHourEntity(string realname, string mainsubject,  int isdel)
        {
            this.RealName = realname;
            this.MainSubject = mainsubject;
            //this.DepID = depid;
            this.Isdel = isdel;
        }

        /// <summary>
        /// Teacher_ClassHour表实体
        /// </summary>
        /// <param name="thid">课时ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="gradeid">所授年级</param>
        /// <param name="mainsubject">主教科目</param>
        /// <param name="mainhours">纯课时数</param>
        /// <param name="partsubject">兼教学科</param>
        /// <param name="parthours">兼课时</param>
        /// <param name="totelhours">合计</param>
        /// <param name="subdesc">语文、数学、英语跨教情况</param>
        /// <param name="executive">任行政j教辅或班主任课时数</param>
        /// <param name="schoolyear">学年度</param>
        /// <param name="semester">学期</param>
        /// <param name="createdate">上报时间</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="thdesc">备注</param>
        public Teacher_ClassHourEntity(string thid, string tid, int gradeid, string mainsubject, int mainhours, string partsubject, int parthours, int totelhours, string subdesc, int executive, string schoolyear, int semester, DateTime createdate, int isdel, string thdesc)
        {
            this.THID = thid;
            this.TID = tid;
            this.GradeID = gradeid;
            this.MainSubject = mainsubject;
            this.MainHours = mainhours;
            this.PartSubject = partsubject;
            this.PartHours = parthours;
            this.TotelHours = totelhours;
            this.SubDesc = subdesc;
            this.Executive = executive;
            this.SchoolYear = schoolyear;
            this.Semester = semester;
            this.CreateDate = createdate;
            this.Isdel = isdel;
            this.THDesc = thdesc;
        }

        private string thid;//课时ID
        private string tid;//教师ID
        private int gradeid;//所授年级
        private string mainsubject;//主教科目
        private int mainhours;//纯课时数
        private string partsubject;//兼教学科
        private int parthours;//兼课时
        private int totelhours;//合计
        private string subdesc;//语文、数学、英语跨教情况
        private int executive;//任行政j教辅或班主任课时数
        private string schoolyear;//学年度
        private int semester;//学期
        private DateTime createdate;//上报时间
        private int isdel;//是否删除
        private string thdesc;//备注
        private string realrname;
        private string idcard;//教师身份证号码
        private int depid;
        private int isreport; //IsReport
        public int IsReport
        {
            get { return isreport; }
            set { isreport = value; }
        }
        /// <summary>
        /// 教师身份证号码
        /// </summary>
        public string IDCard
        {
            get { return idcard; }
            set { idcard = value; }
        }
        public string RealName
        {
            get { return realrname; }
            set { realrname = value; }
        }

        public int DepID
        {
            get { return depid; }
            set { depid = value; }
        }
        ///<summary>
        ///课时ID
        ///</summary>
        public string THID
        {
            get
            {
                return thid;
            }
            set
            {
                thid = value;
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
        ///所授年级
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
        ///主教科目
        ///</summary>
        public string MainSubject
        {
            get
            {
                return mainsubject;
            }
            set
            {
                mainsubject = value;
            }
        }

        ///<summary>
        ///纯课时数
        ///</summary>
        public int MainHours
        {
            get
            {
                return mainhours;
            }
            set
            {
                mainhours = value;
            }
        }

        ///<summary>
        ///兼教学科
        ///</summary>
        public string PartSubject
        {
            get
            {
                return partsubject;
            }
            set
            {
                partsubject = value;
            }
        }

        ///<summary>
        ///兼课时
        ///</summary>
        public int PartHours
        {
            get
            {
                return parthours;
            }
            set
            {
                parthours = value;
            }
        }

        ///<summary>
        ///合计
        ///</summary>
        public int TotelHours
        {
            get
            {
                return totelhours;
            }
            set
            {
                totelhours = value;
            }
        }

        ///<summary>
        ///语文、数学、英语跨教情况
        ///</summary>
        public string SubDesc
        {
            get
            {
                return subdesc;
            }
            set
            {
                subdesc = value;
            }
        }

        ///<summary>
        ///任行政j教辅或班主任课时数
        ///</summary>
        public int Executive
        {
            get
            {
                return executive;
            }
            set
            {
                executive = value;
            }
        }

        ///<summary>
        ///学年度
        ///</summary>
        public string SchoolYear
        {
            get
            {
                return schoolyear;
            }
            set
            {
                schoolyear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
            }
        }

        ///<summary>
        ///上报时间
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

        ///<summary>
        ///备注
        ///</summary>
        public string THDesc
        {
            get
            {
                return thdesc;
            }
            set
            {
                thdesc = value;
            }
        }
    }
}

