/*****************************************************************
** Copyright (c) 芜湖易通信息技术有限公司
** 创 建 人:      ygb
** 创建日期:      2017年03月01日 04点51分
** 描   述:      教师基础信息类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class TeacherEntity
    {

        /// <summary>
        /// Teacher表实体
        ///</summary>
        public TeacherEntity()
        {
        }

        private string tid;//教师ID
        private string realname;//姓名
        private string oldname;//曾用名
        private int tsex;//性别
        private string teachercode;//教职工号
        private string nationality;//国籍/地区
        private int cardtype;//身份证件类型
        private string idcardnum;//身份证件号
        private DateTime birthday;//出生日期
        private string placeorigin;//籍贯
        private string onenative;//出生地
        private int maritalstatus;//婚姻状况
        private int healthstatus;//健康状况
        private DateTime joddate;//参加工作年月
        private DateTime joinschool;//进本校年月
        private int teasource;//教职工来源
        private int teatype;//教职工类别
        private int isseries;//是否在编
        private int employmenttype;//用人形式
        private int contractstate;//签订合同情况
        private int isfulltime;//是否全日制师范类专业毕业
        private int isspecialtrain;//是否受过特教专业培养培训
        private int isspecialedu;//是否有特殊教育从业证书
        private int informationlevel;//信息技术应用能力
        private int isteastu;//是否属于免费(公费)师范生
        private int isgrassservice;//是否参加基层服务项目
        private DateTime grassstartdate;//参加基层服务项目起始年月
        private DateTime grassenddate;//参加基层服务项目起始年月
        private int iscountylevel;//是否县级及以上骨干教师
        private int ishealthteahcer;//是否心理健康教育教师
        private int teastate;//人员状态
        private string photos;//照片
        //private int maincourse;//主教学科
        private int aduitstate;//审核状态
        private int tnation;//民族
        private int politics;//政治面貌
        private DateTime createdate;//录入时间
        private string createuser;//录入人
        private int isdel;//是否删除
        private int isspecialtea;//是否特级教师
        private string otherlink;//其他联系方式
        private string teaaddress;//通讯地址
        private string email;//
        private string cellphone;//手机
        private string linkphone;//联系电话
        private int isreport;

        private int cid;//校区
        private DateTime partytme;//入党时间
        private string postrole;//职务角色
        private string postname;//职务角色名称
        private int salarygrade;//薪级
        private int currentprofessional;//专业技术职称
        private int gradetype;//专业技术岗位等级分类
        private int professgrade;//专业技术岗位等级
        private int isfull;//是否专任教

       
        //private int Section;//学段
        //private int IsTea;//是否教学岗位
        //private DateTime GradeDate;//专业技术职务岗位聘用时间
        //private int IsRetire;//是否退休


        public string CName { get; set; }

        /// <summary>
        /// 学段
        /// </summary>
        public int Section { get; set; }
        /// <summary>
        /// 是否教学岗
        /// </summary>
        public int IsTea { get; set; }
        /// <summary>
        /// 专业技术职务岗位聘用时间
        /// </summary>
        public DateTime GradeDate { get; set; }
        /// <summary>
        /// 教师资格证首次注册时间
        /// </summary>
        public DateTime TeaQualRegDate { get; set; }
        /// <summary>
        /// 教师资格证取得时间
        /// </summary>
        public DateTime TeaQualDate { get; set; }
        /// <summary>
        /// 教师资格证编号
        /// </summary>
        public string TeaQualCode { get; set; }
        /// <summary>
        /// 教师资格证类型
        /// </summary>
        public int TeaQualiType { get; set; }
        /// <summary>
        /// 教师资格证学科
        /// </summary>
        public int TeaQualCourse { get; set; }

        public string TeaQualCourseName { get; set; }
        /// <summary>
        /// 普通话水平
        /// </summary>
        public int Mandarin { get; set; }
        /// <summary>
        /// 是否退休
        /// </summary>
        public int IsRetire { get; set; }
       
        /// <summary>
        /// 是否专任教
        /// </summary>
        public int IsFull
        {
            get { return isfull; }
            set { isfull = value; }
        }
        public string ProfessGradeName { get; set; }
        /// <summary>
        /// 薪级
        /// </summary>
        public int SalaryGrade
        {
            get
            {
                return salarygrade;
            }
            set
            {
                salarygrade = value;
            }
        }

        /// <summary>
        /// 专业技术职称
        /// </summary>
        public int CurrentProfessional
        {
            get
            {
                return currentprofessional;
            }
            set
            {
                currentprofessional = value;
            }
        }

        /// <summary>
        /// 专业技术岗位等级分类
        /// </summary>
        public int GradeType
        {
            get
            {
                return gradetype;
            }
            set
            {
                gradetype = value;
            }
        }

        /// <summary>
        /// 专业技术岗位等级
        /// </summary>
        public int ProfessGrade
        {
            get
            {
                return professgrade;
            }
            set
            {
                professgrade = value;
            }
        }

        public string PostName
        {
            get
            {
                return postname;
            }
            set
            {
                postname = value;
            }
        }

        /// <summary>
        /// 入党时间
        /// </summary>
        public DateTime PartyTme
        {
            get
            {
                return partytme;
            }
            set
            {
                partytme = value;
            }
        }

        /// <summary>
        /// 职务角色
        /// </summary>
        public string PostRole
        {
            get
            {
                return postrole;
            }
            set
            {
                postrole = value;
            }
        }

        /// <summary>
        /// 教授科目
        /// </summary>
        public int TCourse { get; set; }
        /// <summary>
        /// 校区
        /// </summary>
        public int CID
        {
            get { return cid; }
            set { cid = value; }
        }
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

        /// <summary>
        /// 通讯地址
        /// </summary>
        public string TeaAddress
        {
            get { return teaaddress; }
            set { teaaddress = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone
        {
            get { return linkphone; }
            set { linkphone = value; }
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string CellPhone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        /// <summary>
        /// 其他联系方式
        /// </summary>
        public string OtherLink
        {
            get { return otherlink; }
            set { otherlink = value; }
        }
        /// <summary>
        /// 是否特级教师
        /// </summary>
        public int IsSpecialTea
        {
            get { return isspecialtea; }
            set { isspecialtea = value; }
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
        ///姓名
        ///</summary>
        public string RealName
        {
            get
            {
                return realname;
            }
            set
            {
                realname = value;
            }
        }

        ///<summary>
        ///曾用名
        ///</summary>
        public string OldName
        {
            get
            {
                return oldname;
            }
            set
            {
                oldname = value;
            }
        }

        ///<summary>
        ///性别
        ///</summary>
        public int TSex
        {
            get
            {
                return tsex;
            }
            set
            {
                tsex = value;
            }
        }

        ///<summary>
        ///教职工号
        ///</summary>
        public string TeacherCode
        {
            get
            {
                return teachercode;
            }
            set
            {
                teachercode = value;
            }
        }

        ///<summary>
        ///国籍/地区
        ///</summary>
        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
            }
        }

        ///<summary>
        ///身份证件类型
        ///</summary>
        public int CardType
        {
            get
            {
                return cardtype;
            }
            set
            {
                cardtype = value;
            }
        }

        ///<summary>
        ///身份证件号
        ///</summary>
        public string IDCardNum
        {
            get
            {
                return idcardnum;
            }
            set
            {
                idcardnum = value;
            }
        }

        ///<summary>
        ///出生日期
        ///</summary>
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        ///<summary>
        ///籍贯
        ///</summary>
        public string PlaceOrigin
        {
            get
            {
                return placeorigin;
            }
            set
            {
                placeorigin = value;
            }
        }

        ///<summary>
        ///出生地
        ///</summary>
        public string OneNative
        {
            get
            {
                return onenative;
            }
            set
            {
                onenative = value;
            }
        }

        ///<summary>
        ///婚姻状况
        ///</summary>
        public int MaritalStatus
        {
            get
            {
                return maritalstatus;
            }
            set
            {
                maritalstatus = value;
            }
        }

        ///<summary>
        ///健康状况
        ///</summary>
        public int HealthStatus
        {
            get
            {
                return healthstatus;
            }
            set
            {
                healthstatus = value;
            }
        }

        ///<summary>
        ///参加工作年月
        ///</summary>
        public DateTime JodDate
        {
            get
            {
                return joddate;
            }
            set
            {
                joddate = value;
            }
        }

        ///<summary>
        ///进本校年月
        ///</summary>
        public DateTime JoinSchool
        {
            get
            {
                return joinschool;
            }
            set
            {
                joinschool = value;
            }
        }

        ///<summary>
        ///教职工来源
        ///</summary>
        public int TeaSource
        {
            get
            {
                return teasource;
            }
            set
            {
                teasource = value;
            }
        }

        ///<summary>
        ///教职工类别
        ///</summary>
        public int TeaType
        {
            get
            {
                return teatype;
            }
            set
            {
                teatype = value;
            }
        }

        ///<summary>
        ///是否在编
        ///</summary>
        public int IsSeries
        {
            get
            {
                return isseries;
            }
            set
            {
                isseries = value;
            }
        }

        ///<summary>
        ///用人形式
        ///</summary>
        public int EmploymentType
        {
            get
            {
                return employmenttype;
            }
            set
            {
                employmenttype = value;
            }
        }

        ///<summary>
        ///签订合同情况
        ///</summary>
        public int ContractState
        {
            get
            {
                return contractstate;
            }
            set
            {
                contractstate = value;
            }
        }

        ///<summary>
        ///是否全日制师范类专业毕业
        ///</summary>
        public int IsFulltime
        {
            get
            {
                return isfulltime;
            }
            set
            {
                isfulltime = value;
            }
        }

        ///<summary>
        ///是否受过特教专业培养培训
        ///</summary>
        public int IsSpecialTrain
        {
            get
            {
                return isspecialtrain;
            }
            set
            {
                isspecialtrain = value;
            }
        }

        ///<summary>
        ///是否有特殊教育从业证书
        ///</summary>
        public int IsSpecialEdu
        {
            get
            {
                return isspecialedu;
            }
            set
            {
                isspecialedu = value;
            }
        }

        ///<summary>
        ///信息技术应用能力
        ///</summary>
        public int InformationLevel
        {
            get
            {
                return informationlevel;
            }
            set
            {
                informationlevel = value;
            }
        }

        ///<summary>
        ///是否属于免费(公费)师范生
        ///</summary>
        public int IsTeaStu
        {
            get
            {
                return isteastu;
            }
            set
            {
                isteastu = value;
            }
        }

        ///<summary>
        ///是否参加基层服务项目
        ///</summary>
        public int IsGrassService
        {
            get
            {
                return isgrassservice;
            }
            set
            {
                isgrassservice = value;
            }
        }

        ///<summary>
        ///参加基层服务项目起始年月
        ///</summary>
        public DateTime GrassStartDate
        {
            get
            {
                return grassstartdate;
            }
            set
            {
                grassstartdate = value;
            }
        }

        ///<summary>
        ///参加基层服务项目起始年月
        ///</summary>
        public DateTime GrassEndDate
        {
            get
            {
                return grassenddate;
            }
            set
            {
                grassenddate = value;
            }
        }

        ///<summary>
        ///是否县级及以上骨干教师
        ///</summary>
        public int IsCountyLevel
        {
            get
            {
                return iscountylevel;
            }
            set
            {
                iscountylevel = value;
            }
        }

        ///<summary>
        ///是否心理健康教育教师
        ///</summary>
        public int IsHealthTeahcer
        {
            get
            {
                return ishealthteahcer;
            }
            set
            {
                ishealthteahcer = value;
            }
        }

        ///<summary>
        ///人员状态
        ///</summary>
        public int TeaState
        {
            get
            {
                return teastate;
            }
            set
            {
                teastate = value;
            }
        }

        ///<summary>
        ///照片
        ///</summary>
        public string Photos
        {
            get
            {
                return photos;
            }
            set
            {
                photos = value;
            }
        }

        //public int MainCourse
        //{
        //    get
        //    {
        //        return maincourse;
        //    }
        //    set
        //    {
        //        maincourse = value;
        //    }
        //}

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
        ///民族
        ///</summary>
        public int TNation
        {
            get
            {
                return tnation;
            }
            set
            {
                tnation = value;
            }
        }

        ///<summary>
        ///政治面貌
        ///</summary>
        public int Politics
        {
            get
            {
                return politics;
            }
            set
            {
                politics = value;
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
        ///是否删除
        ///</summary>
        public int IsDel
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

