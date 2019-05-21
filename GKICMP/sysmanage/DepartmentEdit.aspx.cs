/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09点30分
** 描   述:      部门修改、添加页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;
using System.Web.UI;

namespace GKICMP.sysmanage
{
    public partial class DepartmentEdit : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 参数集合
        /// <summary>
        /// DID
        /// </summary>
        public int DID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        /// <summary>
        /// 1：部门 2：班级
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
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CampusName", "-2");

                BandData();
               // CommonFunction.BindEnum<CommonEnum.DepType>(this.ddl_DepType, "-99");
                if (Flag == 1)
                {
                    this.depart.Visible = false;
                    //this.ddl_DepType.SelectedValue = ((int)CommonEnum.DepType.职能部门).ToString();
                    //this.ddl_DepType.Enabled = false;
                    this.ltl_D.Text = "部门";
                    this.ltl_DepName.Text = this.ltl_OtherName.Text = this.ltl_DepMark.Text = "部门";
                    this.ltl_Master.Text = "部门负责人";
                    this.ddlcid.Style.Add("display", "none");//隐藏所属校区
                }
                else
                {
                    //this.ddl_DepType.SelectedValue = ((int)CommonEnum.DepType.普通班级).ToString();
                    //this.ddl_DepType.Enabled = false;
                    this.ltl_D.Text = "班级";
                    this.ltl_DepName.Text = this.ltl_OtherName.Text = this.ltl_DepMark.Text = "班级";
                    this.ltl_Master.Text = "班主任";
                }
                if (DID == -1 || DID == -2)
                {
                    //this.btn_Deleted.Style.Add("display", "none");//隐藏删除按钮
                }
                else
                {
                    InfoBind();
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
            if (Flag != 1)
                sb.Append("multiple: false,");
            else
            {
                sb.Append("multiple: true,");
                sb.Append("onlyLeafCheck:'true',");
            }
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
            DataTable dt;
            dt = departmentDAL.GetAllDeparInfo();
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
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
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


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            DepartmentEntity model = departmentDAL.GetObj(DID);
            if (model != null)
            {
                this.txt_DepName.Text = model.DepName;//部门名称
                this.txt_DepMark.Text = model.DepMark;//部门简述
                this.ddl_CID.SelectedValue = model.CID.ToString();

                //this.txt_Master.Text = model.Master;//部门负责人
                //this.hf_SelectedValue.Value = model.Master;
                string[] s = model.Master.Split(',');
                string name = "";
                foreach (string a in s) 
                {
                    name += "'" + a + "',";
                }
                this.txt_OtherName.Text = model.OtherName;
                // this.Series.Value = model.Master;
                // this.rbol_MType.Text = Convert.ToString(model.IsDisplayInWeb.ToString());//是否展现
                this.txt_DepOrder.Text = model.DepOrder.ToString();//排序
                this.hf_ID.Value = "1";//判断是编辑还是添加
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("<script type='text/javascript'>");
                sb1.Append("$(function () {$('#Series').combotree('setValues',[");
                sb1.Append(name.Trim(','));
                sb1.Append("]);})</script>");
                this.ltl_xz.Text = sb1.ToString();

                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>GetValue(" + model.Master + ");</script>", true);//后台调用前台js方法                
            }
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = departmentDAL.GetAllDeparInfo();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (this.hf_SelectedValue.Value == dt.Rows[i]["DID"].ToString())
                    {
                        ShowMessage((Flag == 1 ? "部门" : "班级") + "不可选做部门负责人");
                        return;
                    }
                }

                DepartmentEntity model = new DepartmentEntity();
                model.DID = this.hf_ID.Value == "2" ? -1 : DID;//判断 编辑为DID 添加为-1
                model.DepName = this.txt_DepName.Text;//部门名称
                model.DepMark = this.txt_DepMark.Text;//部门简述

                model.Master = this.Series.Text;
              //  model.Master = this.hf_SelectedValue.Value.ToString();//部门负责人
                //model.Master = this.hf_UID.Value;
                //model.IsDisplayInWeb = int.Parse(this.rbol_MType.SelectedValue);//是否展现
                model.IsDisplayInWeb = 1;
                model.GID = 0;//所属年级
                if (Flag == 1)
                {
                    model.DepType = (int)CommonEnum.DepType.职能部门;
                    model.CID = 0;//校区ID
                }
                else
                {
                    model.DepType = (int)CommonEnum.DepType.普通班级;
                    model.CID = Convert.ToInt32(this.ddl_CID.SelectedValue.ToString());//校区ID
                }
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.OtherName = this.txt_OtherName.Text;
                if (this.txt_DepOrder.Text == "")
                {
                    model.DepOrder = 0;//排序
                }

                else
                {
                    Double rt;
                    if (System.Double.TryParse(this.txt_DepOrder.Text, out rt))
                    {
                        model.DepOrder = int.Parse(this.txt_DepOrder.Text);
                    }
                    else
                    {
                        ShowMessage("排序号只能填写有效数字！！！");
                        return;
                    }
                }
                int depid=0;
                int result = departmentDAL.Edit(model,ref depid);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该" + (Flag == 1 ? "部门" : "班级") + "已存在，请重新输入");
                    return;
                }
                else
                {
                    WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "TXL", 2);
                    if (model1.IsOpen == 1)
                    {
                        string message = WXEdit(model, depid);
                        if (message == "0")
                        {
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, (DID == 0 ? "添加" : "修改") + (Flag == 1 ? "部门" : "班级"), UserID));
                            ShowMessage();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('保存成功，但未同步到微信！');winclose();", true);
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, message, UserID));
                            return;
                        }

                    }
                    else
                    {
                        int log = DID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                        sysLogDAL.Edit(new SysLogEntity(log, (DID == -1 ? "添加" : "修改") + (Flag == 1 ? "部门" : "班级") + "【" + this.txt_DepName.Text + "】", UserID));
                        ShowMessage();
                    }

                   
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
                    //ShowMessage();

                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                return;
            }
        }
        #endregion


        private string WXEdit(DepartmentEntity model,int depid)
        {
            string token = WeixinQYAPI.GetToken(2, "0");
            if (token != "")
            {
                string json = "{ \"id\": \"" + depid
                                + "\", \"name\": \"" + model.DepName
                                + "\",\"parentid\": [1]"
                                + ", \"order\": \"" + model.DepOrder + "\"}";
                if (DID == 0)//新增用户
                {
                    return WeixinQYAPI.CreateDepart(token,json);
                }
                else//修改
                {
                    string code= WeixinQYAPI.UpdateDepart(token, json);
                    if (code != "0") 
                    {
                        return WeixinQYAPI.CreateDepart(token, json);
                    }
                    return code;
                   
                }
            }
            else
            {
                //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, UID == "" ? "增加" : "修改" + "【" + this.txt_UserName.Text + "】的用户", UserID));
                return "凭证调用失败";
            }
        }

        #region 删除栏目
        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            DepartmentEntity model = departmentDAL.GetObj(DID);
            if (model != null)
            {
                int deptype = model.DepType;
                int istrue = departmentDAL.DeleteBat(DID, deptype);
                if (istrue == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除部门【" + this.txt_DepName.Text + "】", UserID));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：删除成功！');succ();</script>");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
            }
        }
        #endregion


    }
}