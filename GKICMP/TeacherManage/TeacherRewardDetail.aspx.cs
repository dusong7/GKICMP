/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      奖励管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.teachermanage
{
    public partial class TeacherRewardDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_RewardDAL teacher_RewardDAL = new Teacher_RewardDAL();

        protected int v = 0;
        public string File = "";

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string TPID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                if (TPID != "")
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
            Teacher_RewardEntity model = teacher_RewardDAL.GetObjByID(TPID);
            if (model != null)
            {
                this.ltl_TeacherName.Text = model.RealName.ToString();
                this.ltl_RewardType.Text = CommonFunction.CheckEnum<CommonEnum.RewardType>(model.RewardType.ToString());
                this.ltl_PubDate.Text = model.PubDate.ToString() == "0001/1/1 0:00:00" ? "" : model.PubDate.ToString("yyyy-MM-dd");
                this.ltl_RewardName.Text = model.RewardName.ToString();
                this.ltl_RGrade.Text = CommonFunction.CheckEnum<CommonEnum.RGrade>(model.RGrade.ToString());
                this.ltl_Ranking.Text = CommonFunction.CheckEnum<CommonEnum.Ranking>(model.Ranking.ToString());
                this.ltl_Lunit.Text = model.Lunit.ToString();
                this.Image2.ImageUrl = model.RFile;
                AccessBind();


                // File = this.ltl_PFile.Text = model.RFile.ToString();

                //if (model.RFile != "")
                //{
                //   this.imgs.ImageUrl =  "../" + model.RFile;
                //   this.imgs.Visible = true;
                //}

            }
        }
        #endregion


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }

        }
        #endregion

        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = teacher_RewardDAL.GetTable(TPID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion

        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
        }
        #endregion

    }
}