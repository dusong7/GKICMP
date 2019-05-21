/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月21日 02点48分
** 描   述:      车辆实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class VehicleEntity
    {

        /// <summary>
        /// Vehicle表实体
        ///</summary>
        public VehicleEntity()
        {
        }


        /// <summary>
        /// Vehicle表实体
        /// </summary>
        /// <param name="vhid">ID</param>
        /// <param name="vehiclename">车辆名称</param>
        /// <param name="vtype">车辆类型</param>
        /// <param name="cseatnum">座位数</param>
        /// <param name="vconfig">车辆配置</param>
        /// <param name="buydate">购置日期</param>
        /// <param name="vcash">购置金额</param>
        /// <param name="vdesc">备注</param>
        /// <param name="vstate">状态</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="isdel">是否删除</param>
        public VehicleEntity(int vhid, string vehiclename, int vtype, int cseatnum, string vconfig, DateTime buydate, decimal vcash, string vdesc, int vstate, string createuser, DateTime createdate, int isdel)
        {
            this.VHID = vhid;
            this.VehicleName = vehiclename;
            this.Vtype = vtype;
            this.CSeatNum = cseatnum;
            this.VConfig = vconfig;
            this.BuyDate = buydate;
            this.Vcash = vcash;
            this.VDesc = vdesc;
            this.VState = vstate;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private int vhid;//ID
        private string vehiclename;//车辆名称
        private int vtype;//车辆类型
        private int cseatnum;//座位数
        private string vconfig;//车辆配置
        private DateTime buydate;//购置日期
        private decimal vcash;//购置金额
        private string vdesc;//备注
        private int vstate;//状态
        private string createuser;//录入人
        private DateTime createdate;//录入日期
        private int isdel;//是否删除
        private string vehicleCode;  //车牌照
        private string vtypeName;

        public string VtypeName
        {
            get { return vtypeName; }
            set { vtypeName = value; }
        }

        public string VehicleCode
        {
            get { return vehicleCode; }
            set { vehicleCode = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public int VHID
        {
            get
            {
                return vhid;
            }
            set
            {
                vhid = value;
            }
        }

        ///<summary>
        ///车辆名称
        ///</summary>
        public string VehicleName
        {
            get
            {
                return vehiclename;
            }
            set
            {
                vehiclename = value;
            }
        }

        ///<summary>
        ///车辆类型
        ///</summary>
        public int Vtype
        {
            get
            {
                return vtype;
            }
            set
            {
                vtype = value;
            }
        }

        ///<summary>
        ///座位数
        ///</summary>
        public int CSeatNum
        {
            get
            {
                return cseatnum;
            }
            set
            {
                cseatnum = value;
            }
        }

        ///<summary>
        ///车辆配置
        ///</summary>
        public string VConfig
        {
            get
            {
                return vconfig;
            }
            set
            {
                vconfig = value;
            }
        }

        ///<summary>
        ///购置日期
        ///</summary>
        public DateTime BuyDate
        {
            get
            {
                return buydate;
            }
            set
            {
                buydate = value;
            }
        }

        ///<summary>
        ///购置金额
        ///</summary>
        public decimal Vcash
        {
            get
            {
                return vcash;
            }
            set
            {
                vcash = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string VDesc
        {
            get
            {
                return vdesc;
            }
            set
            {
                vdesc = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int VState
        {
            get
            {
                return vstate;
            }
            set
            {
                vstate = value;
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

