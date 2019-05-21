/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师课时导入
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.teachermanage
{
    public partial class TeacherImport : PageBase
    {
        public Teacher_ClassHourDAL teacher_ClassHourDAL = new Teacher_ClassHourDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public CourseDAL courseDAL = new CourseDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }

        #region 下载模板文件
        /// <summary>
        /// 下载模板文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            string expath = @"~\Template\TeacherImportTemplate.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "教师信息导入模板"))
            {
                ShowMessage("模板文件不存在，请联系系统管理员");
                return;
            }
        }
        #endregion


        #region 读取Excel文件
        /// <summary>
        /// 读取Excel文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable ReadExcel(string path)
        {
            //DataTable dt = new DataTable();
            ////string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties=Excel 8.0;HDR=Yes;IMEX=1'";
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties='Excel 8.0; IMEX=1'";
            //OleDbConnection conn = new OleDbConnection(strConn);
            //try
            //{
            //    conn.Open();
            //    //获取表名
            //    DataTable dtname = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //    string sheetName = dtname.Rows[0][2].ToString().Trim();
            //    //读取excel文件数据
            //    string strExcel = string.Format("select * from [{0}]", sheetName);
            //    OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
            //    myCommand.Fill(dt);
            //}
            //catch (Exception ex)
            //{
            //    dt = null;
            //}
            //conn.Close();
            //CommonFunction.delfile(path);
            //return dt;
            return CommonFunction.ExportExcel(path);
        }
        #endregion


        #region 上传导入的文件
        /// <summary>
        /// 上传导入的文件
        /// </summary>
        /// <returns></returns>
        protected string up()
        {
            string path = Server.MapPath("../Template/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (fuimport.HasFile)
            {
                string name = UserID.ToString() + "_TeacherClassHourImportTemplate_";
                string strfile = System.IO.Path.GetExtension(fuimport.FileName);
                string filename = name + strfile;
                path += filename;
                fuimport.SaveAs(path);
                return path;
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 导入
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            string path = up();
            //判断是否上传成功
            if (path != "")
            {
                //获取数据
                DataTable dt = ReadExcel(path);
                if (dt != null)
                {
                    // 检查列名
                    string colname = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        colname += dc.ColumnName + ",";
                    }
                    string[] needcol = { "姓名", "身份证", "曾用名", "手机号", "教职工号", "职务角色", "性别", "政治面貌", "入党时间", "出生年月", "籍贯", "出生地", "婚姻状况", "健康状况", "邮箱", "住址", "教职工来源", "教职工类别", "学段", "参加工作年月", "进本校年月", "签订合同情况", "教授科目", "人员状态", "是否专任教", "是否在编", "专业技术岗位等级分类", "专业技术岗位等级", "专业技术职称", "职称聘用时间", "薪级", "教师资格类型", "资格证编号", "资格取得学科", "证书颁发日期", "首次注册日期", "普通话水平", "是否教学岗", "是否受过特教专业培训", "是否有特殊教育从业证书", "是否特级教师", "是否属于免费(公费)师范生", "是否参加基层服务项目", "是否县级及以上骨干教师", "是否心理健康教育教师", "是否全日制师范类专业毕业", "信息技术应用能力", "参加基层服务项目起始年月", "参加基层服务项目结束年月" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                        TeacherEntity[] list = new TeacherEntity[dt.Rows.Count];

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            #region 减少空间，鼠标拖的烦
                            TeacherEntity model = new TeacherEntity();
                            model.TID = "";
                            if (dt.Rows[i]["姓名"].ToString() != "")
                                model.RealName = dt.Rows[i]["姓名"].ToString();
                            else
                            {
                                ShowMessage("姓名不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            if (dt.Rows[i]["身份证"].ToString() != "")
                                model.IDCardNum = dt.Rows[i]["身份证"].ToString();
                            else
                            {
                                ShowMessage("身份证不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            model.OldName = dt.Rows[i]["曾用名"].ToString();
                            model.Nationality = "中国";
                            if (dt.Rows[i]["手机号"].ToString() != "")
                                model.CellPhone = dt.Rows[i]["手机号"].ToString();
                            else
                            {
                                ShowMessage("手机号不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            if (dt.Rows[i]["职务角色"].ToString() != "")
                                model.PostRole = dt.Rows[i]["职务角色"].ToString();
                            else
                            {
                                ShowMessage("职务角色不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            model.TeacherCode = dt.Rows[i]["教职工号"].ToString();
                            model.TSex = dt.Rows[i]["性别"].ToString() == "男" ? 1 : 2;
                            try
                            {
                                model.Politics = (int)Enum.Parse(typeof(CommonEnum.ZZMM), dt.Rows[i]["政治面貌"].ToString());
                            }
                            catch (Exception)
                            {
                                model.Politics = (int)CommonEnum.ZZMM.群众;
                            }
                            model.PartyTme = dt.Rows[i]["入党时间"].ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dt.Rows[i]["入党时间"].ToString());
                            try
                            {
                                model.Birthday = dt.Rows[i]["出生年月"].ToString() == "" ? Convert.ToDateTime(dt.Rows[i]["身份证"].ToString().Substring(6, 8)) : Convert.ToDateTime(dt.Rows[i]["出生年月"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("请输入正确的出生年月【第" + (i + 2) + "行】");
                                return;
                            }
                            model.PlaceOrigin = dt.Rows[i]["籍贯"].ToString();
                            model.OneNative = dt.Rows[i]["出生地"].ToString();

                            if (dt.Rows[i]["婚姻状况"].ToString() != "")
                            {
                                int s = baseDataDAL.GetSDID(dt.Rows[i]["婚姻状况"].ToString(), (int)CommonEnum.BaseDataType.婚姻状况);
                                if (s != 0)
                                    model.MaritalStatus = s;//婚姻状况
                                else
                                {
                                    ShowMessage("系统中不存在此婚姻状况【" + dt.Rows[i]["婚姻状况"].ToString() + "】,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.MaritalStatus = 0;//婚姻状况
                            }
                            try
                            {
                                model.HealthStatus = (int)Enum.Parse(typeof(CommonEnum.HealthStatus), dt.Rows[i]["健康状况"].ToString());
                            }
                            catch (Exception)
                            {
                                model.HealthStatus = (int)CommonEnum.HealthStatus.健康或良好;
                            }
                            model.Email = dt.Rows[i]["邮箱"].ToString();
                            model.TeaAddress = dt.Rows[i]["住址"].ToString();
                            if (dt.Rows[i]["教职工来源"].ToString() != "")
                            {
                                int s = baseDataDAL.GetSDID(dt.Rows[i]["教职工来源"].ToString(), (int)CommonEnum.BaseDataType.教职工来源);
                                if (s != 0)
                                {
                                    model.TeaSource = s;//教职工来源
                                }
                                else
                                {
                                    ShowMessage("系统中不存在此教职工来源【" + dt.Rows[i]["教职工来源"].ToString() + "】,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.TeaSource = 234;//其他
                            }
                            if (dt.Rows[i]["教职工类别"].ToString() != "")
                            {
                                int s = baseDataDAL.GetSDID(dt.Rows[i]["教职工类别"].ToString(), (int)CommonEnum.BaseDataType.教职工类别);
                                if (s != 0)
                                {
                                    model.TeaType = s;//教职工类别
                                }
                                else
                                {
                                    ShowMessage("系统中不存在此教职工类别【" + dt.Rows[i]["教职工类别"].ToString() + "】,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.TeaSource = 3;//专任教师（默认）
                            }
                            if (dt.Rows[i]["学段"].ToString() != "")
                                model.Section = dt.Rows[i]["学段"].ToString() == "小学" ? 2 : 3;
                               // model.Section = dt.Rows[i]["学段"].ToString() == "小学" ? 1 : 2;
                            else
                            {
                                ShowMessage("学段不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            try
                            {
                                model.JodDate = Convert.ToDateTime(dt.Rows[i]["参加工作年月"].ToString());
                            }
                            catch (Exception ex)
                            {
                                ShowMessage("请填写正确的参加工作年月的时间类型【" + dt.Rows[i]["参加工作年月"].ToString() + "】,【第" + (i + 2) + "行】");
                                return;
                            }
                            try
                            {
                                model.JoinSchool = Convert.ToDateTime(dt.Rows[i]["进本校年月"].ToString());
                            }
                            catch (Exception ex)
                            {
                                ShowMessage("请填写正确的进本校年月的时间类型【" + dt.Rows[i]["进本校年月"].ToString() + "】,【第" + (i + 2) + "行】");
                                return;
                            }
                            try
                            {
                                model.ContractState = (int)Enum.Parse(typeof(CommonEnum.ContractState), dt.Rows[i]["签订合同情况"].ToString());
                            }
                            catch (Exception ex)
                            {
                                ShowMessage("请选择签订合同情况类型【" + dt.Rows[i]["签订合同情况"].ToString() + "】,【第" + (i + 2) + "行】");
                                return;
                            }
                            if (dt.Rows[i]["教授科目"].ToString() != "")
                            {
                                int cid = courseDAL.GetCID(dt.Rows[i]["教授科目"].ToString());
                                if (cid == 0)
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["教授科目"].ToString() + "的学科信息，请修改后重新导入【第" + (i + 2) + "行】");
                                    return;
                                }
                                model.TCourse = cid;
                            }
                            else
                            {
                                model.TCourse = 0;
                            }

                            try
                            {
                                model.TeaState = (int)Enum.Parse(typeof(CommonEnum.TeaState), dt.Rows[i]["人员状态"].ToString());
                            }
                            catch (Exception ex)
                            {
                                ShowMessage("请选择人员状态【" + dt.Rows[i]["人员状态"].ToString() + "】,【第" + (i + 2) + "行】");
                                return;
                            }
                            model.IsFull = dt.Rows[i]["是否专任教"].ToString() == "" ? 0 : dt.Rows[i]["是否专任教"].ToString() == "否" ? 0 : 1;
                            model.IsSeries = dt.Rows[i]["是否在编"].ToString() == "" ? 0 : dt.Rows[i]["是否在编"].ToString() == "否" ? 0 : 1;
                            if (dt.Rows[i]["专业技术岗位等级分类"].ToString() != "")
                            {
                                try
                                {
                                    model.GradeType = (int)Enum.Parse(typeof(CommonEnum.ProfessGradeType), dt.Rows[i]["专业技术岗位等级分类"].ToString()); ;
                                }
                                catch (Exception)
                                {
                                    ShowMessage("请选择专业技术岗位等级【" + dt.Rows[i]["专业技术岗位等级分类"].ToString() + "】,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.GradeType = 0;
                            }
                            if (dt.Rows[i]["专业技术岗位等级"].ToString() != "")
                            {
                                int s = baseDataDAL.GetSDID(dt.Rows[i]["专业技术岗位等级"].ToString(), (int)CommonEnum.BaseDataType.专业技术岗位等级);
                                if (s != 0)
                                {
                                    model.ProfessGrade = s;//教职工类别
                                }
                                else
                                {
                                    ShowMessage("系统中不存在此专业技术岗位等级【" + dt.Rows[i]["专业技术岗位等级"].ToString() + "】,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.ProfessGrade = 0;
                            }
                            if (dt.Rows[i]["专业技术职称"].ToString() != "")
                            {
                                try
                                {
                                    model.CurrentProfessional = (int)Enum.Parse(typeof(CommonEnum.CurrentProfessional), dt.Rows[i]["专业技术职称"].ToString());
                                }
                                catch (Exception)
                                {
                                    ShowMessage("请选择专业技术职称【" + dt.Rows[i]["专业技术职称"].ToString() + "】,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.CurrentProfessional = 0;
                            }
                            try
                            {
                                model.GradeDate = dt.Rows[i]["职称聘用时间"].ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dt.Rows[i]["职称聘用时间"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("请填写正确的职称聘用时间【" + dt.Rows[i]["专业技术职称"].ToString() + "】,【第" + (i + 2) + "行】");
                                return;
                            }
                            if (dt.Rows[i]["薪级"].ToString() != "")
                            {
                                try
                                {
                                    model.SalaryGrade = int.Parse(dt.Rows[i]["薪级"].ToString());
                                }
                                catch (Exception)
                                {
                                    ShowMessage("请选择薪级,【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                model.SalaryGrade = 0;
                            } 
                            #endregion

                            #region 减少空间，鼠标拖的烦
                            if (dt.Rows[i]["教师资格类型"].ToString() != "")
                            {
                                try
                                {
                                    model.TeaQualiType = (int)Enum.Parse(typeof(CommonEnum.TeaQualiType), dt.Rows[i]["教师资格类型"].ToString());
                                }
                                catch (Exception)
                                {
                                    ShowMessage("请选择正确的教师资格类型【第" + (i + 2) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                ShowMessage("教师资格证类型不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            if (dt.Rows[i]["资格证编号"].ToString() != "")
                                model.TeaQualCode = dt.Rows[i]["资格证编号"].ToString();
                            else
                            {
                                ShowMessage("教师资格证编号不能为空【第" + (i + 2) + "行】");
                                return;
                            }

                            if (dt.Rows[i]["资格取得学科"].ToString() != "")
                            {
                                int cid = courseDAL.GetCID(dt.Rows[i]["资格取得学科"].ToString());
                                if (cid == 0)
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["资格取得学科"].ToString() + "的学科信息，请修改后重新导入【第" + (i + 2) + "行】");
                                    return;
                                }
                                model.TeaQualCourse = cid;
                            }
                            else
                            {
                                ShowMessage("教师资格证取得学科不能为空【第" + (i + 2) + "行】");
                                return;
                            }
                            try
                            {
                                model.TeaQualRegDate = dt.Rows[i]["首次注册日期"].ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dt.Rows[i]["首次注册日期"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("教师资格证书首次注册日期有误【第" + (i + 2) + "行】");
                                return;
                            }

                            try
                            {
                                model.TeaQualDate = dt.Rows[i]["证书颁发日期"].ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dt.Rows[i]["证书颁发日期"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("教师资格证书颁发日期有误【第" + (i + 2) + "行】");
                                return;
                            }
                            if (dt.Rows[i]["普通话水平"].ToString() != "")
                                model.Mandarin = dt.Rows[i]["普通话水平"].ToString() != "无" ? (int)Enum.Parse(typeof(CommonEnum.MandarinType), dt.Rows[i]["普通话水平"].ToString()) : 0;
                            else
                            {
                                model.Mandarin = 0;
                            }
                            if (dt.Rows[i]["是否教学岗"].ToString() != "")
                                model.IsTea = dt.Rows[i]["是否教学岗"].ToString() == "是" ? 1 : 0;
                            else
                            {
                                ShowMessage("是否教学岗不能为空【第" + (i + 2) + "行】");
                                return;
                            }

                            model.IsSpecialTrain = dt.Rows[i]["是否受过特教专业培训"].ToString() == "" ? 0 : dt.Rows[i]["是否受过特教专业培训"].ToString() == "否" ? 0 : 1;
                            model.IsSpecialEdu = dt.Rows[i]["是否有特殊教育从业证书"].ToString() == "" ? 0 : dt.Rows[i]["是否有特殊教育从业证书"].ToString() == "否" ? 0 : 1;
                            model.IsSpecialTea = dt.Rows[i]["是否特级教师"].ToString() == "" ? 0 : dt.Rows[i]["是否特级教师"].ToString() == "否" ? 0 : 1;
                            model.IsTeaStu = dt.Rows[i]["是否属于免费(公费)师范生"].ToString() == "" ? 0 : dt.Rows[i]["是否属于免费(公费)师范生"].ToString() == "否" ? 0 : 1;
                            model.IsGrassService = dt.Rows[i]["是否参加基层服务项目"].ToString() == "" ? 0 : dt.Rows[i]["是否参加基层服务项目"].ToString() == "否" ? 0 : 1;
                            model.IsCountyLevel = dt.Rows[i]["是否县级及以上骨干教师"].ToString() == "" ? 0 : dt.Rows[i]["是否县级及以上骨干教师"].ToString() == "否" ? 0 : 1;
                            model.IsHealthTeahcer = dt.Rows[i]["是否心理健康教育教师"].ToString() == "" ? 0 : dt.Rows[i]["是否心理健康教育教师"].ToString() == "否" ? 0 : 1;
                            model.IsFulltime = dt.Rows[i]["是否全日制师范类专业毕业"].ToString() == "" ? 0 : dt.Rows[i]["是否全日制师范类专业毕业"].ToString() == "否" ? 0 : 1;
                            try
                            {
                                model.InformationLevel = (int)Enum.Parse(typeof(CommonEnum.InformationLevel), dt.Rows[i]["信息技术应用能力"].ToString());

                            }
                            catch (Exception)
                            {
                                model.InformationLevel = (int)CommonEnum.InformationLevel.精通;
                            }
                            try
                            {
                                model.GrassStartDate = dt.Rows[i]["参加基层服务项目起始年月"].ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dt.Rows[i]["参加基层服务项目起始年月"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("请填写正确的参加基层服务项目起始年月,【第" + (i + 2) + "行】");
                                return;
                            }
                            try
                            {
                                model.GrassEndDate = dt.Rows[i]["参加基层服务项目结束年月"].ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(dt.Rows[i]["参加基层服务项目结束年月"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("请填写正确的参加基层服务项目结束年月,【第" + (i + 2) + "行】");
                                return;
                            }
                            model.CardType = 196;
                            model.EmploymentType = (int)CommonEnum.EmploymentForm.其他;
                            model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报
                            // model.AduitState=(int)CommonEnum
                            model.TNation = (int)CommonEnum.MZ.汉族;
                            model.CreateDate = DateTime.Now;
                            model.CreateUser = UserID;
                            model.IsDel = (int)CommonEnum.IsorNot.否;
                            model.Photos = "";
                            //  model.TeaAddress ="";
                            model.LinkPhone = "";
                            model.OtherLink = "";
                            model.IsRetire = (int)CommonEnum.IsorNot.否; 
                            #endregion
                            list[i] = model;


                        }

                        if (list != null)
                        {
                            int returnvalue = teacherDAL.Import(list);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入教师信息", UserID));
                                ShowMessage();
                            }
                            else
                            {
                                ShowMessage("保存失败");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("导入的信息存在错误");
                            return;
                        }
                    }
                    else
                    {
                        ShowMessage("文件中缺少必要的信息，请检查后重新导入");
                        return;
                    }
                }
                else
                {
                    ShowMessage("文件读取失败，请检查文件是否已损坏");
                    return;
                }
            }
            else
            {
                ShowMessage("文件导入失败");
                return;
            }
        }
        #endregion
    }
}