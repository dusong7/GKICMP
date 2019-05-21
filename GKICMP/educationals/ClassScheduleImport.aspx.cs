/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      课表导入
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
using System.Collections.Generic;

namespace GKICMP.educationals
{
    public partial class ClassScheduleImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public static int ClaID = 0;
        public static string EYear;
        public static int term;


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


        #region 下载学生名单
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            GetTerm(out EYear, out term);
            DataTable dt = new DataTable();
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null)
            {
                //string[] arryStr = new string[] { " ", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                //for (int i = 0; i <= model.CourseDay; i++)
                //{
                //    dt.Columns.Add(arryStr[i], typeof(string));
                //}
                DataTable dtcourse = scourseDAL.GetClaID(EYear, term);
                if (dtcourse != null && dtcourse.Rows.Count > 0)
                {
                    dt.Columns.Add("班级/课程", typeof(string));
                    for (int i = 1; i <= model.CourseDay; i++)
                    {
                        for (int j = 1; j <= model.AfterPitch + model.MorningPitch + model.EveningPitch; j++)
                        {
                            int id = Array.IndexOf(model.NoTimetable.ToString().Split('|'), (i * 100 + j).ToString());
                            if (id == -1)    //不存在
                            {
                                dt.Columns.Add((i * 100 + j).ToString(), typeof(string));
                            }
                        }
                    }
                    for (int k = 0; k < dtcourse.Rows.Count; k++)
                    {
                        ClaID = Convert.ToInt32(dtcourse.Rows[k]["ClaID"].ToString());
                        List<string> list = new List<string>();
                        list.Add(dtcourse.Rows[k]["ClaIDName"].ToString() + "班");
                        dt.Rows.Add(list.ToArray());
                    }
                }
            }
            else
            {
                ShowMessage("请先配置排课设置");
                return;
            }
            try
            {
                //调用导出方法
                CommonFunction.ExportByWeb(dt, "", "课表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            }
            catch (Exception ee)
            {
                string _err = ee.Message;
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
                string name = UserID.ToString() + "_ScheduleTemplate_";
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
            {                //获取数据
                DataTable dt = ReadExcel(path);
                if (dt != null)
                {
                    //SysUserEntity[] list = new SysUserEntity[dt.Rows.Count];
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    SysUserEntity model = new SysUserEntity();

                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["家庭住址"].ToString()))
                    //        model.Address = dt.Rows[i]["家庭住址"].ToString();
                    //    else
                    //    {
                    //        ShowMessage("家庭住址不能为空【第" + (i + 2) + "行】"); return;
                    //    }
                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["民族"].ToString()))
                    //        model.Nation = (int)Enum.Parse(typeof(CommonEnum.MZ), dt.Rows[i]["民族"].ToString());
                    //    else
                    //    {
                    //        ShowMessage("民族不能为空【第" + (i + 2) + "行】"); return;
                    //    }
                    //    model.MailNum = dt.Rows[i]["邮箱"].ToString();
                    //    model.QQNum = dt.Rows[i]["QQ"].ToString();
                    //    model.WeiNum = dt.Rows[i]["微信"].ToString();
                    //    // model.Roles="1";
                    //    model.UserDesc = dt.Rows[i]["备注"].ToString();
                    //    model.UserPwd = CommonFunction.Encrypt("888888");
                    //    model.CompanyNum = "";
                    //    model.BirthDay = DateTime.Parse(model.IDCard.Substring(6, 4) + "-" + model.IDCard.Substring(10, 2) + "-" + model.IDCard.Substring(12, 2));
                    //    //model.DepID = "";
                    //    model.UserType = id;
                    //    model.UState = (int)CommonEnum.UState.正常;
                    //    model.Isdel = (int)CommonEnum.Deleted.未删除;
                    //    model.CreateDate = DateTime.Now;
                    //    model.CreateUser = UserID;
                    //    list[i] = model;
                    //}
                    //if (list != null)
                    //{

                    //    int returnvalue = sysUserDAL.Import(list, id);
                    //    if (returnvalue == 0)
                    //    {
                    //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入课表", UserID));
                    //        ShowMessage();
                    //    }
                    //    else if (returnvalue == -2)
                    //    {
                    //        ShowMessage("该用户名已经存在");
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        ShowMessage("保存失败");
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    ShowMessage("导入的信息存在错误");
                    //    return;
                    //}
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

        #region 获取当前学期
        private static void GetTerm(out string EYear, out int term)
        {
            EYear = "";
            term = 0;
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 8 && month >= 2)
            {
                EYear = (year - 1) + "-" + year;
                term = (int)CommonEnum.XQ.下学期;
            }
            else
            {
                if (month <= 12 && month >= 8)
                {
                    EYear = year + "-" + (year + 1);
                }
                else
                {
                    EYear = (year - 1) + "-" + year;
                }
                term = (int)CommonEnum.XQ.上学期;
            }
        }
        #endregion

    }
}