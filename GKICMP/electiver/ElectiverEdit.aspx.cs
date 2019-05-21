/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月03日 8点30分
** 描   述:       选课任务管理
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.electiver
{
    public partial class ElectiverEdit : PageBase
    {
        public ElectiverDAL eleDAL = new ElectiverDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysSetConfigDAL configDAL = new SysSetConfigDAL();

        #region 参数集合
        /// <summary>
        /// 任务ID
        /// </summary>
        public int EleID
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
                SysSetConfigEntity smodel = configDAL.GetObjByID();
                this.ltl_EYear.Text = smodel.EYear.ToString() + "学年度";
                this.ltl_TermID.Text = Enum.GetName(typeof(CommonEnum.XQ), smodel.NowTerm);
                if (EleID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            ElectiverEntity model = eleDAL.GetObjByID(EleID);
            if (model != null)
            {
                this.txt_ElectiverName.Text = model.ElectiverName.ToString();
                this.txt_EBegin.Text = model.EBegin.ToString("yyyy-MM-dd");
                this.txt_EEnd.Text = model.EEnd.ToString("yyyy-MM-dd");
                this.txt_EstimateBDate.Text = model.EstimateBDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.EstimateBDate.ToString("yyyy-MM-dd");
                this.txt_EstimateEDate.Text = model.EstimateEDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.EstimateEDate.ToString("yyyy-MM-dd");
                this.ltl_EYear.Text = model.EYear.ToString() + "学年度";
                this.ltl_TermID.Text = Enum.GetName(typeof(CommonEnum.XQ), model.TermID);
                this.txt_Ecount.Text = model.Ecount.ToString();
                //if (model.EIsAudit == 1)
                //    this.cb_EIsAudit.Checked = true;
                if (model.IsEstmate == 1)
                    this.cb_IsEstmate.Checked = true;
                if (model.IsRelation == 1)
                    this.cb_IsRelation.Checked = true;
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ElectiverEntity model = new ElectiverEntity();
                SysSetConfigEntity smodel = configDAL.GetObjByID();
                model.EleID = EleID;
                model.ElectiverName = this.txt_ElectiverName.Text.ToString().Trim();
                model.EBegin = Convert.ToDateTime(this.txt_EBegin.Text.ToString());
                model.EEnd = Convert.ToDateTime(this.txt_EEnd.Text.ToString());
                model.CreateUser = UserID;
                model.EYear = smodel.EYear;
                model.TermID = smodel.NowTerm;

                model.Ecount =int.Parse( this.txt_Ecount.Text);
                //if (this.cb_EIsAudit.Checked)
                    model.EIsAudit = 1;
                //else
                //    model.EIsAudit = 0;

                if (this.cb_IsEstmate.Checked)
                {
                    model.IsEstmate = 1;
                    model.EstimateBDate = Convert.ToDateTime(this.txt_EstimateBDate.Text.ToString());
                    model.EstimateEDate = Convert.ToDateTime(this.txt_EstimateEDate.Text.ToString());
                }
                else
                {
                    model.IsEstmate = 0;
                    model.EstimateBDate = Convert.ToDateTime("1900-01-01");
                    model.EstimateEDate = Convert.ToDateTime("1900-01-01");
                }

                if (this.cb_IsRelation.Checked)
                    model.IsRelation = 1;
                else
                    model.IsRelation = 0;


               
                model.EStopDate = Convert.ToDateTime(this.txt_EEnd.Text.ToString());
                model.EState = (int)CommonEnum.ElectiveState.未发布;
                

                int result = eleDAL.Edit(model);
                if (result == 0)
                {
                    int log = EleID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity(log, (EleID == -1 ? "添加" : "修改") + "选课任务名称为【" + this.txt_ElectiverName.Text.ToString() + "】的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage(this.ltl_EYear.Text + this.ltl_TermID.Text + "已有选课任务信息，请检查后重新提交");
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