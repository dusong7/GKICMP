/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月11日 01点37分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Exam_TeacherEntity
    {

        /// <summary>
        /// Exam_Teacher表实体
        ///</summary>
        public Exam_TeacherEntity()
        {
        }


        /// <summary>
        /// Exam_Teacher表实体
        /// </summary>
        /// <param name="etid">考试科目ID</param>
        /// <param name="eid">考试ID</param>
        /// <param name="erid">考场ID</param>
        /// <param name="cid">监考科目</param>
        /// <param name="tid">教师</param>
        public Exam_TeacherEntity(int etid, string eid, int erid, int cid, string tid)
        {
            this.ETID = etid;
            this.EID = eid;
            this.ERID = erid;
            this.CID = cid;
            this.TID = tid;
        }

        private int etid;//考试科目ID
        private string eid;//考试ID
        private int erid;//考场ID
        private int cid;//监考科目
        private string tid;//教师


        ///<summary>
        ///考试科目ID
        ///</summary>
        public int ETID
        {
            get
            {
                return etid;
            }
            set
            {
                etid = value;
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
        ///考场ID
        ///</summary>
        public int ERID
        {
            get
            {
                return erid;
            }
            set
            {
                erid = value;
            }
        }

        ///<summary>
        ///监考科目
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
        ///教师
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
    }
}

