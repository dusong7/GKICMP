/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月15日 06点09分
** 描   述:      学生体质健康实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Stu_PhysicalEntity
    {

        /// <summary>
        /// Stu_Physical表实体
        ///</summary>
        public Stu_PhysicalEntity()
        {
        }


        /// <summary>
        /// Stu_Physical表实体
        /// </summary>
        /// <param name="spid">奖励ID</param>
        /// <param name="stuid">学生</param>
        /// <param name="stuweight">奖励类型</param>
        /// <param name="stuheight">获奖时间</param>
        /// <param name="bust">获奖描述</param>
        /// <param name="lvision">申请材料</param>
        /// <param name="rvision">材料路劲</param>
        /// <param name="lhearing">标识 1：奖励   2：惩罚</param>
        /// <param name="rhearing"></param>
        /// <param name="vitalcapacity"></param>
        /// <param name="dentalcaries"></param>
        /// <param name="term"></param>
        /// <param name="eyear"></param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        public Stu_PhysicalEntity(string spid, string stuid, decimal stuweight, decimal stuheight, decimal bust, decimal lvision, decimal rvision, decimal lhearing, decimal rhearing, decimal vitalcapacity, int dentalcaries, int term, string eyear, string createuser, DateTime createdate)
        {
            this.SPID = spid;
            this.StuID = stuid;
            this.StuWeight = stuweight;
            this.StuHeight = stuheight;
            this.Bust = bust;
            this.LVision = lvision;
            this.RVision = rvision;
            this.Lhearing = lhearing;
            this.Rhearing = rhearing;
            this.Vitalcapacity = vitalcapacity;
            this.DentalCaries = dentalcaries;
            this.Term = term;
            this.EYear = eyear;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private string spid;//奖励ID
        private string stuid;//学生
        private decimal stuweight;//奖励类型
        private decimal stuheight;//获奖时间
        private decimal bust;//获奖描述
        private decimal lvision;//申请材料
        private decimal rvision;//材料路劲
        private decimal lhearing;//标识 1：奖励   2：惩罚
        private decimal rhearing;//
        private decimal vitalcapacity;//
        private int dentalcaries;//
        private int term;//
        private string eyear;//
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private string realname;
        public string RealName
        {
            get
            {
                return realname;
            }
            set
            {
                realname = value;
            }
        }

        ///<summary>
        ///奖励ID
        ///</summary>
        public string SPID
        {
            get
            {
                return spid;
            }
            set
            {
                spid = value;
            }
        }

        ///<summary>
        ///学生
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
        ///奖励类型
        ///</summary>
        public decimal StuWeight
        {
            get
            {
                return stuweight;
            }
            set
            {
                stuweight = value;
            }
        }

        ///<summary>
        ///获奖时间
        ///</summary>
        public decimal StuHeight
        {
            get
            {
                return stuheight;
            }
            set
            {
                stuheight = value;
            }
        }

        ///<summary>
        ///获奖描述
        ///</summary>
        public decimal Bust
        {
            get
            {
                return bust;
            }
            set
            {
                bust = value;
            }
        }

        ///<summary>
        ///申请材料
        ///</summary>
        public decimal LVision
        {
            get
            {
                return lvision;
            }
            set
            {
                lvision = value;
            }
        }

        ///<summary>
        ///材料路劲
        ///</summary>
        public decimal RVision
        {
            get
            {
                return rvision;
            }
            set
            {
                rvision = value;
            }
        }

        ///<summary>
        ///标识 1：奖励   2：惩罚
        ///</summary>
        public decimal Lhearing
        {
            get
            {
                return lhearing;
            }
            set
            {
                lhearing = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Rhearing
        {
            get
            {
                return rhearing;
            }
            set
            {
                rhearing = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Vitalcapacity
        {
            get
            {
                return vitalcapacity;
            }
            set
            {
                vitalcapacity = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int DentalCaries
        {
            get
            {
                return dentalcaries;
            }
            set
            {
                dentalcaries = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int Term
        {
            get
            {
                return term;
            }
            set
            {
                term = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string EYear
        {
            get
            {
                return eyear;
            }
            set
            {
                eyear = value;
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
        ///录入时间
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

