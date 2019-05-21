/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月15日 09时29分01秒
** 描    述:      会议编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Linq;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.meeting
{
    public partial class MeetingEdit : PageBase
    {
        public MeetingDAL mDAL = new MeetingDAL();
        public ClassRoomDAL croomDAL = new ClassRoomDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();


        #region 参数集合
        /// <summary>
        /// 会议ID
        /// </summary>
        public string MID
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
                DataTable dt = croomDAL.GetList("-2", 2, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DorState.可用);
                CommonFunction.DDlTypeBind(this.ddl_MeetingRoom, dt, "CRID", "RoomName", "-2");
                //BindLinkUser();
                //BindMeetUser();
                if (MID != "")
                {
                    this.hf_MID.Value = MID;
                    InfoBind();
                }
                else
                {
                    this.hf_MID.Value = Guid.NewGuid().ToString();
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
            MeetingEntity model = mDAL.GetObjByID(this.hf_MID.Value);
            if (model != null)
            {
                this.txt_MTitle.Text = model.MTitle.ToString();
                this.txt_MContent.Text = model.MContent.ToString();
                this.txt_LinkNum.Text = model.LinkNum.ToString();
                this.txt_MBegin.Text = model.MBegin.ToString("yyyy-MM-dd HH:mm");
                this.txt_MEnd.Text = model.MEnd.ToString("yyyy-MM-dd HH:mm");
                this.txt_UserList.Text = model.UserList.ToString();

                //this.txt_LinkUser.Text = model.LinkUserName.ToString();
                this.ddl_MeetingRoom.SelectedValue = model.MeetingRoom.ToString();

                //SetValue(model.LinkUser.ToString());
                this.hf_DutyUser.Value = model.LinkUser.ToString();

                DataTable dt = mDAL.GetByMID(this.hf_MID.Value.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    //this.txt_MeetingUser.Text = dt.Rows[0]["UserRealName"].ToString();
                    //SetMeetValue(dt.Rows[0]["MeetingUsers"].ToString());
                    this.hf_AlluserID.Value = dt.Rows[0]["MeetingUsers"].ToString();
                }
            }
        }

        //private void SetValue(string TID)
        //{
        //    StringBuilder sb1 = new StringBuilder();
        //    sb1.Append("<script type='text/javascript'>");
        //    sb1.Append("$(function () {$('#LinkUser').combotree('setValue', '");
        //    sb1.Append(TID);
        //    sb1.Append("');");
        //    //sb1.Append("$('#LinkUser').combotree('disable');");
        //    sb1.Append("})</script>");
        //    this.ltl_xz.Text = sb1.ToString();
        //}

        //private void SetMeetValue(string TID)
        //{
        //    StringBuilder sb1 = new StringBuilder();
        //    sb1.Append("<script type='text/javascript'>");
        //    sb1.Append("$(function () {$('#MeetUser').combotree('setValue', '");
        //    sb1.Append(TID);
        //    sb1.Append("');");
        //    //sb1.Append("$('#MeetUser').combotree('disable');");
        //    sb1.Append("})</script>");
        //    this.ltl_xz1.Text = sb1.ToString();
        //}
        #endregion


        //#region 带部门的教师绑定
        ///// <summary>
        ///// 绑定联系人
        ///// </summary>
        //private void BindLinkUser()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    string a = MList();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append(" $(function () {");
        //    sb.Append(" $('#LinkUser').combotree({");
        //    sb.Append(" data: [ ");
        //    sb.Append(a);
        //    sb.Append("],");
        //    sb.Append("multiple: false,");
        //    sb.Append("lines: true,");
        //    sb.Append("});");
        //    sb.Append(" }); </script>");
        //    this.ltl_JQ.Text = sb.ToString();
        //}

        ///// <summary>
        ///// 绑定参会人员
        ///// </summary>
        //private void BindMeetUser()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    string a = MList();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append(" $(function () {");
        //    sb.Append(" $('#MeetUser').combotree({");
        //    sb.Append(" data: [ ");
        //    sb.Append(a);
        //    sb.Append("],");
        //    sb.Append("multiple: true,");
        //    sb.Append("lines: true,");
        //    sb.Append("});");
        //    sb.Append(" }); </script>");
        //    this.ltl_JQ1.Text = sb.ToString();
        //}

        ///// <summary>
        ///// 绑定职能部门信息
        ///// </summary>
        ///// <returns></returns>
        //private string MList()
        //{
        //    DataTable dt;
        //    dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
        //    string name = string.Empty;
        //    if (dt == null)
        //    {
        //        name = "[]";
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
        //            //调用递归方法
        //            name += InitChild(dt.Rows[i]["DID"].ToString());
        //            name += "},";
        //        }
        //    }
        //    sb.Append(name.ToString().TrimEnd(','));
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// 绑定职能部门人员信息
        ///// </summary>
        ///// <param name="parentID"></param>
        ///// <returns></returns>
        //public string InitChild(string parentID)
        //{
        //    DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
        //    StringBuilder sb = new StringBuilder();
        //    string name = "";
        //    if (dt == null)
        //    {
        //        //
        //    }

        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        //        }
        //    }
        //    sb.Append("\"children\":[");
        //    sb.Append(name.ToString().TrimEnd(','));
        //    sb.Append("]");
        //    return sb.ToString();
        //}
        //#endregion


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
                MeetingEntity model = new MeetingEntity();
                int isadd = MID.ToString() == "" ? 0 : 1;
                model.MID = this.hf_MID.Value.ToString();
                model.MTitle = this.txt_MTitle.Text.ToString().Trim();
                model.MContent = this.txt_MContent.Text.ToString().Trim();
                model.MeetingRoom = Convert.ToInt32(this.ddl_MeetingRoom.SelectedValue.ToString());
                if (this.hf_DutyUser.Value == "")
                {
                    ShowMessage("请选择联系人");
                    return;
                }
                if (this.hf_AlluserID.Value == "")
                {
                    ShowMessage("请选择参会人员");
                    return;
                }
                DataTable dt = mDAL.GetByMID(this.hf_MID.Value.ToString());
                if (dt != null && dt.Rows[0]["MeetingUsers"].ToString() != "")
                {
                    string[] musers = this.hf_AlluserID.Value.TrimEnd(',').TrimStart(',').Split(',');
                    string[] dtuser = dt.Rows[0]["MeetingUsers"].ToString().TrimEnd(',').TrimStart(',').Split(',');
                    //string[] ar3 = musers.Union(dtuser).ToArray();//合并数组
                    string[] users = musers.Except(dtuser).ToArray();//从一个数组中去除另一个数组

                    if (users.Length > 0)
                    {
                        for (int i = 0; i < users.Length; i++)
                        {
                            model.MeetingUsers += users[i] + ",";
                        }
                    }
                    else
                    {
                        model.MeetingUsers = "";
                    }
                }
                else
                {
                    model.MeetingUsers = this.hf_AlluserID.Value.TrimEnd(',').TrimStart(',');
                }

                //if (this.txt_MBegin.Text.ToString().Trim() == "" || this.txt_MEnd.Text.ToString().Trim() == "")
                //{
                //    ShowMessage("请填写会议开始与结束时间");
                //    return;
                //}
                model.MBegin = Convert.ToDateTime(this.txt_MBegin.Text.ToString());
                model.MEnd = Convert.ToDateTime(this.txt_MEnd.Text.ToString());
                if (model.MBegin >= model.MEnd)
                {
                    ShowMessage("开始时间应小于结束时间，请重新选择");
                    return;
                }
                if (MID == "")
                {
                    if (model.MBegin < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm")))
                    {
                        ShowMessage("会议开始时间应大于当前时间，请重新选择");
                        return;
                    }
                }
                model.LinkUser = this.hf_DutyUser.Value.ToString();
                model.LinkNum = this.txt_LinkNum.Text.ToString().Trim();
                model.CreateUser = UserID;
                model.UserList = this.txt_UserList.Text.ToString().Trim();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.AuditState = (int)CommonEnum.PraState.申请中;

                int result = mDAL.Edit(model, isadd);
                if (result == 0)
                {
                    //ShowMessage();
                    int log = MID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (MID == "" ? "添加" : "修改") + "会议主题为：" + this.txt_MTitle.Text + "的会议信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='MeetingManage.aspx?flag=1';", true);
                }
                else if (result == -2)
                {
                    ShowMessage("该会议室的该时间段与已有会议有重合，请修改后重新提交");
                    return;
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
            }
        }
        #endregion
    }
}