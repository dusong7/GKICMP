using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace GKICMP.app
{
    public partial class LeaveRecordDetail : PageBaseApp
    {
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
        #region 参数集合
        public string LID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string LAID
        {
            get
            {
                return GetQueryString<string>("laid", "");
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LID != "")
                {
                    LeaveEntity model = leaveDAL.GetObjByID(LID);
                    if (model != null)
                    {
                        this.lbl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd") ;
                        this.lbl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd") ;
                      
                        this.lbl_LeaveDays.Text = model.LeaveDays.ToString("#0.0");
                        this.lbl_LeaveMark.Text = model.LeaveMark;
                       
                        this.lbl_LeaveUser.Text = model.LeaveUserName;
                      
                        if (model.LeaveFile != "")
                        {
                            string[] arr = model.LeaveFile.Split('.');
                            if (arr[1].ToString() == "bmp" || arr[1].ToString() == "JPG" || arr[1].ToString() == "jpg" || arr[1].ToString() == "jpeg" || arr[1].ToString() == "gif" || arr[1].ToString() == "psd" || arr[1].ToString() == "png" || arr[1].ToString() == "tiff" || arr[1].ToString() == "tga" || arr[1].ToString() == "eps")
                            {
                                this.img.Visible = true;
                                this.fj.Visible = false;
                                this.image.ImageUrl = model.LeaveFile;
                            }
                            else
                            {
                                this.img.Visible = false;
                                this.fj.Visible = true;
                                AccessBind();
                            }
                        }
                        else
                        {
                            this.img.Visible = false;
                        }
                    }
                }
            }
        }
        #endregion

        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
        }


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }

        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = leaveDAL.GetTable(LID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion
    }
}