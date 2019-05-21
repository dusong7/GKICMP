/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年02月27日
** 描 述:       视频配置页面
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

namespace GKICMP.voice
{
    public partial class VoiceEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public AttendVacationDAL attendVacationDAL = new AttendVacationDAL();
        public AttendSetDAL AttendSetDAL = new AttendSetDAL();
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();

        public VideoDAL videoDAL = new VideoDAL();

        #region 参数集合
        /// <summary>
        /// Vid
        /// </summary>
        public int VID
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
                if (VID != -1)
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
            VideoEntity model = videoDAL.GetObjByID(VID);
            if (model != null)
            {
                this.txt_EquipName.Text = model.EquipName.ToString();
                this.txt_EquipIP.Text = model.EquipIP.ToString();
                this.txt_PotNum.Text = model.PotNum.ToString();
                this.txt_EquipPotNum.Text = model.EquipPotNum.ToString();
                this.txt_UserName.Text = model.UserName.ToString();
                this.txt_UserPwd.Text = model.UserPwd.ToString();

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
                VideoEntity model = new VideoEntity();
                model.VID = VID;
                model.EquipName = this.txt_EquipName.Text.ToString();
                model.EquipIP = this.txt_EquipIP.Text.ToString();
                model.PotNum = Convert.ToInt32(this.txt_PotNum.Text.ToString());
                model.EquipPotNum = Convert.ToInt32(this.txt_EquipPotNum.Text.ToString());
                model.UserName = this.txt_UserName.Text.ToString();
                model.UserPwd = this.txt_UserPwd.Text.ToString();


                int result = videoDAL.Edit(model);
                if (result == -2)
                {
                    ShowMessage("设备名称已存在，请重新输入");
                    return;
                }
                else
                {
                    ShowMessage();
                    int log = VID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (VID == -1 ? "增加" : "修改") + "视频配置信息", UserID));
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion



    }
}