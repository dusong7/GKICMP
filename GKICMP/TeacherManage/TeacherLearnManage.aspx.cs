/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师学习培训管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.teachermanage
{
    public partial class TeacherLearnManage : PageBase
    {
        Teacher_TrainDAL teacher_TrainDAL = new Teacher_TrainDAL();
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
                //CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_EMajor, "-2");
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
            //ViewState["Year"] = this.txt_Year.Text == "" ? DateTime.Now.Year.ToString() : this.txt_Year.Text;
            ViewState["Year"] = this.txt_Year.Text == "" ? "9999": this.txt_Year.Text;
         
            ViewState["TeacName"] = this.txt_TeacName.Text;
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;  //开始时间
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;     //结束时间
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Teacher_TrainEntity model = new Teacher_TrainEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.TYear =int.Parse(ViewState["Year"].ToString());
            model.TID = ViewState["TeacName"].ToString();
            DataTable dt = teacher_TrainDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["begin"]), Convert.ToDateTime(ViewState["end"]));
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
                int result = teacher_TrainDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师学习培训", UserID));
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

        #region 上报 --测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.Teacher_TrainEntity> args = new List<GKICMP.localhost1.Teacher_TrainEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_TrainEntity p = teacher_TrainDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_TrainEntity model1 = new localhost1.Teacher_TrainEntity();
                    model1.TTID = p.TTID;
                    model1.TID = p.TID;
                    model1.TYear = p.TYear;
                    model1.TStartDate = p.TStartDate;
                    model1.TEndDate = p.TEndDate;

                    model1.TrainAddress = p.TrainAddress;
                    model1.THours = p.THours;
                    model1.TrainContent = p.TrainContent;
                    model1.TType = p.TType;

                    model1.TDesc = p.TDesc;
                    //model1.IsReport = 1;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;


                    args.Add(model1);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_TrainEntity[] A = args.ToArray();
                if (service.TeacherTrain(sguid, A, out aa))
                {
                    int rusult = teacher_TrainDAL.Update(id);//更新字段为 已上报
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

        #region 多条上报 --测试完成
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

                List<GKICMP.localhost1.Teacher_TrainEntity> args = new List<GKICMP.localhost1.Teacher_TrainEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_TrainEntity p = teacher_TrainDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_TrainEntity model1 = new localhost1.Teacher_TrainEntity();
                    model1.TTID = p.TTID;
                    model1.TID = p.TID;
                    model1.TYear = p.TYear;
                    model1.TStartDate = p.TStartDate;
                    model1.TEndDate = p.TEndDate;

                    model1.TrainAddress = p.TrainAddress;
                    model1.THours = p.THours;
                    model1.TrainContent = p.TrainContent;
                    model1.TType = p.TType;

                    model1.TDesc = p.TDesc;
                    //model1.IsReport = 1;
                    model1.Isdel = (int)CommonEnum.Deleted.未删除;


                    args.Add(model1);
                }

               // service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_TrainEntity[] A = args.ToArray();
                if (service.TeacherTrain(sguid, A, out aa))
                {
                    int rusult = teacher_TrainDAL.Update(id);//更新字段为 已上报
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
            string aa = string.Format("<script language=javascript>window.open('TeacherLearnEdit.aspx', '_self')</script>");
            Response.Write(aa);
        }
        #endregion


        #region 编辑
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            string  logid = lbt.CommandName.ToString();
            string aa = string.Format("<script language=javascript>window.open('TeacherLearnEdit.aspx?id={0}', '_self')</script>", logid);
            Response.Write(aa);
        }
        #endregion
    }
}