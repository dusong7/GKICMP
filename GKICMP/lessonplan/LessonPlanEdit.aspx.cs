/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月19日 17点17分
** 描   述:      备课计划编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonPlanEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LessonPlanDAL planDAL = new LessonPlanDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public CampusDAL campusDAL = new CampusDAL();
        public SysSetConfigDAL configDAL = new SysSetConfigDAL();

        #region 参数集合
        /// <summary>
        /// 备课计划ID
        /// </summary>
        public string LID
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
                DataTable dtType = baseDataDAL.GetList((int)CommonEnum.BaseDataType.备课类型, -1);
                CommonFunction.DDlTypeBind(this.ddl_LType, dtType, "SDID", "DataName", "-2");

                DataTable dtCampus = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_CID, dtCampus, "CID", "CampusName", "-2");

                //CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TID, "-2");

                if (LID != "")
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
            LessonPlanEntity model = planDAL.GetObjByID(LID);
            if (model != null)
            {
                this.txt_LName.Text = model.LName.ToString();
                //this.txt_LYear.Text = model.LYear.ToString();
                //this.ddl_TID.SelectedValue = model.TID.ToString();
                this.ddl_CID.SelectedValue = model.CID.ToString();
                this.ddl_LType.SelectedValue = model.LType.ToString();
                this.TeachID.Text = model.TeachIDS.ToString();
                this.hf_Teachers.Value = model.TeachIDS.ToString();
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                LessonPlanEntity model = new LessonPlanEntity();
                SysSetConfigEntity smodel = configDAL.GetObjByID();
                if (smodel != null)
                {
                    model.TID = smodel.NowTerm;
                    model.LYear = smodel.EYear.ToString();
                }
                else
                {
                    ShowMessage("系统中无当前学年与学期配置信息，请先完成配置后再提交信息");
                    return;
                }
                model.LID = LID;
                model.LName = this.txt_LName.Text.ToString().Trim();
                //model.LYear = this.txt_LYear.Text.ToString().Trim();
                //model.TID = Convert.ToInt32(this.ddl_TID.SelectedValue.ToString());
                model.CID = Convert.ToInt32(this.ddl_CID.SelectedValue.ToString());
                model.LType = Convert.ToInt32(this.ddl_LType.SelectedValue.ToString());
                model.CreateUser = UserID;
                if (this.TeachID.Text == "")
                {
                    ShowMessage("请选择执教教师");
                    return;
                }

                int result = planDAL.Edit(model, this.TeachID.Text);
                if (result > 0)
                {
                    ShowMessage();
                    int log = LID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (LID == "" ? "添加" : "修改") + "名称为：【" + this.txt_LName.Text.ToString().Trim() + "】的备课信息", UserID));
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
            }
        }
        #endregion
    }
}