/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 11点14分
** 描   述:      值班日志实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SchoolLogEntity
    {

        /// <summary>
        /// SchoolLog表实体
        ///</summary>
        public SchoolLogEntity()
        {
        }


        /// <summary>
        /// SchoolLog表实体
        /// </summary>
        /// <param name="logid">日志ID</param>
        /// <param name="logcontent">日志内容</param>
        /// <param name="dutyuser">值班人员</param>
        /// <param name="weather">天气</param>
        /// <param name="syear">学年度</param>
        /// <param name="sterm">学期</param>
        /// <param name="createuser">操作人</param>
        /// <param name="createdate">操作时间</param>
        public SchoolLogEntity(int logid, string logcontent, string dutyuser, string weather, string syear, int sterm, string createuser, DateTime createdate)
        {
            this.LogID = logid;
            this.LogContent = logcontent;
            this.DutyUser = dutyuser;
            this.Weather = weather;
            this.SYear = syear;
            this.STerm = sterm;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private int logid;//日志ID
        private string logcontent;//日志内容
        private string dutyuser;//值班人员
        private string dutyuserName;
        private string weather;//天气
        private string syear;//学年度
        private int sterm;//学期
        private string createuser;//操作人
        private string createuserName;
        private DateTime createdate;//操作时间
        public string CreateuserName
        {
            get { return createuserName; }
            set { createuserName = value; }
        }
        public string DutyuserName
        {
            get { return dutyuserName; }
            set { dutyuserName = value; }
        }
        ///<summary>
        ///日志ID
        ///</summary>
        public int LogID
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
        ///值班人员
        ///</summary>
        public string DutyUser
        {
            get
            {
                return dutyuser;
            }
            set
            {
                dutyuser = value;
            }
        }

        ///<summary>
        ///天气
        ///</summary>
        public string Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value;
            }
        }

        ///<summary>
        ///学年度
        ///</summary>
        public string SYear
        {
            get
            {
                return syear;
            }
            set
            {
                syear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int STerm
        {
            get
            {
                return sterm;
            }
            set
            {
                sterm = value;
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

