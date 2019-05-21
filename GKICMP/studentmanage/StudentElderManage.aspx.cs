
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

namespace GKICMP.studentmanage
{
    public partial class StudentElderManage : PageBase
    {
        public StuElderDAL stuElderDAL = new StuElderDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        #region 参数集合
        public string StuID
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
                if (StuID != "")
                {
                    this.hf_TID.Value = StuID;
                    BindInfo();
                }
            }
        }
        #region 初始化用户数据
        public void BindInfo()
        {
            int result=0;
            StuElderEntity model = new StuElderEntity();
            model.StuID = StuID;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = stuElderDAL.GetPaged(100, 1, ref result, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            //Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                string[] rid = ids.Split(',');
                int delresult = stuElderDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除学生家庭成员信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                BindInfo();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
    }
}