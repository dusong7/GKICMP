/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年03月09日 11点27分
** 描   述:      工作实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_WorkExperienceEntity
    {

        /// <summary>
        /// Teacher_WorkExperience表实体
        ///</summary>
        public Teacher_WorkExperienceEntity()
        {
        }

        public Teacher_WorkExperienceEntity(int ttype)
        {
             this.TType = ttype;
        }


        /// <summary>
        /// Teacher_WorkExperience表实体
        /// </summary>
        /// <param name="tweid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="trainaddress">任职单位名称</param>
        /// <param name="tstartdate">任职开始年月</param>
        /// <param name="tenddate">任职j结束年月</param>
        /// <param name="traincontent">任职岗位</param>
        /// <param name="ttype">单位性质类别</param>
        /// <param name="aduitstate">审核状态</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_WorkExperienceEntity(string tweid, string tid, string trainaddress, DateTime tstartdate, DateTime tenddate, string traincontent, int ttype, int aduitstate, int isdel)
        {
            this.TWEID = tweid;
            this.TID = tid;
            this.TrainAddress = trainaddress;
            this.TStartDate = tstartdate;
            this.TEndDate = tenddate;
            this.TrainContent = traincontent;
            this.TType = ttype;
            this.AduitState = aduitstate;
            this.Isdel = isdel;
        }

        private string tweid;//ID
        private string tid;//教师ID
        private string trainaddress;//任职单位名称
        private DateTime tstartdate;//任职开始年月
        private DateTime tenddate;//任职j结束年月
        private string traincontent;//任职岗位
        private int ttype;//单位性质类别
        private int aduitstate;//审核状态
        private int isdel;//是否删除
        private int isreport;//是否上报
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
        private string tname;
        public string TName
        {
            get
            {
                return tname;
            }
            set
            {
                tname = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string TWEID
        {
            get
            {
                return tweid;
            }
            set
            {
                tweid = value;
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
        ///任职单位名称
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
        ///任职开始年月
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
        ///任职j结束年月
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
        ///任职岗位
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
        ///单位性质类别
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
        ///审核状态
        ///</summary>
        public int AduitState
        {
            get
            {
                return aduitstate;
            }
            set
            {
                aduitstate = value;
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

