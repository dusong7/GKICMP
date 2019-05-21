/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      项目文件管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace GKICMP.assetmanage
{
    public partial class Project_FileManage : PageBase
    {
        public Project_FileDAL project_FileDAL = new Project_FileDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

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
                //DataTable dtCType = SysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.BaseDataType.合同类型);
                //CommonFunction.DDlTypeBind(this.ddl_ProStage, dtCType, "SDID", "DataName", "-2");

               // CommonFunction.BindEnum<CommonEnum.ProjectFile>(this.ddl_ProStage, "-2");

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
            ViewState["FileName"] = CommonFunction.GetCommoneString(this.txt_FileName.Text.ToString());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Project_FileEntity model = new Project_FileEntity((string)ViewState["FileName"]);
            model.ProStage = -2;
            DataTable dt = project_FileDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt.Rows.Count > 0 && dt != null)
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
                string ids = this.hf_CheckIDS.Value;
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = project_FileDAL.DeleteBat(ids,-2);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资产文件", UserID));
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


        #region repeter行绑定
        /// <summary>
        /// repeter行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptypelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep1 = e.Item.FindControl("rp_ListFile1") as Repeater;//找到里层的repeater对象  
                Repeater rep2 = e.Item.FindControl("rp_ListFile2") as Repeater;//找到里层的repeater对象
                Repeater rep3 = e.Item.FindControl("rp_ListFile3") as Repeater;//找到里层的repeater对象
                Repeater rep4 = e.Item.FindControl("rp_ListFile4") as Repeater;//找到里层的repeater对象
                Repeater rep5 = e.Item.FindControl("rp_ListFile5") as Repeater;//找到里层的repeater对象
                Label lbl = e.Item.FindControl("Label1") as Label;//找到里层的repeater对象  
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
  
                string typeid = Convert.ToString(rowv["pid"].ToString()); //获取填充子类的id 
                DataTable dtf = project_FileDAL.GetListProState(typeid, 1);
                DataTable dts = project_FileDAL.GetListProState(typeid, 2);
                DataTable dtt = project_FileDAL.GetListProState(typeid, 3);
                DataTable dtfr = project_FileDAL.GetListProState(typeid, 4);
                DataTable dtfrp = project_FileDAL.GetListProState(typeid, 5);
                if (dtf != null && dtf.Rows.Count > 0)
                {
                }
                else
                {
                    dtf.Rows.Add();
                }
                rep1.DataSource = dtf;
                rep1.DataBind();

                if (dts != null && dts.Rows.Count > 0)
                {
                }
                else
                {
                    dts.Rows.Add();
                }
                rep2.DataSource = dts;
                rep2.DataBind();

                if (dtt != null && dtt.Rows.Count > 0)
                {
                }
                else
                {
                    dtt.Rows.Add("暂无");
                }
                rep3.DataSource = dtt;
                rep3.DataBind();

                if (dtfr != null && dtfr.Rows.Count > 0)
                {
                   
                }
                else
                {
                    dtfr.Rows.Add();
                    
                }
                rep4.DataSource = dtfr;
                rep4.DataBind();

                if (dtfrp != null && dtfrp.Rows.Count > 0)
                {

                }
                else
                {
                    dtfrp.Rows.Add();

                }
                rep5.DataSource = dtfrp;
                rep5.DataBind();
            }
        }
        #endregion


        #region 附件下载
        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpfilelist_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                string ProID = e.CommandArgument.ToString().Trim();
                DataTable dt = project_FileDAL.GetFile(ProID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!CommonFunction.UpLoadFunciotn(dt.Rows[i]["FileUrl"].ToString(), dt.Rows[i]["FileName"].ToString()))
                    {
                        ShowMessage("下载文件不存在，请联系系统管理员");
                        return;
                    }
                }
                
            }
            catch (Exception)
            {

                ShowMessage("文件路径错误！请重新上传！！！");
            }

        }
        #endregion

        #region 上报
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {

            localhost1.WebService1 service = new localhost1.WebService1();
            service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();  //BAID

            #region 附件上传
            //LinkButton lbtn = (LinkButton)sender;
            //string id = lbtn.CommandArgument.ToString();
            //DataTable dt = project_FileDAL.GetList(id);
            //Byte[] b = CommonFunction.File2Bytes(dt.Rows[0]["fileurl"].ToString());
            //string a = dt.Rows[0]["fileurl"].ToString().Substring(dt.Rows[0]["fileurl"].ToString().LastIndexOf("\\") + 1);
            //CommonFunction.Bytes2File(b, "/test/" + a); 

            //根据PID循环依次上传多个附件（适用多个附件数据库多条记录）
            DataTable bt = project_FileDAL.GetList(id);
            for (int d = 0; d < bt.Rows.Count; d++ )
            {
                string a = bt.Rows[d]["FileUrl"].ToString();
                Byte[] b = CommonFunction.File2Bytes(a);
                service.SaveFile(b, a);
            }
             #endregion

            string aa = "";
            List<GKICMP.localhost1.Project_FileEntity> args = new List<GKICMP.localhost1.Project_FileEntity>();
            for (int i = 0; i < id.Split(',').Length; i++)
            {
                DataTable dt = project_FileDAL.GetList(id.Split(',')[i]);  //PID
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        GKICMP.localhost1.Project_FileEntity model = new localhost1.Project_FileEntity();
                        model.PFID = dr["PFID"].ToString();
                        model.PID = dr["PID"].ToString();
                        model.FileName = dr["FileName"].ToString();
                        model.FileUrl = dr["FileUrl"].ToString();
                        model.ProStage = int.Parse(dr["ProStage"].ToString());
                        model.CreateUser = dr["CreateUser"].ToString();
                        model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                        args.Add(model);
                    }
                }
            }
          // service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
            string sguid = ConfigurationManager.AppSettings["SGUID"];
            //service.Show("1", "2", out aa);
            GKICMP.localhost1.Project_FileEntity[] A = args.ToArray();
            if (service.ProFile(sguid, A, out aa))
            {
                int rusult = project_FileDAL.Update(id);
                ShowMessage(aa);
                DataBindList();
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
            }
            else
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
            }

        }
        #endregion

        #region 多条上报--测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {

            localhost1.WebService1 service = new localhost1.WebService1();
            service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl");
            string id = "";
            id = this.hf_CheckIDS.Value.ToString();
            id = id.TrimEnd(',').TrimStart(',');

            #region 附件上传
            

            //根据PID循环依次上传附件
            DataTable bt = project_FileDAL.GetList(id);
            for (int d = 0; d < bt.Rows.Count; d++)
            {
                string a = bt.Rows[d]["FileUrl"].ToString();
                Byte[] b = CommonFunction.File2Bytes(a);
                service.SaveFile(b, a);
            }
            #endregion

            string aa = "";
            List<GKICMP.localhost1.Project_FileEntity> args = new List<GKICMP.localhost1.Project_FileEntity>();
            for (int i = 0; i < id.Split(',').Length; i++)
            {
                DataTable dt = project_FileDAL.GetList(id.Split(',')[i]);  //PID
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        GKICMP.localhost1.Project_FileEntity model = new localhost1.Project_FileEntity();
                        model.PFID = dr["PFID"].ToString();
                        model.PID = dr["PID"].ToString();
                        model.FileName = dr["FileName"].ToString();
                        model.FileUrl = dr["FileUrl"].ToString();
                        model.ProStage = int.Parse(dr["ProStage"].ToString());
                        model.CreateUser = dr["CreateUser"].ToString();
                        model.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                        args.Add(model);
                    }
                }
            }
           
            string sguid = ConfigurationManager.AppSettings["SGUID"];
            //service.Show("1", "2", out aa);
            GKICMP.localhost1.Project_FileEntity[] A = args.ToArray();
            if (service.ProFile(sguid, A, out aa))
            {
                int rusult = project_FileDAL.Update(id);
                ShowMessage(aa);
                DataBindList();
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
            }
            else
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
            }

        }
        #endregion
    }
}