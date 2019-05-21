/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:     2017年11月24日 14：55
** 描 述:       校讯通编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
namespace GKICMP.app
{
    public partial class AfficheResearch : PageBaseApp
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindList();
            }
        }
        #endregion

        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                AfficheEntity model = new AfficheEntity();
                model.AfficheTitle = this.txt_AfficheTitle.Text.Trim();
                model.AContent = this.txt_AContent.Text.Trim();
                model.SendUser = UserID;

                //model.AType = Convert.ToInt32(this.hf_Type.Value.ToString());
               // model.AType = 2088;//教研活动

                int sdid = 0;
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                //if (dt != null && dt.Rows.Count > 0)
                //{
                    foreach (DataRow dr in dt.Rows)
                    {
                        string bb = dr["DataName"].ToString();
                        if (dr["DataName"].ToString() == "教研活动")
                        {
                            sdid = Convert.ToInt32(dr["SDID"].ToString());
                        }
                    }
                //}

                model.AType = sdid;


                model.IsDisplay = 0;
                model.AFlag = 1;
                model.ClaID = 0;

                string ids = this.hf_UID.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');

                if (ids == "")
                {
                    ShowMessage("请选择参与人员");
                    return;
                }
                int result = afficheDDAL.ResearchEdit(model, ids);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加教研活动信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='AfficheResearchSend.aspx'</script>");
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
            }
        }
        #endregion

        #region 选择收件人绑定
        public void DataBindList()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpmodule.DataSource = dt;
                this.rpmodule.DataBind();
            }
        }

        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
            HiddenField hf_DID = (HiddenField)e.Item.FindControl("hf_DID");
            DataTable dt = sysUserDAL.GetSysUserByDepid((int)CommonEnum.UserType.老师, Convert.ToInt32(hf_DID.Value));
            if (dt != null && dt.Rows.Count > 0)
            {
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }
        #endregion
    }
}