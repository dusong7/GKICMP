using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace GKICMP.projectmanage
{
    public partial class JJProjectAdd : PageBase
    {
        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string BAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BuildApplyDAL buildApplyDAL = new BuildApplyDAL();

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
                CommonFunction.BindEnum<CommonEnum.BSources>(this.ddl_BSources, "-2");//资金来源
                CommonFunction.BindEnum<CommonEnum.BuildNature>(this.ddl_BuildNature, "-2");//建设性质
               
                this.ltl_ApplyDep.Text =ConfigurationManager.AppSettings["SchoolName"];
                if (BAID != "")
                    InfoBind();
                else
                    this.ltl_ApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            BuildApplyEntity model = buildApplyDAL.GetObjByID(BAID);
            if (model != null)
            {
                this.ltl_ApplyDate.Text = model.ApplyDate.ToString("yyyy-MM-dd");
                this.txt_ProName.Text = model.ProName.ToString();
                this.ltl_ApplyDep.Text = model.ApplyDep.ToString();
                this.ltl_ApplyDate.Text = model.ApplyDate.ToString("yyyy年MM月dd日");
                this.txt_BuildContent.Text = model.BuildContent.ToString();
                this.txt_Structure.Text = model.Structure.ToString();
                this.txt_Acreage.Text = model.Acreage.ToString();
                this.txt_Layers.Text = model.Layers.ToString();
                this.txt_BudgetAmount.Text = model.BudgetAmount.ToString();

                this.ddl_BSources.SelectedValue = model.BSources.ToString();//资金来源
                this.ddl_BuildNature.SelectedValue = model.BuildNature.ToString();//建设性质

                this.txt_BuildAddr.Text = model.BuildAddr.ToString(); //实施地点
                this.txt_DutyUser.Text = model.DutyUser.ToString();//项目责任人
                this.txt_DutyNO.Text = model.DutyNO.ToString();//项目责任人联系人电话
                this.txt_Contractor.Text = model.DepUser.ToString();//申请单位联系人
                this.txt_PhoneNumber.Text = model.DepNO.ToString();//申请单位联系人联系电话
                this.txt_BuildReason.Text = model.BuildReason.ToString();
                this.ltl_Arrangement.Text = model.Arrangement.ToString();

                //DataTable dt = buildApplyDAL.GetTable(BAID);
                //if (dt.Rows[0]["AuditOpinion"].ToString() != null)
                //    this.ltl_Jjk.Text = dt.Rows[0]["AuditOpinion"].ToString();//基建科意见
                //if (dt.Rows.Count >= 3)
                //{
                //    this.ltl_Lead.Text = dt.Rows[2]["AuditOpinion"].ToString();//局领导意见
                //}

            }
        }
        #endregion


       #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                //BuildApplyEntity model = buildApplyDAL.GetObjByID(BAID);

                BuildApplyEntity model = new BuildApplyEntity();
                model.BAID = BAID;
                model.ProName = this.txt_ProName.Text.ToString();
                model.ApplyDep = this.ltl_ApplyDep.Text.ToString();
                model.ApplyDate = Convert.ToDateTime(this.ltl_ApplyDate.Text.ToString());
                model.BuildContent = this.txt_BuildContent.Text.ToString();
               
                model.Acreage = Convert.ToDecimal(this.txt_Acreage.Text.ToString());
                model.Layers = Convert.ToInt32(this.txt_Layers.Text.ToString());
                model.BudgetAmount = Convert.ToDecimal(this.txt_BudgetAmount.Text.ToString());

                model.Structure = this.txt_Structure.Text.ToString(); //结构
                model.BSources = Convert.ToInt32(this.ddl_BSources.SelectedValue.ToString());//资金来源
                model.BuildNature = Convert.ToInt32(this.ddl_BuildNature.SelectedValue.ToString());//建设性质

                model.BuildAddr = this.txt_BuildAddr.Text.ToString(); //实施地点
                model.DutyUser = this.txt_DutyUser.Text.ToString();//项目责任人
                model.DutyNO = this.txt_DutyNO.Text.ToString();//项目责任人联系人电话
                model.DepUser = this.txt_Contractor.Text.ToString();//申请单位联系人
                model.DepNO = this.txt_PhoneNumber.Text.ToString();//申请单位联系人联系电话

                model.BuildReason = this.txt_BuildReason.Text.ToString();
                model.Arrangement = this.ltl_Arrangement.Text.ToString();
                model.AState = 1;//驳回 = 0,未审核 = 1,通过 = 2,否决=3
                model.IsReport = (int)CommonEnum.IsorNot.否;
                int result= buildApplyDAL.Edit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加项目为【" + this.txt_ProName.Text + "】的基建申请信息", UserID));
                    ShowMessage();
                }
                else 
                {
                    ShowMessage("提交出错");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "添加项目【" + this.txt_ProName.Text + "】信息出错：【"+ex.Message+"】", UserID));
                return;
            }


        }
       #endregion

    }
}