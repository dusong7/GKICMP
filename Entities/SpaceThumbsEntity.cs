/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年08月31日 02点21分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SpaceThumbsEntity
    {

        /// <summary>
        /// SpaceThumbs表实体
        ///</summary>
        public SpaceThumbsEntity()
        {
        }


        /// <summary>
        /// SpaceThumbs表实体
        /// </summary>
        /// <param name="stid">点赞ID</param>
        /// <param name="sysid">用户ID</param>
        /// <param name="tflag">FLAG</param>
        /// <param name="objid">对象</param>
        public SpaceThumbsEntity(int stid, string sysid, int tflag, string objid)
        {
            this.STID = stid;
            this.SysID = sysid;
            this.TFlag = tflag;
            this.ObjID = objid;
        }

        private int stid;//点赞ID
        private string sysid;//用户ID
        private int tflag;//FLAG
        private string objid;//对象


        ///<summary>
        ///点赞ID
        ///</summary>
        public int STID
        {
            get
            {
                return stid;
            }
            set
            {
                stid = value;
            }
        }

        ///<summary>
        ///用户ID
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

        ///<summary>
        ///FLAG
        ///</summary>
        public int TFlag
        {
            get
            {
                return tflag;
            }
            set
            {
                tflag = value;
            }
        }

        ///<summary>
        ///对象
        ///</summary>
        public string ObjID
        {
            get
            {
                return objid;
            }
            set
            {
                objid = value;
            }
        }
    }
}

