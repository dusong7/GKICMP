/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月4日 17时45分19秒
** 描    述:      体质健康信息导入页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.IO;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.studentmanage
{
    public partial class StuPhysicalImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public Stu_PhysicalDAL phyDAL = new Stu_PhysicalDAL();

        #region 页面初始化
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
            string expath = @"~\Template\StuPhysicalImportTemplate.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "体质健康导入模板"))
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
                string name = UserID.ToString() + "_StuPhysicalImportTemplate_";
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

        #region 提交事件
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
                    string[] needcol = { "身份证号", "姓名", "学年度", "学期", "体重", "身高", "胸围", "肺活量", "左视力", "右视力", "左听力", "右听力", "龋齿" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                        Stu_PhysicalEntity[] list = new Stu_PhysicalEntity[dt.Rows.Count];
                        int i = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            Stu_PhysicalEntity model = new Stu_PhysicalEntity();
                            if (dr["体重"].ToString() == "" || dr["身高"].ToString() == "" || dr["胸围"].ToString() == "" || dr["肺活量"].ToString() == "" || dr["左视力"].ToString() == "" || dr["右视力"].ToString() == "" || dr["左听力"].ToString() == "" || dr["右听力"].ToString() == "")
                            {
                                ShowMessage("(体重、身高、胸围、左视力、右视力、左听力、右听力以及肺活量)为必填项");
                                return;
                            }
                            model.SPID = "";
                            if (dr["身份证号"].ToString() == "" || dr["姓名"].ToString() == "" || dr["学年度"].ToString() == "" || dr["学期"].ToString() == "")
                            {
                                ShowMessage("【第" + (i + 1) + "行】有不可为空项数据为空，请检查后重新提交");
                                return;
                            }
                            string uid = sysUserDAL.GetUID(dr["身份证号"].ToString());
                            if (uid == "")
                            {
                                ShowMessage("【第" + (i + 1) + "行】系统中不存在身份证号为【" + dr["身份证号"].ToString() + "】的学生信息，请检查后重新提交");
                                return;
                            }
                            else
                            {
                                model.StuID = uid;
                            }
                            try
                            {
                                model.StuWeight = Convert.ToDecimal(dr["体重"].ToString());
                                model.StuHeight = Convert.ToDecimal(dr["身高"].ToString());
                                model.Bust = Convert.ToDecimal(dr["胸围"].ToString());
                                model.LVision = Convert.ToDecimal(dr["左视力"].ToString());
                                model.RVision = Convert.ToDecimal(dr["右视力"].ToString());
                                model.Lhearing = Convert.ToDecimal(dr["左听力"].ToString());
                                model.Rhearing = Convert.ToDecimal(dr["右听力"].ToString());
                                model.Vitalcapacity = Convert.ToDecimal(dr["肺活量"].ToString());
                            }
                            catch
                            {
                                ShowMessage("【第" + (i + 1) + "行】数据填写有误，请检查后重新提交（体重、身高、胸围、左视力、右视力、左听力、右听力以及肺活量均为数字类型，可保留两位小数）");
                                return;
                            }
                            model.DentalCaries = dr["龋齿"].ToString() == "是" ? (int)CommonEnum.IsorNot.是 : (int)CommonEnum.IsorNot.否;
                            model.Term = dr["学期"].ToString() == "上学期" ? (int)CommonEnum.XQ.上学期 : (int)CommonEnum.XQ.下学期;
                            model.EYear = dr["学年度"].ToString();
                            model.CreateUser = UserID;

                            list[i] = model;
                            i++;
                        }
                        if (list != null)
                        {
                            int returnvalue = phyDAL.Import(list);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入学生体质健康信息", UserID));
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
    }
}