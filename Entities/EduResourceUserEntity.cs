/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年9月6日 8点59分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class EduResourceUserEntity
    {

        /// <summary>
        /// EduResourceUser表实体
        ///</summary>
        public EduResourceUserEntity()
        {
        }


        /// <summary>
        /// EduResourceUser表实体
        /// </summary>
        public EduResourceUserEntity(int euid, int erid, string createuser, DateTime createdate)
        {
            this.EUID = euid;
            this.Erid = erid;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private int euid;//ID
        private int erid;//资源ID
        private string createuser;//收藏人
        private DateTime createdate;//收藏时间

        /// <summary>
        /// ID
        /// </summary>
        public int EUID
        {
            get
            {
                return euid;
            }
            set
            {
                euid = value;
            }
        }

        ///<summary>
        ///资源ID
        ///</summary>
        public int Erid
        {
            get
            {
                return erid;
            }
            set
            {
                erid = value;
            }
        }

        ///<summary>
        ///收藏人
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
        ///收藏时间
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
