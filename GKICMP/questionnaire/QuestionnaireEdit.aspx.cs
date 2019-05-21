/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2016年11月07日
** 描 述:       用户管理编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.questionnaire
{
    public partial class QuestionnaireEdit : PageBase
    {
        //public SysRoleUserDAL roleUserDAL = new SysRoleUserDAL();
        public SysRoleDAL roleDAL = new SysRoleDAL();
        public QuestionnaireDAL questionnaireDAL = new QuestionnaireDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string QID
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
                cblBand();
                this.hf_QID.Value = Guid.NewGuid().ToString();
                if (QID != "")
                {
                    this.hf_QID.Value = QID;
                    InfoBind();
                }
            }
        }
        #endregion
        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            QuestionnaireEntity model = questionnaireDAL.GetObjByID(QID);
            if (model != null)
            {
                this.txt_QuestName.Text = model.QuestName;//问卷名称
                this.txt_Questxplain.Text = model.Questxplain;//问卷注意事项
                this.ddl_IsName.SelectedValue = model.IsRealName.ToString();//是否实名
                //角色限制
                DataTable TypeR = questionnaireDAL.GetRoleTable(QID);
                foreach (DataRow dr in TypeR.Rows)
                {
                    string value = dr["RoleID"].ToString();
                    foreach (ListItem li in this.cbl_Role.Items)
                    {
                        if (value == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
                this.txt_LastDate.Text = model.LastDate.ToString("yyyy-MM-dd");//截至日期
                //this.ddl_IsPublish.SelectedValue = model.IsPublish.ToString();//是否发布
                //this.rbtn_DataRole.SelectedValue = model.DataRole;
            }
        }
        #endregion

        #region 角色绑定
        /// <summary>
        /// 角色绑定
        /// </summary>
        private void cblBand()
        {
            //checkboxlist 绑定
            DataTable TypeR = roleDAL.GetList(1, (int)CommonEnum.Deleted.未删除);
            CommonFunction.CBLTypeBind(this.cbl_Role, TypeR, "RoleID", "RoleName");
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                QuestionnaireEntity model = new QuestionnaireEntity();
                model.QID = this.hf_QID.Value;
                model.QuestName = this.txt_QuestName.Text.Trim();//问卷名称
                model.Questxplain = this.txt_Questxplain.Text.Trim();//注意事项
                model.IsRealName = int.Parse(this.ddl_IsName.SelectedValue);//用户类别
                //角色(投票人群)
                string QestCrowd = "";
                string roles = "";
                foreach (ListItem li in this.cbl_Role.Items)
                {
                    if (li.Selected)
                    {
                        roles += li.Value + ",";
                        QestCrowd += li.Text + ",";
                    }
                }
                if (roles == "")
                {
                    ShowMessage("请选择投票人群");
                    return;
                }
                model.QestCrowd = QestCrowd.TrimEnd(',');
                model.LastDate = Convert.ToDateTime(this.txt_LastDate.Text);
                // model.IsPublish = int.Parse(this.ddl_IsPublish.SelectedValue);
                model.IsPublish = (int)CommonEnum.IsorNot.否;
                model.CreateUser = UserID;
                model.CreateDate = DateTime.Now;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                int id = 0;
                if (!string.IsNullOrEmpty(QID))
                    id = 1;//编辑
                int result = questionnaireDAL.Edit(id, model, roles);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该问卷已存在，请重新输入");
                    return;
                }

                else
                {
                    int log = QID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (QID == "" ? "添加" : "修改") + "名称为：【" + this.txt_QuestName.Text + "】的问卷调查信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                return;
            }
        }
        #endregion
    }
}