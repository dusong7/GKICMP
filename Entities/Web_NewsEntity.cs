/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月26日 09点54分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Web_NewsEntity
    {

        /// <summary>
        /// Web_News表实体
        ///</summary>
        public Web_NewsEntity()
        {
        }

        public Web_NewsEntity(string newstitle, string mid, int isdel)
        {
            this.NewsTitle = newstitle;
            this.MID = mid;
            this.Isdel = isdel;
        }
        /// <summary>
        /// Web_News表实体
        /// </summary>
        /// <param name="nid">新闻ID</param>
        /// <param name="newstitle">标题</param>
        /// <param name="imageurl">缩略图</param>
        /// <param name="ncontent">内容</param>
        /// <param name="linkurl">链接</param>
        /// <param name="norder">排序</param>
        /// <param name="mid">栏目编号</param>
        /// <param name="readcount">浏览次数</param>
        /// <param name="msourse">来源</param>
        /// <param name="ncolor">标题颜色</param>
        /// <param name="istop">是否置顶</param>
        /// <param name="mdescription">是否推荐</param>
        /// <param name="isrecommend">是否头条</param>
        /// <param name="isimgnews">图片新闻</param>
        /// <param name="iscomment">禁止发表评论</param>
        /// <param name="nstate">状态</param>
        /// <param name="nttitle">主题</param>
        /// <param name="nkeywords">关键字</param>
        /// <param name="ndep">内容所属部门</param>
        /// <param name="ndescription">描述</param>
        /// <param name="prestr">预留字段</param>
        /// <param name="commentnumber">评论次数</param>
        /// <param name="updateuser">修改人</param>
        /// <param name="updatedate">修改时间</param>
        /// <param name="createdate">发布时间</param>
        /// <param name="nauthor">作者</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="isaudit">是否审核</param>
        /// <param name="aduituser">审核人</param>
        /// <param name="aduitdate">审核时间</param>
        public Web_NewsEntity(int nid, string newstitle, string imageurl, string ncontent, string linkurl, int norder, string mid, int readcount, string msourse, string ncolor, int istop, int mdescription, int isrecommend, int isimgnews, int iscomment, int nstate, string nttitle, string nkeywords, int ndep, string ndescription, string prestr, int commentnumber, string updateuser, DateTime updatedate, DateTime createdate, string nauthor, int isdel, int isaudit, string aduituser, DateTime aduitdate)
        {
            this.NID = nid;
            this.NewsTitle = newstitle;
            this.ImageUrl = imageurl;
            this.NContent = ncontent;
            this.LinkUrl = linkurl;
            this.NOrder = norder;
            this.MID = mid;
            this.ReadCount = readcount;
            this.MSourse = msourse;
            this.NColor = ncolor;
            this.IsTop = istop;
            this.MDescription = mdescription;
            this.IsRecommend = isrecommend;
            this.IsImgNews = isimgnews;
            this.IsComment = iscomment;
            this.Nstate = nstate;
            this.NTtitle = nttitle;
            this.NKeyWords = nkeywords;
            this.NDep = ndep;
            this.NDescription = ndescription;
            this.PreStr = prestr;
            this.CommentNumber = commentnumber;
            this.UpdateUser = updateuser;
            this.UpdateDate = updatedate;
            this.CreateDate = createdate;
            this.NAuthor = nauthor;
            this.Isdel = isdel;
            this.IsAudit = isaudit;
            this.AduitUser = aduituser;
            this.AduitDate = aduitdate;
        }

        private int nid;//新闻ID
        private string newstitle;//标题
        private string imageurl;//缩略图
        private string ncontent;//内容
        private string linkurl;//链接
        private int norder;//排序
        private string mid;//栏目编号
        private int readcount;//浏览次数
        private string msourse;//来源
        private string ncolor;//标题颜色
        private int istop;//是否置顶
        private int mdescription;//是否推荐
        private int isrecommend;//是否头条
        private int isimgnews;//图片新闻
        private int iscomment;//禁止发表评论
        private int nstate;//状态
        private string nttitle;//主题
        private string nkeywords;//关键字
        private int ndep;//内容所属部门
        private string ndescription;//描述
        private string prestr;//预留字段
        private int commentnumber;//评论次数
        private string updateuser;//修改人
        private DateTime updatedate;//修改时间
        private DateTime createdate;//发布时间
        private string nauthor;//作者
        private int isdel;//是否删除
        private int isaudit;//是否审核
        private string aduituser;//审核人
        private DateTime aduitdate;//审核时间
        public string NAuthorName { get; set; }
        public string MName { get; set; }
        public string AduitUserName { get; set; }
        public int auditstate { get; set; }
        public int AuditState
        {
            get
            {
                return auditstate;
            }
            set
            {
                auditstate = value;
            }
        }
        ///<summary>
        ///新闻ID
        ///</summary>
        public int NID
        {
            get
            {
                return nid;
            }
            set
            {
                nid = value;
            }
        }

        ///<summary>
        ///标题
        ///</summary>
        public string NewsTitle
        {
            get
            {
                return newstitle;
            }
            set
            {
                newstitle = value;
            }
        }

        ///<summary>
        ///缩略图
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
        ///内容
        ///</summary>
        public string NContent
        {
            get
            {
                return ncontent;
            }
            set
            {
                ncontent = value;
            }
        }

        ///<summary>
        ///链接
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
        ///排序
        ///</summary>
        public int NOrder
        {
            get
            {
                return norder;
            }
            set
            {
                norder = value;
            }
        }

        ///<summary>
        ///栏目编号
        ///</summary>
        public string MID
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
        ///浏览次数
        ///</summary>
        public int ReadCount
        {
            get
            {
                return readcount;
            }
            set
            {
                readcount = value;
            }
        }

        ///<summary>
        ///来源
        ///</summary>
        public string MSourse
        {
            get
            {
                return msourse;
            }
            set
            {
                msourse = value;
            }
        }

        ///<summary>
        ///标题颜色
        ///</summary>
        public string NColor
        {
            get
            {
                return ncolor;
            }
            set
            {
                ncolor = value;
            }
        }

        ///<summary>
        ///是否置顶
        ///</summary>
        public int IsTop
        {
            get
            {
                return istop;
            }
            set
            {
                istop = value;
            }
        }

        ///<summary>
        ///是否推荐
        ///</summary>
        public int MDescription
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
        ///是否头条
        ///</summary>
        public int IsRecommend
        {
            get
            {
                return isrecommend;
            }
            set
            {
                isrecommend = value;
            }
        }

        ///<summary>
        ///图片新闻
        ///</summary>
        public int IsImgNews
        {
            get
            {
                return isimgnews;
            }
            set
            {
                isimgnews = value;
            }
        }

        ///<summary>
        ///禁止发表评论
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
        ///状态
        ///</summary>
        public int Nstate
        {
            get
            {
                return nstate;
            }
            set
            {
                nstate = value;
            }
        }

        ///<summary>
        ///主题
        ///</summary>
        public string NTtitle
        {
            get
            {
                return nttitle;
            }
            set
            {
                nttitle = value;
            }
        }

        ///<summary>
        ///关键字
        ///</summary>
        public string NKeyWords
        {
            get
            {
                return nkeywords;
            }
            set
            {
                nkeywords = value;
            }
        }

        ///<summary>
        ///内容所属部门
        ///</summary>
        public int NDep
        {
            get
            {
                return ndep;
            }
            set
            {
                ndep = value;
            }
        }

        ///<summary>
        ///描述
        ///</summary>
        public string NDescription
        {
            get
            {
                return ndescription;
            }
            set
            {
                ndescription = value;
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
        ///评论次数
        ///</summary>
        public int CommentNumber
        {
            get
            {
                return commentnumber;
            }
            set
            {
                commentnumber = value;
            }
        }

        ///<summary>
        ///修改人
        ///</summary>
        public string UpdateUser
        {
            get
            {
                return updateuser;
            }
            set
            {
                updateuser = value;
            }
        }

        ///<summary>
        ///修改时间
        ///</summary>
        public DateTime UpdateDate
        {
            get
            {
                return updatedate;
            }
            set
            {
                updatedate = value;
            }
        }

        ///<summary>
        ///发布时间
        ///</summary>
        public DateTime CreateDate
        {
            get
            {
                return createdate;
            }
            set
            {
                createdate = value;
            }
        }

        ///<summary>
        ///作者
        ///</summary>
        public string NAuthor
        {
            get
            {
                return nauthor;
            }
            set
            {
                nauthor = value;
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

        ///<summary>
        ///是否审核
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
        ///审核人
        ///</summary>
        public string AduitUser
        {
            get
            {
                return aduituser;
            }
            set
            {
                aduituser = value;
            }
        }

        ///<summary>
        ///审核时间
        ///</summary>
        public DateTime AduitDate
        {
            get
            {
                return aduitdate;
            }
            set
            {
                aduitdate = value;
            }
        }
    }
}

