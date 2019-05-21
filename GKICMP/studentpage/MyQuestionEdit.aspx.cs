/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年3月07日
** 描 述:       问卷答题页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using System.Data;
using GK.GKICMP.Entities;

namespace GKICMP.studentpage
{
    public partial class MyQuestionEdit : PageBase
    {
        public Questionnaire_SubjectDAL subjectDAL = new Questionnaire_SubjectDAL();
        public Questionnaire_OptionDAL optionDAL = new Questionnaire_OptionDAL();
        public Questionnaire_AnswerDAL answerDAL = new Questionnaire_AnswerDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public string QID
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
                DataTable dt = subjectDAL.GetPagedByQID(QID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.rpListQ.DataSource = dt;
                    this.rpListQ.DataBind();
                }
            }
        }
        #endregion



        #region 获取题目选项列表
        protected void rpListQ_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hf_QSID = (HiddenField)e.Item.FindControl("hf_QSID");
                RadioButtonList rbl_List = (RadioButtonList)e.Item.FindControl("rbl_List");
                CheckBoxList chk_List = (CheckBoxList)e.Item.FindControl("chk_List");
                TextBox txt_List = (TextBox)e.Item.FindControl("txt_List");
                DataTable dt = optionDAL.GetPagedByQSID(Convert.ToInt32(hf_QSID.Value));
                Questionnaire_SubjectEntity model = subjectDAL.GetObjByID(hf_QSID.Value);
                if (model.SubType == 1)
                {
                    chk_List.DataSource = dt;
                    chk_List.DataTextField = "OptionContent";
                    chk_List.DataValueField = "OptionVlaue";
                    chk_List.DataBind();
                    txt_List.Visible = false;
                }
                if (model.SubType == 0)
                {
                    rbl_List.DataSource = dt;
                    rbl_List.DataTextField = "OptionContent";
                    rbl_List.DataValueField = "OptionVlaue";
                    rbl_List.DataBind();
                    txt_List.Visible = false;
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string QSID = "";
                string OID = "";
                for (int i = 0; i < rpListQ.Items.Count; i++)
                {
                    RadioButtonList rbl_List = (RadioButtonList)rpListQ.Items[i].FindControl("rbl_List");
                    CheckBoxList chk_List = (CheckBoxList)rpListQ.Items[i].FindControl("chk_List");
                    TextBox txt_List = (TextBox)rpListQ.Items[i].FindControl("txt_List");
                    HiddenField hf_QSID = (HiddenField)rpListQ.Items[i].FindControl("hf_QSID");
                    QSID += hf_QSID.Value + "|";

                    if (rbl_List.Items.Count > 0)
                    {
                        bool rbl = false;
                        for (int j = 0; j < rbl_List.Items.Count; j++)
                        {
                            rbl |= rbl_List.Items[j].Selected;
                        }
                        if (!rbl)
                        {
                            ShowMessage("第" + (i + 1).ToString() + "题请选择你的答案");
                            return;
                        }
                        else
                        {
                            for (int j = 0; j < rbl_List.Items.Count; j++)
                            {
                                if (rbl_List.Items[j].Selected)
                                {
                                    OID += rbl_List.Items[j].Value + "|";
                                }
                            }
                        }
                    }
                    else if (chk_List.Items.Count > 0)
                    {
                        bool chk = false;
                        for (int j = 0; j < chk_List.Items.Count; j++)
                        {
                            chk |= chk_List.Items[j].Selected;
                        }
                        if (!chk)
                        {
                            ShowMessage("第" + (i + 1).ToString() + "题请选择你的答案");
                            return;
                        }
                        else
                        {
                            string b = "";
                            for (int j = 0; j < chk_List.Items.Count; j++)
                            {
                                if (chk_List.Items[j].Selected)
                                {
                                    b += chk_List.Items[j].Value + ",";
                                }
                            }
                            OID += b.TrimEnd(',') + "|";
                        }
                    }
                    else
                    {
                        OID += txt_List.Text + "|";
                    }
                }
                Questionnaire_AnswerEntity model = new Questionnaire_AnswerEntity();
                model.QAID = "";
                model.UID = UserID;
                model.QID = QID;
                model.OID = OID.Substring(0, OID.Length - 1);
                int result = answerDAL.Edit(model, QSID.TrimEnd('|'));
                if (result == 0)
                {
                    int log = model.QAID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, model.QAID == "" ? "添加" : "" + "姓名：" + UserID + "的问卷调查结果", UserID));
                    ShowMessage();
                }
                else if (result == -2) { ShowMessage("该问卷已提交过，请勿重复答卷"); }
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


    }
}