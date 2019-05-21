/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年09月30日 03点31分
** 描   述:      水印设置信息实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SysSetConfigEntity
    {

        /// <summary>
        /// SysSetConfig表实体
        ///</summary>
        public SysSetConfigEntity()
        {
        }


        /// <summary>
        /// SysSetConfig表实体
        /// </summary>
        /// <param name="sscid">设置ID</param>
        /// <param name="watermarktype">文件管理水印类型</param>
        /// <param name="watermarkcontent">内容</param>
        /// <param name="beginfristdate">开学第一天</param>
        public SysSetConfigEntity(string sscid, int watermarktype, string watermarkcontent, DateTime beginfristdate)
        {
            this.SSCID = sscid;
            this.WatermarkType = watermarktype;
            this.WatermarkContent = watermarkcontent;
            this.BeginFristDate = beginfristdate;
        }

        private string sscid;//设置ID
        private int watermarktype;//文件管理水印类型
        private string watermarkcontent;//内容
        private DateTime beginfristdate;//开学第一天

        private int nowterm;//学期
        private string eyear;//学年度


        public int SendInterval { get; set; }

        public int NowTerm
        {
            get
            {
                return nowterm;
            }
            set
            {
                nowterm = value;
            }
        }
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
        ///设置ID
        ///</summary>
        public string SSCID
        {
            get
            {
                return sscid;
            }
            set
            {
                sscid = value;
            }
        }

        ///<summary>
        ///文件管理水印类型
        ///</summary>
        public int WatermarkType
        {
            get
            {
                return watermarktype;
            }
            set
            {
                watermarktype = value;
            }
        }

        ///<summary>
        ///内容
        ///</summary>
        public string WatermarkContent
        {
            get
            {
                return watermarkcontent;
            }
            set
            {
                watermarkcontent = value;
            }
        }

        ///<summary>
        ///开学第一天
        ///</summary>
        public DateTime BeginFristDate
        {
            get
            {
                return beginfristdate;
            }
            set
            {
                beginfristdate = value;
            }
        }
    }
}

