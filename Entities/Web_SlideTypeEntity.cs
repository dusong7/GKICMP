/*****************************************************************
** Copyright (c) 芜湖易通信息技术有限公司
** 创 建 人:      ygb
** 创建日期:      2017年05月27日 01点58分
** 描   述:      友情链接/幻灯片类型类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Web_SlideTypeEntity
    {

        /// <summary>
        /// Web_SlideType表实体
        ///</summary>
        public Web_SlideTypeEntity()
        {
        }


        /// <summary>
        /// Web_SlideType表实体
        /// </summary>
        /// <param name="stypename">名称</param>
        /// <param name="tflag">标识</param>
        /// <param name="isdel">是否删除</param>
        public Web_SlideTypeEntity(string stypename, int tflag, int isdel)
        {
            this.STypeName = stypename;
            this.TFlag = tflag;
            this.Isdel = isdel;
        }

        private int stype;//ID
        private string stypename;//名称
        private int tflag;//标识
        private string createuser;//创建人
        private DateTime createdate;//创建时间
        private int isdel;//是否删除


        ///<summary>
        ///ID
        ///</summary>
        public int SType
        {
            get
            {
                return stype;
            }
            set
            {
                stype = value;
            }
        }

        ///<summary>
        ///名称
        ///</summary>
        public string STypeName
        {
            get
            {
                return stypename;
            }
            set
            {
                stypename = value;
            }
        }

        ///<summary>
        ///标识
        ///</summary>
        public int TFlag
        {
            get
            {
                return tflag;
            }
            set
            {
                tflag = value;
            }
        }

        ///<summary>
        ///创建人
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
        ///创建时间
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

