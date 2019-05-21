/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月05日 02点13分
** 描   述:      来访登记实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class VisitEntity
    {

        /// <summary>
        /// Visit表实体
        ///</summary>
        public VisitEntity()
        {
        }


        /// <summary>
        /// Visit表实体
        /// </summary>
        /// <param name="vid">ID</param>
        /// <param name="visituser">来访人姓名</param>
        /// <param name="vdate">来访时间</param>
        /// <param name="visitreason">事由</param>
        /// <param name="schooluser">对接人</param>
        /// <param name="linknum">联系电话</param>
        /// <param name="idcard">身份证号码</param>
        /// <param name="leavedate">离开时间</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="vmark">备注</param>
        /// <param name="isdel">是否删除</param>
        public VisitEntity(int vid, string visituser, DateTime vdate, string visitreason, string schooluser, string linknum, string idcard, DateTime leavedate, string createuser, DateTime createdate, string vmark, int isdel)
        {
            this.VID = vid;
            this.VisitUser = visituser;
            this.VDate = vdate;
            this.VisitReason = visitreason;
            this.SchoolUser = schooluser;
            this.LinkNum = linknum;
            this.IDCard = idcard;
            this.LeaveDate = leavedate;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.VMark = vmark;
            this.Isdel = isdel;
        }

        private int vid;//ID
        private string visituser;//来访人姓名
        private DateTime vdate;//来访时间
        private string visitreason;//事由
        private string schooluser;//对接人
        private string linknum;//联系电话
        private string idcard;//身份证号码
        private DateTime leavedate;//离开时间
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private string vmark;//备注
        private int isdel;//是否删除
        private int visittype;//拜访类型
        private int visitcount;//来访人数
        private string createusername;

        public string CreateUserName
        {
            get { return createusername; }
            set { createusername = value; }
        }

        /// <summary>
        /// 来访人数
        /// </summary>
        public int VisitCount
        {
            get
            {
                return visitcount;
            }
            set
            {
                visitcount = value;
            }
        }

        /// <summary>
        /// 拜访类型
        /// </summary>
        public int VisitType
        {
            get
            {
                return visittype;
            }
            set
            {
                visittype = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public int VID
        {
            get
            {
                return vid;
            }
            set
            {
                vid = value;
            }
        }

        ///<summary>
        ///来访人姓名
        ///</summary>
        public string VisitUser
        {
            get
            {
                return visituser;
            }
            set
            {
                visituser = value;
            }
        }

        ///<summary>
        ///来访时间
        ///</summary>
        public DateTime VDate
        {
            get
            {
                return vdate;
            }
            set
            {
                vdate = value;
            }
        }

        ///<summary>
        ///事由
        ///</summary>
        public string VisitReason
        {
            get
            {
                return visitreason;
            }
            set
            {
                visitreason = value;
            }
        }

        ///<summary>
        ///对接人
        ///</summary>
        public string SchoolUser
        {
            get
            {
                return schooluser;
            }
            set
            {
                schooluser = value;
            }
        }

        ///<summary>
        ///联系电话
        ///</summary>
        public string LinkNum
        {
            get
            {
                return linknum;
            }
            set
            {
                linknum = value;
            }
        }

        ///<summary>
        ///身份证号码
        ///</summary>
        public string IDCard
        {
            get
            {
                return idcard;
            }
            set
            {
                idcard = value;
            }
        }

        ///<summary>
        ///离开时间
        ///</summary>
        public DateTime LeaveDate
        {
            get
            {
                return leavedate;
            }
            set
            {
                leavedate = value;
            }
        }

        ///<summary>
        ///录入人
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
        ///录入时间
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
        ///备注
        ///</summary>
        public string VMark
        {
            get
            {
                return vmark;
            }
            set
            {
                vmark = value;
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

