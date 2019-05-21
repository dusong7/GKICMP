/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年11月30日 10点36分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LED_IssueEntity
    {

        /// <summary>
        /// LED_Issue表实体
        ///</summary>
        public LED_IssueEntity()
        {
        }


        /// <summary>
        /// LED_Issue表实体
        /// </summary>
        /// <param name="liid">ID</param>
        /// <param name="lid">设备ID</param>
        /// <param name="icontent">发布内容</param>
        /// <param name="fontsize">字体大小</param>
        /// <param name="fonttype">字体类型</param>
        /// <param name="stoptime">停留时间</param>
        /// <param name="translate">特效</param>
        /// <param name="lwidth">滚动速度</param>
        /// <param name="iflag">发布类型 1:文字   2：图片  </param>
        /// <param name="begindate">播放开始日期</param>
        /// <param name="enddate">播放结束日期</param>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="createuser">发布人</param>
        /// <param name="createdate">发布日期</param>
        public LED_IssueEntity(int liid, int lid, string icontent, int fontsize, string fonttype, int stoptime, int translate, int lwidth, int iflag, DateTime begindate, DateTime enddate, DateTime begintime, DateTime endtime, string createuser, DateTime createdate)
        {
            this.LIID = liid;
            this.LID = lid;
            this.IContent = icontent;
            this.FontSize = fontsize;
            this.FontType = fonttype;
            this.StopTime = stoptime;
            this.Translate = translate;
            this.LWidth = lwidth;
            this.IFlag = iflag;
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.BeginTime = begintime;
            this.EndTime = endtime;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private int liid;//ID
        private int lid;//设备ID
        private string icontent;//发布内容
        private int fontsize;//字体大小
        private string fonttype;//字体类型
        private int stoptime;//停留时间
        private int translate;//特效
        private int lwidth;//滚动速度
        private int iflag;//发布类型 1:文字   2：图片  
        private DateTime begindate;//播放开始日期
        private DateTime enddate;//播放结束日期
        private DateTime begintime;//开始时间
        private DateTime endtime;//结束时间
        private string createuser;//发布人
        private DateTime createdate;//发布日期
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string LName { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string IName { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public int LIID
        {
            get
            {
                return liid;
            }
            set
            {
                liid = value;
            }
        }

        ///<summary>
        ///设备ID
        ///</summary>
        public int LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }

        ///<summary>
        ///发布内容
        ///</summary>
        public string IContent
        {
            get
            {
                return icontent;
            }
            set
            {
                icontent = value;
            }
        }

        ///<summary>
        ///字体大小
        ///</summary>
        public int FontSize
        {
            get
            {
                return fontsize;
            }
            set
            {
                fontsize = value;
            }
        }

        ///<summary>
        ///字体类型
        ///</summary>
        public string FontType
        {
            get
            {
                return fonttype;
            }
            set
            {
                fonttype = value;
            }
        }

        ///<summary>
        ///停留时间
        ///</summary>
        public int StopTime
        {
            get
            {
                return stoptime;
            }
            set
            {
                stoptime = value;
            }
        }

        ///<summary>
        ///特效
        ///</summary>
        public int Translate
        {
            get
            {
                return translate;
            }
            set
            {
                translate = value;
            }
        }

        ///<summary>
        ///滚动速度
        ///</summary>
        public int LWidth
        {
            get
            {
                return lwidth;
            }
            set
            {
                lwidth = value;
            }
        }

        ///<summary>
        ///发布类型 1:文字   2：图片  
        ///</summary>
        public int IFlag
        {
            get
            {
                return iflag;
            }
            set
            {
                iflag = value;
            }
        }

        ///<summary>
        ///播放开始日期
        ///</summary>
        public DateTime BeginDate
        {
            get
            {
                return begindate;
            }
            set
            {
                begindate = value;
            }
        }

        ///<summary>
        ///播放结束日期
        ///</summary>
        public DateTime EndDate
        {
            get
            {
                return enddate;
            }
            set
            {
                enddate = value;
            }
        }

        ///<summary>
        ///开始时间
        ///</summary>
        public DateTime BeginTime
        {
            get
            {
                return begintime;
            }
            set
            {
                begintime = value;
            }
        }

        ///<summary>
        ///结束时间
        ///</summary>
        public DateTime EndTime
        {
            get
            {
                return endtime;
            }
            set
            {
                endtime = value;
            }
        }

        ///<summary>
        ///发布人
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
        ///发布日期
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

