/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年5月25日
** 描 述:       新闻栏目编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Data;
using GK.GKICMP.DAL;
namespace GKICMP.cms
{
    public partial class NewsEdit : PageBase
    {
        public Web_NewsDAL web_NewsDAL = new Web_NewsDAL();
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();

        public static string audituser = "";
        public static int state = 0;

        #region 参数集合


        public int Flag
        {
            get { return GetQueryString<int>("flag", -1); }
        }

        public int NID
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
                this.txt_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DataTable dt = web_MenuDAL.GetTable((int)CommonEnum.Deleted.未删除);
                ModelParent(dt, "-1", this.ddl_MID, "");
                DataTable dtd = departmentDAL.GetDepList((int)CommonEnum.IsorNot.否);
                CommonFunction.DDlTypeBind(this.ddl_NDep, dtd, "DID", "DepName", "-2");
                this.txt_NAuthor.Enabled = false;
                if (NID != 0)
                {
                    InfoBind();
                }
                else
                {
                    //this.rbol_IsAudit.SelectedValue = 1;
                    //this.rbol_IsAudit.Enabled = false;
                    this.txt_NAuthor.Text = UserRealName;
                }

                Web_MenuEntity model = web_MenuDAL.GetObjByID(Convert.ToInt32(this.ddl_MID.SelectedValue.ToString()));
                if (model != null)
                {
                    if (model.AduitUser != null && model.AduitUser.ToString() != "" && model.IsAudit == (int)CommonEnum.IsorNot.是)//当栏目审核人不为空并且发布需要审核时
                    {
                        audituser = model.AduitUser.ToString();
                    }
                    else
                    {
                        audituser = "";//为栏目创建人
                    }
                    if (model.IsAudit == (int)CommonEnum.IsorNot.是)
                    {
                        state = (int)CommonEnum.IsorNot.否;
                    }
                    else
                    {
                        state = (int)CommonEnum.IsorNot.是;
                    }
                }
            }
        }
        #endregion


        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            foreach (DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = str + dr["MName"].ToString();     //Bind text
                item.Value = dr["MID"].ToString();  //Bind value
                string parent_id = item.Value;
                ddl.Items.Add(item);
                //  ModelParent(dt, parent_id, ddl, str + "..");
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Web_NewsEntity model = web_NewsDAL.GetObjByID(NID.ToString());
            if (model != null)
            {


                this.txt_NewsTitle.Text = model.NewsTitle;
                this.ddl_MID.SelectedValue = model.MID;
                this.txt_NAuthor.Text = model.NAuthorName;//作者
                this.txt_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                //this.ddl_NState.SelectedValue = model.Nstate.ToString(); //是否发布
                if (model.IsTop == 1)
                    this.cb_MKeyWords.Checked = true;
                if (model.MDescription == 1)
                    this.cb_MDescription.Checked = true;
                if (model.IsRecommend == 1)
                    this.cb_IsRecommend.Checked = true;
                if (model.IsImgNews == 1)
                    this.cb_IsImgNews.Checked = true;
                if (model.IsComment == 1)
                    this.cb_IsComment.Checked = true;

                this.txt_Content.Text = model.NContent;

                this.txt_NOrder.Text = model.NOrder.ToString();
                // this.txt_MSourse.Text = model.MSourse;
                this.ddl_NDep.SelectedValue = model.NDep.ToString();//内容所属部门
                this.txtvalue.Text = model.NColor;
                //if (model.LinkUrl != null && model.LinkUrl != "")
                //{
                this.txt_LinkUrl.Text = model.LinkUrl;
                //    this.ck_IsLink.Checked = true;
                //}
                this.txt_NTtitle.Text = model.NTtitle;
                this.txt_NKeyWords.Text = model.NKeyWords;
                this.txt_NDescription.Text = model.NDescription;
                if (!string.IsNullOrEmpty(model.ImageUrl))
                {
                    this.hf_imageurl.Value = model.ImageUrl;
                }
                this.Image1.ImageUrl = model.ImageUrl;
                //this.ddl_TempName.SelectedItem.Text = model.TempName;
                this.txt_ReadCount.Text = model.ReadCount.ToString();
                this.txt_CommentNumber.Text = model.CommentNumber.ToString();//评论次数
                //this.rbol_IsAudit.SelectedValue = model.IsAudit.ToString();
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
                int id;

                Web_NewsEntity model = new Web_NewsEntity();
                model.NewsTitle = this.txt_NewsTitle.Text;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.NID = NID;
                model.MID = this.ddl_MID.SelectedValue;
                model.NAuthor = UserID;
                if (!string.IsNullOrEmpty(this.txt_CreateDate.Text))
                    model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text);
                else
                    model.CreateDate = DateTime.Parse(DateTime.Now.ToString("G"));
                model.Nstate = state;//是否发布
                //置顶设置
                if (cb_MKeyWords.Checked)
                    model.IsTop = Convert.ToInt32(CommonEnum.IsorNot.是);
                else
                    model.IsTop = Convert.ToInt32(CommonEnum.IsorNot.否);
                if (cb_MDescription.Checked)
                    model.MDescription = Convert.ToInt32(CommonEnum.IsorNot.是);
                else
                    model.MDescription = Convert.ToInt32(CommonEnum.IsorNot.否);
                if (cb_IsRecommend.Checked)
                    model.IsRecommend = Convert.ToInt32(CommonEnum.IsorNot.是);
                else
                    model.IsRecommend = Convert.ToInt32(CommonEnum.IsorNot.否);
                if (cb_IsImgNews.Checked)
                    model.IsImgNews = Convert.ToInt32(CommonEnum.IsorNot.是);
                else
                    model.IsImgNews = Convert.ToInt32(CommonEnum.IsorNot.否);
                //if (ck_IsLink.Checked)
                //    model.IsLinked = 1;
                //else
                //    model.IsLinked = 0;
                if (this.cb_IsComment.Checked)
                    model.IsComment = Convert.ToInt32(CommonEnum.IsorNot.是);
                else
                    model.IsComment = Convert.ToInt32(CommonEnum.IsorNot.否);
                if (this.txt_Content.Text == "")
                { ShowMessage("新闻内容必须填写"); return; }
                else
                    model.NContent = this.txt_Content.Text;
                model.NOrder = Convert.ToInt32(this.txt_NOrder.Text);
                // model.MSourse = this.txt_MSourse.Text;
                model.NDep = int.Parse(this.ddl_NDep.SelectedValue);//内容所属部门
                model.CommentNumber = int.Parse(this.txt_CommentNumber.Text);//评论次数
                model.NColor = this.txtvalue.Text;
                model.LinkUrl = this.txt_LinkUrl.Text;
                // model.ImageUrl=this.hf_Image.Value;
                model.NTtitle = this.txt_NTtitle.Text;
                model.NKeyWords = this.txt_NKeyWords.Text;
                model.NDescription = this.txt_NDescription.Text;
                //model.TempName = this.ddl_TempName.SelectedItem.Text;
                if (!string.IsNullOrEmpty(this.txt_ReadCount.Text))
                    model.ReadCount = Convert.ToInt32(this.txt_ReadCount.Text);
                else
                    model.ReadCount = 0;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text);
                model.UpdateUser = UserID;
                model.UpdateDate = DateTime.Now;
              //  model.IsAudit = state == (int)CommonEnum.IsorNot.是 ? (int)CommonEnum.IsorNot.否 : (int)CommonEnum.IsorNot.是;
                model.AduitUser = audituser;

                if (NID == 0)
                    id = -1;
                else
                    id = 1;
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "ImageUrl");
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
                int result = web_NewsDAL.Edit(model,ref id);
                if (result > 0)
                {
                    int log = NID == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (NID == 0 ? "添加" : "修改") + "新闻标题为：" + this.txt_NewsTitle.Text + "新闻信息", UserID));

                    //flag:1=返回文章审核列表页面,2=我的文章列表,3
                    if (Flag == 1)
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');window.location.href = 'NewsAuditList.aspx';</script>");
                    else if (Flag == 2)
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');window.location.href = 'NewsListOfMine.aspx';</script>");
                    else
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                return;
            }
        }
        #endregion


        #region 返回
        protected void bt_ok_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsManage.aspx");
        }
        #endregion


        #region 根据栏目判断文章是否发布
        protected void ddl_MID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Web_MenuEntity model = web_MenuDAL.GetObjByID(Convert.ToInt32(this.ddl_MID.SelectedValue.ToString()));
            if (model != null)
            {
                if (model.AduitUser != null && model.AduitUser.ToString() != "" && model.IsAudit.ToString() == "1")//当栏目审核人不为空并且发布需要审核时
                {
                    audituser = model.AduitUser.ToString();
                }
                else
                {
                    audituser = "";//为栏目创建人
                }
                if (model.IsAudit == (int)CommonEnum.IsorNot.是)
                {
                    state = (int)CommonEnum.IsorNot.否;
                }
                else
                {
                    state = (int)CommonEnum.IsorNot.是;
                }
            }
        }
        #endregion
    }
}