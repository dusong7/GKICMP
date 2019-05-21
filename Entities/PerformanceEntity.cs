/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年09月04日 04点57分
** 描   述:      考核实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class PerformanceEntity
    {

        /// <summary>
        /// Performance表实体
        ///</summary>
        public PerformanceEntity()
        {
        }


        /// <summary>
        /// Performance表实体
        /// </summary>
        /// <param name="pername">考核名称</param>
        /// <param name="isuse">是否启用</param>
        /// <param name="isdel">是否删除</param>
        public PerformanceEntity(string pername, int isuse, int isdel)
        {
            this.PerName = pername;
            this.IsUse = isuse;
            this.Isdel = isdel;
        }

        private int pfid;//ID
        private string pername;//考核名称
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private DateTime stopdate;//停用日期
        private int isuse;//是否启用
        private int isdel;//是否删除


        ///<summary>
        ///ID
        ///</summary>
        public int PFID
        {
            get
            {
                return pfid;
            }
            set
            {
                pfid = value;
            }
        }

        ///<summary>
        ///考核名称
        ///</summary>
        public string PerName
        {
            get
            {
                return pername;
            }
            set
            {
                pername = value;
            }
        }

        ///<summary>
        ///录入人
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
        ///录入时间
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
        ///停用日期
        ///</summary>
        public DateTime StopDate
        {
            get
            {
                return stopdate;
            }
            set
            {
                stopdate = value;
            }
        }

        ///<summary>
        ///是否启用
        ///</summary>
        public int IsUse
        {
            get
            {
                return isuse;
            }
            set
            {
                isuse = value;
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

