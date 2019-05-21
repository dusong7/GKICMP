/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月15日 05点59分
** 描   述:      学生变动实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SchoolChangeEntity
    {

        /// <summary>
        /// SchoolChange表实体
        ///</summary>
        public SchoolChangeEntity()
        {
        }


        /// <summary>
        /// SchoolChange表实体
        /// </summary>
        /// <param name="tid">异动ID</param>
        /// <param name="stuid">学生ID</param>
        /// <param name="sctype">异动类别</param>
        /// <param name="screason">异动原因</param>
        /// <param name="scdesc">异动说明</param>
        /// <param name="scdate">异动日期</param>
        /// <param name="createdate">记录日期</param>
        /// <param name="createuser">记录人</param>
        public SchoolChangeEntity(string tid, string stuid, int sctype, string screason, string scdesc, DateTime scdate, DateTime createdate, string createuser)
        {
            this.TID = tid;
            this.StuID = stuid;
            this.SCType = sctype;
            this.SCReason = screason;
            this.SCDesc = scdesc;
            this.SCDate = scdate;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
        }

        private string tid;//异动ID
        private string stuid;//学生ID
        private int sctype;//异动类别
        private string screason;//异动原因
        private string scdesc;//异动说明
        private DateTime scdate;//异动日期
        private DateTime createdate;//记录日期
        private string createuser;//记录人
        private string aduituser;//审核人
        private DateTime aduitdate;//审核日期
        private int aduitstate;//审核状态
        private string aduitdesc;//审核意见
        private string realName;
        private string claIDName;
        private string gradeName;
        private string stuIDName;
        /// <summary>
        /// 审核人
        /// </summary>
        public string AduitUser
        {
            get { return aduituser; }
            set { aduituser = value; }
        }
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime AduitDate
        {
            get { return aduitdate; }
            set { aduitdate = value; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int AduitState
        {
            get { return aduitstate; }
            set { aduitstate = value; }
        }
        /// <summary>
        /// 审核意见
        /// </summary>
        public string AduitDesc
        {
            get { return aduitdesc; }
            set { aduitdesc = value; }
        }

        public string StuIDName
        {
            get { return stuIDName; }
            set { stuIDName = value; }
        }

        public string GradeName
        {
            get { return gradeName; }
            set { gradeName = value; }
        }

        public string ClaIDName
        {
            get { return claIDName; }
            set { claIDName = value; }
        }

        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }


        ///<summary>
        ///异动ID
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
        ///学生ID
        ///</summary>
        public string StuID
        {
            get
            {
                return stuid;
            }
            set
            {
                stuid = value;
            }
        }

        ///<summary>
        ///异动类别
        ///</summary>
        public int SCType
        {
            get
            {
                return sctype;
            }
            set
            {
                sctype = value;
            }
        }

        ///<summary>
        ///异动原因
        ///</summary>
        public string SCReason
        {
            get
            {
                return screason;
            }
            set
            {
                screason = value;
            }
        }

        ///<summary>
        ///异动说明
        ///</summary>
        public string SCDesc
        {
            get
            {
                return scdesc;
            }
            set
            {
                scdesc = value;
            }
        }

        ///<summary>
        ///异动日期
        ///</summary>
        public DateTime SCDate
        {
            get
            {
                return scdate;
            }
            set
            {
                scdate = value;
            }
        }

        ///<summary>
        ///记录日期
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
        ///记录人
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
    }
}

