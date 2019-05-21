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

namespace GKICMP.studentmanage
{
    public partial class StuQualityManage : PageBase
    {
        public Stu_QualityDAL stu_QualityDAL = new Stu_QualityDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term,"-99");
                SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
                this.ddl_Term.SelectedValue = model.NowTerm.ToString();
                //if (DateTime.Now.Month > 9 || DateTime.Now.Month < 3) 
                //{
                //    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                //}
                GetCondition();
                DataBindList();
            }
        }
        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString());
            ViewState["EYear"] = CommonFunction.GetCommoneString(this.txt_EYear.Text.ToString());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Stu_QualityEntity model = new Stu_QualityEntity();
            model.EYear = ViewState["EYear"].ToString();
            model.Term = int.Parse(this.ddl_Term.SelectedValue);
            model.StuName = ViewState["RealName"].ToString();
            DataTable dt = stu_QualityDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                string[] rid = ids.Split(',');
                //string content = "";
                //for (int i = 0; i < rid.Length; i++)
                //{
                //    Stu_QualityEntity sysUser = stu_QualityDAL.GetObjByID(rid[i].ToString());
                //    if (sysUser.UserName == "admin")
                //    {
                //        ShowMessage("删除失败！管理员账号不能删除！");
                //        this.hf_CheckIDS.Value = "";
                //        return;
                //    }
                //    if (i == rid.Length - 1)
                //    {
                //        content += sysUser.UserName;
                //    }
                //    else
                //    {
                //        content += sysUser.UserName + "、";
                //    }
                //}
                int delresult = stu_QualityDAL.DeleteBat(ids);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除学生素质评价信息", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}