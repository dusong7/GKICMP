/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月15日 9时02分32秒
** 描    述:      教师活动添加页面
** 修 改 人:      
** 修改日期:      
** 修改说明:      
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lecturemanage
{
    public partial class TeacherActivityEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public TeacherActivityDAL teacheractDAL = new TeacherActivityDAL();

        #region 参数集合
        /// <summary>
        /// SAID 教师活动ID
        /// </summary>
        public string SAID
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
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.教学活动类型);
                CommonFunction.DDlTypeBind(this.ddl_ActType, dt, "SDID", "DataName", "-2");
                if (SAID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            TeacherActivityEntity model = teacheractDAL.GetObjByID(SAID);
            if (model != null)
            {
                this.txt_ActName.Text = model.ActName.ToString();
                this.ddl_ActType.SelectedValue = model.ActType.ToString();
                this.txt_ActAddress.Text = model.ActAddress.ToString();
                this.Series.Text = model.Counselor.ToString();
                this.txt_ActContent.Text = model.ActContent.ToString();
                this.txt_ActDesc.Text = model.ActContent.ToString();
                this.txt_ABegin.Text = model.ABegin.ToString("yyyy-MM-dd");
                this.txt_AEnd.Text = model.AEnd.ToString("yyyy-MM-dd");
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                TeacherActivityEntity model = new TeacherActivityEntity();
                model.SAID = SAID.ToString();
                model.ActName = this.txt_ActName.Text.ToString().Trim();
                model.ActType = Convert.ToInt32(this.ddl_ActType.SelectedValue.ToString());
                model.ActAddress = this.txt_ActAddress.Text.ToString().Trim();
                model.Counselor = this.Series.Text.ToString();
                model.ActContent = this.txt_ActContent.Text.ToString().Trim();
                model.ActDesc = this.txt_ActDesc.Text.ToString().Trim();
                model.ABegin = Convert.ToDateTime(this.txt_ABegin.Text.ToString().Trim());
                model.AEnd = Convert.ToDateTime(this.txt_AEnd.Text.ToString().Trim());
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                if(model.ABegin>model.AEnd )
                {
                    ShowMessage("活动结束日期不能小于活动开始日期");
                    return;
                }

                int result = teacheractDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = SAID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SAID == "" ? "添加" : "修改") + "活动名称为：【" + this.txt_ActName.Text.ToString().Trim() + "】的教师活动信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage();
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}