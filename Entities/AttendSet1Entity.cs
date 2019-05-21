using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
    public class AttendSet1Entity
    {

        /// <summary>
        /// AttendSet表实体
        ///</summary>
        public AttendSet1Entity()
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
        public AttendSet1Entity(int asid, DateTime mbegin, DateTime mend, string roles, int isuse)
        {
            this.ASID = asid;
            this.MBegin = mbegin;
            this.MEnd = mend;
            //this.ABegin = abegin;
            //this.AEnd = aend;
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
        public int OutType { get; set; }

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

        /////<summary>
        /////下午开始时间
        /////</summary>
        //public DateTime ABegin
        //{
        //    get
        //    {
        //        return abegin;
        //    }
        //    set
        //    {
        //        abegin = value;
        //    }
        //}

        /////<summary>
        /////下午结束时间
        /////</summary>
        //public DateTime AEnd
        //{
        //    get
        //    {
        //        return aend;
        //    }
        //    set
        //    {
        //        aend = value;
        //    }
        //}

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
