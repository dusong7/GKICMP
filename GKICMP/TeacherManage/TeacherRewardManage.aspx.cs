/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      奖励管理界面
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
    public partial class TeacherRewardManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public Teacher_RewardDAL teacherRewardDAL = new Teacher_RewardDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.RewardType>(this.ddl_RewardType, "-2");//
                CommonFunction.BindEnum<CommonEnum.RGrade>(this.ddl_RGrade, "-2");//
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["RewardName"] = CommonFunction.GetCommoneString(this.txt_RewardName.Text.Trim());
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());
            ViewState["RewardType"] = this.ddl_RewardType.SelectedValue.ToString();
            ViewState["RGrade"] = this.ddl_RGrade.SelectedValue.ToString();

            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            Teacher_RewardEntity model = new Teacher_RewardEntity();
            model.RewardName = ViewState["RewardName"].ToString();
            model.RewardType = Convert.ToInt32(ViewState["RewardType"].ToString());
            model.RGrade = ViewState["RGrade"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["begin"].ToString());
            model.End = Convert.ToDateTime(ViewState["end"].ToString());
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = teacherRewardDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, (string)ViewState["RealName"]);
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


        #region 查询
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
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
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teacherRewardDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除奖励信息", UserID));
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

        #region 上报 --测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            //ShowMessage("暂不支持");
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                #region 附件上传
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_RewardEntity dr = teacherRewardDAL.GetObjByID(id.Split(',')[i]);
                    for (int t = 0; t < dr.RFile.Split(',').Length; t++)  //根据TCID循环依次上传多个附件（适用在数据库一条记录存在多个附件）
                    {
                        Byte[] b = CommonFunction.File2Bytes(dr.RFile.Split(',')[t]);
                        service.SaveFile(b, dr.RFile.Split(',')[t]);
                    }

                }
                #endregion
                string aa = "";
                List<GKICMP.localhost1.Teacher_RewardEntity> args = new List<GKICMP.localhost1.Teacher_RewardEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_RewardEntity p = teacherRewardDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_RewardEntity model = new localhost1.Teacher_RewardEntity();

                    model.TRID = p.TPID;//id
                    model.TRName = p.RewardName;//获奖名称
                    model.TID = p.TID;//教师id
                    model.TRDate = p.PubDate;//获奖时间
                    model.TRDepName = p.Lunit;//奖励单位
                    model.TRContent = CommonFunction.CheckEnum<CommonEnum.RewardType>(p.RewardType);//获奖级别
                    model.TRFile = p.RFile;//附件
                    model.TRFlag = 2;//获奖
                    model.TRRmark = "2";//
                    args.Add(model);
                }

                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_RewardEntity[] A = args.ToArray();
                if (service.TeacherReward(sguid, A, out aa))
                {
                    int rusult = teacherRewardDAL.Update(id);//更新字段为 已上报
                    DataBindList();
                }
                ShowMessage(aa);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion

        #region 多条上报 ---测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            //ShowMessage("暂不支持");
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                string aa = "";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                #region 附件上传
                for (int i = 0; i < id.Split(',').Length; i++)
                {

                    Teacher_RewardEntity dr = teacherRewardDAL.GetObjByID(id.Split(',')[i]);
                    for (int t = 0; t < dr.RFile.Split(',').Length; t++)  //根据TCID循环依次上传多个附件（适用在数据库一条记录存在多个附件）
                    {
                        Byte[] b = CommonFunction.File2Bytes(dr.RFile.Split(',')[t]);
                        service.SaveFile(b, dr.RFile.Split(',')[t]);
                    }

                }

                #endregion
                List<GKICMP.localhost1.Teacher_RewardEntity> args = new List<GKICMP.localhost1.Teacher_RewardEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_RewardEntity p = teacherRewardDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_RewardEntity model = new localhost1.Teacher_RewardEntity();

                    model.TRID = p.TPID;//id
                    model.TRName = p.RewardName;//获奖名称
                    model.TID = p.TID;//教师id
                    model.TRDate = p.PubDate;//获奖时间
                    model.TRDepName = p.Lunit;//奖励单位
                    model.TRContent = CommonFunction.CheckEnum<CommonEnum.RewardType>(p.RewardType);//获奖级别
                    model.TRFile = p.RFile;//附件
                    model.TRFlag = 2;//
                    model.TRRmark = "2";//
                    args.Add(model);
                }
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_RewardEntity[] A = args.ToArray();
                if (service.TeacherReward(sguid, A, out aa))
                {
                    int rusult = teacherRewardDAL.Update(id);//更新字段为 已上报

                }
                ShowMessage(aa);
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
            Teacher_RewardEntity model = new Teacher_RewardEntity();
            model.RewardName = ViewState["RewardName"].ToString();
            model.RewardType = Convert.ToInt32(ViewState["RewardType"].ToString());
            model.RGrade = ViewState["RGrade"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["begin"].ToString());
            model.End = Convert.ToDateTime(ViewState["end"].ToString());
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = teacherRewardDAL.GetPaged(2000, 1, ref recordCount, model, (string)ViewState["RealName"]);

            
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>姓名</strong></th>
                                        <th><strong>奖励名称</strong></th>
                                        <th><strong>奖励类别</strong></th>
                                        <th><strong>奖励级别</strong></th>
                                        <th><strong>获奖年月</strong></th>
                                        <th><strong>授奖单位</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["TeacherName"]);
                    str.AppendFormat("<td>{0}</td>", row["RewardName"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.RewardType>(row["RewardType"].ToString()));
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.RGrade>(row["RGrade"].ToString()));
                    str.AppendFormat("<td>{0}</td>", row["PubDate"].ToString() == "" ? "" : Convert.ToDateTime(row["PubDate"]).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["Lunit"]);

                   

                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教师奖励导出", str.ToString());
            

        }
        #endregion

    }
}