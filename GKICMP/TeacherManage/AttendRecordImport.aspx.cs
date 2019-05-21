/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      刘福洲
** 创建日期:      2017年01月19日 09时41分19秒
** 描    述:      考勤管理页面
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

namespace GKICMP.teachermanage
{
    public partial class AttendRecordImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL s = new SysUserDAL();

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
            string expath = @"~\Template\AttendRecordImport.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "考勤导入模板"))
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
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, ex.Message, UserID));
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
                string name = UserID.ToString() + "_AttendRecordImportTemplate_";
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
                    string[] needcol = { "卡号", "姓名", "考勤时间", "打卡机号码", "考勤方式", "备注" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                        AttendRecordEntity[] list = new AttendRecordEntity[dt.Rows.Count];
                        int i = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            AttendRecordEntity model = new AttendRecordEntity();
                            model.ARID = "";
                            //根据教师的姓名获取工号
                            if (dr["卡号"].ToString() != "")
                            {
                                //DataTable ds = teacherDAL.GetUserNum(dr["工号"].ToString(), (int)CommonEnum.Deleted.未删除);
                                SysUserEntity models = s.GetCardNum(dr["卡号"].ToString());
                                if (models != null )
                                {
                                    model.UserNum = models.UID;
                                }
                                else
                                {
                                    ShowMessage("系统中无" + dr["卡号"].ToString() + "卡号的老师，请检查后重新上传【第" + (i + 1) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                ShowMessage("请填写工号【第" + (i + 1) + "行】");
                                return;
                            }

                            //考勤时间
                            if (dr["考勤时间"].ToString() != "")
                            {
                                try
                                {
                                    model.RecordDate = DateTime.Parse(dr["考勤时间"].ToString());
                                }
                                catch (Exception)
                                {
                                    ShowMessage("请正确填写考勤时间。【第" + (i + 1) + "行】");
                                    return;
                                }
                            }
                            else
                            {
                                ShowMessage("考勤时间不能为空【第" + (i + 1) + "行】");
                                return;
                            }

                            //打卡机号码
                            try
                            {
                                model.MachineCode = dr["打卡机号码"].ToString() == "" ? "0" : (dr["打卡机号码"].ToString());
                            }
                            catch (Exception)
                            {
                                ShowMessage("请正确填写打卡机号码，此号码为数字，若无请清空内容。【第" + (i + 1) + "行】");
                                return;
                            }

                            model.IsAnalysis = (int)CommonEnum.IsorNot.否;
                            try
                            {
                                model.AttendType = Convert.ToInt32(Enum.Parse(typeof(CommonEnum.AttendType), dr["考勤方式"].ToString()));
                            }
                            catch (Exception)
                            {
                                ShowMessage("请选择考勤方式【第" + (i + 1) + "行】");
                                return;
                            }
                            model.AttendDesc = dr["备注"].ToString();
                            list[i] = model;
                            i++;

                        }
                        if (list != null)
                        {
                            int returnvalue = attendRecordDAL.Import(list);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入考勤打卡信息", UserID));
                                ShowMessage();
                            }
                            else if (returnvalue == -2)
                            {
                                ShowMessage("导入数据中存在重复数据，请检查后重新导入");
                                return;
                            }
                            else
                            {
                                ShowMessage("提交失败");
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
                        ShowMessage("文件中缺少必要的信息，请检查后重新导入");
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

        //#region 判断输入是否为日期类型
        ///// <summary>   
        ///// 判断输入是否为日期类型   
        ///// </summary>   
        ///// <param name="s">待检查数据</param>   
        ///// <returns></returns>   
        //public bool IsDate(string s)
        //{
        //    try
        //    {
        //        DateTime d = DateTime.Parse(s);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //#endregion


        //#region 判断是否为decimal类型
        ///// <summary>
        ///// 判断是否为decimal类型
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //public bool IsDecimal(string str)
        //{
        //    bool bl = false;
        //    string rx = @"^(\d{1,10})(\.\d{1,2})?$";
        //    if (Regex.IsMatch(str, rx))
        //    {
        //        bl = true;
        //    }
        //    else
        //    {
        //        bl = false;
        //    }
        //    return bl;
        //}
        //#endregion

    }
}