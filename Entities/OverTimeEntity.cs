/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2018年04月08日 11点01分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class OverTimeEntity
    {

        /// <summary>
        /// OverTime表实体
        ///</summary>
        public OverTimeEntity()
        {
        }


        /// <summary>
        /// OverTime表实体
        /// </summary>
        /// <param name="oid">ID</param>
        /// <param name="applyuser">申请人</param>
        /// <param name="applydate">申请时间</param>
        /// <param name="odays">加班天数</param>
        /// <param name="begindate">加班开始时间</param>
        /// <param name="enddate">加班结束时间</param>
        /// <param name="otype">加班类型</param>
        /// <param name="omark">加班理由</param>
        /// <param name="ostate">状态</param>
        /// <param name="isdel">是否删除</param>
        public OverTimeEntity(string oid, string applyuser, DateTime applydate, int odays, DateTime begindate, DateTime enddate, int otype, string omark, int ostate, int isdel)
        {
            this.OID = oid;
            this.ApplyUser = applyuser;
            this.ApplyDate = applydate;
            this.ODays = odays;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.OType = otype;
            this.OMark = omark;
            this.OState = ostate;
            this.Isdel = isdel;
        }

        private string oid;//ID
        private string applyuser;//申请人
        private DateTime applydate;//申请时间
        private decimal odays;//加班天数
        private DateTime begindate;//加班开始时间
        private DateTime enddate;//加班结束时间
        private int otype;//加班类型
        private string omark;//加班理由
        private int ostate;//状态
        private int isdel;//是否删除
        public string ODay { get; set; }
        public string ApplyUserName { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string OTypeName { get; set; }
        /// <summary>
        /// 加班人员名称
        /// </summary>
        public string UsersName { get; set; }
        /// <summary>
        /// 加班人员ID
        /// </summary>
        public string UsersID { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public string OID
        {
            get
            {
                return oid;
            }
            set
            {
                oid = value;
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
        ///申请时间
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
        ///加班天数
        ///</summary>
        public decimal ODays
        {
            get
            {
                return odays;
            }
            set
            {
                odays = value;
            }
        }

        ///<summary>
        ///加班开始时间
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
        ///加班结束时间
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
        ///加班类型
        ///</summary>
        public int OType
        {
            get
            {
                return otype;
            }
            set
            {
                otype = value;
            }
        }

        ///<summary>
        ///加班理由
        ///</summary>
        public string OMark
        {
            get
            {
                return omark;
            }
            set
            {
                omark = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int OState
        {
            get
            {
                return ostate;
            }
            set
            {
                ostate = value;
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

