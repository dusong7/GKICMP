/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年07月06日 02点48分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class HomeWork_ClassEntity
    {

        /// <summary>
        /// HomeWork_Class表实体
        ///</summary>
        public HomeWork_ClassEntity()
        {
        }


        /// <summary>
        /// HomeWork_Class表实体
        /// </summary>
        /// <param name="hcid">HCID</param>
        /// <param name="hwid">ID</param>
        /// <param name="claid">班级ID</param>
        public HomeWork_ClassEntity(int hcid, string hwid, int claid)
        {
            this.HCID = hcid;
            this.HWID = hwid;
            this.ClaID = claid;
        }

        private int hcid;//HCID
        private string hwid;//ID
        private int claid;//班级ID


        ///<summary>
        ///HCID
        ///</summary>
        public int HCID
        {
            get
            {
                return hcid;
            }
            set
            {
                hcid = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string HWID
        {
            get
            {
                return hwid;
            }
            set
            {
                hwid = value;
            }
        }

        ///<summary>
        ///班级ID
        ///</summary>
        public int ClaID
        {
            get
            {
                return claid;
            }
            set
            {
                claid = value;
            }
        }
    }
}

