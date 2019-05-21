/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师课时导入
** 修 改 人:      
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
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class SysUserImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public CampusDAL campusDAL = new CampusDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();


        #region 参数集合
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region 下载模板文件
        /// <summary>
        /// 下载模板文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            string expath = @"~\Template\UserImportTemplate.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "用户导入模板"))
            {
                ShowMessage("模板文件不存在，请联系系统管理员");
                return;
            }
        }
        #endregion


        #region 读取Excel文件
        /// <summary>
        /// 读取Excel文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable ReadExcel(string path)
        {
            //DataTable dt = new DataTable();
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties=Excel 8.0;";
            //OleDbConnection conn = new OleDbConnection(strConn);
            //try
            //{
            //    conn.Open();
            //    //获取表名
            //    DataTable dtname = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //    string sheetName = dtname.Rows[0][2].ToString().Trim();
            //    //读取excel文件数据
            //    string strExcel = string.Format("select * from [{0}]", sheetName);
            //    OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
            //    myCommand.Fill(dt);
            //}
            //catch (Exception ex)
            //{
            //    dt = null;
            //}
            //conn.Close();
            //CommonFunction.delfile(path);
            //return dt;
            return CommonFunction.ExportExcel(path);
        }
        #endregion


        #region 上传导入的文件
        /// <summary>
        /// 上传导入的文件
        /// </summary>
        /// <returns></returns>
        protected string up()
        {
            string path = Server.MapPath("../Template/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (fuimport.HasFile)
            {
                string name = UserID.ToString() + "_UserImportTemplate_";
                string strfile = System.IO.Path.GetExtension(fuimport.FileName);
                string filename = name + strfile;
                path += filename;
                fuimport.SaveAs(path);
                return path;
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 导入
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            string path = up();
            //判断是否上传成功
            if (path != "")
            {
                //获取数据
                DataTable dt = ReadExcel(path);

               
                if (dt != null)
                {
                    // 检查列名
                    string colname = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        colname += dc.ColumnName + ",";
                    }
                    int id = 0;
                    switch (Flag)
                    {
                        case 1:
                            id = (int)CommonEnum.UserType.老师; break;//教师
                        case 2:
                            id = (int)CommonEnum.UserType.学生; break;//学生
                        case 3:
                            id = 3; break;//新生
                    }

                    DataTable dep = departmentDAL.GetList((int)CommonEnum.IsorNot.否, id == 2 ? (int)CommonEnum.DepType.普通班级 : (int)CommonEnum.DepType.职能部门);
                    string[] needcol = { "校区ID", "用户名", "姓名", "身份证号", "性别", "手机号", "部门名称", "家庭住址", "民族", "邮箱", "QQ", "微信", "备注" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                       
                        SysUserEntity[] list = new SysUserEntity[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            SysUserEntity model = new SysUserEntity();
                            model.UID = "";
                            if (!string.IsNullOrEmpty(dt.Rows[i]["手机号"].ToString()))
                                model.CellPhone = dt.Rows[i]["手机号"].ToString();
                            else
                            { 
                                ShowMessage("手机号不能为空【第"+(i+2)+"行】"); return;
                            }
                            model.UserName = dt.Rows[i]["用户名"].ToString() == "" ? dt.Rows[i]["手机号"].ToString() : dt.Rows[i]["用户名"].ToString();

                            //校区ID
                            if (IsNum(dt.Rows[i]["校区ID"].ToString()) == false)
                            {
                                ShowMessage("请输入正确的校区ID,校区ID为整数，请修改【第" + (i + 2) + "行】");
                                return;
                            }
                            int gd = campusDAL.GetByCID( Convert.ToInt32( dt.Rows[i]["校区ID"].ToString() ), (int)CommonEnum.Deleted.未删除);
                            if (gd == -1)
                            {
                                ShowMessage("系统中不存在名称为：" + dt.Rows[i]["校区ID"].ToString() + "的校区ID，请修改后重新导入【第" + (i + 2) + "行】");
                                return;
                            }
                            else
                            {
                                model.CID = gd;
                            }

                            //部门ID
                            //if (IsNum(dt.Rows[i]["部门ID"].ToString()) == false)
                            //{
                            //    ShowMessage("请输入正确的部门ID,部门ID为整数，请修改【第" + (i + 2) + "行】");
                            //    return;
                            //}
                            //int dd = departmentDAL.GetByDID(Convert.ToInt32(dt.Rows[i]["部门ID"].ToString()), (int)CommonEnum.Deleted.未删除);
                            //if (dd == -1)
                            //{
                            //    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["部门ID"].ToString() + "的部门ID，请修改后重新导入【第" + (i + 2) + "行】");
                            //    return;
                            //}
                            //else
                            //{
                            //    model.DepID = Convert.ToString(dd);
                            //}
                            string[] deps = dt.Rows[i]["部门名称"].ToString().Split(',');
                            string depid = "";
                            foreach (string s in deps) 
                            {
                                DataRow[] drd = dep.Select("DepName='" + s + "'");
                                if (drd != null && drd.Length > 0)
                                {
                                    depid += drd[0]["did"].ToString() + ",";
                                }
                            }
                            model.DepID = depid.Trim(',');
                            if (!string.IsNullOrEmpty(dt.Rows[i]["姓名"].ToString()))
                                model.RealName = dt.Rows[i]["姓名"].ToString();
                            else
                            { 
                                ShowMessage("姓名不能为空【第" + (i + 2) + "行】"); return; 
                            }

                            if (!string.IsNullOrEmpty(dt.Rows[i]["身份证号"].ToString()))
                                model.IDCard = dt.Rows[i]["身份证号"].ToString();
                            else
                            {
                                ShowMessage("身份证号不能为空【第" + (i + 2) + "行】"); return;
                            }

                            if (!string.IsNullOrEmpty(dt.Rows[i]["性别"].ToString()))
                                model.UserSex = dt.Rows[i]["性别"].ToString() == "男" ? (int)CommonEnum.XB.男 : (int)CommonEnum.XB.女;
                            else
                            {
                                ShowMessage("性别不能为空【第" + (i + 2) + "行】"); return;
                            }

                            if (!string.IsNullOrEmpty(dt.Rows[i]["家庭住址"].ToString()))
                                model.Address = dt.Rows[i]["家庭住址"].ToString();
                            else 
                            {
                                ShowMessage("家庭住址不能为空【第" + (i + 2) + "行】"); return;
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[i]["民族"].ToString()))
                                model.Nation = (int)Enum.Parse(typeof(CommonEnum.MZ), dt.Rows[i]["民族"].ToString());
                            else 
                            {
                                ShowMessage("民族不能为空【第" + (i + 2) + "行】"); return;
                            }
                            model.MailNum = dt.Rows[i]["邮箱"].ToString();
                            model.QQNum = dt.Rows[i]["QQ"].ToString();
                            model.WeiNum = dt.Rows[i]["微信"].ToString();
                           // model.Roles="1";
                            model.UserDesc = dt.Rows[i]["备注"].ToString();
                            model.UserPwd = CommonFunction.Encrypt("888888");
                            model.CompanyNum = "";
                            model.BirthDay = DateTime.Parse( model.IDCard.Substring(6, 4) + "-" + model.IDCard.Substring(10, 2) + "-" + model.IDCard.Substring(12, 2));
                            //model.DepID = "";
                            model.UserType = id;
                            model.UState = (int)CommonEnum.UState.正常;
                            model.Isdel = (int)CommonEnum.Deleted.未删除;
                            model.CreateDate = DateTime.Now;
                            model.CreateUser = UserID;
                            list[i] = model;
                        }
                        if (list != null)
                        {
                           
                            int returnvalue = sysUserDAL.Import(list,id);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入用户信息", UserID));
                                ShowMessage();
                            }
                            else if (returnvalue == -2)
                            {
                                ShowMessage("该用户名已经存在");
                                return;
                            }
                            else if (returnvalue == -3)
                            {
                                ShowMessage("该身份证已经存在");
                                return;
                            }
                            else if (returnvalue == -4)
                            {
                                ShowMessage("该手机号（并且登录名）已被注册");
                                return;
                            }
                            else
                            {
                                ShowMessage("保存失败");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("导入的信息存在错误");
                            return;
                        }
                    }
                    else
                    {
                        ShowMessage("文件中第缺少必要的信息，请检查后重新导入");
                        return;
                    }
                }
                else
                {
                    ShowMessage("文件读取失败，请检查文件是否已损坏");
                    return;
                }
            }
            else
            {
                ShowMessage("文件导入失败");
                return;
            }
        }
        #endregion

        

        #region 判断是否为数字
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public bool IsNum(string Str)
        {
            bool bl = false;
            string Rx = @"^[1-9]\d*$";
            if (Regex.IsMatch(Str, Rx))
            {
                bl = true;
            }
            else
            {
                bl = false;
            }
            return bl;
        }
        #endregion

    }
}