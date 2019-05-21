using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Services;
using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using System.Configuration;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
namespace GKICMP
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        ComputersDAL computersDAL = new ComputersDAL();
        TeachMaterial_ChapterDAL teachMaterial_ChapterDAL = new TeachMaterial_ChapterDAL();
        ComputerRegDAL computerRegDAL = new ComputerRegDAL();
        ComRecordDAL comRecordDAL = new ComRecordDAL();
        [WebMethod]
        public string Test(string name)
        {
            if (name == "Hello World")
                return "You Are Welcome";
            else
                return "";
        }
        [WebMethod]
        public string HelloWorld(string name)
        {
            if (name == "Hello World")
                return "You Are Welcome";
            else
                return "";
        }
        [WebMethod]
        public string GetVersion(string name)
        {
            if (name == "GKDZ")
                return ConfigurationManager.AppSettings["Version"];
            else
                return "";
        }
        [WebMethod]
        public Byte[] Update(string name,out string formart)
        {
            Byte[] file = new Byte[0];
            formart = "zip";
            if (name == "GKDZ")
            {
                file = CommonFunction.File2Bytes("/update.zip");
                formart = "zip";
                if (file.Length < 1) 
                {
                    CommonFunction.File2Bytes("/update.rar");
                    formart = "rar";
                }
            }
            return file;
        }
        [WebMethod]
        public string Conn(string name)
        {
            if (name == "GKDZ")
            {
                string conn = ConfigurationManager.AppSettings["ConnectionString"];
                return conn;
            }
            else
                return "";
        }
        [WebMethod]
        #region 班班通图片上传
        /// <summary>
        /// 班班通图片上传
        /// </summary>
        public int UploadScreen(string mac, string images, int isregister,string crid)
        {
            try
            {
                ComputersEntity model = new ComputersEntity();
                bool result = true;
                localhost1.WebService1 service = new localhost1.WebService1();
                string path = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl");
                if (path != "")
                {
                    service.Url = path + "/WebService1.asmx";
                    try
                    {
                        if (service.HelloWorld() != "You Are Welcome")
                            result = false;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                }
                else
                    result = false;
                //model.Guid = guid;
                //model.SchoolName = schoolname;
                //try
                //{
                //    int result = ComputersBLL.Add(model);
                //}
                //catch (Exception)
                //{

                //}
                ////创建数据缓存
                Context.Cache.Insert(mac, images, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
                if (result)
                    service.UploadScreen(ConfigurationManager.AppSettings["SGUID"], ConfigurationManager.AppSettings["SchoolName"], images);
                //service.UploadScreen(ConfigurationManager.AppSettings["SGUID"], ConfigurationManager.AppSettings["SchoolName"], images);
                if (isregister == 1)
                {
                    if (result)
                    {
                        localhost1.ComputerRegEntity m = new localhost1.ComputerRegEntity();
                        ComputerRegEntity R = new ComputerRegEntity();

                        m.Guid = R.Guid;
                        m.SchoolName = ConfigurationManager.AppSettings["SchoolName"];
                        m.UserName = R.UserName;
                        m.Subject = R.CIDName;
                        m.ChapterName = R.ChapterName;
                        m.ComputerName = R.ComputerName;
                        m.IP = R.IP;
                        m.RegDate = R.RegDate;
                        m.UploadMD5 = R.UploadMD5;
                        m.Xyear = R.Xyear;
                        m.XTerm = R.XTerm;
                        service.ComputerUseReg(m);
                    }
                    if (Context.Cache[mac + "1"] != null && Context.Cache[mac + "1"].ToString() != "")
                    {
                        int a = Convert.ToInt32(HttpRuntime.Cache.Get(mac + "1").ToString()) + 5;
                        Context.Cache.Insert(mac + "1", a, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
                        if (a >= 300)
                        {
                            byte[] arr = Convert.FromBase64String(images);
                            MemoryStream ms = new MemoryStream(arr);
                            Bitmap bmp = new Bitmap(ms);
                            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999)+".jpeg";
                            string fileserverpath = "~/bbtpic/";
                            string filePath = Server.MapPath(fileserverpath);
                            if (!Directory.Exists(filePath))
                            {
                                Directory.CreateDirectory(filePath);
                            }
                            bmp.Save(filePath + filename, ImageFormat.Jpeg);
                            //插入图片
                            new ComputerRegDAL().AddPIC(mac, fileserverpath+filename, crid);
                            //清楚时间缓存
                            Context.Cache.Remove(mac + "1");
                            Context.Cache.Remove(mac);
                            //Context.Cache.Insert(guid + "1", a, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
                        }
                    }
                    else
                    {
                        Context.Cache.Insert(mac + "1", 6, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
                    }

                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        } 
        #endregion

        [WebMethod]
        #region 班班通注册
        /// <summary>
        /// 班班通图片上传
        /// </summary>
        public bool Register(string mac,string key)
        {
            if (key == "GKDZ") 
            {
                ComputersEntity model = computersDAL.GetObjByMac(mac);
                if (model != null) 
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        #endregion

        [WebMethod]
        #region 班班通设备添加
        /// <summary>
        /// 班班通设备添加
        /// </summary>
        public bool CompAdd(string mac,string ip,string name,int type, string key,out string msg)
        {
            msg = "";
            try
            {
                if (key == "GKDZ")
                {
                    ComputersEntity model = new ComputersEntity();
                    model.Guid = "";
                    model.ComputerName = name;
                    model.LanIP = ip;
                    model.Mac = mac;
                    model.CRID = "-2";
                    model.CreateDate = DateTime.Now;
                    model.CFlag = type;//1班班通，2多媒体教室
                    int result = computersDAL.Edit(model);
                    if (result == -1)
                    {
                        msg = "提交失败";
                        return false;
                    }
                    else if (result == -2)
                    {
                        msg = "该名称已存在，请重新输入";
                        return false;
                    }
                    else if (result == -3)
                    {
                        msg = "该场室已注册，请重新输入";
                        return false;
                    }
                    else
                        return true;
                  
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }
        #endregion

        [WebMethod]
        #region 获取课程与教师
        /// <summary>
        /// 获取课程与教师
        /// </summary>
        public DataTable BaseData(string mac, string key)
        {
            if (key == "GKDZ")
            {
                return computersDAL.CourseList(mac);
            }
            return null;
        }
        #endregion

        [WebMethod]
        #region 获取章节
        /// <summary>
        /// 获取课程与教师
        /// </summary>
        public DataTable CData(int cid, int gid,string key)
        {
            if (key == "GKDZ")
            {
                return teachMaterial_ChapterDAL.GetList(cid, gid);
            }
            return null;
        }
        #endregion

        [WebMethod]
        #region 班班通登记
        /// <summary>
        /// 班班通登记
        /// </summary>
        public bool CompCheck(string json ,string key,out string msg)
        {
            int result=0;
            if (key == "GKDZ")
            {
                JArray list = (JArray)JsonConvert.DeserializeObject(json);
                if (list.Count > 0) 
                {
                    foreach (JObject job in list)
                    {
                        ComputerRegEntity model = new ComputerRegEntity();
                        model.CRID = job["CRID"].ToString();
                        model.Guid = job["Guid"].ToString();
                        model.SysID = job["SysID"].ToString();
                        model.CID = int.Parse(job["CID"].ToString());
                        model.ChapterName = job["ChapterName"].ToString();
                        model.RegType =int.Parse( job["RegType"].ToString());
                        result = computerRegDAL.Add(model);
                        if (result == -2) 
                        {
                            msg = "该时间段内已登记";
                            return false;
                        }
                    }
                }

                if (result == 0)
                {
                    msg = "success";
                    return true; }
            }
            msg = "验证出错";
            return false;
        }
        #endregion

        [WebMethod]
        #region 班班通登记删除（提前退出的情况）
        /// <summary>
        /// 班班通登记
        /// </summary>
        public bool RemoveCheck(string crid, string key)
        {
            int result = 0;
            if (key == "GKDZ")
            {
                result = computerRegDAL.DeleteReg(crid);
                if (result > 0)
                    return true;
            }
            return false;
        }
        #endregion

        [WebMethod]
        #region 机房登记
        /// <summary>
        /// 班班通登记
        /// </summary>
        public bool JFDJ(string json, string key,out string val)
        {
            string result = "0";
            if (key == "GKDZ")
            {
                JArray list = (JArray)JsonConvert.DeserializeObject(json);
                if (list.Count > 0)
                {
                    foreach (JObject job in list)
                    {
                        ComRecordEntity model = new ComRecordEntity();
                        model.SysID = job["SysID"].ToString();
                        model.RegDate = DateTime.Now;
                        model.MAC = job["Mac"].ToString();
                        string psw =job["Psw"].ToString()==""?"": CommonFunction.Encrypt(job["Psw"].ToString());
                        result = comRecordDAL.Edit(model, psw);
                        
                    }
                }
                val = result;
                string[] res = val.Split(',');
                if (res[0] == "0")
                //if (result == "0")
                {
                    val = res.Length > 1 ? res[1] : "";
                    return true;
                }
                else
                    return false;
            }
            val = "验证出错";
            return false;
        }
        #endregion

        [WebMethod]
        #region 机房注册验证
        /// <summary>
        /// 班班通登记
        /// </summary>
        public bool JFYZ(string mac, string key, out string val)
        {
            //string result = "0";
            if (key == "GKDZ")
            {
               ComputersEntity model= computersDAL.GetObjByMac(mac);
               if (model != null)
               {
                   val = "success";
                   return true;
               }
               val = "系统中不存在mac地址为："+mac+"的信息";
               return false;
            }
            val = "验证出错";
            return false;
        }
        #endregion




        //[WebMethod]
        //#region 班班通使用登记
        ///// <summary>
        ///// 班班通使用登记
        ///// </summary>
        //public bool ComputerUseReg(ComputerRegEntity R)
        //{
        //    bool receiveResult = true;
        //    try
        //    {
        //        if (R != null)
        //        {
        //            ComputerRegEntity model = new ComputerRegEntity();
        //            model.CRID = "";
        //            model.Guid = R.Guid;
        //            model.SchoolName = R.SchoolName;
        //            model.UserName = R.UserName;
        //            model.Subject = R.Subject;
        //            model.ChapterName = R.ChapterName;
        //            model.ComputerName = R.ComputerName;
        //            model.IP = R.IP;
        //            model.RegDate = R.RegDate;
        //            model.UploadMD5 = R.UploadMD5;
        //            model.Xyear = R.Xyear;
        //            model.XTerm = R.XTerm;

        //            int result = ComputerRegBLL.Add(model);
        //            if (result > 0)
        //            {
        //                ComputersEntity cmodel = new ComputersEntity();
        //                cmodel.Guid = R.Guid.ToString();
        //                cmodel.ComputerName = R.ComputerName.ToString();
        //                cmodel.LanIP = R.IP.ToString();
        //                cmodel.Mac = "";
        //                cmodel.OnlineMinutes = 0;
        //                int cresult = ComputersBLL.Update(cmodel);

        //                receiveResult = true;
        //            }
        //            else
        //            {
        //                receiveResult = false;
        //            }
        //        }
        //        else
        //        {
        //            receiveResult = false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        receiveResult = false;
        //    }
        //    return receiveResult;
        //}
        //#endregion
    }
}
