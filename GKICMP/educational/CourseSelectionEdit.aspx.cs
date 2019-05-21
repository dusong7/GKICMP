/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月14日 18时04分
** 描 述:       选课管理编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class CourseSelectionEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseSelectionDAL selectionDAL = new CourseSelectionDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 参数集合
        public string CSID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ltl_UIDName.Text = UserRealName;
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsSubmit);
                this.rbl_IsSubmit.SelectedIndex = 0;
                if (CSID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion   
     


        #region 取消
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<script>window.location='CourseSelectionManage.aspx';</script>");
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                CourseSelectionEntity model = new CourseSelectionEntity();
                model.CourseID = this.hf_TID.Value.TrimEnd(',');
                model.CSID = CSID;
                model.EYear = this.txt_EYear.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.IsSubmit = Convert.ToInt32(this.rbl_IsSubmit.SelectedValue);
                model.SelectDate = Convert.ToDateTime(this.txt_SelectDate.Text);
                model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue);
                model.UID = UserID;
                model.CourseNames = this.hf_CIDName.Value.TrimEnd(',');
                int result = selectionDAL.Edit(model);
                if (result == 0)
                {
                    int log = CSID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, CSID == "" ? "添加" : "修改" + "姓名为：" + UserRealName + "的信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('保存成功');window.location='CourseSelectionManage.aspx';</script>");
                }
                else if (result == -2)
                {
                    ShowMessage("该学生：" + UserRealName + "，在" + this.txt_EYear.Text + "学年度" + this.ddl_Term.SelectedItem.Text + "已经添加过选课信息，不能重复添加");
                    return;
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            CourseSelectionEntity model = selectionDAL.GetObjByID(CSID);
            if (model != null)
            {
                string a = "";
                this.txt_EYear.Text = model.EYear;
                this.txt_SelectDate.Text = model.SelectDate.ToString("yyyy-MM-dd");
                this.ddl_Term.SelectedValue = model.Term.ToString();
                this.rbl_IsSubmit.SelectedValue = model.IsSubmit.ToString();
                this.hf_TID.Value = model.CourseID;
                string[] arr = model.CourseID.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    a += "\"" + arr[i].ToString() + "\",";
                }
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("<script type='text/javascript'>");
                sb1.Append("$(function () {$('#Series').combotree('setValues',[");
                sb1.Append(a.TrimEnd(','));
                sb1.Append("]);})</script>");
                this.ltl_xz.Text = sb1.ToString();
            }
        }
        #endregion
    }
}