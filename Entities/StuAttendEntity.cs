/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年01月05日 09点03分
** 描   述:      晨检申报实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class StuAttendEntity
    {

        /// <summary>
        /// StuAttend表实体
        ///</summary>
        public StuAttendEntity()
        {
        }


        /// <summary>
        /// StuAttend表实体
        /// </summary>
        /// <param name="stid">ID</param>
        /// <param name="leaveuser">迟到</param>
        /// <param name="infectious">传染病</param>
        /// <param name="did">班级ID</param>
        /// <param name="compassionate">事假</param>
        /// <param name="sick">病假</param>
        /// <param name="others">其他</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="realcount">实到</param>
        /// <param name="allins">应到</param>
        public StuAttendEntity(string stid, int leaveuser, int infectious, int did, int compassionate, int sick, int others, string createuser, DateTime createdate, int realcount, int allins)
        {
            this.STID = stid;
            this.LeaveUser = leaveuser;
            this.Infectious = infectious;
            this.DID = did;
            this.Compassionate = compassionate;
            this.Sick = sick;
            this.Others = others;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.RealCOunt = realcount;
            this.AllIns = allins;
        }

        private string stid;//ID
        private int leaveuser;//迟到
        private int infectious;//传染病
        private int did;//班级ID
        private int compassionate;//事假
        private int sick;//病假
        private int others;//其他
        private string createuser;//录入人
        private DateTime createdate;//录入日期
        private int realcount;//实到
        private int allins;//应到
        private string leaveUserName;//迟到
        private string infectiousName;//传染病
        private string compassionateName;//事假
        private string sickName;//病假
        private string dIDName;//班级
        private string infectiousNames;//传染病
        private string leaveUserNames;//迟到

        public string LeaveUserNames
        {
            get { return leaveUserNames; }
            set { leaveUserNames = value; }
        }
        public string InfectiousNames
        {
            get { return infectiousNames; }
            set { infectiousNames = value; }
        }
        private string compassionateNames;//事假

        public string CompassionateNames
        {
            get { return compassionateNames; }
            set { compassionateNames = value; }
        }
        private string sickNames;//病假

        public string SickNames
        {
            get { return sickNames; }
            set { sickNames = value; }
        }

        public string DIDName
        {
            get { return dIDName; }
            set { dIDName = value; }
        }


        public string SickName
        {
            get { return sickName; }
            set { sickName = value; }
        }

        public string CompassionateName
        {
            get { return compassionateName; }
            set { compassionateName = value; }
        }


        public string InfectiousName
        {
            get { return infectiousName; }
            set { infectiousName = value; }
        }
        public string LeaveUserName
        {
            get { return leaveUserName; }
            set { leaveUserName = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string STID
        {
            get
            {
                return stid;
            }
            set
            {
                stid = value;
            }
        }

        ///<summary>
        ///迟到
        ///</summary>
        public int LeaveUser
        {
            get
            {
                return leaveuser;
            }
            set
            {
                leaveuser = value;
            }
        }

        ///<summary>
        ///传染病
        ///</summary>
        public int Infectious
        {
            get
            {
                return infectious;
            }
            set
            {
                infectious = value;
            }
        }

        ///<summary>
        ///班级ID
        ///</summary>
        public int DID
        {
            get
            {
                return did;
            }
            set
            {
                did = value;
            }
        }

        ///<summary>
        ///事假
        ///</summary>
        public int Compassionate
        {
            get
            {
                return compassionate;
            }
            set
            {
                compassionate = value;
            }
        }

        ///<summary>
        ///病假
        ///</summary>
        public int Sick
        {
            get
            {
                return sick;
            }
            set
            {
                sick = value;
            }
        }

        ///<summary>
        ///其他
        ///</summary>
        public int Others
        {
            get
            {
                return others;
            }
            set
            {
                others = value;
            }
        }

        ///<summary>
        ///录入人
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
        ///录入日期
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
        ///实到
        ///</summary>
        public int RealCOunt
        {
            get
            {
                return realcount;
            }
            set
            {
                realcount = value;
            }
        }

        ///<summary>
        ///应到
        ///</summary>
        public int AllIns
        {
            get
            {
                return allins;
            }
            set
            {
                allins = value;
            }
        }
    }
}

