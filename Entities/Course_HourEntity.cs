/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年10月26日 03点53分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Course_HourEntity
    {

        /// <summary>
        /// Course_Hour表实体
        ///</summary>
        public Course_HourEntity()
        {
        }


        /// <summary>
        /// Course_Hour表实体
        /// </summary>
        /// <param name="chid">ID</param>
        /// <param name="cid">课程ID</param>
        /// <param name="gid">年级IDs</param>
        /// <param name="chours">系数</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入日期</param>
        public Course_HourEntity(int chid, int cid, int gid, decimal chours, string createuser, DateTime createdate)
        {
            this.CHID = chid;
            this.CID = cid;
            this.GID = gid;
            this.CHours = chours;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private int chid;//ID
        private int cid;//课程ID
        private int gid;//年级IDs
        private decimal chours;//系数
        private string createuser;//录入人
        private DateTime createdate;//录入日期

        public string Gids { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public int CHID
        {
            get
            {
                return chid;
            }
            set
            {
                chid = value;
            }
        }

        ///<summary>
        ///课程ID
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
        ///年级IDs
        ///</summary>
        public int GID
        {
            get
            {
                return gid;
            }
            set
            {
                gid = value;
            }
        }

        ///<summary>
        ///系数
        ///</summary>
        public decimal CHours
        {
            get
            {
                return chours;
            }
            set
            {
                chours = value;
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
    }
}

