/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月09日 09点44分
** 描   述:      通知公告实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AfficheEntity
    {

        /// <summary>
        /// Affiche表实体
        ///</summary>
        public AfficheEntity()
        {
        }


        /// <summary>
        /// Affiche表实体
        /// </summary>
        /// <param name="aid">公告ID</param>
        /// <param name="affichetitle">公告标题</param>
        /// <param name="acontent">公告内容</param>
        /// <param name="senduser">发送人</param>
        /// <param name="senddate">发送日期</param>
        /// <param name="atype">类型</param>
        /// <param name="isdisplay">是否公示</param>
        /// <param name="aflag">2：班级公告  1：政务公告</param>
        /// <param name="claid">班级</param>
        public AfficheEntity(string aid, string affichetitle, string acontent, string senduser, DateTime senddate, int atype, int isdisplay, int aflag, int claid)
        {
            this.AID = aid;
            this.AfficheTitle = affichetitle;
            this.AContent = acontent;
            this.SendUser = senduser;
            this.SendDate = senddate;
            this.AType = atype;
            this.IsDisplay = isdisplay;
            this.AFlag = aflag;
            this.ClaID = claid;
        }

        private string aid;//公告ID
        private string affichetitle;//公告标题
        private string acontent;//公告内容
        private string senduser;//发送人
        private string sendUserName;//发送人      
        private DateTime senddate;//发送日期
        private int atype;//类型
        private int isdisplay;//是否公示
        private int aflag;//2：班级公告  1：政务公告
        private int claid;//班级
        private string acceptUser;//接收人
        private string acceptUserName;//接收人
        private int isRead;
        private string aTypeName;
        private string auditmark;

        public string AuditMark
        {
            get { return auditmark; }
            set { auditmark = value; }
        }

        /// <summary>
        /// 是否发送
        /// </summary>
        public int IsSend { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime AuditDate { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditUser { get; set; }
        public string ATypeName
        {
            get { return aTypeName; }
            set { aTypeName = value; }
        }

        public int IsRead
        {
            get { return isRead; }
            set { isRead = value; }
        }
        public string AcceptUserName
        {
            get { return acceptUserName; }
            set { acceptUserName = value; }
        }
        public string AcceptUser
        {
            get { return acceptUser; }
            set { acceptUser = value; }
        }


        public string SendUserName
        {
            get { return sendUserName; }
            set { sendUserName = value; }
        }

        ///<summary>
        ///公告ID
        ///</summary>
        public string AID
        {
            get
            {
                return aid;
            }
            set
            {
                aid = value;
            }
        }

        ///<summary>
        ///公告标题
        ///</summary>
        public string AfficheTitle
        {
            get
            {
                return affichetitle;
            }
            set
            {
                affichetitle = value;
            }
        }

        ///<summary>
        ///公告内容
        ///</summary>
        public string AContent
        {
            get
            {
                return acontent;
            }
            set
            {
                acontent = value;
            }
        }

        ///<summary>
        ///发送人
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
        ///发送日期
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
        ///类型
        ///</summary>
        public int AType
        {
            get
            {
                return atype;
            }
            set
            {
                atype = value;
            }
        }

        ///<summary>
        ///是否公示
        ///</summary>
        public int IsDisplay
        {
            get
            {
                return isdisplay;
            }
            set
            {
                isdisplay = value;
            }
        }

        ///<summary>
        ///3：年级公告，2：班级公告  1：政务公告，0：全体
        ///</summary>
        public int AFlag
        {
            get
            {
                return aflag;
            }
            set
            {
                aflag = value;
            }
        }

        ///<summary>
        ///班级
        ///</summary>
        public int ClaID
        {
            get
            {
                return claid;
            }
            set
            {
                claid = value;
            }
        }
    }
}

