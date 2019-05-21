/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2016年12月24日 10点43分
** 描   述:      报修管理信息实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Asset_RepairEntity
    {

        /// <summary>
        /// Asset_Repair表实体
        ///</summary>
        public Asset_RepairEntity()
        {
        }


        /// <summary>
        /// Asset_Repair表实体
        /// </summary>
        /// <param name="arid">ID</param>
        /// <param name="aids">资产ID</param>
        /// <param name="repairobj">报修对象</param>
        /// <param name="repaircontent">故障描述</param>
        /// <param name="ardate">报修日期</param>
        /// <param name="createruser">报修人</param>
        /// <param name="dutydep">受理部门</param>
        /// <param name="dutyuser">受理人</param>
        /// <param name="compdesc">完成说明</param>
        /// <param name="compdate">完成时间</param>
        /// <param name="arstate">状态</param>
        /// <param name="isdel">是否删除</param>
        public Asset_RepairEntity(string arid, string aids, string repairobj, string repaircontent, DateTime ardate, string createruser, int dutydep, string dutyuser, string compdesc, DateTime compdate, int arstate, int isdel)
        {
            this.ARID = arid;
            this.AIDs = aids;
            this.RepairObj = repairobj;
            this.RepairContent = repaircontent;
            this.ARDate = ardate;
            this.CreaterUser = createruser;
            this.DutyDep = dutydep;
            this.DutyUser = dutyuser;
            this.CompDesc = compdesc;
            this.CompDate = compdate;
            this.ARState = arstate;
            this.Isdel = isdel;
        }

        private string arid;//ID
        private string aids;//资产ID
        private string repairobj;//报修对象
        private string repaircontent;//故障描述
        private DateTime ardate;//报修日期
        private string createruser;//报修人
        private int dutydep;//受理部门
        private string dutyuser;//受理人
        private string compdesc;//完成说明
        private DateTime compdate;//完成时间
        private int arstate;//状态
        private int isdel;//是否删除
        private string dutyUserName;//受理人
        public string ARFile { get; set; }
        public string SDID { get; set; }//供应商
        private string dutyDepName;
        private string createrusername;//报修人
        public string CreaterUserName { get; set; }
        /// <summary>
        /// 移交人
        /// </summary>
        public string TransferUser { get; set; }
        /// <summary>
        /// 移交人姓名
        /// </summary>
        public string TransferName { get; set; }
        /// <summary>
        /// 移交说明
        /// </summary>
        public string TransferDesc { get; set; }
        /// <summary>
        /// 移交时间
        /// </summary>
        public DateTime TransferDate { get; set; }

        public string DutyDepName
        {
            get { return dutyDepName; }
            set { dutyDepName = value; }
        }
        public string DutyUserName
        {
            get { return dutyUserName; }
            set { dutyUserName = value; }
        }
        /// <summary>
        /// 驳回意见
        /// </summary>
        public string AduitDesc { get; set; }

        ///<summary>
        ///ID
        ///</summary>
        public string ARID
        {
            get
            {
                return arid;
            }
            set
            {
                arid = value;
            }
        }

        ///<summary>
        ///资产ID
        ///</summary>
        public string AIDs
        {
            get
            {
                return aids;
            }
            set
            {
                aids = value;
            }
        }

        ///<summary>
        ///报修对象
        ///</summary>
        public string RepairObj
        {
            get
            {
                return repairobj;
            }
            set
            {
                repairobj = value;
            }
        }

        ///<summary>
        ///故障描述
        ///</summary>
        public string RepairContent
        {
            get
            {
                return repaircontent;
            }
            set
            {
                repaircontent = value;
            }
        }

        ///<summary>
        ///报修日期
        ///</summary>
        public DateTime ARDate
        {
            get
            {
                return ardate;
            }
            set
            {
                ardate = value;
            }
        }

        ///<summary>
        ///报修人
        ///</summary>
        public string CreaterUser
        {
            get
            {
                return createruser;
            }
            set
            {
                createruser = value;
            }
        }

        ///<summary>
        ///受理部门
        ///</summary>
        public int DutyDep
        {
            get
            {
                return dutydep;
            }
            set
            {
                dutydep = value;
            }
        }

        ///<summary>
        ///受理人
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
        ///完成说明
        ///</summary>
        public string CompDesc
        {
            get
            {
                return compdesc;
            }
            set
            {
                compdesc = value;
            }
        }

        ///<summary>
        ///完成时间
        ///</summary>
        public DateTime CompDate
        {
            get
            {
                return compdate;
            }
            set
            {
                compdate = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int ARState
        {
            get
            {
                return arstate;
            }
            set
            {
                arstate = value;
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

