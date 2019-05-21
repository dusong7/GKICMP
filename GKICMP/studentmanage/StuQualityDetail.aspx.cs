/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      liufuzhou 
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
    public partial class StuQualityDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Stu_QualityDAL stu_QualityDAL = new Stu_QualityDAL();
        #region 参数集合
        public string SQID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (SQID != "")
                {
                    BindInfo();
                }
              
            }
        }
        #region 初始化用户数据
        public void BindInfo()
        {
            try
            {
                Stu_QualityEntity model = stu_QualityDAL.GetObjByID(SQID);
                if (model != null)
                {
                    this.ltl_SXDD.Text = model.SXDD;
                    this.ltl_QFXX.Text = model.QFXX;
                    this.ltl_STSZ.Text = model.STSZ;
                    this.ltl_SMSMNL.Text = model.SMSMNL;
                    this.ltl_SHLDJN.Text = model.SHLDJN;
                    this.ltl_CZJSCZNL.Text = model.CZJSCZNL;
                    this.ltl_Term.Text = model.Term.ToString();
                    this.ltl_EYear.Text = model.EYear;
                    this.ltl_StID.Text = model.StuName;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("系统查询出错，请查看系统日志信息");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion
    }
}