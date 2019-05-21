/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月01日 08点39分
** 描   述:      评论与留言实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Web_CommentEntity
    {

        /// <summary>
        /// Web_Comment表实体
        ///</summary>
        public Web_CommentEntity()
        {
        }

        public Web_CommentEntity(DateTime begindate, DateTime enddate, int isdel, int ispublish)
        {
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.Isdel = isdel;
            this.IsPublish = ispublish;
            //this.SID = sid;
        }

        /// <summary>
        /// Web_Comment表实体
        /// </summary>
        /// <param name="cid">评论ID</param>
        /// <param name="nid">新闻ID</param>
        /// <param name="comtitle">标题</param>
        /// <param name="comcontent">内容</param>
        /// <param name="linkuser">联系人</param>
        /// <param name="linktype">联系方式</param>
        /// <param name="constate">状态</param>
        /// <param name="ispublish">是否公开</param>
        /// <param name="replycontent">回复内容</param>
        /// <param name="replydate">回复时间</param>
        /// <param name="comdate">留言时间</param>
        /// <param name="audituser">审核人</param>
        /// <param name="prestr">预留字段</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="cflag">标识 1:留言 2：评论</param>
        public Web_CommentEntity(int cid, string nid, string comtitle, string comcontent, string linkuser, string linktype, int constate, int ispublish, string replycontent, DateTime replydate, DateTime comdate, string audituser, string prestr, int isdel, int cflag)
        {
            this.CID = cid;
            this.NID = nid;
            this.ComTitle = comtitle;
            this.ComContent = comcontent;
            this.LinkUser = linkuser;
            this.LinkType = linktype;
            this.ConState = constate;
            this.IsPublish = ispublish;
            this.ReplyContent = replycontent;
            this.ReplyDate = replydate;
            this.ComDate = comdate;
            this.AuditUser = audituser;
            this.PreStr = prestr;
            this.Isdel = isdel;
            this.CFlag = cflag;
        }

        private int cid;//评论ID
        private string nid;//新闻ID
        private string comtitle;//标题
        private string comcontent;//内容
        private string linkuser;//联系人
        private string linktype;//联系方式
        private int constate;//状态
        private int ispublish;//是否公开
        private string replycontent;//回复内容
        private DateTime replydate;//回复时间
        private DateTime comdate;//留言时间
        private string audituser;//审核人
        private string prestr;//预留字段
        private int isdel;//是否删除
        private int cflag;//标识 1:留言 2：评论

        private DateTime begindate;
        private DateTime enddate;
        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        public DateTime BeginDate
        {
            get { return begindate; }
            set { begindate = value; }
        }

        ///<summary>
        ///评论ID
        ///</summary>
        public int CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
            }
        }

        ///<summary>
        ///新闻ID
        ///</summary>
        public string NID
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
        public string ComTitle
        {
            get
            {
                return comtitle;
            }
            set
            {
                comtitle = value;
            }
        }

        ///<summary>
        ///内容
        ///</summary>
        public string ComContent
        {
            get
            {
                return comcontent;
            }
            set
            {
                comcontent = value;
            }
        }

        ///<summary>
        ///联系人
        ///</summary>
        public string LinkUser
        {
            get
            {
                return linkuser;
            }
            set
            {
                linkuser = value;
            }
        }

        ///<summary>
        ///联系方式
        ///</summary>
        public string LinkType
        {
            get
            {
                return linktype;
            }
            set
            {
                linktype = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int ConState
        {
            get
            {
                return constate;
            }
            set
            {
                constate = value;
            }
        }

        ///<summary>
        ///是否公开
        ///</summary>
        public int IsPublish
        {
            get
            {
                return ispublish;
            }
            set
            {
                ispublish = value;
            }
        }

        ///<summary>
        ///回复内容
        ///</summary>
        public string ReplyContent
        {
            get
            {
                return replycontent;
            }
            set
            {
                replycontent = value;
            }
        }

        ///<summary>
        ///回复时间
        ///</summary>
        public DateTime ReplyDate
        {
            get
            {
                return replydate;
            }
            set
            {
                replydate = value;
            }
        }

        ///<summary>
        ///留言时间
        ///</summary>
        public DateTime ComDate
        {
            get
            {
                return comdate;
            }
            set
            {
                comdate = value;
            }
        }

        ///<summary>
        ///审核人
        ///</summary>
        public string AuditUser
        {
            get
            {
                return audituser;
            }
            set
            {
                audituser = value;
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

        ///<summary>
        ///标识 1:留言 2：评论
        ///</summary>
        public int CFlag
        {
            get
            {
                return cflag;
            }
            set
            {
                cflag = value;
            }
        }
    }
}

