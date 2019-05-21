﻿/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年05月17日 09点30分
** 描   述:      视频配置
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.voice
{
    public partial class VoiceManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_PaperDAL teacher_PaperDAL = new Teacher_PaperDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();

        public VideoDAL videoDAL = new VideoDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlWhwere();
                DataBindList();
            }
        }

        public void SqlWhwere()
        {
            ViewState["EquipName"] = CommonFunction.GetCommoneString(this.txt_EquipName.Text.ToString().Trim());
            ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_UserName.Text.ToString().Trim());
        }

        #region 数据绑定

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {

            int recordCount = -1;
            VideoEntity model = new VideoEntity();
            model.EquipName = (string)ViewState["EquipName"];
            model.UserName = (string)ViewState["UserName"];
            DataTable dt = videoDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            SqlWhwere();
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
            string ids = this.hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = videoDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除视频配置信息", UserID));
                    ShowMessage("删除成功");
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
                return;
            }
        }
        #endregion

        


    }
}