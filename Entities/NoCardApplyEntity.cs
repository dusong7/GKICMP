/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2018年09月11日 09点58分
** 描   述:      补卡申请实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class NoCardApplyEntity
    {

        /// <summary>
        /// NoCardApply表实体
        ///</summary>
        public NoCardApplyEntity()
        {
        }


        /// <summary>
        /// NoCardApply表实体
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="nocardapplyuser">补卡申请人</param>
        /// <param name="nocardapplydate">补卡申请日期</param>
        /// <param name="nocardstate">补卡申请状态</param>
        /// <param name="nocardapplydesc">补卡申请说明</param>
        /// <param name="nocardaudituser">补卡审核人</param>
        /// <param name="nocardauditdate">补卡审核日期</param>
        /// <param name="nocardauditdesc">补卡审核说明</param>
        public NoCardApplyEntity(string id, string nocardapplyuser, DateTime nocardapplydate, int nocardstate, string nocardapplydesc, string nocardaudituser, DateTime nocardauditdate, string nocardauditdesc)
        {
            this.ID = id;
            this.NoCardApplyUser = nocardapplyuser;
            this.NoCardApplyDate = nocardapplydate;
            this.NoCardState = nocardstate;
            this.NoCardApplyDesc = nocardapplydesc;
            this.NoCardAuditUser = nocardaudituser;
            this.NoCardAuditDate = nocardauditdate;
            this.NoCardAuditDesc = nocardauditdesc;
        }

        private string id;//ID
        private string nocardapplyuser;//补卡申请人
        private DateTime nocardapplydate;//补卡申请日期
        private int nocardstate;//补卡申请状态
        private string nocardapplydesc;//补卡申请说明
        private string nocardaudituser;//补卡审核人
        private DateTime nocardauditdate;//补卡审核日期
        private string nocardauditdesc;//补卡审核说明
        private string noCardApplyUserName;//补卡申请人
        private string noCardAuditUserName;//补卡审核人
        private DateTime createdate;//
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

        public string NoCardApplyUserName
        {
            get { return noCardApplyUserName; }
            set { noCardApplyUserName = value; }
        }

        public string NoCardAuditUserName
        {
            get { return noCardAuditUserName; }
            set { noCardAuditUserName = value; }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        ///<summary>
        ///补卡申请人
        ///</summary>
        public string NoCardApplyUser
        {
            get
            {
                return nocardapplyuser;
            }
            set
            {
                nocardapplyuser = value;
            }
        }

        ///<summary>
        ///补卡申请日期
        ///</summary>
        public DateTime NoCardApplyDate
        {
            get
            {
                return nocardapplydate;
            }
            set
            {
                nocardapplydate = value;
            }
        }

        ///<summary>
        ///补卡申请状态
        ///</summary>
        public int NoCardState
        {
            get
            {
                return nocardstate;
            }
            set
            {
                nocardstate = value;
            }
        }

        ///<summary>
        ///补卡申请说明
        ///</summary>
        public string NoCardApplyDesc
        {
            get
            {
                return nocardapplydesc;
            }
            set
            {
                nocardapplydesc = value;
            }
        }

        ///<summary>
        ///补卡审核人
        ///</summary>
        public string NoCardAuditUser
        {
            get
            {
                return nocardaudituser;
            }
            set
            {
                nocardaudituser = value;
            }
        }

        ///<summary>
        ///补卡审核日期
        ///</summary>
        public DateTime NoCardAuditDate
        {
            get
            {
                return nocardauditdate;
            }
            set
            {
                nocardauditdate = value;
            }
        }

        ///<summary>
        ///补卡审核说明
        ///</summary>
        public string NoCardAuditDesc
        {
            get
            {
                return nocardauditdesc;
            }
            set
            {
                nocardauditdesc = value;
            }
        }
    }
}

