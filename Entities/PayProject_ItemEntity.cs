/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年08月18日 11点08分
** 描   述:      缴费实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PayProject_ItemEntity
    {

        /// <summary>
        /// PayProject_Item表实体
        ///</summary>
        public PayProject_ItemEntity()
        {
        }


        /// <summary>
        /// PayProject_Item表实体
        /// </summary>
        /// <param name="ppiid">PPIID</param>
        /// <param name="ppid">缴费项目ID</param>
        /// <param name="piid">缴费项</param>
        public PayProject_ItemEntity(int ppiid, string ppid, int piid)
        {
            this.PPIID = ppiid;
            this.PPID = ppid;
            this.PIID = piid;
        }

        private int ppiid;//PPIID
        private string ppid;//缴费项目ID
        private int piid;//缴费项


        ///<summary>
        ///PPIID
        ///</summary>
        public int PPIID
        {
            get
            {
                return ppiid;
            }
            set
            {
                ppiid = value;
            }
        }

        ///<summary>
        ///缴费项目ID
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
        ///缴费项
        ///</summary>
        public int PIID
        {
            get
            {
                return piid;
            }
            set
            {
                piid = value;
            }
        }
    }
}

