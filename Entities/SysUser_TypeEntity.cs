/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月19日 03点14分
** 描   述:      基础数据实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SysUser_TypeEntity
    {

        /// <summary>
        /// SysUser_Type表实体
        ///</summary>
        public SysUser_TypeEntity()
        {
        }


        /// <summary>
        /// SysUser_Type表实体
        /// </summary>
        /// <param name="utid">ID</param>
        /// <param name="uid">用户ID</param>
        /// <param name="stype">类型</param>
        public SysUser_TypeEntity(int utid, string uid, int stype)
        {
            this.UTID = utid;
            this.UID = uid;
            this.SType = stype;
        }

        private int utid;//ID
        private string uid;//用户ID
        private int stype;//类型


        ///<summary>
        ///ID
        ///</summary>
        public int UTID
        {
            get
            {
                return utid;
            }
            set
            {
                utid = value;
            }
        }

        ///<summary>
        ///用户ID
        ///</summary>
        public string UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        ///<summary>
        ///类型
        ///</summary>
        public int SType
        {
            get
            {
                return stype;
            }
            set
            {
                stype = value;
            }
        }
    }
}

