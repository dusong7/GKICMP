/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月18日 04点52分
** 描   述:      邮箱用户实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class Email_UserEntity
    {

        /// <summary>
        /// Email_User表实体
        ///</summary>
        public Email_UserEntity()
        {
        }


        /// <summary>
        /// Email_User表实体
        /// </summary>
        /// <param name="euid">EUID</param>
        /// <param name="eid">邮件ID</param>
        /// <param name="acceptuser">接收人</param>
        /// <param name="acceptdate">接收时间</param>
        /// <param name="isread">是否已读</param>
        /// <param name="issubmit"></param>
        /// <param name="isdel">是否删除</param>
        public Email_UserEntity(string euid, string eid, string acceptuser, DateTime acceptdate, int isread, int issubmit, int isdel)
        {
            this.EUID = euid;
            this.EID = eid;
            this.AcceptUser = acceptuser;
            this.AcceptDate = acceptdate;
            this.IsRead = isread;
            this.IsSubmit = issubmit;
            this.Isdel = isdel;
        }

        private string euid;//EUID
        private string eid;//邮件ID
        private string acceptuser;//接收人
        private DateTime acceptdate;//接收时间
        private int isread;//是否已读
        private int issubmit;//
        private int isdel;//是否删除


        ///<summary>
        ///EUID
        ///</summary>
        public string EUID
        {
            get
            {
                return euid;
            }
            set
            {
                euid = value;
            }
        }

        ///<summary>
        ///邮件ID
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
        ///
        ///</summary>
        public int IsSubmit
        {
            get
            {
                return issubmit;
            }
            set
            {
                issubmit = value;
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