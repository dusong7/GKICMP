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
namespace GKICMP.teachermanage
{
    public partial class TeacherClassHourImport : PageBase
    {
        public Teacher_ClassHourDAL teacher_ClassHourDAL = new Teacher_ClassHourDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public CourseDAL courseDAL = new CourseDAL();

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
            string expath = @"~\Template\TeacherClassHourImport.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "教师课时导入模板"))
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
            ////string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties=Excel 8.0;HDR=Yes;IMEX=1'";
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties='Excel 8.0;'";
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
                string name = UserID.ToString() + "_TeacherClassHourImportTemplate_";
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
                    string[] needcol = { "学年度", "学期", "姓名","身份证号", "所授年级", "主教学科", "主纯课时数", "兼教学科", "兼纯课时数", "语文、数学、英语跨教情况", "任行政或班主任情况","备注" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                        Teacher_ClassHourEntity[] list = new Teacher_ClassHourEntity[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["姓名"].ToString().Trim() != "")
                            {
                                Teacher_ClassHourEntity model = new Teacher_ClassHourEntity();
                                model.THID = "";
                                //姓名
                               // DataTable sd = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
                                if (dt.Rows[i]["身份证号"].ToString().Trim() != "")
                                {
                                    //DataTable dttid = teacherDAL.GetTID(CommonFunction.Encrypt(dt.Rows[i]["身份证号"].ToString()));
                                    DataTable dttid = teacherDAL.GetTID(dt.Rows[i]["身份证号"].ToString());
                                    if (dttid != null && dttid.Rows.Count > 0)
                                    {
                                        //model.TID = dttid.Rows[0]["UID"].ToString();
                                        model.TID = dttid.Rows[0]["TID"].ToString();
                                    }
                                    else 
                                    {
                                        ShowMessage("系统中不存在此身份证号:" + dt.Rows[i]["身份证号"].ToString() + "【第" + (i + 1) + "行】"); return;
                                    }
                                }
                                else
                                {
                                    ShowMessage("身份证号不能为空【第"+(i+1)+"行】"); return;
                                }
                               
                                model.SchoolYear = dt.Rows[i]["学年度"].ToString().Trim();
                                //学期
                                try
                                {
                                    model.Semester = Convert.ToInt32(Enum.Parse(typeof(CommonEnum.XQ), dt.Rows[i]["学期"].ToString().Trim()));
                                }
                                catch
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["学期"].ToString() + "的学期信息，请修改后重新导入【第" + (i+1) + "行】");
                                    return;
                                }

                                //所授年级
                                int gd = gradeDAL.GetGIDByName(dt.Rows[i]["所授年级"].ToString(), (int)CommonEnum.Deleted.未删除);
                                if (gd == -1 )
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["所授年级"].ToString() + "的年级，请修改后重新导入【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.GradeID = gd;

                                //主教学科
                                DataTable ms = courseDAL.GetCourseByWhere("and isdel=0 and CourseName='" + dt.Rows[i]["主教学科"].ToString() + "' or CourseOther='"+ dt.Rows[i]["主教学科"].ToString() + "'");
                                if (ms == null || ms.Rows.Count <= 0)
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["主教学科"].ToString() + "的学科，请修改后重新导入【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.MainSubject = ms.Rows[0]["CID"].ToString();

                                //兼教学科
                                //string ps = sysDataDAL.GetSDIDByName(dt.Rows[i]["兼教学科"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学科);
                                //if (ps == "-1")
                                //{
                                //    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["兼教学科"].ToString() + "的学科，请修改后重新导入【第" + (i + 1) + "行】");
                                //    return;
                                //}
                                model.PartSubject = dt.Rows[i]["兼教学科"].ToString();

                                try
                                {
                                    model.MainHours = Convert.ToInt32(dt.Rows[i]["主纯课时数"].ToString());
                                }
                                catch (Exception)
                                {
                                   ShowMessage("请填写正确的主纯课时数（课时数为数字）请修改后重新导入【第" + (i + 1) + "行】");
                                   return;
                                }
                                try
                                {
                                    model.PartHours = Convert.ToInt32(dt.Rows[i]["兼纯课时数"].ToString() == "" ? "0" : dt.Rows[i]["兼纯课时数"].ToString());
                                }
                                catch (Exception)
                                {
                                  ShowMessage("请填写正确的兼纯课时数（课时数为数字）请修改后重新导入【第" + (i + 1) + "行】");
                                  return;
                                }
                                model.SubDesc = dt.Rows[i]["语文、数学、英语跨教情况"].ToString();
                                model.Executive = Convert.ToInt32(dt.Rows[i]["任行政或班主任情况"].ToString());
                                model.THDesc = dt.Rows[i]["备注"].ToString();
                               
                                model.Isdel = (int)CommonEnum.Deleted.未删除;
                                model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报
                                list[i] = model;
                            }
                            else
                            {
                                ShowMessage("姓名不能为空【第" + (i + 1) + "行】");
                                return;
                            }
                        }

                        if (list != null)
                        {
                            int returnvalue = teacher_ClassHourDAL.Import(list);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入教师课时信息", UserID));
                                ShowMessage();
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

    }
}