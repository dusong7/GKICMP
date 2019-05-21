/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2016年11月21日 03点43分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Egovernment_FlowEntity
    {

        /// <summary>
        /// Egovernment_Flow表实体
        ///</summary>
        public Egovernment_FlowEntity()
        {
        }


        /// <summary>
        /// Egovernment_Flow表实体
        /// </summary>
        /// <param name="fid">ID</param>
        /// <param name="eid">政务ID</param>
        /// <param name="comment">批注</param>
        /// <param name="senduser">发送人</param>
        /// <param name="acceptuser">接收人</param>
        /// <param name="fopinion">处理意见</param>
        /// <param name="senddate">发送时间</param>
        /// <param name="acceptdate">接收时间</param>
        /// <param name="state">状态</param>
        /// <param name="isread">是否读阅</param>
        /// <param name="issendmess">是否发短信</param>
        public Egovernment_FlowEntity(string fid, string eid, string comment, string senduser, string acceptuser, string fopinion, DateTime senddate, DateTime acceptdate, int state, int isread, int issendmess)
        {
            this.FID = fid;
            this.EID = eid;
            this.Comment = comment;
            this.SendUser = senduser;
            this.AcceptUser = acceptuser;
            this.FOpinion = fopinion;
            this.SendDate = senddate;
            this.AcceptDate = acceptdate;
            this.State = state;
            this.IsRead = isread;
            this.IsSendMess = issendmess;
        }

        private string fid;//ID
        private string eid;//政务ID
        private string etitle;//政务标题
        private DateTime begin;//开始时间
        private DateTime end;//结束时间
        private string comment;//批注
        private string senduser;//发送人
        private string acceptuser;//接收人
        private string fopinion;//处理意见
        private DateTime senddate;//发送时间
        private DateTime acceptdate;//接收时间
        private int state;//状态
        private int isread;//是否读阅
        private int issendmess;//是否发短信
        public string ETitle
        {
            get { return etitle; }
            set { etitle = value; }
        }
        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        ///<summary>
        ///ID
        ///</summary>
        public string FID
        {
            get
            {
                return fid;
            }
            set
            {
                fid = value;
            }
        }

        ///<summary>
        ///政务ID
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
        ///批注
        ///</summary>
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
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
        ///处理意见
        ///</summary>
        public string FOpinion
        {
            get
            {
                return fopinion;
            }
            set
            {
                fopinion = value;
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
        ///接收时间
        ///</summary>
        public DateTime AcceptDate
        {
            get
            {
                return acceptdate;
            }
            set
            {
                acceptdate = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        ///<summary>
        ///是否读阅
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
        ///是否发短信
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
    }
}
