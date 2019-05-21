/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年09月27日 03点47分
** 描   述:      考勤设置实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AttendSetEntity
    {

        /// <summary>
        /// AttendSet表实体
        ///</summary>
        public AttendSetEntity()
        {
        }


        /// <summary>
        /// AttendSet表实体
        /// </summary>
        /// <param name="asid">ID</param>
        /// <param name="mbegin">上午时间</param>
        /// <param name="mend">上午结束时间</param>
        /// <param name="abegin">下午开始时间</param>
        /// <param name="aend">下午结束时间</param>
        /// <param name="roles">适用角色</param>
        /// <param name="isuse">是否启用</param>
        public AttendSetEntity(int asid, DateTime mbegin, DateTime mend, DateTime abegin, DateTime aend, string roles, int isuse)
        {
            this.ASID = asid;
            this.MBegin = mbegin;
            this.MEnd = mend;
            this.ABegin = abegin;
            this.AEnd = aend;
            this.Roles = roles;
            this.IsUse = isuse;
        }

        private int asid;//ID
        private DateTime mbegin;//上午时间
        private DateTime mend;//上午结束时间
        private DateTime abegin;//下午开始时间
        private DateTime aend;//下午结束时间
        private string roles;//适用角色
        private int isuse;//是否启用
        private int atype;//节点类型

        public int OutType { get; set; }
        public string AName { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public int ASID
        {
            get
            {
                return asid;
            }
            set
            {
                asid = value;
            }
        }

        /// <summary>
        /// 节点类型
        /// </summary>
        public int AType
        {
            get { return atype; }
            set { atype = value; }
        }

        ///<summary>
        ///上午时间
        ///</summary>
        public DateTime MBegin
        {
            get
            {
                return mbegin;
            }
            set
            {
                mbegin = value;
            }
        }

        ///<summary>
        ///上午结束时间
        ///</summary>
        public DateTime MEnd
        {
            get
            {
                return mend;
            }
            set
            {
                mend = value;
            }
        }

        ///<summary>
        ///下午开始时间
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
        ///下午结束时间
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
        ///适用角色
        ///</summary>
        public string Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
            }
        }

        ///<summary>
        ///是否启用
        ///</summary>
        public int IsUse
        {
            get
            {
                return isuse;
            }
            set
            {
                isuse = value;
            }
        }
    }
}

