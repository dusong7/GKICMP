/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年11月15日 09点14分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class NetworkTeach_LoginEntity
    {

        /// <summary>
        /// NetworkTeach_Login表实体
        ///</summary>
        public NetworkTeach_LoginEntity()
        {
        }


        /// <summary>
        /// NetworkTeach_Login表实体
        /// </summary>
        /// <param name="ntlid">ID</param>
        /// <param name="ntid">课程ID</param>
        /// <param name="sysid">用户</param>
        /// <param name="loginbegin">登录开始时间</param>
        /// <param name="loginend">登录结束日期</param>
        public NetworkTeach_LoginEntity(string ntlid, string ntid, string sysid, DateTime loginbegin, DateTime loginend)
        {
            this.NTLID = ntlid;
            this.NTID = ntid;
            this.SysID = sysid;
            this.LoginBegin = loginbegin;
            this.LoginEnd = loginend;
        }

        private string ntlid;//ID
        private string ntid;//课程ID
        private string sysid;//用户
        private DateTime loginbegin;//登录开始时间
        private DateTime loginend;//登录结束日期


        ///<summary>
        ///ID
        ///</summary>
        public string NTLID
        {
            get
            {
                return ntlid;
            }
            set
            {
                ntlid = value;
            }
        }

        ///<summary>
        ///课程ID
        ///</summary>
        public string NTID
        {
            get
            {
                return ntid;
            }
            set
            {
                ntid = value;
            }
        }

        ///<summary>
        ///用户
        ///</summary>
        public string SysID
        {
            get
            {
                return sysid;
            }
            set
            {
                sysid = value;
            }
        }

        ///<summary>
        ///登录开始时间
        ///</summary>
        public DateTime LoginBegin
        {
            get
            {
                return loginbegin;
            }
            set
            {
                loginbegin = value;
            }
        }

        ///<summary>
        ///登录结束日期
        ///</summary>
        public DateTime LoginEnd
        {
            get
            {
                return loginend;
            }
            set
            {
                loginend = value;
            }
        }
    }
}

