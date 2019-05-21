
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
    public partial class TeachMateriaImport : PageBase
    {
        public TeachMaterialDAL teachMaterialDAL = new TeachMaterialDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public TeachMaterialVersionDAL versionDAL = new TeachMaterialVersionDAL();
        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public int CID
        {
            get
            {
                return GetQueryString<int>("cid", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 下载模板文件
        /// <summary>
        /// 下载模板文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            string expath = @"~\Template\TeachMateriaImportTemplate.xlsx";
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
                    string[] needcol = { "教材版本", "年级", "学期", "学科", "章节", "内容" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {
                        DataTable course = courseDAL.GetList();//学科列表
                        DataTable version = versionDAL.GetListAll();//版本列表
                        List<TeachMaterialImport> list = new List<TeachMaterialImport>();


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TeachMaterialImport m = new TeachMaterialImport();

                            #region 版本
                            if (dt.Rows[i]["教材版本"].ToString() == "")
                            {
                                ShowMessage("教材版本不能为空【第（" + (i + 1) + "）行】");
                                return;
                            }
                            else
                            {
                                DataRow[] ver = version.Select("VersionName='" + dt.Rows[i]["教材版本"].ToString() + "'");
                                if (ver != null && ver.Length > 0)
                                {
                                    m.TEdition = int.Parse(ver[0]["TMVID"].ToString());
                                }
                                else
                                {
                                    ShowMessage("系统中不存在教材版本名称为\"" + dt.Rows[i]["教材版本"].ToString() + "\"的信息【第" + (i + 1) + "行】");
                                    return;
                                }
                            }
                            #endregion
                            //m.TEdition = 1;//版本

                            #region 学科
                            if (dt.Rows[i]["学科"].ToString() == "")
                            {
                                m.TMCourse = CID;
                            }
                            else
                            {
                                DataRow[] drd = course.Select("CourseName='" + dt.Rows[i]["学科"].ToString() + "'");
                                if (drd != null && drd.Length > 0)
                                {
                                    m.TMCourse = int.Parse(drd[0]["CID"].ToString());
                                }
                                else
                                {
                                    ShowMessage("系统中不存在学科名称为\"" + dt.Rows[i]["学科"].ToString() + "\"的信息【第" + (i + 1) + "行】");
                                    return;
                                }
                            }
                            //m.TMCourse = 1;//学科
                            #endregion

                            #region 章节
                            if (dt.Rows[i]["章节"].ToString() == "")
                            {
                                ShowMessage("章节名称不能为空【第（" + (i + 1) + "）行】");
                                return;
                            }
                            m.ChapterName = dt.Rows[i]["章节"].ToString();
                            #endregion

                            m.TMName = dt.Rows[i]["年级"].ToString() + dt.Rows[i]["学科"].ToString() + (dt.Rows[i]["学期"].ToString() == "上学期" ? "上册" : "下册");//名称   

                            m.ChapterContent = dt.Rows[i]["内容"].ToString();

                            #region 年级
                            if (dt.Rows[i]["年级"].ToString() != "")
                            {
                                switch (dt.Rows[i]["年级"].ToString())
                                {
                                    case "一年级":
                                        m.GID = 1;
                                        break;
                                    case "二年级":
                                        m.GID = 2;
                                        break;
                                    case "三年级":
                                        m.GID = 3;
                                        break;
                                    case "四年级":
                                        m.GID = 4;
                                        break;
                                    case "五年级":
                                        m.GID = 5;
                                        break;
                                    case "六年级":
                                        m.GID = 6;
                                        break;
                                    case "七年级":
                                        m.GID = 7;
                                        break;
                                    case "八年级":
                                        m.GID = 8;
                                        break;
                                    case "九年级":
                                        m.GID = 9;
                                        break;

                                }
                            }
                            else
                            {
                                ShowMessage("年级不能为空【第（" + (i + 1) + "）行】");
                                return;
                            }
                            // m.GID =int.Parse( dt.Rows[i]["年级"].ToString());
                            #endregion
                            if (dt.Rows[i]["学期"].ToString() == "")
                            {
                                ShowMessage("学期不能为空【第（" + (i + 1) + "）行】");
                                return;
                            }
                            m.TermID = dt.Rows[i]["学期"].ToString() == "上学期" ? (int)CommonEnum.XQ.上学期 : (int)CommonEnum.XQ.下学期;
                            m.CreateDate = DateTime.Now;
                            m.CreateUser = UserID;
                            m.Isdel = (int)CommonEnum.IsorNot.否;
                            list.Add(m);
                        }
                        if (list != null)
                        {

                            string returnvalue = teachMaterialDAL.Import(list);
                            if (returnvalue == "0")
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入教材信息", UserID));
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
                            }
                            else if (returnvalue == "-1")
                            {
                                ShowMessage("保存失败");
                                return;
                            }

                            else 
                            {
                                ShowMessage("系统中已存在：" + returnvalue + "教材信息");
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
    }
}