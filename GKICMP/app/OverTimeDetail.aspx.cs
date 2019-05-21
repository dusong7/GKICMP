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
    public partial class OverTimeDetail : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        //public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        public OverTimeDAL overTimeDAL = new OverTimeDAL();
        
        #region 参数集合
        public string OID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// 1学生 2其他
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OverTimeEntity model = overTimeDAL.GetObjByID(OID);
                if (model != null)
                {
                    //this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                    //this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                    this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd ");
                    this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd ");
                    this.ltl_ODays.Text = model.ODays.ToString();
                    this.ltl_OMark.Text = model.OMark.ToString();
                    this.ltl_OState.Text = CommonFunction.CheckEnum<CommonEnum.AduitState>(model.OState);
                    this.ltl_ApplyUser.Text = model.ApplyUserName;
                    //this.ltl_LType.Text = CommonFunction.CheckEnum<CommonEnum.LType>(model.LType);
                    this.ltl_OType.Text = model.OTypeName;
                    this.ltl_UsersName.Text = model.UsersName;


                    DataTable dt = auditDAL.GetList(OID);
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
                                DataRow[] drselect = dt.Select("AuditOrder=" + dr["AuditOrder"] + " and AuditResult<>1 and AuditDate is not null");
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
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        List<string> list = new List<string>();
                    //        if (dr["IsCurrent"].ToString() != "1")
                    //        {
                    //            DataRow[] drselect = dt.Select("AuditOrder=" + dr["AuditOrder"] + " and AuditResult<>1");
                    //            if (drselect.Length > 0)
                    //            {
                    //                if (dtneew.Select("AuditOrder=" + dr["AuditOrder"]).Length <= 0)
                    //                {

                    //                    list.Add(drselect[0]["RealName"].ToString());
                    //                    list.Add(drselect[0]["AuditName"].ToString());
                    //                    list.Add(drselect[0]["AuditDate"].ToString());
                    //                    list.Add(drselect[0]["AuditResult"].ToString());
                    //                    list.Add(drselect[0]["AuditMark"].ToString());
                    //                    list.Add(drselect[0]["AuditOrder"].ToString());
                    //                    dtneew.Rows.Add(list.ToArray());
                    //                }
                    //            }
                    //            else
                    //            {
                    //                if (dtneew.Select("AuditOrder=" + dr["AuditOrder"]).Length <= 0)
                    //                {
                    //                    list.Add(dr["RealName"].ToString());
                    //                    list.Add(dr["AuditName"].ToString());
                    //                    list.Add(dr["AuditDate"].ToString());
                    //                    list.Add(dr["AuditResult"].ToString());
                    //                    list.Add(dr["AuditMark"].ToString());
                    //                    list.Add(dr["AuditOrder"].ToString());
                    //                    dtneew.Rows.Add(list.ToArray());
                    //                }
                    //            }

                    //        }
                    //        else
                    //        {
                    //            //DataRow[] drselect = dt.Select("AuditOrder=" + dr["AuditOrder"]);
                    //            //foreach (DataRow d in drselect)
                    //            //{
                    //            list.Add(dr["RealName"].ToString());
                    //            list.Add(dr["AuditName"].ToString());
                    //            list.Add(dr["AuditDate"].ToString());
                    //            list.Add(dr["AuditResult"].ToString());
                    //            list.Add(dr["AuditMark"].ToString());
                    //            list.Add(dr["AuditOrder"].ToString());
                    //            dtneew.Rows.Add(list.ToArray());
                    //            //}
                    //        }
                    //    }
                        
                    //}
                    DataView dv = dtneew.DefaultView;
                    //dv.Sort = "AuditOrder asc";
                    dv.Sort = "auditorder asc,AuditDate asc";
                    dtneew = dv.ToTable();
                    this.rp_List.DataSource = dtneew;
                    this.rp_List.DataBind();
                }
            }
        }
        #endregion
    }
}