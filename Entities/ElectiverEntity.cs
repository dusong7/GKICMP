/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月03日 08点41分
** 描   述:      选课任务实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ElectiverEntity
    {

        /// <summary>
        /// Electiver表实体
        ///</summary>
        public ElectiverEntity()
        {
        }


        /// <summary>
        /// Electiver表实体
        /// </summary>  
        /// <param name="electivername">任务名称</param>     
        /// <param name="eyear">学年度</param>
        /// <param name="termid">学期</param>
        public ElectiverEntity(string electivername,  string eyear, int termid)
        {
            this.ElectiverName = electivername;
            this.EYear = eyear;
            this.TermID = termid;
        }

        private int eleid;//任务ID
        private string electivername;//任务名称
        private DateTime ebegin;//报名开始时间
        private DateTime eend;//报名结束时间
        private string createuser;//创建人
        private DateTime createdate;//创建时间
        private string eyear;//学年度
        private int termid;//学期
        private DateTime estimatebdate;//预选开始日期
        private DateTime estimateedate;//预选结束日期
        private int estate;//0：未发布；1：未开始    2：预选阶段：3：选课阶段   4：结束
        private DateTime estopdate;//任务结束时间

        public string CreateUserName { get; set; }
        /// <summary>
        /// 限制门数
        /// </summary>
        public int Ecount { get; set; }
        /// <summary>
        /// 限制门数
        /// </summary>
        public int EIsAudit { get; set; }
        /// <summary>
        /// 是否需要预选
        /// </summary>
        public int IsEstmate{ get; set; }
        /// <summary>
        /// 是否关联
        /// </summary>
        public int IsRelation { get; set; }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EStopDate
        {
            get { return estopdate; }
            set { estopdate = value; }
        }


        ///<summary>
        ///任务ID
        ///</summary>
        public int EleID
        {
            get
            {
                return eleid;
            }
            set
            {
                eleid = value;
            }
        }

        ///<summary>
        ///任务名称
        ///</summary>
        public string ElectiverName
        {
            get
            {
                return electivername;
            }
            set
            {
                electivername = value;
            }
        }

        ///<summary>
        ///报名开始时间
        ///</summary>
        public DateTime EBegin
        {
            get
            {
                return ebegin;
            }
            set
            {
                ebegin = value;
            }
        }

        ///<summary>
        ///报名结束时间
        ///</summary>
        public DateTime EEnd
        {
            get
            {
                return eend;
            }
            set
            {
                eend = value;
            }
        }

        ///<summary>
        ///创建人
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
        ///创建时间
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
        ///学年度
        ///</summary>
        public string EYear
        {
            get
            {
                return eyear;
            }
            set
            {
                eyear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int TermID
        {
            get
            {
                return termid;
            }
            set
            {
                termid = value;
            }
        }

        ///<summary>
        ///预选开始日期
        ///</summary>
        public DateTime EstimateBDate
        {
            get
            {
                return estimatebdate;
            }
            set
            {
                estimatebdate = value;
            }
        }

        ///<summary>
        ///预选结束日期
        ///</summary>
        public DateTime EstimateEDate
        {
            get
            {
                return estimateedate;
            }
            set
            {
                estimateedate = value;
            }
        }

        ///<summary>
        ///0：未发布；1：未开始    2：预选阶段：3：选课阶段   4：结束
        ///</summary>
        public int EState
        {
            get
            {
                return estate;
            }
            set
            {
                estate = value;
            }
        }
    }
}

