using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Text;

namespace GKICMP.projectmanage
{
    public partial class JZProjectAdd : PageBase
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
                CommonFunction.BindEnum<CommonEnum.BSources>(this.ddl_Financed, "-2"); //资金来源
                //项目类型
                DataTable dttype = sysDataDAL.GetProList((int)CommonEnum.IsorNot.否, 1, -1);
                CommonFunction.DDlTypeBind(this.ddl_ProType,dttype,"SDID","DataName","-2");

                //项目内容
                DataTable dt = sysDataDAL.GetProList((int)CommonEnum.IsorNot.否, 1, int.Parse(this.ddl_ProType.SelectedValue));
                CommonFunction.DDlTypeBind(this.ddl_ProContent, dt, "SDID", "DataName", "-2");

                if (PID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            JZProjectManageEntity model = jzProjectManage.GetObjByID(PID);
            if (model != null)
            {
                this.txt_ProName.Text = model.ProName;
                this.ddl_Financed.SelectedValue = Convert.ToString(model.Financed);
                this.txt_ProBudget.Text = Convert.ToString(model.ProBudget);
                this.ddl_ProType.SelectedValue = model.ProType.ToString();
                //项目内容
                DataTable dt = sysDataDAL.GetProList((int)CommonEnum.IsorNot.否, 1, model.ProType);
                CommonFunction.DDlTypeBind(this.ddl_ProContent, dt, "SDID", "DataName", "-2");
                this.ddl_ProContent.SelectedValue = model.ProContent;
                this.txt_ProArea.Text = model.ProArea.ToString();
                this.txt_Amount.Text = model.Amount.ToString();
               // this.txt_ProContent.Text = model.ProContent;
                this.txt_DepPerson.Text = model.DepPerson;
                this.txt_DepLinkno.Text = model.DepLinkno;
                this.txt_Amount.Text = Convert.ToString(model.Amount);
                this.txt_ProDesc.Text = model.ProDesc;
                //this.txt_ProArea.Text = Convert.ToString(model.a);

                this.hf_RFile.Value = model.PCFile;
                AccessBind();
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
                JZProjectManageEntity model = new JZProjectManageEntity();
                model.PID = PID;
                model.ProName = this.txt_ProName.Text.Trim();//项目名称
                model.ProBudget = Convert.ToDecimal(this.txt_ProBudget.Text);//预算
                model.Financed = int.Parse(this.ddl_Financed.SelectedValue);//资金来源
                model.ProArea = Convert.ToDecimal(this.txt_ProArea.Text);//建筑面积
                model.DepPerson = this.txt_DepPerson.Text;//联系人
                model.DepLinkno = this.txt_DepLinkno.Text;//联系电话
                model.Amount = Convert.ToInt32(this.txt_Amount.Text);//数量
                model.ProType = int.Parse(this.ddl_ProType.SelectedValue);//项目类型
                model.ProContent = this.ddl_ProContent.SelectedValue;//项目内容
                model.State = 1;//驳回 = 0,未审核 = 1,通过 = 2,否决=3
                model.ProDate = DateTime.Now;//创建时间
                model.CreateUser = UserID;//创建人
                model.Isdel = (int)CommonEnum.IsorNot.否;//是否删除
                model.ProDesc = this.txt_ProDesc.Text;//备注
                model.Type = 0;//代建、自建
                model.PType=(int)CommonEnum.IsorNot.否;//是否上报

                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "file");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = model.PID;
                    accessinfo.ObjID = "";
                }
                model.PCFile = accessinfo.AccessUrl;

                int result =jzProjectManage.Edit(model);
                if (result >0)
                {
                    int log = PID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PID == "" ? "增加" : "修改") + "项目为【" + this.txt_ProName.Text + "】的教装项目采购申请信息", UserID));
                    ShowMessage();
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "系统错误【" + this.txt_ProName.Text + "】", UserID));
                return;
            }
           
        }
        #endregion

        protected void ddl_ProType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = sysDataDAL.GetProList((int)CommonEnum.IsorNot.否, 1, int.Parse(this.ddl_ProType.SelectedValue));
            CommonFunction.DDlTypeBind(this.ddl_ProContent, dt, "SDID", "DataName", "-2");
        }



        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = jzProjectManage.GetTable(PID);
            rp_File.DataSource = ds;
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