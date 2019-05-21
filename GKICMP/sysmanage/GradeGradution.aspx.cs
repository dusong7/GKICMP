using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;

namespace GKICMP.sysmanage
{
    public partial class GradeGradution : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL UserDal = new SysUserDAL();
        public DepartmentDAL departmentDal = new DepartmentDAL();
        public SysUserDAL sysUserDal = new SysUserDAL();
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        #region 参数集合
        public int GID
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

        }
        #endregion

        #region 提交
        /// <summary>
        ///   提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                GradeEntity model = new GradeEntity();

                model.GID = 0;
                if (GID != -1)
                {
                    model.GID = Convert.ToInt32(GID);
                    model = gradeDAL.GetObjByID(GID);
                }

                model.IsGraduate = 1;//是否毕业

                model.CreateDate = DateTime.Now;//创建日期
                model.Notes = this.txt_Notes.Text.Trim();//备注
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_GraduatePhoto, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_GraduatePhoto.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_GraduatePhoto.HasFile)
                        model.GraduatePhoto = accessinfo.AccessUrl;
                    else
                        model.GraduatePhoto = this.hf_GraduatePhoto.Value;
                }
                int result = gradeDAL.Edit(model,0);

                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该年级名称已存在，请重新输入");
                    return;
                }
                else
                {
                    if (GID != -1)
                    {
                        SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加【" + model.GradeName.ToString() + "】的毕业信息", UserID);
                        sysLogDAL.Edit(log);
                    }

                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
            }
        }
        #endregion
    }
}