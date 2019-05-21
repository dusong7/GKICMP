/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年07月06日 02点46分
** 描   述:      编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace GKICMP.office
{
    public partial class TraveLeaveDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();


        #region 参数集合
        public string LID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeaveEntity model = leaveDAL.GetObjByID(LID);
                if (model != null)
                {
                    //this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
                    //this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd");

                    this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd") + (Convert.ToInt32(model.BeginDate.ToString("HH")) == 7 ? " 上午" : " 下午");
                    this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd") + (Convert.ToInt32(model.EndDate.ToString("HH")) == 13 ? " 上午" : " 下午");
                    this.ltl_LeaveDate.Text = model.LeaveDate.ToString("yyyy-MM-dd HH:mm");

                    this.ltl_LeaveDays.Text = model.LeaveDays.ToString();
                    this.ltl_LeaveMark.Text = model.LeaveMark.ToString();
                    this.ltl_LeaveState.Text = CommonFunction.CheckEnum<CommonEnum.AduitState>(model.LeaveState);
                    this.ltl_LeaveUser.Text = model.LeaveUserName;
                    this.ltl_IsOK.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsOK);
                    AccessBind();
                    //DataTable dt = auditDAL.GetList(LID);
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    this.trnull.Visible = false;
                    //}
                    //else
                    //{
                    //    this.trnull.Visible = true;
                    //}
                    //this.rp_List.DataSource = dt;
                    //this.rp_List.DataBind();
                    DataTable dt = auditDAL.GetList(LID);
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
                      //  count = dtneew.Rows.Count;
                        this.trnull.Visible = false;
                    }
                    else
                    {
                        this.trnull.Visible = true;
                    }
                    DataView dv = dtneew.DefaultView;
                    dv.Sort = "auditorder asc,AuditDate asc";
                    dtneew = dv.ToTable();
                    this.rp_List.DataSource = dtneew;
                    this.rp_List.DataBind();
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