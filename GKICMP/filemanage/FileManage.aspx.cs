
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;

namespace GKICMP.filemanage
{
    public partial class FileManage : PageBase
    {
        public FileBoxDAL fileBoxDAL = new FileBoxDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        #region 参数集合
        /// <summary>
        /// EID
        /// </summary>
        public int PID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
       
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DataBindList(PID);
                if (PID != -1)
                {
                    //返回上一级，获取上一级的pid
                    DataTable dt = fileBoxDAL.GetPid(PID);
                    if (dt != null && dt.Rows.Count > 0)
                        this.hf_PID.Value = dt.Rows[0]["PID"].ToString();
                }
            }
        }
        public void DataBindList(int id ) 
        {
            DataTable dt = fileBoxDAL.GetPaged(PID);
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();

        }
        public string GetPic(int flag, string formart) 
        {
            if (flag == 1)
            {
                return "../images/zy.png";
            }
            else
            {
                string pname = "";
                if (formart.ToString() == "jpg" || formart.ToString() == "gif" || formart.ToString() == "png" || formart.ToString() == "jpeg" || formart.ToString() == "psd" || formart.ToString() == "bmp")
                {
                    pname = "../images/bmp_icon.png";
                }
                else if (formart.ToString() == "xls" || formart.ToString() == "xlsx")
                {
                    pname = "../images/xlsx_icon.png";
                }
                else if (formart.ToString() == "doc" || formart.ToString() == "docx" || formart.ToString() == "wps")
                {
                    pname = "../images/docx_icon.png";
                }
                else if (formart.ToString() == "ppt" || formart.ToString() == "pps" || formart.ToString() == "ppsx")
                {
                    pname = "../images/pptx_icon.png";
                }
                else if (formart.ToString() == "txt")
                {
                    pname = "../images/text_icon.png";
                }
                else if (formart.ToString() == "zip" || formart.ToString() == "rar")
                {
                    pname = "../images/rar_icon.png";
                }
                else if (formart.ToString() == "pdf")
                {
                    pname = "../images/pdf_icon.png";
                }
                else if (formart.ToString() == "mp4")
                {
                    pname = "../images/wmv_file_icon.png";
                }
                else if (formart.ToString() == "mp4")
                {
                    pname = "../images/wmv_file_icon.png";
                }
                else if (formart.ToString() == "swf")
                {
                    pname = "../images/flash_icon.png";
                }
                else
                {
                    pname = "../images/unknown_ico.gif";
                }
                return pname;
            }
        }

        #region 下载资源
        protected void btn_Down_Click(object sender, EventArgs e)
        {
            // LinkButton btn = (LinkButton)sender;

            FileBoxEntity model = fileBoxDAL.GetObjByID(this.hf_FBID.Value);
            string expath = model.FileUrl;
            string name = model.FBName;
            if (!CommonFunction.UpLoadFunciotn(expath, name))
            {
                ShowMessage("资源不存在，请联系系统管理员");
                return;
            }
            int result = fileBoxDAL.DownLoad(this.hf_FBID.Value);
            sysLogDAL.Edit((new SysLogEntity("于"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"下载【" + model.FBName + "】资源", UserID)));
            this.hf_FBID.Value = "";
        } 
        #endregion

        #region 删除资源
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                FileBoxEntity model = fileBoxDAL.GetObjByID(this.hf_FBID.Value);
                string path = model.FileUrl;
                int result = fileBoxDAL.DeleteBat(this.hf_FBID.Value, UserID);
                if (result == 0)
                {
                    if (model != null && model.FileUrl != "")
                        CommonFunction.delfile(HttpContext.Current.Server.MapPath(model.FileUrl));
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资源", UserID));
                    sysLogDAL.Edit((new SysLogEntity("于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "删除【" + model.FBName + "】" + (model.FileUrl != ""?"的文件夹":"的资源"), UserID)));
                    ShowMessage("删除成功");
                }
                else if (result == -1)
                {
                    ShowMessage("您不是该文件夹的管理员，无法删除文件");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("此文件夹包含文件无法删除，请先删除里面的文件");
                    return;
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList(PID);

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, ex.Message, UserID));
                return;
            }
        } 
        #endregion

        #region 页面刷新
        protected void btn_Reload_Click(object sender, EventArgs e)
        {
            DataBindList(PID);
        } 
        #endregion

        #region 上传资源
        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            try
            {
                SysSetConfigEntity model1 = sysSetConfigDAL.GetObjByID();
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_File, "FileBox", model1);
                FileBoxEntity model = new FileBoxEntity();
                model.FBID = 0;
                model.FBName = accessinfo.AccessName;
                model.CreateUser = UserID;
                model.CreateDate = DateTime.Now;
                model.AdminID = UserID;
                model.PID = this.hf_FBID.Value == "" ? PID : int.Parse(this.hf_FBID.Value);
                // model.FileUrl = accessinfo.AccessUrl;
                //  model.RSize = 0;
                //model.RFormat = "";
                model.DownLoadNum = 0;
                model.FFlag = 2;//1文件夹，2文件

                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_File.Value.ToString());
                    //ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.FileUpload.HasFile)
                    {
                        model.FileUrl = accessinfo.AccessUrl;
                        model.RSize = this.FileUpload.PostedFile.ContentLength;
                        string a = System.IO.Path.GetExtension(this.FileUpload.PostedFile.FileName);
                        model.RFormat = a.Substring(a.LastIndexOf('.') + 1);
                    }
                    else
                        model.FileUrl = this.hf_File.Value;
                }
                int result = fileBoxDAL.Edit(model);
                if (result ==0)
                {
                    ShowMessage("提交成功");
                    DataBindList(PID);
                    sysLogDAL.Edit((new SysLogEntity("于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "上传【" + accessinfo.AccessName + "】资源", UserID)));

                    this.hf_FBID.Value = "";
                }
                else
                {
                    ShowMessage("上传资源失败");
                    sysLogDAL.Edit((new SysLogEntity("于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "上传【" + accessinfo.AccessName + "】资源失败", UserID)));
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
                return;
            }

        } 
        #endregion

        //protected void lbUploadPhoto_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_File, "FileBox");
        //        FileBoxEntity model = new FileBoxEntity();
        //        model.FBID = 0;
        //        model.FBName = accessinfo.AccessName;
        //        model.CreateUser = UserID;
        //        model.CreateDate = DateTime.Now;
        //        model.AdminID = UserID;
        //        model.PID = this.hf_PID.Value == "" ? PID : int.Parse(this.hf_PID.Value);
        //        // model.FileUrl = accessinfo.AccessUrl;
        //        //  model.RSize = 0;
        //        //model.RFormat = "";
        //        model.DownLoadNum = 0;
        //        model.FFlag = 2;//1文件夹，2文件

        //        if (accessinfo.AccessID == "-2")
        //        {
        //            //刚才上传的文件删除
        //            CommonFunction.delfile(hf_File.Value.ToString());
        //            ShowMessage(accessinfo.AccessName);
        //            return;
        //        }
        //        else
        //        {
        //            if (this.FileUpload.HasFile)
        //            {
        //                model.FileUrl = accessinfo.AccessUrl;
        //                model.RSize = this.FileUpload.PostedFile.ContentLength;
        //                string a = System.IO.Path.GetExtension(this.FileUpload.PostedFile.FileName);
        //                model.RFormat = a.Substring(a.LastIndexOf('.') + 1);
        //            }
        //            else
        //                model.FileUrl = this.hf_File.Value;
        //        }
        //        int result = fileBoxDAL.Edit(model);
        //        if (result > 0)
        //        {
        //            ShowMessage("提交成功");
        //            DataBindList(PID);
        //            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "上传资源成功", UserID));
        //        }
        //        else { ShowMessage("上传资源失败"); return; }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(ex.Message);
        //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
        //        return;
        //    }

        //}
   
    }
}