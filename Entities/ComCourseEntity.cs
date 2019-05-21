/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2018年02月27日 04点53分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ComCourseEntity
    {

        /// <summary>
        /// ComCourse表实体
        ///</summary>
        public ComCourseEntity()
        {
        }


        /// <summary>
        /// ComCourse表实体
        /// </summary>
        /// <param name="ccid">ID</param>
        /// <param name="sysid">上课教师</param>
        /// <param name="cid">学科</param>
        /// <param name="chaptername">课题</param>
        /// <param name="regdate">登记日期</param>
        /// <param name="xyear">年份</param>
        /// <param name="xterm">学期</param>
        /// <param name="crid">教室</param>
        /// <param name="did">班级ID</param>
        /// <param name="classnum">节次</param>
        /// <param name="isdel">是否删除</param>
        public ComCourseEntity(string ccid, string sysid, int cid, string chaptername, DateTime regdate, string xyear, int xterm, int crid, int did, int classnum, int isdel)
        {
            this.CCID = ccid;
            this.SysID = sysid;
            this.CID = cid;
            this.ChapterName = chaptername;
            this.RegDate = regdate;
            this.Xyear = xyear;
            this.XTerm = xterm;
            this.CRID = crid;
            this.DID = did;
            this.ClassNum = classnum;
            this.Isdel = isdel;
        }

        private string ccid;//ID
        private string sysid;//上课教师
        private int cid;//学科
        private string chaptername;//课题
        private DateTime regdate;//登记日期
        private string xyear;//年份
        private int xterm;//学期
        private int crid;//教室
        private int did;//班级ID
        private int classnum;//节次
        private int isdel;//是否删除


        ///<summary>
        ///ID
        ///</summary>
        public string CCID
        {
            get
            {
                return ccid;
            }
            set
            {
                ccid = value;
            }
        }

        ///<summary>
        ///上课教师
        ///</summary>
        public string SysID
        {
            get
            {
                return sysid;
            }
            set
            {
                sysid = value;
            }
        }

        ///<summary>
        ///学科
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
        ///课题
        ///</summary>
        public string ChapterName
        {
            get
            {
                return chaptername;
            }
            set
            {
                chaptername = value;
            }
        }

        ///<summary>
        ///登记日期
        ///</summary>
        public DateTime RegDate
        {
            get
            {
                return regdate;
            }
            set
            {
                regdate = value;
            }
        }

        ///<summary>
        ///年份
        ///</summary>
        public string Xyear
        {
            get
            {
                return xyear;
            }
            set
            {
                xyear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int XTerm
        {
            get
            {
                return xterm;
            }
            set
            {
                xterm = value;
            }
        }

        ///<summary>
        ///教室
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
        ///班级ID
        ///</summary>
        public int DID
        {
            get
            {
                return did;
            }
            set
            {
                did = value;
            }
        }

        ///<summary>
        ///节次
        ///</summary>
        public int ClassNum
        {
            get
            {
                return classnum;
            }
            set
            {
                classnum = value;
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

