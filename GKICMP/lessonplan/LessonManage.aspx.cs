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
    public partial class LessonManage : PageBase
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


        #region 备课事件
        protected void lbtn_Bill_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string ldid = lbtn.CommandArgument.ToString();
            string ispre = lbtn.CommandName.ToString();

            Response.Write("<script language=javascript>window.open('LessonEdit.aspx?ldid=" + ldid + "&lid=" + LID + "&ltype=" + LType + "&isprepare=" + ispre + "&flag=1" + "', '_self')</script>");
        }
        #endregion
    }
}