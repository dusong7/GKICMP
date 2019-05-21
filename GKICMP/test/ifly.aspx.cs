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
using System.Security.Cryptography;
using System.Text;
namespace GKICMP.test
{
    public partial class ifly : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //appName=zhxy (固定)
            //loginName (智慧校园账号)
            //token =  md5加密 (loginName+”_”+appName+”_”+"ifly123!@#")
            string uid = "18226530705";
            string login = "18226530705_zhxy_ifly123!@#";
            //string b = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(login, "MD5");
            string b = md5(login);
            Response.Redirect("http://zh.jyj.wuhu.gov.cn/manage/login_fromAnhuiPlatform.action?appName=zhxy&loginName=" + uid + "&token=" + b, false);

        }
        public String md5(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(str);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();  
            //MD5.Create(str.getBytes());
            //byte b[] = MD5.digest();
            //int i;
            //StringBuilder buf = new StringBuilder();
            //for (int offset = 0; offset < b.length; offset++) {
            // i = b[offset];
            // if (i < 0)
            //  i += 256;
            // if (i < 16)
            //  buf.append("0");
            // buf.append(Integer.toHexString(i));
            //}
            //return buf.toString();
        }
    }
}