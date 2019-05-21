/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月18日 04点47分
** 描   述:      邮箱实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class EmailEntity
    {

        /// <summary>
        /// Email表实体
        ///</summary>
        public EmailEntity()
        {
        }


        /// <summary>
        /// Email表实体
        /// </summary>
        /// <param name="eid">EID</param>
        /// <param name="emailcontent">消息内容</param>
        /// <param name="emailtitle">消息标题</param>
        /// <param name="senduser">发送人</param>
        /// <param name="senddate">发送时间</param>
        /// <param name="etype">类型</param>
        public EmailEntity(string eid, string emailcontent, string emailtitle, string senduser, DateTime senddate, int etype)
        {
            this.EID = eid;
            this.EmailContent = emailcontent;
            this.EmailTitle = emailtitle;
            this.SendUser = senduser;
            this.SendDate = senddate;
            this.EType = etype;
        }

        private string eid;//EID
        private string emailcontent;//消息内容
        private string emailtitle;//消息标题
        private string senduser;//发送人
        private DateTime senddate;//发送时间
        private int etype;//类型
        private int isdel;//是否删除
        private string acceptuser;//接收人
        private int issubmit;//是否提交
        private string acceptname;
        private string sendusername;

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string SendUserName
        {
            get { return sendusername; }
            set { sendusername = value; }
        }

        /// <summary>
        /// 接收人名称
        /// </summary>
        public string AcceptName
        {
            get { return acceptname; }
            set { acceptname = value; }
        }

        /// <summary>
        /// 接收人
        /// </summary>
        public string AcceptUser
        {
            get { return acceptuser; }
            set { acceptuser = value; }
        }

        /// <summary>
        /// 是否提交
        /// </summary>
        public int IsSubmit
        {
            get { return issubmit; }
            set { issubmit = value; }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        ///<summary>
        ///EID
        ///</summary>
        public string EID
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
        }

        ///<summary>
        ///消息内容
        ///</summary>
        public string EmailContent
        {
            get
            {
                return emailcontent;
            }
            set
            {
                emailcontent = value;
            }
        }

        ///<summary>
        ///消息标题
        ///</summary>
        public string EmailTitle
        {
            get
            {
                return emailtitle;
            }
            set
            {
                emailtitle = value;
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
        ///发送时间
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
        public int EType
        {
            get
            {
                return etype;
            }
            set
            {
                etype = value;
            }
        }
    }
}