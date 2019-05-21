/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年01月19日 09时41分19秒
** 描    述:      聘用工资导入
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.payment
{
    public partial class EmployWageImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public WageDAL wageDAL = new WageDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();


        #region 页面初始化
        /// <summary>
        /// 页面初始化
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
            string expath = @"~\Template\WageTemplate.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "聘用工资导入模板"))
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
                string name = UserID.ToString() + "_WageTemplate_";
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
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string path = up();
                if (path != "")
                {
                    DataTable dt = ReadExcel(path);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string colname = "";
                        foreach (DataColumn dc in dt.Columns)
                        {
                            colname += dc.ColumnName + ",";
                        }
                        string[] needcol = { "用户名", "年份", "月份", "基本工资", "岗位工资", "学历工资", "上月绩效工资", "应发工资", "养老保险", "住房公积金", "失业保险", "大病救助", "医保", "工会扣除", "实发工资" };
                        int count = 0;
                        for (int i = 0; i < needcol.Length; i++)
                        {
                            count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                        }
                        if (count == needcol.Length)
                        {
                            WageEntity[] list = new WageEntity[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                SysUserEntity model1 = sysUserDAL.GetByUserName(dt.Rows[i]["用户名"].ToString());
                                if (model1 != null)
                                {
                                    if (model1.IsSeries == (int)CommonEnum.IsorNot.是)
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的不是聘用老师，请重新导入");
                                        return;
                                    }
                                    WageEntity model = new WageEntity();
                                    model.TID = model1.UID;
                                    if (!IsNum(dt.Rows[i]["年份"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的年份录入不正确，请重新导入");
                                    }
                                    if (!IsNum(dt.Rows[i]["月份"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的月份录入不正确，请重新导入");
                                    }
                                    if (Convert.ToInt32(dt.Rows[i]["月份"].ToString()) > 12)
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的月份只能在1-12月，请重新导入");
                                    }
                                    if (!IsDecimal(dt.Rows[i]["基本工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的基本工资录入不正确，请重新导入");
                                    }
                                    model.Allowance = Convert.ToDecimal(dt.Rows[i]["基本工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["岗位工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的岗位工资录入不正确，请重新导入");
                                    }
                                    model.PostWage = Convert.ToDecimal(dt.Rows[i]["岗位工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["学历工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的学历工资录入不正确，请重新导入");
                                    }
                                    model.SalaryScale = Convert.ToDecimal(dt.Rows[i]["学历工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["上月绩效工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的上月绩效工资录入不正确，请重新导入");
                                    }
                                    model.BasicPay = Convert.ToDecimal(dt.Rows[i]["上月绩效工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["应发工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的应发工资录入不正确，请重新导入");
                                    }
                                    model.ShouldWage = Convert.ToDecimal(dt.Rows[i]["应发工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["养老保险"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的养老保险录入不正确，请重新导入");
                                    }
                                    model.Insurance = Convert.ToDecimal(dt.Rows[i]["养老保险"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["住房公积金"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的住房公积金录入不正确，请重新导入");
                                    }
                                    model.Accumulation = Convert.ToDecimal(dt.Rows[i]["住房公积金"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["失业保险"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的失业保险录入不正确，请重新导入");
                                    }
                                    model.Unemployment = Convert.ToDecimal(dt.Rows[i]["失业保险"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["大病救助"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的大病救助录入不正确，请重新导入");
                                    }
                                    model.Serious = Convert.ToDecimal(dt.Rows[i]["大病救助"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["医保"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的医保录入不正确，请重新导入");
                                    }
                                    model.MedicalFee = Convert.ToDecimal(dt.Rows[i]["医保"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["工会扣除"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的工会扣除录入不正确，请重新导入");
                                    }
                                    model.Union = Convert.ToDecimal(dt.Rows[i]["工会扣除"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["实发工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的实发工资录入不正确，请重新导入");
                                    }
                                    model.ActualWages = Convert.ToDecimal(dt.Rows[i]["实发工资"].ToString());
                                    model.Withhold = model.Insurance + model.Accumulation + model.Unemployment + model.Serious + model.MedicalFee;
                                    model.Isdel = (int)CommonEnum.IsorNot.否;
                                    model.WFlag = (int)CommonEnum.WFlag.聘用;
                                    model.WYear = Convert.ToInt32(dt.Rows[i]["年份"].ToString());
                                    model.WMonth = Convert.ToInt32(dt.Rows[i]["月份"].ToString());
                                    model.TeachNursing = 0;
                                    model.Rewarding = 0;
                                    model.AssessWage = 0;
                                    model.Income = 0;
                                    model.RentalFee = 0;
                                    model.WDesc = "";
                                    list[i] = model;
                                }
                                else
                                {
                                    ShowMessage("该用户名：" + dt.Rows[i]["用户名"] + "不存在");
                                    return;
                                }
                            }
                            if (list != null)
                            {
                                string result = wageDAL.Import(list);
                                if (result == "")
                                {
                                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入聘用工资信息", UserID));
                                    ShowMessage();
                                }
                                else
                                {
                                    ShowMessage(result);
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
                            ShowMessage("数据获取到的列不对应");
                            return;
                        }
                    }
                    else
                    {
                        ShowMessage("数据不能为空");
                        return;
                    }
                }
                else
                {
                    ShowMessage("请选择需要上传的文件进行导入");
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


        #region 判断是否为decimal类型
        /// <summary>
        /// 判断是否为decimal类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsDecimal(string str)
        {
            bool bl = false;
            string rx = @"^(\d{1,10})(\.\d{1,2})?$";
            if (Regex.IsMatch(str, rx))
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