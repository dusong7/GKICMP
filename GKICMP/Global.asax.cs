using System;
using System.Collections.Generic;
using System.Web;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.IO;
using System.Web.Configuration;
using System.Web.Caching;
using System.Reflection;
using System.Runtime.InteropServices;
using System.DirectoryServices;


using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using System.Data.SqlClient;


using System.Diagnostics;


namespace GKICMP
{
    public class Global : System.Web.HttpApplication
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        public string TFTIP = "";
        public int TFTPort = 0;
        public bool isfirst = true;
        public AttendSetDAL attendSetDAL = new AttendSetDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public Web_NewsDAL web_NewsDAL = new Web_NewsDAL();
        //public EgovernmentDAL egovernmentDAL = new EgovernmentDAL();

        public int degree = 0;

        #region 钉钉考勤--全局变量
        string appkey = ConfigurationManager.AppSettings["appkey"];
        string appsecret = ConfigurationManager.AppSettings["appsecret"];
        string connectstring = ConfigurationManager.AppSettings["ConnectionString"];
        
        public DateTime BeginDate = DateTime.Now;
        public DateTime EndDate = DateTime.Now;

        public List<JArray> CUserList = new List<JArray>();

        public JArray UserList = new JArray();
        public JArray TUserList = new JArray();
        #endregion

        protected void Application_Start(object sender, EventArgs e)
        {
            #region 获取SGUID
            //string p = AppDomain.CurrentDomain.BaseDirectory;
            //string p1 = "";
            //string pa = GetUrl();
            // HttpContext.Current.Request.();
            
            string guid = ConfigurationManager.AppSettings["SGUID"];
            if (string.IsNullOrEmpty(guid))
            {
                ConfigurationManager.AppSettings.Set("SGUID", Guid.NewGuid().ToString());
            }
            #endregion

            #region 进入校园 离开校园
            //Play();
            //GetVersion();
            //SysUserEntity fu = sysUserDAL.GetCardNum("0a44d638526e5ef589fe6abfba238751");
            //WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
            //if (model1.IsOpen == 1)
            //{
            //    string message = "";
            //    //type=1 进入打卡 2离开打卡
            //    //if (fl.OutType == 1)
            //    message = WXSendMsg(model1.Agent, fu, "于" + DateTime.Now + "进入校园");
            //    //else
            //    //    message = WXSendMsg(model1.Agent, fu, "于" + fl.RecordDate + "离开校园");


            //}
            //string message = "";
            //string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "DX/IsOpen");
            //if (isopen == "1")
            //{
            //    DataTable dt = new SysUserDAL().GetPhone((int)CommonEnum.HumanType.政务接受人);
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        string phone = "";
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            if (dr[0].ToString() != "")
            //                phone += dr[0] + ",";
            //        }
            //        if (phone.TrimEnd(',') != "")
            //        {
            //            message = SendMsg("", phone.TrimEnd(','));
            //        }
            //    }
            //}

            //Thread thread25yi = new Thread(new ThreadStart(MethodTimer1));
            //thread25yi.Start();

            //SendMsg("","18226530705");
            //UpdateByProType();
            //测试时注释
            #endregion

            #region 测试时请注释

            #region 收发政务
            System.Timers.Timer myTimer1 = new System.Timers.Timer(60000);
                myTimer1.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                myTimer1.Interval = 60000;
                myTimer1.Enabled = true;

                //Thread td = new Thread(delegate()
                //{
                //    OaMsgSend();
                //});
                //td.Name = "SendMsg";
                //td.IsBackground = true;
                //td.Start();

            #endregion


            #region 采购
                System.Timers.Timer myTimer2 = new System.Timers.Timer(60000);
                myTimer1.Elapsed += new System.Timers.ElapsedEventHandler(Purchase);
                myTimer1.Interval = 60000;
                myTimer1.Enabled = true;
                #endregion

            #region 发送微信消息
                //System.Timers.Timer sendWXmsg = new System.Timers.Timer(3600000);
                //sendWXmsg.Elapsed += new System.Timers.ElapsedEventHandler(sendWXmsgT);
                //sendWXmsg.Enabled = true;
                //#endregion

                // GetCamera(AppDomain.CurrentDomain.BaseDirectory+"CameraPicTemp/");
                //Thread send = new Thread(new ThreadStart(GetAttend));
                //send.Start();

                //List<Thread> threadlist = new List<Thread>();

                //#region 人脸识别
                //if (ConfigurationManager.AppSettings["IsOpenC"] == "1")
                //{
                //    Thread tft = new Thread(delegate()
                //    {
                //        GetCamera(AppDomain.CurrentDomain.BaseDirectory + "CameraPicTemp/");
                //    });
                //    tft.IsBackground = true;
                //    tft.Name = "FaceThread:" + (threadlist.Count + 1);
                //    threadlist.Add(tft);
                //    tft.Start();
                //    // GetCamera(AppDomain.CurrentDomain.BaseDirectory+"CameraPicTemp/");
                //    //Thread send = new Thread(new ThreadStart(GetAttend));
                //    //send.Start();
                //}
                #endregion

            #endregion

            #region 网页爬虫--正式版
            //System.Timers.Timer myTimer2 = new System.Timers.Timer(3600000);
            //myTimer2.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent2);
            //myTimer2.Enabled = true;
            #endregion

            #region 网页爬虫--测试版
             //GetFromHtml("e:/dzzw.html", 1);//网页爬虫--师范附小专用 每小时执行一次
             // GetFromHtml("e:/jyj.html", 2);//编码格式为UTF8

                //GetFromHtml("e:/tz.html", 1);//编码格式为UTF8

             // GetFromHtml("http://whjhoa.cn/ShowClass2.asp?ClassID=7", 1);//编码格式为GBK
             // GetFromHtml("http://whjhoa.cn/ShowClass2.asp?ClassID=46", 2);//编码格式为UTF8
           #endregion


            #region 钉钉考勤--正式版
                //BuildUserList();//获取前50条userid列表
                //TwoUserList();  //获取后50条userid列表
                //System.Timers.Timer timer = new System.Timers.Timer(60000);
                //timer.Elapsed += new System.Timers.ElapsedEventHandler(GetAttendence);
                //timer.Enabled = true;

                #region 职员工userid列表 存储在CUserList[i]中
                //int ddcount = GetFactoryEmployeeCount();//获取通讯录总人数
                //int yu = ddcount % 50;//取余
                //int zeng = ddcount / 50;//取整
                //int tt = 0;
                //if (yu > 0)
                //{
                //    zeng = zeng + 1;
                //}
                //for (int i = 0; i < zeng; i++)
                //{
                //    tt = 50 * i;
                //    ToBuildUserList(i, tt);//分页查询企业在职员工userid列表 存储在CUserList[i]中
                //}

                //System.Timers.Timer timer = new System.Timers.Timer(300000);
                //timer.Elapsed += new System.Timers.ElapsedEventHandler(GetAttendence);
                //timer.Enabled = true;
                #endregion
               
           #endregion

            #region 钉钉考勤--测试版

                //int ddcount = GetFactoryEmployeeCount();//获取通讯录总人数
                //int yu = ddcount % 50;//取余
                //int zeng = ddcount / 50;//取整
                //int tt = 0;
                //if (yu > 0)
                //{
                //    zeng = zeng + 1;
                //}
                //for (int i = 0; i < zeng; i++)
                //{
                //    tt = 50 * i;
                //    ToBuildUserList(i,tt);
                //    GetAttendance(BeginDate, EndDate, UserList);
                //}
                //BeginDate = EndDate;
                //EndDate = DateTime.Now;

               
          
                ////UserList.Add("03452243497666");
                ////UserList.Add("085146610134609723");
                ////UserList.Add("056415482627289950");
                ////UserList.Add("055551150027113057");
                ////UserList.Add("03153664332360");
                ////UserList.Add("065454412029179344");
                ////UserList.Add("04132266231212971");

                //BuildUserList();//获取前50条userid列表
                //TwoUserList();  //获取后50条userid列表
                //GetAttendance(BeginDate, EndDate, UserList);
                //GetAttendance(BeginDate, EndDate, TUserList);
                //BeginDate = EndDate;
                //EndDate = DateTime.Now;

            #endregion

            #region 钉钉考勤--测试版22

                //#region 职员工userid列表 存储在CUserList[i]中
                //int ddcount = GetFactoryEmployeeCount();//获取通讯录总人数
                //int yu = ddcount % 50;//取余
                //int zeng = ddcount / 50;//取整
                //int tt = 0;
                //if (yu > 0)
                //{
                //    zeng = zeng + 1;
                //}
                //for (int i = 0; i < zeng; i++)
                //{
                //    tt = 50 * i;
                //    ToBuildUserList(i,tt);//分页查询企业在职员工userid列表 存储在CUserList[i]中
                //}
                //#endregion

                //for (int g = 0; g < CUserList.Count; g++)
                //{
                //    ToGetAttendance(BeginDate, EndDate, CUserList, g);
                //}
                //BeginDate = EndDate;
                //EndDate = DateTime.Now;

           #endregion

        }


        //public void test()
        //{
        //    Thread thread25yi = new Thread(new ThreadStart(MethodTimer1));
        //    thread25yi.Start();
        //}
        

       public  void MethodTimer1()
        {
            bool play = true;
            bool play1 = true;
            bool play2 = true;
            while (true)
            {
                DataTable dt = new DataTable();
                if (HttpRuntime.Cache["ALL"] != null)
                {
                    dt = (DataTable)HttpRuntime.Cache["ALL"];
                    if (dt.Rows.Count < 1)
                    {
                        dt = new RestTimeDAL().GetList(); //从数据库中取得数据
                        HttpRuntime.Cache.Insert("ALL", dt, null,
                                    DateTime.Now.AddHours(1),
                                    System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                }
                else
                {
                    dt = new RestTimeDAL().GetList();//从数据库中取得数据
                    HttpRuntime.Cache.Insert("ALL", dt, null,
                                DateTime.Now.AddHours(1),
                                System.Web.Caching.Cache.NoSlidingExpiration);

                }

                DataRow[] dr = dt.Select("weeks=" +(int)DateTime.Now.DayOfWeek);
               
                foreach(DataRow d in dr)
                {
                    
                    if (d["IsGetSet"].ToString() == "1") 
                    {
                        if (DateTime.Now.AddMinutes(2).ToString("HH:mm") == Convert.ToDateTime(d["BeginTime"].ToString()).ToString("HH:mm"))
                        {
                            if (play)
                            {
                                play = false;
                                Play();
                            }

                        }
                    }
                    if (DateTime.Now.ToString("HH:mm") == Convert.ToDateTime(d["BeginTime"].ToString()).ToString("HH:mm")) 
                    {
                        if (play1)
                        {
                            play1 = false;
                            Play();
                        }
                       
                    }
                    if (DateTime.Now.ToString("HH:mm") == Convert.ToDateTime(d["EndTime"].ToString()).ToString("HH:mm"))
                    {
                        if (play2)
                        {
                            play2 = false;
                            Play();
                        }

                    }
                    //Thread threadHand1 = new Thread(delegate() { MethodTimer("0"); });
                    //threadHand1.Start();
                }
                Thread.Sleep(5000);//阻止设定时间 
            }
        }

       
        public void GetAttend()
        {
            DataTable dt = attendSetDAL.GetList();
            DateTime dreset = DateTime.Now;
            if (dt != null && dt.Rows.Count > 0)
            {
                string mess = "";
                string messt = "";

                while (1 == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime DT1 = DateTime.Now.AddMinutes(-10);
                        DateTime DT2 = Convert.ToDateTime(Convert.ToDateTime(dr["MEnd"].ToString()).ToString("HH:mm"));

                        if (Convert.ToDateTime(DateTime.Now.AddMinutes(-10).ToString("yyyy-MM-dd HH:mm")) == Convert.ToDateTime(Convert.ToDateTime(dr["MEnd"].ToString()).ToString("HH:mm")))
                        {
                            string id = "";
                            string name = "";
                            string acc = "";
                            DateTime sendmsg = DateTime.Now;
                            DataTable dt1 = attendRecordDAL.Abnormal(Convert.ToDateTime(Convert.ToDateTime(dr["MBegin"].ToString()).ToString("HH:mm")), Convert.ToDateTime(Convert.ToDateTime(dr["MEnd"].ToString()).ToString("HH:mm")), int.Parse(dr["OutType"].ToString()));
                            if (dt1 != null && dt1.Rows.Count > 0)
                            {
                                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                                if (model1.IsOpen == 1)
                                {
                                    foreach (DataRow dr1 in dt1.Rows)
                                    {
                                        id += dr1["UserID"].ToString() + ",";
                                        name += dr1["RealName"].ToString() + ",";
                                    }
                                    //name = name.TrimEnd(',');
                                    DataTable Accpter = sysUserDAL.GetUserID((int)CommonEnum.HumanType.考勤异常接收人);
                                    if (Accpter != null && Accpter.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr2 in Accpter.Rows)
                                        {
                                            acc += dr2["UserID"].ToString() + ",";
                                        }
                                        if (mess == "" || mess != "发送成功")
                                        {
                                            messt = WXSendMsg(model1.Agent, id.TrimEnd(','), "您好，在【" + Convert.ToDateTime(dr["MBegin"].ToString()).ToString("HH:mm") + "-" + Convert.ToDateTime(dr["MEnd"].ToString()).ToString("HH:mm") + "】节点内共" + dt1.Rows.Count + "人未打卡，具体人员名单为:【" + name.TrimEnd(',') + "】");
                                        }
                                    }
                                    if (mess == "" || mess != "发送成功")
                                    {
                                        mess = WXSendMsg(model1.Agent, id.TrimEnd(','), "在【" + Convert.ToDateTime(dr["MBegin"].ToString()).ToString("HH:mm") + "-" + Convert.ToDateTime(dr["MEnd"].ToString()).ToString("HH:mm") + "】节点内未打卡。");
                                    }

                                    if (DateTime.Now.ToString("yyyy-MM-dd HH:mm") == sendmsg.AddMinutes(1).ToString("yyyy-MM-dd HH:mm"))
                                    {
                                        mess = "";
                                        messt = "";
                                        //dreset = DateTime.Now;
                                        //dt = attendSetDAL.GetList();
                                    }
                                }
                            }


                        }

                    }
                    if (DateTime.Now == dreset.AddMinutes(30))
                    {
                        dreset = DateTime.Now;
                        dt = attendSetDAL.GetList();
                    }
                }
            }
        }

        public enum VerifyMode
        {
            密码验证 = 0,
            指纹验证 = 1,
            卡验证 = 2,
            其他验证 = 9,
        }

        public enum InOutMode
        {
            上班签到 = 0,
            下班签退 = 1,
            外出 = 2,
            外出返回 = 3,
            加班签到 = 4,
            加班签退 = 5,
        }

        public static object locker = new object();



        #region 播放音乐方法
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);
        public void Play()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = path + "holdon.mp3";
            new MCI().Play(path, 1);
            //mciSendString(@"close temp_alias", null, 0, 0);
            //mciSendString("open " + path + " alias temp_alias", null, 0, 0);
            ////mciSendString(@"open src\\1.mp3 alias temp_alias", null, 0, 0);
            //mciSendString("play temp_alias ", null, 0, 0);
        }
        #endregion

        #region 测试区域，不用时请注释
        //Play();
        //public static void test1()
        //{
        //    DayOfWeek a = DateTime.Now.DayOfWeek;
        //    int b = (int)a;
        //    switch (b)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            test();
        //            break;
        //        case 2:
        //            test();
        //            break;
        //        case 3:
        //            test();
        //            break;
        //        case 4:
        //            test();
        //            break;
        //        case 5:
        //            test();
        //            break;
        //        case 6:
        //            break;

        //    }
        //}

        //private static void test()
        //{
        //    try
        //    {
        //        localhost1.WebService1 a = new localhost1.WebService1();
        //        // string s = a.HelloWorld();

        //        localhost1.OA[] oa;
        //        a.ReceiveOA(new Guid(ConfigurationManager.AppSettings["SGUID"]), out oa);
        //        List<EgovernmentEntity> egoEntity = new List<EgovernmentEntity>();
        //        if (oa.Length > 0)
        //        {
        //            foreach (localhost1.OA oamodel in oa)
        //            {
        //                // OA model = new OA();
        //                EgovernmentEntity model = new EgovernmentEntity();
        //                //model= oa.ArticleID ;
        //                model.EID = oamodel.zwid.ToString();
        //                model.Etitle = oamodel.Title;
        //                model.Ecode = DateTime.Now.ToString("yyyyMMddHHmmss");
        //                model.EKey = "";
        //                model.EDepartment = oamodel.lwdw;
        //                model.EtitleType = oamodel.SubTitle;
        //                model.EContent = oamodel.Content;
        //                model.Opened = 0;
        //                model.Completed = 0;
        //                model.IsApproved = 1;
        //                model.Etype = 0;
        //                model.CreateUser = oamodel.InputerName;

        //                model.CreateDate = oamodel.UpdateTime;
        //                model.Estate = (int)CommonEnum.GWType.未处理;
        //                model.IsSave = 1;
        //                model.IsSuperior = (int)CommonEnum.IsorNot.是;
        //                //Egovernment_FlowEntity modelflow = new Egovernment_FlowEntity();
        //                //modelflow.Comment = oamodel.Operator;
        //                //modelflow.IsSendMess = 0;
        //                //modelflow.AcceptUser = "";
        //                //modelflow.State = (int)CommonEnum.GWType.未处理;
        //                //modelflow.IsRead = 0;
        //                egoEntity.Add(model);

        //            }
        //            int result = new EgovernmentDAL().ReceiveOA(egoEntity);
        //            if (result == 0)
        //            {
        //                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "成功接收到上级下发政务", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //            }
        //            else { new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "接收政务失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD")); }
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //    }
        //}

        //private static void test2()
        //{
        //    try
        //    {
        //        string pid = "";
        //        localhost1.WebService1 a = new localhost1.WebService1();
        //        a.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";

        //        //获取教装项目审核状态为未通过的项目
        //        DataTable jt = new JZProjectManageDAL().GetObjByState((int)CommonEnum.IsorNot.否);
        //        if (jt != null && jt.Rows.Count > 0)
        //        {
        //            for (int j = 0; j < jt.Rows.Count; j++)
        //            {
        //                pid += jt.Rows[j]["PID"].ToString() + ",";
        //            }

        //            //foreach (DataRow dr in jt.Rows) 
        //            //{
        //            //    pid += dr["PID"].ToString() + ",";
        //            //}
        //        }

        //        localhost1.JZProjectManageEntity[] jz;
        //        //对应 区平台 
        //        a.JZProjectState(new Guid(ConfigurationManager.AppSettings["SGUID"]), pid, out jz);
        //        List<JZProjectManageEntity> egoEntity = new List<JZProjectManageEntity>();
        //        if (jz.Length > 0)
        //        {
        //            foreach (localhost1.JZProjectManageEntity oamodel in jz)
        //            {
        //                JZProjectManageEntity model = new JZProjectManageEntity();
        //                model.PID = oamodel.PID;
        //                //model.State = oamodel.State; //驳回 = 0,未审核 = 1,通过 = 2,否决=3
        //                //model.ProName = oamodel.ProName;
        //                egoEntity.Add(model);
        //            }

        //            int result = new JZProjectManageDAL().JZUpdate(egoEntity);
        //            if (result == 2)
        //            {
        //                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "更新教装项目审核状态成功", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //            }
        //            else
        //            {
        //                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "更新教装项目审核状态失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //            }
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //    }
        //}

        //private static void test3()
        //{
        //    try
        //    {
        //        string baid = "";
        //        localhost1.WebService1 a = new localhost1.WebService1();
        //        a.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";


        //        //获取基建项目审核状态为未通过的项目
        //        DataTable jt = new BuildApplyDAL().GetObjByState((int)CommonEnum.Deleted.未删除);
        //        if (jt != null && jt.Rows.Count > 0)
        //        {
        //            for (int j = 0; j < jt.Rows.Count; j++)
        //            {
        //                baid += jt.Rows[j]["BAID"].ToString() + ",";
        //            }
        //        }
        //        localhost1.BuildApplyEntity[] jj;
        //        //对应 区平台 
        //        a.JJProjectState(new Guid(ConfigurationManager.AppSettings["SGUID"]), baid, out jj);
        //        List<BuildApplyEntity> egoEntity = new List<BuildApplyEntity>();
        //        if (jj.Length > 0)
        //        {
        //            foreach (localhost1.BuildApplyEntity oamodel in jj)
        //            {
        //                BuildApplyEntity model = new BuildApplyEntity();
        //                model.BAID = oamodel.BAID;
        //                egoEntity.Add(model);
        //            }

        //            int result = new BuildApplyDAL().JZUpdate(egoEntity);
        //            if (result == 2)
        //            {
        //                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "更新基建项目审核状态", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //            }
        //            else
        //            {
        //                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "更新基建项目审核状态", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //            }
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
        //    }
        //} 
        #endregion

        #region 运行环境区域，不测试时请取消注释
        /// <summary>
        /// 每1分钟执行一次
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            Thread ts = new Thread(delegate()
            {
                ReceiveOA();
            });
            ts.IsBackground = true;
            ts.Start();

            Thread tssend = new Thread(delegate()
            {
                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
                if (model1.IsOpen == 1)
                {
                    SendWXmsg(model1.Agent);
                }
            });
            tssend.IsBackground = true;
            tssend.Start();




            //Thread oaMsgtd = new Thread(delegate()
            //{
            //    //degree++;
            //    OaMsgSend();
            //});
            //oaMsgtd.IsBackground = true;
            //oaMsgtd.Start();

            //Thread tsupdate = new Thread(delegate()
            //{
            //    GetVersion();
            //});
            //tsupdate.IsBackground = true;
            //tsupdate.Start();
            
            //JZUpdate();
            //JJUpdate();

        }

        private static void Purchase(object source, System.Timers.ElapsedEventArgs e)
        {
            Thread ts = new Thread(delegate()
            {
                UpdatePurchase();
            });
            ts.IsBackground = true;
            ts.Start();
        }
        /// <summary>
        /// 每1h执行一次
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent1(object source, System.Timers.ElapsedEventArgs e)
        {
            UpdateByProType();
            JZUpdate();
            JJUpdate();


        }


        private static void StopRadio(object source, System.Timers.ElapsedEventArgs e)
        {
            //string type = ConfigurationManager.AppSettings["Radio"];
            //if (type == "1")
            //{
            //    System.Timers.Timer myTimer3 = new System.Timers.Timer(5000);
            //    myTimer3.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
            //    myTimer3.Enabled = true;
            //}
        }


        #endregion
        public static void UpdatePurchase() 
        {
            try
            {
                localhost1.WebService1 a = new localhost1.WebService1();
                a.Url = GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl") + "/WebService1.asmx";
                localhost1.PurchaseEntity[] oa;
                if (a.HelloWorld() == "You Are Welcome")
                {
                    //获取教装项目审核状态为未通过的项目
                    string pid = "";
                    DataTable jt = new PurchaseDAL().GetNoAudit((int)CommonEnum.AduitState.通过);
                    if (jt != null && jt.Rows.Count > 0)
                    {
                        for (int j = 0; j < jt.Rows.Count; j++)
                        {
                            pid += jt.Rows[j]["PID"].ToString() + ",";
                        }
                    }
                    if (a.PurchaseState(new Guid(ConfigurationManager.AppSettings["SGUID"]),pid, out oa))
                    {
                        List<PurchaseEntity> egoEntity = new List<PurchaseEntity>();
                        string uid = "", phone = "";
                        if (oa != null && oa.Length > 0)
                        {
                            foreach (localhost1.PurchaseEntity oamodel in oa)
                            {
                                DataRow[] dr = jt.Select("pid='" + oamodel.PID + "'");
                                if (dr != null && dr.Length > 0)
                                {
                                    uid += dr[0]["UserID"] + "|";
                                    phone += dr[0]["CellPhone"] + ",";
                                }
                                PurchaseEntity model = new PurchaseEntity();
                                model.PLState = oamodel.PLState == 3 ? (int)CommonEnum.AduitState.通过 : (int)CommonEnum.AduitState.驳回;
                                model.PType = oamodel.PurType;
                                model.PID = oamodel.PID;
                                model.PLDate = oamodel.PLDate;
                                egoEntity.Add(model);
                            }
                            int result = new PurchaseDAL().AuditUpdate(egoEntity);
                            if (result > 0)
                            {
                                string message = "";
                                string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "DX/IsOpen");
                                if (isopen == "1")
                                {
                                    message = SendMsg("", phone.TrimEnd(',')) + ",";
                                }
                                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
                                if (model1.IsOpen == 1)
                                {
                                    WXSendMsg1(model1.Agent, uid.Trim('|'), "您的采购项目上级已审核,请到系统内查看", out message);
                                }

                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "您有新的采购项目已审核,请到系统内查看" + message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));

                            }
                            else { new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "更新采购审核信息失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD")); }
                        }
                        else
                        {
                            // new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "null", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                        }
                    }
                    else
                    {
                        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "false", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    }
                }
                else
                {

                }
            }
            catch (Exception error)
            {
                //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                return;
                //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
            }
        }

        #region 执行调用方法
        public static void GetVersion() 
        {
            string formart = "";
            string path = "";
            WebReference.WebService ws = new WebReference.WebService();
            ws.Url = ConfigurationManager.AppSettings["Update"] + "/update.asmx";
            string vsion= ConfigurationManager.AppSettings["Version"];
            string version=ws.GetVersion("GKDZ");
            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "获取版本信息：" + vsion + ";" + version, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
            if (vsion != version)
            {
                try
                {
                    string gxpath  =AppDomain.CurrentDomain.BaseDirectory;
                    //string mlpath = AppDomain.CurrentDomain.BaseDirectory;
                    byte[] buff = ws.Update("GKDZ", out formart);
                    if (formart == "zip") path = gxpath + "/yghd.zip";
                    else path = gxpath + "/yghd.rar";
                    new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "获取版本信息：" + buff.Length + ";" + formart, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    if (buff.Length > 0)
                    {
                        ///string pathq = System.Web.HttpContext.Current.Server.MapPath(path);
                        // new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "获取版本信息：" + pathq, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (FileStream fs = new FileStream(path, FileMode.CreateNew))
                        {
                            BinaryWriter bw = new BinaryWriter(fs);
                            bw.Write(buff, 0, buff.Length);
                            bw.Close();
                            fs.Close();
                        }
                        Compress.UnpackFile(path, gxpath);
                        new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "解压文件成功", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                        bool result = CommonFunction.CopyDirectory(gxpath + "/yghd", gxpath);
                        if (result)
                        {
                            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
                            AppSettingsSection app = config.AppSettings;
                            //string v = app.Settings["Version"].Value;
                            //if (v != version)
                            //{
                            app.Settings["Version"].Value = version;
                            config.Save(ConfigurationSaveMode.Modified);
                            //}
                            string delpath = gxpath + "/yghd";
                            FileAttributes attr = File.GetAttributes(delpath);
                            if (attr == FileAttributes.Directory)
                            {
                                Directory.Delete(delpath, true);
                            }
                            else
                            {
                                File.Delete(delpath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    return;
                }
            }
            //string a = System.Web.HttpContext.Current.Server.MapPath("/"); //F:\高科开发程序\YJQAPMS\D.实现阶段\YJQAPMS\YJQAPMS\webupload\profile\2017060808464980220.doc
            //string path = a.Substring(0, a.LastIndexOf("\\"));//F:\高科开发程序\YJQAPMS\D.实现阶段\YJQAPMS\YJQAPMS\webupload\profile
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

            //if (System.IO.File.Exists(a))
            //{
            //    System.IO.File.Delete(a);
            //}

            
            
        }
        public static void SendWXmsg(string agent)
        {

            //DataTable dt = new SysUserDAL().GetNotice();
            DataTable dt = new SysUserDAL().GetNoNotice();
            if (dt != null && dt.Rows.Count > 0) 
            {
               // DataRow[] drt  = dt.Select("NType=1");//1:weixin ,2:duanxin
                string token = WeixinQYAPI.GetToken(1, "Notice");
                //WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                foreach (DataRow dr in dt.Rows) 
                {
                    if (token != "")
                    {
                        string msg = "";
                        string host = ConfigurationManager.AppSettings["SendUrl"] +"/app/";
                        string senddate =dr["SendDate"].ToString() ;//通知时间
                        string sendusername = dr["SendUserName"].ToString(); //通知人

                        if (dr["MsgUrl"].ToString() == "")
                            msg = WeixinQYAPI.SendMessage(token, dr["AcceptUser"].ToString(), agent, dr["NContent"].ToString());
                        else
                            //发送微信图文消息
                              //msg = WeixinQYAPI.SendMessage(token, dr["AcceptUser"].ToString(), int.Parse(agent), dr["MsgTitle"].ToString(), dr["NContent"].ToString(), host + dr["MsgUrl"].ToString(), dr["PicUrl"].ToString() == "" ? "" : (host + dr["PicUrl"].ToString()));
                            //发送微信卡片消息
                              msg = WeixinQYAPI.SendMessageCard(token, dr["AcceptUser"].ToString(), int.Parse(agent), dr["MsgTitle"].ToString(), dr["NContent"].ToString(), host + dr["MsgUrl"].ToString(), senddate, sendusername, dr["PicUrl"].ToString() == "" ? "" : (host + dr["PicUrl"].ToString()));
                        if (msg == "ok")
                        {
                            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "消息发送成功", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            int result = new SysUserDAL().UpdateNotice(dr["SNID"].ToString());
                           //return "发送成功";
                        }
                        else
                        {
                            if (HttpRuntime.Cache.Get(dr["SNID"].ToString()) != null && HttpRuntime.Cache.Get(dr["SNID"].ToString()).ToString() != "")
                            {
                               
                                int a = Convert.ToInt32(HttpRuntime.Cache.Get(dr["SNID"].ToString()).ToString()) + 1;
                                if (a >= 3)
                                {
                                    HttpRuntime.Cache.Remove(dr["SNID"].ToString());
                                    int result = new SysUserDAL().UpdateNotice(dr["SNID"].ToString());
                                }
                                else
                                {
                                    HttpRuntime.Cache.Insert(dr["SNID"].ToString(), a, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
                                }
                            }
                            else
                            {
                                HttpRuntime.Cache.Insert(dr["SNID"].ToString(), 1, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
                            }
                            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "消息发送失败【"+msg+"】", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            //return "微信消息发送失败";
                        }
                    }
                }
            }
            
        }

        #region 区平台方法
        /// <summary>
        /// 获取电子政务（每分钟执行一次）
        /// </summary>
        private static void ReceiveOA()
        {
            try
            {
                localhost1.WebService1 a = new localhost1.WebService1();
                //string s = a.HelloWorld();
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                //string url = GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl");
                a.Url = GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl") + "/WebService1.asmx";
                //a.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                //a.Url = XMLHelper.GetXmlNodes(path+"BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                localhost1.OA[] oa;
                if (a.HelloWorld() == "You Are Welcome")
                {
                    if (a.ReceiveOA(new Guid(ConfigurationManager.AppSettings["SGUID"]), out oa))
                    {
                        List<EgovernmentEntity> egoEntity = new List<EgovernmentEntity>();
                        if (oa != null && oa.Length > 0)
                        {
                            foreach (localhost1.OA oamodel in oa)
                            {
                                // OA model = new OA();
                                EgovernmentEntity model = new EgovernmentEntity();
                                //model= oa.ArticleID ;
                                model.EID = oamodel.zwid.ToString();
                                model.Etitle = oamodel.Title;
                                model.Ecode = DateTime.Now.ToString("yyyyMMddHHmmss");
                                model.EKey = "";
                                model.EDepartment = oamodel.lwdw;
                                model.EtitleType = oamodel.SubTitle;
                                model.EContent = oamodel.Content.Replace("href=\"", "href=\"" + GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl"));
                                model.Opened = 0;
                                model.Completed = 0;
                                model.IsApproved = 1;
                                model.Etype = 0;
                                model.CreateUser = oamodel.InputerName;

                                model.CreateDate = oamodel.UpdateTime;
                                model.Estate = (int)CommonEnum.GWType.未处理;
                                model.IsSave = 1;
                                model.IsSuperior = (int)CommonEnum.IsorNot.否;
                                //Egovernment_FlowEntity modelflow = new Egovernment_FlowEntity();
                                //modelflow.Comment = oamodel.Operator;
                                //modelflow.IsSendMess = 0;
                                //modelflow.AcceptUser = "";
                                //modelflow.State = (int)CommonEnum.GWType.未处理;
                                //modelflow.IsRead = 0;
                                egoEntity.Add(model);

                            }
                            int result = new EgovernmentDAL().ReceiveOA(egoEntity);
                            if (result == 0)
                            {
                                string message = "";
                                string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "DX/IsOpen");
                                if (isopen == "1")
                                {
                                    DataTable dt = new SysUserDAL().GetPhone((int)CommonEnum.HumanType.政务接受人);
                                    if (dt != null && dt.Rows.Count > 0)
                                    {
                                        string phone = "";
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            if (dr[0].ToString() != "")
                                                phone += dr[0] + ",";
                                        }
                                        if (phone.TrimEnd(',') != "")
                                        {
                                            message = SendMsg("", phone.TrimEnd(',')) + ",";
                                        }
                                    }
                                }
                                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                                if (model1.IsOpen == 1)
                                {
                                    DataTable dt = new SysUserDAL().GetPhone((int)CommonEnum.HumanType.政务接受人);
                                    string phone = "";
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        if (dr[0].ToString() != "")
                                            phone += dr[1] + ",";
                                    }
                                    WXSendMsg1(model1.Agent, phone.Trim(','), "您有新的电子政务,请及时查看",out message);


                                }

                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "成功接收到上级下发政务" + message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));

                            }
                            else { new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "接收政务失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD")); }
                        }
                        else
                        {
                            // new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "null", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                        }
                    }
                    else
                    {
                        //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "false", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    }
                }
                else
                {

                }
            }
            catch (Exception error)
            {
                //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                return;
                //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
            }
        }

        public static string SendMsg(string content, string touser)
        {
            MessageConfigEntity msmodel = new MessageConfigDAL().GetObjByID("政务通知");
            return ALiDaYu.SendMessage(msmodel, content, touser);
        }

        public static void OaMsgSend() 
        {
            while (true)
            {
                int milli = 0;
                try
                {
                    SysSetConfigEntity model = new SysSetConfigDAL().GetObjByID();
                    milli = model.SendInterval * 1000 * 3600;//SendInterval单位为小时 转化成毫秒数
                    if (milli <= 600000)
                        milli = 1800000;
                    string message = "";
                    bool wx = true;
                    DataTable dt = new DataTable();
                    WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                    if (model1.IsOpen == 1)
                    {
                        dt = new Egovernment_FlowDAL().GetNoReadList();
                        string phone = "";
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr[0].ToString() != "")
                                phone += dr[0] + "|";
                        }
                        if (WXSendMsg1(model1.Agent, phone.Trim('|'), "您有新的电子政务,请及时查看", out message))
                        {
                            wx = false;
                        }
                        else
                        {
                            new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, message, ""));
                        }
                    }
                    if (wx)
                    {
                        string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "DX/IsOpen");
                        if (isopen == "1")
                        {
                            dt = new Egovernment_FlowDAL().GetNoReadList();
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string phone = "";
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr[1].ToString() != "")
                                        phone += dr[1] + ",";
                                }
                                if (phone.TrimEnd(',') != "")
                                {
                                    message = SendMsg("", phone.TrimEnd(',')) + ",";
                                }
                            }

                        }
                    }
                    new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "发送通知" + message, ""));
                }
                catch (Exception ex)
                {
                     new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, ""));
                }
                System.Threading.Thread.Sleep(milli);
            }
        }

        /// <summary>
        /// 更新教装项目审核状态
        /// </summary>
        private static void JZUpdate()
        {
            try
            {
                string pid = "";
                localhost1.WebService1 a = new localhost1.WebService1();
                //a.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                a.Url = GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl") + "/WebService1.asmx";
                if (a.HelloWorld() == "You Are Welcome")
                {
                    //获取教装项目审核状态为未通过的项目
                    DataTable jt = new JZProjectManageDAL().GetObjByState();
                    if (jt != null && jt.Rows.Count > 0)
                    {
                        for (int j = 0; j < jt.Rows.Count; j++)
                        {
                            pid += jt.Rows[j]["PID"].ToString() + ",";
                        }
                        //foreach (DataRow dr in jt.Rows)
                        //{
                        //    pid += dr["PID"].ToString();
                        //}
                    }

                    localhost1.JZProjectManageEntity[] jz;
                    //对应 区平台 
                    if (a.JZProjectState(new Guid(ConfigurationManager.AppSettings["SGUID"]), pid, out jz))
                    {

                        List<JZProjectManageEntity> egoEntity = new List<JZProjectManageEntity>();
                        if (jz != null && jz.Length > 0)
                        {
                            foreach (localhost1.JZProjectManageEntity oamodel in jz)
                            {
                                JZProjectManageEntity model = new JZProjectManageEntity();
                                model.PID = oamodel.PID;
                                //model.State = oamodel.State; //驳回 = 0,未审核 = 1,通过 = 2,否决=3
                                //model.ProName = oamodel.ProName;
                                egoEntity.Add(model);
                            }

                            int result = new JZProjectManageDAL().JZUpdate(egoEntity);
                            if (result == 2)
                            {
                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "更新教装项目审核状态成功", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            }
                            else
                            {
                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "更新教装项目审核状态失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
            }
        }

        /// <summary>
        /// 更新基建项目审核状态
        /// </summary>
        private static void JJUpdate()
        {
            try
            {
                string baid = "";
                localhost1.WebService1 a = new localhost1.WebService1();
                //a.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                a.Url = GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl") + "/WebService1.asmx";
                if (a.HelloWorld() == "You Are Welcome")
                {
                    //获取基建项目审核状态为未通过的项目
                    DataTable jt = new BuildApplyDAL().GetObjByState((int)CommonEnum.Deleted.未删除);
                    if (jt != null && jt.Rows.Count > 0)
                    {
                        for (int j = 0; j < jt.Rows.Count; j++)
                        {
                            baid += jt.Rows[j]["BAID"].ToString() + ",";
                        }
                    }



                    localhost1.BuildApplyEntity[] jj;
                    //对应 区平台 
                    if (a.JJProjectState(new Guid(ConfigurationManager.AppSettings["SGUID"]), baid, out jj))
                    {
                        List<BuildApplyEntity> egoEntity = new List<BuildApplyEntity>();
                        if (jj != null && jj.Length > 0)
                        {
                            foreach (localhost1.BuildApplyEntity oamodel in jj)
                            {
                                BuildApplyEntity model = new BuildApplyEntity();
                                model.BAID = oamodel.BAID;
                                egoEntity.Add(model);
                            }

                            int result = new BuildApplyDAL().JZUpdate(egoEntity);
                            if (result == 2)
                            {
                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "更新基建项目审核状态", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            }
                            else
                            {
                                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "更新基建项目审核状态", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
            }
        }
        /// <summary>
        /// 更新项目类型
        /// </summary>
        private static void UpdateByProType()
        {
            SysData1DAL sysData1DAL = new SysData1DAL();
            SysLogDAL sysLogDAL = new SysLogDAL();
            try
            {
                string sdid = "";
                List<SysData1Entity> Entity = new List<SysData1Entity>();
                localhost1.WebService1 server = new localhost1.WebService1();
                localhost1.SysDataEntity[] asset;
                server.Url = GetUrl(AppDomain.CurrentDomain.BaseDirectory, "ServerUrl") + "/WebService1.asmx";

                if (server.HelloWorld() == "You Are Welcome")
                {
                    DataTable dt = sysData1DAL.GetList((int)CommonEnum.IsorNot.否, 1);//1为资产分类
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            sdid += dr["SDID"].ToString() + ",";
                        }
                    }
                    if (server.AssetType(sdid, 1, out asset))
                    {
                        if (asset.Length > 0)
                        {
                            foreach (localhost1.SysDataEntity m in asset)
                            {
                                SysData1Entity model = new SysData1Entity();
                                model.SDID = m.SDID;
                                model.DataName = m.DataName;
                                model.DataDesc = m.DataDesc;
                                model.DataType = 1;
                                model.PID = m.PID;
                                model.Isdel = (int)CommonEnum.IsorNot.否;
                                model.IsSysSet = (int)CommonEnum.IsorNot.是;
                                Entity.Add(model);
                            }
                            int result = sysData1DAL.UpdateProType(Entity);
                            if (result == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "更新项目类别成功", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                                // ShowMessage("更新成功【本次共更新" + asset.Length + "条】");
                            }
                            else
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "更新项目类别失败Result=" + result, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                            }
                        }
                        //else { ShowMessage("暂无更新，请稍后再试"); }
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "更新项目类别失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                        //ShowMessage("更新失败"); 
                    }
                }
            }
            catch (Exception ex)
            {
                //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                //  ShowMessage(ex.Message);
            }

        }
        /// <summary>
        /// 获取区平台配置地址
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private static string GetUrl(string path, string nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(path + "/BaseInfoSet.xml");
                //读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                XmlNode root = xmlDoc.SelectSingleNode("//" + nodes);//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
                if (root != null)
                {
                    return root.InnerText;

                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, e.Message, ""));
                return e.Message;
            }
        }



        #endregion

        public AttendVacationDAL attendVacationDAL = new AttendVacationDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        // public SysUserDAL sysUserDAL = new SysUserDAL();
     

        public void HandleFace(Bitmap bitmap, string facesettoken, string path, object camearobj)
        {
            string facetoken = Face.Search(bitmap, facesettoken);
            //SysUserEntity getpt = new SysUserEntity();
            if ((facetoken == "No Result" || facetoken == "" || facetoken.IndexOf("$error") == 0))
            {
                if (facetoken.IndexOf("$error") != 0)
                {
                    //报警,保存当前图像
                }
            }
            else
            {
                //需修改查询
                SysUserEntity fu = sysUserDAL.GetFaceNum(facetoken);

                if (fu != null)
                {
                    AttendRecordEntity fl = new AttendRecordEntity();
                    CameraClass cc = (CameraClass)camearobj;
                    fl.UserNum = fu.UID;
                    fl.AttImg = "/CameraPic/" + path.Substring(path.LastIndexOf("/") + 1, path.Length - path.LastIndexOf("/") - 1);
                    fl.RecordDate = DateTime.Now;
                    fl.ARID = "";
                    fl.MachineCode = cc.name;
                    fl.AttendType = (int)CommonEnum.AttendType.人脸识别;
                    fl.IsAnalysis = (int)CommonEnum.IsorNot.否;
                    fl.AttendDesc = "人脸识别";
                    fl.OutType = cc.outtype;
                    // fl.OutType
                    int result = attendRecordDAL.Add(fl);
                    if (result == 0)
                    {
                        string newpath = path.Replace("CameraPicTemp", "CameraPic");
                        File.Copy(path, newpath, true);

                        WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                        if (model1.IsOpen == 1)
                        {
                            string message = "";
                            //type=1 进入打卡 2离开打卡
                            if (fl.OutType == 1)
                                message = WXSendMsg(model1.Agent, fu, fu.RealName + "于" + fl.RecordDate + "进入校园");
                            else
                                message = WXSendMsg(model1.Agent, fu, fu.RealName + "于" + fl.RecordDate + "离开校园");
                        }
                    }
                }

            }

            System.Threading.Thread.CurrentThread.Abort();

        }

        public void Search(string path, string camerapath, string facesettoken, object camearobj)
        {
            try
            {
                JArray jarray = Face.DetectAll(path);
                if (jarray != null && jarray.Count > 0)
                {
                    //获取每张人脸的图片
                    foreach (var jo in jarray)
                    {
                        JObject facepot = (JObject)jo["face_rectangle"];

                        int width = Convert.ToInt32(facepot["width"]) + 10;
                        int height = Convert.ToInt32(facepot["height"]) + 10;

                        int top = Convert.ToInt32(facepot["top"]) > 5 ? Convert.ToInt32(facepot["top"]) - 5 : Convert.ToInt32(facepot["top"]);
                        int left = Convert.ToInt32(facepot["left"]) > 5 ? Convert.ToInt32(facepot["left"]) - 5 : Convert.ToInt32(facepot["left"]);


                        Image fromImage = Image.FromFile(path);
                        //创建新图位图
                        Bitmap bitmap = new Bitmap(width, height);
                        //创建作图区域
                        Graphics graphic = Graphics.FromImage(bitmap);
                        //截取原图相应区域写入作图区
                        graphic.DrawImage(fromImage, 0, 0, new Rectangle(left, top, width, height), GraphicsUnit.Pixel);
                        //从作图区生成新图
                        Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());

                        Thread ts = new Thread(delegate()
                        {
                            HandleFace(bitmap, facesettoken, path, camearobj);
                        });
                        ts.IsBackground = true;
                        ts.Start();

                    }
                }

                System.Threading.Thread.CurrentThread.Abort();
            }
            catch
            {

            }



        }

        #endregion


        #region 人脸2
        public void ArcSearch(string path, string camerapath, string facesettoken, object camearobj)
        {
            try
            {
                JArray jarray = Face.DetectAll(path);
                if (jarray != null && jarray.Count > 0)
                {
                    //获取每张人脸的图片
                    foreach (var jo in jarray)
                    {
                        JObject facepot = (JObject)jo["face_rectangle"];

                        int width = Convert.ToInt32(facepot["width"]) + 10;
                        int height = Convert.ToInt32(facepot["height"]) + 10;

                        int top = Convert.ToInt32(facepot["top"]) > 5 ? Convert.ToInt32(facepot["top"]) - 5 : Convert.ToInt32(facepot["top"]);
                        int left = Convert.ToInt32(facepot["left"]) > 5 ? Convert.ToInt32(facepot["left"]) - 5 : Convert.ToInt32(facepot["left"]);


                        Image fromImage = Image.FromFile(path);
                        //创建新图位图
                        Bitmap bitmap = new Bitmap(width, height);
                        //创建作图区域
                        Graphics graphic = Graphics.FromImage(bitmap);
                        //截取原图相应区域写入作图区
                        graphic.DrawImage(fromImage, 0, 0, new Rectangle(left, top, width, height), GraphicsUnit.Pixel);
                        //从作图区生成新图
                        Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());

                        Thread ts = new Thread(delegate()
                        {
                            HandleFace(bitmap, facesettoken, path, camearobj);
                        });
                        ts.IsBackground = true;
                        ts.Start();

                    }
                }

                System.Threading.Thread.CurrentThread.Abort();
            }
            catch
            {

            }



        }
        #endregion

        public void ImageHandle(object path)
        {
            List<string> ImageList = new List<string>();
            List<string> delimglist = new List<string>();

            System.Timers.Timer ImageHandle = new System.Timers.Timer();
            ImageHandle.Interval = 60000;
            string pathvalue = path.ToString();
            ImageHandle.Elapsed += new System.Timers.ElapsedEventHandler((s, e) => ImageHandel(s, e, pathvalue));
            ImageHandle.AutoReset = true;
            ImageHandle.Start();


        }
        public void GetCamera(string camerapath)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ImageHandle));
            thread.IsBackground = true;
            thread.Start(camerapath);

            string facesettoken = ConfigurationManager.AppSettings["faceset_token"];

            string message = null;
            if (CHCNetSDK.NET_DVR_Init())
            {
                //获取所有的摄像机表
                List<AttendMachineEntity> amlist = new List<AttendMachineEntity>();
                DataTable dt = new AttendMachineDAL().GetList(3);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        AttendMachineEntity model = new AttendMachineEntity();
                        model.IPUrl = dr["IPUrl"].ToString();
                        model.MachiName = dr["MachiName"].ToString();
                        model.UserID = dr["UserID"].ToString();
                        model.Pwd = dr["Pwd"].ToString();
                        model.PotCode = dr["PotCode"].ToString();
                        model.OutType = int.Parse(dr["OutType"].ToString());
                        amlist.Add(model);
                    }
                    //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                }
                if (amlist.Count > 0)
                {
                    foreach (AttendMachineEntity am in amlist)
                    {
                        Thread camerathread = new Thread(new ParameterizedThreadStart(CameraThread));
                        camerathread.IsBackground = true;
                        CameraClass cc = new CameraClass();
                        cc.address = am.IPUrl;
                        cc.port = Convert.ToInt16(am.PotCode);
                        cc.username = am.UserID;
                        cc.password = am.Pwd;
                        cc.camerapath = camerapath;
                        cc.facesettoken = facesettoken;
                        cc.name = am.MachiName;
                        cc.outtype = am.OutType;
                        camerathread.Start(cc);
                    }
                }
            }
            else
            {
                message = "初始化失败";
                //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, message, "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
            }
        }

        private class CameraClass
        {
            public string address { get; set; }
            public Int16 port { get; set; }
            public string username { get; set; }
            public string password { get; set; }

            public string camerapath { get; set; }

            public string facesettoken { get; set; }

            public string name { get; set; }
            public int outtype { get; set; }

        }

        public void CameraThread(object camearobj)
        {
            string message = null;
            CameraClass cc = (CameraClass)camearobj;
            string DVRIPAddress = cc.address; //设备IP地址或者域名
            Int16 DVRPortNumber = cc.port;//设备服务端口号
            string DVRUserName = cc.username;//设备登录用户名
            string DVRPassword = cc.password;//设备登录密码

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);

            if (m_lUserID < 0)
            {
                message = "Login failed, error code= " + CHCNetSDK.NET_DVR_GetLastError();
            }
            else
            {

                DateTime begindate = DateTime.Now, enddate = DateTime.Now;

                while (1 == 1)
                {
                    try
                    {
                        DataTable attendsetlist = new AttendSetDAL().GetList();
                        bool isvedio = false;

                        if (attendVacationDAL.IsVacation(DateTime.Now) == 0)
                        {
                            //可考虑在固定的时间内进行统计，非固定时间不统计
                            foreach (DataRow dr in attendsetlist.Rows)
                            {
                                begindate = Convert.ToDateTime(dr["MBegin"]);
                                enddate = Convert.ToDateTime(dr["MEnd"]);
                                begindate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + begindate.ToString("HH:mm:ss"));
                                enddate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + enddate.ToString("HH:mm:ss"));
                                if (DateTime.Now > begindate && DateTime.Now < enddate)
                                {
                                    isvedio = true;
                                    break;
                                }
                            }
                        }

                        if (isvedio)
                        {
                            //需要分摄像头修改
                            string imagepath = GetImage(cc.camerapath, m_lUserID, cc.name);
                            try
                            {
                                Thread ts = new Thread(delegate()
                                {
                                    Search(imagepath, cc.camerapath, cc.facesettoken, camearobj);
                                });
                                ts.IsBackground = true;
                                ts.Start();
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {

                    }

                    System.Threading.Thread.Sleep(200);
                }
            }
        }


        public string GetImage(string path, int m_lUserID, string machinename, int channel = 1)
        {
            string imagename = "";
            string sJpegPicFileName;
            //图片保存路径和文件名 the path and file name to save
            sJpegPicFileName = path + DateTime.Now.ToString("yyyyMMddHHmmss") + "_Camera_" + machinename + ".jpg";

            int lChannel = channel; //通道号 Channel number

            CHCNetSDK.NET_DVR_JPEGPARA lpJpegPara = new CHCNetSDK.NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //图像质量 Image quality
            lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

            //JPEG抓图 Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
            {

            }
            else
            {
                imagename = sJpegPicFileName;
            }
            return imagename;
        }


        public void ImageHandel(object sender, System.Timers.ElapsedEventArgs e, string path)
        {
            try
            {
                //清除该文件夹的文件
                DirectoryInfo d = new DirectoryInfo(path);
                FileSystemInfo[] images = d.GetFileSystemInfos();
                foreach (FileSystemInfo image in images)
                {
                    try
                    {
                        File.Delete(image.FullName);
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        #region 发送企业微信消息
        /// <summary>
        /// 发送企业微信消息
        /// </summary>
        /// <returns>返回结果</returns>
        public SysLogDAL sysLogDAL = new SysLogDAL();
        private string WXSendMsg(string agent, SysUserEntity model, string mess)
        {
            string token = WeixinQYAPI.GetToken(1, "Main");
            if (token != "")
            {
                //string AgentID = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//AgentID");
                string AgentID = agent;

                string msg = WeixinQYAPI.SendMessage(token, model.UserID, AgentID, mess);
                if (msg == "ok")
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "人脸识别结果推送", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    return "发送成功";
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "人脸识别成功，但结果推送失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    return "微信消息发送失败";
                }
            }
            else
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "微信凭证调用失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                return "微信凭证调用失败";
            }

        }
        private string WXSendMsg(string agent, string userid, string mess)
        {
            string token = WeixinQYAPI.GetToken(1, "Main");
            if (token != "")
            {
                //string AgentID = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//AgentID");
                string AgentID = agent;

                string msg = WeixinQYAPI.SendMessage(token, userid, AgentID, mess);
                if (msg == "ok")
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "人脸识别结果推送", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    return "发送成功";
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "人脸识别成功，但结果推送失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    return "微信消息发送失败";
                }
            }
            else
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "微信凭证调用失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                return "微信凭证调用失败";
            }

        }
        private static bool WXSendMsg1(string agent, string userid, string mess,out string message)
        {
            message="";
            string token = WeixinQYAPI.GetToken(1, "Notice");
            if (token != "")
            {
                //string AgentID = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//AgentID");
                string AgentID = agent;

                string msg = WeixinQYAPI.SendMessage(token, userid, AgentID, mess);
                if (msg == "ok")
                {
                    //return true;
                    //new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "政务提醒推送", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    //message= "发送成功";
                    return true;
                }
                else
                {
                    new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "政务接收成功，但消息推送失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                    message = msg;
                    return false;
                }
            }
            else
            {

                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "微信凭证调用失败", "E95D4A5F-D086-4A74-B949-EDF72D802CFD"));
                message= "微信配置出错";
                return false;
            }

        }
        #endregion

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        public enum ErrorCode 
        {
            暂未授权=10001,
            试用过期=10002,
            域名未授权=10003,
            无授权文件=10004,
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
               // GetVersion();
                string reason = "";
                string result = test(DateTime.Now, HttpContext.Current.Request.Url.Host, ref reason);
                if (result != "0")
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = "text/html";
                    HttpContext.Current.Response.AddHeader("Content-type", "text/html;charset=UTF-8");
                    HttpContext.Current.Response.Write("<h1>此版本" + CommonFunction.CheckEnum<ErrorCode>(result) + "," + reason + "</h1><h2>如有疑问请联系：<a href='http://www.whgkdz.com' target='_blank' style='text-decoration:none;'>芜湖高科电子</a> 0553-3821930 邮箱：<a href='mailto:gkdz168@126.com'  target='_blank' style='text-decoration:none;'>gkdz168@126.com</a></h2>");
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                    //HttpContext.Current.Response.Write("<h1>此版本" + CommonFunction.CheckEnum<ErrorCode>(result) + "," + reason + "</h1><h2>如有疑问请联系：<a href='http://www.whgkdz.com' target='_blank' style='text-decoration:none;'>芜湖高科电子</a> 0553-3821930 邮箱：<a href='mailto:gkdz168@126.com'  target='_blank' style='text-decoration:none;'>gkdz168@126.com</a></h2>");
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
               
                //string a = HttpContext.Current.Request.Url.Host;
                //string text = CommonFunction.DecryptTxt(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/license.txt"));
                ////if (text.IndexOf(a) < 0 && a != "localhost")
                ////{
                ////    HttpContext.Current.Response.Redirect("~/ComingSoon.html");
                ////    System.Web.HttpContext.Current.Response.End();
                ////}
                //if (text != "")
                //{
                //    if (text.IndexOf(a) < 0)
                //    {
                //        //HttpContext.Current.Response.Clear();
                //        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Unicode;
                //        HttpContext.Current.Response.Write(("<h1>此版本只能运行在" + text + "</h1>"));
                //        // HttpContext.Current.Request.RewritePath();
                //        //HttpContext.Current.Response.WriteFile(HttpContext.Current.Server.MapPath("~/ComingSoon.html"));
                //        HttpContext.Current.ApplicationInstance.CompleteRequest();
                //    }
                //}
                //else
                //{
                //    HttpContext.Current.Response.Clear();
                //    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                //    HttpContext.Current.Response.Write(("<h1>此版本暂未授权，如有需要请联系：<a href='http://www.whgkdz.com' target='_blank' style='text-decoration:none;'>芜湖高科电子</a> 0553-3821930 邮箱：<a href='mailto:gkdz168@126.com'  target='_blank' style='text-decoration:none;'>gkdz168@126.com</a></h1>"));
                //    // HttpContext.Current.Request.RewritePath();
                //    //HttpContext.Current.Response.WriteFile(HttpContext.Current.Server.MapPath("~/ComingSoon.html"));
                //    HttpContext.Current.ApplicationInstance.CompleteRequest();
                //}
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<h1>此版本暂未授权，如有需要请联系：<a href='http://www.whgkdz.com' target='_blank' style='text-decoration:none;'>芜湖高科电子</a> 0553-3821930 邮箱：<a href='mailto:gkdz168@126.com'  target='_blank' style='text-decoration:none;'>gkdz168@126.com</a></h1>");
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                // HttpContext.Current.Request.RewritePath();
                //HttpContext.Current.Response.WriteFile(HttpContext.Current.Server.MapPath("~/ComingSoon.html"));
                // HttpContext.Current.Response.End();
            }
        }

        protected string test(DateTime dt,string url, ref string reason)
        {

            try
            {
                string path = Server.MapPath("~/License.dll");
                Assembly asm = Assembly.LoadFrom(path);////我们要调用的dll文件路径
                //加载dll后,需要使用dll中某类.
                Type t = asm.GetType("License.License");//获取类名，必须 命名空间+类名  

                //实例化类型
                object o = Activator.CreateInstance(t);

                //得到要调用的某类型的方法
                MethodInfo method = t.GetMethod("ValidateTime");//functionname:方法名字

                object[] obj = { DateTime.Now, url, reason };
                //对方法进行调用
                var keyData = method.Invoke(o, obj);//param为方法参数object数组
                reason = obj[2].ToString();
                return keyData.ToString();
            }
            catch (Exception)
            {
                reason = "需要授权";
                return "10004";
            }
                

                
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            //Thread.Sleep(1000);

            //这里设置你的web地址，可以随便指向你的任意一个aspx页面甚至不存在的页面，目的是要激发Application_Start  
            //string url = "WebForm1.aspx";
            //HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            //Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流  
        }



        #region 网页爬虫
        // 每1h执行一次
        private static void OnTimedEvent2(object source, System.Timers.ElapsedEventArgs e)
        {
            //string url = "whjhoa.cn/ShowClass2.asp?ClassID=7";
            //GetFromHtml(url);

            //GetFromHtml("http://whjhoa.cn/ShowClass2.asp?ClassID=7", 1);//编码格式为GBK
            //GetFromHtml("http://whjhoa.cn/ShowClass2.asp?ClassID=46", 2);//编码格式为UTF8
        }


        //初始加载
        private static void GetFromHtml(string url, int ntype)
        {
            WebRequest request = WebRequest.Create(url);//实例化WebRequest对象
            WebResponse response = request.GetResponse();//创建WebResponse对象

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.ContentType = "text/xml";
            //HttpWebResponse response;
            //try
            //{
            //    response = (HttpWebResponse)request.GetResponse();
            //}
            //catch (WebException ex)
            //{
            //    response = (HttpWebResponse)ex.Response;
            //}

            Stream datastream = response.GetResponseStream();//创建流对象
            Encoding EC = Encoding.Default;//编码格式为GBK
            Encoding ec = Encoding.UTF8;//编码格式为UTF8
            StreamReader reader = new StreamReader(datastream, EC);
            string responseFromServer = reader.ReadToEnd();//数据读取
            GetWorm(responseFromServer, ntype);//htmlDcoument对象用来访问Html文档
            reader.Close();
            datastream.Close();
            response.Close();
        }
      
        //htmlDcoument对象用来访问Html文档
        public static void GetWorm(string strhtml, int ntype)
        {
            try
            {
                HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
                hd.LoadHtml(strhtml);//加载Html文档
               // HtmlNodeCollection NameList = hd.DocumentNode.SelectNodes("//td[@class='tdbg_main']//td[@valign='top']/a");
                HtmlNodeCollection NameList = hd.DocumentNode.SelectNodes("//tr[@class='tdbg_main']//td[@valign='top']/a");
                if (ntype == 1)
                {
                    NameList = hd.DocumentNode.SelectNodes("//tr[@class='tdbg_main']//td[@valign='top']/a");
                }
                else
                {
                    NameList = hd.DocumentNode.SelectNodes("//tr[@class='tdbg_main']//td[@valign='top']/a");
                }
                Stopwatch sp = new Stopwatch();
                sp.Start();

                foreach (HtmlNode name in NameList)
                {
                    DateTime date = DateTime.Now;
                    string title = name.InnerText.Trim();//【教研室】第十一周研训活动通知（2018.11.5～11.9）

                    string titleTo = name.Attributes["title"].Value; //【电教馆】关于开展区级小学信息技术学科教研活动的通知
                    string[] ff = titleTo.Split('\n');
                    string newtitle = ff[0].Replace("文章标题：", "").ToString();
                    string from = ff[1].Replace("作    者：", "").ToString();//电教馆
                    DateTime newdate = Convert.ToDateTime(ff[2].Replace("更新时间：", ""));//更新时间：2018/11/5 10:25:54
                    string newurl = name.Attributes["href"].Value; //http://whjhoa.cn:10000/ShowArticle.asp?ArticleID=73343


                    //string newcontent = GetContent("e:/dlxc.html",1);//编码格式为GBK
                    //string newcontent = GetContent("e:/jyjtz.html", ntype);//编码格式为UTF8
                    string newcontent = "";

                    if (ntype == 1)
                    {
                         //newcontent = GetContent(newurl, ntype);
                        //newcontent = GetContent("e:/dlxc.html", ntype);
                        newcontent = GetContent("e:/tzxx.html", ntype);
                    }
                    else
                    {
                        //string newcontent = GetContent(newurl, ntype);
                         //newcontent = GetContent("e:/jyjtz.html", ntype);
                         newcontent = GetContent("e:/wjxx.html", ntype);
                    }

                   
                    DateTime Tdate = Convert.ToDateTime(date.ToString("yyyy-MM-dd"));
                    DateTime Tnewdate = Convert.ToDateTime(newdate.ToString("yyyy-MM-dd"));

                   //只获取当天的政务
                    if (Tnewdate == Tdate)
                    { 

                       #region 政务 判断是否已存在
                       int enid = new EgovernmentDAL().GetToEID(newtitle, newdate);
                       if (enid != -1)
                       {
                           EgovernmentEntity model = new EgovernmentEntity();
                           Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
                           model.EID = Guid.NewGuid().ToString();
                           model.Etitle = newtitle;
                           model.Ecode = "1";
                           model.EKey = "";
                           //model.EDepartment = "镜湖区教育局";//来文单位
                           model.EDepartment = from.ToString();//来文单位
                           model.EtitleType = "1";
                           model.EContent = newcontent;
                           model.Opened = 0;
                           model.Completed = 0;
                           model.IsApproved = 1;
                           model.Etype = 0;
                           model.CreateDate = newdate;
                           model.CreateUser = "5AF4C0C3-80B7-451A-978E-124C204018D1";//师范附小
                           model.CreateUser = "E95D4A5F-D086-4A74-B949-EDF72D802CFD";//镜湖小学
                           model.Estate = 0;
                           model.IsSave = 1;//0保存，1提交
                           model.IsSuperior = 0;

                           model_flow.Comment = "请领导审阅";//批注
                           //model_flow.AcceptUser = "35C00599-1A51-484A-8E31-8CF80AB97921,092FF719-9DC0-426D-A688-EDA67891223D,"
                           //+ "82A7993A-A5DE-4558-9EC7-55479C8F810E,FAB4D75E-E9CC-4705-9AD5-5D44F6696CF1,DB7D7BB4-66A1-4358-A408-5CB4795A5D8C,"
                           //+ "8C2E0675-8C6E-403B-BDA0-07AE0E6D0D44,FCB4A54C-B006-4B88-BF9C-22940CD7F18F,"
                           //+ "4A72733A-B8D3-4C18-961A-34BDD19A871A,12D01C67-00C8-4F89-B353-B006533CF82E,C4688E1C-D1B9-448B-B7F3-0E1878F9E861,"
                           //+ "F3F40304-F157-4CA4-98E6-F653DBD460C5,E7FB332B-228B-40AE-B142-729179EB7B73,0F39864B-6A38-40C1-97AD-714A45B61FBD,"
                           //+ "FDFC87A5-A3BB-499A-8756-19739FA79C17,BB3DA89E-C182-46BB-BC64-AEBA8F119CED,"
                           //+ "2112F2E2-8B9A-4C5B-A2EE-FF32B0FD53E5,2A21DD99-F5DE-4B23-B3D1-377F00797A99";//收件人

                           //model_flow.AcceptUser = "5AF4C0C3-80B7-451A-978E-124C204018D1,0F39864B-6A38-40C1-97AD-714A45B61FBD";//师范附小

                           model_flow.AcceptUser = "94554f6c-c4ec-4e83-9e9a-fa6ca6cde616"; //镜湖小学 ,B67F2070-8C93-4011-8D8D-1C4E4CD93993

                           model_flow.IsSendMess = 0;
                           model_flow.State = 0;//未处理状态
                           model_flow.IsRead = 0;

                           int eresult = new EgovernmentDAL().Edit(model, model_flow, 0);
                           if (eresult > 0)
                           {
                               new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "新增区下发的政务【" + newtitle + "】", "5AF4C0C3-80B7-451A-978E-124C204018D1"));
                           }
                           else
                           {
                               //ShowMessage("提交失败");
                               return;
                           }
                           //string zsql = "insert intoTb_Egovernment (EID,Etitle,Ecode,EtitleType,EContent,Opened,Completed,IsApproved,Etype,CreateDate,CreateUser,Estate,IsSave,IsSuperior) values (NEWID(),'" + title + "','1','1','" + newcontent + "',0,0,1,0,'" + newdate + "','5AF4C0C3-80B7-451A-978E-124C204018D1',0,1,0)";
                           //LinkSql(xsql);//链接数据库 
                       }
                       #endregion


                       #region 新闻  判断是否已存在并返回最大新闻ID
                       int nnid = new Web_NewsDAL().GetToNID(title, newdate);
                       if (nnid != -1)
                       {
                           Web_NewsEntity model = new Web_NewsEntity();
                           int id = -1;
                           model.NewsTitle = title;
                           model.Isdel = 0;
                           model.NID = 0;//新闻ID
                           model.MID = "11";//栏目ID为

                           model.NAuthor = "5AF4C0C3-80B7-451A-978E-124C204018D1";//
                           model.CreateDate = newdate;
                           model.Nstate = 1;//是否发布
                           model.IsTop = 0;//置顶设置
                           model.MDescription = 0;

                           model.IsRecommend = 0;
                           model.IsImgNews = 0;
                           model.IsComment = 0;
                           model.NContent = newcontent;
                           model.NOrder = 0;

                           model.NDep = 7;//内容所属部门
                           model.CommentNumber = 0;//评论次数
                           model.NColor = "";
                           model.LinkUrl = "";
                           model.NTtitle = "";

                           model.NKeyWords = "";
                           model.NDescription = "";
                           model.ReadCount = 0;
                           model.Isdel = 0;
                           model.CreateDate = newdate;

                           model.UpdateUser = "5AF4C0C3-80B7-451A-978E-124C204018D1";
                           model.UpdateDate = newdate;
                           model.AduitUser = "5AF4C0C3-80B7-451A-978E-124C204018D1";
                           model.ImageUrl = "";

                           model.IsAudit = 1;
                           model.AduitDate = newdate;
                           model.AuditState = 1;

                           int result = new Web_NewsDAL().EditAccept(model, ref id);
                           if (result > 0)
                           {
                               new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "新增区下发的新闻【" + title + "】", "5AF4C0C3-80B7-451A-978E-124C204018D1"));
                           }
                           else
                           {
                               return;
                           }
                       }
                       #endregion

                   }
                }

                sp.Stop();
                TimeSpan ts = sp.Elapsed;
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "总时长：" + ts.Milliseconds.ToString(), "5AF4C0C3-80B7-451A-978E-124C204018D1"));

            }
            catch(Exception ex)
            {
                //ShowMessage(ex.Message);
                //Console.WriteLine("{0} Second exception.", ex.Message);
                System.IO.File.WriteAllText(@"e:/9.txt", ex.Message, Encoding.Default);

            }
        }


        //获取新闻内容
        public static string GetContent(string urlcontent, int ntype)
        {
            WebRequest request = WebRequest.Create(urlcontent);//实例化WebRequest对象
            WebResponse response = request.GetResponse();//创建WebResponse对象
            Stream datastream = response.GetResponseStream();//创建流对象

            Encoding EC = Encoding.Default;
            if (ntype == 1)
            {
                EC = Encoding.Default;//编码格式为GBK
            }
            else
            {
                EC = Encoding.UTF8;//编码格式为UTF8
            }

            StreamReader reader = new StreamReader(datastream, EC);
            string responseFromServer = reader.ReadToEnd();//数据读取
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(responseFromServer);//加载Html文档
            string content = "";

            if (ntype == 1)  //编码格式为GBK  --公告  通知 
            {
                HtmlNodeCollection NameList = hd.DocumentNode.SelectNodes("//td[@valign='top']//td[@class='title_right2']/span");
                foreach (HtmlNode name in NameList)
                {
                    //content = name.InnerText.Trim();
                    content = name.InnerHtml.Trim();

                }
            }
            else  //编码格式为UTF8  --教育局文件
            {
                HtmlNodeCollection TList = hd.DocumentNode.SelectNodes("//td[@class='Vent']");
                foreach (HtmlNode name in TList)
                {
                    content = name.InnerHtml.Trim();
                }
            }

            return content;
        }



        #endregion


        #region 钉钉考勤接入

        #region 全局变量
        //string appkey = ConfigurationManager.AppSettings["appkey"];
        //string appsecret = ConfigurationManager.AppSettings["appsecret"];
        //string connectstring = ConfigurationManager.AppSettings["ConnectionString"];

        //public DateTime BeginDate = DateTime.Now;
        //public DateTime EndDate = DateTime.Now;
        //public JArray UserList = new JArray();
        //public JArray TUserList = new JArray();
        //public JArray sUserList = new JArray();
        #endregion

        #region 获取钉钉通讯录总员工数
        public int GetFactoryEmployeeCount()
        {
            //onlyActive 0：包含未激活钉钉的人员数量 1：不包含未激活钉钉的人员数量
            int result = 0;
            string accesstoken = GetAccessToken();//获取AccessToken
            JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(GetData("https://oapi.dingtalk.com/user/get_org_user_count?onlyActive=0&access_token=" + accesstoken));
            if (returndata["errmsg"].ToString() == "ok")
            {
                result = Convert.ToInt32(returndata["count"].ToString());
            }

            FileStream jdh = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter kdl = new StreamWriter(jdh);
            kdl.BaseStream.Seek(0, SeekOrigin.End);
            kdl.WriteLine("钉钉通讯录总人数：" + result);
            kdl.Flush();
            kdl.Close();
            jdh.Close();

            return result;

        }
        #endregion

        #region 分页查询企业在职员工userid列表  最大能获取50个
        //获取前50条userid列表
        public void BuildUserList()
        {
            string accesstoken = GetAccessToken();//获取AccessToken
            JObject postdata = new JObject();
            postdata.Add("access_token", accesstoken);
            postdata.Add("status_list", "2,3,5");    //2 试用期；3 正式；5 待离职；-1 无状态
            //postdata.Add("offset", tt);      //分页游标，从0开始
            postdata.Add("offset", 0);      //分页游标，从0开始
            postdata.Add("size", 50);        //分页大小，最大20
            JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/queryonjob?access_token=" + accesstoken, postdata.ToString()));
            if (returndata != null)
            {
                JArray RecordArray = (JArray)returndata["result"]["data_list"];
                UserList = RecordArray;
                //UserList[tt] = RecordArray;

                FileStream jh = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter kl = new StreamWriter(jh);
                kl.BaseStream.Seek(0, SeekOrigin.End);
                //kl.WriteLine("第"+ tt +"到"+ (tt+50) +"条ID总数：" + UserList.Count + " 钉钉ID：" + UserList);
                kl.WriteLine("50条ID总数：" + UserList.Count + " 钉钉ID：" + UserList);
                kl.Flush();
                kl.Close();
                jh.Close();
            }
            else
            {
                FileStream bn = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter pl = new StreamWriter(bn);
                pl.BaseStream.Seek(0, SeekOrigin.End);
                pl.WriteLine("未获取到钉钉ID,原因：" + returndata);
                pl.Flush();
                pl.Close();
                bn.Close();
            }
           
        }
        //获取后50条userid列表
        public void TwoUserList()
        {
            string accesstoken = GetAccessToken();//获取AccessToken
            JObject postdata = new JObject();
            postdata.Add("access_token", accesstoken);
            postdata.Add("status_list", "2,3,5");    //2 试用期；3 正式；5 待离职；-1 无状态
            postdata.Add("offset", 50);     //分页游标，从0开始
            postdata.Add("size", 50);        //分页大小，最大20
            JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/queryonjob?access_token=" + accesstoken, postdata.ToString()));
            if (returndata != null)
            {
                JArray RecordArray = (JArray)returndata["result"]["data_list"];
                TUserList = RecordArray;

                FileStream jh = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter kl = new StreamWriter(jh);
                kl.BaseStream.Seek(0, SeekOrigin.End);
                kl.WriteLine("后50条ID总数：" + TUserList.Count + " 钉钉ID：" + TUserList);
                kl.Flush();
                kl.Close();
                jh.Close();
            }
            else
            {
                FileStream cn = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter ll = new StreamWriter(cn);
                ll.BaseStream.Seek(0, SeekOrigin.End);
                ll.WriteLine("未获取到钉钉ID,原因：" + returndata);
                ll.Flush();
                ll.Close();
                cn.Close();
            }
           
        }
       #endregion

        #region 分页查询企业在职员工userid列表  最大能获取50个  方法2
        public void ToBuildUserList(int i, int tt)
        {
            string accesstoken = GetAccessToken();//获取AccessToken
            JObject postdata = new JObject();
            postdata.Add("access_token", accesstoken);
            postdata.Add("status_list", "2,3,5");    //2 试用期；3 正式；5 待离职；-1 无状态
            postdata.Add("offset", tt);      //分页游标，从0开始
            postdata.Add("size", 50);        //分页大小，最大20
            JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/queryonjob?access_token=" + accesstoken, postdata.ToString()));
            if (returndata != null)
            {
                JArray RecordArray = (JArray)returndata["result"]["data_list"];
                CUserList.Add(RecordArray);

                FileStream jh = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter kl = new StreamWriter(jh);
                kl.BaseStream.Seek(0, SeekOrigin.End);
                kl.WriteLine("第" + tt + "到" + (tt + 49) + "条ID,总数为" + CUserList[i].Count + " 钉钉ID：" + CUserList[i]);
                kl.Flush();
                kl.Close();
                jh.Close();
            }
            else
            {
                FileStream bn = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter pl = new StreamWriter(bn);
                pl.BaseStream.Seek(0, SeekOrigin.End);
                pl.WriteLine("未获取到钉钉ID,原因：" + returndata);
                pl.Flush();
                pl.Close();
                bn.Close();
            }

        }
        #endregion

        public void GetAttendence(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //GetAttendance(BeginDate, EndDate, UserList);
                //GetAttendance(BeginDate, EndDate, TUserList);
                //BeginDate = EndDate;
                //EndDate = DateTime.Now;

                for (int c = 0; c < CUserList.Count; c++)
                {
                    ToGetAttendance(BeginDate, EndDate, CUserList, c);
                }
                BeginDate = EndDate;
                EndDate = DateTime.Now;

            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine("执行插入错误原因(WindowsService: Service Exception)：" + ex.Message + "\n");
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }

        #region Post请求 Get请求 获取AccessToken
        //Post请求
        private string PostData(string url, string postData)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

            myRequest.Method = "POST";
            myRequest.ContentType = "text/xml";
            //myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
        //Get请求
        private string GetData(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        //获取AccessToken
        public string GetAccessToken()
        {
            string accessget = GetData(string.Format("https://oapi.dingtalk.com/gettoken?appkey={0}&appsecret={1}", appkey, appsecret));
            JObject ja = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(accessget);
            return ja["access_token"].ToString();
        }
        
        #endregion

        //获取考勤数据
        public void GetAttendance(DateTime BeginDate, DateTime EndDate, JArray UserList)
        {
            try
            {
                #region .exe 服务
                //string accesstoken = ConfigurationManager.AppSettings["AccessToken"];
                //string expires = ConfigurationManager.AppSettings["AccessTokenExpires"];
                //if (string.IsNullOrEmpty(accesstoken) || string.IsNullOrEmpty(expires) || Convert.ToDateTime(expires) < DateTime.Now)
                //{
                //var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //_config.AppSettings.Settings["AccessToken"].Value = accesstoken;
                //_config.AppSettings.Settings["AccessTokenExpires"].Value = DateTime.Now.AddSeconds(7000).ToString("yyyy-MM-dd HH:mm:ss"); 
                //_config.Save(ConfigurationSaveMode.Modified);
                //}
	            #endregion

                string accesstoken = "";
                string expires = "";
                accesstoken = GetAccessToken();
                expires = DateTime.Now.AddSeconds(7000).ToString("yyyy-MM-dd HH:mm:ss"); 

                JObject postdata = new JObject();
                postdata.Add("access_token", accesstoken);
                //postdata.Add("checkDateFrom", "2018-12-04 07:00:00");
                postdata.Add("checkDateFrom", BeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                postdata.Add("checkDateTo", EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                postdata.Add("userIds", UserList);
                JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/attendance/listRecord?access_token=" + accesstoken, postdata.ToString()));
                string ttt = returndata["recordresult"].ToString();//
                if (returndata["errmsg"].ToString() == "ok" && returndata["recordresult"].ToString() != "[]")
                {
                    AnalysisAttendance((JArray)returndata["recordresult"]);//对考勤数据分析并插入到表中
                }
                else
                {
                    FileStream cs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter kj = new StreamWriter(cs);
                    kj.BaseStream.Seek(0, SeekOrigin.End);
                    kj.WriteLine("在" + BeginDate.ToString("yyyy-MM-dd HH:mm:ss") + "到" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "时间段内执行报错,未获取到考勤打卡记录：" + " 具体信息： " + returndata);
                    kj.Flush();
                    kj.Close();
                    cs.Close();
                }
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.Message);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.InnerException.Message);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }

        //获取考勤数据 2
        public void ToGetAttendance(DateTime BeginDate, DateTime EndDate, List<JArray> CUserList, int i)
        {
            try
            {
                string accesstoken = "";
                string expires = "";
                accesstoken = GetAccessToken();
                expires = DateTime.Now.AddSeconds(7000).ToString("yyyy-MM-dd HH:mm:ss");

                JObject postdata = new JObject();
                postdata.Add("access_token", accesstoken);
                //postdata.Add("checkDateFrom", "2018-12-17 07:00:00");
                 postdata.Add("checkDateFrom", BeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                postdata.Add("checkDateTo", EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //postdata.Add("userIds", UserList);
                postdata.Add("userIds", CUserList[i]);

                JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/attendance/listRecord?access_token=" + accesstoken, postdata.ToString()));
                string ttt = returndata["recordresult"].ToString();//
                if (returndata["errmsg"].ToString() == "ok" && returndata["recordresult"].ToString() != "[]")
                {
                    AnalysisAttendance((JArray)returndata["recordresult"]);//对考勤数据分析并插入到表中
                }
                else
                {
                    FileStream cs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter kj = new StreamWriter(cs);
                    kj.BaseStream.Seek(0, SeekOrigin.End);
                    kj.WriteLine("在" + BeginDate.ToString("yyyy-MM-dd HH:mm:ss") + "到" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "时间段内执行报错,未获取到考勤打卡记录：" + " 具体信息： " + returndata);
                    kj.Flush();
                    kj.Close();
                    cs.Close();
                }
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.Message);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.InnerException.Message);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }

        #region 枚举
        public enum sourceType
        {
            ATM = 1,//考勤机
            BEACON = 2,//蓝牙
            DING_ATM = 3,//钉钉考勤机
            USER = 4,//用户打卡
            BOSS = 5,//老板改签
            APPROVE = 6,//审批系统
            SYSTEM = 7,//考勤系统
            AUTO_CHECK = 8//自动打卡
        }

        public enum timeResult
        {
            Normal = 1,//正常
            Early = 2,//早退
            Late = 3,//迟到
            SeriousLate = 4,//严重迟到
            Absenteeism = 5,//旷工迟到
            NotSigned = 6,//未打卡
        }

        public enum checkType
        {
            //上班
            OnDuty = 1,
            //下班
            OffDuty = 2
        }

        #endregion

        //数据插入执行
        public void AnalysisAttendance(JArray RecordArray)
        {
            FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("在" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  成功获取考勤打卡条数：" + RecordArray.Count);
            sw.Flush();
            sw.Close();
            fs.Close();

            foreach (JObject RecordData in RecordArray)
            {
                string userCheckTime = "";
                checkType checkType = (checkType)Enum.Parse(typeof(checkType), "OnDuty");//考勤类型 OnDuty
                sourceType sourceType = (sourceType)Enum.Parse(typeof(sourceType), "DING_ATM");//打卡类型 DING_ATM

                try
                {
                    //有些数据返回的不全  需要判断
                    string userId = RecordData["userId"].ToString();//钉钉ID
                    if (RecordData.Property("checkType") != null)
                    {
                         checkType = (checkType)Enum.Parse(typeof(checkType), RecordData["checkType"].ToString());//考勤类型 OnDuty
                    }
                    if (RecordData.Property("sourceType") != null)
                    {
                         sourceType = (sourceType)Enum.Parse(typeof(sourceType), RecordData["sourceType"].ToString());//打卡类型
                    }
                    if (RecordData.Property("userCheckTime") != null)
                    {
                        userCheckTime = TimeToDate(RecordData["userCheckTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    //checkType checkType = (checkType)Enum.Parse(typeof(checkType), RecordData["checkType"].ToString());//考勤类型
                    //sourceType sourceType = (sourceType)Enum.Parse(typeof(sourceType), RecordData["sourceType"].ToString());//打卡类型
                    //userCheckTime = TimeToDate(RecordData["userCheckTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    ////string outsideRemark = RecordData["outsideRemark"].ToString();  //打卡备注

                    //判断其特征
                    //DataTable userdt = DoSqlDT("select * from Tb_SysUser where Isdel=0 and CardNum='" + sEnrollNumber + "'");
                    //string userid = userdt.Rows[0]["UID"].ToString();

                    DataTable asmodel = DoSqlDT("select * from Tb_AttendSet where IsUse=1");
                    DateTime begindate = DateTime.Now, enddate = DateTime.Now;
                    int isanalysis = 0;//打卡结果类型
                    foreach (DataRow dr in asmodel.Rows)
                    {
                        begindate = Convert.ToDateTime(dr["MBegin"]);
                        enddate = Convert.ToDateTime(dr["MEnd"]);
                        begindate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + begindate.ToString("HH:mm:ss"));
                        enddate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + enddate.ToString("HH:mm:ss"));
                        if (DateTime.Now > begindate && DateTime.Now < enddate)
                        {
                            isanalysis = Convert.ToInt32(dr["AType"]);
                            break;
                        }
                    }

                    string addsql = "insert into Tb_AttendRecord ([ARID],[UserNum],[MachineCode],[RecordDate],[AttendType],[IsAnalysis],[AttendDesc],[OutType],[AttImg]) values (NewID(),'" + userId
                       + "','" + (int)sourceType
                       + "','" + userCheckTime
                       + "','" + (int)CommonEnum.AttendType.钉钉打卡  //5表示钉钉打卡
                       + "','" + isanalysis
                       + "','" + (int)checkType
                       + "','" + 0
                       + "','" + ""
                       + "')";
                    DoSql(addsql);

                    FileStream gs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter df = new StreamWriter(gs);
                    df.BaseStream.Seek(0, SeekOrigin.End);
                    df.WriteLine("钉钉ID：" + userId + "          打卡时间：" + userCheckTime + "\n");
                    df.Flush();
                    df.Close();
                    gs.Close();

                }
                catch (Exception ex)
                {
                    FileStream fc = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter tg = new StreamWriter(fc);
                    tg.BaseStream.Seek(0, SeekOrigin.End);
                    tg.WriteLine("执行插入错误原因：" + ex.Message + "\n");
                    tg.Flush();
                    tg.Close();
                    fc.Close();
                    //有些数据返回的不全
                }
            }
        }


        private DataTable DoSqlDT(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                adapter.Dispose();
                conn.Close();
            }

            return dt;
        }

        private void DoSql(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }

        private DateTime TimeToDate(string time)
        {
            long jsTimeStamp = long.Parse(time);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
            return dt;
        }




        #endregion

    }
}