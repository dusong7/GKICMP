/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年05月17日 05点16分
** 描   述:      教师学习培训实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_TrainEntity
    {

        /// <summary>
        /// Teacher_Train表实体
        ///</summary>
        public Teacher_TrainEntity()
        {
        }


        /// <summary>
        /// Teacher_Train表实体
        /// </summary>
        /// <param name="ttid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="tyear">培训年份</param>
        /// <param name="tstartdate">开始日期</param>
        /// <param name="tenddate">结束日期</param>
        /// <param name="trainaddress">学习或培训地点</param>
        /// <param name="thours">课时</param>
        /// <param name="traincontent">学习或培训内容</param>
        /// <param name="ttype">学习类型</param>
        /// <param name="tdesc">备注</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="isreport"></param>
        public Teacher_TrainEntity(string ttid, string tid, int tyear, DateTime tstartdate, DateTime tenddate, string trainaddress, int thours, string traincontent, int ttype, string tdesc, int isdel, int isreport)
        {
            this.TTID = ttid;
            this.TID = tid;
            this.TYear = tyear;
            this.TStartDate = tstartdate;
            this.TEndDate = tenddate;
            this.TrainAddress = trainaddress;
            this.THours = thours;
            this.TrainContent = traincontent;
            this.TType = ttype;
            this.TDesc = tdesc;
            this.Isdel = isdel;
            this.IsReport = isreport;
        }

        private string ttid;//ID
        private string tid;//教师ID
        private int tyear;//培训年份
        private DateTime tstartdate;//开始日期
        private DateTime tenddate;//结束日期
        private string trainaddress;//学习或培训地点
        private int thours;//课时
        private string traincontent;//学习或培训内容
        private int ttype;//学习类型
        private string tdesc;//备注
        private int isdel;//是否删除
        private int isreport;//
        private string ttypename;
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
        public string TTypeName
        {
            get
            {
                return ttypename;
            }
            set
            {
                ttypename = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string TTID
        {
            get
            {
                return ttid;
            }
            set
            {
                ttid = value;
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
        ///培训年份
        ///</summary>
        public int TYear
        {
            get
            {
                return tyear;
            }
            set
            {
                tyear = value;
            }
        }

        ///<summary>
        ///开始日期
        ///</summary>
        public DateTime TStartDate
        {
            get
            {
                return tstartdate;
            }
            set
            {
                tstartdate = value;
            }
        }

        ///<summary>
        ///结束日期
        ///</summary>
        public DateTime TEndDate
        {
            get
            {
                return tenddate;
            }
            set
            {
                tenddate = value;
            }
        }

        ///<summary>
        ///学习或培训地点
        ///</summary>
        public string TrainAddress
        {
            get
            {
                return trainaddress;
            }
            set
            {
                trainaddress = value;
            }
        }

        ///<summary>
        ///课时
        ///</summary>
        public int THours
        {
            get
            {
                return thours;
            }
            set
            {
                thours = value;
            }
        }

        ///<summary>
        ///学习或培训内容
        ///</summary>
        public string TrainContent
        {
            get
            {
                return traincontent;
            }
            set
            {
                traincontent = value;
            }
        }

        ///<summary>
        ///学习类型
        ///</summary>
        public int TType
        {
            get
            {
                return ttype;
            }
            set
            {
                ttype = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string TDesc
        {
            get
            {
                return tdesc;
            }
            set
            {
                tdesc = value;
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

        ///<summary>
        ///
        ///</summary>
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
    }
}

