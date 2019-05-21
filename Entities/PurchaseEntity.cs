/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2018年01月02日 01点40分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PurchaseEntity
    {

        /// <summary>
        /// Purchase表实体
        ///</summary>
        public PurchaseEntity()
        {
        }

        public PurchaseEntity(string name)
        {
            this.PTitle = name;
        }

        /// <summary>
        /// Purchase表实体
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="ptitle"></param>
        /// <param name="pestimate">概算</param>
        /// <param name="pdesc">备注</param>
        /// <param name="createdate"></param>
        /// <param name="createuser"></param>
        /// <param name="isdel"></param>
        /// <param name="pstate">审核状态</param>
        /// <param name="psdate">审核时间</param>
        /// <param name="psuser"></param>
        /// <param name="isreport">是否上报</param>
        public PurchaseEntity(string pid, string ptitle, decimal pestimate, string pdesc, DateTime createdate, string createuser, int isdel, int pstate, DateTime psdate, string psuser, int isreport)
        {
            this.PID = pid;
            this.PTitle = ptitle;
            this.PEstimate = pestimate;
            this.PDesc = pdesc;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.Isdel = isdel;
            this.PState = pstate;
            this.PSDate = psdate;
            this.PSUser = psuser;
            this.IsReport = isreport;
        }

        private string pid;//
        private string ptitle;//
        private decimal pestimate;//概算
        private string pdesc;//备注
        private DateTime createdate;//
        private string createuser;//
        private int isdel;//
        private int pstate;//审核状态
        private DateTime psdate;//审核时间
        private string psuser;//
        private int isreport;//是否上报
        public int IsChecked { get; set; }
        public int PType { get; set; }
        public DateTime PLDate { get; set; }
        public string CreateUserName { get; set; }
        public int PLState { get; set; }
        public string PTypeName { get; set; }
        ///<summary>
        ///
        ///</summary>
        public string PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string PTitle
        {
            get
            {
                return ptitle;
            }
            set
            {
                ptitle = value;
            }
        }

        ///<summary>
        ///概算
        ///</summary>
        public decimal PEstimate
        {
            get
            {
                return pestimate;
            }
            set
            {
                pestimate = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string PDesc
        {
            get
            {
                return pdesc;
            }
            set
            {
                pdesc = value;
            }
        }

        ///<summary>
        ///
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
        ///
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
        ///
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

        ///<summary>
        ///审核状态
        ///</summary>
        public int PState
        {
            get
            {
                return pstate;
            }
            set
            {
                pstate = value;
            }
        }

        ///<summary>
        ///审核时间
        ///</summary>
        public DateTime PSDate
        {
            get
            {
                return psdate;
            }
            set
            {
                psdate = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string PSUser
        {
            get
            {
                return psuser;
            }
            set
            {
                psuser = value;
            }
        }

        ///<summary>
        ///是否上报
        ///</summary>
        public int IsReport
        {
            get
            {
                return isreport;
            }
            set
            {
                isreport = value;
            }
        }
    }
}

