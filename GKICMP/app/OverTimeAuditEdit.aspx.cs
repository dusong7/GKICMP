using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace GKICMP.app
{
    public partial class OverTimeAuditEdit : PageBaseApp
    {
        //public LeaveDAL leaveDAL = new LeaveDAL();
        public OverTimeDAL overTimeDAL = new OverTimeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveAuditDAL leaveAuditDAL = new LeaveAuditDAL();
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
                OverTimeEntity model = overTimeDAL.GetObjByID(LID);
                if (model != null)
                {
                    this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                    this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                    this.ltl_ODays.Text = model.ODay.ToString();
                    this.ltl_OMark.Text = model.OMark.ToString();
                    this.ltl_OState.Text = CommonFunction.CheckEnum<CommonEnum.AduitState>(model.OState);
                    this.ltl_ApplyUser.Text = model.ApplyUserName;
                    //this.ltl_LType.Text = CommonFunction.CheckEnum<CommonEnum.LType>(model.LType);
                    this.ltl_OType.Text = model.OTypeName;
                    this.ltl_UsersName.Text = model.UsersName;


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
                    //            list.Add(dr["RealName"].ToString());
                    //            list.Add(dr["AuditDate"].ToString());
                    //            list.Add(dr["AuditResult"].ToString());
                    //            list.Add(dr["AuditMark"].ToString());
                    //            list.Add(dr["AuditOrder"].ToString());
                    //            dtneew.Rows.Add(list.ToArray());
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
            }
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
                int result = leaveAuditDAL.UpdateOvetTimeState(model);
                if (result == 0)
                {
                   
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核加班信息", UserID));
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='OverTimeAudit.aspx';", true);
                  
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