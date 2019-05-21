/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2016年11月08日
** 描 述:       新闻栏目编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.IO;
using System.Text;

namespace GKICMP.cms
{
    public partial class MenuEdit : PageBase
    {
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public int MID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }


        /// <summary>
        /// deep
        /// </summary>
        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
            }
        }
        #endregion


        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.MType>(this.ddl_rbol_MType, "-99"); //栏目类别
                BandDepart();
                string rep_path = Server.MapPath("..\\Temp");
                string[] files = Directory.GetFiles(rep_path);
                List<string> List_files = new List<string>();
                List<string> Comment_files = new List<string>();
                for (int i = 0; i < files.Length; i++)
                {
                    string a = Path.GetFileName(files[i].Substring(0, files[i].LastIndexOf('.')));
                    if (files[i].ToLower().IndexOf("list") > 0)
                        List_files.Add(Path.GetFileName(files[i]));
                    else if (a != "head" && a != "index" && a != "foot")
                        Comment_files.Add(Path.GetFileName(files[i]));

                }
                this.ddl_MenuTemplate.DataSource = List_files;
                this.ddl_DetailTemplate.DataSource = Comment_files;
                this.ddl_MenuTemplate.DataBind();
                this.ddl_DetailTemplate.DataBind();
                //foreach(string  f in files)
                //{
                //    if (f.IndexOf("List") > 0) 
                //    {

                //    }
                //}

                //DataTable LBT = TempleteBLL.GetList(1);
                //DataTable NRT = TempleteBLL.GetList(2);
                //CommonFunction.DDlTypeBind(this.ddl_LBT, LBT, "TID", "TemName", "-2");
                //this.ddl_LBT.SelectedValue = "1";
                //CommonFunction.DDlTypeBind(this.ddl_NRT, NRT, "TID", "TemName", "-2");
                //this.ddl_NRT.SelectedValue = "3";

                if (MID != 0)
                {
                    DataTable dtType = web_MenuDAL.GetTable("-2", (int)CommonEnum.Deleted.未删除);
                    ModelParent(dtType, "-1", this.ddl_MID, "");
                    ddl_MID.Items.Insert(0, new ListItem("--顶级栏目--", "-1"));
                }
                else
                {
                    ddl_MID.Items.Insert(0, new ListItem("--顶级栏目--", "-1"));
                }
                this.hf_ID.Value = MID.ToString();

                if (MID != 0)
                {
                    TreeBind();
                }
                else
                {
                    this.hf_PID.Value = "-1";
                }
            }
        }
        #endregion
        #region 教师绑定
        /// <summary>
        /// 教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = DepartList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Role').combotree({");
            sb.Append(" data:[");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: true,");
            sb.Append("multiline: false,");
            sb.Append("});");
            sb.Append(" }); </script>");

            this.ltl_Role.Text = sb.ToString();

        }
        private string DepartList()
        {
            DataTable dt;


            dt = sysRoleDAL.GetTable((int)CommonEnum.IsorNot.否);
            string name = string.Empty;
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //this.hf_SelectedValue.Value += dt.Rows[i]["UID"].ToString() + ',';
                    name += "{\"id\":\"" + dt.Rows[i]["RoleID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RoleName"].ToString() + "\"},";
                }
            }
            //sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("]");
            return sb.ToString();
        }
        #endregion

        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            string slt;
            slt = string.Format("PID='{0}'", parentid);
            DataRow[] drarr = dt.Select(slt);
            foreach (DataRow dr in drarr)
            {
                if (parentid == "-1")
                {
                    str_ = "";
                }
                else
                {
                    str_ = "├";
                }
                ListItem item = new ListItem();
                item.Text = str + str_ + dr["MName"].ToString();
                item.Value = dr["MID"].ToString();
                string parent_id = item.Value;
                ddl.Items.Add(item);

                ModelParent(dt, parent_id, ddl, str + "..");
            }

        }
        #endregion


        #region 绑定信息
        /// <summary>
        /// 绑定信息
        /// </summary>
        private void TreeBind()
        {
            this.hf_ID.Value = MID.ToString();
            Web_MenuEntity model = web_MenuDAL.GetObjByID(MID);
            this.ddl_MID.SelectedValue = model.PID;
            this.txt_MName.Text = model.MName;
            this.hf_PID.Value = model.PID.ToString();
            //if (model.PID != "-1")
            //{
            //    Web_MenuEntity pmodel = web_MenuDAL.GetObjByID(model.PID);
            //    //this.txt_PMName.Text = pmodel.MName;
            //}
            this.txt_MOrder.Text = model.MOrder.ToString();
            this.ddl_rbol_MType.SelectedValue = model.MType.ToString();
            this.txt_LinkUrl.Text = model.LinkUrl;
            this.rbol_MState.SelectedValue = model.IsNavigation.ToString();
            this.txt_MenuTitle.Text = model.MenuTitle;
            this.txt_MKeyWords.Text = model.MKeyWords;
            this.txt_MDescription.Text = model.MDescription;
            this.Image2.ImageUrl = this.hf_imageurl.Value = model.ImageUrl;//缩略图
            this.txt_Content.Text = model.MContent;//内容

            this.Image1.ImageUrl = this.hf_MNanner.Value = model.MNanner;
            this.txt_EngName.Text = model.EngName;//英文名称
            this.ddl_MenuTemplate.SelectedValue = model.MenuTemplate;//栏目模版
            this.ddl_DetailTemplate.SelectedValue = model.DetailTemplate;//
            this.rbl_IsOpen.SelectedValue = model.IsOpen.ToString();//
            this.rbl_IsComment.SelectedValue = model.IsComment.ToString();//
            this.rbl_IsCommentAudit.SelectedValue = model.IsCommentAudit.ToString();//
            this.rbl_IsAudit.SelectedValue = model.IsAudit.ToString();//
            this.txt_TIDS.Text = model.AduitUser == null ? "" : model.AduitUser.ToString();
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#Role').combotree('setValues', '");
            sb1.Append(model.PublishRoles);
            sb1.Append("');");
            //sb1.Append("$('#Role').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();

        }
        #endregion


        #region 添加子栏目
        /// <summary>
        /// 添加子栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Click(object sender, EventArgs e)
        {

            this.hf_PID.Value = this.hf_ID.Value;
            this.hf_ID.Value = "0";
            this.ddl_MID.SelectedValue = this.hf_PID.Value;
            //this.txt_PMName.Text = this.txt_MName.Text;
            this.txt_MName.Text = "";
            this.btn_Delete.Visible = this.btn_Add.Visible = false;
            this.ddl_rbol_MType.SelectedValue = "2";//类别
            this.rbol_MState.SelectedValue = "1";//是否显示
            this.txt_LinkUrl.Text = "";
            this.txt_MDescription.Text = "";
            this.txt_MenuTitle.Text = "";
            this.txt_MKeyWords.Text = "";
            this.txt_Content.Text = "";//内容
            this.txt_EngName.Text = "";//英文名称  

        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            Web_MenuEntity model = new Web_MenuEntity();
            //if (this.hf_SelectedValue.Value == "") { ShowMessage("发布角色不能为空"); return; }
            model.MID = int.Parse(this.hf_ID.Value);
            model.MName = this.txt_MName.Text;
            model.PID = this.ddl_MID.SelectedValue;
            model.MOrder = Convert.ToInt32(this.txt_MOrder.Text);//排序
            model.MType = Convert.ToInt32(this.ddl_rbol_MType.SelectedValue);//类别
            model.IsNavigation = Convert.ToInt32(this.rbol_MState.SelectedValue);//是否显示
            model.LinkUrl = this.txt_LinkUrl.Text;
            model.MenuTitle = this.txt_MenuTitle.Text;
            model.MKeyWords = this.txt_MKeyWords.Text;
            model.MDescription = this.txt_MDescription.Text;
            model.MContent = this.txt_Content.Text;//内容
            //
            model.EngName = this.txt_EngName.Text;//英文名称
            model.MenuTemplate = this.ddl_MenuTemplate.SelectedValue;//栏目模版
            model.DetailTemplate = this.ddl_DetailTemplate.SelectedValue;//
            model.IsOpen = int.Parse(this.rbl_IsOpen.SelectedValue);//
            model.IsComment = int.Parse(this.rbl_IsComment.SelectedValue);//
            model.IsCommentAudit = int.Parse(this.rbl_IsCommentAudit.SelectedValue);//
            model.IsAudit = int.Parse(this.rbl_IsAudit.SelectedValue);//
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.PublishRoles = "";
           // model.MenuTemplate = this.ddl_MenuTemplate.SelectedValue;
            model.DetailTemplate = this.ddl_DetailTemplate.SelectedValue;
            model.PublishRoles = this.Role.Text;
            model.AduitUser = this.txt_TIDS.Text.ToString();
            //上传图片
            int upsize = 4000000;
            try
            {
                upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
            }
            catch (Exception) { }
            AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "ImageUrl");
            AccessoryEntity accessinfo1 = CommonFunction.upfile(1, 2, hf_MNanner, "ImageUrl");
            if (accessinfo.AccessID == "-2")
            {
                //刚才上传的文件删除
                CommonFunction.delfile(hf_UpFile.Value.ToString());
                ShowMessage(accessinfo.AccessName);
                return;
            }
            else
            {
                if (this.fl_UpFile.HasFile)
                    model.ImageUrl = accessinfo.AccessUrl;
                else
                    model.ImageUrl = this.hf_imageurl.Value;
            }
            if (accessinfo1.AccessID == "-2")
            {
                //刚才上传的文件删除
                CommonFunction.delfile(hf_MNanner.Value.ToString());
                ShowMessage(accessinfo1.AccessName);
                return;
            }
            else
            {
                if (this.fl_MNanner.HasFile)
                    model.MNanner = accessinfo1.AccessUrl;
                else
                    model.MNanner = this.hf_MNanner.Value;
            }
            int result = web_MenuDAL.Edit(model);
            if (result == -1)
            {
                ShowMessage("提交失败");
                return;
            }
            else if (result == -2)
            {
                ShowMessage("请重新输入");
                return;
            }
            else
            {
                if (MID == 0)
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加栏目【" + this.txt_MName.Text + "】信息", UserID));
                else
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改栏目【" + this.txt_MName.Text + "】信息", UserID));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
            }
        }
        #endregion


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            int ids = MID;
            try
            {
                int delresult = web_MenuDAL.DeleteBat(ids.ToString(), (int)CommonEnum.Deleted.删除);
                if (delresult == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除栏目【" + this.txt_MName.Text + "】信息", UserID));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：删除成功！');succ();</script>");
                }
                else if (delresult == -2)
                {
                    ShowMessage("该栏目下存在子栏目，请先删除子栏目");
                    return;
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}