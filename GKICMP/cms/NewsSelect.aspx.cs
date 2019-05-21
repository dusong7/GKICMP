/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2016年11月08日
** 描 述:       新闻栏目编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;
using GK.GKICMP.DAL;
using System.IO;

namespace GKICMP.cms
{
    public partial class NewsSelect : PageBase
    {
        public Web_NewsDAL web_NewsDAL = new Web_NewsDAL();
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = web_MenuDAL.GetTable((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_MName, dt, "MID", "MName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["BName"] = CommonFunction.GetCommoneString(this.txt_BName.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Web_NewsEntity model = new Web_NewsEntity((string)ViewState["BName"], this.ddl_MName.SelectedValue, (int)CommonEnum.Deleted.未删除);
            model.NAuthor = "";
            model.Nstate = 1;
            DataTable dt = web_NewsDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion

        public string GetConntent(object obj) 
        {
            string html =CommonFunction.xxHTML( obj.ToString());
            return html.Length > 20 ? html.Substring(0, 20) : html;
        }
       
        public string GetUrl(object obj)
        {
           // string path = HttpContext.Current.Request.Url.Authority;
            List<string> list = CommonFunction.GetImgUrl(obj.ToString());
            if (list.Count > 0) 
            {
                return list[0];
            }
            Random rd = new Random();
            if (Directory.Exists(Server.MapPath("../NewsImg/")))
            {
                string rep_path = Server.MapPath("../NewsImg/");
                var files = System.IO.Directory.GetFiles(rep_path, "*.*", System.IO.SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".gif") || s.EndsWith(".bmp") || s.EndsWith(".png"));
                List<string> filelist = new List<string>();
                foreach (string file in files)
                {
                    //读取文件信息
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    
                    if (fi.Extension == ".jpg" || fi.Extension == ".gif" || fi.Extension == ".bmp" || fi.Extension == ".png")
                    {
                        string path = urlConvertor(fi.Name);
                        filelist.Add(path);
                    }
                }
                int a = rd.Next(0, filelist.Count);
                string imgpath = "/NewsImg/" + filelist[a];
                return imgpath;
            }
            return "/images/avatar.png";
        }

        private  string urlConvertor(string strUrl)
        {
            string tmpRootDir = HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录  
            string urlPath = strUrl.Replace(tmpRootDir, ""); //转换成相对路径  
            urlPath = urlPath.Replace(@"/", @"/");
            return urlPath;
        }  
      
        public string GetImgUrl(object obj)
        {
            string path = HttpContext.Current.Request.Url.Authority;
            List<string> list = CommonFunction.GetImgUrl(obj.ToString());
            if (list.Count > 0)
            {
                return path + list[0];
            }
            Random rd = new Random();
            if (Directory.Exists(Server.MapPath("../NewsImg/")))
            {
                string rep_path = Server.MapPath("../NewsImg/");
                var files = System.IO.Directory.GetFiles(rep_path, "*.*", System.IO.SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".gif") || s.EndsWith(".bmp") || s.EndsWith(".png"));
                List<string> filelist = new List<string>();
                foreach (string file in files)
                {
                    //读取文件信息
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);

                    if (fi.Extension == ".jpg" || fi.Extension == ".gif" || fi.Extension == ".bmp" || fi.Extension == ".png")
                    {
                        string path1 = urlConvertor(fi.Name);
                        filelist.Add(path1);
                    }
                }

                int a = rd.Next(0, filelist.Count);
                if (path.IndexOf("http://") < 0)
                    path = "http://" + path;
                string imgpath = path + "/NewsImg/" + filelist[a];
                return imgpath;
              
            }

            if (path.IndexOf("http://") < 0)
                path = "http://" + path;
            return path + "/images/avatar.png";
               
        }

    }
}