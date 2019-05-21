/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月06日 04点47分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ComputersEntity
    {

        /// <summary>
        /// Computers表实体
        ///</summary>
        public ComputersEntity()
        {
        }


        /// <summary>
        /// Computers表实体
        /// </summary>
        /// <param name="guid">ID</param>
        /// <param name="computername">设备名称</param>
        /// <param name="lanip">IP</param>
        /// <param name="mac">Mac地址</param>
        /// <param name="lastactivetime">最后活动时间</param>
        /// <param name="onlineminutes">在线时常</param>
        /// <param name="crid">教室ID</param>
        /// <param name="softversion">软件版本号</param>
        /// <param name="createdate">登记时间</param>
        /// <param name="cflag">标识  1:班班通    2：多媒体教室</param>
        public ComputersEntity(string guid, string computername, string lanip, string mac, DateTime lastactivetime, int onlineminutes, string crid, string softversion, DateTime createdate, int cflag)
        {
            this.Guid = guid;
            this.ComputerName = computername;
            this.LanIP = lanip;
            this.Mac = mac;
            this.LastActiveTime = lastactivetime;
            this.OnlineMinutes = onlineminutes;
            this.CRID = crid;
            this.SoftVersion = softversion;
            this.CreateDate = createdate;
            this.CFlag = cflag;
        }

        private string guid;//ID
        private string computername;//设备名称
        private string lanip;//IP
        private string mac;//Mac地址
        private DateTime lastactivetime;//最后活动时间
        private int onlineminutes;//在线时常
        private string crid;//教室ID
        private string softversion;//软件版本号
        private DateTime createdate;//登记时间
        private int cflag;//标识  1:班班通    2：多媒体教室


        ///<summary>
        ///ID
        ///</summary>
        public string Guid
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }

        ///<summary>
        ///设备名称
        ///</summary>
        public string ComputerName
        {
            get
            {
                return computername;
            }
            set
            {
                computername = value;
            }
        }

        ///<summary>
        ///IP
        ///</summary>
        public string LanIP
        {
            get
            {
                return lanip;
            }
            set
            {
                lanip = value;
            }
        }

        ///<summary>
        ///Mac地址
        ///</summary>
        public string Mac
        {
            get
            {
                return mac;
            }
            set
            {
                mac = value;
            }
        }

        ///<summary>
        ///最后活动时间
        ///</summary>
        public DateTime LastActiveTime
        {
            get
            {
                return lastactivetime;
            }
            set
            {
                lastactivetime = value;
            }
        }

        ///<summary>
        ///在线时常
        ///</summary>
        public int OnlineMinutes
        {
            get
            {
                return onlineminutes;
            }
            set
            {
                onlineminutes = value;
            }
        }

        ///<summary>
        ///教室ID
        ///</summary>
        public string CRID
        {
            get
            {
                return crid;
            }
            set
            {
                crid = value;
            }
        }

        ///<summary>
        ///软件版本号
        ///</summary>
        public string SoftVersion
        {
            get
            {
                return softversion;
            }
            set
            {
                softversion = value;
            }
        }

        ///<summary>
        ///登记时间
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
        ///标识  1:班班通    2：多媒体教室
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


