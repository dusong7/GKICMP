/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年9月9日 8时53分53秒
** 描    述:      作息时间编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.speech
{
    public partial class TimeTableEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public RestTimeDAL restTimeDAL = new RestTimeDAL();
        public MusicLibDAL musicLibDAL = new MusicLibDAL();

        #region 参数集合
        ///// <summary>
        ///// 适用星期
        ///// </summary>
        //public string Weeks
        //{
        //    get
        //    {
        //        return GetQueryString<string>("week", "");
        //    }
        //}

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date
        {
            get
            {
                return GetQueryString<DateTime>("date", Convert.ToDateTime("9999-12-31 00:00"));
            }
        }

        /// <summary>
        /// 作息ID
        /// </summary>
        public int RTID
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
            if (!IsPostBack)
            {
                DataTable dt = musicLibDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_BMID, dt, "MID", "Name", "-2");
                CommonFunction.DDlTypeBind(this.ddl_EMID, dt, "MID", "Name", "-2");
                CommonFunction.DDlTypeBind(this.ddl_RMID, dt, "MID", "Name", "-2");
                this.txt_BeginTime.Text = Date.ToString("HH:mm");
                if (RTID != -1)
                {
                    InfoBind();
                    this.btn_Delete.Visible = true;
                }
                else
                {
                    this.btn_Delete.Visible = false;
                }
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind()
        {
            DataTable model = restTimeDAL.GetObj(RTID);
            if (model != null && model.Rows.Count > 0)
            {
                this.txt_RestName.Text = model.Rows[0]["RestName"].ToString();
                this.txt_BeginTime.Text = Convert.ToDateTime(model.Rows[0]["BeginTime"].ToString()).ToString("HH:mm");
                this.txt_EndTime.Text = Convert.ToDateTime(model.Rows[0]["EndTime"].ToString()).ToString("HH:mm");
                this.ddl_BMID.SelectedValue = model.Rows[0]["BMID"].ToString();
                this.ddl_EMID.SelectedValue = model.Rows[0]["EMID"].ToString();
                this.ddl_RMID.SelectedValue = model.Rows[0]["RMID"].ToString();
                this.rdo_IsGetSet.SelectedValue = model.Rows[0]["IsGetSet"].ToString();
                this.rdo_IsUse.SelectedValue = model.Rows[0]["IsUse"].ToString();
                this.ck_Weeks.Enabled = false;
                foreach (ListItem li in this.ck_Weeks.Items)
                {
                    if (model.Rows[0]["Weeks"].ToString() == li.Value)
                    {
                        li.Selected = true;
                    }
                }
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
                RestTimeEntity model = new RestTimeEntity();
                model.RTID = RTID;
                model.RestName = this.txt_RestName.Text.ToString().Trim();
                model.BeginTime = Convert.ToDateTime(this.txt_BeginTime.Text.ToString());
                model.EndTime = Convert.ToDateTime(this.txt_EndTime.Text.ToString());
                model.BMID = Convert.ToInt32(this.ddl_BMID.SelectedValue.ToString());
                model.EMID = Convert.ToInt32(this.ddl_EMID.SelectedValue.ToString());
                model.RMID = Convert.ToInt32(this.ddl_RMID.SelectedValue.ToString());
                model.IsUse = Convert.ToInt32(this.rdo_IsUse.SelectedValue.ToString());
                model.IsRecording = -2;
                model.IsGetSet = Convert.ToInt32(this.rdo_IsGetSet.SelectedValue.ToString());
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                //string weeks = "";
                int resultvalue = -2;
                int result = 0;
                int count = 0;
                for (int i = 0; i < this.ck_Weeks.Items.Count; i++)
                {
                    //if (ck_Weeks.Items[i].Selected == true)
                    //{
                    //    weeks += ck_Weeks.Items[i].Value.ToString() + ",";
                    //}
                    if (this.ck_Weeks.Items[i].Selected)
                    {
                        model.Weeks = ck_Weeks.Items[i].Value.ToString();
                        count = count + 1;
                    }
                    else
                    {
                        continue;
                    }
                    result = restTimeDAL.Edit(model);
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
                if (count <= 0)
                {
                    ShowMessage("请选择适用星期");
                    return;
                }
                //model.Weeks = weeks.TrimEnd(',').TrimStart(',');
                //int result = restTimeDAL.Edit(model);
                if (resultvalue == 0)
                {
                    int log = RTID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (RTID == -1 ? "添加" : "修改") + "名称为【" + this.txt_RestName.Text.ToString().Trim() + "】的作息时间信息", UserID));
                    //ClientScript.RegisterStartupScript(GetType(),"key", "<script>alert('提交成功');window.location.href='TableTime.html';</script>",true);
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 判断是否有预备铃
        /// <summary>
        /// 判断是否有预备铃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdo_IsGetSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdo_IsGetSet.SelectedValue.ToString() == "1")
            {
                this.ddl_RMID.Enabled = true;
            }
            else
            {
                this.ddl_RMID.Enabled = false;
            }
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
            try
            {
                int result = restTimeDAL.DeleteBat(RTID.ToString(), (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除名称为【" + this.txt_RestName.Text.ToString().Trim() + "】的作息时间信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('删除成功');winclose();</script>");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}