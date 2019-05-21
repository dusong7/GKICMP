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
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GKICMP.teachermanage
{
    public partial class ContractDetail : PageBase
    {
        Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        protected int v = 0;
        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string TCID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                if (TCID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {

            Teacher_ContractEntity model = contractDal.GetObjByID(TCID);
            if (model != null)
            {
                this.ltl_TeacherName.Text = model.RealName.ToString();
                this.ltl_TCycle.Text = model.TCycle.ToString() + "年";
                this.ltl_TStartDate.Text = model.TStartDate.ToString() == "0001/1/1 0:00:00" ? "" : model.TStartDate.ToString("yyyy-MM-dd");
                this.ltl_TEndDate.Text = model.TEndDate.ToString() == "0001/1/1 0:00:00" ? "" : model.TEndDate.ToString("yyyy-MM-dd");
                this.ltl_OverDate.Text = model.OverDate.ToString() == "0001/1/1 0:00:00" ? "" : model.OverDate.ToString("yyyy-MM-dd");

                //this.ltl_CType.Text = CommonFunction.CheckEnum<CommonEnum.BaseDataType>(model.CType);
                this.ltl_CType.Text = model.CTypeName.ToString();

                this.ltl_TState.Text = model.TState == (int)CommonEnum.TState.到期 ? "到期" : (model.TState == (int)CommonEnum.TState.解除 ? "解除" : "正常");
                
                DataTable dt = new DataTable();
                List<string> list = new List<string>();
                DataTable dt1 = contractDal.GetPagedHistory(TCID); //
                if (dt1.Rows.Count > 0)
                {
                    this.tr_null.Visible = false;
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (dt1.Rows[i]["TCFile"].ToString() != "")
                        {
                            foreach (string file in dt1.Rows[i]["TCFile"].ToString().Split(','))
                            {
                                list.Add(file);
                            }
                        }
                    }
                }
                else
                    this.tr_null.Visible = true;

                //合同附件
                if (model.TCFile != null && model.TCFile.ToString() != "")
                {
                    foreach (string file in model.TCFile.Split(','))
                    {
                        list.Add(file);
                    }
                    dt.Columns.Add("tcfile", typeof(string));
                    foreach (string cfile in list)
                    {
                        DataRow dr = dt.NewRow();
                        dr["tcfile"] = cfile;
                        dt.Rows.Add(dr);
                    }

                    this.rp_File.DataSource = dt;
                    this.rp_File.DataBind();
                }
                this.rp_List.DataSource = dt1;
                this.rp_List.DataBind();
            }
        }
        #endregion


        #region 附件下载
        /// <summary>
        /// 附件下载、删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string tcid = e.CommandArgument.ToString().Trim();
            Teacher_ContractEntity model = contractDal.GetObjByID(TCID);

            if (!CommonFunction.UpLoadFunciotn(model.TCFile, "合同附件"))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }
        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = contractDal.GetTable(TCID); //
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion
    }
}