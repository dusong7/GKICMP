/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年03月21日 10点15分
** 描   述:      班级空间图片上传
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Transactions;
using System.Configuration;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.spacemanage
{
    public partial class ClassPhotoUpload : PageBase
    {
        public SpacePhotosDAL photoDAL = new SpacePhotosDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// ClaID 班级ID
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("claid", -1);
            }
        }

        /// <summary>
        /// 标示 1:班级空间  2：个人空间
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
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    SpacePhotosEntity model = new SpacePhotosEntity();
                    model.TID = -1;
                    model.PhotoName = this.txt_StuID.Text.ToString().Trim();
                    model.PhotoDesc = this.txt_SCReason.Text.ToString().Trim();
                    model.CreateUser = UserID;
                    model.ClassID = ClaID;
                    model.PFlag = Flag;
                    string photourl = "";

                    if (fl_SImage.HasFile)
                    {
                        int upsize = 4000000;
                        try
                        {
                            upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                        }
                        catch (Exception) { }
                        int filecount = Convert.ToInt32(hf_SImage.Value.Trim());
                        AccessoryEntity accessinfo = CommonFunction.upfile(0, filecount, hf_SImage, "spaceimg");
                        if (accessinfo.AccessID == "-2")
                        {
                            //刚才上传的文件删除
                            CommonFunction.delfile(hf_SImage.Value.ToString());
                            ShowMessage(accessinfo.AccessName);
                            return;
                        }
                        else
                        {
                            photourl = accessinfo.AccessUrl.TrimEnd(',').TrimStart(',');
                        }
                    }
                    else
                    {
                        ShowMessage("请选择要上传的图片");
                        return;
                    }

                    string[] type = photourl.Split(',');
                    int result = 0;
                    int resultvalue = 0;
                    for (int i = 0; i < type.Length; i++)
                    {
                        model.PhotoUrl = type[i].ToString();
                        result = photoDAL.Edit(model);
                        if (result > 0)
                        {
                            resultvalue = 0;
                        }
                        else
                        {
                            resultvalue = -1;
                            break;
                        }
                    }

                    //int result = photoDAL.Edit(model);
                    if (resultvalue == 0)
                    {
                        ShowMessage();
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "上传" + (Flag == 1 ? "班级" : "个人") + "空间照片", UserID));
                        ts.Complete();
                    }
                    else
                    {
                        ShowMessage("上传失败");
                        ts.Dispose();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                    ts.Dispose();
                    return;
                }
            }
        }
        #endregion
    }
}