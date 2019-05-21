/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月04日 08点55分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class BuildApplyEntity
    {

        /// <summary>
        /// BuildApply表实体
        ///</summary>
        public BuildApplyEntity()
        {
        }


        /// <summary>
        /// BuildApply表实体
        /// </summary>
        /// <param name="baid">申请ID</param>
        /// <param name="proname">项目名称</param>
        /// <param name="applydep">申报单位</param>
        /// <param name="applydate">时间</param>
        /// <param name="buildaddr"></param>
        /// <param name="buildcontent">建设内容</param>
        /// <param name="buildnature">建设性质</param>
        /// <param name="acreage">建筑面积</param>
        /// <param name="layers">层数</param>
        /// <param name="structure">结构</param>
        /// <param name="budgetamount">预算金额</param>
        /// <param name="bsources">资金来源</param>
        /// <param name="dutyuser">项目责任人</param>
        /// <param name="dutyno">项目负责人电话</param>
        /// <param name="depuser">单位负责人</param>
        /// <param name="depno">单位负责人电话</param>
        /// <param name="buildreason">建设理由</param>
        /// <param name="applyuser">申请人</param>
        /// <param name="arrangement">资金落实情况</param>
        /// <param name="bdesc">备注</param>
        /// <param name="astate">状态</param>
        public BuildApplyEntity(string baid, string proname, string applydep, DateTime applydate, string buildaddr, string buildcontent, int buildnature, decimal acreage, int layers, string structure, decimal budgetamount, int bsources, string dutyuser, string dutyno, string depuser, string depno, string buildreason, string applyuser, string arrangement, string bdesc, int astate)
        {
            this.BAID = baid;
            this.ProName = proname;
            this.ApplyDep = applydep;
            this.ApplyDate = applydate;
            this.BuildAddr = buildaddr;
            this.BuildContent = buildcontent;
            this.BuildNature = buildnature;
            this.Acreage = acreage;
            this.Layers = layers;
            this.Structure = structure;
            this.BudgetAmount = budgetamount;
            this.BSources = bsources;
            this.DutyUser = dutyuser;
            this.DutyNO = dutyno;
            this.DepUser = depuser;
            this.DepNO = depno;
            this.BuildReason = buildreason;
            this.ApplyUser = applyuser;
            this.Arrangement = arrangement;
            this.BDesc = bdesc;
            this.AState = astate;
        }

        private string baid;//申请ID
        private string proname;//项目名称
        private string applydep;//申报单位
        private DateTime applydate;//时间
        private string buildaddr;//
        private string buildcontent;//建设内容
        private int buildnature;//建设性质
        private decimal acreage;//建筑面积
        private int layers;//层数
        private string structure;//结构
        private decimal budgetamount;//预算金额
        private int bsources;//资金来源
        private string dutyuser;//项目责任人
        private string dutyno;//项目负责人电话
        private string depuser;//单位负责人
        private string depno;//单位负责人电话
        private string buildreason;//建设理由
        private string applyuser;//申请人
        private string arrangement;//资金落实情况
        private string bdesc;//备注
        private int astate;//状态
        private int isreport;
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
        ///<summary>
        ///申请ID
        ///</summary>
        public string BAID
        {
            get
            {
                return baid;
            }
            set
            {
                baid = value;
            }
        }

        ///<summary>
        ///项目名称
        ///</summary>
        public string ProName
        {
            get
            {
                return proname;
            }
            set
            {
                proname = value;
            }
        }

        ///<summary>
        ///申报单位
        ///</summary>
        public string ApplyDep
        {
            get
            {
                return applydep;
            }
            set
            {
                applydep = value;
            }
        }

        ///<summary>
        ///时间
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
        ///
        ///</summary>
        public string BuildAddr
        {
            get
            {
                return buildaddr;
            }
            set
            {
                buildaddr = value;
            }
        }

        ///<summary>
        ///建设内容
        ///</summary>
        public string BuildContent
        {
            get
            {
                return buildcontent;
            }
            set
            {
                buildcontent = value;
            }
        }

        ///<summary>
        ///建设性质
        ///</summary>
        public int BuildNature
        {
            get
            {
                return buildnature;
            }
            set
            {
                buildnature = value;
            }
        }

        ///<summary>
        ///建筑面积
        ///</summary>
        public decimal Acreage
        {
            get
            {
                return acreage;
            }
            set
            {
                acreage = value;
            }
        }

        ///<summary>
        ///层数
        ///</summary>
        public int Layers
        {
            get
            {
                return layers;
            }
            set
            {
                layers = value;
            }
        }

        ///<summary>
        ///结构
        ///</summary>
        public string Structure
        {
            get
            {
                return structure;
            }
            set
            {
                structure = value;
            }
        }

        ///<summary>
        ///预算金额
        ///</summary>
        public decimal BudgetAmount
        {
            get
            {
                return budgetamount;
            }
            set
            {
                budgetamount = value;
            }
        }

        ///<summary>
        ///资金来源
        ///</summary>
        public int BSources
        {
            get
            {
                return bsources;
            }
            set
            {
                bsources = value;
            }
        }

        ///<summary>
        ///项目责任人
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
        ///项目负责人电话
        ///</summary>
        public string DutyNO
        {
            get
            {
                return dutyno;
            }
            set
            {
                dutyno = value;
            }
        }

        ///<summary>
        ///单位负责人
        ///</summary>
        public string DepUser
        {
            get
            {
                return depuser;
            }
            set
            {
                depuser = value;
            }
        }

        ///<summary>
        ///单位负责人电话
        ///</summary>
        public string DepNO
        {
            get
            {
                return depno;
            }
            set
            {
                depno = value;
            }
        }

        ///<summary>
        ///建设理由
        ///</summary>
        public string BuildReason
        {
            get
            {
                return buildreason;
            }
            set
            {
                buildreason = value;
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
        ///资金落实情况
        ///</summary>
        public string Arrangement
        {
            get
            {
                return arrangement;
            }
            set
            {
                arrangement = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string BDesc
        {
            get
            {
                return bdesc;
            }
            set
            {
                bdesc = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int AState
        {
            get
            {
                return astate;
            }
            set
            {
                astate = value;
            }
        }
    }
}

