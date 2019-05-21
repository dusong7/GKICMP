/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年05月15日
** 描 述:       考核信息编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;

namespace GKICMP.teachermanage
{
    public partial class TeacherHolidayEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public Teacher_HolidayDAL teacher_HolidayDAL = new Teacher_HolidayDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string THID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        /// <summary>
        /// TID
        /// </summary>
        //public string TID
        //{
        //    get
        //    {
        //        return GetQueryString<string>("tid", "");
        //    }
        //}
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.hf_SelectedValue.Value = TID;

            if (!IsPostBack)
            {
               // BandDepart();
                DataTable dtHType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.长假类型);
                CommonFunction.DDlTypeBind(this.ddl_HType, dtHType, "SDID", "DataName", "-2");
                if (THID != "")
                {
                    InfoBind();

                }
            }
        }
        #endregion



        #region 绑定教师姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#TeacherName').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#TeacherName').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        } 
        #endregion

        //#region 教师绑定
        ///// <summary>
        ///// 教师绑定
        ///// </summary>
        //private void BandDepart()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    string a = DepartList();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append(" $(function () {");
        //    sb.Append(" $('#TeacherName').combotree({");
        //    sb.Append(" data:[");
        //    sb.Append(a);
        //    sb.Append("],");
        //    sb.Append("multiple: false,");
        //    sb.Append("multiline: false,");
        //    sb.Append("});");
        //    sb.Append(" }); </script>");

        //    this.ltl_JQ.Text = sb.ToString();

        //}
        //private string DepartList()
        //{
        //    DataTable dt;
        //    dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
        //    string name = string.Empty;
        //    StringBuilder sb = new StringBuilder();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        //        }
        //    }
        //    sb.Append(name.ToString().TrimEnd(','));
        //    return sb.ToString();
        //}
        //#endregion

        #region 带部门的教师绑定
        /// <summary>
        /// 带部门的教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#TeacherName').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定职能部门信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt;
            dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
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
                    name += InitChild(dt.Rows[i]["DID"].ToString());
                    name += "},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }

        /// <summary>
        /// 绑定职能部门人员信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
                //
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
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            try
            {
                Teacher_HolidayEntity tmodel = teacher_HolidayDAL.GetObjByID(THID);
                if (tmodel != null)
                {
                    //SetValue(tmodel.TID);
                    //this.hf_SelectedValue.Value = tmodel.TID;
                    this.Series.Text = tmodel.TID;
                    this.Series.Enabled = false;

                    //this.txt_RealName.Text = tmodel.TName;
                    //this.hf_UID.Value = tmodel.TID;//教师
                    // this.TeacherName.Value = tmodel.TID;
                    this.img_SImage.ImageUrl = tmodel.HFile;
                    if (tmodel.HFile != "")//图片
                    {
                        this.img_SImage.ImageUrl = this.hf_SImage.Value = tmodel.HFile;
                    }
                    //this.txt_TSYear.Text = tmodel.TSYear.ToString() == "1990/1/1 0:00:00" ? "" : tmodel.TSYear.ToString("yyyy");
                    this.txt_HStartDate.Text = tmodel.HStartDate == null ? "" : tmodel.HStartDate.ToString("yyyy-MM-dd");
                    this.txt_HEndDate.Text = tmodel.HEndDate == null ? "" : tmodel.HEndDate.ToString("yyyy-MM-dd");
                    this.ddl_HType.SelectedValue = tmodel.HType.ToString();
                    this.txt_HolidayDesc.Text = tmodel.HolidayDesc;
                    this.txt_HDays.Text = tmodel.HDays.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,ex.Message, UserID));
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher_HolidayEntity model = new Teacher_HolidayEntity();
                model.THID = THID;
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                //model.TID = this.hf_SelectedValue.Value;//教师
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;


                model.HType = int.Parse(this.ddl_HType.SelectedValue);
                //model.TID = this.hf_UID.Value;//教师
                model.HStartDate = Convert.ToDateTime(this.txt_HStartDate.Text);//年份
                model.HEndDate = Convert.ToDateTime(this.txt_HEndDate.Text);//年份
                model.HolidayDesc = this.txt_HolidayDesc.Text;
                model.CreateDate = DateTime.Now;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;
                model.HDays = decimal.Parse(this.txt_HDays.Text);
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_SImage, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_SImage.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_SImage.HasFile)
                        model.HFile = accessinfo.AccessUrl;
                    else
                        model.HFile = this.hf_SImage.Value;
                }
                int result = teacher_HolidayDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = THID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (THID == "" ? "添加" : "修改") + "教师为：" + this.Series.Text + "长假信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}