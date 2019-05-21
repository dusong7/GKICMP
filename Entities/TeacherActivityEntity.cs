/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月15日 08点38分
** 描   述:      教师活动实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class TeacherActivityEntity
    {
        /// <summary>
        /// TeacherActivity表实体
        ///</summary>
        public TeacherActivityEntity()
        {
        }


        /// <summary>
        /// TeacherActivity表实体
        /// </summary>
        /// <param name="said">ID</param>
        /// <param name="actname">活动名称</param>
        /// <param name="acttype">活动类型</param>
        /// <param name="isdel">是否删除</param>
        public TeacherActivityEntity(string actname, int acttype, int isdel)
        {
            this.ActName = actname;
            this.ActType = acttype;
            this.Isdel = isdel;
        }

        private string said;//ID
        private string actname;//活动名称
        private int acttype;//活动类型
        private string actaddress;//活动地点
        private string counselor;//指导教师
        private string actcontent;//活动内容
        private string actdesc;//备注
        private DateTime abegin;//活动开始时间
        private DateTime aend;//活动结束时间
        private DateTime createdate;//录入日期
        private int isdel;//是否删除

        /// <summary>
        /// 参与教师姓名
        /// </summary>
        public string CounselorName
        {
            get;
            set;
        }

        /// <summary>
        /// 活动类型名称
        /// </summary>
        public string ActTypeName
        {
            get;
            set;
        }

        ///<summary>
        ///ID
        ///</summary>
        public string SAID
        {
            get
            {
                return said;
            }
            set
            {
                said = value;
            }
        }

        ///<summary>
        ///活动名称
        ///</summary>
        public string ActName
        {
            get
            {
                return actname;
            }
            set
            {
                actname = value;
            }
        }

        ///<summary>
        ///活动类型
        ///</summary>
        public int ActType
        {
            get
            {
                return acttype;
            }
            set
            {
                acttype = value;
            }
        }

        ///<summary>
        ///活动地点
        ///</summary>
        public string ActAddress
        {
            get
            {
                return actaddress;
            }
            set
            {
                actaddress = value;
            }
        }

        ///<summary>
        ///指导教师
        ///</summary>
        public string Counselor
        {
            get
            {
                return counselor;
            }
            set
            {
                counselor = value;
            }
        }

        ///<summary>
        ///活动内容
        ///</summary>
        public string ActContent
        {
            get
            {
                return actcontent;
            }
            set
            {
                actcontent = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string ActDesc
        {
            get
            {
                return actdesc;
            }
            set
            {
                actdesc = value;
            }
        }

        ///<summary>
        ///活动开始时间
        ///</summary>
        public DateTime ABegin
        {
            get
            {
                return abegin;
            }
            set
            {
                abegin = value;
            }
        }

        ///<summary>
        ///活动结束时间
        ///</summary>
        public DateTime AEnd
        {
            get
            {
                return aend;
            }
            set
            {
                aend = value;
            }
        }

        ///<summary>
        ///录入日期
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