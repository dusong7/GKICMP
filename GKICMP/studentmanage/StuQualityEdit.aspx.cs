/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年01月06日 09时52分17秒
** 描    述:      题目编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.studentmanage
{
    public partial class StuQualityEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Stu_QualityDAL stu_QualityDAL = new Stu_QualityDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        #region 参数集合
        public string SQID
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
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");


                if (SQID != "")
                {
                    BindInfo();
                    this.txt_StID.Enabled = false;
                }
                else
                {
                    SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
                    this.txt_EYear.Text = model.EYear;
                    this.ddl_Term.SelectedValue = model.NowTerm.ToString();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Stu_QualityEntity model = new Stu_QualityEntity();
                model.SQID = SQID;
                model.SXDD = this.ddl_SXDD.SelectedValue;
                model.QFXX = this.ddl_QFXX.SelectedValue;
                model.STSZ = this.ddl_STSZ.SelectedValue;
                model.SMSMNL = this.ddl_SMSMNL.SelectedValue;
                model.SHLDJN = this.ddl_SHLDJN.SelectedValue;
                model.CZJSCZNL = this.ddl_CZJSCZNL.SelectedValue;
                model.Term = int.Parse(this.ddl_Term.SelectedValue);
                model.EYear = this.txt_EYear.Text;
                model.CreateUser = UserID;
                model.CreateDate = DateTime.Now;
                model.StID = this.txt_StID.Text;

                string result = stu_QualityDAL.Edit(model);
                if (result == "0")
                {
                    ShowMessage();
                    int log = SQID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, SQID == "" ? "添加" : "修改" + "学生素质评价的信息", UserID));
                }
                else if (result == "-1")
                {
                    ShowMessage("保存失败");
                    return;
                }
                else
                {
                     ShowMessage("系统中已存在【"+result.Trim(',')+"】的素质评价信息，请去除重复学生再添加");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            Stu_QualityEntity model = stu_QualityDAL.GetObjByID(SQID);
            if (model != null)
            {
              this.ddl_SXDD.SelectedValue  =model.SXDD  ;
              this.ddl_QFXX.SelectedValue = model.QFXX;
              this.ddl_STSZ.SelectedValue = model.STSZ;
              this.ddl_SMSMNL.SelectedValue = model.SMSMNL;
              this.ddl_SHLDJN.SelectedValue = model.SHLDJN;
              this.ddl_CZJSCZNL.SelectedValue = model.CZJSCZNL;
              this.ddl_Term.SelectedValue = model.Term.ToString();
              this.txt_EYear.Text = model.EYear;
              this.txt_StID.Text = model.StID;
            }
        }
        #endregion
    }
}