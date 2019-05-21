/*****************************************************************
** Copyright (c) 芜湖易通信息技术有限公司
** 创 建 人:      ygb
** 创建日期:      2017年05月27日 01点59分
** 描   述:      友情链接/幻灯片类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Web_SlideEntity
    {

        /// <summary>
        /// Web_Slide表实体
        ///</summary>
        public Web_SlideEntity()
        {
        }


        /// <summary>
        /// Web_Slide表实体
        /// </summary>
        /// <param name="sliid">友情链接/幻灯片ID</param>
        /// <param name="stype">分类</param>
        /// <param name="slidename">名称</param>
        /// <param name="slideurl">链接</param>
        /// <param name="simage">图片</param>
        /// <param name="invaliddate">失效时间</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建时间</param>
        /// <param name="isdel">是否删除</param>
        public Web_SlideEntity(int stype, string slidename,DateTime begindate,DateTime enddate, int isdel,int tflag)
        {
            this.SType = stype;
            this.SlideName = slidename;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.Isdel = isdel;
            this.tFlag = tflag;
        }

        private int sliid;//友情链接/幻灯片ID
        private int stype;//分类
        private string slidename;//名称
        private string slideurl;//链接
        private string simage;//图片
        private DateTime invaliddate;//失效时间
        private string createuser;//创建人
        private DateTime createdate;//创建时间
        private int isdel;//是否删除
        private int tFlag;
        private DateTime begindate;
        private DateTime enddate;
        private string createusername;//创建人姓名
        private string stypename;//类别名称

        public string STypeName
        {
            get { return stypename; }
            set { stypename = value; }
        }

        public string CreateUserName
        {
            get { return createusername; }
            set { createusername = value; }
        }


        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        public DateTime BeginDate
        {
            get { return begindate; }
            set { begindate = value; }
        }


        public int TFlag
        {
            get { return tFlag; }
            set { tFlag = value; }
        }


        ///<summary>
        ///友情链接/幻灯片ID
        ///</summary>
        public int SliID
        {
            get
            {
                return sliid;
            }
            set
            {
                sliid = value;
            }
        }

        ///<summary>
        ///分类
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
        public string SlideName
        {
            get
            {
                return slidename;
            }
            set
            {
                slidename = value;
            }
        }

        ///<summary>
        ///链接
        ///</summary>
        public string SlideUrl
        {
            get
            {
                return slideurl;
            }
            set
            {
                slideurl = value;
            }
        }

        ///<summary>
        ///图片
        ///</summary>
        public string SImage
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
        ///失效时间
        ///</summary>
        public DateTime InvalidDate
        {
            get
            {
                return invaliddate;
            }
            set
            {
                invaliddate = value;
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

