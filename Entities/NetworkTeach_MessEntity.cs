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

    public class NetworkTeach_MessEntity
    {

        /// <summary>
        /// NetworkTeach_Mess表实体
        ///</summary>
        public NetworkTeach_MessEntity()
        {
        }


        /// <summary>
        /// NetworkTeach_Mess表实体
        /// </summary>
        /// <param name="ntmid">ID</param>
        /// <param name="ntid">课程ID</param>
        /// <param name="sysid">留言人</param>
        /// <param name="createdate">留言时间</param>
        /// <param name="messcontent">留言内容</param>
        /// <param name="pid">父ID</param>
        public NetworkTeach_MessEntity(int ntmid, string ntid, string sysid, DateTime createdate, string messcontent, int pid)
        {
            this.NTMID = ntmid;
            this.NTID = ntid;
            this.SysID = sysid;
            this.CreateDate = createdate;
            this.MessContent = messcontent;
            this.PID = pid;
        }

        private int ntmid;//ID
        private string ntid;//课程ID
        private string sysid;//留言人
        private DateTime createdate;//留言时间
        private string messcontent;//留言内容
        private int pid;//父ID


        ///<summary>
        ///ID
        ///</summary>
        public int NTMID
        {
            get
            {
                return ntmid;
            }
            set
            {
                ntmid = value;
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
        ///留言人
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
        ///留言时间
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
        ///留言内容
        ///</summary>
        public string MessContent
        {
            get
            {
                return messcontent;
            }
            set
            {
                messcontent = value;
            }
        }

        ///<summary>
        ///父ID
        ///</summary>
        public int PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }
    }
}

