/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年08月11日 02点15分
** 描   述:      教师异动实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_ChangesEntity
    {

        /// <summary>
        /// Teacher_Changes表实体
        ///</summary>
        public Teacher_ChangesEntity()
        {
        }

        public Teacher_ChangesEntity(DateTime begin , DateTime end)
        {
            this.Begin = begin;
            this.End = end;

        }

        /// <summary>
        /// Teacher_Changes表实体
        /// </summary>
        /// <param name="tcid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="changereason">异动说明</param>
        /// <param name="ctype">异动类型</param>
        /// <param name="cdate">异动日期</param>
        /// <param name="cfile">附件</param>
        /// <param name="isreport">是否上报</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="createuser">录入人</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_ChangesEntity(string tcid, string tid, string changereason, int ctype, DateTime cdate, string cfile, int isreport, DateTime createdate, string createuser, int isdel)
        {
            this.TCID = tcid;
            this.TID = tid;
            this.ChangeReason = changereason;
            this.CType = ctype;
            this.CDate = cdate;
            this.CFile = cfile;
            this.IsReport = isreport;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.Isdel = isdel;
        }

        private string tcid;//ID
        private string tid;//教师ID
        private string changereason;//异动说明
        private int ctype;//异动类型
        private DateTime cdate;//异动日期
        private string cfile;//附件
        private int isreport;//是否上报
        private DateTime createdate;//录入日期
        private string createuser;//录入人
        private int isdel;//是否删除

        private string tname;
        public string TName
        {
            get
            {
                return tname;
            }
            set
            {
                tname = value;
            }
        }

        private DateTime begin;
        private DateTime end;
        public DateTime Begin
        {
            get
            {
                return begin;
            }
            set
            {
                begin = value;
            }
        }
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public string TCID
        {
            get
            {
                return tcid;
            }
            set
            {
                tcid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TID
        {
            get
            {
                return tid;
            }
            set
            {
                tid = value;
            }
        }

        ///<summary>
        ///异动说明
        ///</summary>
        public string ChangeReason
        {
            get
            {
                return changereason;
            }
            set
            {
                changereason = value;
            }
        }

        ///<summary>
        ///异动类型
        ///</summary>
        public int CType
        {
            get
            {
                return ctype;
            }
            set
            {
                ctype = value;
            }
        }

        ///<summary>
        ///异动日期
        ///</summary>
        public DateTime CDate
        {
            get
            {
                return cdate;
            }
            set
            {
                cdate = value;
            }
        }

        ///<summary>
        ///附件
        ///</summary>
        public string CFile
        {
            get
            {
                return cfile;
            }
            set
            {
                cfile = value;
            }
        }

        ///<summary>
        ///是否上报
        ///</summary>
        public int IsReport
        {
            get
            {
                return isreport;
            }
            set
            {
                isreport = value;
            }
        }

        ///<summary>
        ///录入日期
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

