/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
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


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;


namespace GKICMP.teachermanage
{
    public partial class ContractEdit : PageBase
    {
        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();

        #region 参数集合
        /// <summary>
        /// TCID 合同ID
        /// </summary>
        public string TCID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        protected int v = 0;

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
                DataTable dtCType = SysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.BaseDataType.合同类型);
                CommonFunction.DDlTypeBind(this.ddl_CType, dtCType, "SDID", "DataName", "-2");

               // BandDepart(); //绑定教师

                if (TCID != "")
                {
                    InfoBind(0);
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


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind(int i)
        {
            Teacher_ContractEntity model = contractDal.GetObjByID(TCID);
            if (model != null)
            {
                //SetValue(model.TID);//绑定教师姓名
                //this.hf_SelectedValue.Value = model.TID;
                this.Series.Text = model.TID;
                this.Series.Enabled = false;

                //this.txt_TeacherName.Text = model.RealName.ToString();
                //this.hf_TID.Value = model.TID.ToString();
                this.txt_TCycle.Text = model.TCycle.ToString();
                this.ddl_CType.SelectedValue = model.CType.ToString();
                this.txt_TStartDate.Text = model.TStartDate.ToString("yyyy-MM-dd");
                this.txt_TEndDate.Text = model.TEndDate.ToString("yyyy-MM-dd");
                //this.hf_IDCard.Value = model.IDCard.ToString();

                if (i == 0)
                    this.hf_Images.Value = model.TCFile;
                if (model.TCFile != null && model.TCFile.ToString() != "")
                {
                    DataTable dt = new DataTable();
                    string[] FileList;
                    if (i == 0)
                        FileList = model.TCFile.Split(',');
                    else
                        FileList = this.hf_Images.Value.Split(',');
                    dt.Columns.Add("tcfile", typeof(string));

                    for (int j = 0; j < FileList.Length; j++)
                    {
                        DataRow dr = dt.NewRow();
                        if (FileList[j] != "")
                        {
                            dr["tcfile"] = FileList[j].ToString();
                            dt.Rows.Add(dr);
                        }
                    }
                    this.rp_File.DataSource = dt;
                    this.rp_File.DataBind();

                }
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
                Teacher_ContractEntity model = new Teacher_ContractEntity();
                model.TCID = TCID.ToString();
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                ////model.TID = this.hf_TID.Value.ToString();
                //model.TID = this.hf_SelectedValue.Value;//教师
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;

                model.CType = Convert.ToInt32(this.ddl_CType.SelectedValue.ToString());
                if (IsChange(this.txt_TCycle.Text.ToString()) == false)
                {
                    ShowMessage("合同周期请输入正确的正整数");
                    return;
                }
                else
                {
                    model.TCycle = Convert.ToInt32(this.txt_TCycle.Text.ToString());//合同周期
                }
                model.TStartDate = Convert.ToDateTime(this.txt_TStartDate.Text.ToString());
                model.TEndDate = Convert.ToDateTime(this.txt_TEndDate.Text.ToString());
                if (model.TStartDate > model.TEndDate)
                {
                    ShowMessage("学期结束时间须大于开始时间，请重新输入");
                    return;
                }
                model.TState = (int)CommonEnum.TState.正常;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报

                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, Convert.ToInt32(hf_UpFile.Value.Trim()), hf_UpFile, "profile");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = model.TCID;
                    accessinfo.ObjID = "";
                }
                model.TCFile = (this.hf_Images.Value + "," + accessinfo.AccessUrl).Trim(',');
                int result = contractDal.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "", UserID));
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
                return;
            }
        }
        #endregion

        #region 判断是否为Int类型
        /// <summary>
        /// 判断是否为Int类型
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public bool IsChange(string Str)
        {
            bool ret;
            int myNumber;
            try
            {
                myNumber = Convert.ToInt32(Str);
                if (myNumber <= 0)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        #endregion


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string path = e.CommandArgument.ToString().Trim();
            if (e.CommandName.ToString() == "del")
            {
                string path1 = HttpContext.Current.Server.MapPath(path);
                this.hf_Images.Value = this.hf_Images.Value.Replace(path, "").Trim(',');
                //int istrue = AccessoryBLL.Delete(accessid);
                //物理路径的文件删除
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }
                else
                {
                    ShowMessage("删除失败");
                }
                InfoBind(1);
            }
          
        }
        #endregion

        #region 下载删除
        /// <summary>
        /// 下载删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Download_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string op = lbtn.CommandName.ToString();
            //if (op == "Delete")
            if (op == "del")
            {
                this.hf_Images.Value = this.hf_Images.Value.Replace(id, "");
                string path = HttpContext.Current.Server.MapPath(id);
                //int istrue = AccessoryBLL.Delete(accessid);
                //物理路径的文件删除
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    ShowMessage("删除失败");
                }
                InfoBind(1);
            }
            if (op == "Download")
            {

                if (!CommonFunction.UpLoadFunciotn(id, "附件下载"))
                {
                    ShowMessage("下载文件不存在，请联系管理员!");
                    return;
                }

            }
        }
        #endregion

        protected void lbtn_ProView_Click(object sender, EventArgs e)
        {

        }

        protected void hf_TID_ValueChanged(object sender, EventArgs e)
        {
            //TeacherEntity model = teacherDAL.GetObjByID(this.hf_TID.Value.ToString());
            //if (model != null)
            //{
            //    //this.txt_DepName.Text = model.DepName.ToString();
            //    //this.hf_DepID.Value = model.DepID.ToString();
            //}
        }

    }
}