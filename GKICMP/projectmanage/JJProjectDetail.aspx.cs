using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.projectmanage
{
    public partial class JJProjectDetail : PageBase
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BuildApplyDAL buildApplyDAL = new BuildApplyDAL();

        #region 参数集合
        /// <summary>
        /// BAID
        /// </summary>
        public string BAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BAID != "")
            {
                InfoBind();
            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
             BuildApplyEntity model = buildApplyDAL.GetObjByID(BAID);
             if (model != null)
             {
                 this.ltl_ProName.Text = model.ProName.ToString();
                 this.ltl_BuildContent.Text = model.BuildContent.ToString();
                 this.ltl_Structure.Text = model.Structure.ToString();
                 this.ltl_Acreage.Text = model.Acreage.ToString();
                 this.ltl_Layers.Text = model.Layers.ToString();
                 this.ltl_BudgetAmount.Text = model.BudgetAmount.ToString();

                 //this.ltl_BSources.Text = model.BSources.ToString();//资金来源
                 this.ltl_BSources.Text = CommonFunction.CheckEnum<CommonEnum.BSources>(model.BSources.ToString()); 
                 this.ltl_BuildNature.Text = CommonFunction.CheckEnum<CommonEnum.BuildNature>(model.BuildNature);//建设性质 
                 this.ltl_BuildAddr.Text = model.BuildAddr.ToString(); //实施地点
                 this.ltl_DutyUser.Text = model.DutyUser.ToString();//项目责任人
                 this.ltl_DutyNO.Text = model.DutyNO.ToString();//项目责任人联系人电话
                 this.ltl_Contractor.Text = model.DepUser.ToString();//申请单位联系人
                 this.ltl_PhoneNumber.Text = model.DepNO.ToString();//申请单位联系人联系电话
                 this.ltl_BuildReason.Text = model.BuildReason.ToString();

                 if (model.AState == 0)
                 {
                     this.ltl_AState.Text = "已驳回";  // 未审核 = 1,通过 = 2
                 }

                 else if (model.AState == 1)
                 {
                     this.ltl_AState.Text = "未审核";  // 未审核 = 1,通过 = 2
                 }
                 else if (model.AState == 2)
                 {
                     this.ltl_AState.Text = "已通过";  // 未审核 = 1,通过 = 2
                 }
                 else
                 {
                     this.ltl_AState.Text = "待修改";
                 }

                 this.ltl_AStateDesc.Text = model.BDesc;

                 //this.ltl_Arrangement.Text = model.Arrangement.ToString();
                 //this.ltl_ApplyDate.Text = model.ApplyDate.ToString("yyyy-MM-dd");
                 //this.ltl_ApplyDep.Text = model.ApplyDep.ToString();
                 //this.ltl_ApplyDate.Text = model.ApplyDate.ToString("yyyy年MM月dd日");
             }
        }
        #endregion


    }
}