/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 16时15分48秒
** 描    述:      评分标准编辑页面
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

namespace GKICMP.lecturemanage
{
    public partial class LectureStandardEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Lecture_StandardDAL standardDAL = new Lecture_StandardDAL();

        #region 参数集合
        /// <summary>
        /// LSID
        /// </summary>
        public int LSID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentID
        {
            get
            {
                return GetQueryString<int>("pid", -2);
            }
        }

        /// <summary>
        /// 0:添加 1：修改
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }

        /// <summary>
        /// //标识 1：听课标准 2：考核标准
        /// </summary>
        public int PType
        {
            get
            {
                return GetQueryString<int>("type", -1);
            }
        }

        /// <summary>
        /// 考核ID
        /// </summary>
        public int PFID
        {
            get
            {
                return GetQueryString<int>("pfid", -1);
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
                //DataTable dt = standardDAL.GetList((int)CommonEnum.Deleted.未删除);//LSID去除编辑中的父级ID
                //CommonFunction.DDlTypeBind(this.ddl_PID, dt, "LSID", "StandardContent", "-2");
                if (LSID != -1)
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
            Lecture_StandardEntity model = standardDAL.GetObjByID(LSID);
            if (model != null)
            {
                //this.ddl_PID.SelectedValue = model.ParentID.ToString();
                this.txt_LScore.Text = model.LScore.ToString();
                this.txt_SOrder.Text = model.SOrder.ToString();
                this.txt_StandardContent.Text = model.StandardContent.ToString();
                this.hf_PID.Value = model.ParentID.ToString();
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
                Lecture_StandardEntity model = new Lecture_StandardEntity();
                model.LSID = LSID;
                model.StandardContent = this.txt_StandardContent.Text.ToString().Trim();
                model.LScore = Convert.ToInt32(this.txt_LScore.Text.ToString().Trim());
                if (Flag == 0)
                {
                    model.ParentID = ParentID;
                }
                else
                {
                    model.ParentID = Convert.ToInt32(this.hf_PID.Value.ToString());
                }
                model.SOrder = Convert.ToInt32(this.txt_SOrder.Text.ToString().Trim());
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.LSFlag = PType;//标识 1：听课标准 2：考核标准
                if (PType == 1)
                {
                    model.PFID = -1;
                }
                else
                {
                    model.PFID = PFID;
                }

                int result = standardDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log=LSID == -1?(int)CommonEnum.LogType.操作日志_添加:(int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (LSID == -1 ? "添加" : "修改") + "评分标准信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("提交此标准后同级标准分值之和超出上级定义分值，请修改后重新提交");
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}