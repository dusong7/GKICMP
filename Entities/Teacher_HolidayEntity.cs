/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月15日 10点01分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_HolidayEntity
    {

        /// <summary>
        /// Teacher_Holiday表实体
        ///</summary>
        public Teacher_HolidayEntity()
        {
        }


        /// <summary>
        /// Teacher_Holiday表实体
        /// </summary>
        /// <param name="thid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="htype">请假类型</param>
        /// <param name="depid">单位</param>
        /// <param name="hstartdate">开始日期</param>
        /// <param name="henddate">结束日期</param>
        /// <param name="holidaydesc">请假原因</param>
        /// <param name="createdate">创建日期</param>
        /// <param name="hfile">附件</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_HolidayEntity(string thid, string tid, int htype, int depid, DateTime hstartdate, DateTime henddate, string holidaydesc, DateTime createdate, string hfile, int isdel)
        {
            this.THID = thid;
            this.TID = tid;
            this.HType = htype;
            this.DepID = depid;
            this.HStartDate = hstartdate;
            this.HEndDate = henddate;
            this.HolidayDesc = holidaydesc;
            this.CreateDate = createdate;
            this.HFile = hfile;
            this.Isdel = isdel;
        }

        private string thid;//ID
        private string tid;//教师ID
        private int htype;//请假类型
        private int depid;//单位
        private DateTime hstartdate;//开始日期
        private DateTime henddate;//结束日期
        private string holidaydesc;//请假原因
        private DateTime createdate;//创建日期
        private string hfile;//附件
        private int isdel;//是否删除
        private string tname;//教师姓名
        private int isreport;//是否上报
        /// <summary>
        /// 请假天数
        /// </summary>
        public decimal HDays { get; set; }//请假天数
        public int IsReport
        {
            get
            {
                return isreport;
            }
            set
            {
                isreport = value;
            }
        }
        public string TName { get { return tname; } set { tname = value; } }

        ///<summary>
        ///ID
        ///</summary>
        public string THID
        {
            get
            {
                return thid;
            }
            set
            {
                thid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TID
        {
            get
            {
                return tid;
            }
            set
            {
                tid = value;
            }
        }

        ///<summary>
        ///请假类型
        ///</summary>
        public int HType
        {
            get
            {
                return htype;
            }
            set
            {
                htype = value;
            }
        }

        ///<summary>
        ///单位
        ///</summary>
        public int DepID
        {
            get
            {
                return depid;
            }
            set
            {
                depid = value;
            }
        }

        ///<summary>
        ///开始日期
        ///</summary>
        public DateTime HStartDate
        {
            get
            {
                return hstartdate;
            }
            set
            {
                hstartdate = value;
            }
        }

        ///<summary>
        ///结束日期
        ///</summary>
        public DateTime HEndDate
        {
            get
            {
                return henddate;
            }
            set
            {
                henddate = value;
            }
        }

        ///<summary>
        ///请假原因
        ///</summary>
        public string HolidayDesc
        {
            get
            {
                return holidaydesc;
            }
            set
            {
                holidaydesc = value;
            }
        }

        ///<summary>
        ///创建日期
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
        ///附件
        ///</summary>
        public string HFile
        {
            get
            {
                return hfile;
            }
            set
            {
                hfile = value;
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

