/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      czz
** 创建日期:    2017年02月28日
** 描 述:       年级编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;
using System.Xml;
using System.Web.UI.WebControls;

namespace GKICMP.sysmanage
{
    public partial class GradeEdit : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL UserDal = new SysUserDAL();
        public DepartmentDAL departmentDal = new DepartmentDAL();
        public SysUserDAL sysUserDal = new SysUserDAL();
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public GradeLevelDAL gradeLevelDal = new GradeLevelDAL();
        public string a = "";

        #region 参数集合
        public int GID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion


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
                BandData();
                string[] arr = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "XD").Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    this.ddl_ShortName.Items.Add(new ListItem(arr[i].ToString() == "2" ? "小学" : "中学", arr[i].ToString()));
                }
                if (GID != 0)
                {
                    InfoBind();
                    //SetValue();
                }
            }
        }
        #endregion

        #region 绑定姓名
        private void SetValue()
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#txt_Duty').combotree('setValues', [");
            sb1.Append("\"" + this.hf_SelectedValue.Value.Trim(',') + "\"");
            sb1.Append("]);");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        #region 带分组人员绑定
        private void BandData()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#txt_Duty').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("multiline: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }
        private string MList()
        {
            DataTable dt;
            //获取所有的职能部门，部门类型为职能部门
            //dt = departmentDal.GetAllDeparInfo();
            dt = departmentDal.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                    //调用递归方法
                    //name += InitChild(dt.Rows[i]["DID"].ToString());
                    name += InitChild((int)CommonEnum.UserType.老师, dt.Rows[i]["DID"].ToString());//调用递归方法
                    name += "},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }
        //public string InitChild(string parentID)
        public string InitChild(int usertype, string parentID)
        {
            //DataTable dt = sysUserDal.GetTeacherByDepID(int.Parse(parentID));//GetSysUserByDepid
            DataTable dt = sysUserDal.GetSysUserByDepid(usertype, int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion

        #region 初始化用户数据
        private void InfoBind()
        {
            GradeEntity model = new GradeEntity();
            model = gradeDAL.GetObjByID(GID);
            if (model != null)
            {
                this.txt_GradeYear.Text = model.GradeYear.ToString();//年级名称
                GradeLevelEntity entity = gradeLevelDal.GetGradeLevelByGLID(model.ShortName);
                ddl_ShortName.SelectedValue = entity.GradeLever.ToString();
                //DataTable dt = egovernment_FlowDAL.GetTable(model.GradeDuty);
                //SysUserEntity entitys = UserDal.GetObjByID(model.GradeDuty);
                //a += "\"" + entitys.RealName + "\",";

                this.hf_SelectedValue.Value = model.GradeDuty;//年级负责人
                this.txt_Duty.Text = model.GradeDuty;//年级负责人

                this.txt_ClassNum.Text = Convert.ToString(model.ClassCount);//班级数
                this.txt_ClassNum.Enabled = false;

            }
        }
        #endregion


        //#region 提交
        ///// <summary>
        /////   提交
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>  
        //protected void btn_Sumbit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GradeEntity model = new GradeEntity();
        //        try
        //        {
        //            model.GID = 0;
        //            if (GID != -1)
        //            {
        //                model.GID = Convert.ToInt32(GID);
        //            }

        //            model.GradeYear = int.Parse(this.txt_GradeYear.Text.Trim().ToString());//入学年份
        //            // model.ShortName = int.Parse(ddl_ShortName.SelectedValue.ToString());
        //             int shortName=0;
        //             if (DateTime.Now.Month > 7)
        //                 shortName = DateTime.Now.Year - int.Parse(model.GradeYear.ToString()) + 1;
        //             else
        //                 shortName = DateTime.Now.Year - int.Parse(model.GradeYear.ToString()) ;
        //            if (shortName <= 0)
        //            {
        //                ShowMessage("该时间内不能设置年级");
        //                return;
        //            }
        //            string stime = DateTime.Now.ToString("MM-dd");

        //            if (int.Parse(ddl_ShortName.SelectedValue.ToString()) == 1 && shortName > 0 && shortName < 7)
        //            {
        //                if (DateTime.Parse(stime) < DateTime.Parse("09-01") && shortName != 1)
        //                {
        //                    model.ShortName = shortName - 1;
        //                }
        //                else
        //                {
        //                    model.ShortName = shortName;
        //                }
        //                model.GradeName = "小学" + model.GradeYear.ToString() + "级";
        //            }
        //            else if (int.Parse(ddl_ShortName.SelectedValue.ToString()) == 2 && shortName <= 3)
        //            {
        //                //model.ShortName = shortName + 6;
        //                if (DateTime.Parse(stime) < DateTime.Parse("09-01") && shortName != 1)
        //                {
        //                    model.ShortName = shortName + 5;
        //                }
        //                else
        //                {
        //                    model.ShortName = shortName + 6;
        //                }
        //                model.GradeName = "初中" + model.GradeYear.ToString() + "级";
        //            }
        //            else if (int.Parse(ddl_ShortName.SelectedValue.ToString()) == 3 && shortName <= 3)
        //            {
        //                //model.ShortName = shortName + 9;
        //                if (DateTime.Parse(stime) < DateTime.Parse("09-01") && shortName != 1)
        //                {
        //                    model.ShortName = shortName + 8;
        //                }
        //                else
        //                {
        //                    model.ShortName = shortName + 9;
        //                }
        //                model.GradeName = "高中" + model.GradeYear.ToString() + "级";
        //            }
        //            else
        //            {
        //                ShowMessage("该年份的同学已经毕业，请重新输入");
        //                return;
        //            }

        //            if (this.hf_SelectedValue.Value == "")
        //            {
        //                ShowMessage("请选择年级负责人");
        //                return;
        //            }
        //        }
        //        catch (Exception error)
        //        {
        //            SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID);
        //            ShowMessage(error.Message);
        //            return;
        //        }

        //        DepartmentDAL depart = new DepartmentDAL();
        //        DataTable dtDepart = depart.GetAllDeparInfo();
        //        for (int i = 0; i < dtDepart.Rows.Count; i++)
        //        {
        //            if (this.hf_SelectedValue.Value == dtDepart.Rows[i]["DID"].ToString())
        //            {
        //                ShowMessage("部门不可选做部门负责人");

        //                return;
        //            }
        //        }

        //        model.IsGraduate = 0;//是否毕业

        //        GradeEntity entity = new GradeEntity();
        //        try
        //        {
        //            if (GID != -1)
        //            {
        //                entity = GradeDAL.GetObjByID(GID);
        //                SysUserEntity entitys = UserDal.GetObjByID(entity.GradeDuty);
        //                string[] split = this.hf_SelectedValue.Value.Split(',');
        //                if (entitys != null)
        //                {
        //                    if (split[0].ToString() == entitys.RealName)
        //                    {
        //                        model.GradeDuty = entity.GradeDuty;
        //                    }
        //                    else
        //                    {
        //                        model.GradeDuty = this.hf_SelectedValue.Value;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                model.GradeDuty = this.hf_SelectedValue.Value;
        //            }
        //            model.CreateDate = DateTime.Now;//创建日期
        //            model.Notes = "";//备注
        //            model.Isdel = (int)CommonEnum.Deleted.未删除;
        //            model.GraduatePhoto = "";
        //        }
        //        catch (Exception exe)
        //        {
        //            SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.系统日志, exe.Message, UserID);
        //            ShowMessage(exe.Message);
        //            return;
        //        }
        //        int ads = int.Parse(this.txt_ClassNum.Text);
        //        int result = GradeDAL.Edit(model, int.Parse(this.txt_ClassNum.Text));

        //        if (result == -1)
        //        {
        //            ShowMessage("提交失败");
        //            return;
        //        }
        //        else if (result == -2)
        //        {
        //            ShowMessage("该年级名称已存在，请重新输入");
        //            return;
        //        }
        //        else
        //        {

        //            if (GID == -1)
        //            {
        //                SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加年级【" + model.GradeName.ToString() + "】信息", UserID);
        //                sysLogDAL.Edit(log);
        //            }
        //            else
        //            {
        //                SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改年级【" + model.GradeName.ToString() + "】信息", UserID);
        //                sysLogDAL.Edit(log);
        //            }
        //            ShowMessage();
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        ShowMessage(error.Message);
        //    }
        //}
        //#endregion

        #region 提交
        /// <summary>
        ///   提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                GradeEntity model = new GradeEntity();
                if (this.txt_Duty.Text == "") 
                {
                    ShowMessage("负责人不能为空");
                    return;
                }
                model.GID = GID;
                int shortname = DateTime.Now.Year - int.Parse(this.txt_GradeYear.Text);
                if (this.ddl_ShortName.SelectedValue == "2")//xiaoxue 
                {
                    if (shortname < 7 && shortname >= 0)
                    {
                        if (this.txt_GradeYear.Text == DateTime.Now.Year.ToString())
                        {
                            if (DateTime.Now.Month < 8)
                            {
                                ShowMessage("当前时间不可添加年级，请在8月后再添加");
                                return;
                            }
                            else
                            {
                                model.ShortName = 1;
                            }
                            model.GradeName = "小学" + this.txt_GradeYear.Text + "级";
                        }
                        else
                        {
                            if (DateTime.Now.Month < 8)
                            {
                                model.ShortName = shortname;
                                //model.GradeName = "小学" + (int.Parse(this.txt_GradeYear.Text) - 1) + "级";
                            }
                            else
                            {
                                model.ShortName = shortname + 1;
                            }
                            model.GradeName = "小学" + this.txt_GradeYear.Text + "级";
                        }
                    }
                    else 
                    {
                        ShowMessage("该年份的同学已经毕业，请重新输入");
                        return;
                    }

                }
                else //zhonguxe
                {
                    if (shortname < 4 && shortname >= 0)
                    {
                        if (this.txt_GradeYear.Text == DateTime.Now.Year.ToString())
                        {
                            if (DateTime.Now.Month < 8)
                            {
                                ShowMessage("当前时间不可添加年级，请在8月后再添加");
                                return;
                            }
                            else
                            {
                                model.ShortName = 1;
                            }
                            model.GradeName = "中学" + this.txt_GradeYear.Text + "级";
                        }
                        else
                        {
                            if (DateTime.Now.Month < 8)
                            {
                                model.ShortName = shortname+6;
                               
                            }
                            else
                            {
                                model.ShortName = shortname + 7;
                                
                            }
                            model.GradeName = "中学" + this.txt_GradeYear.Text + "级";
                        }
                    }
                }
               // model.GradeName = "";
               // model.ShortName = 0;



                model.GradeYear = int.Parse(this.txt_GradeYear.Text);
                model.IsGraduate = 0;
                model.GraduatePhoto = "";
               
                model.GradeDuty = this.txt_Duty.Text;
                model.CreateDate = DateTime.Now;
                model.Notes = "";
                model.Isdel = (int)CommonEnum.IsorNot.否;
                int result = gradeDAL.Edit(model,int.Parse(this.txt_ClassNum.Text));
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity(GID == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改,(GID == 0?"添加":"修改" )+"年级【" + model.GradeName.ToString() + "】信息", UserID));                 
                    ShowMessage();
                }
                else if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该年级名称已存在，请重新输入");
                    return;
                }
            }
            catch (Exception error)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                ShowMessage(error.Message);
            }
                
        }
        #endregion


    }
}