/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月27日
** 描 述:       用户管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.freshmen
{
    public partial class StudentRegManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public CampusDAL campusDAL = new CampusDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CommonFunction.BindEnum<CommonEnum.UserType>(this.ddl_UserType, "-2");//用户类别
                //ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_UserName.Text.Trim());//用户名
                
                DataTable ds = campusDAL.GetList((int)CommonEnum.Deleted.未删除);//所属校区
                CommonFunction.DDlTypeBind(this.ddl_CID, ds, "CID", "CampusName", "-2");

                ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());//姓名
                ViewState["IDCard"] = this.txt_IDCard.Text;
                ViewState["CID"] = this.ddl_CID.SelectedValue.ToString();

                DataBindList();
            }
        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            StudentEntity model = new StudentEntity();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.IDCard = ViewState["IDCard"].ToString();
            model.RealName = ViewState["RealName"].ToString();
            model.CID = Convert.ToInt32(ViewState["CID"].ToString());
           // model.UserType = 3;//3为新生入学
            DataTable dt = studentDAL.GetStuRegPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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

        #region 查询事件
        /// <summary>
        /// 点击查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());//姓名
            ViewState["IDCard"] = this.txt_IDCard.Text;
            ViewState["CID"] = this.ddl_CID.SelectedValue.ToString();
            Pager.CurrentPageIndex = 1;
            DataBindList();
        }
        #endregion

        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion

        

        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                string[] rid = ids.Split(',');
                string content = "";
                for (int i = 0; i < rid.Length; i++)
                {
                    SysUserEntity sysUser = sysUserDAL.GetObjByID(rid[i].ToString());
                    if (sysUser.UserName == "admin")
                    {
                        ShowMessage("删除失败！管理员账号不能删除！");
                        this.hf_CheckIDS.Value = "";
                        return;
                    }
                    if (i == rid.Length - 1)
                    {
                        content += sysUser.UserName;
                    }
                    else
                    {
                        content += sysUser.UserName + "、";
                    }
                }
                //int delresult = sysUserDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                int delresult = sysUserDAL.DeleteStuBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除【" + content + "】的用户信息", UserID));
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
                return;
            }
        }
        #endregion

        

        

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>window.open('SysUserEdit.aspx?ID=', '_self')</script>");
        }

        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string uid = lbtn.CommandArgument;
            Response.Write("<script language=javascript>window.open('SysUserEdit.aspx?ID=" + uid + "', '_self')</script>");
        }
    }
}