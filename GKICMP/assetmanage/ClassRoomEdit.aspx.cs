/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2016年12月28日 16时34分38秒
** 描    述:      教室基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace ICMP.assetmanage
{
    public partial class ClassRoomEdit : PageBase
    {
        public ClassRoomDAL classDAL = new ClassRoomDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUser_TypeDAL sTypeDAL = new SysUser_TypeDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();

        #region 参数集合
        public int CRID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        /// <summary>
        /// 楼层ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("fid", "");
            }
        }

        /// <summary>
        /// 1:教室 2:会议室 3:场室
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
                DDLBind();
                if (Flag == 1)
                {
                    this.ltl_Name.Text = this.ltl_BName.Text = "教室";
                    this.tr_Ctype.Visible = false;
                    DataTable dt = departmentDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DepType.普通班级);
                    CommonFunction.DDlTypeBind(this.ddl_DepID, dt, "DID", "OtherName", "-2");
                }
                else if (Flag == 2)
                {
                    this.tr_DID.Visible = false;
                    this.ltl_Name.Text = this.ltl_BName.Text = "会议室";
                    this.tr_Ctype.Visible = false;
                }
                else
                {
                    this.tr_DID.Visible = false;
                    this.ltl_Name.Text = this.ltl_BName.Text = "场室";
                    this.tr_Ctype.Visible = true;
                }
                this.hf_FID.Value = FID.ToString();
                //CommonFunction.BindEnum<CommonEnum.DorState>(this.ddl_IsUseable, "-2");
                if (CRID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 绑定下拉框数据
        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void DDLBind()
        {
            DataTable dt = null;
            if(Flag==2)
            {
                dt = sTypeDAL.GetList((int)CommonEnum.HumanType.会议室管理员);
            }
            else
            {
                dt = sTypeDAL.GetList((int)CommonEnum.HumanType.场室管理员);
            }
            CommonFunction.DDlTypeBind(this.ddl_IsCome, dt, "UID", "RealName", "-2");

            DataTable dtType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.场地类型);
            CommonFunction.DDlTypeBind(this.ddl_CType, dtType, "SDID", "DataName", "-2");
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            ClassRoomEntity model = classDAL.GetObjByID(CRID);
            if (model != null)
            {
                this.txt_RoomName.Text = model.RoomName.ToString();
                this.txt_RoomDesc.Text = model.RoomDesc == null ? "" : model.RoomDesc.ToString();
                //this.ddl_IsUseable.SelectedValue = Convert.ToString(model.IsUseable);
                //this.hf_FID.Value = model.FID;
                if (model.IsUseable == 1)
                    this.cb_IsUseable.Checked = true;
                this.hf_FID.Value = Convert.ToString(model.FID);
                this.ddl_CType.SelectedValue = model.CType.ToString();
                this.ddl_IsCome.SelectedValue = model.IsCome.ToString();
                this.ddl_DepID.SelectedValue = model.DID.ToString();
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
                ClassRoomEntity model = new ClassRoomEntity();
                model.CRID = CRID;
                model.FID = this.hf_FID.Value.ToString();
                model.RoomName = this.txt_RoomName.Text.ToString().Trim();
                model.RoomDesc = this.txt_RoomDesc.Text.ToString().Trim();
                model.IsUseable = this.cb_IsUseable.Checked == true ? 1 : 0;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.RFlag = Flag;
                model.IsCome = this.ddl_IsCome.SelectedValue.ToString();
                model.CType = Flag == 3 ? Convert.ToInt32(this.ddl_CType.SelectedValue.ToString()) : 0;
                if (Flag == 1)
                    model.DID = int.Parse(this.ddl_DepID.SelectedValue);
                else
                    model.DID = -2;
                int result = classDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = CRID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (CRID == -1 ? "添加" : "修改") + "教室名称为：" + this.txt_RoomName.Text.ToString() + "的教室信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("系统中已存在该教室名称的数据，请重新输入");
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
                return;
            }
        }
        #endregion
    }
}