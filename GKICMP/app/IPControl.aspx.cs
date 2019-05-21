
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace GKICMP.app
{
    public partial class IPControl : PageBaseApp
    {
        //int ret = 0;
        //IntPtr session_ID;


        int id1 = 0,  id2 = 0, id3 = 0;
        //uint mxId = 0;
        //int playSid = 0;//播放会话id
        IPCast.SetCallBack callback;//保存回调函数不被回收
        int[] termList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Connect();
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            if (!ServeStatue())//如果还没有连接服务器，不执行下一步
            {
                return;
            }
            //int[] t = GetTermList();
            //string strCurrentPath =;//获取当前文件路径
            string MapPath = Server.MapPath(this.hf_FilePath.Value);
            //string fList = System.Web.HttpContext.Current.Server.MapPath("/mp3/dingdong.mp3") + ";" + System.Web.HttpContext.Current.Server.MapPath("/mp3/holdon.mp3");
            if (File.Exists(MapPath))
            {
                try
                {
                    id1 = IPCast.FilePlayStart(MapPath, 1, 3, termList);
                    Debug.WriteLine("IPCast.FilePlayStart id1=" + id1.ToString());
                }
                catch (System.Exception ex)
                {
                    ShowMessage("请检查文件路径是否正确，" + ex.Message);
                }
            }
            else 
            {
                ShowMessage("文件不存在或已删除");
            }
        }

        protected void btn_Stop_Click(object sender, EventArgs e)
        {
            bool bl = IPCast.FilePlayStop(id1);
            Debug.WriteLine("IPCast.FilePlayStop(id1)=" + bl.ToString());
        }

        #region 检查服务器是否连接
        //检查服务器是否连接
        /// <summary>
        /// 检查服务器是否连接
        /// </summary>
        /// <returns></returns>
        private bool ServeStatue()
        {
            if (!IPCast.IPCAST_ServerStatus())
            {
                ShowMessage("服务器连接失败！");
                //this.btn_Connect.Focus();//连接获得焦点
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 获取终端列表
        /// <summary>
        /// 获取终端列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int[] GetTermList()
        {
            if (!ServeStatue())//如果还没有连接服务器，不执行下一步
            {
                return null;
            }

            IntPtr pArray = Marshal.AllocHGlobal(0);
            int count = IPCast.GetTermList(pArray, 0);
            int[] termsid = new int[count];
            string[] terms = new string[count];
            string termIds = IPCast.GetAllTerms(terms);//获取所有的终端数目
            for (int i = 0; i < count; i++)
            {
                termsid[i] = int.Parse(terms[i].Split(' ')[0]);
            }
            return termsid;

        }
        #endregion
        public void SetCallBackHandler(int eventNo, string paramStr)
        {

            string str = "Event:" + eventNo + "," + paramStr;
            ShowMessage(str);
        }
        #region 连接服务器
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Connect()
        {
            //获取输入
            string ipAdd = "220.178.163.78";
            string user = "admin";
            string pwd = "admin";
            bool loginStatus = IPCast.Connect(ipAdd, user, pwd);

            callback = new IPCast.SetCallBack(SetCallBackHandler);
            if (loginStatus)
            {
                IPCast.IPCAST_SetCallBack(callback);//委托函数注意包装不被GC提前释放
            }
            else
            {
                //MessageBox.Show("connect server error");
                ShowMessage("服务器连接失败");
            }
            Debug.WriteLine("IPCast.Connect=" + loginStatus.ToString());
        }
        #endregion

        #region 断开服务器
        /// <summary>
        /// 断开服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_DisConnect_Click(object sender, EventArgs e)
        {
            bool dis = IPCast.DisConnect();
            if (dis)
            {
                //this.ltl_Msg.Text = "Disconnect";
                //this.btn_DisConnect.Enabled = false;
                //this.btn_Connect.Enabled = true;
            }
            Debug.WriteLine("IPCast.DisConnect");
        }
        #endregion
    }
}