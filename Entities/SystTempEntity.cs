/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月09日 05点03分
** 描   述:      模板实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SystTempEntity
    {

        /// <summary>
        /// SystTemp表实体
        ///</summary>
        public SystTempEntity()
        {
        }


        /// <summary>
        /// SystTemp表实体
        /// </summary>
        /// <param name="stid">模板ID</param>
        /// <param name="tempname">模板名称</param>
        /// <param name="tempcontent">模板内容</param>
        /// <param name="mids">使用模块</param>
        /// <param name="isuse">是否启用</param>
        /// <param name="createdate">更新日期</param>
        public SystTempEntity(int stid, string tempname, string tempcontent, string mids, string isuse, DateTime createdate)
        {
            this.STID = stid;
            this.TempName = tempname;
            this.TempContent = tempcontent;
            this.Mids = mids;
            this.IsUse = isuse;
            this.CreateDate = createdate;
        }

        private int stid;//模板ID
        private string tempname;//模板名称
        private string tempcontent;//模板内容
        private string mids;//使用模块
        private string isuse;//是否启用
        private DateTime createdate;//更新日期


        ///<summary>
        ///模板ID
        ///</summary>
        public int STID
        {
            get
            {
                return stid;
            }
            set
            {
                stid = value;
            }
        }

        ///<summary>
        ///模板名称
        ///</summary>
        public string TempName
        {
            get
            {
                return tempname;
            }
            set
            {
                tempname = value;
            }
        }

        ///<summary>
        ///模板内容
        ///</summary>
        public string TempContent
        {
            get
            {
                return tempcontent;
            }
            set
            {
                tempcontent = value;
            }
        }

        ///<summary>
        ///使用模块
        ///</summary>
        public string Mids
        {
            get
            {
                return mids;
            }
            set
            {
                mids = value;
            }
        }

        ///<summary>
        ///是否启用
        ///</summary>
        public string IsUse
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
        ///更新日期
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
    }
}

