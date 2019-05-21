using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace GKICMP.app
{
    public partial class LeaveAuditEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        #region 参数集合
        /// <summary>
        /// LAID 审核ID
        /// </summary>
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
        public int flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lbl_title.Text = flag == 1 ? "请假审核" : "外出审核";
                this.lbl_User.Text = this.lbl_Num.Text = this.lbl_UserSeason.Text = flag == 1 ? "请假" : "外出";

                //flag == 1 ? lx.Style["display"] = "none" : lx.Style["display"] = "none";
                //flag == 1 ? lx.Attributes.Add("display", "none") :"";
               

                    if(flag != 1 )
                    {
                        //lx.Attributes.Add("display", "none");
                        lx.Style["display"] = "none";
                    }
                    else
                    {
                        
                    }
               

                if (LID != "")
                {
                    LeaveEntity model = leaveDAL.GetObjByID(LID);
                    if (model != null)
                    {
                        this.lbl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd") + (Convert.ToInt32(model.BeginDate.ToString("HH")) == 7 ? " 上午" : " 下午");
                        this.lbl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd") + (Convert.ToInt32(model.EndDate.ToString("HH")) == 13 ? " 上午" : " 下午");
                        this.lbl_IsOK.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsOK);
                        this.lbl_LeaveDays.Text = model.LeaveDays.ToString("#0.0");
                        //this.lbl_LeaveFile.Text = model.LeaveFile;
                        this.lbl_LeaveMark.Text = model.LeaveMark;
                        this.lbl_LeaveState.Text = CommonFunction.CheckEnum<CommonEnum.AduitState>(model.LeaveState);
                        this.lbl_LeaveUser.Text = model.LeaveUserName;
                        //this.lbl_LType.Text = CommonFunction.CheckEnum<CommonEnum.LType>(model.LType); 
                        this.lbl_LType.Text = model.LTypeName;

                        AuditBind();
                    }
                }
            }
        }
        //

        public void AuditBind()
        {
            //DataTable dt = leaveAuditDAL.GetList(LID);
            //DataTable dtneew = new DataTable();
            //dtneew.Columns.Add("RealName", typeof(string));
            //dtneew.Columns.Add("AuditDate", typeof(string));
            //dtneew.Columns.Add("AuditResult", typeof(string));
            //dtneew.Columns.Add("AuditMark", typeof(string));
            //dtneew.Columns.Add("AuditOrder", typeof(string));
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        List<string> list = new List<string>();
            //        DataRow[] drselect = dt.Select("AuditOrder=" + dr["AuditOrder"] + " and AuditResult<>1");
            //        if (drselect.Length > 0)
            //        {
            //            if (dtneew.Select("AuditOrder=" + dr["AuditOrder"]).Length <= 0)
            //            {

            //                list.Add(drselect[0]["RealName"].ToString());
            //                list.Add(drselect[0]["AuditDate"].ToString());
            //                list.Add(drselect[0]["AuditResult"].ToString());
            //                list.Add(drselect[0]["AuditMark"].ToString());
            //                list.Add(drselect[0]["AuditOrder"].ToString());
            //                dtneew.Rows.Add(list.ToArray());
            //            }
            //        }
            //        else
            //        {
            //            if (dtneew.Select("AuditOrder=" + dr["AuditOrder"]).Length <= 0)
            //            {
            //                list.Add(dr["RealName"].ToString());
            //                list.Add(dr["AuditDate"].ToString());
            //                list.Add(dr["AuditResult"].ToString());
            //                list.Add(dr["AuditMark"].ToString());
            //                list.Add(dr["AuditOrder"].ToString());
            //                dtneew.Rows.Add(list.ToArray());
            //            }
            //        }
            //    }

            //}

            //this.rp_List.DataSource = dtneew;
            //this.rp_List.DataBind();

            DataTable dt = leaveAuditDAL.GetList(LID);
            DataTable dtneew = new DataTable();
            dtneew.Columns.Add("RealName", typeof(string));
            dtneew.Columns.Add("AuditName", typeof(string));
            dtneew.Columns.Add("AuditDate", typeof(string));
            dtneew.Columns.Add("AuditResult", typeof(string));
            dtneew.Columns.Add("AuditMark", typeof(string));
            dtneew.Columns.Add("AuditOrder", typeof(string));
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    List<string> list = new List<string>();
                    if (dr["IsCurrent"].ToString() != "1")
                    {
                        DataRow[] drselect = dt.Select("AuditOrder=" + dr["AuditOrder"] + " and AuditResult<>1");
                        if (drselect.Length > 0)
                        {
                            if (dtneew.Select("AuditOrder=" + dr["AuditOrder"]).Length <= 0)
                            {

                                list.Add(drselect[0]["RealName"].ToString());
                                list.Add(drselect[0]["AuditName"].ToString());
                                list.Add(drselect[0]["AuditDate"].ToString());
                                list.Add(drselect[0]["AuditResult"].ToString());
                                list.Add(drselect[0]["AuditMark"].ToString());
                                list.Add(drselect[0]["AuditOrder"].ToString());
                                dtneew.Rows.Add(list.ToArray());
                            }
                        }
                        else
                        {
                            if (dtneew.Select("AuditOrder=" + dr["AuditOrder"]).Length <= 0)
                            {
                                list.Add(dr["RealName"].ToString());
                                list.Add(dr["AuditName"].ToString());
                                list.Add(dr["AuditDate"].ToString());
                                list.Add(dr["AuditResult"].ToString());
                                list.Add(dr["AuditMark"].ToString());
                                list.Add(dr["AuditOrder"].ToString());
                                dtneew.Rows.Add(list.ToArray());
                            }
                        }
                    }
                    else
                    {
                        //DataRow[] drselect = dt.Select("AuditOrder=" + dr["AuditOrder"]);
                        //foreach (DataRow d in drselect)
                        //{
                        list.Add(dr["RealName"].ToString());
                        list.Add(dr["AuditName"].ToString());
                        list.Add(dr["AuditDate"].ToString());
                        list.Add(dr["AuditResult"].ToString());
                        list.Add(dr["AuditMark"].ToString());
                        list.Add(dr["AuditOrder"].ToString());
                        dtneew.Rows.Add(list.ToArray());
                        //}
                    }
                }

            }
            DataView dv = dtneew.DefaultView;
            //dv.Sort = "AuditOrder asc";
            dv.Sort = "auditorder asc,AuditDate asc";
            dtneew = dv.ToTable();
            this.rp_List.DataSource = dtneew;
            this.rp_List.DataBind();

        }


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Leave_AuditEntity model = new Leave_AuditEntity();
                model.LAID = LAID.ToString();
                model.AuditMark = this.txt_AuditMark.Text;
                model.AuditResult = Convert.ToInt32(this.hf_AuditResult.Value);
                model.LID = LID.ToString();
                int result = leaveAuditDAL.UpdateState(model);
                if (result == 0)
                {
                    if (flag == 1)
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核请假信息", UserID));
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='LeaveAudit.aspx';", true);
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核外出登记信息", UserID));
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='TraveAudit.aspx';", true);
                    }
                }
                else if (result == -1)
                {
                    ShowMessage("或签已审核，无需再审");
                    return;
                }
                else
                {
                    ShowMessage("保存失败");
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
    }
}