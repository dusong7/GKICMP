/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月12日 09点28分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ScreenImagesEntity
    {

        /// <summary>
        /// ScreenImages表实体
        ///</summary>
        public ScreenImagesEntity()
        {
        }


        /// <summary>
        /// ScreenImages表实体
        /// </summary>
        /// <param name="siid">ID</param>
        /// <param name="simage">图片</param>
        /// <param name="imagedate">录入时间</param>
        /// <param name="crid">登记ID</param>
        public ScreenImagesEntity(string siid, string simage, DateTime imagedate, string crid)
        {
            this.SIID = siid;
            this.Simage = simage;
            this.ImageDate = imagedate;
            this.CRID = crid;
        }

        private string siid;//ID
        private string simage;//图片
        private DateTime imagedate;//录入时间
        private string crid;//登记ID


        ///<summary>
        ///ID
        ///</summary>
        public string SIID
        {
            get
            {
                return siid;
            }
            set
            {
                siid = value;
            }
        }

        ///<summary>
        ///图片
        ///</summary>
        public string Simage
        {
            get
            {
                return simage;
            }
            set
            {
                simage = value;
            }
        }

        ///<summary>
        ///录入时间
        ///</summary>
        public DateTime ImageDate
        {
            get
            {
                return imagedate;
            }
            set
            {
                imagedate = value;
            }
        }

        ///<summary>
        ///登记ID
        ///</summary>
        public string CRID
        {
            get
            {
                return crid;
            }
            set
            {
                crid = value;
            }
        }
    }
}

