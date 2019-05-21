/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月20日 08点37分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Project_CheckEntity
    {

        /// <summary>
        /// Project_Check表实体
        ///</summary>
        public Project_CheckEntity()
        {
        }


        /// <summary>
        /// Project_Check表实体
        /// </summary>
        /// <param name="pcid"></param>
        /// <param name="pid">项目id</param>
        /// <param name="brandchecked">品牌产地是否正确</param>
        /// <param name="specificationchecked">规格型号是否正确</param>
        /// <param name="configchecked">配置是否正确</param>
        /// <param name="countchecked">数量是否正确</param>
        /// <param name="debuggingchecked">安装调试是否正常</param>
        /// <param name="guaranteechecked">是否有保修卡</param>
        /// <param name="packingchecked">是否包装完好</param>
        /// <param name="contractchecked">是否签订合同</param>
        /// <param name="evaluate">综合评价</param>
        /// <param name="opinion">验收意见</param>
        /// <param name="createdate">验收申请时间</param>
        /// <param name="pcdate">验收时间</param>
        /// <param name="createuser">验收人</param>
        /// <param name="pcfile">验收单附件</param>
        /// <param name="isreport">是否上报</param>
        public Project_CheckEntity(string pcid, string pid, int brandchecked, int specificationchecked, int configchecked, int countchecked, int debuggingchecked, int guaranteechecked, int packingchecked, int contractchecked, int evaluate, string opinion, DateTime createdate, DateTime pcdate, string createuser, string pcfile, int isreport)
        {
            this.PCID = pcid;
            this.PID = pid;
            this.BrandChecked = brandchecked;
            this.SpecificationChecked = specificationchecked;
            this.ConfigChecked = configchecked;
            this.CountChecked = countchecked;
            this.DebuggingChecked = debuggingchecked;
            this.GuaranteeChecked = guaranteechecked;
            this.PackingChecked = packingchecked;
            this.ContractChecked = contractchecked;
            this.Evaluate = evaluate;
            this.Opinion = opinion;
            this.CreateDate = createdate;
            this.PCDate = pcdate;
            this.CreateUser = createuser;
            this.PCFile = pcfile;
            this.IsReport = isreport;
        }

        private string pcid;//
        private string pid;//项目id
        private int brandchecked;//品牌产地是否正确
        private int specificationchecked;//规格型号是否正确
        private int configchecked;//配置是否正确
        private int countchecked;//数量是否正确
        private int debuggingchecked;//安装调试是否正常
        private int guaranteechecked;//是否有保修卡
        private int packingchecked;//是否包装完好
        private int contractchecked;//是否签订合同
        private int evaluate;//综合评价
        private string opinion;//验收意见
        private DateTime createdate;//验收申请时间
        private DateTime pcdate;//验收时间
        private string createuser;//验收人
        private string pcfile;//验收单附件
        private int isreport;//是否上报
        private string pname;
        public string CreateUserName { get; set; }
        public string PName
        {
            get
            {
                return pname;
            }
            set
            {
                pname = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string PCID
        {
            get
            {
                return pcid;
            }
            set
            {
                pcid = value;
            }
        }

        ///<summary>
        ///项目id
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
        ///品牌产地是否正确
        ///</summary>
        public int BrandChecked
        {
            get
            {
                return brandchecked;
            }
            set
            {
                brandchecked = value;
            }
        }

        ///<summary>
        ///规格型号是否正确
        ///</summary>
        public int SpecificationChecked
        {
            get
            {
                return specificationchecked;
            }
            set
            {
                specificationchecked = value;
            }
        }

        ///<summary>
        ///配置是否正确
        ///</summary>
        public int ConfigChecked
        {
            get
            {
                return configchecked;
            }
            set
            {
                configchecked = value;
            }
        }

        ///<summary>
        ///数量是否正确
        ///</summary>
        public int CountChecked
        {
            get
            {
                return countchecked;
            }
            set
            {
                countchecked = value;
            }
        }

        ///<summary>
        ///安装调试是否正常
        ///</summary>
        public int DebuggingChecked
        {
            get
            {
                return debuggingchecked;
            }
            set
            {
                debuggingchecked = value;
            }
        }

        ///<summary>
        ///是否有保修卡
        ///</summary>
        public int GuaranteeChecked
        {
            get
            {
                return guaranteechecked;
            }
            set
            {
                guaranteechecked = value;
            }
        }

        ///<summary>
        ///是否包装完好
        ///</summary>
        public int PackingChecked
        {
            get
            {
                return packingchecked;
            }
            set
            {
                packingchecked = value;
            }
        }

        ///<summary>
        ///是否签订合同
        ///</summary>
        public int ContractChecked
        {
            get
            {
                return contractchecked;
            }
            set
            {
                contractchecked = value;
            }
        }

        ///<summary>
        ///综合评价
        ///</summary>
        public int Evaluate
        {
            get
            {
                return evaluate;
            }
            set
            {
                evaluate = value;
            }
        }

        ///<summary>
        ///验收意见
        ///</summary>
        public string Opinion
        {
            get
            {
                return opinion;
            }
            set
            {
                opinion = value;
            }
        }

        ///<summary>
        ///验收申请时间
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
        ///验收时间
        ///</summary>
        public DateTime PCDate
        {
            get
            {
                return pcdate;
            }
            set
            {
                pcdate = value;
            }
        }

        ///<summary>
        ///验收人
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
        ///验收单附件
        ///</summary>
        public string PCFile
        {
            get
            {
                return pcfile;
            }
            set
            {
                pcfile = value;
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

