/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2016年11月11日 10:00
** 描 述:       资产领用/借出页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AssetBorrowEdit : PageBase
    {
        public AssetBorrowDAL borrowDAL = new AssetBorrowDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public AssetDAL assetDAL = new AssetDAL();

        #region 参数集合
        /// <summary>
        /// Flag 标示 1：借出 2：领用
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        public int ABFlag
        {
            get
            {
                return GetQueryString<int>("abflag", -1);
            }
        }
        /// <summary>
        /// 资产id
        /// </summary>
        public string AID
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
                //BandDepart(); //绑定教师

                //资产借出
                if (Flag == 1)
                {
                    this.ltl_UserDate.Text = this.ltl_Name.Text = this.ltl_ABMak.Text = this.ltl_AssetNum.Text = this.ltl_Title.Text = "借出";
                    this.txt_UserDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//添加时间
                }
                else //耗材领用
                {
                    this.ltl_UserDate.Text = this.ltl_Name.Text = this.ltl_ABMak.Text = this.ltl_AssetNum.Text = this.ltl_Title.Text = "领用";
                    this.txt_UserDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//添加时间
                }
                //资产领用
                if (ABFlag == 3 && Flag == 1)
                {
                    this.ltl_UserDate.Text = this.ltl_Name.Text = this.ltl_ABMak.Text = this.ltl_AssetNum.Text = this.ltl_Title.Text = "领用";
                    this.txt_UserDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//添加时间
                }
            }
        }
        #endregion

        #region 绑定教师姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#TeacherName').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#TeacherName').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        #region 带部门的教师绑定
        /// <summary>
        /// 带部门的教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#TeacherName').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定职能部门信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt;
            dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
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
        /// 绑定职能部门人员信息
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
                Asset_BorrowEntity model = new Asset_BorrowEntity();
                model.ABID = 0;
                model.AID = AID;
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}

                //DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (this.hf_SelectedValue.Value == dt.Rows[i]["DID"].ToString())
                //    {
                //        ShowMessage("部门不可选做教师");
                //        return;
                //    }
                //}
                //model.ABUser = this.hf_SelectedValue.Value;//领用人
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.ABUser = this.Series.Text;//领用人

                model.Flag = Flag;//1 资产  2 耗材
                //model.ABFlag = Flag; //状态：1借出  2领用
                model.ABFlag = ABFlag; //状态：1资产借出 3资产领用  2耗材领用 
                AssetEntity model1 = assetDAL.GetObjByID(AID);
                if (model1 == null)
                {
                    model1.AssetNum = 0;
                }
                if (model1.AssetNum < Convert.ToInt32(this.txt_AssetNum.Text))
                {
                    ShowMessage("领用数量不能超过库存量");
                    return;
                }
                if (Convert.ToInt32(this.txt_AssetNum.Text) <= 0)
                {
                    ShowMessage("领用数量不能小于0");
                    return;
                }
                model.AssetNum = Convert.ToInt32(this.txt_AssetNum.Text.ToString().Trim());
                model.ABMak = this.txt_ABMark.Text.ToString().Trim();
                model.CreaterUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.UserDate = Convert.ToDateTime(this.txt_UserDate.Text);//领用时间


                //if (Flag == 1)//状态：1 资产  2 耗材
                //{
                //    model.ABFlag = (int)CommonEnum.ABState.借出;
                //}
                //else
                //{
                //    model.ABFlag = (int)CommonEnum.ABState.领用;
                //}

                int result = borrowDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "领用耗材信息", UserID));
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, (Flag == 1 ? "借出资产信息" : "领用耗材信息"), UserID));
                }
                else
                {
                    ShowMessage("保存失败");
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