/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
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

namespace GKICMP.computermanage
{
    public partial class ComputerEdit : PageBase
    {
        #region 参数集合
        /// <summary>
        /// SDID 基础数据主键
        /// </summary>
        public string  GUID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        public ComputersDAL computersDAL = new ComputersDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ClassRoomDAL classRoomDAL = new ClassRoomDAL();
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
                DepartBind();
                //CommonFunction.BindEnum<CommonEnum.DataType>(this.ddl_Type, "-2");
                if (GUID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion
        public void DepartBind()
        {
            //教室绑定
            DataTable dtcr = classRoomDAL.GetTable((int)CommonEnum.IsorNot.否, (int)CommonEnum.IsorNot.是, -2);
            CommonFunction.DDlTypeBind(this.ddl_CRID, dtcr, "CRID", "RName", "-999");
            //DataTable dt = departmentDAL.GetList((int)CommonEnum.IsorNot.否,(int)CommonEnum.DepType.普通班级);
            //CommonFunction.DDlTypeBind(this.ddl_CRID,dt,"DID","OtherName","-2");
        }

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            ComputersEntity model = computersDAL.GetObjByID(GUID);
            if (model != null)
            {
                this.txt_ComputerName.Text = model.ComputerName ;
                this.txt_LanIP.Text = model.LanIP;
                this.txt_Mac.Text = model.Mac;
                this.ddl_CRID.SelectedValue = model.CRID;
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
                ComputersEntity model = new ComputersEntity();
                model.Guid = GUID;
                model.ComputerName = this.txt_ComputerName.Text;
                model.LanIP = this.txt_LanIP.Text.Trim();
                model.Mac = this.txt_Mac.Text;
                model.CRID = this.ddl_CRID.SelectedValue;
                model.CreateDate = DateTime.Now;
                model.CFlag = 1;//1班班通，2多媒体教室
                int result = computersDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该名称已存在，请重新输入");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("该场室已添加，请重新选择");
                    return;
                }
                else
                {
                    if (GUID =="")
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加设备名称为【" + this.txt_ComputerName.Text + "】信息", UserID));
                    else
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改设备名称为【" + this.txt_ComputerName.Text + "】信息", UserID));
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