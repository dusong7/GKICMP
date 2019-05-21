using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Text;
using System.Data;
using System.Configuration;

namespace GKICMP.projectmanage
{
    public partial class JZProjectCheckList : PageBase
    {
        public BuildApplyDAL  buildApplyDAL = new BuildApplyDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public JZProjectManageDAL jzprojectManageDAL = new JZProjectManageDAL();
        public Project_CheckDAL project_CheckDAL = new Project_CheckDAL();
        public AssetDAL assetDAL = new AssetDAL();

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
            Project_CheckEntity model = new Project_CheckEntity();
            model.PID = (string)ViewState["GName"];
            DataTable dt = project_CheckDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = project_CheckDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除验收信息", UserID));
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

        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            //return Path.GetFileNameWithoutExtension(obj);
            return Path.GetFileName(obj);
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
            StringBuilder str = new StringBuilder();
            int recordCount = -1;
            Project_CheckEntity model = new Project_CheckEntity();
            model.PID = (string)ViewState["GName"];
            DataTable dt = project_CheckDAL.GetPaged(9999999, 1, ref recordCount, model);
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>项目名称</strong></th>
                                        <th><strong>综合评价</strong></th>
                                        <th><strong>验收意见</strong></th>
                                        <th><strong>验收时间</strong></th>
                                        <th><strong>验收单附件</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["PName"]);
                    str.AppendFormat("<td>{0}</td>",CommonFunction.CheckEnum<CommonEnum.ProjectCheck>(row["Evaluate"]));
                    str.AppendFormat("<td>{0}</td>", row["Opinion"]);
                    str.AppendFormat("<td>{0}</td>", DateTime.Parse(row["PCDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["PCFile"]);
                    //str.AppendFormat("<td>{0}</td>", row["BudgetAmount"]);
                    //str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BSources>(row["BSources"]));
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("项目验收", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出项目验收", UserID));

        }
        #endregion

        #region 上报 --测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
               
                #region 判断该项目下的供货清单里的资产是否上报了
                //DataTable dt = assetDAL.GetListByPID(id, (int)CommonEnum.Deleted.未删除); //PCID
                DataTable dt = assetDAL.GetListByPCID(id, (int)CommonEnum.Deleted.未删除); ////根据PCID获取未上报的资产
                //if (dt == null || dt.Rows.Count == 0)
                //{
                //    ShowMessage("该项目下的供货清单还没有，请完成后再操作");
                //    return;
                //}
                //if (dt == null || dt.Rows.Count == 0)
                if (dt != null && dt.Rows.Count > 0)
                {
                    ShowMessage("该项目下的供货清单还没有或未上报，请完成后再操作");
                    return;
                }
                #endregion

                #region 附件上传
                //LinkButton lbtn = (LinkButton)sender;
                //string id = lbtn.CommandArgument.ToString();
                //DataTable dt = project_FileDAL.GetList(id);
                //Byte[] b = CommonFunction.File2Bytes(dt.Rows[0]["fileurl"].ToString());
                //string a = dt.Rows[0]["fileurl"].ToString().Substring(dt.Rows[0]["fileurl"].ToString().LastIndexOf("\\") + 1);
                //CommonFunction.Bytes2File(b, "/test/" + a); 

                Project_CheckEntity bt = project_CheckDAL.GetObjByID(id);
                if (bt != null)
                {
                    if(bt.PCFile != null)
                    {
                        Byte[] b = CommonFunction.File2Bytes(bt.PCFile);
                        service.SaveFile(b, bt.PCFile);
                    }
                }
                
                #endregion

                string aa = "";
                List<GKICMP.localhost1.Project_CheckEntity> args = new List<GKICMP.localhost1.Project_CheckEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Project_CheckEntity p = project_CheckDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Project_CheckEntity model = new localhost1.Project_CheckEntity();
                    model.PCID = p.PCID;
                    model.PID = p.PID;
                    model.BrandChecked = p.BrandChecked;
                    model.SpecificationChecked = p.SpecificationChecked;
                    model.ConfigChecked = p.ConfigChecked;
                    model.CountChecked = p.CountChecked;
                    model.DebuggingChecked = p.DebuggingChecked;
                    model.GuaranteeChecked = p.GuaranteeChecked;
                    model.PackingChecked = p.PackingChecked;
                    model.ContractChecked = p.ContractChecked;
                    model.Evaluate = p.Evaluate;
                    model.Opinion = p.Opinion;
                    model.CreateDate = p.CreateDate;
                    model.PCDate = p.PCDate;
                    model.CreateUser = p.CreateUserName;
                    model.PCFile = p.PCFile;
                    args.Add(model);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                GKICMP.localhost1.Project_CheckEntity[] A = args.ToArray();
                if (service.ProCheck(sguid, A, out aa))
                {
                    int rusult = project_CheckDAL.Update(id);//更新验收上报

                    #region 验收成功后 更新 (供货清单里的资产 ,教装项目)的验收状态：0 否 ，1 是
                    DataTable ds = assetDAL.GetListByPID(id, (int)CommonEnum.Deleted.未删除); //根据PCID获取已上报的资产
                    if (ds != null && ds.Rows.Count > 0)
                    {
                        for (int y = 0; y < ds.Rows.Count; y++)
                        {
                            int sult = assetDAL.UpdateIsChecked(ds.Rows[y]["AID"].ToString());
                        }
                    }
                    #endregion
                  
                    ShowMessage(aa);
                    DataBindList();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 多条上报 --测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');

                #region 判断该项目下的供货清单里的资产是否上报了
                 for (int i = 0; i < id.Split(',').Length; i++)
                {
                    //DataTable dt = assetDAL.GetListByPID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除);
                    DataTable dt = assetDAL.GetListByPCID(id, (int)CommonEnum.Deleted.未删除); //PCID
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ShowMessage("该项目下的供货清单还没有或未上报，请完成后再操作");
                        return;
                    }
                }
                #endregion

                #region 附件上传
                //Project_CheckEntity bt = project_CheckDAL.GetObjByID(id);
                 for (int i = 0; i < id.Split(',').Length; i++)
                 {
                     Project_CheckEntity bt = project_CheckDAL.GetObjByID(id.Split(',')[i]);
                     if (bt != null)
                     {
                         if (bt.PCFile != null)
                         {
                             Byte[] b = CommonFunction.File2Bytes(bt.PCFile);
                             service.SaveFile(b, bt.PCFile);
                         }
                     }
                 }
             
                #endregion


                string aa = "";
                List<GKICMP.localhost1.Project_CheckEntity> args = new List<GKICMP.localhost1.Project_CheckEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Project_CheckEntity p = project_CheckDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Project_CheckEntity model = new localhost1.Project_CheckEntity();
                    model.PCID = p.PCID;
                    model.PID = p.PID;
                    model.BrandChecked = p.BrandChecked;
                    model.SpecificationChecked = p.SpecificationChecked;
                    model.ConfigChecked = p.ConfigChecked;
                    model.CountChecked = p.CountChecked;
                    model.DebuggingChecked = p.DebuggingChecked;
                    model.GuaranteeChecked = p.GuaranteeChecked;
                    model.PackingChecked = p.PackingChecked;
                    model.ContractChecked = p.ContractChecked;
                    model.Evaluate = p.Evaluate;
                    model.Opinion = p.Opinion;
                    model.CreateDate = p.CreateDate;
                    model.PCDate = p.PCDate;
                    model.CreateUser = p.CreateUserName;
                    model.PCFile = p.PCFile;
                    args.Add(model);
                }
                // jzprojectManageDAL.GetObjByID(id);
                // string url = "http://localhost:5317/WebService1.asmx";

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Project_CheckEntity[] A = args.ToArray();
                if (service.ProCheck(sguid, A, out aa))
                {
                    int rusult = project_CheckDAL.Update(id);

                    #region 验收成功后 更新 (供货清单里的资产 ,教装项目)的验收状态：0 否 ，1 是
                    for (int i = 0; i < id.Split(',').Length; i++)
                    {
                        DataTable dg = assetDAL.GetListByPID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除); //每个PID下可能会有多个AID
                        if (dg != null && dg.Rows.Count > 0)
                        {
                            for (int y = 0; y < dg.Rows.Count; y++)
                            {
                                int sult = assetDAL.UpdateIsChecked(dg.Rows[y]["AID"].ToString());
                            }
                        }
                    }
                    #endregion

                    ShowMessage(aa);
                    DataBindList();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, aa, UserID));
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
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

    }
}