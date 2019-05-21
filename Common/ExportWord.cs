using Aspose.Words;
using Aspose.Words.Drawing;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GK.GKICMP.Common
{
   public class ExportWord
    {
       public static void ImportWord(DataTable dt, DataTable dtlist, string path, string name, SysSetConfigEntity model)
       {
           string fielname = System.Web.HttpContext.Current.Server.MapPath(path);
           //Document docz = new Document(fielname);
           Document docz = new Document(fielname);
           bool first = true;
           foreach (DataRow dr in dt.Rows)
           {
               DataRow[] dra = null;
               if (first)
               {
                   first = false;
                  
                   if (dtlist != null && dtlist.Rows.Count > 0)
                   {
                        dra = dtlist.Select("LID='" + dr["LID"]+"'");
                   }
                   docz = GetWord(fielname, dt, dra, dr);
               }
               else 
               {
                   if (dtlist != null && dtlist.Rows.Count > 0)
                   {
                       dra = dtlist.Select("LID='" + dr["LID"]+"'");
                   }
                   Document d = GetWord(fielname, dt,dra, dr);
                   docz.AppendDocument(d, ImportFormatMode.UseDestinationStyles);
               }
               //Document doc = new Document(fielname);
               //for (int i = 0; i < dr.ItemArray.Length; i++)
               //{
               //    doc.Range.Replace("@" + dt.Columns[i].ColumnName, dr[i].ToString(), false, false);
               //}
               ////建立DocumentBuilder物件 
               //DocumentBuilder builder = new DocumentBuilder(doc);
               //////新增文字
               ////builder.MoveToBookmark("ActivityContent");
               ////builder.InsertHtml(dr["ActivityContent"].ToString().Trim());
               ////builder.MoveToBookmark("ActivityTarget");
               ////builder.InsertHtml(dr["ActivityTarget"].ToString().Trim());
               ////builder.MoveToBookmark("ActivityPre");
               ////builder.InsertHtml(dr["ActivityPre"].ToString().Trim());

               ////添加页眉图片（使用书签）
               //Shape shape = new Shape(doc, ShapeType.Image);
               //shape.Width = 16;
               //shape.Height = 16;
               //shape.ImageData.SetImage(GetMapPath("~/gzimages/bk.png"));
               ////if (doc.Range.Bookmarks["Pic"] == null)
               ////{
               //builder.MoveToBookmark("Pic");
               //builder.InsertNode(shape);
               ////}
               ////將上述設定的格式清除
               //builder.Font.ClearFormatting();
               ////將文件存檔
               ////doc.Save("D://Test.doc");
               ////将照片写入标签【此处不用域】
               ////DocumentBuilder builder = new DocumentBuilder(doc);
               ////Shape shape = new Shape(doc, ShapeType.Image);
               ////shape.ImageData.SetImage("");
               ////shape.Width = 91;
               ////shape.Height = 95;
               ////shape.HorizontalAlignment = Aspose.Words.Drawing.HorizontalAlignment.Center;
               ////if (doc.Range.Bookmarks["photo"] != null)
               ////{
               ////    builder.MoveToBookmark("photo");
               ////    builder.InsertNode(shape);
               ////}
               //docz.AppendDocument(doc, ImportFormatMode.UseDestinationStyles);

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
       public static Document GetWord (string fielname,DataTable dt,DataRow[] dra, DataRow dr)
       {
           DataTable dtnew = new DataTable("Item");
           dtnew = ToDataTable(dra);
           Document doc = new Document(fielname);
           for (int i = 0; i < dr.ItemArray.Length; i++)
           {
               doc.Range.Replace("@" + dt.Columns[i].ColumnName, dr[i].ToString(), false, false);
           }
           //建立DocumentBuilder物件 
           DocumentBuilder builder = new DocumentBuilder(doc);

           if (dtnew != null && dtnew.Rows.Count > 0)
               doc.MailMerge.ExecuteWithRegions(dtnew);
           ////新增文字
           //builder.MoveToBookmark("ActivityContent");
           //builder.InsertHtml(dr["ActivityContent"].ToString().Trim());
           //builder.MoveToBookmark("ActivityTarget");
           //builder.InsertHtml(dr["ActivityTarget"].ToString().Trim());
           //builder.MoveToBookmark("ActivityPre");
           //builder.InsertHtml(dr["ActivityPre"].ToString().Trim());

           //添加页眉图片（使用书签）
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
          // docz.AppendDocument(doc, ImportFormatMode.UseDestinationStyles);
           return doc;
       }

       public static DataTable ToDataTable(DataRow[] rows)
       {
           if (rows == null || rows.Length == 0) return null;
           DataTable tmp = rows[0].Table.Clone(); // 复制DataRow的表结构
           foreach (DataRow row in rows)
           {

               tmp.ImportRow(row); // 将DataRow添加到DataTable中
           }
           return tmp;
       }
       #region 删除文件
       /// <summary>
       /// 删除文件
       /// </summary>
       /// <param name="path"></param>
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
       #endregion

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
    }
}
