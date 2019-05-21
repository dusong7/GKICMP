/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09点30分
** 描   述:      附件实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class AccessoryEntity
    {

        /// <summary>
        /// Accessory表实体
        ///</summary>
        public AccessoryEntity()
        {
            this.AccessName = "";
            this.AccessUrl = "";
            this.ObjID = "";
        }


        /// <summary>
        /// Accessory表实体
        /// </summary>
        /// <param name="accessid">编号</param>
        /// <param name="accessname">附件名称</param>
        /// <param name="accessurl">附件路劲</param>
        /// <param name="accessobjid">对象ID</param>
        /// <param name="accessflag">标志 1：Tb_Web_Slide</param>
        /// <param name="objid">预留ID</param>
        public AccessoryEntity(string accessname, string accessurl)
        {

            this.AccessName = accessname;
            this.AccessUrl = accessurl;
        }

        private string accessid;//编号
        private string accessname;//附件名称
        private string accessurl;//附件路劲
        private string accessobjid;//对象ID
        private int accessflag;//标志 1：发票
        private string objid;//预留ID
        private int aorder;//排序

        public decimal Size { get; set; }



        ///<summary>
        ///编号
        ///</summary>
        public string AccessID
        {
            get
            {
                return accessid;
            }
            set
            {
                accessid = value;
            }
        }

        ///<summary>
        ///附件名称
        ///</summary>
        public string AccessName
        {
            get
            {
                return accessname;
            }
            set
            {
                accessname = value;
            }
        }

        ///<summary>
        ///附件路劲
        ///</summary>
        public string AccessUrl
        {
            get
            {
                return accessurl;
            }
            set
            {
                accessurl = value;
            }
        }

        ///<summary>
        ///对象ID
        ///</summary>
        public string AccessObjID
        {
            get
            {
                return accessobjid;
            }
            set
            {
                accessobjid = value;
            }
        }

        ///<summary>
        ///标志 1：Tb_Web_Slide
        ///</summary>
        public int AccessFlag
        {
            get
            {
                return accessflag;
            }
            set
            {
                accessflag = value;
            }
        }

        ///<summary>
        ///预留ID
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



        /// <summary>
        /// 排序
        /// </summary>
        public int AOrder
        {
            get { return aorder; }
            set { aorder = value; }
        }
    }
}
