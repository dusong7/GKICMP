/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年2月25日 09时17分
** 描 述:       任务详情
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.electiver
{
    public partial class ElectiverDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Electiver_CourseDAL electiver_CourseDAL = new Electiver_CourseDAL();
        public ElectiverDAL electiverDAL = new ElectiverDAL();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public int EleID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }

        public int SysMUID
        {
            get
            {
                return GetQueryString<int>("SysMUID", -1);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_SysMUID.Value = SysMUID.ToString();
                InfoBind();
                CourseBind();
            }
        }
        public void InfoBind()
        {
            ElectiverEntity model = electiverDAL.GetObjByID(EleID);
            if (model != null)
            {
                this.ltl_ElectiverName.Text = model.ElectiverName;
                this.ltl_EYear.Text = model.EYear;
                this.ltl_TermID.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(model.TermID);
                this.ltl_EBegin.Text = model.EBegin.ToString("yyyy-MM-dd");
                this.ltl_EEnd.Text = model.EEnd.ToString("yyyy-MM-dd");
                this.ltl_EstimateBDate.Text = model.EstimateBDate.ToString("yyyy-MM-dd");
                this.ltl_EstimateEDate.Text = model.EstimateEDate.ToString("yyyy-MM-dd");
                this.ltl_EStopDate.Text = model.EStopDate.ToString("yyyy-MM-dd");
                int state=GetState(model.IsEstmate,model.EBegin, model.EEnd, model.EstimateBDate, model.EstimateEDate);
                this.ltl_EState.Text = state == 1 ? CommonFunction.CheckEnum<CommonEnum.ElectiveState>(1) : state == 2 ? CommonFunction.CheckEnum<CommonEnum.ElectiveState>(2) : state == 3 ? CommonFunction.CheckEnum<CommonEnum.ElectiveState>(3) : CommonFunction.CheckEnum<CommonEnum.ElectiveState>(4);
               // this.ltl_EState.Text = CommonFunction.CheckEnum<CommonEnum.ElectiveState>(model.EState);
                this.ltl_CreateUser.Text = model.CreateUserName;
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
            }
        }
        public void CourseBind()
        {
            DataTable dt = electiver_CourseDAL.GetList(EleID);
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
        public int GetState(int IsEstmate, DateTime begin, DateTime end, DateTime ebegin, DateTime eend)
        {
            if (IsEstmate == 1)
            {

                if (DateTime.Parse((ebegin).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return 1;
                }
                else if (DateTime.Parse((end).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    //return CommonEnum.ElectiveState.结束.ToString();
                    return 4;
                }
                else if (DateTime.Parse((eend).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
              
            }
            else
            {
                if (DateTime.Parse((end).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return 4;
                }
                else if (DateTime.Parse((begin).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                    return 1;
                else
                    return 3;
            }
        }
    }
}