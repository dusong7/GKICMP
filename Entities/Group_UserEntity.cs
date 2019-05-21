/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年12月14日 09点07分
** 描   述:      自定义分组实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Group_UserEntity
    {

        /// <summary>
        /// Group_User表实体
        ///</summary>
        public Group_UserEntity()
        {
        }


        /// <summary>
        /// Group_User表实体
        /// </summary>
        /// <param name="groupuid">GroupUID</param>
        /// <param name="did">分组ID</param>
        /// <param name="sysid">建立用户</param>
        public Group_UserEntity(int groupuid, int did, string sysid)
        {
            this.GroupUID = groupuid;
            this.DID = did;
            this.SysID = sysid;
        }

        private int groupuid;//GroupUID
        private int did;//分组ID
        private string sysid;//建立用户


        ///<summary>
        ///GroupUID
        ///</summary>
        public int GroupUID
        {
            get
            {
                return groupuid;
            }
            set
            {
                groupuid = value;
            }
        }

        ///<summary>
        ///分组ID
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
        ///建立用户
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
    }
}

