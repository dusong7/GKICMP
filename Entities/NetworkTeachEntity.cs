/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年11月15日 09点13分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class NetworkTeachEntity
    {

        /// <summary>
        /// NetworkTeach表实体
        ///</summary>
        public NetworkTeachEntity()
        {
        }


        /// <summary>
        /// NetworkTeach表实体
        /// </summary>
        /// <param name="ntid">ID</param>
        /// <param name="nttname">课程名称</param>
        /// <param name="epid">适合年级</param>
        /// <param name="cid">科目</param>
        /// <param name="createuser">上传教师</param>
        /// <param name="teabegin">在线开始时间</param>
        /// <param name="teaend">在线结束时间</param>
        /// <param name="createdate">发布时间</param>
        /// <param name="ntturl">视频地址</param>
        /// <param name="iscommunication">是否允许交流</param>
        public NetworkTeachEntity(string ntid, string nttname, string epid, int cid, string createuser, DateTime teabegin, DateTime teaend, DateTime createdate, string ntturl, int iscommunication)
        {
            this.NTID = ntid;
            this.NTTName = nttname;
            this.EPID = epid;
            this.CID = cid;
            this.CreateUser = createuser;
            this.TeaBegin = teabegin;
            this.TeaEnd = teaend;
            this.CreateDate = createdate;
            this.NTTUrl = ntturl;
            this.IsCommunication = iscommunication;
        }

        private string ntid;//ID
        private string nttname;//课程名称
        private string epid;//适合年级
        private int cid;//科目
        private string createuser;//上传教师
        private DateTime teabegin;//在线开始时间
        private DateTime teaend;//在线结束时间
        private DateTime createdate;//发布时间
        private string ntturl;//视频地址
        private int iscommunication;//是否允许交流
        /// <summary>
        /// 对应班级
        /// </summary>
        public string Cla { get; set; }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 上传人名称
        /// </summary>
        public string CreateName { get; set; }
        /// <summary>
        /// 年级名称
        /// </summary>
        public string GName { get; set; }
        public int RoomID { get; set; }
        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string ImgUrl { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public string NTID
        {
            get
            {
                return ntid;
            }
            set
            {
                ntid = value;
            }
        }

        ///<summary>
        ///课程名称
        ///</summary>
        public string NTTName
        {
            get
            {
                return nttname;
            }
            set
            {
                nttname = value;
            }
        }

        ///<summary>
        ///适合年级
        ///</summary>
        public string EPID
        {
            get
            {
                return epid;
            }
            set
            {
                epid = value;
            }
        }

        ///<summary>
        ///科目
        ///</summary>
        public int CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
            }
        }

        ///<summary>
        ///上传教师
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
        ///在线开始时间
        ///</summary>
        public DateTime TeaBegin
        {
            get
            {
                return teabegin;
            }
            set
            {
                teabegin = value;
            }
        }

        ///<summary>
        ///在线结束时间
        ///</summary>
        public DateTime TeaEnd
        {
            get
            {
                return teaend;
            }
            set
            {
                teaend = value;
            }
        }

        ///<summary>
        ///发布时间
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
        ///视频地址
        ///</summary>
        public string NTTUrl
        {
            get
            {
                return ntturl;
            }
            set
            {
                ntturl = value;
            }
        }

        ///<summary>
        ///是否允许交流
        ///</summary>
        public int IsCommunication
        {
            get
            {
                return iscommunication;
            }
            set
            {
                iscommunication = value;
            }
        }
    }
}

