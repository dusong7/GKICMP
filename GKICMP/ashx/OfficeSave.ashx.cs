using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// OfficeSave 的摘要说明
    /// </summary>
    public class OfficeSave : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int id = 0;
            BinaryReader bReader = new BinaryReader(context.Request.InputStream);
            string strTemp = Encoding.GetEncoding("iso-8859-1").GetString(
            bReader.ReadBytes((int)bReader.BaseStream.Length), 0, (int)bReader.BaseStream.Length);
            string match = "Content-Type: application/msword\r\n\r\n";
            int pos = strTemp.IndexOf(match) + match.Length;
            bReader.BaseStream.Seek(pos, SeekOrigin.Begin);
            string newFile = System.Web.HttpContext.Current.Server.MapPath(".") + "\\MyFile2.doc";
            FileStream newDoc = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            BinaryWriter bWriter = new BinaryWriter(newDoc);
            bWriter.BaseStream.Seek(0, SeekOrigin.End);

            while (bReader.BaseStream.Position < bReader.BaseStream.Length - 38)
                bWriter.Write(bReader.ReadByte());
            bReader.Close();
            bWriter.Flush();
            bWriter.Close();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}