/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月28日
** 描 述:       用户详情页面
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

namespace GKICMP.sysmanage
{
    public partial class SysUserDetail : PageBase
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string UID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (UID != "")
                {
                    cblBand();
                    InfoBind();
                }
            }
        }
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
        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            SysUserEntity model = sysUserDAL.GetObjByID(UID);
            if (model != null)
            {
                this.ltl_UserName.Text = model.UserName;//有用户名
                if (model.IDCard != null && model.IDCard != "")
                {
                    this.ltl_IDCard.Text = model.IDCard;//身份证
                }
                else
                {
                    this.ltl_IDCard.Text = "";
                }
                this.ltl_CellPhone.Text = model.CellPhone;//手机号
                this.ltl_Address.Text = model.Address;//家庭地址
               // this.ltl_CompanyNum.Text = model.CompanyNum;//公司座机
                this.ltl_MailNum.Text = model.MailNum;//邮箱
                this.ltl_QQNum.Text = model.QQNum;//QQ号
                this.ltl_WeiNum.Text = model.WeiNum;//微信号
                if (model.BirthDay != null && model.BirthDay.ToString("yyyy-MM-dd") != "0001-01-01")
                {
                    this.ltl_BirthDay.Text = model.BirthDay.ToString("yyyy-MM");//出生年月
                }
                else
                {
                    this.ltl_BirthDay.Text = "";
                }
                this.ltl_UserSex.Text = Convert.ToString(model.UserSex.ToString());//性别
                this.ltl_UserSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.UserSex.ToString());
                //this.ltl_UserType.Text = CommonFunction.CheckEnum<CommonEnum.UserType>(model.UserType.ToString());//类型
                this.ltl_CampusName.Text = model.CampusName.ToString();
                this.ltl_RealName.Text = model.RealName;//姓名 
                this.ltl_UserNation.Text = CommonFunction.CheckEnum<CommonEnum.MZ>(model.Nation.ToString());//民族
               // this.ltl_UState.Text = CommonFunction.CheckEnum<CommonEnum.State>(model.UState.ToString());//状态
                this.ltl_UserDesc.Text = model.UserDesc;//描述
                //this.ltl_CardNum.Text = model.CardNum;//一卡通
                this.ltl_DepName.Text = model.DepName;
                DataTable TypeR = sysRoleDAL.GetTable(UID);
                foreach (DataRow dr in TypeR.Rows)
                {
                    string value = dr["RoleID"].ToString();
                    foreach (ListItem li in this.cbl_Role.Items)
                    {
                        if (value == li.Value)
                        {
                            li.Selected = true;
                        }
                        li.Enabled = false;
                    }
                }
                this.cbl_Role.Enabled = false;

            }
        }
        #endregion

    }
}