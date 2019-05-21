/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年11月04日 09点31分
** 描   述:      代课安排实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AbsentEntity
    {

        /// <summary>
        /// Absent表实体
        ///</summary>
        public AbsentEntity()
        {
        }


        /// <summary>
        /// Absent表实体
        /// </summary>
        /// <param name="abid">代课ID</param>
        /// <param name="absentuser">请假人</param>
        /// <param name="subdate">代课日期</param>
        /// <param name="subuser">代课人</param>
        /// <param name="subcount">节数</param>
        /// <param name="subcoruse">代课课程</param>
        /// <param name="subnum">节次</param>
        /// <param name="lid">请假id</param>
        /// <param name="othername">代课班级别名称</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建日期</param>
        /// <param name="substate">是否同意</param>
        /// <param name="did">代课班级</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="hourse">课时系数</param>
        /// <param name="reason">原因</param>
        public AbsentEntity(int abid, string absentuser, DateTime subdate, string subuser, int subcount, int subcoruse, int subnum, string lid, string othername, string createuser, DateTime createdate, int substate, int did, int isdel, int hourse, string reason)
        {
            this.AbID = abid;
            this.AbsentUser = absentuser;
            this.SubDate = subdate;
            this.SubUser = subuser;
            this.SubCount = subcount;
            this.SubCoruse = subcoruse;
            this.SubNum = subnum;
            this.LID = lid;
            this.OtherName = othername;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.SubState = substate;
            this.DID = did;
            this.Isdel = isdel;
            this.Hourse = hourse;
            this.Reason = reason;
        }

        private int abid;//代课ID
        private string absentuser;//请假人
        private DateTime subdate;//代课日期
        private string subuser;//代课人
        private int subcount;//节数
        private int subcoruse;//代课课程
        private int subnum;//节次
        private string lid;//请假id
        private string othername;//代课班级别名称
        private string createuser;//创建人
        private DateTime createdate;//创建日期
        private int substate;//是否同意
        private int did;//代课班级
        private int isdel;//是否删除
        private decimal hourse;//课时系数
        private string reason;//原因
        private string subUserName;//代价人名称
        private string absentUserName;//请假人名称
        private string createUserName;//创建人名称
        private string subCoruseName;//代课课程名称

        public string SubCoruseName
        {
            get { return subCoruseName; }
            set { subCoruseName = value; }
        }
        public string AbsentUserName
        {
            get { return absentUserName; }
            set { absentUserName = value; }
        }


        public string CreateUserName
        {
            get { return createUserName; }
            set { createUserName = value; }
        }



        public string SubUserName
        {
            get { return subUserName; }
            set { subUserName = value; }
        }


        ///<summary>
        ///代课ID
        ///</summary>
        public int AbID
        {
            get
            {
                return abid;
            }
            set
            {
                abid = value;
            }
        }

        ///<summary>
        ///请假人
        ///</summary>
        public string AbsentUser
        {
            get
            {
                return absentuser;
            }
            set
            {
                absentuser = value;
            }
        }

        ///<summary>
        ///代课日期
        ///</summary>
        public DateTime SubDate
        {
            get
            {
                return subdate;
            }
            set
            {
                subdate = value;
            }
        }

        ///<summary>
        ///代课人
        ///</summary>
        public string SubUser
        {
            get
            {
                return subuser;
            }
            set
            {
                subuser = value;
            }
        }

        ///<summary>
        ///节数
        ///</summary>
        public int SubCount
        {
            get
            {
                return subcount;
            }
            set
            {
                subcount = value;
            }
        }

        ///<summary>
        ///代课课程
        ///</summary>
        public int SubCoruse
        {
            get
            {
                return subcoruse;
            }
            set
            {
                subcoruse = value;
            }
        }

        ///<summary>
        ///节次
        ///</summary>
        public int SubNum
        {
            get
            {
                return subnum;
            }
            set
            {
                subnum = value;
            }
        }

        ///<summary>
        ///请假id
        ///</summary>
        public string LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }

        ///<summary>
        ///代课班级别名称
        ///</summary>
        public string OtherName
        {
            get
            {
                return othername;
            }
            set
            {
                othername = value;
            }
        }

        ///<summary>
        ///创建人
        ///</summary>
        public string CreateUser
        {
            get
            {
                return createuser;
            }
            set
            {
                createuser = value;
            }
        }

        ///<summary>
        ///创建日期
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
        ///是否同意
        ///</summary>
        public int SubState
        {
            get
            {
                return substate;
            }
            set
            {
                substate = value;
            }
        }

        ///<summary>
        ///代课班级
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

        ///<summary>
        ///课时系数
        ///</summary>
        public decimal Hourse
        {
            get
            {
                return hourse;
            }
            set
            {
                hourse = value;
            }
        }

        ///<summary>
        ///原因
        ///</summary>
        public string Reason
        {
            get
            {
                return reason;
            }
            set
            {
                reason = value;
            }
        }
    }
}

