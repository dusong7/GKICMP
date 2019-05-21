/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年05月31日 16时18分06秒
** 描    述:      幻灯片/超链接编辑
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Configuration;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class SlideEdit : PageBase
    {
        public Web_SlideDAL slideDAL = new Web_SlideDAL();
        public Web_SlideTypeDAL slidetypeDAL = new Web_SlideTypeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// Flag 1：友情链接 2：幻灯片 3：宣传标语
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }

        /// <summary>
        /// 友情链接/幻灯片ID
        /// </summary>
        public int SliID
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
                DataTable dt = slidetypeDAL.GetList(Flag, (int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_SType, dt, "SType", "STypeName", "-2");

                if (Flag == 1)
                {
                    this.ltl_Name.Text = this.ltl_SName.Text = "友情链接";
                    this.ltl_Small.Text = "建议大小为467*320";
                }
                else if (Flag == 2)
                {
                    this.ltl_Name.Text = this.ltl_SName.Text = "幻灯片";
                    this.ltl_Small.Text = "建议大小为170*50";
                }
                else
                {
                    this.ltl_Name.Text = this.ltl_SName.Text = "宣传标语";
                    this.ltl_Small.Text = "";
                }
                if (SliID != -1)
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
            Web_SlideEntity model = slideDAL.GetObjByID(SliID);
            if (model != null)
            {
                this.ddl_SType.SelectedValue = model.SType.ToString();
                this.txt_SlideName.Text = model.SlideName.ToString();
                this.txt_SlideUrl.Text = model.SlideUrl == null ? "" : model.SlideUrl.ToString();
                this.txt_InvalidDate.Text = model.InvalidDate.ToString("yyyy-MM-dd");
                if (model.SImage != null && model.SImage.ToString() != "")
                {
                    this.img_SImage.Visible = true;
                    img_SImage.ImageUrl = this.hf_SImage.Value = model.SImage.ToString();
                }
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
                Web_SlideEntity model = new Web_SlideEntity();
                model.SliID = SliID;
                model.SType = Convert.ToInt32(this.ddl_SType.SelectedValue.ToString());
                model.SlideName = this.txt_SlideName.Text.ToString().Trim();
                model.SlideUrl = this.txt_SlideUrl.Text.ToString().Trim();
                //model.InvalidDate = Convert.ToDateTime(this.txt_InvalidDate.Text.ToString().Trim());

                if (SliID == -1)
                {
                    if (Convert.ToDateTime(this.txt_InvalidDate.Text) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        ShowMessage("失效日期不能小于当前日期，请重新选择");
                        return;
                    }
                }
                model.InvalidDate = Convert.ToDateTime(this.txt_InvalidDate.Text);
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_SImage, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_SImage.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_SImage.HasFile)
                        model.SImage = accessinfo.AccessUrl;
                    else
                        model.SImage = this.hf_SImage.Value;
                }

                int result = slideDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = SliID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SliID == -1 ? "添加" : "修改") + "名称为：【" + this.txt_SlideName.Text.ToString().Trim() + "】的" + this.ltl_Name.Text.ToString().Trim() + "信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("已存在名称和类别都相同的数据");
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