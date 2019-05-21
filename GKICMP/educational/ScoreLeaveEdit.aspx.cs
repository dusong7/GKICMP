/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月16日 16时54分10秒
** 描    述:      分数等级操作类
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

namespace GKICMP.educational
{
    public partial class ScoreLeaveEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ScoreLevelDAL scoreLeaveDAL = new ScoreLevelDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 参数集合
        public int SLID
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
                DataTable dtGrade = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
                CommonFunction.CBLTypeBind(this.ckl_GID, dtGrade, "GID", "ShortGName");
                CommonFunction.BindEnum<CommonEnum.SLName>(this.ddl_SLName, "-2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-2");
                if (SLID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ScoreLevelEntity model = new ScoreLevelEntity();
                model.SLID = SLID;
                model.BScore = Convert.ToInt32(this.txt_BScore.Text.Trim());
                model.EScore = Convert.ToInt32(this.txt_EScore.Text.Trim());
                model.SLName = this.ddl_SLName.SelectedItem.ToString();
                if (model.EScore <= model.BScore)
                {
                    ShowMessage("结束分数不能小于等于开始分数，请重新录入");
                    return;
                }
                string GIDS = "";
                string GIDSName = "";
                for (int i = 0; i < this.ckl_GID.Items.Count; i++)
                {

                    if (ckl_GID.Items[i].Selected)
                    {
                        GIDS += ckl_GID.Items[i].Value + ",";
                        GIDSName += ckl_GID.Items[i].Text + ",";
                    }
                }
                if (GIDS == "")
                {
                    ShowMessage("请选择年级");
                    return;
                }
                model.CID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                model.GIDS = GIDS.TrimEnd(',');
                int result = scoreLeaveDAL.Edit(model);
                if (result == 0)
                {
                    if (SLID == -1)
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加年级为：" + GIDSName.TrimEnd(',') + "的分数等级信息", UserID));
                    else
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改年级为：" + GIDSName.TrimEnd(',') + "的分数等级信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("该年级的课程等级已存在，请重新录入");
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
            ScoreLevelEntity model = scoreLeaveDAL.GetObjByID(SLID);
            if (model != null)
            {
                for (int i = 0; i < this.ckl_GID.Items.Count; i++)
                {
                    if (ckl_GID.Items[i].Value == model.GID.ToString())
                    {
                        ckl_GID.Items[i].Selected = true;
                    }
                }
                this.ckl_GID.Enabled = false;
                this.ddl_CourseName.SelectedValue = model.CID.ToString();
                this.ddl_SLName.SelectedValue = (model.SLName.ToString() == CommonEnum.SLName.优秀.ToString() ? (int)CommonEnum.SLName.优秀 : model.SLName.ToString() == CommonEnum.SLName.良好.ToString() ? (int)CommonEnum.SLName.良好 : model.SLName.ToString() == CommonEnum.SLName.合格.ToString() ? (int)CommonEnum.SLName.合格 : (int)CommonEnum.SLName.不合格).ToString();
                this.txt_BScore.Text = model.BScore.ToString();
                this.txt_EScore.Text = model.EScore.ToString();
            }
        }
        #endregion
    }
}