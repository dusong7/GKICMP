/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年01月22日 13时43分25秒
** 描    述:      教师管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.teachermanage
{
    public partial class TeacherManages : PageBase
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public string Role = "";
      

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_TSex, "-2");
                CommonFunction.BindEnum<CommonEnum.ZZMM>(this.ddl_Politics, "-2");
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSeries, "-2");
                // CommonFunction.BindEnum<CommonEnum.TeaState>(this.ddl_TeaState, "-2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_TCourse, dtCourse, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            //ViewState["TeacherCode"] = CommonFunction.GetCommoneString(this.txt_TeacherCode.Text.ToString().Trim());
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.ToString().Trim());
            ViewState["TSex"] = this.ddl_TSex.SelectedValue.ToString();
            ViewState["Politics"] = this.ddl_Politics.SelectedValue.ToString();
            ViewState["TCourse"] = this.ddl_TCourse.SelectedValue.ToString();
            ViewState["IsSeries"] = this.ddl_IsSeries.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            TeacherEntity model = new TeacherEntity();
            //model.TeacherCode = (string)ViewState["TeacherCode"];
            model.RealName = (string)ViewState["RealName"];
            model.TSex = Convert.ToInt32(ViewState["TSex"].ToString());
            model.Politics = Convert.ToInt32(ViewState["Politics"].ToString());
            model.TCourse = Convert.ToInt32(ViewState["TCourse"].ToString());
            model.IsSeries = Convert.ToInt32(ViewState["IsSeries"].ToString());
            model.IsDel = (int)CommonEnum.Deleted.未删除;
            model.TeaAddress = this.txt_TeaState.Text == "" ? "201,202,203,204,205,206,207,208,209,210,211,301,302,303,306,307,308" : this.txt_TeaState.Text;//人员状态
            DataTable dt = teacherDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value;
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teacherDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 跳转修改页面
        /// <summary>
        /// 跳转修改页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('TeacherEdit.aspx?id={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion

        #region 跳转详情页面
        /// <summary>
        /// 跳转详情页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Info_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('TeacherDetail.aspx?id={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion


        #region 上报 ---测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.TeacherEntity> args = new List<GKICMP.localhost1.TeacherEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    TeacherEntity p = teacherDAL.GetObjByID(id.Split(',')[i]);

                    GKICMP.localhost1.TeacherEntity model1 = new localhost1.TeacherEntity();

                    model1.TID = p.TID;//TID
                    //根据TID获取教师职务角色ID
                    #region 职务
                    DataTable dt1 = teacherDAL.GetRole(id);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        for (int f = 0; f < dt1.Rows.Count; f++)
                        {
                            Role += dt1.Rows[f]["RID"].ToString() + ",";
                        }
                        model1.PostRole = Role.Trim(','); ;//职务角色
                    }
                    else
                    {
                        model1.PostRole = "";
                    }
                    model1.PostName = p.PostRole;//职务角色名称
                    #endregion
                    // model1.DepID = p.DepID;
                    model1.TeacherName = p.RealName;//姓名
                    model1.TSex = p.TSex;//性别
                    model1.JobStartDate = p.JodDate;//参加工作年月--参加工作时间
                    model1.BirthDay = p.Birthday;//出生日期
                    model1.Politics = p.Politics;//政治面貌
                    model1.IDCard = p.IDCardNum;//身份证号
                    model1.PartyTme = p.PartyTme;//入党时间
                    #region 学历信息
                    DataTable dt = teacherEducation.GetListByTID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model1.FirstDegree = int.Parse(dt.Rows[0]["Education"].ToString());//第一学历
                        model1.FirstGetDate = Convert.ToDateTime(dt.Rows[0]["OutDate"].ToString() == "" ? "1900-01-01" : dt.Rows[0]["OutDate"].ToString());//第一学历取得时间
                        model1.TopDegree = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Education"].ToString() == "" ? "0" : dt.Rows[dt.Rows.Count - 1]["Education"].ToString());//获得学历--最高学历
                        model1.TopGetDate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["OutDate"].ToString() == "" ? "1900-01-01" : dt.Rows[dt.Rows.Count - 1]["OutDate"].ToString()); ;//最高学历取得时间
                        model1.FirstSchool = dt.Rows[0]["EduSchool"].ToString();//第一学历取得院校
                        model1.TopSchool = dt.Rows[dt.Rows.Count - 1]["EduSchool"].ToString();//最高学历取得院校
                        model1.HighestDegree = dt.Rows[dt.Rows.Count - 1]["DegreeName"].ToString();//学位名称 --最高学位;
                        model1.HighestGetDate = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["GrantDate"].ToString() == "" ? "1900-01-01" : dt.Rows[dt.Rows.Count - 1]["GrantDate"].ToString());//学位授予年月 --最高学位取得时间
                        model1.HighestSchool = dt.Rows[dt.Rows.Count - 1]["GradeSchool"].ToString();//获得学位的院校或机构--最高学位毕业院校、专业
                        //for (int c = 0; c < dt.Rows.Count; c++)
                        //{
                        //    model1.TopDegree = Convert.ToInt32(dt.Rows[c]["Education"].ToString());//获得学历--最高学历
                        //    model1.TopSchool = dt.Rows[c]["GradeSchool"].ToString();//获得学位的院校或机构-- 最高毕业院校、专业

                        //    model1.HighestDegree = dt.Rows[c]["DegreeName"].ToString();//学位名称 --最高学位
                        //    model1.HighestGetDate = Convert.ToDateTime(dt.Rows[c]["GrantDate"].ToString());//学位授予年月 --最高学位取得时间
                        //    model1.HighestSchool = dt.Rows[c]["GradeSchool"].ToString();//获得学位的院校或机构--最高学位毕业院校、专业

                        //    model1.TSbuject = dt.Rows[c]["EMajor"].ToString();//所学专业-- 专业
                        //    model1.TopGetDate = Convert.ToDateTime(dt.Rows[c]["OutDate"].ToString());//毕业年月-- 最高学历 取得时间
                        //}
                    }
                    else
                    {
                        ShowMessage("该老师还不存在学历信息，请先添加学历再上报");
                        return;
                    }
                    #endregion

                    model1.CurrentProfessional = p.CurrentProfessional;//专业技术职称--现任专业技术职务名称
                    model1.Qualifications = Convert.ToString(p.GradeDate);//职称聘用时间


                    model1.LastContrDate = Convert.ToDateTime("1900-01-01");//最近一次合同签订时间
                    model1.TState = p.IsSeries;//是否在编
                    model1.TCourse = p.TCourse;//教授科目
                    model1.TNation = p.TNation;//民族
                    model1.LinkNum = p.CellPhone;//联系方式
                    model1.TEmail = p.Email;//邮箱
                    model1.TAddress = p.TeaAddress;//住址
                    model1.TSbuject = dt.Rows[dt.Rows.Count - 1]["EMajor"].ToString();//专业
                    model1.IsFull = p.IsFull;//是否专任教

                    model1.SalaryGrade = p.SalaryGrade;//薪级
                    //试用期 = 0,管理人员 = 1,专业技术人员 = 2,技术工人 = 3,普通工人 = 4
                    //试用期 = 332, 管理人员 = 333, 专业技术人员 = 334, 技术工人 = 335,普通工人 = 336
                    #region 专业技术岗位等级分类
                    switch (p.GradeType)
                    {
                        case 332:
                            model1.ProfessGradeType = 0;
                            break;
                        case 333:
                            model1.ProfessGradeType = 1;
                            break;
                        case 334:
                            model1.ProfessGradeType = 2;
                            break;
                        case 335:
                            model1.ProfessGradeType = 3;
                            break;
                        case 336:
                            model1.ProfessGradeType = 4;
                            break;
                        default:
                            model1.ProfessGradeType = -2;
                            break;

                    }
                    #endregion
                    #region 专业技术岗位等级
                    switch (p.ProfessGrade)
                    {
                        case 337:
                            model1.ProfessGrade = 1;
                            break;
                        case 338:
                            model1.ProfessGrade = 2;
                            break;
                        case 339:
                            model1.ProfessGrade = 3;
                            break;
                        case 340:
                            model1.ProfessGrade = 4;
                            break;
                        case 341:
                            model1.ProfessGrade = 5;
                            break;
                        case 342:
                            model1.ProfessGrade = 6;
                            break;
                        case 343:
                            model1.ProfessGrade = 7;
                            break;
                        case 344:
                            model1.ProfessGrade = 8;
                            break;
                        case 345:
                            model1.ProfessGrade = 9;
                            break;
                        case 346:
                            model1.ProfessGrade = 10;
                            break;
                        case 347:
                            model1.ProfessGrade = 11;
                            break;
                        case 348:
                            model1.ProfessGrade = 12;
                            break;
                        case 349:
                            model1.ProfessGrade = 13;
                            break;
                        case 350:
                            model1.ProfessGrade = 14;
                            break;
                        case 351:
                            model1.ProfessGrade = 15;
                            break;
                        case 352:
                            model1.ProfessGrade = 16;
                            break;
                        case 353:
                            model1.ProfessGrade = 17;
                            break;
                        case 354:
                            model1.ProfessGrade = 18;
                            break;
                        case 355:
                            model1.ProfessGrade = 19;
                            break;
                        case 356:
                            model1.ProfessGrade = 20;
                            break;
                        case 357:
                            model1.ProfessGrade = 21;
                            break;
                        case 358:
                            model1.ProfessGrade = 22;
                            break;
                        case 359:
                            model1.ProfessGrade = 23;
                            break;
                        case 360:
                            model1.ProfessGrade = 24;
                            break;
                        case 361:
                            model1.ProfessGrade = 25;
                            break;
                        case 362:
                            model1.ProfessGrade = 26;
                            break;
                        case 363:
                            model1.ProfessGrade = 27;
                            break;
                        case 364:
                            model1.ProfessGrade = 28;
                            break;
                        case 365:
                            model1.ProfessGrade = 29;
                            break;
                        default:
                            model1.ProfessGrade = -2;
                            break;

                    }
                    #endregion

                    model1.IsRetire = p.IsRetire;//是否退休
                    model1.TeaState = p.TeaState;//人员状态
                    model1.IsCancel = (int)CommonEnum.IsorNot.否;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;
                    model1.CID = p.CName;//校区
                    model1.SchoolName = p.CName;//分校名称
                    model1.Section = p.Section;//学段                    

                    model1.TeachQualification1 = CommonFunction.CheckEnum<CommonEnum.TeaQualiType>(p.TeaQualiType) + "  " + p.TeaQualCode;//教师资格名称及编号
                    model1.TQGetDate1 = p.TeaQualDate.ToString("yyyy-MM-dd");//教师资格证取得时间

                    //model1.PostRole = p.PostRole;//职务角色
                    //model1.PostName = p.PostName;//职务角色名称
                    //model1.CurrentProfessional = p.IsTea;//是否教学岗位 
                    //model1.GradeDate = p.GradeDate;//专业技术职务岗位聘用时间--
                    //model1.Mandarin = p.Mandarin;
                    //model1.TSbuject = p.TSbuject;
                    //model1.IsFull = p.IsFull;
                    //model1.PartyTme = p.PartyTme;
                    //model1.JobStartDate = p.JobStartDate;
                    //model1.LinkNum = p.LinkNum;
                    //model1.TAddress = p.TAddress;
                    //model1.ProfessGrade = p.ProfessGrade;
                    //model1.ProfessGradeType = p.ProfessGradeType;
                    //model1.SalaryGrade = p.SalaryGrade;
                    //model1.CourseName = p.CourseName;
                    //model1.FirstDegree = p.FirstDegree;
                    //model1.TopDegree = p.TopDegree;
                    //model1.FirstGetDate = p.FirstGetDate;
                    //model1.TopGetDate = p.TopGetDate;

                    //model1.FirstSchool = p.FirstSchool;
                    //model1.TopSchool = p.TopSchool;
                    //model1.HighestGetDate = p.HighestGetDate;
                    //model1.HighestSchool = p.HighestSchool;
                    //model1.HighestDegree = p.HighestDegree;

                    args.Add(model1);
                }


                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.TeacherEntity[] A = args.ToArray();
                if (service.Teacher(sguid, A, out aa))
                {
                    int rusult = teacherDAL.InUpdate(id);//更新字段为 已上报
                    ShowMessage(aa);
                    DataBindList();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, aa, UserID));
                }
                else
                {
                    ShowMessage(aa.Replace("'", ""));
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, aa, UserID));
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 多条上报 ---测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string aa = "";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');

                List<GKICMP.localhost1.TeacherEntity> args = new List<GKICMP.localhost1.TeacherEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    TeacherEntity p = teacherDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.TeacherEntity model1 = new localhost1.TeacherEntity();

                    model1.TID = p.TID;
                    // model1.DepID = p.DepID;
                    model1.TeacherName = p.RealName;
                    model1.TSex = p.TSex;
                    model1.BirthDay = p.Birthday;
                    model1.IDCard = p.IDCardNum;
                    model1.Politics = p.Politics;
                    model1.TNation = p.TNation;
                    model1.TEmail = p.Email;
                    model1.TeaState = p.TeaState;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;
                    model1.TCourse = p.TCourse;//教授科目
                    model1.TState = p.IsSeries;//是否在编

                    //model1.PostRole = p.PostRole;//职务角色
                    //model1.PostName = p.PostName;//职务角色名称

                    model1.PostName = p.PostRole;//职务角色名称

                    //根据TID获取教师职务角色ID
                    DataTable dt1 = teacherDAL.GetRoleTable(id);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        for (int f = 0; f < dt1.Rows.Count; f++)
                        {
                            Role += dt1.Rows[f]["RID"].ToString() + ",";
                        }
                        model1.PostRole = Role.Trim(','); ;//职务角色
                    }
                    else
                    {
                        model1.PostRole = "";
                    }

                    model1.PartyTme = p.PartyTme;//入党时间
                    model1.SalaryGrade = p.SalaryGrade;//薪级
                    model1.ProfessGradeType = p.GradeType;//专业技术岗位等级分类
                    model1.ProfessGrade = p.ProfessGrade;//专业技术岗位等级
                    model1.CurrentProfessional = p.CurrentProfessional;//专业技术职称--现任专业技术职务名称
                    model1.IsFull = p.IsFull;//是否专任教
                    model1.IsRetire = p.IsRetire;//是否退休
                    model1.Section = p.Section;//学段
                    model1.JobStartDate = p.JodDate;//参加工作年月--参加工作时间

                    //model1.CurrentProfessional = p.IsTea;//是否教学岗位 
                    model1.Qualifications = p.TeaQualCode;//教师资格证编号-- 资格取得时间及编号

                    //model1.GradeDate = p.GradeDate;//专业技术职务岗位聘用时间--
                    model1.TQGetDate1 = Convert.ToString(p.TeaQualDate);//教师资格证取得时间 --资格取得时间、编号1
                    //model1.Mandarin = p.Mandarin;

                    DataTable dt = teacherEducation.GetListByTID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int c = 0; c < dt.Rows.Count; c++)
                        {
                            model1.TopDegree = Convert.ToInt32(dt.Rows[c]["Education"].ToString());//获得学历--最高学历
                            model1.TopSchool = dt.Rows[c]["GradeSchool"].ToString();//获得学位的院校或机构-- 最高毕业院校、专业

                            model1.HighestDegree = dt.Rows[c]["DegreeName"].ToString();//学位名称 --最高学位
                            model1.HighestGetDate = Convert.ToDateTime(dt.Rows[c]["GrantDate"].ToString());//学位授予年月 --最高学位取得时间
                            model1.HighestSchool = dt.Rows[c]["GradeSchool"].ToString();//获得学位的院校或机构--最高学位毕业院校、专业

                            model1.TSbuject = dt.Rows[c]["EMajor"].ToString();//所学专业-- 专业
                            model1.TopGetDate = Convert.ToDateTime(dt.Rows[c]["OutDate"].ToString());//毕业年月-- 最高学历 取得时间
                        }
                    }
                    else
                    {
                        ShowMessage("该老师还不存在学历信息，请先添加学历再上报");
                    }


                    args.Add(model1);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.TeacherEntity[] A = args.ToArray();
                if (service.Teacher(sguid, A, out aa))
                {
                    int rusult = teacherDAL.InUpdate(id);//更新字段为 已上报
                    ShowMessage(aa);
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
            }

        }
        #endregion

        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string sstate = state.ToString();
            if (sstate == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion

        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            TeacherEntity model = new TeacherEntity();
            //model.TeacherCode = (string)ViewState["TeacherCode"];
            model.RealName = (string)ViewState["RealName"];
            model.TSex = Convert.ToInt32(ViewState["TSex"].ToString());
            model.Politics = Convert.ToInt32(ViewState["Politics"].ToString());
            model.TCourse = Convert.ToInt32(ViewState["TCourse"].ToString());
            model.IsSeries = Convert.ToInt32(ViewState["IsSeries"].ToString());
            model.IsDel = (int)CommonEnum.Deleted.未删除;
            model.TeaAddress = this.txt_TeaState.Text == "" ? "-2" : this.txt_TeaState.Text;//人员状态
            DataTable dt = teacherDAL.GetPaged(2000, 1, ref recordCount, model);
            DataTable dtOut = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {

                //DataTable stu = exam_StudentDAL.GetStuByEid(int.Parse(EID));
                //DataTable course = exam_SubjectDAL.GetByEID(EID);
                dtOut.Columns.Add("姓名", typeof(string));
                dtOut.Columns.Add("身份证", typeof(string));
                dtOut.Columns.Add("教职工编号", typeof(string));
                dtOut.Columns.Add("教职工类别", typeof(string));
                dtOut.Columns.Add("学段", typeof(string));
                dtOut.Columns.Add("性别", typeof(string));
                dtOut.Columns.Add("出生年月", typeof(string));
                dtOut.Columns.Add("手机号", typeof(string));
                dtOut.Columns.Add("民族", typeof(string));
                dtOut.Columns.Add("政治面貌", typeof(string));
                dtOut.Columns.Add("入党时间", typeof(string));
                dtOut.Columns.Add("婚姻状况", typeof(string));
                dtOut.Columns.Add("健康状况", typeof(string));
                dtOut.Columns.Add("邮箱", typeof(string));
                dtOut.Columns.Add("地址", typeof(string));
                dtOut.Columns.Add("参加工作年月", typeof(string));
                dtOut.Columns.Add("进本校年月", typeof(string));
                dtOut.Columns.Add("职务", typeof(string));
                dtOut.Columns.Add("是否专任教", typeof(string));
                dtOut.Columns.Add("教授科目", typeof(string));
                dtOut.Columns.Add("人员状态", typeof(string));
                dtOut.Columns.Add("是否在编", typeof(string));
                dtOut.Columns.Add("专业技术岗位等级分类", typeof(string));
                dtOut.Columns.Add("专业技术岗位等级", typeof(string));
                dtOut.Columns.Add("专业技术职称", typeof(string));
                dtOut.Columns.Add("职称聘用时间", typeof(string));
                dtOut.Columns.Add("薪级", typeof(string));

                dtOut.Columns.Add("合同签到情况", typeof(string));

                dtOut.Columns.Add("教师资格类型", typeof(string));
                dtOut.Columns.Add("资格证编号", typeof(string));
                dtOut.Columns.Add("资格取得学科", typeof(string));
                dtOut.Columns.Add("证书颁发日期", typeof(string));
                dtOut.Columns.Add("首次注册日期", typeof(string));
                dtOut.Columns.Add("普通话水平", typeof(string));
                dtOut.Columns.Add("是否教学岗", typeof(string));
                //dtOut.Columns.Add("薪级", typeof(string));
                //dtOut.Columns.Add("薪级", typeof(string));
                //dtOut.Columns.Add("薪级", typeof(string));
                //dtOut.Columns.Add("薪级", typeof(string));
                //dtOut.Columns.Add("薪级", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    List<string> list = new List<string>();
                    list.Add(dr["RealName"].ToString());
                    list.Add(dr["IDCardNum"].ToString());
                    list.Add(dr["TeacherCode"].ToString());
                    list.Add(dr["TeaTypeName"].ToString());
                    list.Add(dr["Section"].ToString() == "1" ? "小学" : "初中");

                    list.Add(dr["TSex"].ToString() == "1" ? "男" : "女");
                    list.Add(dr["Birthday"].ToString() == "" ? "" : Convert.ToDateTime(dr["Birthday"]).ToString("yyyy-MM"));
                    list.Add(dr["CellPhone"].ToString());
                    list.Add(CommonFunction.CheckEnum<CommonEnum.MZ>(dr["TNation"].ToString()));
                    list.Add(CommonFunction.CheckEnum<CommonEnum.ZZMM>(dr["Politics"].ToString()));
                    list.Add(dr["PartyTme"] == null ? "" : Convert.ToDateTime(dr["PartyTme"]).ToString("yyyy-MM-dd") == "1900-01-01" ? "" : dr["PartyTme"].ToString());
                    list.Add(dr["MaritalStatusName"].ToString());
                    list.Add(CommonFunction.CheckEnum<CommonEnum.HealthStatus>(dr["HealthStatus"].ToString()));
                    list.Add(dr["Email"].ToString());
                    list.Add(dr["TeaAddress"].ToString());
                    list.Add(dr["JodDate"].ToString() == "" ? "" : Convert.ToDateTime(dr["JodDate"]).ToString("yyyy-MM"));
                    list.Add(dr["JoinSchool"].ToString() == "" ? "" : Convert.ToDateTime(dr["JoinSchool"]).ToString("yyyy-MM"));
                    list.Add(dr["PostRole"].ToString());
                    list.Add(dr["IsFull"].ToString() == "1" ? "是" : "否");
                    list.Add(dr["TCourseName"].ToString());
                    list.Add(CommonFunction.CheckEnum<CommonEnum.TeaState>(dr["TeaState"].ToString()));
                    list.Add(dr["IsSeries"].ToString() == "1" ? "是" : "否");
                    list.Add(CommonFunction.CheckEnum<CommonEnum.ProfessGradeType>(dr["GradeType"].ToString()));
                    list.Add(dr["ProfessGradeName"].ToString());
                    list.Add(CommonFunction.CheckEnum<CommonEnum.CurrentProfessional>(dr["CurrentProfessional"].ToString()));
                    list.Add(Convert.ToDateTime(dr["GradeDate"]).ToString("yyyy-MM-dd") == "1900-01-01" ? "" : dr["GradeDate"].ToString());
                    list.Add(dr["SalaryGrade"].ToString());






                    list.Add(CommonFunction.CheckEnum<CommonEnum.ContractState>(dr["ContractState"].ToString()));

                    list.Add(CommonFunction.CheckEnum<CommonEnum.TeaQualiType>(dr["TeaQualiType"].ToString()));
                    list.Add(dr["TeaQualCode"].ToString());
                    list.Add(dr["TeaQualCourseName"].ToString());
                    list.Add(Convert.ToDateTime(dr["TeaQualDate"]).ToString("yyyy-MM-dd") == "1900-01-01" ? "" : dr["TeaQualDate"].ToString());
                    list.Add(Convert.ToDateTime(dr["TeaQualRegDate"]).ToString("yyyy-MM-dd") == "1900-01-01" ? "" : dr["TeaQualRegDate"].ToString());
                    list.Add(CommonFunction.CheckEnum<CommonEnum.MandarinType>(dr["Mandarin"].ToString()));
                    list.Add(dr["IsTea"].ToString() == "1" ? "是" : "否");
                    //list.Add(dr[""].ToString());
                    //list.Add(dr[""].ToString());
                    //list.Add(dr[""].ToString());
                    //list.Add(dr[""].ToString());
                    //list.Add(dr[""].ToString());


                    dtOut.Rows.Add(list.ToArray());
                }
            }
            else
            {
                ShowMessage("暂无数据导出");
                return;
            }
            try
            {
                //string _excelName = "发货列表信息";//Excel表头名称
                //string fileName = _excelName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls"; //Excel文件名称
                //调用导出方法
                CommonFunction.ExportByWeb(dtOut, "", "教师信息表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

            }
            catch (Exception ee)
            {
                string _err = ee.Message;
            }
            this.hf_CheckIDS.Value = "";
        }
    }
}