/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年02月27日
** 描 述:       考勤节点页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.rlsb
{
    public partial class AttendSetEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public AttendVacationDAL attendVacationDAL = new AttendVacationDAL();
        public AttendSetDAL AttendSetDAL = new AttendSetDAL();
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        #region 参数集合
        /// <summary>
        /// Vid
        /// </summary>
        public int ASID
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
                //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsUse, "-2");
                //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsUse);
                //this.ddl_IsUse.SelectedIndex = 0;

                cblBand();//角色绑定

                if (ASID != -1)
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
            AttendSetEntity model = AttendSetDAL.GetObjByID1(ASID);
            if (model != null)
            {

                this.txt_MBegin.Text = model.MBegin.ToString("HH:mm:ss");
                this.txt_MEnd.Text = model.MEnd.ToString("HH:mm:ss");
                this.txt_AName.Text = model.AName == null ? "" : model.AName;
                //this.ddl_IsUse.SelectedValue = model.IsUse.ToString();
                this.rdo_IsUse.SelectedValue = model.IsUse.ToString();
                this.rbo_Type.SelectedValue = model.OutType.ToString();
                int mm = model.Roles.ToString().Split(',').Length;
                string nn = model.Roles.ToString();
                for (int t = 0; t < mm; t++)
                {
                    if (nn != null)
                    {
                        string kk = nn.Split(',')[t];
                        foreach (ListItem li in this.cbl_Role.Items)
                        {
                            if (kk == li.Value)
                            {
                                li.Selected = true;
                            }
                        }

                    }
                }


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
                AttendSetEntity model = new AttendSetEntity();
                model.ASID = ASID;
                model.MBegin = this.txt_MBegin.Text == "" ? Convert.ToDateTime("1990/1/1 0:00:00") : Convert.ToDateTime(this.txt_MBegin.Text.Trim());
                model.MEnd = this.txt_MEnd.Text == "" ? Convert.ToDateTime("1990/1/1 0:00:00") : Convert.ToDateTime(this.txt_MEnd.Text.Trim());
                model.AName = this.txt_AName.Text;
                // model.IsUse = Convert.ToInt32(this.ddl_IsUse.SelectedValue.ToString());
                model.IsUse = int.Parse(this.rdo_IsUse.SelectedValue);
                model.OutType =int.Parse( this.rbo_Type.SelectedValue);
                //绑定角色
                string roles = "";
                foreach (ListItem li in this.cbl_Role.Items)
                {
                    if (li.Selected)
                    {
                        roles = roles + li.Value + ",";
                    }
                }
                if (roles.Length > 0)
                {
                    roles = roles.Substring(0, roles.Length);
                }
                model.Roles = roles;


                int result = AttendSetDAL.Edit1(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = ASID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (ASID == -1 ? "增加" : "修改") + "考勤节点信息", UserID));
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
            DataTable TypeR = sysRoleDAL.GetList(1, (int)CommonEnum.Deleted.未删除);
            CommonFunction.CBLTypeBind(this.cbl_Role, TypeR, "RoleID", "RoleName");
        }

        #endregion
    }
}