/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年01月03日 03点36分
** 描   述:      学生选课实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Electiver_StuEntity
    {

        /// <summary>
        /// Electiver_Stu表实体
        ///</summary>
        public Electiver_StuEntity()
        {
        }


        /// <summary>
        /// Electiver_Stu表实体
        /// </summary>
        /// <param name="esid">ID</param>
        /// <param name="eleid">任务ID</param>
        /// <param name="corseid">课程ID</param>
        /// <param name="stuid">学生ID</param>
        /// <param name="eledate">选课时间</param>
        /// <param name="etype">类型  1:预选   2:实选</param>
        /// <param name="groupid">班级ID</param>
        /// <param name="isback">是否退课</param>
        /// <param name="backdate">退课时间</param>
        public Electiver_StuEntity(int esid, int eleid, int corseid, string stuid, DateTime eledate, int etype, int groupid, int isback, DateTime backdate)
        {
            this.ESID = esid;
            this.EleID = eleid;
            this.CorseID = corseid;
            this.StuID = stuid;
            this.EleDate = eledate;
            this.EType = etype;
            this.GroupID = groupid;
            this.IsBack = isback;
            this.BackDate = backdate;
        }

        private int esid;//ID
        private int eleid;//任务ID
        private int corseid;//课程ID
        private string stuid;//学生ID
        private DateTime eledate;//选课时间
        private int etype;//类型  1:预选   2“实选
        private int groupid;//班级ID
        private int isback;//是否退课
        private DateTime backdate;//退课时间


        ///<summary>
        ///ID
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
        ///任务ID
        ///</summary>
        public int EleID
        {
            get
            {
                return eleid;
            }
            set
            {
                eleid = value;
            }
        }

        ///<summary>
        ///课程ID
        ///</summary>
        public int CorseID
        {
            get
            {
                return corseid;
            }
            set
            {
                corseid = value;
            }
        }

        ///<summary>
        ///学生ID
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
        ///选课时间
        ///</summary>
        public DateTime EleDate
        {
            get
            {
                return eledate;
            }
            set
            {
                eledate = value;
            }
        }

        ///<summary>
        ///类型  1:预选   2“实选
        ///</summary>
        public int EType
        {
            get
            {
                return etype;
            }
            set
            {
                etype = value;
            }
        }

        ///<summary>
        ///班级ID
        ///</summary>
        public int GroupID
        {
            get
            {
                return groupid;
            }
            set
            {
                groupid = value;
            }
        }

        ///<summary>
        ///是否退课
        ///</summary>
        public int IsBack
        {
            get
            {
                return isback;
            }
            set
            {
                isback = value;
            }
        }

        ///<summary>
        ///退课时间
        ///</summary>
        public DateTime BackDate
        {
            get
            {
                return backdate;
            }
            set
            {
                backdate = value;
            }
        }
    }
}

