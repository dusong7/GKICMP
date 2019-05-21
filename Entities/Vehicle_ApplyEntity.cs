/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月22日 10点17分
** 描   述:      车辆申请实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Vehicle_ApplyEntity
    {

        /// <summary>
        /// Vehicle_Apply表实体
        ///</summary>
        public Vehicle_ApplyEntity()
        {
        }


        /// <summary>
        /// Vehicle_Apply表实体
        /// </summary>
        /// <param name="applyid">申请ID</param>
        /// <param name="vhid">车辆ID</param>
        /// <param name="applyuser">申请人</param>
        /// <param name="applydate">申请日期</param>
        /// <param name="beginaddress">出车地点</param>
        /// <param name="endaddress">目的地</param>
        /// <param name="applydesc">用车事由</param>
        /// <param name="begindate">用车开始时间</param>
        /// <param name="enddate">用车结束时间</param>
        /// <param name="peercount">同行人数</param>
        /// <param name="vstate">状态</param>
        /// <param name="sysuid">司机</param>
        /// <param name="isdel">是否删除</param>
        public Vehicle_ApplyEntity(string applyid, int vhid, string applyuser, DateTime applydate, string beginaddress, string endaddress, string applydesc, DateTime begindate, DateTime enddate, int peercount, int vstate, string sysuid, int isdel)
        {
            this.ApplyID = applyid;
            this.VHID = vhid;
            this.ApplyUser = applyuser;
            this.ApplyDate = applydate;
            this.BeginAddress = beginaddress;
            this.EndAddress = endaddress;
            this.ApplyDesc = applydesc;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.PeerCount = peercount;
            this.VState = vstate;
            this.SysUid = sysuid;
            this.Isdel = isdel;
        }

        private string applyid;//申请ID
        private int vhid;//车辆ID
        private string applyuser;//申请人
        private DateTime applydate;//申请日期
        private string beginaddress;//出车地点
        private string endaddress;//目的地
        private string applydesc;//用车事由
        private DateTime begindate;//用车开始时间
        private DateTime enddate;//用车结束时间
        private int peercount;//同行人数
        private int vstate;//状态
        private string sysuid;//司机
        private int isdel;//是否删除
        private string applyUserName;
        private int dID;

        public int DID
        {
            get { return dID; }
            set { dID = value; }
        }

        public string ApplyUserName
        {
            get { return applyUserName; }
            set { applyUserName = value; }
        }


        ///<summary>
        ///申请ID
        ///</summary>
        public string ApplyID
        {
            get
            {
                return applyid;
            }
            set
            {
                applyid = value;
            }
        }

        ///<summary>
        ///车辆ID
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
        ///申请人
        ///</summary>
        public string ApplyUser
        {
            get
            {
                return applyuser;
            }
            set
            {
                applyuser = value;
            }
        }

        ///<summary>
        ///申请日期
        ///</summary>
        public DateTime ApplyDate
        {
            get
            {
                return applydate;
            }
            set
            {
                applydate = value;
            }
        }

        ///<summary>
        ///出车地点
        ///</summary>
        public string BeginAddress
        {
            get
            {
                return beginaddress;
            }
            set
            {
                beginaddress = value;
            }
        }

        ///<summary>
        ///目的地
        ///</summary>
        public string EndAddress
        {
            get
            {
                return endaddress;
            }
            set
            {
                endaddress = value;
            }
        }

        ///<summary>
        ///用车事由
        ///</summary>
        public string ApplyDesc
        {
            get
            {
                return applydesc;
            }
            set
            {
                applydesc = value;
            }
        }

        ///<summary>
        ///用车开始时间
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
        ///用车结束时间
        ///</summary>
        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
            }
        }

        ///<summary>
        ///同行人数
        ///</summary>
        public int PeerCount
        {
            get
            {
                return peercount;
            }
            set
            {
                peercount = value;
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
        ///司机
        ///</summary>
        public string SysUid
        {
            get
            {
                return sysuid;
            }
            set
            {
                sysuid = value;
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

