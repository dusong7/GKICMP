/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月23日 08点06分
** 描   述:      车辆审核实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Vehicle_AduitEntity
    {

        /// <summary>
        /// Vehicle_Aduit表实体
        ///</summary>
        public Vehicle_AduitEntity()
        {
        }


        /// <summary>
        /// Vehicle_Aduit表实体
        /// </summary>
        /// <param name="aid">审核ID</param>
        /// <param name="applyid">申请ID</param>
        /// <param name="aduituser">审核人</param>
        /// <param name="aduitmess">审核意见</param>
        /// <param name="aduitdate">审核时间</param>
        public Vehicle_AduitEntity(string aid, string applyid, string aduituser, string aduitmess, DateTime aduitdate)
        {
            this.AID = aid;
            this.ApplyID = applyid;
            this.AduitUser = aduituser;
            this.AduitMess = aduitmess;
            this.AduitDate = aduitdate;
        }

        private string aid;//审核ID
        private string applyid;//申请ID
        private string aduituser;//审核人
        private string aduitmess;//审核意见
        private DateTime aduitdate;//审核时间
        private string aduitUserName;

        public string AduitUserName
        {
            get { return aduitUserName; }
            set { aduitUserName = value; }
        }

        ///<summary>
        ///审核ID
        ///</summary>
        public string AID
        {
            get
            {
                return aid;
            }
            set
            {
                aid = value;
            }
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
        ///审核人
        ///</summary>
        public string AduitUser
        {
            get
            {
                return aduituser;
            }
            set
            {
                aduituser = value;
            }
        }

        ///<summary>
        ///审核意见
        ///</summary>
        public string AduitMess
        {
            get
            {
                return aduitmess;
            }
            set
            {
                aduitmess = value;
            }
        }

        ///<summary>
        ///审核时间
        ///</summary>
        public DateTime AduitDate
        {
            get
            {
                return aduitdate;
            }
            set
            {
                aduitdate = value;
            }
        }
    }
}

