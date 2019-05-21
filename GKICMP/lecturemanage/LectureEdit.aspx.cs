/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 13时41分01秒
** 描    述:      教师听课操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lecturemanage
{
    public partial class LectureEdit : PageBase
    {
        public LectureDAL lecDAL = new LectureDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// LID
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
                if (LID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void InfoBind()
        {
            LectureEntity model = lecDAL.GetObjByID(LID);
            if (model != null)
            {
                this.txt_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                this.txt_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                this.hf_ClaID.Value = model.ClaID.ToString();
                this.hf_CourseID.Value = model.CID.ToString();
                this.hf_TID.Value = model.TID.ToString();
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
                LectureEntity model = new LectureEntity();
                if (this.hf_CourseID.Value == "")
                {
                    ShowMessage("请选择课程");
                    return;
                }
                if (this.hf_ClaID.Value == "")
                {
                    ShowMessage("请选择班级");
                    return;
                }
                if (this.hf_TID.Value == "")
                {
                    ShowMessage("请选择授课教师");
                    return;
                }
                model.LID = LID;
                model.ClaID = Convert.ToInt32(this.hf_ClaID.Value.ToString());
                model.CID = Convert.ToInt32(this.hf_CourseID.Value.ToString());
                model.BeginDate = Convert.ToDateTime(this.txt_BeginDate.Text.ToString());
                model.EndDate = Convert.ToDateTime(this.txt_EndDate.Text.ToString());
                if (model.BeginDate >= model.EndDate)
                {
                    ShowMessage("听课结束时间应大于听课开始时间");
                    return;
                }
                model.TID = this.hf_TID.Value.ToString();
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = lecDAL.Edit(model);
                if (result == 0)
                {
                    //ShowMessage();
                    int log = LID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (LID == "" ? "添加" : "修改") + "教师听课信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='LectureList.aspx';", true);
                }
                else if (result == -2)
                {
                    ShowMessage("该时段内该授课教师已有听课安排，请修改后重新录入");
                    return;
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
                return;
            }
        }
        #endregion
    }
}