/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月11日 01点36分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Exam_SubjectEntity
    {

        /// <summary>
        /// Exam_Subject表实体
        ///</summary>
        public Exam_SubjectEntity()
        {
        }


        /// <summary>
        /// Exam_Subject表实体
        /// </summary>
        /// <param name="esid">考试科目ID</param>
        /// <param name="eid">考试ID</param>
        /// <param name="cid">科目ID</param>
        /// <param name="begindate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="subcode">对应成绩编号</param>
        /// <param name="sorder">排序</param>
        public Exam_SubjectEntity(int esid, string eid, int cid, DateTime begindate, DateTime enddate, int subcode, int sorder)
        {
            this.ESID = esid;
            this.EID = eid;
            this.CID = cid;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.SubCode = subcode;
            this.SOrder = sorder;
        }

        private int esid;//考试科目ID
        private string eid;//考试ID
        private int cid;//科目ID
        private DateTime begindate;//开始时间
        private DateTime enddate;//结束时间
        private int subcode;//对应成绩编号
        private int sorder;//排序


        ///<summary>
        ///考试科目ID
        ///</summary>
        public int ESID
        {
            get
            {
                return esid;
            }
            set
            {
                esid = value;
            }
        }

        ///<summary>
        ///考试ID
        ///</summary>
        public string EID
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
        }

        ///<summary>
        ///科目ID
        ///</summary>
        public int CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
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
        ///对应成绩编号
        ///</summary>
        public int SubCode
        {
            get
            {
                return subcode;
            }
            set
            {
                subcode = value;
            }
        }

        ///<summary>
        ///排序
        ///</summary>
        public int SOrder
        {
            get
            {
                return sorder;
            }
            set
            {
                sorder = value;
            }
        }
    }
}

