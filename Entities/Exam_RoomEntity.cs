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

    public class Exam_RoomEntity
    {

        /// <summary>
        /// Exam_Room表实体
        ///</summary>
        public Exam_RoomEntity()
        {
        }


        /// <summary>
        /// Exam_Room表实体
        /// </summary>
        /// <param name="erid">考场ID</param>
        /// <param name="eid">考试ID</param>
        /// <param name="crid">教室ID</param>
        /// <param name="roomnum">考场号</param>
        /// <param name="stunum">学生数</param>
        /// <param name="teanum">教师数</param>
        public Exam_RoomEntity(int erid, string eid, int crid, string roomnum, int stunum, int teanum)
        {
            this.ERID = erid;
            this.EID = eid;
            this.CRID = crid;
            this.RoomNum = roomnum;
            this.StuNum = stunum;
            this.TeaNum = teanum;
        }

        private int erid;//考场ID
        private string eid;//考试ID
        private int crid;//教室ID
        private string roomnum;//考场号
        private int stunum;//学生数
        private int teanum;//教师数


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
        ///教室ID
        ///</summary>
        public int CRID
        {
            get
            {
                return crid;
            }
            set
            {
                crid = value;
            }
        }

        ///<summary>
        ///考场号
        ///</summary>
        public string RoomNum
        {
            get
            {
                return roomnum;
            }
            set
            {
                roomnum = value;
            }
        }

        ///<summary>
        ///学生数
        ///</summary>
        public int StuNum
        {
            get
            {
                return stunum;
            }
            set
            {
                stunum = value;
            }
        }

        ///<summary>
        ///教师数
        ///</summary>
        public int TeaNum
        {
            get
            {
                return teanum;
            }
            set
            {
                teanum = value;
            }
        }
    }
}

