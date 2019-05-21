/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Web;

namespace GKICMP.studentmanage
{
    public partial class StuRewardEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public Stu_RewardDAL stu_RewardDAL = new Stu_RewardDAL();
        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string SRID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
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
            //this.hf_SelectedValue.Value = TID;

            if (!IsPostBack)
            {
                //BandDepart();

                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");//学期
                CommonFunction.BindEnum<CommonEnum.RGrade>(this.ddl_RewardGrade, "-2");//奖励级别
                CommonFunction.BindEnum<CommonEnum.RType>(this.ddl_RewardType, "-2");//奖励类别
                CommonFunction.BindEnum<CommonEnum.RewardType>(this.ddl_RewardRand, "-2");//奖励等级
                CommonFunction.BindEnum<CommonEnum.RStyle>(this.ddl_RStyle, "-2");//奖励类型
                CommonFunction.BindEnum<CommonEnum.RMode>(this.ddl_RMode, "-2");//奖励方式
                if (DateTime.Now.Month > 8)
                {
                    this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                    //  this.ddl_Term.Enabled = false;
                }
                else
                {
                    this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                    // this.ddl_Term.Enabled = false;
                }
                if (SRID != "")
                {
                    InfoBind(0);

                }
            }
        }
        #endregion

        #region 绑定学生姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#StuName').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#StuName').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        #region 学生绑定
        /// <summary>
        /// 教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = DepartList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#StuName').combotree({");
            sb.Append(" data:[");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("multiline: false,");
            sb.Append("});");
            sb.Append(" }); </script>");

            this.ltl_JQ.Text = sb.ToString();

        }
        private string DepartList()
        {
            DataTable dt;
            dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.学生, (int)CommonEnum.Deleted.未删除);
            string name = string.Empty;
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind(int i)
        {
            try
            {
                Stu_RewardEntity model = stu_RewardDAL.GetObjByID(SRID);
                if (model != null)
                {
                    //SetValue(model.StuID);
                   // this.hf_SelectedValue.Value = model.StuID;
                    this.txt_EYear.Text = model.EYear;
                    this.ddl_Term.SelectedValue = model.Term.ToString();
                    this.txt_RewardName.Text = model.RewardName;
                    this.ddl_RewardGrade.Text = model.RewardGrade.ToString();
                    this.ddl_RewardType.SelectedValue = model.RewardType.ToString();
                    this.ddl_RewardRand.SelectedValue = model.RewardRand.ToString();
                    this.ddl_RStyle.SelectedValue = model.RStyle.ToString();
                    this.txt_RewardCash.Text = model.RewardCash.ToString();
                    this.txt_RewardDep.Text = model.RewardDep;
                    this.txt_RewardReason.Text = model.RewardReason;
                    this.ddl_RMode.SelectedValue = model.RMode.ToString();
                    this.txt_RDate.Text = model.RDate.ToString("yyyy-MM-dd");
                    //this.hf_TID.Value = model.TeaID;
                    this.txt_Tea.Text = model.TeaID;
                    this.ddl_IsAchievement.SelectedValue = model.IsAchievement.ToString();
                    this.txt_StuName.Text = model.StuID;
                    this.txt_StuName.Enabled = false;
                    if (i == 0)
                    {
                        this.hf_Images.Value = model.RFile; 
                    }
                    if (model.RFile != null && model.RFile.ToString() != "")
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("tcfile", typeof(string));
                        string[] FileList;
                        if (i == 0)
                        { 
                            FileList = model.RFile.Split(','); 
                        }
                        else
                            {
                               FileList = this.hf_Images.Value.Split(',');
                               
                            }

                        for (int j = 0; j < FileList.Length; j++)
                        {
                            DataRow dr = dt.NewRow();
                            if (FileList[j] != "")
                            {
                                dr["tcfile"] = FileList[j].ToString();
                                dt.Rows.Add(dr);
                            }
                        }
                        this.rp_File.DataSource = dt;
                        this.rp_File.DataBind();

                    }
                    //this.txt_RealName.Text = tmodel.TName;
                    //this.hf_UID.Value = tmodel.TID;//教师
                    // this.TeacherName.Value = tmodel.TID;
                   // txt_Evaluate.Text = model.Evaluate;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string path = e.CommandArgument.ToString().Trim();//\webupload\profile\2017081708450584391.jpg
            if (e.CommandName.ToString() == "del")
            {
                string path1 = HttpContext.Current.Server.MapPath(path);//F:\高科开发程序\GKICMP\D.实现阶段\GKICMP\GKICMP\webupload\profile\2017081708300437611.jpg
                this.hf_Images.Value = this.hf_Images.Value.Replace(path, "").Trim(',');//\webupload\profile\2017081708300437510.jpg
                //int istrue = AccessoryBLL.Delete(accessid);
                //物理路径的文件删除
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }
                else
                {
                    ShowMessage("文件已删除");
                }
                InfoBind(1);
            }

        }
        #endregion

        #region 下载删除
        /// <summary>
        /// 下载删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Download_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string op = lbtn.CommandName.ToString();
            if (op == "Delete")
            {
                this.hf_Images.Value = this.hf_Images.Value.Replace(id, "");
                string path = HttpContext.Current.Server.MapPath(id);
                //int istrue = AccessoryBLL.Delete(accessid);
                //物理路径的文件删除
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    ShowMessage("删除失败");
                }
                InfoBind(1);
            }
            if (op == "Download")
            {

                if (!CommonFunction.UpLoadFunciotn(id, "附件下载"))
                {
                    ShowMessage("下载文件不存在，请联系管理员!");
                    return;
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
                Stu_RewardEntity model = new Stu_RewardEntity();
                model.SRID = SRID;
                //model.StuID = this.hf_SelectedValue.Value;
                //if (this.txt_StuName.Text == "" || this.txt_StuName.Text.Length<10)
                if (this.txt_StuName.Text == "")
                { ShowMessage("请选择学生"); return; }
                model.StuID = this.txt_StuName.Text;
                model.EYear = this.txt_EYear.Text;
                model.Term =int.Parse(  this.ddl_Term.SelectedValue);
                model.RewardName = this.txt_RewardName.Text;
                model.RewardGrade =int.Parse(  this.ddl_RewardGrade.Text);
                model.RewardType = int.Parse( this.ddl_RewardType.SelectedValue);
                model.RewardRand = int.Parse( this.ddl_RewardRand.SelectedValue);
                model.RStyle = int.Parse( this.ddl_RStyle.SelectedValue);

                try
                {
                    model.RewardCash = Convert.ToDecimal(this.txt_RewardCash.Text == "" ? "0" : this.txt_RewardCash.Text);
                }
                catch (Exception)
                {
                    ShowMessage("请填写正确的金额");
                }
                model.RewardDep = this.txt_RewardDep.Text;
                model.RewardReason = this.txt_RewardReason.Text;
                model.RMode = int.Parse( this.ddl_RMode.SelectedValue);
                model.RDate =Convert.ToDateTime( this.txt_RDate.Text);
                //model.TeaID = this.hf_TID.Value;
                if (this.txt_Tea.Text == "" || this.txt_Tea.Text.Length < 10)
                { ShowMessage("请选择辅导老师"); return; }
                model.TeaID = this.txt_Tea.Text;
                model.IsAchievement=int.Parse( this.ddl_IsAchievement.SelectedValue);
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.Isdel=(int)CommonEnum.IsorNot.否;

                //string aa = this.hf_UpFile.Value; //3
               
                AccessoryEntity accessinfo = CommonFunction.upfile(0, Convert.ToInt32(hf_UpFile.Value.Trim()), hf_UpFile, "profile");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = model.SRID;
                    accessinfo.ObjID = "";
                }
              
                model.RFile = (this.hf_Images.Value + "," + accessinfo.AccessUrl).Trim(',');
                int result = stu_RewardDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = SRID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SRID == "" ? "添加" : "修改") + "学生评语信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
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
    }
}