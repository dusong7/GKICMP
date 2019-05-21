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

namespace GKICMP.freshmen
{
    public partial class StudentRegDetail : PageBase
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();

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
                    InfoBind();
                }
            }
        }

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            //SysUserEntity model = sysUserDAL.GetObjByID(UID);
            SysUserEntity model = sysUserDAL.GetStuByID(UID);
           
            if (model != null)
            {
                this.ltl_CampusName.Text = model.CampusName.ToString();

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
              //  this.ltl_CompanyNum.Text = model.CompanyNum;//公司座机
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
                //this.ltl_UserSex.Text = Convert.ToString(model.UserSex.ToString());//性别
                this.ltl_UserSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.UserSex.ToString());
               // this.ltl_UserType.Text = CommonFunction.CheckEnum<CommonEnum.UserType>(model.UserType.ToString());//类型
                this.ltl_RealName.Text = model.RealName;//姓名 
                this.ltl_UserNation.Text = CommonFunction.CheckEnum<CommonEnum.MZ>(model.Nation.ToString());//民族
                //this.ltl_UState.Text = CommonFunction.CheckEnum<CommonEnum.State>(model.UState.ToString());//状态
                this.ltl_UserDesc.Text = model.UserDesc;//描述
                this.ltl_Mark.Text = model.Mark.ToString();
                //this.ltl_CardNum.Text = model.CardNum;//一卡通
                //this.txt_DepName.Text = model.DepName;
                this.ltl_HighEducation.Text = CommonFunction.CheckEnum<CommonEnum.XL>(model.HighEducation.ToString());
                this.ltl_LevelCommunication.Text = CommonFunction.CheckEnum<CommonEnum.JL>(model.LevelCommunication.ToString());
            }
        }
        #endregion
    }
}