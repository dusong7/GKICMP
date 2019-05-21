/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年12月01日 08点11分
** 描   述:      我的练习实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ExamPaper_PractStuEntity
    {

        /// <summary>
        /// ExamPaper_PractStu表实体
        ///</summary>
        public ExamPaper_PractStuEntity()
        {
        }


        /// <summary>
        /// ExamPaper_PractStu表实体
        /// </summary>
        /// <param name="ppsid">ID</param>
        /// <param name="eppid">练习ID</param>
        /// <param name="stuid">练习人</param>
        /// <param name="createdate">开始时间</param>
        /// <param name="completedate">完成时间</param>
        /// <param name="pscore">分数</param>
        /// <param name="iscomplete">是否完成</param>
        public ExamPaper_PractStuEntity(int ppsid, string eppid, string stuid, DateTime createdate, DateTime completedate, decimal pscore, int iscomplete)
        {
            this.PPSID = ppsid;
            this.EPPID = eppid;
            this.StuID = stuid;
            this.CreateDate = createdate;
            this.CompleteDate = completedate;
            this.PScore = pscore;
            this.IsComplete = iscomplete;
        }

        private int ppsid;//ID
        private string eppid;//练习ID
        private string stuid;//练习人
        private DateTime createdate;//开始时间
        private DateTime completedate;//完成时间
        private decimal pscore;//分数
        private int iscomplete;//是否完成
        private string ePID;//试卷ID

        public string EPID
        {
            get { return ePID; }
            set { ePID = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public int PPSID
        {
            get
            {
                return ppsid;
            }
            set
            {
                ppsid = value;
            }
        }

        ///<summary>
        ///练习ID
        ///</summary>
        public string EPPID
        {
            get
            {
                return eppid;
            }
            set
            {
                eppid = value;
            }
        }

        ///<summary>
        ///练习人
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
        ///开始时间
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
        ///完成时间
        ///</summary>
        public DateTime CompleteDate
        {
            get
            {
                return completedate;
            }
            set
            {
                completedate = value;
            }
        }

        ///<summary>
        ///分数
        ///</summary>
        public decimal PScore
        {
            get
            {
                return pscore;
            }
            set
            {
                pscore = value;
            }
        }

        ///<summary>
        ///是否完成
        ///</summary>
        public int IsComplete
        {
            get
            {
                return iscomplete;
            }
            set
            {
                iscomplete = value;
            }
        }
    }
}

