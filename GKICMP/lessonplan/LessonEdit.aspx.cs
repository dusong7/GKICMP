/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月20日 17时36分35秒
** 描    述:      备课编辑页
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonEdit : PageBase
    {
        public LessonDAL lessonDAL = new LessonDAL();
        public LessonPlanDAL planDAL = new LessonPlanDAL();
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 备课ID
        /// </summary>
        public string LesID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        /// <summary>
        /// 备课计划ID
        /// </summary>
        public string LID
        {
            get
            {
                return GetQueryString<string>("lid", "");
            }
        }
        /// <summary>
        /// 计划清单ID
        /// </summary>
        public string LDID
        {
            get
            {
                return GetQueryString<string>("ldid", "");
            }
        }

        /// <summary>
        /// 课程类型：社团活动 体验课程
        /// </summary>
        public int LType
        {
            get
            {
                return GetQueryString<int>("ltype", -1);
            }
        }

        /// <summary>
        /// 是否备课 
        /// </summary>
        public int IsPrepare
        {
            get
            {
                return GetQueryString<int>("isprepare", -1);
            }
        }

        /// <summary>
        /// 1.备课计划 2.我的备课
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //根据备课类型显示不同数据
                BaseDataEntity bmodel = baseDataDAL.GetList(LType);
                if (bmodel != null)
                {
                    this.hf_Type.Value = bmodel.DataName;
                    if (bmodel.DataName == "社团活动")
                    {
                        this.ltl_Speaker.Text = "主讲人";
                        this.trClaIDs.Visible = false;
                    }
                    else
                    {
                        this.ltl_Speaker.Text = "执教教师";
                        this.trAssistant.Visible = false;
                    }
                }
                //绑定教师数据
                DataTable dt = planDAL.GetLessonTeacher(LID);
                CommonFunction.CBLTypeBind(this.chk_Speaker, dt, "TeachID", "TeacherName");
                CommonFunction.CBLTypeBind(this.chk_Assistant, dt, "TeachID", "TeacherName");

                if (IsPrepare == 0 || IsPrepare == -1)
                {
                    LessonPlan_DetailEntity model = detailDAL.GetObjByID(LDID);
                    if (model != null)
                    {
                        this.txt_AContent.Text = model.AContent.ToString();
                        this.txt_PDate.Text = model.PDate.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            //LessonEntity model = lessonDAL.GetObjByID(LesID);
            DataTable dt = lessonDAL.GetList(LDID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.txt_PDate.Text = dt.Rows[0]["PDate"].ToString();
                this.txt_ActivityAddress.Text = dt.Rows[0]["ActivityAddress"].ToString();
                this.txt_AContent.Text = dt.Rows[0]["AContent"].ToString();
                this.txt_ActivityTarget.Text = dt.Rows[0]["ActivityTarget"].ToString();
                this.txt_ActivityPre.Text = dt.Rows[0]["ActivityPre"].ToString();
                this.txt_Content.Text = dt.Rows[0]["ActivityContent"].ToString();
                this.hf_ClaID.Value = dt.Rows[0]["ClaIDs"].ToString();
                string[] bt = dt.Rows[0]["Speaker"].ToString().Split(',');
                foreach (string dr in bt)
                {
                    foreach (ListItem li in this.chk_Speaker.Items)
                    {
                        if (dr == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
                string[] bt1 = dt.Rows[0]["Assistant"].ToString().Split(',');
                foreach (string dr in bt1)
                {
                    foreach (ListItem li in this.chk_Assistant.Items)
                    {
                        if (dr == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string speaker = "";
                string assistant = "";
                LessonEntity model = new LessonEntity();
                model.LesID = LesID;
                model.LDID = LDID;
                model.LID = LID;
                model.ActivityAddress = this.txt_ActivityAddress.Text.ToString().Trim();
                model.PDate = Convert.ToDateTime(this.txt_PDate.Text.ToString());
                model.AContent = this.txt_AContent.Text.ToString().Trim();
                model.ActivityPre = this.txt_ActivityPre.Text.ToString().Trim();
                model.CRID = -1;
                model.ActivityTarget = this.txt_ActivityTarget.Text.ToString().Trim();
                model.ActivityContent = this.txt_Content.Text.ToString().Trim();

                foreach (ListItem li in this.chk_Speaker.Items)
                {
                    if (li.Selected)
                    {
                        speaker = speaker + li.Value + ",";
                    }
                }
                foreach (ListItem li in this.chk_Assistant.Items)
                {
                    if (li.Selected)
                    {
                        assistant = assistant + li.Value + ",";
                    }
                }
                if (speaker == "")
                {
                    ShowMessage("请选择" + this.ltl_Speaker.Text.ToString());
                    return;
                }
                if (this.hf_Type.Value == "社团活动")
                {
                    if (assistant == "")
                    {
                        ShowMessage("请选择助教");
                        return;
                    }
                }
                else
                {
                    if (this.hf_ClaID.Value == "")
                    {
                        ShowMessage("请选择班级");
                        return;
                    }
                }
                model.Speaker = speaker;
                model.Assistant = assistant;
                model.ClaIDs = this.hf_ClaID.Value.ToString();
                model.CreateUser = UserID;
                model.LastUser = UserID;

                int result = lessonDAL.Edit(model, IsPrepare);
                if (result > 0)
                {
                    int log = (IsPrepare == -1 || IsPrepare == 0) ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    string url = "";
                    if (Flag == 1)
                    {
                        url = "LessonManage.aspx";
                    }
                    else if (Flag == 2)
                    {
                        url = "PersonLessonManage.aspx";
                    }
                    else
                    {
                        url = "../spacemanage/TeacherLesson.aspx";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='" + url + "?lid=" + LID + "&ltype=" + LType + "&id=" + UserID + "'</script>");
                    sysLogDAL.Edit(new SysLogEntity(log, ((IsPrepare == -1 || IsPrepare == 0) ? "添加" : "修改") + "活动内容为：【" + this.txt_AContent.Text.ToString().Trim() + "】的备课信息", UserID));
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