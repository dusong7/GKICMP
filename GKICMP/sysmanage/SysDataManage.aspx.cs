/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年03月03日
** 描 述:       基础数据管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class SysDataManage : PageBase
    {
        SysDataDAL SysDataDAL = new SysDataDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();


        //#region 参数集合
        ///// <summary>
        ///// Flag 标示 1：资产分类 2：仓库名称 3：计量单位  4：宿舍楼类型 5：专业部
        ///// </summary>
        //public int Flag
        //{
        //    get
        //    {
        //        return GetQueryString<int>("flag", -1);
        //    }
        //}
        //#endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.DataType>(this.ddl_ddl_Type, "-2");
                //GetCondition();
                DataBindList();
            }

        }
        #endregion


        //#region 获取查询条件
        ///// <summary>
        ///// 获取查询条件
        ///// </summary>
        //public void GetCondition()
        //{
        //    ViewState["DataName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//姓名
        //}
        //#endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            SysDataEntity model = new SysDataEntity();
            model.DataType = int.Parse(this.ddl_ddl_Type.SelectedValue);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = SysDataDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            CommonFunction.BindEnum<CommonEnum.DataType>(this.ddl_ddl_Type, "-2");
            DataBindList();
        }
        #endregion


        #region 删除事件
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int delresult = SysDataDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除基础数据", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}