/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年08月18日 09点21分
** 描   述:      缴费项目实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PayProjectEntity
    {

        /// <summary>
        /// PayProject表实体
        ///</summary>
        public PayProjectEntity()
        {
        }


        /// <summary>
        /// PayProject表实体
        /// </summary>
        /// <param name="ppid">ID</param>
        /// <param name="projectname">缴费项目名称</param>
        /// <param name="paycount">缴费总金额</param>
        /// <param name="isdisable">是否停用</param>
        /// <param name="isdel">是否删除</param>
        public PayProjectEntity(string ppid, string projectname, decimal paycount, int isdisable, int isdel)
        {
            this.PPID = ppid;
            this.ProjectName = projectname;
            this.PayCount = paycount;
            this.IsDisable = isdisable;
            this.Isdel = isdel;
        }

        private string ppid;//ID
        private string projectname;//缴费项目名称
        private decimal paycount;//缴费总金额
        private int isdisable;//是否停用
        private int isdel;//是否删除


        ///<summary>
        ///ID
        ///</summary>
        public string PPID
        {
            get
            {
                return ppid;
            }
            set
            {
                ppid = value;
            }
        }

        ///<summary>
        ///缴费项目名称
        ///</summary>
        public string ProjectName
        {
            get
            {
                return projectname;
            }
            set
            {
                projectname = value;
            }
        }

        ///<summary>
        ///缴费总金额
        ///</summary>
        public decimal PayCount
        {
            get
            {
                return paycount;
            }
            set
            {
                paycount = value;
            }
        }

        ///<summary>
        ///是否停用
        ///</summary>
        public int IsDisable
        {
            get
            {
                return isdisable;
            }
            set
            {
                isdisable = value;
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

