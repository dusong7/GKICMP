/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      ygb
** 创建日期:      2017年11月24日 16时05分25秒
** 描    述:      学生信息详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.studentpage
{
    public partial class StudentInfo :  PageBase
    {
        public StudentDAL studentDAL = new StudentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();


   


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SysUserEntity model1 = sysUserDAL.GetObjByID(UserID);
                StudentEntity model = studentDAL.GetObjByID(UserID);
                if (model1 != null)
                {
                    this.lbl_BirthDay.Text = model1.BirthDay.ToString("yyyy-MM");
                    this.lbl_Sex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model1.UserSex);
                    this.lbl_RealName.Text = model1.RealName;
                    this.lbl_IDCard.Text = model1.IDCard;
                    this.lbl_Nation.Text = CommonFunction.CheckEnum<CommonEnum.MZ>(model1.Nation);
                    this.lbl_Ustate.Text = model1.UStateName;
                }
                if (model != null)
                {
                    this.lbl_CardNum.Text = model.CardNum;
                    this.lbl_Cellphone.Text = model.CellPhone;
                    this.lbl_Claid.Text = model.ClaIDName;
                    this.lbl_EntranceDate.Text = model.EnterDate.ToString("yyyy-MM-dd");
                    this.lbl_GEnrollment.Text = model.GEnrollment;
                    this.lbl_Guardian.Text = model.Guardian;
                    this.lbl_IsField.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsField);
                    this.lbl_IsLeftBehind.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsLeftBehind);
                    this.lbl_IsOnly.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsOnly);
                    this.lbl_LoinDate.Text = model.LoinDate.ToString("yyyy-MM-dd");
                    this.lbl_PEnrollment.Text = model.PEnrollment;
                    this.lbl_PlaceOrigion.Text = model.PlaceOrigin;
                    this.lbl_Politics.Text = CommonFunction.CheckEnum<CommonEnum.ZZMM>(model.Politics);
                    this.lbl_RegisteredPlace.Text = model.RegisteredPlace;
                    this.lbl_RegistType.Text = CommonFunction.CheckEnum<CommonEnum.HKLX>(model.RegistType);
                    this.lbl_UsedName.Text = model.UsedName;
                    this.lbl_GuardNum.Text = model.GuardNum;
                    if (model.Photos != "")
                    {
                        this.img_Photo.ImageUrl = model.Photos;
                        this.img_Photo.Visible = true;
                    }
                    this.lbl_IsFlow.Text = model.IsFlowName;
             
                }
            }
        }
        #endregion
    }
}