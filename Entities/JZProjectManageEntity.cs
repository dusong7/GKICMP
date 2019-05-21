/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年04月26日 03点29分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    [Serializable]
    public class JZProjectManageEntity
    {

        /// <summary>
        /// JZProjectManage表实体
        ///</summary>
        public JZProjectManageEntity()
        {
        }


        /// <summary>
        /// JZProjectManage表实体
        /// </summary>
        /// <param name="pid">项目ID</param>
        /// <param name="proname">项目名称</param>
        /// <param name="procode">项目编号</param>
        /// <param name="probudget">概算</param>
        /// <param name="financed">资金来源</param>
        /// <param name="depperson">单位负责人</param>
        /// <param name="deplinkno">单位联系电话</param>
        /// <param name="amount">数量</param>
        /// <param name="protype">类型</param>
        /// <param name="procontent">内容</param>
        /// <param name="state">审核状态</param>
        /// <param name="prodate">申报日期</param>
        /// <param name="changedate">修改日期</param>
        /// <param name="createuser">申报人</param>
        /// <param name="changeuser">修改人</param>
        /// <param name="isdel">是否删除</param>
        /// <param name="buildaddr">施工地点</param>
        /// <param name="prodesc">备注</param>
        /// <param name="type">默认代建0，1为自建</param>
        /// <param name="ptype">是否汇报，1为是，0否（默认否）</param>
        public JZProjectManageEntity(string pid, string proname, string procode, decimal probudget, int financed, string depperson, string deplinkno, int amount, int protype, string procontent, int state, DateTime prodate, DateTime changedate, string createuser, string changeuser, int isdel, string buildaddr, string prodesc, int type, int ptype)
        {
            this.PID = pid;
            this.ProName = proname;
            this.ProCode = procode;
            this.ProBudget = probudget;
            this.Financed = financed;
            this.DepPerson = depperson;
            this.DepLinkno = deplinkno;
            this.Amount = amount;
            this.ProType = protype;
            this.ProContent = procontent;
            this.State = state;
            this.ProDate = prodate;
            this.ChangeDate = changedate;
            this.CreateUser = createuser;
            this.ChangeUser = changeuser;
            this.Isdel = isdel;
            this.BuildAddr = buildaddr;
            this.ProDesc = prodesc;
            this.Type = type;
            this.PType = ptype;
        }

        private string pid;//项目ID
        private string proname;//项目名称
        private string procode;//项目编号
        private decimal probudget;//概算
        private int financed;//资金来源
        private string depperson;//单位负责人
        private string deplinkno;//单位联系电话
        private int amount;//数量
        private int protype;//类型
        private string protypename;//类型名称
        private string procontent;//内容
        private string procontentname;//内容名称
        private int state;//审核状态
        private DateTime prodate;//申报日期
        private DateTime changedate;//修改日期
        private string createuser;//申报人
        private string createusername;//申报人
        private string changeuser;//修改人
        private int isdel;//是否删除
        private string buildaddr;//施工地点
        private string prodesc;//备注
        private int type;//默认代建0，1为自建
        private int ptype;//是否汇报，1为是，0否（默认否）
        private decimal proArea;//建设面积
        private string pcfile;//附件
        public string PCFile { get { return pcfile; } set { pcfile = value; } }
        public decimal ProArea { get { return proArea; } set { proArea = value; } }
        public string ProContentName { get { return procontentname; } set { procontentname = value; } }
        public string ProTypeName { get { return protypename; } set { protypename = value; } }

        ///<summary>
        ///项目ID
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
        ///项目编号
        ///</summary>
        public string ProCode
        {
            get
            {
                return procode;
            }
            set
            {
                procode = value;
            }
        }

        ///<summary>
        ///概算
        ///</summary>
        public decimal ProBudget
        {
            get
            {
                return probudget;
            }
            set
            {
                probudget = value;
            }
        }

        ///<summary>
        ///资金来源
        ///</summary>
        public int Financed
        {
            get
            {
                return financed;
            }
            set
            {
                financed = value;
            }
        }

        ///<summary>
        ///单位负责人
        ///</summary>
        public string DepPerson
        {
            get
            {
                return depperson;
            }
            set
            {
                depperson = value;
            }
        }

        ///<summary>
        ///单位联系电话
        ///</summary>
        public string DepLinkno
        {
            get
            {
                return deplinkno;
            }
            set
            {
                deplinkno = value;
            }
        }

        ///<summary>
        ///数量
        ///</summary>
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        ///<summary>
        ///类型
        ///</summary>
        public int ProType
        {
            get
            {
                return protype;
            }
            set
            {
                protype = value;
            }
        }

        ///<summary>
        ///内容
        ///</summary>
        public string ProContent
        {
            get
            {
                return procontent;
            }
            set
            {
                procontent = value;
            }
        }

        ///<summary>
        ///审核状态
        ///</summary>
        public int State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        ///<summary>
        ///申报日期
        ///</summary>
        public DateTime ProDate
        {
            get
            {
                return prodate;
            }
            set
            {
                prodate = value;
            }
        }

        ///<summary>
        ///修改日期
        ///</summary>
        public DateTime ChangeDate
        {
            get
            {
                return changedate;
            }
            set
            {
                changedate = value;
            }
        }

        ///<summary>
        ///申报人
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
        ///申报人
        ///</summary>
        public string CreateUserName
        {
            get
            {
                return createusername;
            }
            set
            {
                createusername = value;
            }
        }
        ///<summary>
        ///修改人
        ///</summary>
        public string ChangeUser
        {
            get
            {
                return changeuser;
            }
            set
            {
                changeuser = value;
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

        ///<summary>
        ///施工地点
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
        ///备注
        ///</summary>
        public string ProDesc
        {
            get
            {
                return prodesc;
            }
            set
            {
                prodesc = value;
            }
        }

        ///<summary>
        ///默认代建0，1为自建
        ///</summary>
        public int Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        ///<summary>
        ///是否汇报，1为是，0否（默认否）
        ///</summary>
        public int PType
        {
            get
            {
                return ptype;
            }
            set
            {
                ptype = value;
            }
        }
    }
}

