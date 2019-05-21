
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09时20分16秒
** 描    述:      公共方法类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Services.Description;
using System.Text;
using System.Web;
using System.Configuration;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Net;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Cells;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GK.GKICMP.Common
{
    public class CommonFunction
    {
        public static SysDataDAL sysDataDAL = new SysDataDAL();
        public static BaseDataDAL baseDataDAL = new BaseDataDAL();
        public static Exam_RoomDAL roomDAL = new Exam_RoomDAL();
        public static Exam_SubjectDAL subjectDAL = new Exam_SubjectDAL();
        public static Exam_TeacherDAL teacherDAL = new Exam_TeacherDAL();

        #region SQL关键字
        /// <summary>
        /// SQL关键字
        /// </summary>
        /// <param name="charString">关键字</param>
        /// <returns></returns>
        public static string GetCommoneString(string charString)
        {
            if (charString.IndexOf('%') >= 0)
            {
                return charString.Replace("%", "[%]").Replace("[", "[[]").Replace("_", "[_]");
            }

            return charString;
        }
        #endregion


        #region 检查枚举绑定
        /// <summary>
        /// 检查枚举绑定
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="checkedValue">被检查的值</param>
        /// <returns></returns>
        public static string CheckEnum<T>(object checkedValue)
        {
            try
            {
                return Enum.Parse(typeof(T), checkedValue.ToString().Trim()).ToString();
            }
            catch
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 绑定下拉列表枚举数据源
        /// </summary>
        /// <typeparam name="T">枚举源</typeparam>
        /// <param name="ddlControl">被绑定的控件</param>
        public static void BindEnum<T>(DropDownList ddlControl, string firstvalue)
        {
            Type enumSource = typeof(T);
            if (firstvalue == "-99")
            {

            }
            else
            {
                ddlControl.Items.Add(new ListItem("--请选择--", firstvalue));
            }
            foreach (int itemValue in Enum.GetValues(enumSource))
            {
                ddlControl.Items.Add(new ListItem(Enum.GetName(enumSource, itemValue), itemValue.ToString()));
            }
        }

        /// <summary>
        /// 绑定单选列表枚举数据源
        /// </summary>
        /// <typeparam name="T">枚举源</typeparam>
        /// <param name="rblControl">被绑定的控件</param>
        public static void BindEnum<T>(RadioButtonList rblControl)
        {
            Type enumSource = typeof(T);

            foreach (int itemValue in Enum.GetValues(enumSource))
            {
                rblControl.Items.Add(new ListItem(Enum.GetName(enumSource, itemValue), itemValue.ToString()));
            }
        }
        #endregion


        #region 导出excel
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        public static void ExportExcel(string fileName, string text)
        {
            try
            {
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Charset = "GB2312";//设置字符集，解决中文乱码问题
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=\"text/html;charset=GB2312\">");//解决乱码问题
                //解决HTTP头中文乱码问题
                string strExcelText = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");//Excel显示的内容
                string strEncode = System.Web.HttpUtility.UrlEncode(strExcelText, System.Text.Encoding.UTF8);//进行编码的格式,用gb2312出错
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=\"" + strEncode + ".xls\"");//对保存标题进行编码
                HttpContext.Current.Response.ContentType = "application/vnd.xls";//设置输出格式
                HttpContext.Current.Response.Write(@"<html><head><style>.content {border-top: 1pt solid #2e5ac5; border-right: 1pt solid #9DB3C5;}
                                    .content th {height:30px;line-height:30px;font-weight:bold;border-bottom: 1pt solid #9DB3C5;border-left: 1pt solid #2e5ac5;background:#fff;}
                                    .content td {line-height:26px;color:#333;border-left: 1pt solid #9DB3C5;border-bottom: 1pt solid #9DB3C5;background:#fff;}
                                    .content tr {text-align:center;}
                                    </style></head><body>");
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                htw.WriteLine(text);//将数据输出
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.Write("</body></html>");
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch
            {
                return;
            }
        }
        #endregion



        #region 上传文件

        public static AccessoryEntity upfile(int start, int end, HiddenField hfcount, string uploadpath, SysSetConfigEntity model)
        {
            int upsize = 140000000;
            try
            {
                upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
            }
            catch (Exception) { }

            //清空隐藏控件的值，用于存放路径，以便数据保存失败时删除文件
            //if (hfcount == null)
            //{
            //    hfcount.Value = "";
            //}
            //设置文件夹的名称
            string attaname = "";
            string attaurl = "";
            //设置上传路径
            //string pname = "~/webupload/" + System.DateTime.Now.ToString("yyyyMM") + "/";
            //string pname = "~/webupload/" + uploadpath + "/";
            string pname = "/webupload/" + uploadpath + "/";
            string path = System.Web.HttpContext.Current.Server.MapPath(pname);
            //string pathmark = System.Web.HttpContext.Current.Server.MapPath(pname);
            AccessoryEntity attainfo = null;

            //判断上传文件夹是否存在，若不存在，则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(path.Replace(uploadpath, uploadpath + "WaterMark")))
            {
                Directory.CreateDirectory(path.Replace(uploadpath, uploadpath + "WaterMark"));
            }
            //遍历页面中的上传控件
            HttpFileCollection files = HttpContext.Current.Request.Files;
            for (int i = start; i < end; i++)
            {
                HttpPostedFile postedFile = files[i];
                if (postedFile.FileName != "")
                {
                    string a = Path.GetFileName(postedFile.FileName);

                    string[] name = postedFile.FileName.ToString().Split('\\');
                    string[] filename = name[name.Length - 1].ToString().Split('.');
                    //获取上传文件的名称
                    string oglname = filename[0].ToString();
                    for (int o = 1; o < filename.Length - 1; o++)
                    {
                        oglname += "." + filename[o].ToString();
                    }
                    attaname += oglname + ",";
                    //为上传的文件设置新的名称，防止重名
                    string newname = System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + i.ToString();
                    newname = newname + "." + filename[filename.Length - 1];
                    //设置完整的文件上传路径
                    string filepath = path + newname;
                    string serverPath = pname + newname;
                    if (postedFile.ContentLength < upsize)
                    {
                        postedFile.SaveAs(filepath);
                        if (model.WatermarkType == 1)
                        {
                            if (filename[1].ToString() == "xls" || filename[1].ToString() == "xlsx")
                            {
                                WaterMark.InsertExcelWatermarkText(serverPath, serverPath.Replace(uploadpath, uploadpath + "WaterMark"), model.WatermarkContent);
                            }
                            if (filename[1].ToString() == "doc" || filename[1].ToString() == "docx" || filename[1].ToString() == "wps")
                            {
                                WaterMark.InsertWordWatermarkText(serverPath, serverPath.Replace(uploadpath, uploadpath + "WaterMark"), model.WatermarkContent);
                            }
                            if (filename[1].ToString() == "jpg" || filename[1].ToString() == "png" || filename[1].ToString() == "jpeg" || filename[1].ToString() == "bmp")
                            {
                                WaterMark.AddImageSignText(serverPath, serverPath.Replace(uploadpath, uploadpath + "WaterMark"), model.WatermarkContent, 9, 50, "宋体", 50);
                            }
                            File.Delete(filepath);
                        }
                        else if (model.WatermarkType == 2)
                        {
                            if (filename[1].ToString() == "xls" || filename[1].ToString() == "xls")
                            {
                                WaterMark.InsertExcelWatermarkPic(serverPath, serverPath.Replace(uploadpath, uploadpath + "WaterMark"), model.WatermarkContent);
                            }
                            if (filename[1].ToString() == "doc" || filename[1].ToString() == "docx" || filename[1].ToString() == "docx")
                            {
                                WaterMark.InsertWordWatermarkPic(serverPath, serverPath.Replace(uploadpath, uploadpath + "WaterMark"), model.WatermarkContent);
                            }
                            if (filename[1].ToString() == "jpg" || filename[1].ToString() == "png" || filename[1].ToString() == "jpeg" || filename[1].ToString() == "bmp")
                            {
                                WaterMark.AddImageSignPic(serverPath, serverPath.Replace(uploadpath, uploadpath + "WaterMark"), model.WatermarkContent, 9, 50, 15);
                            }
                            File.Delete(filepath);
                        }

                        if (hfcount != null)
                        {
                            hfcount.Value += filepath + "$";
                        }

                        int j = filepath.IndexOf("webupload");
                        string str = filepath.Substring(j - 1);
                        attaurl += str + ",";
                    }
                    else
                    {
                        attainfo = new AccessoryEntity();
                        attainfo.AccessID = "-2";
                        attainfo.AccessName = "上传失败，上传文件不能大于" + upsize / 1000000 + "M！";
                        return attainfo;
                    }
                }
            }

            attaname = (attaname + "$").Replace(",$", "");
            attaurl = (attaurl + "$").Replace(",$", "");
            if (attaname != "$" && attaurl != "$" && attainfo == null)
            {
                if (model.WatermarkType == 1 || model.WatermarkType == 2)
                    attainfo = new AccessoryEntity(attaname, attaurl.Replace(uploadpath, uploadpath + "WaterMark"));
                else
                    attainfo = new AccessoryEntity(attaname, attaurl);
            }
            else
            {
                attainfo = new AccessoryEntity();
            }
            return attainfo;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件名</param>
        /// <param name="mark">标识</param>
        /// <param name="filepath">文件存放路径</param>
        /// <returns></returns>
        public static AccessoryEntity upfile(int start, int end, HiddenField hfcount, string uploadpath)
        {
            int upsize = 140000000;
            try
            {
                upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
            }
            catch (Exception) { }

            //清空隐藏控件的值，用于存放路径，以便数据保存失败时删除文件
            //if (hfcount == null)
            //{
            //    hfcount.Value = "";
            //}
            //设置文件夹的名称
            string attaname = "";
            string attaurl = "";
            //设置上传路径
            //string pname = "~/webupload/" + System.DateTime.Now.ToString("yyyyMM") + "/";
            //string pname = "~/webupload/" + uploadpath + "/";
            string pname = "/webupload/" + uploadpath + "/";
            string path = System.Web.HttpContext.Current.Server.MapPath(pname);

            AccessoryEntity attainfo = null;

            //判断上传文件夹是否存在，若不存在，则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //遍历页面中的上传控件
            HttpFileCollection files = HttpContext.Current.Request.Files;
            for (int i = start; i < end; i++)
            {
                HttpPostedFile postedFile = files[i];
                if (postedFile.FileName != "")
                {
                    string a = Path.GetFileName(postedFile.FileName);

                    string[] name = postedFile.FileName.ToString().Split('\\');
                    string[] filename = name[name.Length - 1].ToString().Split('.');
                    //获取上传文件的名称
                    string oglname = filename[0].ToString();
                    for (int o = 1; o < filename.Length - 1; o++)
                    {
                        oglname += "." + filename[o].ToString();
                    }
                    attaname += oglname + ",";
                    //为上传的文件设置新的名称，防止重名
                    string newname = System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + i.ToString();
                    newname = newname + "." + filename[filename.Length - 1];
                    //设置完整的文件上传路径
                    string filepath = path + newname;

                    if (postedFile.ContentLength < upsize)
                    {
                        //Stream postStream = postedFile.InputStream;
                        postedFile.SaveAs(filepath);
                        if (hfcount != null)
                        {
                            hfcount.Value += filepath + "$";
                        }

                        int j = filepath.IndexOf("webupload");
                        string str = filepath.Substring(j - 1);
                        attaurl += str + ",";
                    }
                    else
                    {
                        attainfo = new AccessoryEntity();
                        attainfo.AccessID = "-2";
                        attainfo.AccessName = "上传失败，上传文件不能大于" + upsize / 1000000 + "M！";
                        return attainfo;
                    }
                }
            }

            attaname = (attaname + "$").Replace(",$", "");
            attaurl = (attaurl + "$").Replace(",$", "");
            if (attaname != "$" && attaurl != "$" && attainfo == null)
            {
                attainfo = new AccessoryEntity(attaname, attaurl);
            }
            else
            {
                attainfo = new AccessoryEntity();
            }
            return attainfo;
        }

        public static AccessoryEntity upfile(int start, int end, HiddenField hfcount)
        {
            int upsize = 30000000;
            try
            {
                upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
            }
            catch (Exception) { }

            //清空隐藏控件的值，用于存放路径，以便数据保存失败时删除文件
            if (hfcount != null)
            {
                hfcount.Value = "";
            }
            //设置文件夹的名称
            string attaname = "";
            string attaurl = "";
            //设置上传路径
            string pname = "/uploadfile/" + System.DateTime.Now.ToString("yyyyMM") + "/";
            //string pname = "~/uploadfile/" + System.DateTime.Now.ToString("yyyyMM") + "/";
            // string pname = "/webupload/" + uploadpath + "/";
            string path = System.Web.HttpContext.Current.Server.MapPath(pname);

            AccessoryEntity attainfo = null;

            //判断上传文件夹是否存在，若不存在，则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //遍历页面中的上传控件
            HttpFileCollection files = HttpContext.Current.Request.Files;
            for (int i = start; i < end; i++)
            {
                HttpPostedFile postedFile = files[i];
                if (postedFile.FileName != "")
                {
                    string a = Path.GetFileName(postedFile.FileName);

                    string[] name = postedFile.FileName.ToString().Split('\\');
                    string[] filename = name[name.Length - 1].ToString().Split('.');
                    //获取上传文件的名称
                    string oglname = filename[0].ToString();
                    for (int o = 1; o < filename.Length - 1; o++)
                    {
                        oglname += "." + filename[o].ToString();
                    }
                    attaname += oglname + ",";
                    //为上传的文件设置新的名称，防止重名
                    string newname = System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + i.ToString();
                    newname = newname + "." + filename[filename.Length - 1];
                    //设置完整的文件上传路径
                    string filepath = path + newname;

                    if (postedFile.ContentLength < upsize)
                    {
                        postedFile.SaveAs(filepath);
                        if (hfcount != null)
                        {
                            hfcount.Value += filepath + "$";
                        }

                        int j = filepath.IndexOf("uploadfile");
                        string str = filepath.Substring(j - 1);
                        attaurl += str + ",";
                    }
                    else
                    {
                        attainfo = new AccessoryEntity();
                        attainfo.AccessID = "-2";
                        attainfo.AccessName = "上传失败，上传文件不能大于" + upsize / 1000000 + "M！";
                        return attainfo;
                    }
                }
            }

            attaname = (attaname + "$").Replace(",$", "");
            attaurl = (attaurl + "$").Replace(",$", "");
            if (attaname != "$" && attaurl != "$" && attainfo == null)
            {
                attainfo = new AccessoryEntity(attaname, attaurl);
            }
            else
            {
                attainfo = new AccessoryEntity();
            }
            return attainfo;
        }

        public static AccessoryEntity upfileTest(int start, int end, HiddenField hfcount, string uploadpath)
        {
            // int upsize = 140000000;

            Stopwatch sp = new Stopwatch();
            sp.Start();

            string attaname = "";
            string attaurl = "";
            //设置上传路径
            //string pname = "~/webupload/" + System.DateTime.Now.ToString("yyyyMM") + "/";
            //string pname = "~/webupload/" + uploadpath + "/";
            string pname = "/webupload/" + uploadpath + "/";
            string path = System.Web.HttpContext.Current.Server.MapPath(pname);

            AccessoryEntity attainfo = null;

            //判断上传文件夹是否存在，若不存在，则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //遍历页面中的上传控件
            HttpFileCollection files = HttpContext.Current.Request.Files;
            for (int i = start; i < end; i++)
            {
                HttpPostedFile postedFile = files[i];
                if (postedFile.FileName != "")
                {
                    string a = Path.GetFileName(postedFile.FileName);

                    string[] name = postedFile.FileName.ToString().Split('\\');
                    string[] filename = name[name.Length - 1].ToString().Split('.');
                    //获取上传文件的名称
                    string oglname = filename[0].ToString();
                    for (int o = 1; o < filename.Length - 1; o++)
                    {
                        oglname += "." + filename[o].ToString();
                    }
                    attaname += oglname + ",";
                    //为上传的文件设置新的名称，防止重名
                    string newname = System.DateTime.Now.ToString("yyyyMMddHHmmssffff") + i.ToString();
                    newname = newname + "." + filename[filename.Length - 1];
                    //设置完整的文件上传路径
                    string filepath = path + newname;

                    if (postedFile.ContentLength < 1024000000)
                    {
                        Stopwatch sp1 = new Stopwatch();
                        sp1.Start();
                        Stream postStream = postedFile.InputStream;
                        sp1.Stop();
                        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "流运行时间：" + sp1.ElapsedMilliseconds.ToString(), ""));
                        Stopwatch sp2 = new Stopwatch();
                        sp2.Start();
                        //ImageThumbnail.GetPicThumbnail(postStream, filepath, 540, 960, 100);
                        ImageThumbnail.ReduceImage(postStream, filepath, 50);
                        sp2.Stop();
                        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "压缩保存运行时间：" + sp2.ElapsedMilliseconds.ToString(), ""));
                        // postedFile.SaveAs(filepath);
                        if (hfcount != null)
                        {
                            hfcount.Value += filepath + "$";
                        }

                        int j = filepath.IndexOf("webupload");
                        string str = filepath.Substring(j - 1);
                        attaurl += str + ",";
                    }
                    else
                    {
                        attainfo = new AccessoryEntity();
                        attainfo.AccessID = "-2";
                        attainfo.AccessName = "上传失败，上传文件过大";
                        return attainfo;
                    }
                }
            }

            attaname = (attaname + "$").Replace(",$", "");
            attaurl = (attaurl + "$").Replace(",$", "");
            if (attaname != "$" && attaurl != "$" && attainfo == null)
            {
                attainfo = new AccessoryEntity(attaname, attaurl);
            }
            else
            {
                attainfo = new AccessoryEntity();
            }
            sp.Stop();
            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "总运行时间：" + sp.ElapsedMilliseconds.ToString(), ""));
            return attainfo;
        }

        #endregion
        #region 下载
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool UpLoadFunciotn(string path, string filename)
        {
            try
            {
                string filekind = Path.GetExtension(path);
                string name = filename + filekind;
                //提供下载的文件并且编码
                string fileName = HttpContext.Current.Server.UrlEncode(name);
                fileName = fileName.Replace("+", "%20");
                string filePath = HttpContext.Current.Server.MapPath(path);
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                    HttpContext.Current.Response.BinaryWrite(bytes);
                    HttpContext.Current.Response.Flush();
                    //HttpContext.Current.Response.End();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            //if (path != "")
            //{
            //    // string filekind = path.Substring(path.Length - 4, 4);
            //    string filekind = Path.GetExtension(path);
            //    string name = filename + filekind;
            //    //提供下载的文件并且编码
            //    string fileName = HttpContext.Current.Server.UrlEncode(name);
            //    fileName = fileName.Replace("+", "%20");
            //    string filePath = HttpContext.Current.Server.MapPath(path);
            //    FileInfo info = new FileInfo(filePath);
            //    if (info.Exists)
            //    {
            //        long fileSize = info.Length;
            //        HttpContext.Current.Response.Clear();
            //        HttpContext.Current.Response.Charset = "utf-8";
            //        HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            //        //Response.ContentType = "application/msword";
            //        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            //        //不指明Content-Length用Flush的话不会显示下载进度     
            //        HttpContext.Current.Response.AddHeader("Content-Length", fileSize.ToString());
            //        HttpContext.Current.Response.TransmitFile(filePath, 0, fileSize);
            //        HttpContext.Current.Response.Flush();
            //        HttpContext.Current.Response.Close();
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
        }
        #endregion

        #region 文件大小转化(byte\Kb\Mb\G)
        /// <summary>
        /// 文件大小转化(byte\Kb\Mb\G)
        /// </summary>
        /// <param name="Size">文件大小（byte）</param>
        /// <returns></returns>
        public static string CountSize(long Size)
        {
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + "Byte";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + "K";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + "M";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + "G";
            return m_strSize;
        }
        #endregion

        #region 删除上传的文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">路径</param>
        public static void delfile(string path)
        {
            string[] upfile = path.Split('$');
            for (int i = 0; i < upfile.Length; i++)
            {
                if (System.IO.File.Exists(upfile[i].ToString()))
                {
                    System.IO.File.Delete(upfile[i].ToString());
                }
            }
        }
        #endregion


        #region 绑定下拉框数据源（含请选择）
        /// <summary>
        /// 绑定下拉框数据源
        /// </summary>
        /// <param name="ddlControl"></param>
        /// <param name="dv">数据源</param>
        /// <param name="valuename">绑定值</param>
        /// <param name="textname">显示字段</param>
        /// <param name="firstvalue">请选择默认值</param>
        public static void DDlTypeBind(DropDownList ddlControl, DataTable dv, string valuename, string textname, string firstvalue)
        {
            ddlControl.Items.Clear();
            if (firstvalue != "-999")
            {
                ddlControl.Items.Add(new ListItem("--请选择--", firstvalue));
            }
            if (dv != null && dv.Rows.Count > 0)
            {
                foreach (DataRow row in dv.Rows)
                {
                    ddlControl.Items.Add(new ListItem(row[textname].ToString().Length > 10 ? row[textname].ToString().Substring(0, 10).TrimEnd(',') + "..." : row[textname].ToString(), row[valuename].ToString()));
                }
            }

        }
        public static void DDlTypeBind(DropDownList ddlControl, DataRow[] dv, string valuename, string textname, string firstvalue)
        {
            ddlControl.Items.Clear();
            if (firstvalue != "-999")
            {
                ddlControl.Items.Add(new ListItem("--请选择--", firstvalue));
            }
            if (dv != null && dv.Length > 0)
            {
                foreach (DataRow row in dv)
                {
                    ddlControl.Items.Add(new ListItem(row[textname].ToString().Length > 10 ? row[textname].ToString().Substring(0, 10).TrimEnd(',') + "..." : row[textname].ToString(), row[valuename].ToString()));
                }
            }

        }
        public static void DDlTypeBindLength(DropDownList ddlControl, DataTable dv, string valuename, string textname, string firstvalue)
        {
            ddlControl.Items.Clear();
            if (firstvalue != "-999")
            {
                ddlControl.Items.Add(new ListItem("--请选择--", firstvalue));
            }
            if (dv != null && dv.Rows.Count > 0)
            {
                foreach (DataRow row in dv.Rows)
                {
                    ddlControl.Items.Add(new ListItem(row[textname].ToString().Length > 50 ? row[textname].ToString().Substring(0, 50).TrimEnd(',') + "..." : row[textname].ToString(), row[valuename].ToString()));
                }
            }

        }
        #endregion


        /// <summary>
        /// 绑定基础数据
        /// </summary>
        /// <param name="ddlControl"></param>
        /// <param name="flag"></param>
        public static void DDlDataBaseBind(DropDownList ddlControl, int flag, string firstvalue)
        {

            //DataTable dv = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, flag, -1);
            // DataTable dv = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, flag);
            DataTable dv = baseDataDAL.GetList(flag, -1);

            ddlControl.Items.Clear();
            if (firstvalue == "-999")
            {
                ddlControl.Items.Add(new ListItem("--请选择--", "-2"));
            }
            if (dv != null && dv.Rows.Count > 0)
            {
                foreach (DataRow row in dv.Rows)
                {
                    ddlControl.Items.Add(new ListItem(row["DataName"].ToString().Length > 10 ? row["DataName"].ToString().Substring(0, 10).TrimEnd(',') + "..." : row["DataName"].ToString(), row["SDID"].ToString()));
                }
            }

        }


        ///// <summary>
        ///// 绑定多级基础数据
        ///// </summary>
        ///// <param name="ddlControl"></param>
        ///// <param name="flag"></param>
        //public static void DDlPidTypeBind(DropDownList ddlControl, int flag)
        //{

        //    DataTable dv = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, flag, -1);

        //    ddlControl.Items.Clear();

        //    ddlControl.Items.Add(new ListItem("--请选择--", "-2"));

        //    if (dv != null && dv.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dv.Rows)
        //        {
        //            ddlControl.Items.Add(new ListItem(row["SDID"].ToString().Length > 10 ? row["SDID"].ToString().Substring(0, 10).TrimEnd(',') + "..." : row["SDID"].ToString(), row["DataName"].ToString()));
        //            DataTable dv1 = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, flag, Convert.ToInt32(row["SDID"].ToString()));
        //            if (dv1 != null && dv1.Rows.Count > 0)
        //            {
        //                foreach (DataRow row1 in dv1.Rows)
        //                {
        //                    ddlControl.Items.Add(new ListItem("--" + row1["DataName"].ToString(), row1["SDID"].ToString()));
        //                }
        //            }

        //        }
        //    }

        //}

        #region 绑定下拉框数据源（含请选择）
        /// <summary>
        /// 绑定下拉框数据源
        /// </summary>
        /// <param name="ddlControl"></param>
        /// <param name="dv">数据源</param>
        /// <param name="valuename">绑定值</param>
        /// <param name="textname">显示字段</param>
        /// <param name="firstvalue">请选择默认值</param>
        public static void CBLTypeBind(CheckBoxList CBLControl, DataTable dv, string valuename, string textname)
        {
            CBLControl.Items.Clear();

            if (dv != null && dv.Rows.Count > 0)
            {
                foreach (DataRow row in dv.Rows)
                {
                    CBLControl.Items.Add(new ListItem(row[textname].ToString(), row[valuename].ToString()));
                }
            }

        }
        #endregion


        #region 绑定下拉框数据源（含请选择）
        /// <summary>
        /// 绑定下拉框数据源
        /// </summary>
        /// <param name="ddlControl"></param>
        /// <param name="dv">数据源</param>
        /// <param name="valuename">绑定值</param>
        /// <param name="textname">显示字段</param>
        /// <param name="firstvalue">请选择默认值</param>
        public static void CBLRoleBind(RadioButtonList rblControl, DataTable dv, string valuename, string textname)
        {
            rblControl.Items.Clear();

            if (dv != null && dv.Rows.Count > 0)
            {
                foreach (DataRow row in dv.Rows)
                {
                    rblControl.Items.Add(new ListItem(row[textname].ToString(), row[valuename].ToString()));
                }
            }

        }
        #endregion


        #region 加密、解密
        private static readonly string KEY = "gk.sismp";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">被加密的字符串</param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            try
            {
                using (MemoryStream encryptStream = new MemoryStream())
                {
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

                    desProvider.IV = ASCIIEncoding.UTF8.GetBytes(KEY);
                    desProvider.Key = ASCIIEncoding.UTF8.GetBytes(KEY);

                    using (CryptoStream cryptoStream = new CryptoStream(encryptStream, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] encryptBuffer = Encoding.UTF8.GetBytes(encryptString);

                        cryptoStream.Write(encryptBuffer, 0, encryptBuffer.Length);
                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }

                    StringBuilder encryptBuilder = new StringBuilder();

                    foreach (byte encryptByte in encryptStream.ToArray())
                    {
                        encryptBuilder.AppendFormat("{0:X2}", encryptByte);
                    }

                    encryptStream.Close();
                    return encryptBuilder.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">被解密的字符串</param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            try
            {
                using (MemoryStream decryptStream = new MemoryStream())
                {
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

                    desProvider.IV = ASCIIEncoding.ASCII.GetBytes(KEY);
                    desProvider.Key = ASCIIEncoding.ASCII.GetBytes(KEY);

                    using (CryptoStream cryptoStream = new CryptoStream(decryptStream, desProvider.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        int decryptStringCount = decryptString.Length / 2;
                        byte[] decryptBuffer = new byte[decryptStringCount];

                        for (int x = 0; x < decryptStringCount; x++)
                        {
                            int i = (Convert.ToInt32(decryptString.Substring(x * 2, 2), 16));
                            decryptBuffer[x] = (byte)i;
                        }

                        cryptoStream.Write(decryptBuffer, 0, decryptBuffer.Length);
                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }

                    decryptStream.Close();
                    return Encoding.UTF8.GetString(decryptStream.ToArray());
                }
            }
            catch
            {
                return string.Empty;
            }
        }


        #endregion

        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            //if ((classname == null) || (classname == ""))
            //{
            //    classname = WebServiceHelper.GetWsClassName(url);
            //}

            try
            {
                //获取WSDL  
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);

                //生成客户端代理类代码  
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                ICodeCompiler icc = csc.CreateCompiler();

                //设定编译参数  
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类  
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                //生成代理实例，并调用方法  
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodname);

                return mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }



        #region 将文件转换为byte数组
        /// <summary>
        /// 将文件转换为byte数组
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] File2Bytes(string savepath)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(savepath);
            if (!System.IO.File.Exists(path))
            {
                return new byte[0];
            }

            FileInfo fi = new FileInfo(path);
            byte[] buff = new byte[fi.Length];

            FileStream fs = fi.OpenRead();
            fs.Read(buff, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            return buff;
        }
        #endregion
        #region 将byte数组转换为文件并保存到指定地址
        /// <summary>
        /// 将byte数组转换为文件并保存到指定地址
        /// </summary>
        /// <param name="buff">byte数组</param>
        /// <param name="savepath">保存地址</param>
        public static void Bytes2File(byte[] buff, string savepath)
        {
            string a = System.Web.HttpContext.Current.Server.MapPath(savepath);
            string path = a.Substring(0, a.LastIndexOf("\\"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (System.IO.File.Exists(savepath))
            {
                System.IO.File.Delete(savepath);
            }
            FileStream fs = new FileStream(a, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buff, 0, buff.Length);
            bw.Close();
            fs.Close();
        }
        #endregion

        #region 从Xml中获取日期计算两个日期相差的周数
        /// <summary>
        /// 从Xml中获取日期计算两个日期相差的周数
        /// </summary>
        /// <param name="dt">现在的日期</param>
        /// <param name="fliepath">xml文件路径</param>
        /// <param name="nodes">xml文件节点</param>
        /// <returns>返回周数</returns>
        public static int Weeks(DateTime dt, string fliepath, string nodes)
        {
            string date = XMLHelper.GetXmlNodes(fliepath, nodes);
            //if (dt.Year == Convert.ToDateTime(date).Year)
            //{
            //    GregorianCalendar gc = new GregorianCalendar();
            //    int fweekOfYear = gc.GetWeekOfYear(DateTime.Parse(date), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            //    int sweekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            //    return (sweekOfYear - fweekOfYear)+1;
            //}
            //else 
            //{
            int count = 0;
            DateTime p = Convert.ToDateTime(date);
            while (p <= dt)
            {
                if (p.DayOfWeek == DayOfWeek.Sunday)
                    count++;
                p = p.AddDays(1);

            }
            if (dt.DayOfWeek != DayOfWeek.Sunday)
                count += 1;
            return count;

            //TimeSpan ts = dt.Subtract(Convert.ToDateTime(date));
            //return (ts.Days / 7)+2;
            //}
        }
        public static int Weeks(DateTime dt, DateTime begin)
        {

            int count = 0;
            while (begin <= dt)
            {
                if (begin.DayOfWeek == DayOfWeek.Sunday)
                    count++;
                begin = begin.AddDays(1);

            }
            if (dt.DayOfWeek != DayOfWeek.Sunday)
                count += 1;
            return count;

            //TimeSpan ts = dt.Subtract(Convert.ToDateTime(date));
            //return (ts.Days / 7)+2;
            //}
        }
        #endregion

        #region 使用npoi导出excel

        #region Excel导出方法 ExportByWeb(dtSource,strHeaderText,strFileName)
        /// <summary>
        /// Excel导出方法 ExportByWeb()
        /// </summary>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="strHeaderText">Excel表头文本（例如：车辆列表）</param>
        /// <param name="strFileName">Excel文件名（例如：车辆列表.xls）</param>
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText).GetBuffer());
            curContext.Response.End();
        }
        #endregion


        #region DataTable导出到Excel文件 Export(dtSource,strHeaderText,strFileName)
        /// <summary>
        /// DataTable导出到Excel文件 Export()
        /// </summary>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="strHeaderText">Excel表头文本（例如：车辆列表）</param>
        /// <param name="strFileName">保存位置</param>
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }
        #endregion

        #region DataTable导出到Excel的MemoryStream Export(dtSource,strHeaderText)
        /// <summary>
        /// DataTable导出到Excel的MemoryStream Export()
        /// </summary>
        /// <param name="dtSource">DataTable数据源</param>
        /// <param name="strHeaderText">Excel表头文本（例如：车辆列表）</param>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = System.DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length + 5;
            }
            //for (int i = 0; i < dtSource.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtSource.Columns.Count; j++)
            //    {
            //        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
            //        if (intTemp > arrColWidth[j])
            //        {
            //            arrColWidth[j] = intTemp + 3;
            //        }
            //    }
            //}
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    if (strHeaderText != "")
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER; // ------------------
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1)); // ------------------
                    }
                    #endregion

                    #region 列头及样式
                    {
                        IRow headerRow;
                        if (strHeaderText != "")
                            headerRow = sheet.CreateRow(1);
                        else
                            headerRow = sheet.CreateRow(0);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER; // ------------------
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 12;
                        font.FontName = "宋体";
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }


                    #endregion
                    if (strHeaderText != "")
                        rowIndex = 2;
                    else
                        rowIndex = 1;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                //ICellStyle contentStyle = workbook.CreateCellStyle();
                //{
                //    contentStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER; // ------------------
                //    IFont font = workbook.CreateFont();
                //    font.FontHeightInPoints = 12;
                //    font.FontName = "宋体";
                //    //  font.Boldweight = 700;
                //    contentStyle.SetFont(font);
                //}
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);
                    //newCell.CellStyle = contentStyle;
                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            System.DateTime dateV;
                            System.DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                ms.Dispose();
                return ms;
            }
        }
        #endregion

        #region 读取excel ,默认第一行为标头Import()
        /// <summary>
        /// 读取excel ,默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        #endregion
        #endregion

        #region txt文件加密解密
        private static readonly string KEY1 = "@GK.QFWH";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">被加密的字符串</param>
        /// <returns></returns>
        public static string EncryptTxt(string encryptString)
        {
            try
            {
                using (MemoryStream encryptStream = new MemoryStream())
                {
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

                    desProvider.IV = ASCIIEncoding.UTF8.GetBytes(KEY1);
                    desProvider.Key = ASCIIEncoding.UTF8.GetBytes(KEY1);

                    using (CryptoStream cryptoStream = new CryptoStream(encryptStream, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] encryptBuffer = Encoding.UTF8.GetBytes(encryptString);

                        cryptoStream.Write(encryptBuffer, 0, encryptBuffer.Length);
                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }

                    StringBuilder encryptBuilder = new StringBuilder();

                    foreach (byte encryptByte in encryptStream.ToArray())
                    {
                        encryptBuilder.AppendFormat("{0:X2}", encryptByte);
                    }

                    encryptStream.Close();
                    return encryptBuilder.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">被解密的字符串</param>
        /// <returns></returns>
        public static string DecryptTxt(string decryptString)
        {
            try
            {
                using (MemoryStream decryptStream = new MemoryStream())
                {
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

                    desProvider.IV = ASCIIEncoding.ASCII.GetBytes(KEY1);
                    desProvider.Key = ASCIIEncoding.ASCII.GetBytes(KEY1);

                    using (CryptoStream cryptoStream = new CryptoStream(decryptStream, desProvider.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        int decryptStringCount = decryptString.Length / 2;
                        byte[] decryptBuffer = new byte[decryptStringCount];

                        for (int x = 0; x < decryptStringCount; x++)
                        {
                            int i = (Convert.ToInt32(decryptString.Substring(x * 2, 2), 16));
                            decryptBuffer[x] = (byte)i;
                        }

                        cryptoStream.Write(decryptBuffer, 0, decryptBuffer.Length);
                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }

                    decryptStream.Close();
                    return Encoding.UTF8.GetString(decryptStream.ToArray());
                }
            }
            catch
            {
                return string.Empty;
            }
        }


        #endregion


        public static void ImportWord(DataTable dt, string path, string name)
        {
            string fielname = System.Web.HttpContext.Current.Server.MapPath(path);
            Document docz = new Document();
            foreach (DataRow dr in dt.Rows)
            {

                Document doc = new Document(fielname);
                // doc.MailMerge.ExecuteWithRegions(dt);
                doc.Range.Replace("@SchoolName", dr["SchoolName"].ToString(), false, false);
                doc.Range.Replace("@Year", dr["Year"].ToString(), false, false);
                doc.Range.Replace("@Term", dr["Term"].ToString(), false, false);
                doc.Range.Replace("@DateType", dr["DateType"].ToString(), false, false);
                doc.Range.Replace("@Addr", dr["Addr"].ToString(), false, false);
                doc.Range.Replace("@zjr", dr["AddrText"].ToString(), false, false);
                doc.Range.Replace("@Tid", dr["Tid"].ToString(), false, false);
                doc.Range.Replace("@dd", dr["TidText"].ToString(), false, false);


                doc.Range.Replace("@pdate", dr["pdate"].ToString(), false, false);
                doc.Range.Replace("@ActivityAddress", dr["ActivityAddress"].ToString(), false, false);
                doc.Range.Replace("@AContent", dr["AContent"].ToString(), false, false);
                //doc.Range.Replace("@ActivityTarget", dr["ActivityTarget"].ToString(), false, false);
                // doc.Range.Replace("@ActivityPre", dr["ActivityPre"].ToString(), false, false);
                // doc.Range.Replace("@AContent", dt.Rows[0]["AContent1"].ToString(), false, false);
                //doc.Range.Replace("@pdate", dt.Rows[0]["pdate"].ToString(), false, false);
                //建立DocumentBuilder物件 
                DocumentBuilder builder = new DocumentBuilder(doc);
                //新增文字
                builder.MoveToBookmark("ActivityContent");
                builder.InsertHtml(dr["ActivityContent"].ToString().Trim());
                builder.MoveToBookmark("ActivityTarget");
                builder.InsertHtml(dr["ActivityTarget"].ToString().Trim());
                builder.MoveToBookmark("ActivityPre");
                builder.InsertHtml(dr["ActivityPre"].ToString().Trim());

                Shape shape = new Shape(doc, ShapeType.Image);
                shape.Width = 16;
                shape.Height = 16;
                shape.ImageData.SetImage(GetMapPath("~/gzimages/bk.png"));
                //if (doc.Range.Bookmarks["Pic"] == null)
                //{
                builder.MoveToBookmark("Pic");
                builder.InsertNode(shape);
                //}
                //將上述設定的格式清除
                builder.Font.ClearFormatting();
                //將文件存檔
                //doc.Save("D://Test.doc");
                //将照片写入标签【此处不用域】
                //DocumentBuilder builder = new DocumentBuilder(doc);
                //Shape shape = new Shape(doc, ShapeType.Image);
                //shape.ImageData.SetImage("");
                //shape.Width = 91;
                //shape.Height = 95;
                //shape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Center;
                //if (doc.Range.Bookmarks["photo"] != null)
                //{
                //    builder.MoveToBookmark("photo");
                //    builder.InsertNode(shape);
                //}
                docz.AppendDocument(doc, ImportFormatMode.UseDestinationStyles);

            }
            DeleteFile(path);
            var docStream = new MemoryStream();
            docz.Save(docStream, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));

            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/msword";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(name, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(docStream.GetBuffer());
            curContext.Response.End();


            // return base.File(docStream.ToArray(), "application/msword", "Template.doc");
            // doc.Save( name + "的人事信息.doc", SaveOptions.CreateSaveOptions(SaveFormat.Doc));


        }

        public static void ImportWordBGD(DataTable dt, DataTable dtpy, DataTable dtzh, DataTable dtstsz, DataTable dtjc, DataTable dtkcxx, string path, string name, int ps, int qz, int zh)
        {
            string fielname = System.Web.HttpContext.Current.Server.MapPath(path);
            Document docz = new Document();
            foreach (DataRow dr in dt.Rows)
            {
                Document doc = new Document(fielname);
                // doc.MailMerge.ExecuteWithRegions(dt);

                #region 基本信息
                doc.Range.Replace("@xnb", dr["xnb"].ToString(), false, false);
                doc.Range.Replace("@xue", dr["xne"].ToString(), false, false);
                doc.Range.Replace("@term", dr["term"].ToString(), false, false);
                doc.Range.Replace("@school", dr["school"].ToString(), false, false);
                doc.Range.Replace("@grade", dr["grade"].ToString(), false, false);
                doc.Range.Replace("@class", dr["class"].ToString(), false, false);
                doc.Range.Replace("@name", dr["name"].ToString(), false, false);
                doc.Range.Replace("@Num", dr["Num"].ToString(), false, false);

                doc.Range.Replace("@class", dr["class"].ToString(), false, false);
                doc.Range.Replace("@name", dr["name"].ToString(), false, false);
                doc.Range.Replace("@Num", dr["Num"].ToString(), false, false);

                doc.Range.Replace("@bmouth", dr["bmouth"].ToString().Split('-')[1], false, false);
                doc.Range.Replace("@bday", dr["bmouth"].ToString().Split('-')[2], false, false);
                doc.Range.Replace("@mos", dr["emouth"].ToString().Split('-')[1], false, false);
                doc.Range.Replace("@eday", dr["emouth"].ToString().Split('-')[2], false, false);

                doc.Range.Replace("@year", DateTime.Now.ToString("yyyy-MM-dd").Split('-')[0], false, false);
                doc.Range.Replace("@mouth", DateTime.Now.ToString("yyyy-MM-dd").Split('-')[1], false, false);
                doc.Range.Replace("@day", DateTime.Now.ToString("yyyy-MM-dd").Split('-')[2], false, false);
                #endregion

                #region 评语
                DataRow[] drarr = dtpy.Select("stuid='" + dr["stid"].ToString() + "'");
                string aa = "";
                foreach (DataRow d in drarr)
                {
                    aa += d["Evaluate"].ToString() + ",";
                }
                doc.Range.Replace("@py", aa.TrimEnd(','), false, false);
                #endregion

                #region 综合评价
                DataRow[] drzh = dtzh.Select("stid='" + dr["stid"].ToString() + "'");
                if (drzh != null && drzh.Length > 0)
                {
                    string v = drzh[0]["SXDD"].ToString();
                    string g = drzh[0]["QFXX"].ToString();
                    doc.Range.Replace("@sxdd", drzh[0]["SXDD"].ToString() == null ? "" : drzh[0]["SXDD"].ToString(), false, false);
                    doc.Range.Replace("@qfxx", drzh[0]["QFXX"].ToString() == null ? "" : drzh[0]["QFXX"].ToString(), false, false);
                    doc.Range.Replace("@stsz", drzh[0]["STSZ"].ToString() == null ? "" : drzh[0]["STSZ"].ToString(), false, false);
                    doc.Range.Replace("@smsm", drzh[0]["SMSMNL"].ToString() == null ? "" : drzh[0]["SMSMNL"].ToString(), false, false);
                    doc.Range.Replace("@shld", drzh[0]["SHLDJN"].ToString() == null ? "" : drzh[0]["SHLDJN"].ToString(), false, false);
                    doc.Range.Replace("@cxjs", drzh[0]["CZJSCZNL"].ToString() == null ? "" : drzh[0]["CZJSCZNL"].ToString(), false, false);
                }
                else
                {
                    doc.Range.Replace("@sxdd", "", false, false);
                    doc.Range.Replace("@qfxx", "", false, false);
                    doc.Range.Replace("@stsz", "", false, false);
                    doc.Range.Replace("@smsm", "", false, false);
                    doc.Range.Replace("@shld", "", false, false);
                    doc.Range.Replace("@cxjs", "", false, false);
                }
                #endregion

                #region 身体素质
                DataRow[] drstsz = dtstsz.Select("stuid='" + dr["stid"].ToString() + "'");
                if (drstsz != null && drstsz.Length > 0)
                {
                    doc.Range.Replace("@tz", drstsz[0]["StuWeight"].ToString() == null ? "" : drstsz[0]["StuWeight"].ToString(), false, false);
                    doc.Range.Replace("@sg", drstsz[0]["StuHeight"].ToString() == null ? "" : drstsz[0]["StuHeight"].ToString(), false, false);
                    doc.Range.Replace("@xw", drstsz[0]["Bust"].ToString() == null ? "" : drstsz[0]["Bust"].ToString(), false, false);
                    doc.Range.Replace("@sll", drstsz[0]["LVision"].ToString() == null ? "" : drstsz[0]["LVision"].ToString(), false, false);
                    doc.Range.Replace("@slr", drstsz[0]["RVision"].ToString() == null ? "" : drstsz[0]["RVision"].ToString(), false, false);
                    doc.Range.Replace("@ltl", drstsz[0]["Lhearing"].ToString() == null ? "" : drstsz[0]["Lhearing"].ToString(), false, false);
                    doc.Range.Replace("@rtl", drstsz[0]["Rhearing"].ToString() == null ? "" : drstsz[0]["Rhearing"].ToString(), false, false);
                    doc.Range.Replace("@fhl", drstsz[0]["Vitalcapacity"].ToString() == null ? "" : drstsz[0]["Vitalcapacity"].ToString(), false, false);
                    doc.Range.Replace("@qc", drstsz[0]["DentalCaries"].ToString() == null ? "" : drstsz[0]["DentalCaries"].ToString(), false, false);
                    doc.Range.Replace("@tc", "", false, false);
                }
                else
                {
                    doc.Range.Replace("@tz", "", false, false);
                    doc.Range.Replace("@sg", "", false, false);
                    doc.Range.Replace("@xw", "", false, false);
                    doc.Range.Replace("@sll", "", false, false);
                    doc.Range.Replace("@slr", "", false, false);
                    doc.Range.Replace("@ltl", "", false, false);
                    doc.Range.Replace("@rtl", "", false, false);
                    doc.Range.Replace("@fhl", "", false, false);
                    doc.Range.Replace("@qc", "", false, false);
                    doc.Range.Replace("@tc", "", false, false);
                }
                #endregion

                #region 奖惩
                DataRow[] drjc = dtjc.Select("stuid='" + dr["stid"].ToString() + "'");
                if (drjc != null && drjc.Length > 0)
                {
                    string jc = "";
                    foreach (DataRow j in drjc)
                    {
                        jc += Convert.ToDateTime(j["RDate"]).ToString("yyyy-MM-dd") + "获得" + j["RewardName"].ToString() + ",";
                    }
                    doc.Range.Replace("@jc", jc.TrimEnd(','), false, false);
                }
                else
                {
                    doc.Range.Replace("@jc", "", false, false);
                }
                #endregion

                #region 学科课程学习状况
                //平时
                DataRow[] drLps = dtkcxx.Select("stid='" + dr["StID"].ToString() + "' and eid=" + ps);
                //期终
                DataRow[] drLqz = dtkcxx.Select("stid='" + dr["StID"].ToString() + "' and eid=" + qz);
                //综合
                DataRow[] drLzh = dtkcxx.Select("stid='" + dr["StID"].ToString() + "' and eid=" + zh);
                if (drLps != null && drLps.Length > 0)
                {
                    #region 绑定课程值
                    foreach (DataRow Levelps in drLps)
                    {
                        switch (Levelps["CName"].ToString())
                        {
                            case "语文":
                                doc.Range.Replace("@ydps", Levelps["Level"].ToString(), false, false);
                                doc.Range.Replace("@zwps", Levelps["Level"].ToString(), false, false);
                                doc.Range.Replace("@xzps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "数学":
                                doc.Range.Replace("@sxps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "英语":
                                doc.Range.Replace("@yyps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "品德":
                                doc.Range.Replace("@spps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "科学":
                                doc.Range.Replace("@kxps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "劳动":
                                doc.Range.Replace("@ldps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "社会":
                                doc.Range.Replace("@shps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "音乐":
                                doc.Range.Replace("@musicps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "体育":
                                doc.Range.Replace("@typs", Levelps["Level"].ToString(), false, false);
                                break;
                            case "美术":
                                doc.Range.Replace("@msps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "计算机初步":
                                doc.Range.Replace("@jsjps", Levelps["Level"].ToString(), false, false);
                                break;
                            case "健康教育":
                                doc.Range.Replace("@jkjyps", Levelps["Level"].ToString(), false, false);
                                break;
                        }
                        #region 课程(第二种)
                        //    if (kc["CName"].ToString() == "语文")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            string vvv = kc["fs"].ToString();
                        //            //阅读
                        //            doc.Range.Replace("@ydps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //            //作文说话
                        //            doc.Range.Replace("@zwps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //            //写字
                        //            doc.Range.Replace("@xzps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }
                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@ydqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //            doc.Range.Replace("@zwqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //            doc.Range.Replace("@xzqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }
                        //        if (kc["EID"].ToString() == Convert.ToString(zh))
                        //        {
                        //            doc.Range.Replace("@ydzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //            doc.Range.Replace("@zwzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //            doc.Range.Replace("@xzzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }
                        //    }

                        //    if (kc["CName"].ToString() == "数学")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@sxps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@sxqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))  //综合等级
                        //        {
                        //            doc.Range.Replace("@sxzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "英语")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@yyps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }
                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@yyqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }
                        //        if (kc["EID"].ToString() == Convert.ToString(zh))//综合等级
                        //        {
                        //            doc.Range.Replace("@yyzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }
                        //    }

                        //    if (kc["CName"].ToString() == "品德")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@spps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@spqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@spzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "科学")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@kxps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@kxqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);
                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@kxzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "劳动")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@ldps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@ldqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@ldzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "社会")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@shps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@shqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@shzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "音乐")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@musicps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@musicqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@musiczh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "体育")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@typs", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@tyqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@tyzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "美术")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@msps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@msqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@mszh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "计算机初步")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@jsjps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@jsjqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@jsjzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //    if (kc["CName"].ToString() == "健康教育")
                        //    {
                        //        if (kc["EID"].ToString() == Convert.ToString(ps))//平时等级
                        //        {
                        //            doc.Range.Replace("@jkjyps", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //        if (kc["EID"].ToString() == Convert.ToString(qz))//期中等级
                        //        {
                        //            doc.Range.Replace("@jkjyqz", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }


                        //        if (kc["EID"].ToString() == Convert.ToString(zh))   //综合等级
                        //        {
                        //            doc.Range.Replace("@jkjyzh", kc["fs"].ToString() == null ? "" : kc["fs"].ToString(), false, false);

                        //        }

                        //    }

                        //}
                        //    #endregion
                        #endregion
                    }
                    #endregion
                }
                if (drLqz != null && drLqz.Length > 0)
                {
                    #region 绑定课程值
                    foreach (DataRow Levelqz in drLqz)
                    {
                        switch (Levelqz["CName"].ToString())
                        {
                            case "语文":
                                doc.Range.Replace("@ydqz", Levelqz["Level"].ToString(), false, false);
                                doc.Range.Replace("@zwqz", Levelqz["Level"].ToString(), false, false);
                                doc.Range.Replace("@xzqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "数学":
                                doc.Range.Replace("@sxqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "英语":
                                doc.Range.Replace("@yyqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "品德":
                                doc.Range.Replace("@spqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "科学":
                                doc.Range.Replace("@kxqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "劳动":
                                doc.Range.Replace("@ldqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "社会":
                                doc.Range.Replace("@shqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "音乐":
                                doc.Range.Replace("@musicqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "体育":
                                doc.Range.Replace("@tyqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "美术":
                                doc.Range.Replace("@msqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "计算机初步":
                                doc.Range.Replace("@jsjqz", Levelqz["Level"].ToString(), false, false);
                                break;
                            case "健康教育":
                                doc.Range.Replace("@jkjyqz", Levelqz["Level"].ToString(), false, false);
                                break;
                        }
                    }
                    #endregion
                }
                if (drLzh != null && drLzh.Length > 0)
                {
                    #region 绑定课程值
                    foreach (DataRow Levelzh in drLzh)
                    {
                        switch (Levelzh["CName"].ToString())
                        {
                            case "语文":
                                doc.Range.Replace("@ydzh", Levelzh["Level"].ToString(), false, false);
                                doc.Range.Replace("@zwzh", Levelzh["Level"].ToString(), false, false);
                                doc.Range.Replace("@xzzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "数学":
                                doc.Range.Replace("@sxzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "英语":
                                doc.Range.Replace("@yyzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "品德":
                                doc.Range.Replace("@spzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "科学":
                                doc.Range.Replace("@kxzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "劳动":
                                doc.Range.Replace("@ldzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "社会":
                                doc.Range.Replace("@shzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "音乐":
                                doc.Range.Replace("@musiczh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "体育":
                                doc.Range.Replace("@tyzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "美术":
                                doc.Range.Replace("@mszh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "计算机初步":
                                doc.Range.Replace("@jsjzh", Levelzh["Level"].ToString(), false, false);
                                break;
                            case "健康教育":
                                doc.Range.Replace("@jkjyzh", Levelzh["Level"].ToString(), false, false);
                                break;
                        }
                    }
                    #endregion
                }

                #region 赋初始值值为空
                doc.Range.Replace("@spps", "", false, false);
                doc.Range.Replace("@spqz", "", false, false);
                doc.Range.Replace("@spzh", "", false, false);

                doc.Range.Replace("@ydps", "", false, false);
                doc.Range.Replace("@ydqz", "", false, false);
                doc.Range.Replace("@ydzh", "", false, false);

                doc.Range.Replace("@zwps", "", false, false);
                doc.Range.Replace("@zwqz", "", false, false);
                doc.Range.Replace("@zwzh", "", false, false);

                doc.Range.Replace("@xzps", "", false, false);
                doc.Range.Replace("@xzqz", "", false, false);
                doc.Range.Replace("@xzzh", "", false, false);

                doc.Range.Replace("@sxps", "", false, false);
                doc.Range.Replace("@sxqz", "", false, false);
                doc.Range.Replace("@sxzh", "", false, false);

                doc.Range.Replace("@yyps", "", false, false);
                doc.Range.Replace("@yyqz", "", false, false);
                doc.Range.Replace("@yyzh", "", false, false);

                doc.Range.Replace("@kxps", "", false, false);
                doc.Range.Replace("@kxqz", "", false, false);
                doc.Range.Replace("@kxzh", "", false, false);

                doc.Range.Replace("@ldps", "", false, false);
                doc.Range.Replace("@ldqz", "", false, false);
                doc.Range.Replace("@ldzh", "", false, false);

                doc.Range.Replace("@shps", "", false, false);
                doc.Range.Replace("@shqz", "", false, false);
                doc.Range.Replace("@shzh", "", false, false);

                doc.Range.Replace("@musicps", "", false, false);
                doc.Range.Replace("@musicqz", "", false, false);
                doc.Range.Replace("@musiczh", "", false, false);

                doc.Range.Replace("@typs", "", false, false);
                doc.Range.Replace("@tyqz", "", false, false);
                doc.Range.Replace("@tyzh", "", false, false);

                doc.Range.Replace("@msps", "", false, false);
                doc.Range.Replace("@msqz", "", false, false);
                doc.Range.Replace("@mszh", "", false, false);

                doc.Range.Replace("@jsjps", "", false, false);
                doc.Range.Replace("@jsjqz", "", false, false);
                doc.Range.Replace("@jsjzh", "", false, false);

                doc.Range.Replace("@jkjyps", "", false, false);
                doc.Range.Replace("@jkjyqz", "", false, false);
                doc.Range.Replace("@jkjyzh", "", false, false);

                #endregion
                #endregion

                docz.AppendDocument(doc, ImportFormatMode.UseDestinationStyles);
            }

            DeleteFile(path);
            var docStream = new MemoryStream();
            docz.Save(docStream, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));

            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/msword";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(docStream.GetBuffer());
            curContext.Response.End();


            // return base.File(docStream.ToArray(), "application/msword", "Template.doc");
            // doc.Save( name + "的人事信息.doc", SaveOptions.CreateSaveOptions(SaveFormat.Doc));


        }


        #region 导出考场座位表
        public static void ImportWordKCZWB(DataTable dts, string path, string name, int EID)
        {
            string fielname = System.Web.HttpContext.Current.Server.MapPath(path);
            Document docz = new Document(fielname);

            //用户表结构
            DataTable dt1 = new DataTable("All");
            dt1.Columns.Add(new DataColumn("Id", typeof(int)));
            dt1.Columns.Add("no", typeof(string));
            if (dts != null && dts.Rows.Count > 0)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    var row = dt1.NewRow();
                    row["Id"] = i;
                    row["no"] = dts.Rows[i]["KCH"];
                    dt1.Rows.Add(row);
                }
            }
            //分数表结构
            DataTable dt2 = new DataTable("Item");
            dt2.Columns.Add(new DataColumn("UserId", typeof(int)));
            dt2.Columns.Add("UIDName", typeof(string));
            dt2.Columns.Add("ClassName", typeof(string));
            dt2.Columns.Add("KCH", typeof(string));
            dt2.Columns.Add("ERID", typeof(string));

            if (dts != null && dts.Rows.Count > 0)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    int recordCount = 0;
                    ExamEntity model = new ExamEntity();
                    model.EID = EID;
                    DataTable dt = roomDAL.GetPageZWH(int.MaxValue, 1, ref recordCount, model, Convert.ToInt32(dts.Rows[i]["KCH"]));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            var rowt = dt2.NewRow();
                            rowt["UserId"] = i;
                            rowt["UIDName"] = dt.Rows[j]["UIDName"];
                            rowt["ClassName"] = dt.Rows[j]["ClassName"];
                            rowt["KCH"] = dt.Rows[j]["KCH"];
                            rowt["ERID"] = dt.Rows[j]["ERID"];
                            dt2.Rows.Add(rowt);
                        }
                    }
                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Relations.Add(new DataRelation("ScoreListForUser", dt1.Columns["Id"], dt2.Columns["UserId"]));
            docz.MailMerge.ExecuteWithRegions(ds);
            //docz.AppendDocument(doc, ImportFormatMode.UseDestinationStyles); 
            DeleteFile(path);
            var docStream = new MemoryStream();
            docz.Save(docStream, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));

            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/msword";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(docStream.GetBuffer());
            curContext.Response.End();
            // return base.File(docStream.ToArray(), "application/msword", "Template.doc");
            // doc.Save( name + "的人事信息.doc", SaveOptions.CreateSaveOptions(SaveFormat.Doc));  

        }

        #endregion


        #region 导出监考表
        public static void ImportWordJKB(string path, string name, int EID)
        {
            string fielname = System.Web.HttpContext.Current.Server.MapPath(path);
            Document docz = new Document(fielname);
            //用户表结构
            DataTable dt1 = new DataTable("All");
            dt1.Columns.Add("no", typeof(string));
            DataRow row1 = dt1.NewRow();


            DataTable dtsubject = subjectDAL.GetByEID(EID.ToString());
            StringBuilder str = new StringBuilder();
            if (dtsubject != null && dtsubject.Rows.Count > 0)
            {
                row1["no"] = dtsubject.Rows[0]["GName"].ToString() + dtsubject.Rows[0]["EYear"].ToString() + "年度" + CommonFunction.CheckEnum<CommonEnum.XQ>(Convert.ToInt32(dtsubject.Rows[0]["Term"].ToString())) + dtsubject.Rows[0]["ExamName"] + "监考表";
                dt1.Rows.Add(row1);
                //建立DocumentBuilder物件 
                DocumentBuilder builder = new DocumentBuilder(docz);
                builder.MoveToDocumentEnd();
                builder.StartTable();
                builder.InsertCell();
                builder.CellFormat.Width = 25;
                builder.Write("");
                //builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
                //builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

                foreach (DataRow dtsubjectrow in dtsubject.Rows)
                {
                    builder.InsertCell();
                    builder.CellFormat.Width = 100;
                    builder.Write(dtsubjectrow["CourseName"].ToString() + Convert.ToDateTime(dtsubjectrow["BeginDate"]).ToString("MM-dd HH:mm") + "-" + Convert.ToDateTime(dtsubjectrow["EndDate"]).ToString("HH:mm"));
                }
                builder.EndRow();
                DataTable dtteacher = teacherDAL.GetByEID(EID.ToString());
                if (dtteacher != null && dtteacher.Rows.Count > 0)
                {
                    int x = 0;
                    for (int i = 1; i <= dtteacher.Rows.Count; i++)
                    {
                        if (i % dtsubject.Rows.Count == 1 && x == 0)
                        {
                            builder.InsertCell();
                            builder.CellFormat.Width = 25;
                            builder.Write(dtteacher.Rows[i - 1]["RoomName"].ToString());
                        }
                        else
                        {
                            x = 1;
                        }
                        builder.InsertCell();
                        builder.CellFormat.Width = 100;
                        builder.Write(dtteacher.Rows[i - 1]["TIDName"].ToString());
                        if (i % dtsubject.Rows.Count == 0 && x == 1)
                        {
                            x = 0;
                            builder.EndRow();
                        }
                    }
                }
            }
            docz.MailMerge.ExecuteWithRegions(dt1);
            //docz.AppendDocument(doc, ImportFormatMode.UseDestinationStyles); 
            DeleteFile(path);
            var docStream = new MemoryStream();
            docz.Save(docStream, Aspose.Words.Saving.SaveOptions.CreateSaveOptions(Aspose.Words.SaveFormat.Doc));

            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/msword";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name, Encoding.UTF8));
            //调用导出具体方法Export()
            curContext.Response.BinaryWrite(docStream.GetBuffer());
            curContext.Response.End();
            // return base.File(docStream.ToArray(), "application/msword", "Template.doc");
            // doc.Save( name + "的人事信息.doc", SaveOptions.CreateSaveOptions(SaveFormat.Doc));  

        }

        #endregion


        //public static Document ImportWord1(DataRow dr, string path, string name)
        //{
        //    //string fielname = System.Web.HttpContext.Current.Server.MapPath(path);
        //    //Document doc = new Document(fielname);
        //    //doc.Range.Replace("@School", schoolname, false, false);
        //    //doc.Range.Replace("@Job", jobname, false, false);
        //    //doc.Range.Replace("@Name", teacher.Name, false, false);
        //    //doc.Range.Replace("@Sex", Enum.GetName(typeof(SexEnums), teacher.Sex), false, false);
        //    //doc.Range.Replace("@BirthDate", teacher.BirthDate.ToString("yyyy-MM"), false, false);
        //    //doc.Range.Replace("@PoliticalStatus", Enum.GetName(typeof(PoliticalStatusEnums), teacher.PoliticalStatus), false, false);
        //    //doc.Range.Replace("@IDNumber", teacher.IDNumber, false, false);
        //    //doc.Range.Replace("@Health", teacher.Health, false, false);
        //    //doc.Range.Replace("@IsMarried", teacher.IsMarried ? "已婚" : "未婚", false, false);
        //    //doc.Range.Replace("@Residence", teacher.Residence, false, false);
        //    //doc.Range.Replace("@FirstEducation", Enum.GetName(typeof(EducationEnums), teacher.FirstEducation), false, false);


        //    //DocumentBuilder builder = new DocumentBuilder(doc);

        //    //Bitmap source = new Bitmap(System.Web.HttpContext.Current.Server.MapPath(dr["Url"].ToString()));
        //    //Bitmap target = new Bitmap(source, new Size(175, 246));

        //    //builder.MoveToBookmark("Photo");
        //    //builder.InsertImage(PhysicalAddress + @"/Resource/Photo/" + teacher.Photo, RelativeHorizontalPosition.Margin, 1, RelativeVerticalPosition.Margin, 1, 182, 256, WrapType.Square);


        //    //return doc;
        //}
        //public string GetWord()
        //{
        //    return "";
        //    //string PhysicalAddress = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //    //Document doc = new Aspose.Words.Document(PhysicalAddress + "/Resource/Word/TableModel.docx");
        //    //UserRole ur = db.UserRole.FirstOrDefault(t => t.UserID == LoginHelper.CurrentUser.ID);
        //    //int[] SchoolList;
        //    //int[] JobList;
        //    //if (string.IsNullOrEmpty(ur.JobIDList))
        //    //{
        //    //    JobList = new int[] { -1 };
        //    //}
        //    //else
        //    //{
        //    //    JobList = ur.JobIDList.Split(',').Select(s => int.Parse(s)).ToArray();
        //    //}
        //    //if (string.IsNullOrEmpty(ur.SchoolIDList))
        //    //{
        //    //    SchoolList = new int[] { -1 };
        //    //}
        //    //else
        //    //{
        //    //    SchoolList = ur.SchoolIDList.Split(',').Select(s => int.Parse(s)).ToArray();
        //    //}

        //    ////数据
        //    //List<Teacher> teacherlist = db.Teacher.Where(t => (ur.SchoolIDList == "" || SchoolList.Contains(t.School)) && (ur.JobIDList == "" || JobList.Contains(t.Job))).ToList();

        //    //bool isfirst = true;
        //    //foreach (Teacher teacher in teacherlist)
        //    //{
        //    //    if (isfirst)
        //    //    {
        //    //        isfirst = false;
        //    //        doc = BuildWord(teacher);
        //    //    }
        //    //    else
        //    //    {
        //    //        //获取每一个单独的获奖证书，并合并为一个
        //    //        Document model = BuildWord(teacher);
        //    //        doc.AppendDocument(model, ImportFormatMode.UseDestinationStyles);

        //    //    }
        //    //}
        //    //this.DeleteFile("Word");

        //    //string filename = string.Format(@"开发区招聘聘用教师报名资格审查表_{0}.Docx", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
        //    //doc.Save(PhysicalAddress + @"/Resource/Word/" + filename, Aspose.Words.SaveFormat.Docx);


        //    //return filename;
        //}
        public static void DeleteFile(string path)
        {
            string paath = System.Web.HttpContext.Current.Server.MapPath(path);
            try
            {
                DirectoryInfo dir = new DirectoryInfo(paath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);
                    }
                    else
                    {
                        if (i.Name == "ExcelModel.xlsx" || i.Name == "TableModel.docx")
                        {

                        }
                        else
                        {
                            File.Delete(i.FullName);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public static DataTable ExportExcel(string path)
        {
            Workbook book = new Workbook(path);
            //book.Open(GetMapPath(path));
            Worksheet sheet = book.Worksheets[0];
            Cells cells = sheet.Cells;

            return cells.ExportDataTableAsString(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, true);
        }

        #region 获得当前绝对路径
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion
        /// <summary>
        /// 移动文件夹下的所有文件及文件夹
        /// </summary>
        /// <param name="sourcePath">需要移动的文件夹目录</param>
        /// <param name="destPath">移动后文件夹路径</param>
        /// <returns></returns>
        public static bool MoveFolder(string sourcePath, string destPath)
        {
            if (Directory.Exists(sourcePath))
            {
                if (!Directory.Exists(destPath))
                {
                    //目标目录不存在则创建
                    try
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("创建目标目录失败：" + ex.Message);
                    }
                }
                //获得源文件下所有文件
                List<string> files = new List<string>(Directory.GetFiles(sourcePath));
                files.ForEach(c =>
                {
                    string destFile = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    //覆盖模式
                    if (File.Exists(destFile))
                    {
                        File.Delete(destFile);
                    }
                    File.Move(c, destFile);
                });
                //获得源文件下所有目录文件
                List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));

                folders.ForEach(c =>
                {
                    string destDir = Path.Combine(new string[] { destPath, Path.GetFileName(c) });
                    //Directory.Move必须要在同一个根目录下移动才有效，不能在不同卷中移动。
                    //Directory.Move(c, destDir);

                    //采用递归的方法实现
                    MoveFolder(c, destDir);
                });
                return true;
            }
            else
            {
                //throw new DirectoryNotFoundException("源目录不存在！");
                return false;
            }
        }

        /// <summary>
        /// 将html内容转换为纯文本
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string xxHTML(string html)
        {

            html = html.Replace("(<style)+[^<>]*>[^\0]*(</style>)+", "");
            html = html.Replace(@"\<img[^\>] \>", "");
            html = html.Replace(@"<p>", "");
            html = html.Replace(@"</p>", "");


            System.Text.RegularExpressions.Regex regex0 =
            new System.Text.RegularExpressions.Regex("(<style)+[^<>]*>[^\0]*(</style>)+", System.Text.RegularExpressions.RegexOptions.Multiline);
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S] </script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S] </iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S] </frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>] \>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记  
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性   
            html = regex0.Replace(html, ""); //过滤href=javascript: (<A>) 属性   


            //html = regex10.Replace(html, "");  
            html = regex3.Replace(html, "");// _disibledevent="); //过滤其它控件的on...事件  
            html = regex4.Replace(html, ""); //过滤iframe  
            html = regex5.Replace(html, ""); //过滤frameset  
            html = regex6.Replace(html, ""); //过滤frameset  
            html = regex7.Replace(html, ""); //过滤frameset  
            html = regex8.Replace(html, ""); //过滤frameset  
            html = regex9.Replace(html, "");
            //html = html.Replace(" ", "");  
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = html.Replace(" ", "");
            return html;
        }
        /// <summary>
        /// 提取html中img路劲
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static List<string> GetImgUrl(string html)
        {
            List<string> resultStr = new List<string>();
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(html);
            // 取得匹配项列表   
            foreach (Match match in matches)
                resultStr.Add(match.Groups["imgUrl"].Value.ToLower());
            return resultStr;



            //Regex r = new Regex(@"<IMG[^>] src=s*(?:´(?<src>[^´] )´|""(?<src>[^""] )""|(?<src>[^>s] ))s*[^>]*>", RegexOptions.IgnoreCase);//忽视大小写
            //MatchCollection mc = r.Matches(html);

            //foreach (Match m in mc)
            //{
            //    resultStr.Add(m.Groups["src"].Value.ToLower());
            //}
            //if (resultStr.Count > 0)
            //{
            //    return resultStr;
            //}
            //else
            //{
            //    resultStr.Clear();
            //    return resultStr;
            //}
        }

        /// <summary>
        /// 根据随机数范围获取一定数量的随机数
        /// </summary>
        /// <param name="minNum">随机数最小值</param>
        /// <param name="minNum">是否包含最小值</param>
        /// <param name="maxNum">随机数最大值</param>
        /// <param name="minNum">是否包含最大值</param>
        /// <param name="ResultCount">随机结果数量</param>
        /// <param name="rm">随机数对象</param>
        /// <param name="isSame">结果是否重复</param>
        /// <returns></returns>
        public static List<int> GetRandom(int minNum, bool isIncludeMinNum, int maxNum, bool isIncludeMaxNum, int ResultCount, bool isSame)
        {
            Random rm = new Random();
            List<int> randomList = new List<int>();
            int nValue = 0;

            #region 是否包含最大最小值，默认包含最小值，不包含最大值
            if (!isIncludeMinNum) { minNum = minNum + 1; }
            if (isIncludeMaxNum) { maxNum = maxNum + 1; }
            #endregion

            if (isSame)
            {
                for (int i = 0; randomList.Count < ResultCount; i++)
                {
                    nValue = rm.Next(minNum, maxNum);
                    randomList.Add(nValue);
                }
            }
            else
            {
                for (int i = 0; randomList.Count < ResultCount; i++)
                {
                    nValue = rm.Next(minNum, maxNum);
                    //重复判断
                    if (!randomList.Contains(nValue))
                    {
                        randomList.Add(nValue);
                    }
                }
            }

            return randomList;
        }

        public static bool CopyDirectory(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, e.Message + "11111111", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                return false;
            }
        }


       
        #region 后台post事件
        /// <summary>
        /// 后台post事件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Post(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }
        #endregion

        #region 截取Json字符串
        /// <summary>
        /// 截取Json字符串
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Json(string json, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(json))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = json.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值
                    int end = json.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = json.IndexOf('}', index);
                    }

                    result = json.Substring(index, end - index);
                    result = result.Trim(new char[] { '"', ' ', '\'' }); //过滤引号或空格
                }
            }
            return result;
        }
        #endregion

        #region get事件
        /// <summary>
        /// get事件
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        public static string RequestUrl(string urlString)
        {
            //定义局部变量
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebRespones = null;
            Stream stream = null;
            string htmlString = string.Empty;
            //请求页面
            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; Maxthon 2.0)";
            //获取服务器的返回信息
            try
            {
                httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRespones.GetResponseStream();
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("接受服务器返回页面时发生错误！", ex);
            }
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            //读取返回页面
            try
            {
                htmlString = streamReader.ReadToEnd();
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("读取页面数据时发生错误！", ex);
            }
            //释放资源返回结果
            streamReader.Close();
            stream.Close();
            return htmlString;
        }
        #endregion


       

    }
}
