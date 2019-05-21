/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 02点38分
** 描   述:      排课计划实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class TeacherPlaneEntity
    {

        /// <summary>
        /// TeacherPlane表实体
        ///</summary>
        public TeacherPlaneEntity()
        {
        }


        /// <summary>
        /// TeacherPlane表实体
        /// </summary>
        /// <param name="tpid">ID</param>
        /// <param name="ctid">课表ID</param>
        /// <param name="courseid">课程ID</param>
        /// <param name="teacherid">教师ID</param>
        /// <param name="claid">班级ID</param>
        /// <param name="jieshu">节数</param>
        /// <param name="lianjie">连节</param>
        /// <param name="lianci">连次</param>
        /// <param name="crid">场地(教室）</param>
        public TeacherPlaneEntity(string tpid, string ctid, int courseid, string teacherid, int claid, int jieshu, int lianjie, int lianci, int crid)
        {
            this.TPID = tpid;
            this.CTID = ctid;
            this.CourseID = courseid;
            this.TeacherID = teacherid;
            this.ClaID = claid;
            this.JieShu = jieshu;
            this.LianJie = lianjie;
            this.LianCi = lianci;
            this.CRID = crid;
        }

        private string tpid;//ID
        private string ctid;//课表ID
        private int courseid;//课程ID
        private string teacherid;//教师ID
        private int claid;//班级ID
        private int jieshu;//节数
        private int lianjie;//连节
        private int lianci;//连次
        private int crid;//场地(教室）


        ///<summary>
        ///ID
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
        ///课表ID
        ///</summary>
        public string CTID
        {
            get
            {
                return ctid;
            }
            set
            {
                ctid = value;
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
        ///班级ID
        ///</summary>
        public int ClaID
        {
            get
            {
                return claid;
            }
            set
            {
                claid = value;
            }
        }

        ///<summary>
        ///节数
        ///</summary>
        public int JieShu
        {
            get
            {
                return jieshu;
            }
            set
            {
                jieshu = value;
            }
        }

        ///<summary>
        ///连节
        ///</summary>
        public int LianJie
        {
            get
            {
                return lianjie;
            }
            set
            {
                lianjie = value;
            }
        }

        ///<summary>
        ///连次
        ///</summary>
        public int LianCi
        {
            get
            {
                return lianci;
            }
            set
            {
                lianci = value;
            }
        }

        ///<summary>
        ///场地(教室）
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
    }
}

