/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年08月17日 04点18分
** 描   述:      室场预约实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AppointmentEntity
    {

        /// <summary>
        /// Appointment表实体
        ///</summary>
        public AppointmentEntity()
        {
        }

        /// <summary>
        /// Appointment表实体
        /// </summary>
        /// <param name="abflag">标示</param>
        /// <param name="isdel">是否删除</param>
        public AppointmentEntity(DateTime begin, DateTime end)
        {
            this.Begin = begin;
            this.End = end;
           
        }



        /// <summary>
        /// Appointment表实体
        /// </summary>
        /// <param name="aid">预约ID</param>
        /// <param name="mrid">场地ID</param>
        /// <param name="appuser">预约人</param>
        /// <param name="createdate">预约时间</param>
        /// <param name="appointmentdesc">预约说明</param>
        /// <param name="begindate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="isuse">是否使用</param>
        public AppointmentEntity(int aid, int mrid, string appuser, DateTime createdate, string appointmentdesc, DateTime begindate, DateTime enddate, int isuse)
        {
            this.AID = aid;
            this.MRID = mrid;
            this.AppUser = appuser;
            this.CreateDate = createdate;
            this.AppointmentDesc = appointmentdesc;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.IsUse = isuse;
        }

        private int aid;//预约ID
        private int mrid;//场地ID
        private string appuser;//预约人
        private DateTime createdate;//预约时间
        private string appointmentdesc;//预约说明
        private DateTime begindate;//开始时间
        private DateTime enddate;//结束时间
        private int isuse;//是否使用
        private string appusername;//预约人
        public string AppUserName
        {
            get
            {
                return appusername;
            }
            set
            {
                appusername = value;
            }
        }

        private string mrname;//场地名称
        public string MRName
        {
            get
            {
                return mrname;
            }
            set
            {
                mrname = value;
            }
        }

        private DateTime begin;
        private DateTime end;
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        ///<summary>
        ///预约ID
        ///</summary>
        public int AID
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
        ///场地ID
        ///</summary>
        public int MRID
        {
            get
            {
                return mrid;
            }
            set
            {
                mrid = value;
            }
        }

        ///<summary>
        ///预约人
        ///</summary>
        public string AppUser
        {
            get
            {
                return appuser;
            }
            set
            {
                appuser = value;
            }
        }

        ///<summary>
        ///预约时间
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
        ///预约说明
        ///</summary>
        public string AppointmentDesc
        {
            get
            {
                return appointmentdesc;
            }
            set
            {
                appointmentdesc = value;
            }
        }

        ///<summary>
        ///开始时间
        ///</summary>
        public DateTime BeginDate
        {
            get
            {
                return begindate;
            }
            set
            {
                begindate = value;
            }
        }

        ///<summary>
        ///结束时间
        ///</summary>
        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
            }
        }

        ///<summary>
        ///是否使用
        ///</summary>
        public int IsUse
        {
            get
            {
                return isuse;
            }
            set
            {
                isuse = value;
            }
        }
    }
}

