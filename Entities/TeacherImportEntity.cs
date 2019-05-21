using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class TeacherImportEntity
    {
       public TeacherImportEntity() { }
       public string TID { get; set; }//教师ID
       public string RealName { get; set; }//姓名
       public string OldName { get; set; }//曾用名
       public int Sex { get; set; }//性别
       public string TeacherCode { get; set; }//教职工号
       public string Nationality { get; set; }//国籍/地区
       public int CardType { get; set; }//身份证件类型
       public string IdCardNum { get; set; }//身份证件号
       public DateTime Birthday { get; set; }//出生日期
       public string Placeorigin { get; set; }//籍贯
       public string Onenative { get; set; }//出生地
       public int Maritalstatus { get; set; }//婚姻状况
       public int Healthstatus { get; set; }//健康状况
       public DateTime JodDate { get; set; }//参加工作年月
       public DateTime JoinSchool { get; set; }//进本校年月
       public int TeaSource { get; set; }//教职工来源
       public int TeaType { get; set; }//教职工类别
       public int Isseries { get; set; }//是否在编
       public int EmploymentType { get; set; }//用人形式
       public int ContractState { get; set; }//签订合同情况
       public int Isfulltime { get; set; }//是否全日制师范类专业毕业
       public int Isspecialtrain { get; set; }//是否受过特教专业培养培训
       public int Isspecialedu { get; set; }//是否有特殊教育从业证书
       public int Informationlevel { get; set; }//信息技术应用能力
       public int Isteastu { get; set; }//是否属于免费(公费)师范生
       public int Isgrassservice { get; set; }//是否参加基层服务项目
       public DateTime Grassstartdate { get; set; }//参加基层服务项目起始年月
       public DateTime Grassenddate { get; set; }//参加基层服务项目起始年月
       public int Iscountylevel { get; set; }//是否县级及以上骨干教师
       public int Ishealthteahcer { get; set; }//是否心理健康教育教师
       public int TeaState { get; set; }//人员状态
       public string Photos { get; set; }//照片
       public int Aduitstate { get; set; }//审核状态
       public int Tnation { get; set; }//民族
       public int Politics { get; set; }//政治面貌
       public DateTime Createdate { get; set; }//录入时间
       public string Createuser { get; set; }//录入人
       public int Isdel { get; set; }//是否删除
       public int Isspecialtea { get; set; }//是否特级教师
       public string Otherlink { get; set; }//其他联系方式
       public string Teaaddress { get; set; }//通讯地址
       public string email { get; set; }//
       public string cellphone { get; set; }//手机
       public string linkphone { get; set; }//联系电话
       public int isreport { get; set; }
       public int cid { get; set; }//校区
       public DateTime partytme { get; set; }
       public string postrole { get; set; }
       public string postname { get; set; }
       public int salarygrade { get; set; }
       public int currentprofessional { get; set; }
       public int gradetype { get; set; }
       public int professgrade { get; set; }
    }
}
