using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.projectmanage
{
    public partial class JJProjectManage : PageBase
    {
        BuildApplyDAL buildApplyDAL = new BuildApplyDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public JZProjectManageDAL jzprojectManageDAL = new JZProjectManageDAL();

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
            ViewState["GName"] = CommonFunction.GetCommoneString(this.txt_GName.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            BuildApplyEntity model = new BuildApplyEntity();
            model.ProName = (string)ViewState["GName"];
            DataTable dt = buildApplyDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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

        public string GetState(object obj)
        {
            if (obj.ToString() == "0")
            {
                return "已驳回";
            }
            else if (obj.ToString() == "1")
            {
                return "<font style='color:red;'>未审核";
            }
            else if (obj.ToString() == "2")
            {
                return "已通过";
            }
            else
            {
                return "待修改";
            }
        }

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
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = buildApplyDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除基建项目申报", UserID));
                    ShowMessage("删除成功");
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
                return;
            }
        }
        #endregion


        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            BuildApplyEntity model = new BuildApplyEntity();
            model.ProName = (string)ViewState["GName"];
           

            DataTable dt = buildApplyDAL.GetPaged(9999999, 1, ref recordCount, model);
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>项目名称</strong></th>
                                        <th><strong>建设性质</strong></th>
                                        <th><strong>建筑面积</strong></th>
                                        <th><strong>层数</strong></th>
                                        <th><strong>结构</strong></th>
                                        <th><strong>预算金额</strong></th>
                                        <th><strong>资金来源</strong></th>
                                        <th><strong>申报日期</strong></th>
                                        <th><strong>状态</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["ProName"]);
                    str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BuildNature>(row["BuildNature"]));
                    str.AppendFormat("<td>{0}</td>", row["Acreage"]);
                    str.AppendFormat("<td>{0}</td>", row["Layers"]);
                    str.AppendFormat("<td>{0}</td>", row["Structure"]);
                    str.AppendFormat("<td>{0}</td>", row["BudgetAmount"]);
                    str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BSources>(row["BSources"]));
                    str.AppendFormat("<td>{0}</td>", DateTime.Parse(row["ApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    if (Convert.ToString(row["AState"]) == "0")
                    {
                        str.AppendFormat("<td>{0}</td>", "已驳回");
                    }
                    else if (Convert.ToString(row["AState"]) == "1")
                    {
                        str.AppendFormat("<td>{0}</td>", "未审核");
                    }
                    else if (Convert.ToString(row["AState"]) == "2")
                    {
                        str.AppendFormat("<td>{0}</td>", "已通过");
                    }
                    else
                    {
                        str.AppendFormat("<td>{0}</td>", "待修改");
                    }
                   
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("基建项目申报", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出基建项目申报", UserID));

        }
        #endregion

        #region 单条上报
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";

                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();  //BAID
                string aa = "";
                List<GKICMP.localhost1.BuildApplyEntity> args = new List<GKICMP.localhost1.BuildApplyEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    BuildApplyEntity p = buildApplyDAL.GetObjByID(id.Split(',')[i]);  //PID
                    if (p != null)
                    {
                        GKICMP.localhost1.BuildApplyEntity model = new localhost1.BuildApplyEntity();
                        model.BAID = p.BAID;
                        //model.ApplyDep = dt.Rows[0]["DepID"].ToString();
                        model.ProName = p.ProName;//项目名称
                        model.BuildAddr = p.BuildAddr;//项目地址
                        model.ApplyDate = p.ApplyDate;//申请时间
                        model.BuildContent = p.BuildContent;//建设内容
                        model.BuildNature = p.BuildNature;//建设性质
                        model.Acreage = p.Acreage;//面积
                        model.Layers = p.Layers;//层数
                        model.Structure = p.Structure;//结构
                        model.BudgetAmount = p.BudgetAmount;//预算金额
                        model.BSources = p.BSources;//资金来源
                        model.DutyUser = p.DutyUser;//项目责任人
                        model.DutyNO = p.DutyNO;//责任人电话
                        model.BuildReason = p.BuildReason;//建设理由
                        model.ApplyUser = p.ApplyUser;//申请人
                        model.DepUser = p.DepUser;//单位负责人
                        model.DepNO = p.DepNO;//负责人电话
                        model.Arrangement = p.Arrangement;//资金落实情况
                        model.AState = p.AState;//状态
                        model.BDesc = p.BDesc;
                        args.Add(model);
                    }
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.BuildApplyEntity[] A = args.ToArray();
                if (service.JJProManage(sguid, A, out aa))
                {
                    int rusult = buildApplyDAL.Update(id);
                    ShowMessage(aa);
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 多条上报--测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');
                string aa = "";
                List<GKICMP.localhost1.BuildApplyEntity> args = new List<GKICMP.localhost1.BuildApplyEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    BuildApplyEntity p = buildApplyDAL.GetObjByID(id.Split(',')[i]);  //PID
                    if (p != null)
                    {
                        GKICMP.localhost1.BuildApplyEntity model = new localhost1.BuildApplyEntity();
                        model.BAID = p.BAID;
                        //model.ApplyDep = dt.Rows[0]["DepID"].ToString();
                        model.ProName = p.ProName;//项目名称
                        model.BuildAddr = p.BuildAddr;//项目地址
                        model.ApplyDate = p.ApplyDate;//申请时间
                        model.BuildContent = p.BuildContent;//建设内容
                        model.BuildNature = p.BuildNature;//建设性质
                        model.Acreage = p.Acreage;//面积
                        model.Layers = p.Layers;//层数
                        model.Structure = p.Structure;//结构
                        model.BudgetAmount = p.BudgetAmount;//预算金额
                        model.BSources = p.BSources;//资金来源
                        model.DutyUser = p.DutyUser;//项目责任人
                        model.DutyNO = p.DutyNO;//责任人电话
                        model.BuildReason = p.BuildReason;//建设理由
                        model.ApplyUser = p.ApplyUser;//申请人
                        model.DepUser = p.DepUser;//单位负责人
                        model.DepNO = p.DepNO;//负责人电话
                        model.Arrangement = p.Arrangement;//资金落实情况
                        model.AState = p.AState;//状态
                        model.BDesc = p.BDesc;
                        args.Add(model);
                    }
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.BuildApplyEntity[] A = args.ToArray();
                if (service.JJProManage(sguid, A, out aa))
                {
                    int rusult = buildApplyDAL.Update(id);
                    ShowMessage(aa);
                    DataBindList();
                }
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
        public string State(object state)
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
    }
}