using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.app
{
    public partial class EgovernmentDetail : PageBaseApp
    {
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();


        #region 参数集合
        /// <summary>
        /// BID 宿舍楼ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.pz.Visible = false;
                if (!string.IsNullOrEmpty(FID))
                {
                    IsRead();
                    BindInfo();
                }
            }
        }

        #region 是否阅读
        public void IsRead()
        {
            int result = egovernment_FlowDAL.IsReadAPP(FID, UserID);
        }
        #endregion


        #region 绑定数据
        private void BindInfo()
        {
            DataTable dt = egovernmentDAL.GetTableAPP(FID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.lbl_ETitle.Text = this.lbl_ETitle.Text = dt.Rows[0]["Etitle"].ToString();//公文标题
                this.lbl_AcceptUser.Text = dt.Rows[0]["SendUserName"].ToString(); //发件人
                this.lbl_SendDate.Text = Convert.ToDateTime(dt.Rows[0]["SendDate"].ToString()).ToString("yyyy-MM-dd");//日期
                this.lbl_EContent.Text = dt.Rows[0]["EContent"].ToString();//内容

                if (dt.Rows[0]["IsApproved"].ToString() == "1")
                {
                    BindRepeter();
                }
                else
                {
                    //this.btn_CY.Visible = false;
                }

            }
        }

        public void BindRepeter()
        {
            DataTable dt = egovernment_FlowDAL.GetFlowAPP(FID);
            this.rp_List.DataSource = dt;
            rp_List.DataBind();

        }
        #endregion

        protected void btn_Send_Click(object sender, EventArgs e)
        {
            string ids = this.hf_UID.Value.ToString();
            ids = ids.TrimEnd(',').TrimStart(',');
            Egovernment_FlowEntity model = egovernment_FlowDAL.GetObjByID(FID);
            Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
            model_flow.EID = model.EID;
            model_flow.Comment = this.hf_SelectedText.Value;//批注
            model_flow.SendUser = UserID;//发件人
            model_flow.AcceptUser = ids;//接受人
            model_flow.FOpinion = "";//处理意见
            model_flow.SendDate = DateTime.Now;//发送时间
            model_flow.FID = FID;

            model_flow.State = (int)CommonEnum.GWType.已处理;//
            int egstate = (int)CommonEnum.GWType.批转中;
            int result = egovernment_FlowDAL.EditAPP(model_flow, egstate);
            if (result > 0)
            {
                //ShowMessage("");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "批转公文：" + this.lbl_ETitle.Text + "的信息", UserID));
                RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='EgovernmentGet.aspx'</script>");
            }
            else
            {
                ShowMessage("保存失败");
                return;
            }
        }

        protected void btn_CY_Click(object sender, EventArgs e)
        {
            if (this.pz.Visible)
            {
                this.pz.Visible = false;
            }
            else
            {
                this.pz.Visible = true;
                //BandData(2); 
                // Data(2); 
                DataBindList();
            }
        }

        #region 选择收件人绑定
        private void BandData(int type)
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            if (type == 1)
                sb.Append("multiple: false,");
            else
                sb.Append("multiple: true,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");

            this.ltl_JQ.Text = sb.ToString();
        }

        //绑定部门
        private string MList()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
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
                    string a = InitChild((int)CommonEnum.UserType.老师, dt.Rows[i]["DID"].ToString());
                    if (a == "")
                    { }
                    else
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                        //调用递归方法
                        name += a;

                        name += ",state:\"closed\"},";
                    }
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }

        //绑定部门下的人员
        public string InitChild(int usertype, string parentID)
        {
            DataTable dt = new SysUserDAL().GetSysUserByDepid(usertype, int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            else
            {
                return "";
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }

        #endregion


        #region 选择收件人绑定
        public void DataBindList()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpmodule.DataSource = dt;
                this.rpmodule.DataBind();
            }
        }
        #endregion

        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
            HiddenField hf_DID = (HiddenField)e.Item.FindControl("hf_DID");
            DataTable dt = sysUserDAL.GetSysUserByDepid((int)CommonEnum.UserType.老师, Convert.ToInt32(hf_DID.Value));
            if (dt != null && dt.Rows.Count > 0)
            {
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }
    }
}