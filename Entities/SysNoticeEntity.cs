/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月04日 03点43分
** 描   述:      系统通知实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SysNoticeEntity
    {

        /// <summary>
        /// SysNotice表实体
        ///</summary>
        public SysNoticeEntity()
        {
        }

        public SysNoticeEntity(string senduser, string ncontent)
        {
            this.SendUser = senduser;
            this.NContent = ncontent;
           
        }

        /// <summary>
        /// SysNotice表实体
        /// </summary>
        /// <param name="snid">ID</param>
        /// <param name="ncontent">通知内容</param>
        /// <param name="senduser">通知人</param>
        /// <param name="senddate">通知日期</param>
        /// <param name="ntype">通知类型1：请假，2：，3：报修（需要时往后加）</param>
        /// <param name="objid">关联ID</param>
        /// <param name="isread">是否已读</param>
        /// <param name="issendmess">是否发送短信</param>
        /// <param name="issendmail">是否发送邮件</param>
        /// <param name="acceptuser">接收人</param>
        /// <param name="readdate">读取时间</param>
        /// <param name="issendwx">是否发送微信</param>
        /// <param name="stype">发送方式1：微信，2：短信</param>
        public SysNoticeEntity(string snid, string ncontent, string senduser, DateTime senddate, int ntype, string objid, int isread, int issendmess, int issendmail, string acceptuser, DateTime readdate, int issendwx, int stype)
        {
            this.SNID = snid;
            this.NContent = ncontent;
            this.SendUser = senduser;
            this.SendDate = senddate;
            this.NType = ntype;
            this.ObjID = objid;
            this.IsRead = isread;
            this.IsSendMess = issendmess;
            this.IsSendMail = issendmail;
            this.AcceptUser = acceptuser;
            this.ReadDate = readdate;
            this.IsSendWX = issendwx;
            this.SType = stype;
        }

        private string snid;//ID
        private string ncontent;//通知内容
        private string senduser;//通知人
        private DateTime senddate;//通知日期
        private int ntype;//通知类型1：请假，2：，3：报修（需要时往后加）
        private string objid;//关联ID
        private int isread;//是否已读
        private int issendmess;//是否发送短信
        private int issendmail;//是否发送邮件
        private string acceptuser;//接收人
        private DateTime readdate;//读取时间
        private int issendwx;//是否发送微信
        private int stype;//发送方式1：微信，2：短信
        private string sendusername;

        private DateTime begin;
        private DateTime end;

        public DateTime Begin
        {
            get
            {
                return begin;
            }
            set
            {
                begin = value;
            }
        }

        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }


        public string SendUserName
        {
            get { return sendusername; }
            set { sendusername = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string SNID
        {
            get
            {
                return snid;
            }
            set
            {
                snid = value;
            }
        }

        ///<summary>
        ///通知内容
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
        ///通知人
        ///</summary>
        public string SendUser
        {
            get
            {
                return senduser;
            }
            set
            {
                senduser = value;
            }
        }

        ///<summary>
        ///通知日期
        ///</summary>
        public DateTime SendDate
        {
            get
            {
                return senddate;
            }
            set
            {
                senddate = value;
            }
        }

        ///<summary>
        ///通知类型1：请假，2：，3：报修（需要时往后加）
        ///</summary>
        public int NType
        {
            get
            {
                return ntype;
            }
            set
            {
                ntype = value;
            }
        }

        ///<summary>
        ///关联ID
        ///</summary>
        public string ObjID
        {
            get
            {
                return objid;
            }
            set
            {
                objid = value;
            }
        }

        ///<summary>
        ///是否已读
        ///</summary>
        public int IsRead
        {
            get
            {
                return isread;
            }
            set
            {
                isread = value;
            }
        }

        ///<summary>
        ///是否发送短信
        ///</summary>
        public int IsSendMess
        {
            get
            {
                return issendmess;
            }
            set
            {
                issendmess = value;
            }
        }

        ///<summary>
        ///是否发送邮件
        ///</summary>
        public int IsSendMail
        {
            get
            {
                return issendmail;
            }
            set
            {
                issendmail = value;
            }
        }

        ///<summary>
        ///接收人
        ///</summary>
        public string AcceptUser
        {
            get
            {
                return acceptuser;
            }
            set
            {
                acceptuser = value;
            }
        }

        ///<summary>
        ///读取时间
        ///</summary>
        public DateTime ReadDate
        {
            get
            {
                return readdate;
            }
            set
            {
                readdate = value;
            }
        }

        ///<summary>
        ///是否发送微信
        ///</summary>
        public int IsSendWX
        {
            get
            {
                return issendwx;
            }
            set
            {
                issendwx = value;
            }
        }

        ///<summary>
        ///发送方式1：微信，2：短信
        ///</summary>
        public int SType
        {
            get
            {
                return stype;
            }
            set
            {
                stype = value;
            }
        }
    }
}

