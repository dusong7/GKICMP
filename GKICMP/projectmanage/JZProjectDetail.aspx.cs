using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


namespace GKICMP.projectmanage
{
    public partial class JZProjectDetail : PageBase
    {
        #region 参数集合
        /// <summary>
        /// PID
        /// </summary>
        public string PID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public JZProjectManageDAL jzProjectManage = new JZProjectManageDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PID != "")
            {
                InfoBind();
            }
        }
        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            JZProjectManageEntity model = jzProjectManage.GetObjByID(PID);
            if (model != null)
            {
                this.ltl_ProName.Text = model.ProName;
                this.ltl_Financed.Text =CommonFunction.CheckEnum<CommonEnum.BSources>( model.Financed);
                this.ltl_ProBudget.Text = Convert.ToString(model.ProBudget);
                this.ltl_ProType.Text = model.ProTypeName.ToString();//项目类型
                this.ltl_ProContent.Text = model.ProContentName;//项目内容
                this.ltl_ProArea.Text = model.ProArea.ToString();
                this.ltl_Amount.Text = model.Amount.ToString();
                // this.ltl_ProContent.Text = model.ProContent;
                this.ltl_DepPerson.Text = model.DepPerson;
                this.ltl_DepLinkno.Text = model.DepLinkno;
                this.ltl_Amount.Text = Convert.ToString(model.Amount);
                this.ltl_ProDesc.Text = model.ProDesc;

                //this.ltl_ProArea.Text = Convert.ToString(model.a);
                if (model.State == 0)
                {
                    this.ltl_State.Text = "驳回";  //驳回 = 0, 未审核 = 1,通过 = 2, 否决=3 
                }
                else if (model.State == 1)
                {
                    this.ltl_State.Text = "未审核"; 
                }
                else if (model.State == 2)
                {
                    this.ltl_State.Text = "通过";
                }
                else 
                {
                    this.ltl_State.Text = "否决";
                }

                this.ltl_StateDesc.Text = model.ProDesc;

                AccessBind();//附件绑定
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
            DataTable jt = jzProjectManage.GetTable(PID);
            rp_File.DataSource = jt;
            rp_File.DataBind();
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

        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileName(obj);
        }
        #endregion

    }
}