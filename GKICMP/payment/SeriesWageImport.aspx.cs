/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年01月19日 09时41分19秒
** 描    述:      在编工资导入
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
    public partial class SeriesWageImport : PageBase
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
            string expath = @"~\Template\WageTemplateZB.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "在编工资导入模板"))
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
                string name = UserID.ToString() + "_WageTemplateZB_";
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
                        string[] needcol = { "用户名", "年份", "月份", "岗位工资", "薪级工资", "教龄津贴", "教护", "基础性绩效工资", "奖励性绩效工资", "提租补贴", "20%工资", "公积金", "失业保险", "医保费", "养老保险", "工会费", "考核工资", "个人所得税", "实发工资", "备注" };
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
                                    if (model1.IsSeries == (int)CommonEnum.IsorNot.否)
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "不是在编老师，请重新导入");
                                        return;
                                    }
                                    WageEntity model = new WageEntity();
                                    if (!IsNum(dt.Rows[i]["年份"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的年份录入不正确，请重新导入");
                                        return;
                                    }
                                    model.TID = model1.UID;
                                    model.WYear = Convert.ToInt32(dt.Rows[i]["年份"].ToString());
                                    if (!IsNum(dt.Rows[i]["月份"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的月份只能在1-12月录入不正确，请重新导入");
                                        return;
                                    }
                                    model.WMonth = Convert.ToInt32(dt.Rows[i]["月份"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["岗位工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的岗位工资录入不正确，请重新导入");
                                        return;
                                    }
                                    model.PostWage = Convert.ToDecimal(dt.Rows[i]["岗位工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["薪级工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的薪级工资录入不正确，请重新导入");
                                    }
                                    model.SalaryScale = Convert.ToDecimal(dt.Rows[i]["薪级工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["教龄津贴"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的教龄津贴录入不正确，请重新导入");
                                    }
                                    model.Allowance = Convert.ToDecimal(dt.Rows[i]["教龄津贴"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["教护"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的教护录入不正确，请重新导入");
                                    }
                                    model.TeachNursing = Convert.ToDecimal(dt.Rows[i]["教护"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["基础性绩效工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的基础性绩效工资录入不正确，请重新导入");
                                    }
                                    model.BasicPay = Convert.ToDecimal(dt.Rows[i]["基础性绩效工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["奖励性绩效工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的奖励性绩效工资录入不正确，请重新导入");
                                    }
                                    model.Rewarding = Convert.ToDecimal(dt.Rows[i]["奖励性绩效工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["提租补贴"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的提租补贴录入不正确，请重新导入");
                                    }
                                    model.RentalFee = Convert.ToDecimal(dt.Rows[i]["提租补贴"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["20%工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的20%工资录入不正确，请重新导入");
                                    }
                                    model.Serious = Convert.ToDecimal(dt.Rows[i]["20%工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["养老保险"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的养老保险录入不正确，请重新导入");
                                    }
                                    model.Insurance = Convert.ToDecimal(dt.Rows[i]["养老保险"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["公积金"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的公积金录入不正确，请重新导入");
                                    }
                                    model.Accumulation = Convert.ToDecimal(dt.Rows[i]["公积金"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["失业保险"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的失业保险录入不正确，请重新导入");
                                    }
                                    model.Unemployment = Convert.ToDecimal(dt.Rows[i]["失业保险"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["医保费"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的医保费录入不正确，请重新导入");
                                    }
                                    model.MedicalFee = Convert.ToDecimal(dt.Rows[i]["医保费"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["养老保险"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的养老保险录入不正确，请重新导入");
                                    }
                                    model.Insurance = Convert.ToDecimal(dt.Rows[i]["养老保险"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["工会费"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的工会费录入不正确，请重新导入");
                                    }
                                    model.Union = Convert.ToDecimal(dt.Rows[i]["工会费"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["考核工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的考核工资录入不正确，请重新导入");
                                    }
                                    model.AssessWage = Convert.ToDecimal(dt.Rows[i]["考核工资"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["个人所得税"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的个人所得税录入不正确，请重新导入");
                                    }
                                    model.Income = Convert.ToDecimal(dt.Rows[i]["个人所得税"].ToString());
                                    if (!IsDecimal(dt.Rows[i]["实发工资"].ToString()))
                                    {
                                        ShowMessage("用户名为：" + dt.Rows[i]["用户名"].ToString() + "的实发工资录入不正确，请重新导入");
                                    }
                                    model.ActualWages = Convert.ToDecimal(dt.Rows[i]["实发工资"].ToString());
                                    model.WDesc = dt.Rows[i]["备注"].ToString();
                                    model.ShouldWage = model.PostWage + model.SalaryScale + model.Allowance + model.TeachNursing + model.BasicPay + model.Rewarding + model.RentalFee + model.Serious;
                                    model.Withhold = model.Insurance + model.Accumulation + model.Unemployment + model.Union + model.MedicalFee + model.AssessWage + model.Income;
                                    model.Isdel = (int)CommonEnum.IsorNot.否;
                                    model.WFlag = (int)CommonEnum.WFlag.在编;
                                    list[i] = model;
                                }
                                else
                                {
                                    ShowMessage("该用户名不存在");
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