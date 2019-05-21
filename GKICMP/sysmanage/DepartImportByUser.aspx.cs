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
using System.Collections.Generic;

namespace GKICMP.sysmanage
{
    public partial class DepartImportByUser : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
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
            if (!IsPostBack) { }
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
            //string expath = @"~\Template\UserImportTemplate.xls";
            //if (!CommonFunction.UpLoadFunciotn(expath, "用户导入模板"))
            //{
            //    ShowMessage("模板文件不存在，请联系系统管理员");
            //    return;
            //}
            Excel();
        }
        #endregion

        #region 导出教师名单
        public void Excel()
        {
            DataTable dt = new DataTable();
            DataTable teacher = sysUserDAL.GetSysUserByTeac((int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
           
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("身份证号", typeof(string));
            dt.Columns.Add("部门", typeof(string));
            foreach (DataRow dr in teacher.Rows)
            {
                List<string> list = new List<string>();
                list.Add(dr["RealName"].ToString());
                list.Add(dr["IDCard"].ToString());
                list.Add(dr["DepID"].ToString());
                dt.Rows.Add(list.ToArray());
            }
            try
            {
                //string _excelName = "发货列表信息";//Excel表头名称
                //string fileName = _excelName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls"; //Excel文件名称
                //调用导出方法
                CommonFunction.ExportByWeb(dt, "", "教师部门导入模版" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

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
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties='Excel 8.0;IMEX=1'";
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
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
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
               // DataTable depart = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门,(int)CommonEnum.Deleted.未删除);
                DataTable depart = departmentDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DepType.职能部门);
                //List<string> dlist = new List<string>();
                if (depart == null || depart.Rows.Count <= 0)
                {
                    ShowMessage("请先在系统中添加部门信息");
                    return;
                }
                if (dt != null)
                {
                    // 检查列名
                    string colname = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        colname += dc.ColumnName + ",";
                    }
                    string[] needcol = {  "姓名", "身份证号",  "部门" };
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
                            if (dt.Rows[i]["身份证号"].ToString() != "")
                                model.IDCard = dt.Rows[i]["身份证号"].ToString();
                            else
                            { ShowMessage("请勿修改模版文件：身份证号不能为空【第" + (i + 2) + "行】"); return; }

                            string[] deps = dt.Rows[i]["部门"].ToString().Split(',');
                            string depid = "";
                            foreach (string s in deps)
                            {
                                DataRow[] drd = depart.Select("DepName='" + s + "'");
                                if (drd != null && drd.Length > 0)
                                {
                                    depid += drd[0]["did"].ToString() + ",";
                                }
                            }
                            model.DepID = depid.Trim(',');

                            //部门ID
                            //if (dt.Rows[i]["部门ID"].ToString()!="")
                            //{
                            //    string[] did = dt.Rows[i]["部门ID"].ToString().Split(',');
                            //    foreach (string s in did) 
                            //    {
                            //        if (dlist.IndexOf(s) <0) 
                            //        {
                            //            ShowMessage("系统中不存在部门id为【" + s + "】的部门，请修改"); return;
                            //        }
                            //    }
                            //    model.DepID = dt.Rows[i]["部门ID"].ToString();
                            //}
                            //else
                            //{
                            //    ShowMessage("部门不能为空【第" + (i + 2) + "行】");
                            //    return;
                            //}


                            list[i] = model;
                        }
                        if (list != null)
                        {

                            string returnvalue = sysUserDAL.Import(list);
                            if (returnvalue == "0")
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入用户信息", UserID));
                                ShowMessage();
                            }
                            else if (returnvalue == "-1")
                            {
                                ShowMessage("保存失败");
                                return;
                            }
                           
                            else
                            {
                                ShowMessage("系统中没有此身份证号：" + returnvalue);
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