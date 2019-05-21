/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2016年12月28日 15:45
** 描 述:       教室管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace ICMP.assetmanage
{
    public partial class ClassRoomManage : PageBase
    {
        public ClassRoomDAL classDAL = new ClassRoomDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public FloorDAL floorDAL = new FloorDAL();

        #region 参数集合
        /// <summary>
        /// 楼层ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// Depth
        /// </summary>
        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
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
                if (Flag == 1)
                {
                    this.ltl_SName.Text = this.ltl_BName.Text = "教室";
                }
                else if (Flag == 2)
                {
                    this.ltl_SName.Text = this.ltl_BName.Text = "会议室";
                }
                else
                {
                    this.ltl_SName.Text = this.ltl_BName.Text = "场室";
                }
                if (FID == "" || Deep != 2)
                {
                    this.operation.Visible = false;
                }
                this.hf_Flag.Value = Flag.ToString();
                this.hf_FID.Value = FID;
                CommonFunction.BindEnum<CommonEnum.DorState>(this.ddl_IsUseable, "-2");
                FloorEntity model = floorDAL.GetObj(FID);
                if (model != null)
                {
                    this.lbl_RoomName.Text = model.FloorName;
                }
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["RoomName"] = CommonFunction.GetCommoneString(this.txt_RoomName.Text.ToString().Trim());
            ViewState["IsUseable"] = this.ddl_IsUseable.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            //ClassRoomEntity model = new ClassRoomEntity((string)ViewState["RoomName"], Convert.ToInt32(ViewState["IsUseable"].ToString()), (int)CommonEnum.Deleted.未删除,FID);
            ClassRoomEntity model = new ClassRoomEntity((string)ViewState["RoomName"], Convert.ToInt32(ViewState["IsUseable"].ToString()), (int)CommonEnum.Deleted.未删除);
            model.FID = FID;
            model.RFlag = Flag;
            DataTable dt = classDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = classDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教室信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion
    }
}