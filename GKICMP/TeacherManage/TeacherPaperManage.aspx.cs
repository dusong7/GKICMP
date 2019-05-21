/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
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
    public partial class TeacherPaperManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_PaperDAL teacher_PaperDAL = new Teacher_PaperDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlWhwere();
                DataBindList();
            }
        }
        public void SqlWhwere() 
        {
            ViewState["TeacherName"] = CommonFunction.GetCommoneString(this.txt_TeacName.Text.ToString().Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {

            int recordCount = -1;
            Teacher_PaperEntity model = new Teacher_PaperEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.TID = (string)ViewState["TeacherName"];
            DataTable dt = teacher_PaperDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model,Convert.ToDateTime( ViewState["begin"]), Convert.ToDateTime( ViewState["end"]));
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
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            SqlWhwere();
            DataBindList();
        }
        #endregion

        //#region 跳转详情页面
        ///// <summary>
        ///// 跳转详情页面
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbtn_Info_Click(object sender, EventArgs e)
        //{
        //    LinkButton lbtn = (LinkButton)sender;
        //    string id = lbtn.CommandArgument.ToString();
        //    string aa = string.Format("<script language=javascript>window.open('TeacherHolidayDetail.aspx?THID={0}', '_self')</script>", id);
        //    Response.Write(aa);
        //}
        //#endregion

        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = this.hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teacher_PaperDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师论文信息", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
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
        #region 导出事件
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            Teacher_PaperEntity model = new Teacher_PaperEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            // model.DepID = int.Parse(this.ddl_Depart.SelectedValue);
            DataTable dt = teacher_PaperDAL.GetPaged(9999999, 1, ref recordCount, model, (DateTime)ViewState["begin"], (DateTime)ViewState["end"]);
            if (dt == null)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>姓名</strong></th>
                                        <th><strong>论文名称</strong></th>
                                        <th><strong>刊物名称</strong></th>
                                        <th><strong>发表年月</strong></th>
                                        <th><strong>卷号</strong></th>
                                        <th><strong>期号</strong></th>


                                         <th><strong>起始页码</strong></th>
                                         <th><strong>结束页码</strong></th>
                                         <th><strong>本人角色</strong></th>
                                         <th><strong>学科领域</strong></th>
                                         <th><strong>论文收录情况</strong></th>

                                        <th><strong>是否上报</strong></th>
                                        </tr>");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["TeacherName"]);
                    str.AppendFormat("<td>{0}</td>", row["PaperName"]);
                    str.AppendFormat("<td>{0}</td>", row["Publication"]);
                    str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["PubDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["Volume"]);
                    str.AppendFormat("<td>{0}</td>", row["TermNum"]);
                    str.AppendFormat("<td>{0}</td>", row["BeginNum"]);
                    str.AppendFormat("<td>{0}</td>", row["EndPage"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.URole>(row["URoles"]));
                    str.AppendFormat("<td>{0}</td>", row["SubjectArea"]);
                    str.AppendFormat("<td>{0}</td>", row["Included"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.IsorNot>(row["IsReport"].ToString()).ToString() == "0" ? "未上报" : "已上报");
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教师长假信息表", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教师长假信息表", UserID));
        }
        #endregion

        #region 单条上报 --测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            //ShowMessage("暂不支持");
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                string aa = "";
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();

                //#region 附件上传
                //for (int i = 0; i < id.Split(',').Length; i++)
                //{

                //    Teacher_PaperEntity dr = teacher_PaperDAL.GetObjByID(id.Split(',')[i]);
                //    for (int t = 0; t < dr.RFile.Split(',').Length; t++)  //根据TCID循环依次上传多个附件（适用在数据库一条记录存在多个附件）
                //    {
                //        Byte[] b = CommonFunction.File2Bytes(dr.RFile.Split(',')[t]);
                //        service.SaveFile(b, dr.RFile.Split(',')[t]);
                //    }

                //}

                //#endregion
                List<GKICMP.localhost1.Teacher_RewardEntity> args = new List<GKICMP.localhost1.Teacher_RewardEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_PaperEntity p = teacher_PaperDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_RewardEntity model = new localhost1.Teacher_RewardEntity();

                    model.TRID = p.TPID;//id
                    model.TRName = p.PaperName;//获奖名称
                    model.TID = p.TID;//教师id
                    model.TRDate = p.PubDate;//获奖时间
                    model.TRDepName = p.Publication;//奖励单位
                    model.TRContent = p.IncludedName;//获奖级别
                    //model.TRFile = p.RFile;//附件
                    model.TRFlag = 1;//论文收录情况
                    model.TRRmark = p.TermNum;//
                    args.Add(model);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_RewardEntity[] A = args.ToArray();
                if (service.TeacherReward(sguid, A, out aa))
                {
                    int rusult = teacher_PaperDAL.Update(id);//更新字段为 已上报

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

        #region 上报 --多条上报
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
                //#region 附件上传
                //for (int i = 0; i < id.Split(',').Length; i++)
                //{
                //    Teacher_HolidayEntity dr = teacher_HolidayDAL.GetObjByID(id.Split(',')[i]);
                //    for (int t = 0; t < dr.HFile.Split(',').Length; t++)
                //    {
                //        Byte[] b = CommonFunction.File2Bytes(dr.HFile.Split(',')[t]);
                //        service.SaveFile(b, dr.HFile.Split(',')[t]);
                //    }
                //}
                //#endregion

                List<GKICMP.localhost1.Teacher_RewardEntity> args = new List<GKICMP.localhost1.Teacher_RewardEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Teacher_PaperEntity p = teacher_PaperDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Teacher_RewardEntity model = new localhost1.Teacher_RewardEntity();

                    model.TRID = p.TPID;//id
                    model.TRName = p.PaperName;//获奖名称
                    model.TID = p.TID;//教师id
                    model.TRDate = p.PubDate;//获奖时间
                    model.TRDepName = p.Publication;//奖励单位
                    model.TRContent = p.IncludedName;//获奖级别
                    //model.TRFile = p.RFile;//附件
                    model.TRFlag = 1;//论文收录情况
                    model.TRRmark = p.TermNum;//
                    args.Add(model);
                }

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Teacher_RewardEntity[] A = args.ToArray();
                if (service.TeacherReward(sguid, A, out aa))
                {
                    int rusult = teacher_PaperDAL.Update(id);//更新字段为 已上报

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
    }
}