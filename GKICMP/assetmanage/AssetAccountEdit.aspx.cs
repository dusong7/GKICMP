/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月11日 10:00
** 描 述:       资产盘点编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.assetmanage
{
    public partial class AssetAccountEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_AccountDAL accountDAL = new Asset_AccountDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public Asset_Account_InfoDAL infoDAL = new Asset_Account_InfoDAL();
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();

        #region 参数集合
        public string AAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// 1：全部盘点 2：部门盘点
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_AAID.Value = Guid.NewGuid().ToString();
                DataTable dt = sysUser_TypeDAL.GetList((int)CommonEnum.HumanType.资产盘点负责人);
                CommonFunction.DDlTypeBind(this.ddl_FZR, dt, "UID", "RealName", "-2");

                if (Flag == 1)
                {
                    this.tr_Dep.Visible = false;
                }
                else
                {
                    this.tr_Dep.Visible = true;
                }

                DataTable dtDep = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_DepID, dtDep, "DID", "DepName", "-2");

                //  BandData();
                if (AAID != "")
                {
                    BindInfo();
                    DataBindList();
                }
            }
        }
        #endregion


        #region 前台js绑定数据
        /// <summary>
        /// 前台js绑定数据
        /// </summary>
        private void BandData()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_Content.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定部门信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.Deleted.未删除);
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                    //调用递归方法
                    name += InitChild(dt.Rows[i]["DID"].ToString());
                    name += "},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }

        /// <summary>
        /// 绑定部门人员信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
                //
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            Asset_AccountEntity model = accountDAL.GetObjByID(AAID);
            if (model != null)
            {
                this.hf_AAID.Value = model.AAID;
                this.txt_AccBegin.Text = model.AccBegin.ToString("yyyy-MM-dd");
                this.txt_AccDesc.Text = model.AccDesc;
                this.txt_AccEnd.Text = model.AccEnd.ToString("yyyy-MM-dd");
                this.txt_AccGroup.Text = model.AccGroup;
                //this.hf_TID.Value = model.AccDuty;
                this.ddl_FZR.SelectedValue = model.AccDuty;
                if (model.AAFlag == 2)
                {
                    this.tr_Dep.Visible = true;
                }
                this.ddl_DepID.SelectedValue = model.DepID.ToString();
                //StringBuilder sb1 = new StringBuilder();
                //sb1.Append("<script type='text/javascript'>");
                //sb1.Append("$(function () {$('#Series').combotree('setValues',['");
                //sb1.Append(this.hf_TID.Value.Trim(','));
                //sb1.Append("']);})</script>");
                //this.ltl_xz.Text = sb1.ToString();
            }
        }
        #endregion


        #region 删除
        public void imbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton imbtn = (ImageButton)sender;
                int aaiid = Convert.ToInt32(imbtn.CommandArgument.ToString());
                int result = infoDAL.DeleteByID(aaiid);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资产详细信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('删除成功');</script>");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 资产详细数据获取
        public void DataBindList()
        {
            DataTable dt1 = infoDAL.GetPaged(this.hf_AAID.Value, (int)CommonEnum.AIType.有账无物);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                this.tr_null1.Visible = false;
            }
            else
            {
                this.tr_null1.Visible = true;
            }
            rp_List1.DataSource = dt1;
            rp_List1.DataBind();
            DataTable dt2 = infoDAL.GetPaged(this.hf_AAID.Value, (int)CommonEnum.AIType.有物无账);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                this.tr_null2.Visible = false;
            }
            else
            {
                this.tr_null2.Visible = true;
            }
            rp_List2.DataSource = dt2;
            rp_List2.DataBind();
        }
        #endregion


        #region 数据绑定
        public void imgbtn_inquiry_Click(object sender, EventArgs e)
        {
            DataBindList();
            //this.Series.Value = this.hf_TIDName.Value;
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, System.EventArgs e)
        {
            try
            {
                Asset_AccountEntity model = new Asset_AccountEntity();
                int isadd = AAID == "" ? 0 : 1;
                model.AAID = this.hf_AAID.Value;
                model.AccBegin = Convert.ToDateTime(this.txt_AccBegin.Text);
                model.AccDesc = this.txt_AccDesc.Text.Trim();
                model.AccDuty = this.ddl_FZR.SelectedValue;
                model.AccEnd = Convert.ToDateTime(this.txt_AccEnd.Text);
                model.AccGroup = this.txt_AccGroup.Text.Trim();
                model.CreaterUser = UserID;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                if (model.AccBegin > model.AccEnd)
                {
                    ShowMessage("盘点开始日期不能大于盘点结束日期");
                    return;
                }
                if (Flag == 1)
                {
                    model.DepID = -2;
                }
                else
                {
                    model.DepID = Convert.ToInt32(this.ddl_DepID.SelectedValue.ToString());
                }
                model.AAFlag = Flag;
                int result = accountDAL.Edit(model, isadd);
                if (result == 0)
                {
                    int log = AAID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, AAID == "" ? "添加" : "修改" + "资产盘点信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 盘点类型选值变化事件
        protected void rdo_AAFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdo_AAFlag.SelectedValue == "1")
            {
                this.tr_Dep.Visible = false;
            }
            else
            {
                this.tr_Dep.Visible = true;
            }
        }
        #endregion
    }
}