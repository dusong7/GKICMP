/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月26日 09点53分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Web_MenuEntity
    {

        /// <summary>
        /// Web_Menu表实体
        ///</summary>
        public Web_MenuEntity()
        {
        }


        /// <summary>
        /// Web_Menu表实体
        /// </summary>
        /// <param name="mid">栏目ID</param>1
        /// <param name="mname">栏目名称</param>1
        /// <param name="pid">父级id</param>1
        /// <param name="morder">排序</param>1
        /// <param name="mtype">类别 1：单篇  2：新闻  3：链接 4：相册 5：下载 6：其他</param>1
        /// <param name="mcontent">内容</param>1
        /// <param name="imageurl">栏目图标</param>1
        /// <param name="linkurl">外部链接地址</param>1
        /// <param name="menutitle">标题</param>1
        /// <param name="mkeywords">关键字</param>1
        /// <param name="mdescription">描述</param>1
        /// <param name="engname">英文名称</param>1
        /// <param name="mnanner">栏目banner</param>1
        /// <param name="menutemplate">栏目模板</param>1
        /// <param name="detailtemplate">详情页模板</param> 1
        /// <param name="isopen">是否开放栏目</param>1
        /// <param name="iscomment">是否允许评论</param>1
        /// <param name="iscommentaudit">评论是否需要审核</param>1
        /// <param name="isnavigation">是否显示在导航条上</param>1
        /// <param name="isaudit">发布内容是否需要审核</param>1
        /// <param name="publishroles">发布角色</param>
        /// <param name="prestr">预留字段</param>
        /// <param name="isdel">是否删除</param>
        public Web_MenuEntity(int mid, string mname, string pid, int morder, int mtype, string mcontent, string imageurl, string linkurl, string menutitle, string mkeywords, string mdescription, string engname, string mnanner, string menutemplate, string detailtemplate, int isopen, int iscomment, int iscommentaudit, int isnavigation, int isaudit, string publishroles, string prestr, int isdel)
        {
            this.MID = mid;
            this.MName = mname;
            this.PID = pid;
            this.MOrder = morder;
            this.MType = mtype;
            this.MContent = mcontent;
            this.ImageUrl = imageurl;
            this.LinkUrl = linkurl;
            this.MenuTitle = menutitle;
            this.MKeyWords = mkeywords;
            this.MDescription = mdescription;
            this.EngName = engname;
            this.MNanner = mnanner;
            this.MenuTemplate = menutemplate;
            this.DetailTemplate = detailtemplate;
            this.IsOpen = isopen;
            this.IsComment = iscomment;
            this.IsCommentAudit = iscommentaudit;
            this.IsNavigation = isnavigation;
            this.IsAudit = isaudit;
            this.PublishRoles = publishroles;
            this.PreStr = prestr;
            this.Isdel = isdel;
        }

        private int mid;//栏目ID
        private string mname;//栏目名称
        private string pid;//父级id
        private int morder;//排序
        private int mtype;//类别 1：单篇  2：新闻  3：链接 4：相册 5：下载 6：其他
        private string mcontent;//内容
        private string imageurl;//栏目图标
        private string linkurl;//外部链接地址
        private string menutitle;//标题
        private string mkeywords;//关键字
        private string mdescription;//描述
        private string engname;//英文名称
        private string mnanner;//栏目banner
        private string menutemplate;//栏目模板
        private string detailtemplate;//详情页模板
        private int isopen;//是否开放栏目
        private int iscomment;//是否允许评论
        private int iscommentaudit;//评论是否需要审核
        private int isnavigation;//是否显示在导航条上
        private int isaudit;//发布内容是否需要审核
        private string publishroles;//发布角色
        private string prestr;//预留字段
        private int isdel;//是否删除
        private string aduituser;//审核人

        /// <summary>
        /// 审核人
        /// </summary>
        public string AduitUser
        {
            get { return aduituser; }
            set { aduituser = value; }
        }


        ///<summary>
        ///栏目ID
        ///</summary>
        public int MID
        {
            get
            {
                return mid;
            }
            set
            {
                mid = value;
            }
        }

        ///<summary>
        ///栏目名称
        ///</summary>
        public string MName
        {
            get
            {
                return mname;
            }
            set
            {
                mname = value;
            }
        }

        ///<summary>
        ///父级id
        ///</summary>
        public string PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        ///<summary>
        ///排序
        ///</summary>
        public int MOrder
        {
            get
            {
                return morder;
            }
            set
            {
                morder = value;
            }
        }

        ///<summary>
        ///类别 1：单篇  2：新闻  3：链接 4：相册 5：下载 6：其他
        ///</summary>
        public int MType
        {
            get
            {
                return mtype;
            }
            set
            {
                mtype = value;
            }
        }

        ///<summary>
        ///内容
        ///</summary>
        public string MContent
        {
            get
            {
                return mcontent;
            }
            set
            {
                mcontent = value;
            }
        }

        ///<summary>
        ///栏目图标
        ///</summary>
        public string ImageUrl
        {
            get
            {
                return imageurl;
            }
            set
            {
                imageurl = value;
            }
        }

        ///<summary>
        ///外部链接地址
        ///</summary>
        public string LinkUrl
        {
            get
            {
                return linkurl;
            }
            set
            {
                linkurl = value;
            }
        }

        ///<summary>
        ///标题
        ///</summary>
        public string MenuTitle
        {
            get
            {
                return menutitle;
            }
            set
            {
                menutitle = value;
            }
        }

        ///<summary>
        ///关键字
        ///</summary>
        public string MKeyWords
        {
            get
            {
                return mkeywords;
            }
            set
            {
                mkeywords = value;
            }
        }

        ///<summary>
        ///描述
        ///</summary>
        public string MDescription
        {
            get
            {
                return mdescription;
            }
            set
            {
                mdescription = value;
            }
        }

        ///<summary>
        ///英文名称
        ///</summary>
        public string EngName
        {
            get
            {
                return engname;
            }
            set
            {
                engname = value;
            }
        }

        ///<summary>
        ///栏目banner
        ///</summary>
        public string MNanner
        {
            get
            {
                return mnanner;
            }
            set
            {
                mnanner = value;
            }
        }

        ///<summary>
        ///栏目模板
        ///</summary>
        public string MenuTemplate
        {
            get
            {
                return menutemplate;
            }
            set
            {
                menutemplate = value;
            }
        }

        ///<summary>
        ///详情页模板
        ///</summary>
        public string DetailTemplate
        {
            get
            {
                return detailtemplate;
            }
            set
            {
                detailtemplate = value;
            }
        }

        ///<summary>
        ///是否开放栏目
        ///</summary>
        public int IsOpen
        {
            get
            {
                return isopen;
            }
            set
            {
                isopen = value;
            }
        }

        ///<summary>
        ///是否允许评论
        ///</summary>
        public int IsComment
        {
            get
            {
                return iscomment;
            }
            set
            {
                iscomment = value;
            }
        }

        ///<summary>
        ///评论是否需要审核
        ///</summary>
        public int IsCommentAudit
        {
            get
            {
                return iscommentaudit;
            }
            set
            {
                iscommentaudit = value;
            }
        }

        ///<summary>
        ///是否显示在导航条上
        ///</summary>
        public int IsNavigation
        {
            get
            {
                return isnavigation;
            }
            set
            {
                isnavigation = value;
            }
        }

        ///<summary>
        ///发布内容是否需要审核
        ///</summary>
        public int IsAudit
        {
            get
            {
                return isaudit;
            }
            set
            {
                isaudit = value;
            }
        }

        ///<summary>
        ///发布角色
        ///</summary>
        public string PublishRoles
        {
            get
            {
                return publishroles;
            }
            set
            {
                publishroles = value;
            }
        }

        ///<summary>
        ///预留字段
        ///</summary>
        public string PreStr
        {
            get
            {
                return prestr;
            }
            set
            {
                prestr = value;
            }
        }

        ///<summary>
        ///是否删除
        ///</summary>
        public int Isdel
        {
            get
            {
                return isdel;
            }
            set
            {
                isdel = value;
            }
        }
    }
}

