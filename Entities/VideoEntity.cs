/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年10月09日 11点10分
** 描   述:      视频配置实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class VideoEntity
    {

        /// <summary>
        /// Video表实体
        ///</summary>
        public VideoEntity()
        {
        }


        /// <summary>
        /// Video表实体
        /// </summary>
        /// <param name="vid">设备ID</param>
        /// <param name="equipname">设备名称</param>
        /// <param name="equipip">ip地址</param>
        /// <param name="potnum">端口号</param>
        /// <param name="username">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <param name="equippotnum">设备端口</param>
        /// <param name="equippre">预留字段</param>
        public VideoEntity(int vid, string equipname, string equipip, int potnum, string username, string userpwd, int equippotnum, string equippre)
        {
            this.VID = vid;
            this.EquipName = equipname;
            this.EquipIP = equipip;
            this.PotNum = potnum;
            this.UserName = username;
            this.UserPwd = userpwd;
            this.EquipPotNum = equippotnum;
            this.EquipPre = equippre;
        }

        private int vid;//设备ID
        private string equipname;//设备名称
        private string equipip;//ip地址
        private int potnum;//端口号
        private string username;//用户名
        private string userpwd;//密码
        private int equippotnum;//设备端口
        private string equippre;//预留字段


        ///<summary>
        ///设备ID
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
        ///设备名称
        ///</summary>
        public string EquipName
        {
            get
            {
                return equipname;
            }
            set
            {
                equipname = value;
            }
        }

        ///<summary>
        ///ip地址
        ///</summary>
        public string EquipIP
        {
            get
            {
                return equipip;
            }
            set
            {
                equipip = value;
            }
        }

        ///<summary>
        ///端口号
        ///</summary>
        public int PotNum
        {
            get
            {
                return potnum;
            }
            set
            {
                potnum = value;
            }
        }

        ///<summary>
        ///用户名
        ///</summary>
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        ///<summary>
        ///密码
        ///</summary>
        public string UserPwd
        {
            get
            {
                return userpwd;
            }
            set
            {
                userpwd = value;
            }
        }

        ///<summary>
        ///设备端口
        ///</summary>
        public int EquipPotNum
        {
            get
            {
                return equippotnum;
            }
            set
            {
                equippotnum = value;
            }
        }

        ///<summary>
        ///预留字段
        ///</summary>
        public string EquipPre
        {
            get
            {
                return equippre;
            }
            set
            {
                equippre = value;
            }
        }
    }
}

