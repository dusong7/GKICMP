/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年03月03日 06点12分
** 描   述:      学历实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_EducationEntity
    {

        /// <summary>
        /// Teacher_Education表实体
        ///</summary>
        public Teacher_EducationEntity()
        {
        }


        /// <summary>
        /// Teacher_Education表实体
        /// </summary>
        /// <param name="teid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="education">获得学历</param>
        /// <param name="educountry">获得学历的国家(地区)</param>
        /// <param name="eduschool">获得学历的院校或机构</param>
        /// <param name="emajor">所学专业</param>
        /// <param name="isteach">是否师范类专业</param>
        /// <param name="indate">入学年月</param>
        /// <param name="outdate">毕业年月</param>
        /// <param name="degreelevel">学位层次</param>
        /// <param name="degreename">学位名称</param>
        /// <param name="gradecountry">获得学位的国家(地区)</param>
        /// <param name="gradeschool">获得学位的院校或机构</param>
        /// <param name="grantdate">学位授予年月</param>
        /// <param name="studytype">学习方式</param>
        /// <param name="companytype">在学单位类别</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建日期</param>
        /// <param name="aduitstate">审核状态</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_EducationEntity(string teid, string tid, int education, int educountry, string eduschool, string emajor, int isteach, DateTime indate, DateTime outdate, int degreelevel, int degreename, int gradecountry, string gradeschool, DateTime grantdate, int studytype, int companytype, string createuser, DateTime createdate, int aduitstate, int isdel)
        {
            this.TEID = teid;
            this.TID = tid;
            this.Education = education;
            this.EduCountry = educountry;
            this.EduSchool = eduschool;
            this.EMajor = emajor;
            this.IsTeach = isteach;
            this.InDate = indate;
            this.OutDate = outdate;
            this.DegreeLevel = degreelevel;
            this.DegreeName = degreename;
            this.GradeCountry = gradecountry;
            this.GradeSchool = gradeschool;
            this.GrantDate = grantdate;
            this.StudyType = studytype;
            this.CompanyType = companytype;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.AduitState = aduitstate;
            this.Isdel = isdel;
        }

        private string teid;//ID
        private string tid;//教师ID
        private int education;//获得学历
        private int educountry;//获得学历的国家(地区)
        private string eduschool;//获得学历的院校或机构
        private string emajor;//所学专业
        private int isteach;//是否师范类专业
        private DateTime indate;//入学年月
        private DateTime outdate;//毕业年月
        private int degreelevel;//学位层次
        private int degreename;//学位名称
        private int gradecountry;//获得学位的国家(地区)
        private string gradeschool;//获得学位的院校或机构
        private DateTime grantdate;//学位授予年月
        private int studytype;//学习方式
        private int companytype;//在学单位类别
        private string createuser;//创建人
        private DateTime createdate;//创建日期
        private int aduitstate;//审核状态
        private int isdel;//是否删除
        private int isreport;//是否上报
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

        private string tname;
        public string TName
        {
            get
            {
                return tname;
            }
            set
            {
                tname = value;
            }
        }

        private DateTime begin;
        private DateTime end;
         public DateTime Begin
         {
             get
             {
                 return begin;
             }
             set
             {
                 begin = value;
             }
         }
         public DateTime End
         {
             get
             {
                 return end;
             }
             set
             {
                 end = value;
             }
         }

        ///<summary>
        ///ID
        ///</summary>
        public string TEID
        {
            get
            {
                return teid;
            }
            set
            {
                teid = value;
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
        ///获得学历
        ///</summary>
        public int Education
        {
            get
            {
                return education;
            }
            set
            {
                education = value;
            }
        }

        ///<summary>
        ///获得学历的国家(地区)
        ///</summary>
        public int EduCountry
        {
            get
            {
                return educountry;
            }
            set
            {
                educountry = value;
            }
        }

        ///<summary>
        ///获得学历的院校或机构
        ///</summary>
        public string EduSchool
        {
            get
            {
                return eduschool;
            }
            set
            {
                eduschool = value;
            }
        }

        ///<summary>
        ///所学专业
        ///</summary>
        public string EMajor
        {
            get
            {
                return emajor;
            }
            set
            {
                emajor = value;
            }
        }

        ///<summary>
        ///是否师范类专业
        ///</summary>
        public int IsTeach
        {
            get
            {
                return isteach;
            }
            set
            {
                isteach = value;
            }
        }

        ///<summary>
        ///入学年月
        ///</summary>
        public DateTime InDate
        {
            get
            {
                return indate;
            }
            set
            {
                indate = value;
            }
        }

        ///<summary>
        ///毕业年月
        ///</summary>
        public DateTime OutDate
        {
            get
            {
                return outdate;
            }
            set
            {
                outdate = value;
            }
        }

        ///<summary>
        ///学位层次
        ///</summary>
        public int DegreeLevel
        {
            get
            {
                return degreelevel;
            }
            set
            {
                degreelevel = value;
            }
        }

        ///<summary>
        ///学位名称
        ///</summary>
        public int DegreeName
        {
            get
            {
                return degreename;
            }
            set
            {
                degreename = value;
            }
        }

        ///<summary>
        ///获得学位的国家(地区)
        ///</summary>
        public int GradeCountry
        {
            get
            {
                return gradecountry;
            }
            set
            {
                gradecountry = value;
            }
        }

        ///<summary>
        ///获得学位的院校或机构
        ///</summary>
        public string GradeSchool
        {
            get
            {
                return gradeschool;
            }
            set
            {
                gradeschool = value;
            }
        }

        ///<summary>
        ///学位授予年月
        ///</summary>
        public DateTime GrantDate
        {
            get
            {
                return grantdate;
            }
            set
            {
                grantdate = value;
            }
        }

        ///<summary>
        ///学习方式
        ///</summary>
        public int StudyType
        {
            get
            {
                return studytype;
            }
            set
            {
                studytype = value;
            }
        }

        ///<summary>
        ///在学单位类别
        ///</summary>
        public int CompanyType
        {
            get
            {
                return companytype;
            }
            set
            {
                companytype = value;
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
        ///审核状态
        ///</summary>
        public int AduitState
        {
            get
            {
                return aduitstate;
            }
            set
            {
                aduitstate = value;
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

