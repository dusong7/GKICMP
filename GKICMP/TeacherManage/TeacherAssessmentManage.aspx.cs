/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年01月22日 13时43分25秒
** 描    述:      教师管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.teachermanage
{
    public partial class TeacherAssessmentManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_AssessmentDAL teachAssessment = new Teacher_AssessmentDAL();
        #region 参数集合
        /// <summary>
        /// TID
        /// </summary>
        //public string Flag
        //{
        //    get
        //    {
        //        return GetQueryString<string>("Flag", "");
        //    }
        //}
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Flag == 1)
                { this.lbl_Menuname.Text = "年度考核管理"; this.ltl_Year.Text = "考核年份"; this.ltl_Years.Text = "考核年份"; }
                else
                { this.lbl_Menuname.Text = "师德考核管理"; this.ltl_Year.Text = "考核时间"; this.ltl_Years.Text = "考核时间"; }
                CommonFunction.BindEnum<CommonEnum.KHJG>(this.ddl_AssResult, "-2");
                this.hf_CID.Value = Flag.ToString();
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            //ViewState["TSYear"] = CommonFunction.GetCommoneString(this.txt_TSYear.Text.ToString().Trim());
            ViewState["TSYear"] = this.txt_TSYear.Text == "" ? "9999" : this.txt_TSYear.Text;  //  
            ViewState["AssResult"] = this.ddl_AssResult.SelectedValue.ToString();
            ViewState["TName"] = CommonFunction.GetCommoneString(this.txt_Name.Text);

        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Teacher_AssessmentEntity model = new Teacher_AssessmentEntity();
            //model.TSYear = Convert.ToDateTime(ViewState["TSYear"].ToString());
            model.AssResult = Convert.ToInt32(ViewState["AssResult"].ToString());
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.TID = (string)ViewState["TName"];

            model.TSYear = DateTime.ParseExact(ViewState["TSYear"].ToString(), "yyyy", System.Globalization.CultureInfo.CurrentCulture);
            //model.TFlag =int.Parse(Flag);//1 年度考核  2 师德考核
            model.TFlag = Flag;//1 年度考核  2 师德考核
            DataTable dt = teachAssessment.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value;
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teachAssessment.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师考核信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 上报 ---测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.TeacherAssessmentEntity> args = new List<GKICMP.localhost1.TeacherAssessmentEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_AssessmentEntity p = teachAssessment.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.TeacherAssessmentEntity model1 = new localhost1.TeacherAssessmentEntity();

                    model1.TAID = p.TAID;
                    //model1.TDepID = p.;//单位;
                    model1.TID = p.TID;//
                    //model1.TSYear = Convert.ToInt32(p.TSYear.ToString("yyyy"));//区平台字段类型不一致
                    model1.TSYear = p.TSYear;//区平台字段类型不一致
                    model1.AssResult = p.AssResult;
                    model1.TSDesc = p.TSDesc;
                    model1.TFalg = p.TFlag;

                    args.Add(model1);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.TeacherAssessmentEntity[] A = args.ToArray();
                if (service.TeacherAssessment(sguid, A, out aa))
                {
                    int rusult = teachAssessment.Update(id);//更新字段为 已上报

                    DataBindList();
                }
                ShowMessage(aa);
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 多条上报 ---测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string aa = "";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');

                List<GKICMP.localhost1.TeacherAssessmentEntity> args = new List<GKICMP.localhost1.TeacherAssessmentEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_AssessmentEntity p = teachAssessment.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.TeacherAssessmentEntity model1 = new localhost1.TeacherAssessmentEntity();

                    model1.TAID = p.TAID;
                    //model1.TDepID = p.;//单位;
                    model1.TID = p.TID;//
                    model1.TSYear = p.TSYear;//区平台字段类型不一致
                    model1.AssResult = p.AssResult;
                    model1.TSDesc = p.TSDesc;
                    model1.TFalg = p.TFlag;

                    args.Add(model1);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.TeacherAssessmentEntity[] A = args.ToArray();
                if (service.TeacherAssessment(sguid, A, out aa))
                {
                    int rusult = teachAssessment.Update(id);//更新字段为 已上报
                    DataBindList();
                }
                ShowMessage(aa);
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string sstate = state.ToString();
            if (sstate == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 添加
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('TeacherAssessmentEdit.aspx?flag={0}', '_self')</script>", Flag);
            Response.Write(aa);
        }
        #endregion


        #region 编辑
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            string logid = lbt.CommandName.ToString();
            string aa = string.Format("<script language=javascript>window.open('TeacherAssessmentEdit.aspx?id={0}&&flag={1}', '_self')</script>", logid, Flag);
            Response.Write(aa);
        }
        #endregion
    }
}