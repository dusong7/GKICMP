/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月12日 10点49分
** 描   述:      打卡实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AttendRecordEntity
    {

        /// <summary>
        ///  AttendRecord表实体
        ///</summary>
        public AttendRecordEntity()
        {
            	
        }


        /// <summary>
        ///  AttendRecord表实体
        /// </summary>
        /// <param name="arid">ID</param>
        /// <param name="usernum">工号</param>
        /// <param name="machinecode">打卡机号码</param>
        /// <param name="recorddate">打卡时间</param>
        /// <param name="attendtype">考勤方式</param>
        /// <param name="isanalysis">是否分析</param>
        /// <param name="attenddesc">备注</param>
        public AttendRecordEntity(string arid, string usernum, string machinecode, DateTime recorddate, int attendtype, int isanalysis, string attenddesc)
        {
            this.ARID = arid;
            this.UserNum = usernum;
            this.MachineCode = machinecode;
            this.RecordDate = recorddate;
            this.AttendType = attendtype;
            this.IsAnalysis = isanalysis;
            this.AttendDesc = attenddesc;
        }

        private string arid;//ID
        private string usernum;//工号
        private string machinecode;//打卡机号码
        private DateTime recorddate;//打卡时间
        private int attendtype;//考勤方式
        private int isanalysis;//是否分析
        private string attenddesc;//备注
        private DateTime begin;//开始时间
        private DateTime end;//结束时间
        private string username;
        public string UserName { get { return username; } set { username = value; } }
        public DateTime Begin { get { return begin; } set { begin = value; } }
        public DateTime End { get { return end; } set { end = value; } }
        public string AttImg { get; set; }
        //1 进 2 出
        public int OutType { get; set; }

        ///<summary>
        ///ID
        ///</summary>
        public string ARID
        {
            get
            {
                return arid;
            }
            set
            {
                arid = value;
            }
        }

        ///<summary>
        ///工号
        ///</summary>
        public string UserNum
        {
            get
            {
                return usernum;
            }
            set
            {
                usernum = value;
            }
        }

        ///<summary>
        ///打卡机号码
        ///</summary>
        public string MachineCode
        {
            get
            {
                return machinecode;
            }
            set
            {
                machinecode = value;
            }
        }

        ///<summary>
        ///打卡时间
        ///</summary>
        public DateTime RecordDate
        {
            get
            {
                return recorddate;
            }
            set
            {
                recorddate = value;
            }
        }

        ///<summary>
        ///考勤方式
        ///</summary>
        public int AttendType
        {
            get
            {
                return attendtype;
            }
            set
            {
                attendtype = value;
            }
        }

        ///<summary>
        ///是否分析
        ///</summary>
        public int IsAnalysis
        {
            get
            {
                return isanalysis;
            }
            set
            {
                isanalysis = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string AttendDesc
        {
            get
            {
                return attenddesc;
            }
            set
            {
                attenddesc = value;
            }
        }
    }
}

