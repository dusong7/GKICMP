/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年10月20日 14时52分
** 描 述:       备课清单列表页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonPlanBillManage : PageBase
    {
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 备课计划ID
        /// </summary>
        public string LID
        {
            get
            {
                return GetQueryString<string>("lid", "");
            }
        }

        /// <summary>
        /// 课程类型：社团活动 体验课程
        /// </summary>
        public int LType
        {
            get
            {
                return GetQueryString<int>("ltype", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaseDataEntity bmodel = baseDataDAL.GetList(LType);
                if (bmodel != null)
                {
                    if (bmodel.DataName == "社团活动")
                    {
                        this.ltl_TeacherName.Text = "指导教师";
                    }
                    else
                    {
                        this.ltl_TeacherName.Text = "执教教师";
                    }
                }
                this.hf_LID.Value = LID.ToString();
                DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            DataTable dt = detailDAL.GetList(LID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion


        #region 删除事件
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();

                int result = detailDAL.DeleteBat(id);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除备课清单信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 备课事件
        protected void lbtn_Bill_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string ldid = lbtn.CommandArgument.ToString();

            Response.Write("<script language=javascript>window.open('LessonEdit.aspx?ldid=" + ldid + "&lid=" + LID + "&ltype=" + LType + "', '_self')</script>");
        }
        #endregion

        #region 编辑备课
        protected void lbtn_EditBill_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string ldid = lbtn.CommandArgument.ToString();

            Response.Write("<script language=javascript>window.open('LessonEdit.aspx?ldid=" + ldid + "', '_self')</script>");
        } 
        #endregion
    }
}