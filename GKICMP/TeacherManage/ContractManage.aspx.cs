/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
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
    public partial class ContractManage : PageBase
    {
        Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
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
                DataTable dtCType = SysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.BaseDataType.合同类型);
                CommonFunction.DDlTypeBind(this.ddl_CType, dtCType, "SDID", "DataName", "-2");
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
            ViewState["TID"] = CommonFunction.GetCommoneString(this.txt_TeacherName.Text.ToString());
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Teacher_ContractEntity model = new Teacher_ContractEntity((string)ViewState["TID"], Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), (int)CommonEnum.Deleted.未删除);
            model.CType = int.Parse(this.ddl_CType.SelectedValue);
            DataTable dt = contractDal.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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

        #region 教师合同状态
        /// <summary>
        /// 教师合同状态
        /// </summary>
        /// <param name="tstate"></param>
        /// <returns></returns>
        public string GetState(object tstate, object date)
        {
            int state = Convert.ToInt32(tstate.ToString());
            if (state == (int)CommonEnum.TState.正常)
            {
                DateTime d = Convert.ToDateTime(date);
                TimeSpan ts = d - DateTime.Now;
                if (ts.Days <= 90)
                {
                    return " <span style='color:green; background: url(/images/but_b.gif) left center no-repeat;padding-left:20px' title='合同即将到期'>正常</span>";
                }
                else
                {
                    return "<span style='color:green'>正常</span>";
                }

            }
            else if (state == (int)CommonEnum.TState.到期)
            {
                return "<span style='color:red'>到期</span>";
            }
            else
            {
                return "<span style='color:red'>解除</span>";
            }
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
            Teacher_ContractEntity model = new Teacher_ContractEntity((string)ViewState["TID"], Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), (int)CommonEnum.Deleted.未删除);
            model.CType = int.Parse(this.ddl_CType.SelectedValue);
            DataTable dt = contractDal.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>姓名</strong></th>
                                        <th><strong>合同周期</strong></th>
                                        <th><strong>合同类型</strong></th>
                                        <th><strong>签订日期</strong></th>
                                        <th><strong>到期日期</strong></th>
                                        <th><strong>解除日期</strong></th>
                                        <th><strong>合同状态</strong></th>
                                        <th><strong>是否上报</strong></th>
                                        </tr>");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["RealName"]);
                    str.AppendFormat("<td>{0}</td>", row["TCycle"] + "年");
                    str.AppendFormat("<td>{0}</td>", row["CTypeName"]);
                    str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["TStartDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["TEndDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", (row["OverDate"].ToString() == "" ? "" : Convert.ToDateTime(row["OverDate"].ToString()).ToString("yyyy-MM-dd")));
                    if (row["TState"].ToString() == ((int)CommonEnum.TState.正常).ToString())
                        str.AppendFormat("<td>{0}</td>", "正常");
                    else if (row["TState"].ToString() == ((int)CommonEnum.TState.到期).ToString())
                        str.AppendFormat("<td>{0}</td>", "到期");
                    else
                        str.AppendFormat("<td>{0}</td>", "解除");
                    //str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.IsorNot>(row["IsReport"].ToString()).ToString() == "0" ? "未上报" : "已上报");
                    str.AppendFormat("<td>{0}</td>", row["IsReport"].ToString() == "0" ? "未上报" : "已上报");
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教师合同信息表", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教师合同信息表", UserID));
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
                string id = lbtn.CommandArgument.ToString();//TCID

                #region 附件上报一
                //Teacher_ContractEntity dr = contractDal.GetObjByID(id.Split(',')[i]);
                //for (int t = 0; t < dr.TCFile.Split(',').Length; t++)  //根据TCID循环依次上传多个附件（适用在数据库一条记录存在多个附件）
                //{
                //    if(dr.TCFile != null)
                //    {
                //        Byte[] b = CommonFunction.File2Bytes(dr.TCFile.Split(',')[t]);
                //       service.SaveFile(b, dr.TCFile.Split(',')[t]);
                //    }
                //string a = dr.TCFile.ToString().Substring(dr.TCFile.ToString().LastIndexOf("\\") + 1);
                //CommonFunction.Bytes2File(b, ConfigurationManager.AppSettings["URL"] + dr.TCFile.ToString());
                //}
                #endregion

                #region 内容上报一
                //string aa = "";
                //List<GKICMP.localhost1.Teacher_ContractEntity> args = new List<GKICMP.localhost1.Teacher_ContractEntity>();
                //for (int i = 0; i < id.Split(',').Length; i++)
                //{
                //    Teacher_ContractEntity p = contractDal.GetObjByID(id.Split(',')[i]);
                //    GKICMP.localhost1.Teacher_ContractEntity model1 = new localhost1.Teacher_ContractEntity();

                //    model1.TCID = p.TCID;
                //    model1.TID = p.TID;
                //    model1.DepID = p.DepID;
                //    model1.CType = p.CType;
                //    model1.TCycle = p.TCycle;
                //    model1.TStartDate = p.TStartDate;
                //    model1.TEndDate = p.TEndDate;
                //    model1.CreateDate = DateTime.Now; ;
                //    model1.TCFile = p.TCFile;
                //    model1.Isdel = (int)CommonEnum.Deleted.未删除;
                //    model1.TState = p.TState;

                //    args.Add(model1);
                //}
                #endregion


                #region 附件上报二
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    // //根据TID获取未上报的合同
                    DataTable ct = contractDal.GetObjByTCID(id.Split(',')[i]);
                    //if (ct != null || ct.Rows.Count > 0)
                    if (ct != null && ct.Rows.Count > 0)
                    {
                        for (int c = 0; c < ct.Rows.Count; c++)
                        {
                            int mm = ct.Rows[c]["TCFile"].ToString().Split(',').Length;
                            string nn = ct.Rows[c]["TCFile"].ToString();
                            //根据TID循环依次获得多个附件（适用在数据库一条记录存在多个附件）
                            for (int t = 0; t < mm; t++)
                            {
                                if (nn != null)
                                {
                                    //Byte[] b = CommonFunction.File2Bytes(ct.Rows[c]["TCFile"].ToString().Split(',')[t]);
                                    string kk = nn.Split(',')[t];
                                    Byte[] b = CommonFunction.File2Bytes(kk);
                                    service.SaveFile(b, ct.Rows[c]["TCFile"].ToString().Split(',')[t]);
                                }
                            }

                        }

                    }
                  
                }
                #endregion

                #region 内容上报二
                string aa = "";
                List<GKICMP.localhost1.Teacher_ContractEntity> args = new List<GKICMP.localhost1.Teacher_ContractEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                     DataTable ct = contractDal.GetObjByTCID(id.Split(',')[i]);
                     //if (ct != null || ct.Rows.Count > 0)
                     if (ct != null && ct.Rows.Count > 0)
                     {
                         for (int c = 0; c < ct.Rows.Count; c++)
                         {
                             GKICMP.localhost1.Teacher_ContractEntity model1 = new localhost1.Teacher_ContractEntity();

                             model1.TCID = ct.Rows[c]["TCID"].ToString();
                             model1.TID = ct.Rows[c]["TID"].ToString();
                             model1.DepID = ct.Rows[c]["DepID"].ToString() == "" ? 0 : Convert.ToInt32(ct.Rows[c]["DepID"].ToString()); //所属部门
                             model1.CType = Convert.ToInt32(ct.Rows[c]["CType"].ToString());
                             model1.TCycle = Convert.ToInt32(ct.Rows[c]["TCycle"].ToString());
                             model1.TStartDate = Convert.ToDateTime(ct.Rows[c]["TStartDate"].ToString());
                             model1.TEndDate = Convert.ToDateTime(ct.Rows[c]["TEndDate"].ToString());
                             model1.CreateDate = DateTime.Now; ;
                             model1.TCFile = ct.Rows[c]["TCFile"].ToString();
                             model1.Isdel = (int)CommonEnum.Deleted.未删除;
                             model1.TState = Convert.ToInt32(ct.Rows[c]["TState"].ToString());

                             args.Add(model1);
                         }

                     }
                     else
                     {
                         ShowMessage("暂无新合同需要上报");
                     }
                }
                #endregion

                string sguid = ConfigurationManager.AppSettings["SGUID"];
                GKICMP.localhost1.Teacher_ContractEntity[] A = args.ToArray();
                if (service.TeacherContract(sguid, A, out aa))
                {
                    int rusult = contractDal.Update(id);//更新字段为 已上报
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

        #region 多条上报 ---测试完成 id是PCID
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

                #region 附件上传一
                //for (int i = 0; i < id.Split(',').Length; i++)
                //{
                //    Teacher_ContractEntity dr = contractDal.GetObjByID(id.Split(',')[i]);
                //    for (int t = 0; t < dr.TCFile.Split(',').Length; t++)
                //    {
                //        if (dr.TCFile != null)
                //        {
                //            Byte[] b = CommonFunction.File2Bytes(dr.TCFile.Split(',')[t]);
                //            service.SaveFile(b, dr.TCFile.Split(',')[t]);
                //        }
                //    }

                //}
                #endregion

                #region 内容上报一
                //List<GKICMP.localhost1.Teacher_ContractEntity> args = new List<GKICMP.localhost1.Teacher_ContractEntity>();
                //for (int i = 0; i < id.Split(',').Length; i++)
                //{
                //    Teacher_ContractEntity p = contractDal.GetObjByID(id.Split(',')[i]);
                //    GKICMP.localhost1.Teacher_ContractEntity model1 = new localhost1.Teacher_ContractEntity();

                //    model1.TCID = p.TCID;
                //    model1.TID = p.TID;
                //    model1.DepID = p.DepID;
                //    model1.CType = p.CType;
                //    model1.TCycle = p.TCycle;
                //    model1.TStartDate = p.TStartDate;
                //    model1.TEndDate = p.TEndDate;
                //    model1.CreateDate = DateTime.Now;
                //    model1.TCFile = p.TCFile;
                //    model1.Isdel = (int)CommonEnum.Deleted.未删除;

                //    model1.TState = p.TState;

                //    args.Add(model1);
                //}
                #endregion


                #region 附件上报二
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    // //根据TID获取未上报的合同
                    DataTable ct = contractDal.GetObjByTCID(id.Split(',')[i]);
                    //if (ct != null || ct.Rows.Count > 0)
                    if (ct != null && ct.Rows.Count > 0)
                    {
                        for (int c = 0; c < ct.Rows.Count; c++)
                        {
                            string nn = ct.Rows[c]["TCFile"].ToString();
                            int mm = ct.Rows[c]["TCFile"].ToString().Split(',').Length;
                            //根据TID循环依次获得多个附件（适用在数据库一条记录存在多个附件）
                            for (int t = 0; t < mm; t++)
                            {
                                if (nn != null)
                                {
                                    //Byte[] b = CommonFunction.File2Bytes(ct.Rows[c]["TCFile"].ToString().Split(',')[t]);
                                    string kk = nn.Split(',')[t];
                                    Byte[] b = CommonFunction.File2Bytes(kk);
                                    service.SaveFile(b, kk);
                                }
                            }

                        }

                    }
                }
                #endregion

                #region 内容上报二
                List<GKICMP.localhost1.Teacher_ContractEntity> args = new List<GKICMP.localhost1.Teacher_ContractEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    DataTable ct = contractDal.GetObjByTCID(id.Split(',')[i]);
                    //if (ct != null || ct.Rows.Count > 0)
                    if (ct != null && ct.Rows.Count > 0)
                    {
                        for (int c = 0; c < ct.Rows.Count; c++)
                        {
                            GKICMP.localhost1.Teacher_ContractEntity model1 = new localhost1.Teacher_ContractEntity();

                            model1.TCID = ct.Rows[c]["TCID"].ToString();
                            model1.TID = ct.Rows[c]["TID"].ToString();
                            model1.DepID = ct.Rows[c]["DepID"].ToString() == "" ? 0 : Convert.ToInt32(ct.Rows[c]["DepID"].ToString()); //所属部门
                            model1.CType = Convert.ToInt32(ct.Rows[c]["CType"].ToString());
                            model1.TCycle = Convert.ToInt32(ct.Rows[c]["TCycle"].ToString());
                            model1.TStartDate = Convert.ToDateTime(ct.Rows[c]["TStartDate"].ToString());
                            model1.TEndDate = Convert.ToDateTime(ct.Rows[c]["TEndDate"].ToString());
                            model1.CreateDate = DateTime.Now; ;
                            model1.TCFile = ct.Rows[c]["TCFile"].ToString();
                            model1.Isdel = (int)CommonEnum.Deleted.未删除;
                            model1.TState = Convert.ToInt32(ct.Rows[c]["TState"].ToString());

                            args.Add(model1);
                        }

                    }
                    else
                    {
                        ShowMessage("暂无新合同需要上报");
                    }
                }
                #endregion
                
                string sguid = ConfigurationManager.AppSettings["SGUID"];
              
                GKICMP.localhost1.Teacher_ContractEntity[] A = args.ToArray();

                if (service.TeacherContract(sguid, A, out aa))
                {
                    int rusult = contractDal.Update(id);//更新字段为 已上报
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
        protected void lbtn_Info_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument;
            Response.Write("<script language=javascript>window.open('ContractDetail.aspx?id=" + id + "', '_self')</script>");
        }
    }
}