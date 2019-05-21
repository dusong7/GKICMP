/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年02月27日
** 描 述:       用户编辑页面
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
using System.Configuration;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
namespace GKICMP.networkteach
{
    public partial class NetworkTeachQuote : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public NetworkTeachDAL networkTeachDAL = new NetworkTeachDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public GradeLevelDAL gradeLevelDAL = new GradeLevelDAL();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public string NTID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = gradeLevelDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_EPID, dt, "GLID", "ShortName", "-2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CID, dtCourse, "CID", "CourseName", "-2");
                if (NTID != "")
                {
                    InfoBind();
                }
            }
        }
        #region 班级绑定
        /// <summary>
        /// 角色绑定
        /// </summary>
        private void cblBand()
        {
            //checkboxlist 绑定
            DataTable cla = departmentDAL.GetByGID(int.Parse(this.ddl_EPID.SelectedValue), (int)CommonEnum.Deleted.未删除);
            CommonFunction.CBLTypeBind(this.cbl_Class, cla, "DID", "OtherName");
        }

        #endregion

        #region 信息绑定
        public void InfoBind()
        {
            NetworkTeachEntity model = networkTeachDAL.GetObjByID(NTID);
            this.txt_NTTName.Text = model.NTTName;
            this.ddl_EPID.SelectedValue = model.EPID;
            this.ddl_CID.SelectedValue = model.CID.ToString();
            #region 班级绑定
            cblBand();
            DataTable dt = networkTeachDAL.GetClass(NTID);
            foreach (DataRow dr in dt.Rows)
            {
                string value = dr["ClaID"].ToString();
                foreach (ListItem li in this.cbl_Class.Items)
                {
                    if (value == li.Value)
                    {
                        li.Selected = true;
                    }
                }
            }
            #endregion
            this.txt_TeaBegin.Text = model.TeaBegin.ToString("yyyy-MM-dd HH:mm");
            this.txt_TeaEnd.Text = model.TeaEnd.ToString("yyyy-MM-dd HH:mm");
            this.cb_IsOrNot.Checked = model.IsCommunication == 1 ? true : false;
            this.hf_UpFile.Value = model.NTTUrl;
            this.hf_UpImg.Value = model.ImgUrl;
            //string cla = "";
            //foreach (ListItem li in this.cbl_Class.Items) 
            //{
            //    if (li.Selected)
            //    {
            //        cla = cla + li.Value + ",";
            //    }
            //}
        }
        #endregion
        #region 选择年级显示对应班级信息
        protected void ddl_MeetingRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblBand();
        }
        #endregion

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {

                NetworkTeachEntity model = new NetworkTeachEntity();
                model.NTID = "";
                model.NTTName = this.txt_NTTName.Text;
                model.EPID = this.ddl_EPID.SelectedValue;
                model.CID = int.Parse(this.ddl_CID.SelectedValue);
                string cla = "";
                //绑定角色
                foreach (ListItem li in this.cbl_Class.Items)
                {
                    if (li.Selected)
                    {
                        cla = cla + li.Value + ",";
                    }
                }
                model.Cla = cla.Trim(',');
                //int upsize = 4000000;
                //try
                //{
                //    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                //}
                //catch (Exception) { }
                //AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "NetworkTeac");
                //if (accessinfo.AccessID == "-2")
                //{
                //    //刚才上传的文件删除
                //    CommonFunction.delfile(hf_UpFile.Value.ToString());
                //    ShowMessage(accessinfo.AccessName);
                //    return;
                //}
                //else
                //{
                //    if (this.fl_UpFile.HasFile)
                //        model.NTTUrl = accessinfo.AccessUrl;
                //    else
                model.NTTUrl = this.hf_UpFile.Value;
                model.ImgUrl = this.hf_UpImg.Value;
                //}
                model.TeaBegin = Convert.ToDateTime(this.txt_TeaBegin.Text);
                model.TeaEnd = Convert.ToDateTime(this.txt_TeaEnd.Text);
                model.CreateUser = UserID;
                model.CreateDate = DateTime.Now;
                model.IsCommunication = this.cb_IsOrNot.Checked ? 1 : 0;
                int result = networkTeachDAL.Edit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "引用网路课程【" + this.txt_NTTName.Text + "】", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
    }
}