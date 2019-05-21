using Entities;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace GK.GKICMP.Common
{
    
    public class XMLHelper
    {
        public static XmlDocument xmldoc;
        public static XmlNode xmlnode;
        public static XmlElement xmlelem;
        public XMLHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        public static void CreateXmlDocument(string path) 
        {
            xmldoc = new XmlDocument();
            //加入XML的声明段落,<?xml version="1.0" encoding="gb2312"?>
            XmlDeclaration xmldecl;
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf_8", null);
            xmldoc.AppendChild(xmldecl);

            //加入一个根元素
            xmlelem = xmldoc.CreateElement("", "Employees", "");
            xmldoc.AppendChild(xmlelem);
            //加入另外一个元素
            for (int i = 1; i < 3; i++)
            {

                XmlNode root = xmldoc.SelectSingleNode("Employees");//查找<Employees> 
                XmlElement xe1 = xmldoc.CreateElement("Node");//创建一个<Node>节点 
                xe1.SetAttribute("genre", "DouCube");//设置该节点genre属性 
                xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性 

                XmlElement xesub1 = xmldoc.CreateElement("title");
                xesub1.InnerText = "CS从入门到精通";//设置文本节点 
                xe1.AppendChild(xesub1);//添加到<Node>节点中 
                XmlElement xesub2 = xmldoc.CreateElement("author");
                xesub2.InnerText = "";
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmldoc.CreateElement("price");
                xesub3.InnerText = "58.3";
                xe1.AppendChild(xesub3);

                root.AppendChild(xe1);//添加到<Employees>节点中 
            }
            //保存创建好的XML文档
            xmldoc.Save(System.Web.HttpContext.Current.Server.MapPath(path)); 
        }
        public static void UpdateXmlDocument() 
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("data.xml"));

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Employees").ChildNodes;//获取Employees节点的所有子节点 

            foreach (XmlNode xn in nodeList)//遍历所有子节点 
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                if (xe.GetAttribute("genre") == "张三")//如果genre属性值为“张三” 
                {
                    xe.SetAttribute("genre", "update张三");//则修改该属性为“update张三” 

                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                    foreach (XmlNode xn1 in nls)//遍历 
                    {
                        XmlElement xe2 = (XmlElement)xn1;//转换类型 
                        if (xe2.Name == "author")//如果找到 
                        {
                            xe2.InnerText = "亚胜";//则修改
                        }
                    }
                }
            }
            xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath("data.xml"));//保存。
        }
        /// <summary>
        /// 获取xml节点属性值<aaa><add key="123" value="321"/></aaa>
        /// </summary>
        /// <returns></returns>
        public static string GetXmlNodeValue(string filename, string node, string attributes) 
        {
            //XmlDataDocument xmlDoc = new System.Xml.XmlDataDocument();
            //xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(filename));
            //XmlElement elem = xmlDoc.(node);
            //return elem.Attributes[attributes].Value;
            return "";
        }
        /// <summary>获取节点值
        /// /<?xml version="1.0" encoding="utf-8"?> 
        /// <Workflow>  
        /// <Activity>  
        /// <ActivityId>1</ActivityId>  
        /// <ActivityName>start</ActivityName>  
        /// <BindingPageId>1</BindingPageId>  
        /// <BindingRoleId>1</BindingRoleId>  
        /// <ActivityLevel>1</ActivityLevel>  
        /// </Activity>  
        /// <Activity>   
        /// <ActivityId>2</ActivityId> 
        /// <ActivityName>pass</ActivityName>   
        /// <BindingPageId>2</BindingPageId>   
        /// <BindingRoleId>2</BindingRoleId>   
        /// <ActivityLevel>2</ActivityLevel>   
        /// </Activity>  
        /// </Workflow>  
        /// </summary>
        /// <param name="filename"></param>
        public static string GetXmlNodes(string filename,string nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string path = "";
                if (HttpContext.Current != null)
                {
                    path = HttpContext.Current.Server.MapPath(filename);//有http请求
                }
                else //非web程序引用         
                {
                    filename = filename.Replace("/", "\\");
                    filename = filename.Replace("~", "");
                    if (filename.StartsWith("\\"))
                    {
                        // filename = filename.Substring(filename.IndexOf('\\', 1)).TrimStart('\\');
                        filename = filename.TrimStart('\\');
                    }
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                }
                xmlDoc.Load(path);
                //读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                XmlNode root = xmlDoc.SelectSingleNode("//" + nodes);//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
                if (root != null)
                {
                    //return (root.SelectSingleNode(nodes)).InnerText;
                    return root.InnerText;
                   
                }
                else
                {
                    return "";
                    //Console.Read();  
                }  
                //xmlDoc.Load(filename);
                //XmlNodeList xnList = xmlDoc.SelectNodes("//Activity//"+nodes);
                ////Console.WriteLine("共有{0}个节点", xnList.Count);//输出xnList中节点个数。  
                ////foreach (XmlNode xn in xnList)
                ////{
                //    //无法使用xn["ActivityId"].InnerText  
                //string ActivityId = xnList.SelectSingleNode("ActivityId")).InnerText;
                //    //string ActivityName = xn.SelectSingleNode("ActivityName").InnerText;
                //    //string ActivityLevel = xn.SelectSingleNode("ActivityLevel").InnerText;
                //    ////  Console.WriteLine("ActivityId:" + ActivityId + "/nActivityName:" + ActivityName + "/nActivityLevel:" + ActivityLevel);  
                //    //Console.WriteLine("ActivityId:  {0}/nActivityName:  {1}/nActivityLevel:  {2}", ActivityId, ActivityName, ActivityLevel);
                ////}
            }
            catch (Exception e)
            {
               new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, e.Message, ""));
                return e.Message;
            }
        }

        public static string GetXmlNodesAttributes(string path, string nodes, string attributes) 
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(path));
            XmlNode node = xmlDoc.SelectSingleNode("//" + nodes);
            return node.Attributes[attributes].Value;
        }
        public static string GetXmlNodesValue(string filename, string nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath(filename));
                //读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                XmlNode root = xmlDoc.SelectSingleNode(nodes);//当节点Workflow带有属性是，使用SelectSingleNode无法读取          
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
        public static bool UpdateXmlNodes(string filename, string nodes,string value) 
        {
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath(filename);
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode("//" + nodes);
                string transDate = xn.InnerText;
                xn.InnerText = value;
                doc.Save(path);
                return true;
            }
            catch (Exception error)
            {
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, ""));
                return false;
            }
        }
        /// <summary>
        /// 获取企业微信参数
        /// </summary>
        /// <param name="filename">保存信息文件路径（相对路径）</param>
        /// <param name="agent">属性"name"的值</param>
        /// <param name="type">1为应用，2为通讯录</param>
        /// <returns></returns>
        public static WeiXinInfoEntity Get(string filename,string agent,int type)
        { 
            WeiXinInfoEntity model = new WeiXinInfoEntity();
            try
            {
                //WeiXinInfoEntity model = new WeiXinInfoEntity();
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                string path = "";
                if (HttpContext.Current != null)
                {
                   path= HttpContext.Current.Server.MapPath(filename);//有http请求
                }
                else //非web程序引用         
                {
                    filename = filename.Replace("/", "\\");
                    filename = filename.Replace("~","");
                    if (filename.StartsWith("\\"))
                    {
                       // filename = filename.Substring(filename.IndexOf('\\', 1)).TrimStart('\\');
                        filename = filename.TrimStart('\\');               
                    }
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                }
                 // path = System.Web.HttpContext.Current.Server.MapPath(filename);
               //XmlReader reader = XmlReader.Create(System.Web.HttpContext.Current.Server.MapPath(filename), settings);
                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);
                reader.Close();
                XmlNode wx = doc.SelectSingleNode("WX");
                XmlElement wxxe = (XmlElement)wx;
                model.IsOpen = int.Parse(wxxe.GetAttribute("IsOpen"));
                if (model.IsOpen == 1)
                {
                    model.CorpID = wxxe.GetAttribute("CorpID");
                    XmlNode xn;
                    if (type == 1)
                        xn = doc.SelectSingleNode("WX/Agent[@name=\"" + agent + "\"]");
                    else
                        xn = doc.SelectSingleNode("WX/TXL");
                    XmlElement ag = (XmlElement)xn;
                    model.Agent = ag.GetAttribute("id");
                    if (xn != null)
                    {
                        XmlNodeList xnl = xn.ChildNodes;
                        model.Secret = xnl.Item(0).InnerText;
                        model.Access_Token = xnl.Item(1).InnerText;
                        model.Token_Time = xnl.Item(2).InnerText;
                    }
                }
            }
            catch (Exception)
            {
            }
            return model;
        }
        public static void Update(string filename, string agent,string node,string value,int type)
        {
            WeiXinInfoEntity model = new WeiXinInfoEntity();
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(System.Web.HttpContext.Current.Server.MapPath(filename), settings);
            xmlDoc.Load(reader);
            reader.Close();
           // XmlElement xe = xmlDoc.DocumentElement; // DocumentElement 获取xml文档对象的根XmlElement.
            //string strPath = string.Format("WX/Agent[@id=\"{0}\"]", agent);
            XmlElement selectXe;
            if (type == 1)
                selectXe = (XmlElement)xmlDoc.SelectSingleNode("WX/Agent[@name=\"" + agent + "\"]");//selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            else
                selectXe = (XmlElement)xmlDoc.SelectSingleNode("WX/TXL");//selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            //selectXe.SetAttribute("Type", dgvBookInfo.CurrentRow.Cells[0].Value.ToString());//也可以通过SetAttribute来增加一个属性
            selectXe.GetElementsByTagName(node).Item(0).InnerText = value;
            //selectXe.GetElementsByTagName("author").Item(0).InnerText = dgvBookInfo.CurrentRow.Cells[3].Value.ToString();
            //selectXe.GetElementsByTagName("price").Item(0).InnerText = dgvBookInfo.CurrentRow.Cells[4].Value.ToString();
            xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath(filename));
        }
        public static void UpdateTXL(string filename, string node, string value)
        {
            WeiXinInfoEntity model = new WeiXinInfoEntity();
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(System.Web.HttpContext.Current.Server.MapPath(filename), settings);
            xmlDoc.Load(reader);
            reader.Close();
            // XmlElement xe = xmlDoc.DocumentElement; // DocumentElement 获取xml文档对象的根XmlElement.
            //string strPath = string.Format("WX/Agent[@id=\"{0}\"]", agent);
            XmlElement selectXe = (XmlElement)xmlDoc.SelectSingleNode("WX/TXL");  //selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            //selectXe.SetAttribute("Type", dgvBookInfo.CurrentRow.Cells[0].Value.ToString());//也可以通过SetAttribute来增加一个属性
            selectXe.GetElementsByTagName(node).Item(0).InnerText = value;
            //selectXe.GetElementsByTagName("author").Item(0).InnerText = dgvBookInfo.CurrentRow.Cells[3].Value.ToString();
            //selectXe.GetElementsByTagName("price").Item(0).InnerText = dgvBookInfo.CurrentRow.Cells[4].Value.ToString();
            xmlDoc.Save(System.Web.HttpContext.Current.Server.MapPath(filename));
        }
        public static string GetNodes(string filename, string xpath)
        {
           // XmlDocument xmlDoc = new XmlDocument();
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                XmlReader reader = XmlReader.Create(System.Web.HttpContext.Current.Server.MapPath(filename), settings);
                doc.Load(reader);
                reader.Close();
                XmlNode wx = doc.SelectSingleNode(xpath);
                if (wx != null)
                {
                    return wx.InnerText;

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
        public static string GetValues(string filename, string xpath)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(System.Web.HttpContext.Current.Server.MapPath(filename));//加载xml
            XmlNodeList xmlnlist = xmldoc.SelectNodes(xpath);//读取xml的节点列表
            //for (int i = 0; i < xmlnlist.Count; i++)
            //{
            //    sb.Append("<a href=\"index.aspx?cityid=" + xmlnlist[i].Attributes["ID"].Value + "\">" + xmlnlist[i].Attributes["CityName"].Value + "</a>");//循环读取里面的值
            //}
            return xmlnlist[0].Attributes["CorpID"].Value;
        }
    }
}
