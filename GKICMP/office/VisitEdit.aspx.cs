/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月05日 14时30分10秒
** 描    述:      来访登记编辑页面
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

namespace GKICMP.office
{
    public partial class VisitEdit : PageBase
    {
        public VisitDAL visitDAL = new VisitDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 参数集合
        public int VID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.来访类型);
                CommonFunction.DDlTypeBind(this.ddl_VisitType, dt, "SDID", "DataName", "-2");
                if (VID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            VisitEntity model = visitDAL.GetObjByID(VID);
            if (model != null)
            {
                this.txt_VisitUser.Text = model.VisitUser.ToString().Trim();
                this.txt_VDate.Text = model.VDate.ToString("yyyy-MM-dd HH:mm");
                this.txt_VisitReason.Text = model.VisitReason.ToString().Trim();
                this.txt_SchoolUser.Text = model.SchoolUser.ToString().Trim();
                this.txt_LinkNum.Text = model.LinkNum.ToString().Trim();
                this.txt_VMark.Text = model.VMark.ToString().Trim();
                this.ddl_VisitType.SelectedValue = model.VisitType.ToString();
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                VisitEntity model = new VisitEntity();
                model.VID = VID;
                model.VisitUser = this.txt_VisitUser.Text.ToString().Trim();
                model.VDate = Convert.ToDateTime(this.txt_VDate.Text.ToString());
                if (model.VDate > DateTime.Now)
                {
                    ShowMessage("来访时间不得大于当前时间");
                    return;
                }
                model.VisitReason = this.txt_VisitReason.Text.ToString().Trim();
                model.SchoolUser = this.txt_SchoolUser.Text.ToString().Trim();
                model.LinkNum = this.txt_LinkNum.Text.ToString().Trim();
                model.CreateUser = UserID;
                model.VMark = this.txt_VMark.Text.ToString().Trim();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.VisitType = Convert.ToInt32(this.ddl_VisitType.SelectedValue.ToString());
                model.VisitCount = Convert.ToInt32(this.txt_VisitCount.Text.ToString());

                int result = visitDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = VID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (VID == -1 ? "添加" : "修改") + "来访人为【" + this.txt_VisitUser.Text.ToString().Trim() + "】的来访信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
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