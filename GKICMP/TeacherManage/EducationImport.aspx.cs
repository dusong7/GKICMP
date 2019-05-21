/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年01月19日 09时41分19秒
** 描    述:      学历管理页面
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
    public partial class EducationImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

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
            string expath = @"~\Template\EducationImportTemplate.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "学历导入模板"))
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
                string name = UserID.ToString() + "_EducationImportTemplate_";
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
                    string[] needcol = { "教师姓名", "身份证", "获得学历", "获得学历的国家（地区）", "获得学历的院校或机构", "所学专业", "入学年月", "毕业年月", "是否师范类专业", "学位层次", "学位名称", "获得学位的国家（地区）", "获得学位的院校或机构", "学位授予年月", "学习方式", "在学单位类别" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                        Teacher_EducationEntity[] list = new Teacher_EducationEntity[dt.Rows.Count];
                        int i = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Teacher_EducationEntity model = new Teacher_EducationEntity();
                            if (row["身份证"].ToString() == "")
                            {
                                ShowMessage("第" + (i + 1) + "行身份证不能为空，请检查后重新导入");
                                return;
                            }
                            DataTable dt1 = teacherDAL.GetTID(row["身份证"].ToString());
                            if (dt1 == null || dt1.Rows.Count == 0)
                            {
                                ShowMessage("第" + (i + 1) + "行教师姓名为：" + row["教师姓名"].ToString() + "身份证不存在，请检查后重新导入");
                                return;
                            }
                            else
                            {
                                model.TID = dt1.Rows[0]["TID"].ToString();
                                if (row["获得学历"].ToString() == "")
                                {
                                    ShowMessage("第" + (i + 1) + "行获得学历不能为空");
                                    return;
                                }
                                if (XL(row["获得学历"].ToString()) == 0)
                                {
                                    ShowMessage("第" + (i + 1) + "行获得学历录入错误，请按照模板中给出的进行选择");
                                    return;
                                }
                                model.Education = Convert.ToInt32(XL(row["获得学历"].ToString()));
                                if (row["获得学历的国家（地区）"].ToString() == "")
                                {
                                    ShowMessage("第" + (i + 1) + "行获得学历的国家（地区）不能为空");
                                    return;
                                }
                                if (baseDataDAL.GetSDID(row["获得学历的国家（地区）"].ToString(), (int)CommonEnum.BaseDataType.国家) == 0)
                                {
                                    ShowMessage("第" + (i + 1) + "行获得学历的国家（地区）录入错误，请按照模板中给出的进行选择");
                                    return;
                                }
                                model.EduCountry = baseDataDAL.GetSDID(row["获得学历的国家（地区）"].ToString(), (int)CommonEnum.BaseDataType.国家);
                                string a = row["获得学历的院校或机构"].ToString();
                                if (row["获得学历的院校或机构"].ToString() == "")
                                {
                                    ShowMessage("第" + (i + 1) + "行获得学历的院校或机构不能为空");
                                    return;
                                }
                                model.EduSchool = row["获得学历的院校或机构"].ToString();
                                if (row["所学专业"].ToString() == "")
                                {
                                    ShowMessage("第" + (i + 1) + "行所学专业不能为空");
                                    return;
                                }
                                model.EMajor = row["所学专业"].ToString();
                                if (!IsDate(row["入学年月"].ToString()))
                                {
                                    ShowMessage("第" + (i + 1) + "行入学年月可以为空或日期格式的年月");
                                    return;
                                }
                                model.InDate = Convert.ToDateTime(row["入学年月"].ToString() == "" ? "1900-01-01" : row["入学年月"].ToString());
                                if (!IsDate(row["毕业年月"].ToString()))
                                {
                                    ShowMessage("第" + (i + 1) + "行毕业年月可以为空或日期格式的年月");
                                    return;
                                }
                                model.OutDate = Convert.ToDateTime(row["毕业年月"].ToString() == "" ? "1900-01-01" : row["毕业年月"].ToString());
                                if (row["是否师范类专业"].ToString() != CommonEnum.IsorNot.是.ToString() && row["是否师范类专业"].ToString() != CommonEnum.IsorNot.否.ToString() && row["是否师范类专业"].ToString() != "")
                                {
                                    ShowMessage("第" + (i + 1) + "行是否师范类专业录入错误，请按照模板中给出的进行选择,可以为空");
                                    return;
                                }
                                
                                model.IsTeach =row["是否师范类专业"].ToString() == "是" ?(int) CommonEnum.IsorNot.是 :row["是否师范类专业"].ToString()=="否"? (int)CommonEnum.IsorNot.否:-2;
                                if (row["学位层次"].ToString() != CommonEnum.XWCC.博士.ToString() && row["学位层次"].ToString() != CommonEnum.XWCC.硕士.ToString() && row["学位层次"].ToString() != CommonEnum.XWCC.无.ToString() && row["学位层次"].ToString() != CommonEnum.XWCC.学士.ToString() && row["学位层次"].ToString() != "")
                                {
                                    ShowMessage("第" + (i + 1) + "行学位层次录入错误，请按照模板中给出的进行选择,可以为空");
                                    return;
                                }
                                model.DegreeLevel = row["学位层次"].ToString() == "博士" ? (int)CommonEnum.XWCC.博士 : row["学位层次"].ToString() == "硕士" ? (int)CommonEnum.XWCC.硕士 : row["学位层次"].ToString() == "无" ? (int)CommonEnum.XWCC.无 : row["学位层次"].ToString() == "学士"?(int)CommonEnum.XWCC.学士:-2;
                                if (row["学位名称"].ToString() != CommonEnum.XWLB.无学位.ToString() && row["学位名称"].ToString() != CommonEnum.XWLB.学术型博士.ToString() && row["学位名称"].ToString() != CommonEnum.XWLB.学术型硕士.ToString() && row["学位名称"].ToString() != CommonEnum.XWLB.学术型学士.ToString() && row["学位名称"].ToString() != CommonEnum.XWLB.专业学位博士.ToString() && row["学位名称"].ToString() != CommonEnum.XWLB.专业学位硕士.ToString() && row["学位名称"].ToString() != CommonEnum.XWLB.专业学位学士.ToString() && row["学位名称"].ToString() != "")
                                {
                                    ShowMessage("第" + (i + 1) + "行学位名称录入错误，请按照模板中给出的进行选择,可以为空");
                                    return;
                                }
                                model.DegreeName = row["学位名称"].ToString() == "无学位" ? (int)CommonEnum.XWLB.无学位 : row["学位名称"].ToString() == "学术型博士" ? (int)CommonEnum.XWLB.学术型博士 : row["学位名称"].ToString() == "学术型硕士" ? (int)CommonEnum.XWLB.学术型硕士 : row["学位名称"].ToString() == "学术型学士" ? (int)CommonEnum.XWLB.学术型学士 : row["学位名称"].ToString() == "专业学位博士" ? (int)CommonEnum.XWLB.专业学位博士 : row["学位名称"].ToString() == "专业学位硕士" ? (int)CommonEnum.XWLB.专业学位硕士 : row["学位名称"].ToString() == "专业学位学士"?(int)CommonEnum.XWLB.专业学位学士:-2;
                                if (baseDataDAL.GetSDID(row["获得学位的国家（地区）"].ToString(), (int)CommonEnum.BaseDataType.国家) == 0 && row["获得学位的国家（地区）"].ToString() != "")
                                {
                                    ShowMessage("第" + (i + 1) + "行获得学位的国家（地区）录入错误，请按照模板中给出的进行选择,可以为空");
                                    return;
                                }
                                model.GradeCountry =row["获得学位的国家（地区）"].ToString() == "" ? -2 : baseDataDAL.GetSDID(row["获得学位的国家（地区）"].ToString(), (int)CommonEnum.BaseDataType.国家);
                                model.GradeSchool = row["获得学位的院校或机构"].ToString();
                                if (!IsDate(row["学位授予年月"].ToString()))
                                {
                                    ShowMessage("第" + (i + 1) + "行学位授予年月可以为空或日期格式的年月");
                                    return;
                                }
                                model.GrantDate = Convert.ToDateTime(row["学位授予年月"].ToString() == "" ? "1900-01-01" : row["学位授予年月"].ToString());
                                if (row["学习方式"].ToString() != CommonEnum.XXFS.半脱产.ToString() && row["学习方式"].ToString() != CommonEnum.XXFS.不脱产.ToString() && row["学习方式"].ToString() != CommonEnum.XXFS.全脱产.ToString() && row["学习方式"].ToString() != "")
                                {
                                    ShowMessage("第" + (i + 1) + "行学习方式录入错误，请按照模板中给出的进行选择,可以为空");
                                    return;
                                }
                                model.StudyType = Convert.ToInt32(row["学习方式"].ToString() == "半脱产" ?(int) CommonEnum.XXFS.半脱产 : row["学习方式"].ToString() == "不脱产" ?(int) CommonEnum.XXFS.不脱产 : row["学习方式"].ToString() == "全脱产"? (int)CommonEnum.XXFS.全脱产:-2);
                                if (baseDataDAL.GetSDID(row["在学单位类别"].ToString(), (int)CommonEnum.BaseDataType.在学单位类别) == 0 && row["在学单位类别"].ToString() != "")
                                {
                                    ShowMessage("第" + (i + 1) + "行在学单位类别录入错误，请按照模板中给出的进行选择,可以为空");
                                    return;
                                }
                                model.CompanyType =row["在学单位类别"].ToString() == "" ? -2 : baseDataDAL.GetSDID(row["在学单位类别"].ToString(), (int)CommonEnum.BaseDataType.在学单位类别);
                                model.Isdel = (int)CommonEnum.Deleted.未删除;
                                model.CreateUser = UserID;
                                model.IsReport = Convert.ToInt32(CommonEnum.IsorNot.否);
                                list[i] = model;
                                i++;
                            }
                        }
                        if (list != null)
                        {
                            string returnvalue = teacherEducation.Import(list);
                            if (returnvalue == "")
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入学历信息", UserID));
                                ShowMessage();
                            }
                            else
                            {
                                ShowMessage(returnvalue);
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


        #region 判断输入是否为日期类型
        /// <summary>   
        /// 判断输入是否为日期类型   
        /// </summary>   
        /// <param name="s">待检查数据</param>   
        /// <returns></returns>   
        public bool IsDate(string s)
        {
            try
            {
                if (s == "")
                {
                    return true;
                }
                else
                {
                    DateTime d = DateTime.Parse(s);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion



        #region 判断学历是否存在
        public int XL(string xl)
        {
            int value = 0;
            if (xl == CommonEnum.XL.博士研究生毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.博士研究生毕业);
            }
            else if (xl == CommonEnum.XL.博士研究生结业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.博士研究生结业);
            }
            else if (xl == CommonEnum.XL.博士研究生肄业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.博士研究生肄业);
            }
            else if (xl == CommonEnum.XL.大学本科毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学本科毕业);
            }
            else if (xl == CommonEnum.XL.大学本科结业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学本科结业);
            }
            else if (xl == CommonEnum.XL.大学本科肄业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学本科肄业);
            }
            else if (xl == CommonEnum.XL.大学专科毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学专科毕业);
            }
            else if (xl == CommonEnum.XL.大学专科结业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学专科结业);
            }
            else if (xl == CommonEnum.XL.大学专科肄业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学专科肄业);
            }
            else if (xl == CommonEnum.XL.硕士研究生毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.硕士研究生毕业);
            }
            else if (xl == CommonEnum.XL.硕士研究生结业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.硕士研究生结业);
            }
            else if (xl == CommonEnum.XL.硕士研究生肄业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.硕士研究生肄业); ;
            }
            else if (xl == CommonEnum.XL.中专毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.中专毕业);
            }
            else
            {
                value = 0;
            }
            return value;
        }
        #endregion
    }
}