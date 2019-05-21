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

namespace GKICMP.resource
{
    public partial class EduResourseEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public GradeLevelDAL gradeLevelDAL = new GradeLevelDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        #region 参数集合
        public string Name = "";
        public string Url = "";

        public int Erid
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

                DataTable dt = gradeLevelDAL.GetList();//年级绑定
                CommonFunction.DDlTypeBind(this.ddl_GID, dt, "GLID", "ShortName", "-2");
                CommonFunction.BindEnum<CommonEnum.EType>(this.ddl_EType, "-2");//类别绑定
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TID, "-2");//类别绑定
                DataTable dtc = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CID, dtc, "CID", "CourseName", "-2");
                if (Erid != 0)
                {
                    InfoBind();
                }
                else 
                {
                    this.txt_DownLoadNum.Text = "0";
                }
            }
        }
        #endregion


        


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            EduResourceEntity model = eduResourceDAL.GetObjByID(Erid);
            if (model != null)
            {
               Name= this.txt_ResourseName.Text = model.ResourseName;
                this.ddl_GID.SelectedValue = model.GID.ToString();
                this.ddl_TID.SelectedValue = model.TID.ToString();
                this.ddl_CID.SelectedValue = model.CID.ToString();
                this.ddl_EType.SelectedValue = model.EType.ToString();
                this.txt_DownLoadNum.Text =    model.DownLoadNum.ToString();
               Url= this.hf_imageurl.Value = model.ResourseUrl;
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
                if (!this.fl_UpFile.HasFile) 
                {
                    ShowMessage("请选择课件");
                    return;
                }
                EduResourceEntity model = new EduResourceEntity();
                model.Erid = Erid;
                model.ResourseName = this.txt_ResourseName.Text;
                model.GID =int.Parse( this.ddl_GID.SelectedValue);
                model.TID =int.Parse( this.ddl_TID.SelectedValue);
                model.CID =int.Parse( this.ddl_CID.SelectedValue);
                model.EType =int.Parse( this.ddl_EType.SelectedValue);
                model.DownLoadNum =int.Parse( this.txt_DownLoadNum.Text);
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.IsExcellent = (int)CommonEnum.IsorNot.否;
                model.IsOpen = (int)CommonEnum.IsorNot.否;
                model.AuditState = (int)CommonEnum.NewsAuditState.未审;
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                SysSetConfigEntity model1 = sysSetConfigDAL.GetObjByID();
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "Resource", model1);
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
                    { 
                       // model.ResourseUrl = "~"+accessinfo.AccessUrl;
                        model.ResourseUrl =  accessinfo.AccessUrl;
                        model.RSize = this.fl_UpFile.PostedFile.ContentLength;
                        string a = System.IO.Path.GetExtension(this.fl_UpFile.PostedFile.FileName);
                        model.RFormat = a.Substring(a.LastIndexOf('.')+1);
                    }
                    //else
                    //    model.ResourseUrl = this.hf_imageurl.Value;
                }
                int result = eduResourceDAL.Edit(model);
                if (result > 0)
                {
                    int log = Erid == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (Erid == 0 ? "添加" : "修改") + "名为：" + this.txt_ResourseName.Text + "资源信息", UserID));
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
                    ShowMessage();
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,error.Message, UserID));
            }
        }
        #endregion


        #region 返回
        protected void bt_ok_Click(object sender, EventArgs e)
        {
            Response.Redirect("EduResourse.aspx");
        }
        #endregion
    }
}