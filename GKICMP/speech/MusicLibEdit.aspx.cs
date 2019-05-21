/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年9月6日 15：28
** 描 述:       音乐库编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.speech
{
    public partial class MusicLibEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public MusicLibDAL musicLibDAL = new MusicLibDAL();
        public string Name = "";
        public string Url = "";

        #region 参数集合
        /// <summary>
        /// 音乐ID
        /// </summary>
        public int MID
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
            if (MID != -1)
            {
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            MusicLibEntity model = musicLibDAL.GetObjByID(MID);
            Name = this.txt_Name.Text = model.Name.ToString();
            Url = this.hf_imageurl.Value = model.Src.ToString();
            this.hf_Size.Value = model.Size.ToString();
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
                MusicLibEntity model = new MusicLibEntity();
                model.MID = MID;
                model.Name = this.txt_Name.Text.ToString().Trim();
                model.CreateUser = UserID;

                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "MusicLib");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_UpFile.HasFile)
                    {
                        model.Src = accessinfo.AccessUrl;
                        model.Size = this.fl_UpFile.PostedFile.ContentLength;
                    }
                    else
                    {
                        model.Src = this.hf_imageurl.Value;
                        model.Size = Convert.ToInt32(this.hf_Size.Value);
                    }
                }
                int result = musicLibDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = MID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (MID == -1 ? "添加" : "修改") + "名称为【" + this.txt_Name.Text.ToString().Trim() + "】的音乐信息", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}