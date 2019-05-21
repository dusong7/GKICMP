/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09点23分
** 描   述:       日志实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SysLogEntity
    {

        /// <summary>
        /// SysLog表实体
        ///</summary>
        public SysLogEntity()
        {
        }

        public SysLogEntity(string createuser, int logtype)
        {
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.LogType = logtype;
        }

        public SysLogEntity(int logtype, string logcontent, string createuser)
        {
            this.LogType = logtype;
            this.LogContent = logcontent;
            this.CreateUser = createuser;
            this.LogFlag = 1;
        }

        public SysLogEntity( string logcontent, string createuser)
        {
            this.LogType = 0;
            this.LogContent = logcontent;
            this.CreateUser = createuser;
            this.LogFlag = 2;
        }
       

        /// <summary>
        /// SysLog表实体
        /// </summary>
        /// <param name="logid">日志ID</param>
        /// <param name="logtype">日志类型</param>
        /// <param name="logcontent">日志内容</param>
        /// <param name="createuser">操作人</param>
        /// <param name="createdate">操作时间</param>
        public SysLogEntity(string logid, int logtype, string logcontent, string createuser, DateTime createdate)
        {
            this.LogID = logid;
            this.LogType = logtype;
            this.LogContent = logcontent;
            this.CreateUser = createuser;
            this.CreateDate = createdate;

        }


        private string logid;//日志ID
        private int logtype;//日志类型
        private string logcontent;//日志内容
        private string createuser;//操作人
        private DateTime createdate;//操作时间
        private string createusername;//操作人
        private int logflag;

        public int LogFlag
        {
            get { return logflag; }
            set { logflag = value; }
        }

        public string Createusername
        {
            get { return createusername; }
            set { createusername = value; }
        }
        private DateTime begin;//操作时间
        private DateTime end;

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
        ///日志ID
        ///</summary>
        public string LogID
        {
            get
            {
                return logid;
            }
            set
            {
                logid = value;
            }
        }

        ///<summary>
        ///日志类型
        ///</summary>
        public int LogType
        {
            get
            {
                return logtype;
            }
            set
            {
                logtype = value;
            }
        }

        ///<summary>
        ///日志内容
        ///</summary>
        public string LogContent
        {
            get
            {
                return logcontent;
            }
            set
            {
                logcontent = value;
            }
        }

        ///<summary>
        ///操作人
        ///</summary>
        public string CreateUser
        {
            get
            {
                return createuser;
            }
            set
            {
                createuser = value;
            }
        }

        ///<summary>
        ///操作时间
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
    }
}

