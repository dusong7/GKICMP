/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月29日 10点49分
** 描   述:      助学金实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class GrantEntity
    {

        /// <summary>
        /// Grant表实体
        ///</summary>
        public GrantEntity()
        {
        }


        public GrantEntity(string uname, DateTime begin, DateTime end, int isdel)
        {
            this.UserName = uname;
            this.Begin = begin;
            this.End = end;
            this.Isdel = isdel;

        }

        public GrantEntity(DateTime begin, DateTime end, int isdel)
        {
            this.Begin = begin;
            this.End = end;
            this.Isdel = isdel;

        }

        private string gid;//助学金ID
        private string uid;//学生ID
        private string username;
        private int gtype;//奖学金类型
        private DateTime createdate;//申请时间
        private string applyurl;//申请材料
        private DateTime aduitdate;//审核时间
        private string aduituser;//审核人
        private string aduitname;//审核人姓名
        private string gmark;//备注
        private int aduitstate;//审核状态
        private int isdel;//是否删除
        private DateTime begin;
        private DateTime end;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        /// <summary>
        /// 审核人姓名
        /// </summary>
        public string AduitName
        {
            get { return aduitname; }
            set { aduitname = value; }
        }

        ///<summary>
        ///助学金ID
        ///</summary>
        public string GID
        {
            get
            {
                return gid;
            }
            set
            {
                gid = value;
            }
        }

        ///<summary>
        ///学生ID
        ///</summary>
        public string UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        ///<summary>
        ///奖学金类型
        ///</summary>
        public int GType
        {
            get
            {
                return gtype;
            }
            set
            {
                gtype = value;
            }
        }

        ///<summary>
        ///申请时间
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
        ///申请材料
        ///</summary>
        public string ApplyUrl
        {
            get
            {
                return applyurl;
            }
            set
            {
                applyurl = value;
            }
        }

        ///<summary>
        ///审核时间
        ///</summary>
        public DateTime AduitDate
        {
            get
            {
                return aduitdate;
            }
            set
            {
                aduitdate = value;
            }
        }

        ///<summary>
        ///审核人
        ///</summary>
        public string AduitUser
        {
            get
            {
                return aduituser;
            }
            set
            {
                aduituser = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string GMark
        {
            get
            {
                return gmark;
            }
            set
            {
                gmark = value;
            }
        }

        ///<summary>
        ///审核状态
        ///</summary>
        public int AduitState
        {
            get
            {
                return aduitstate;
            }
            set
            {
                aduitstate = value;
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

