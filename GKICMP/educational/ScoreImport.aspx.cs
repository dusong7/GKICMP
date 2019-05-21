
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace GKICMP.educational
{
    public partial class ScoreImport : PageBase
    {
        public ExamDAL examDAL = new ExamDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public Exam_SubjectDAL exam_SubjectDAL = new Exam_SubjectDAL();
        // public TermDAL termDAL = new TermDAL();
        public Exam_StudentDAL exam_StudentDAL = new Exam_StudentDAL();
        public CourseDAL courseDAL = new CourseDAL();
        // public Exam_GradesDAL exam_GradesDAL = new Exam_GradesDAL();
        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string EID
        {
            get
            {
                return GetQueryString<string>("eid", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Excel();
                //DataTable dt = exam_SubjectDAL.GetByEID(EID);
                //CommonFunction.DDlTypeBind(this.ddl_Subject, dt, "CID", "CourseName", "-2");
                if (!string.IsNullOrEmpty(EID))
                {
                    DataTable dt1 = examDAL.GetTable(EID);
                    this.ltl_Grade.Text = dt1.Rows[0]["GradeName"].ToString();
                    //  this.ltl_ProName.Text = dt1.Rows[0]["TermName"].ToString();
                    this.ltl_Term.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(dt1.Rows[0]["Term"].ToString());
                }
            }
        }

        protected void ExportExcel(DataTable dt)
        {
            //if (dt == null || dt.Rows.Count == 0) return;
            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //if (xlApp == null)
            //{
            //    return;
            //}
            //System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            //Microsoft.Office.Interop.Excel.Range range;
            //long totalCount = dt.Rows.Count;
            //long rowRead = 0;
            //float percent = 0;
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            //    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
            //    range.Interior.ColorIndex = 15;
            //    range.Font.Bold = true;
            //}
            //for (int r = 0; r < dt.Rows.Count; r++)
            //{
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
            //    }
            //    rowRead++;
            //    percent = ((float)(100 * rowRead)) / totalCount;
            //}
            //xlApp.Visible = true;
        }
        protected void lbtn_example_Click(object sender, EventArgs e)
        {

            Excel();
            //#region 使用com组件导出excel
            //DataTable dt = exam_StudentDAL.GetStuByEid(int.Parse(EID));
            //DataTable course = exam_SubjectDAL.GetByEID(EID);
            //if (dt == null || dt.Rows.Count == 0) { ShowMessage("暂无学生名单"); return; }
            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //if (xlApp == null)
            //{
            //    return;
            //}
            //System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            //Microsoft.Office.Interop.Excel.Range range;
            //long totalCount = dt.Rows.Count;
            //long rowRead = 0;
            //float percent = 0;
            //worksheet.Cells[1, 1] = "学生姓名"; range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
            //worksheet.Cells[1, 2] = "身份证号"; range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 2];
            //worksheet.Cells[1, 3] = "年级"; range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 3];
            //worksheet.Cells[1, 4] = "学期"; range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 4];
            //for (int i = 0; i < course.Rows.Count; i++)
            //{
            //    worksheet.Cells[1, i + 5] = course.Rows[i]["CourseName"]; range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 5];
            //}
            //range.Interior.ColorIndex = 15;
            //range.Font.Bold = true;
            //for (int r = 0; r < dt.Rows.Count; r++)
            //{
            //    worksheet.Cells[r + 2, 1] = dt.Rows[r][0].ToString();
            //    worksheet.Cells[r + 2, 2] = dt.Rows[r][1].ToString();
            //    worksheet.Cells[r + 2, 3] = dt.Rows[r][2].ToString();
            //    worksheet.Cells[r + 2, 4] = this.ltl_Term.Text;
            //    for (int i = 0; i < course.Rows.Count; i++)
            //    {
            //        worksheet.Cells[2, i + 5] = "";
            //    }
            //    rowRead++;
            //    percent = ((float)(100 * rowRead)) / totalCount;
            //}
            //Response.Write(workbook);
            //xlApp.Visible = true;
            //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "导出学生名单", UserID)); 
            //#endregion
        }

        public void Excel()
        {
            DataTable dt = new DataTable();
            DataTable stu = exam_StudentDAL.GetStuByEid(int.Parse(EID));
            DataTable course = exam_SubjectDAL.GetByEID(EID);
            dt.Columns.Add("学生姓名", typeof(string));
            dt.Columns.Add("身份证号", typeof(string));
            dt.Columns.Add("年级", typeof(string));
            dt.Columns.Add("班级", typeof(string));
            dt.Columns.Add("学期", typeof(string));
            foreach (DataRow dr in course.Rows)
            {
                dt.Columns.Add(dr["CourseName"].ToString(), typeof(string));
            }

            foreach (DataRow dr in stu.Rows)
            {
                List<string> list = new List<string>();
                list.Add(dr[0].ToString());
                list.Add(dr[1].ToString());
                list.Add(dr[2].ToString());
                list.Add(dr[20].ToString());
                list.Add(this.ltl_Term.Text);
                foreach (DataRow dc in course.Rows)
                {
                    list.Add("");
                }
                dt.Rows.Add(list.ToArray());
            }
            try
            {
                //string _excelName = "发货列表信息";//Excel表头名称
                //string fileName = _excelName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls"; //Excel文件名称
                //调用导出方法
                CommonFunction.ExportByWeb(dt, "", "学生成绩表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

            }
            catch (Exception ee)
            {
                string _err = ee.Message;
            }
        }


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
                string name = UserID.ToString() + "_ImportGrades_";
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
                    DataTable course = exam_SubjectDAL.GetByEID(EID);
                    // string[] needcol=;
                    List<string> needcol = new List<string>();
                    if (course != null && course.Rows.Count > 0)
                    {
                        //string[] needcol = new string[course.Rows.Count+4];

                        needcol.Add("学生姓名");
                        needcol.Add("身份证号");
                        needcol.Add("年级");
                        needcol.Add("班级");
                        needcol.Add("学期");
                        foreach (DataRow dr in course.Rows)
                        {
                            needcol.Add(dr["CourseName"].ToString());
                        }
                        // needcol = list.ToArray();
                    }
                    int count = 0;
                    for (int i = 0; i < needcol.Count; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Count)
                    {
                        //SysUserEntity[] list = new SysUserEntity[dt.Rows.Count];
                        //TeacherEntity[] tlist = new TeacherEntity[dt.Rows.Count];
                        List<Exam_StudentEntity> list = new List<Exam_StudentEntity>();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Exam_StudentEntity model = new Exam_StudentEntity();
                            for (int j = 0; j < course.Rows.Count; j++)
                            {
                                switch (course.Rows[j]["subcode"].ToString())
                                {
                                    case "1":
                                        //string A = dt.Rows[i][4 + j].ToString();
                                        model.Score1 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "2":
                                        model.Score2 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "3":
                                        model.Score3 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "4":
                                        model.Score4 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "5":
                                        model.Score5 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "6":
                                        model.Score6 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "7":
                                        model.Score7 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "8":
                                        model.Score8 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "9":
                                        model.Score9 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "10":
                                        model.Score10 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "11":
                                        model.Score11 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;
                                    case "12":
                                        model.Score12 = decimal.Parse(dt.Rows[i][5 + j].ToString()) == 0 ? -1 : decimal.Parse(dt.Rows[i][5 + j].ToString());
                                        break;

                                }
                                //model.  dr["CID"].ToString();
                            }
                            if (dt.Rows[i]["身份证号"].ToString() != "")
                            {
                                string result = sysUserDAL.GetUID(dt.Rows[i]["身份证号"].ToString());
                                if (result != "")
                                    model.StID = dt.Rows[i]["身份证号"].ToString();
                                else
                                {
                                    ShowMessage("系统中不存在身份证为：" + dt.Rows[i]["身份证号"].ToString() + ",请修改后再导入。【第" + (i + 2) + "行】");
                                    return;
                                }
                                model.EID = EID;
                            }
                            else
                            {
                                ShowMessage("身份证不能为空【第" + (i + 1) + "行】");
                                return;
                            }
                            list.Add(model);
                        }
                        if (list != null)
                        {
                            int returnvalue = exam_StudentDAL.UpdateByImport(list);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入成绩信息", UserID));
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