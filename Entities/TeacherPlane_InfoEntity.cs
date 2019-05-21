/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年10月07日 09点52分
** 描   述:      排课计划详细信息实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class TeacherPlane_InfoEntity
    {

        /// <summary>
        /// TeacherPlane_Info表实体
        ///</summary>
        public TeacherPlane_InfoEntity()
        {
        }


        /// <summary>
        /// TeacherPlane_Info表实体
        /// </summary>
        /// <param name="tiid"></param>
        /// <param name="tpid">计划ID</param>
        /// <param name="courseid">课程ID</param>
        /// <param name="teacherid">教师ID</param>
        /// <param name="position">星期位置</param>
        /// <param name="ptype">1:必须  2:禁止  3：推荐  4：普通</param>
        public TeacherPlane_InfoEntity(int tiid, string tpid, int courseid, string teacherid, int position, int ptype)
        {
            this.TIID = tiid;
            this.TPID = tpid;
            this.CourseID = courseid;
            this.TeacherID = teacherid;
            this.Position = position;
            this.PType = ptype;
        }

        private int tiid;//
        private string tpid;//计划ID
        private int courseid;//课程ID
        private string teacherid;//教师ID
        private int position;//星期位置
        private int ptype;//1:必须  2:禁止  3：推荐  4：普通


        ///<summary>
        ///
        ///</summary>
        public int TIID
        {
            get
            {
                return tiid;
            }
            set
            {
                tiid = value;
            }
        }

        ///<summary>
        ///计划ID
        ///</summary>
        public string TPID
        {
            get
            {
                return tpid;
            }
            set
            {
                tpid = value;
            }
        }

        ///<summary>
        ///课程ID
        ///</summary>
        public int CourseID
        {
            get
            {
                return courseid;
            }
            set
            {
                courseid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TeacherID
        {
            get
            {
                return teacherid;
            }
            set
            {
                teacherid = value;
            }
        }

        ///<summary>
        ///星期位置
        ///</summary>
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        ///<summary>
        ///1:必须  2:禁止  3：推荐  4：普通
        ///</summary>
        public int PType
        {
            get
            {
                return ptype;
            }
            set
            {
                ptype = value;
            }
        }
    }
}

