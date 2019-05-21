/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年03月08日 03点47分
** 描   述:      考核实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_AssessmentEntity
    {

        /// <summary>
        /// Teacher_Assessment表实体
        ///</summary>
        public Teacher_AssessmentEntity()
        {
        }


        /// <summary>
        /// Teacher_Assessment表实体
        /// </summary>
        /// <param name="taid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="tsyear">年份</param>
        /// <param name="assresult">考核结果</param>
        /// <param name="aduitstate">审核状态</param>
        /// <param name="tsdesc">备注</param>
        /// <param name="tflag">标识</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_AssessmentEntity(string taid, string tid, DateTime tsyear, int assresult, int aduitstate, string tsdesc, int tflag, int isdel)
        {
            this.TAID = taid;
            this.TID = tid;
            this.TSYear = tsyear;
            this.AssResult = assresult;
            this.AduitState = aduitstate;
            this.TSDesc = tsdesc;
            this.TFlag = tflag;
            this.Isdel = isdel;
        }

        private string taid;//ID
        private string tid;//教师ID
        private DateTime tsyear;//年份
        private int assresult;//考核结果
        private int aduitstate;//审核状态
        private string tsdesc;//备注
        private int tflag;//标识
        private int isdel;//是否删除
        private string tname;
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
        public string TAID
        {
            get
            {
                return taid;
            }
            set
            {
                taid = value;
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
        ///年份
        ///</summary>
        public DateTime TSYear
        {
            get
            {
                return tsyear;
            }
            set
            {
                tsyear = value;
            }
        }

        ///<summary>
        ///考核结果
        ///</summary>
        public int AssResult
        {
            get
            {
                return assresult;
            }
            set
            {
                assresult = value;
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
        ///备注
        ///</summary>
        public string TSDesc
        {
            get
            {
                return tsdesc;
            }
            set
            {
                tsdesc = value;
            }
        }

        ///<summary>
        ///标识
        ///</summary>
        public int TFlag
        {
            get
            {
                return tflag;
            }
            set
            {
                tflag = value;
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

