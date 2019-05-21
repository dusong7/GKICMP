/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      俞桂宝
** 创建日期:      2017年11月10日 10点36分
** 描   述:      自由流审批提交流程类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class WF_CustomizedEntity
    {

        /// <summary>
        /// WF_Customized表实体
        ///</summary>
        public WF_CustomizedEntity()
        {
        }


        /// <summary>
        /// WF_Customized表实体
        /// </summary>
        /// <param name="fdvid">ID</param>
        /// <param name="wffid">流程ID</param>
        /// <param name="createuser">用户ID</param>
        /// <param name="cstate">状态</param>
        /// <param name="lastdate">最后修改状态时间</param>
        public WF_CustomizedEntity(string cid, string wffid, string createuser, int cstate, DateTime lastdate)
        {
            this.CID = cid;
            this.WFFID = wffid;
            this.CreateUser = createuser;
            this.CState = cstate;
            this.LastDate = lastdate;
        }

        private string cid;//ID
        private string wffid;//流程ID
        private string createuser;//用户ID
        private int cstate;//状态
        private DateTime createdate; //创建日期
        private DateTime lastdate;//最后修改状态时间
        private int faid;//审核位置

        ///<summary>
        ///ID
        ///</summary>
        public string CID
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
        ///审核位置
        ///</summary>
        public int FAID
        {
            get
            {
                return faid;
            }
            set
            {
                faid = value;
            }
        }


        ///<summary>
        ///流程ID
        ///</summary>
        public string WFFID
        {
            get
            {
                return wffid;
            }
            set
            {
                wffid = value;
            }
        }

        ///<summary>
        ///用户ID
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
        ///状态
        ///</summary>
        public int CState
        {
            get
            {
                return cstate;
            }
            set
            {
                cstate = value;
            }
        }


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
        ///最后修改状态时间
        ///</summary>
        public DateTime LastDate
        {
            get
            {
                return lastdate;
            }
            set
            {
                lastdate = value;
            }
        }
    }
}

