/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月19日 02点47分
** 描   述:      校区实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class CampusEntity
    {

        /// <summary>
        /// Campus表实体
        ///</summary>
        public CampusEntity()
        {
        }


        /// <summary>
        /// Campus表实体
        /// </summary>
        /// <param name="cid">校区ID</param>
        /// <param name="campusname">校区名称</param>
        /// <param name="buttoncode">校区地址</param>
        /// <param name="linknum">校区联系电话</param>
        /// <param name="dutyuser">校区负责人</param>
        /// <param name="areasize">校区面积</param>
        /// <param name="builtupaea">校区建筑面积</param>
        /// <param name="equipmentvalue">校区教学科研仪器设备总值</param>
        /// <param name="fixedassets">校区固定资产总值</param>
        /// <param name="begindate">正式使用日期</param>
        /// <param name="isdel">是否删除</param>
        public CampusEntity(int cid, string campusname, string buttoncode, string linknum, string dutyuser, decimal areasize, decimal builtupaea, decimal equipmentvalue, decimal fixedassets, DateTime begindate, int isdel)
        {
            this.CID = cid;
            this.CampusName = campusname;
            this.ButtonCode = buttoncode;
            this.LinkNum = linknum;
            this.DutyUser = dutyuser;
            this.AreaSize = areasize;
            this.BuiltupAea = builtupaea;
            this.EquipmentValue = equipmentvalue;
            this.FixedAssets = fixedassets;
            this.BeginDate = begindate;
            this.Isdel = isdel;
        }

        private int cid;//校区ID
        private string campusname;//校区名称
        private string buttoncode;//校区地址
        private string linknum;//校区联系电话
        private string dutyuser;//校区负责人
        private decimal areasize;//校区面积
        private decimal builtupaea;//校区建筑面积
        private decimal equipmentvalue;//校区教学科研仪器设备总值
        private decimal fixedassets;//校区固定资产总值
        private DateTime begindate;//正式使用日期
        private int isdel;//是否删除


        ///<summary>
        ///校区ID
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
        ///校区名称
        ///</summary>
        public string CampusName
        {
            get
            {
                return campusname;
            }
            set
            {
                campusname = value;
            }
        }

        ///<summary>
        ///校区地址
        ///</summary>
        public string ButtonCode
        {
            get
            {
                return buttoncode;
            }
            set
            {
                buttoncode = value;
            }
        }

        ///<summary>
        ///校区联系电话
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
        ///校区负责人
        ///</summary>
        public string DutyUser
        {
            get
            {
                return dutyuser;
            }
            set
            {
                dutyuser = value;
            }
        }

        ///<summary>
        ///校区面积
        ///</summary>
        public decimal AreaSize
        {
            get
            {
                return areasize;
            }
            set
            {
                areasize = value;
            }
        }

        ///<summary>
        ///校区建筑面积
        ///</summary>
        public decimal BuiltupAea
        {
            get
            {
                return builtupaea;
            }
            set
            {
                builtupaea = value;
            }
        }

        ///<summary>
        ///校区教学科研仪器设备总值
        ///</summary>
        public decimal EquipmentValue
        {
            get
            {
                return equipmentvalue;
            }
            set
            {
                equipmentvalue = value;
            }
        }

        ///<summary>
        ///校区固定资产总值
        ///</summary>
        public decimal FixedAssets
        {
            get
            {
                return fixedassets;
            }
            set
            {
                fixedassets = value;
            }
        }

        ///<summary>
        ///正式使用日期
        ///</summary>
        public DateTime BeginDate
        {
            get
            {
                return begindate;
            }
            set
            {
                begindate = value;
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

