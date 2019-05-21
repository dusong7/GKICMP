/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年11月11日
** 描 述:       校区编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.sysmanage
{
    public partial class CampusEdit : PageBase
    {
        public SysUser_TypeDAL sysUserTypeDAL = new SysUser_TypeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                DataTable dt = sysUserTypeDAL.GetList(Convert.ToInt32(CommonEnum.HumanType.校区负责人));
                CommonFunction.DDlTypeBind(this.ddl_DutyUser, dt, "UID", "RealName", "-2");

                //DataTable dt = sysUser_TypeDAL.GetList((int)CommonEnum.HumanType.资产盘点负责人);
                //CommonFunction.DDlTypeBind(this.ddl_FZR, dt, "UID", "RealName", "-2");
                if (CID != -1)
                {
                    this.span1.Visible = false;
                    BindInfo();
                }
            }
        }
        #endregion

        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void BindInfo()
        {
            CampusEntity model = campusDAL.GetObjByID(CID);
            if (model != null)
            {
                this.txt_CampusName.Text = model.CampusName;
                this.txt_ButtonCode.Text = model.ButtonCode;
                this.txt_LinkNum.Text = model.LinkNum;
                this.ddl_DutyUser.SelectedValue = model.DutyUser;
                this.txt_AreaSize.Text = model.AreaSize.ToString();
                this.txt_BuiltupAea.Text = model.BuiltupAea.ToString();
                this.txt_EquipmentValue.Text = model.EquipmentValue.ToString();
                this.txt_FixedAssets.Text = model.FixedAssets.ToString();
                this.txt_BeginDate.Visible = false;
                this.ltl_BeginDate.Visible = true;
                this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
            }
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
                CampusEntity model = new CampusEntity();
                model.CID = CID;
                model.CampusName = this.txt_CampusName.Text.Trim();
                model.ButtonCode = this.txt_ButtonCode.Text.Trim();
                model.LinkNum = this.txt_LinkNum.Text.Trim();
                model.DutyUser = this.ddl_DutyUser.SelectedValue;
                if (IsChange(this.txt_AreaSize.Text.Trim()) == false)
                {
                    ShowMessage("请输入正确的校区面积，注（保留2位有效小数）");
                    return;
                }
                model.AreaSize = Convert.ToDecimal(this.txt_AreaSize.Text.Trim());
                if (IsChange(this.txt_BuiltupAea.Text.Trim()) == false)
                {
                    ShowMessage("请输入正确的校区建筑面积，注（保留2位有效小数）");
                    return;
                }
                model.BuiltupAea = Convert.ToDecimal(this.txt_BuiltupAea.Text.Trim());
                if (IsChange(this.txt_EquipmentValue.Text.Trim()) == false)
                {
                    ShowMessage("请输入正确的校区教学科研设备总值，注（保留2位有效小数）");
                    return;
                }
                model.EquipmentValue = Convert.ToDecimal(this.txt_EquipmentValue.Text.Trim());
                if (IsChange(this.txt_FixedAssets.Text.Trim()) == false)
                {
                    ShowMessage("请输入正确的校区固定资产备总值，注（保留2位有效小数）");
                    return;
                }
                model.FixedAssets = Convert.ToDecimal(this.txt_FixedAssets.Text.Trim());
                if (CID == -1)
                {
                    model.BeginDate = Convert.ToDateTime(this.txt_BeginDate.Text.Trim());
                    //if (model.BeginDate < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
                    //{
                    //    ShowMessage("正式使用日期不能小于当前日期");
                    //    return;
                    //}
                }
                else
                {
                    model.BeginDate = Convert.ToDateTime(this.ltl_BeginDate.Text.Trim());
                }
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                int result = campusDAL.Edit(model);
                if (result == 0)
                {
                    int log = CID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (CID == -1 ? "添加" : "修改") + "校区名称为【" + this.txt_CampusName.Text + "】的校区信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("校区名称已存在，请重新输入");
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }

        }
        #endregion


        #region 判断是否为decimal类型
        /// <summary>
        /// 判断是否为decimal类型
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public bool IsChange(string Str)
        {
            bool ret;
            int myNumber;
            decimal number;
            try
            {
                myNumber = Convert.ToInt32(Str);
                if (myNumber <= 0)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
            }
            catch
            {
                try
                {
                    number = Convert.ToDecimal(Str);
                    if (number.ToString().Split('.')[1].Length > 2)
                    {
                        ret = false;
                    }
                    else
                    {
                        ret = true;

                    }
                }
                catch
                {
                    ret = false;
                }

            }
            return ret;
        }
        #endregion

    }
}