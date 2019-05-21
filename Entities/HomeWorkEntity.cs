/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年07月01日 11点05分
** 描   述:      作业布置实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class HomeWorkEntity
    {

        /// <summary>
        /// HomeWork表实体
        ///</summary>
        public HomeWorkEntity()
        {
        }


        /// <summary>
        /// HomeWork表实体
        /// </summary>
        /// <param name="hwid">ID</param>
        /// <param name="homework">作业内容</param>
        /// <param name="completetime">完成时间</param>
        /// <param name="claname">班级</param>
        /// <param name="cid">课程</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="createuser">录入人</param>
        /// <param name="issend">是否发送</param>
        public HomeWorkEntity(string hwid, string homework, int completetime, string claname, int cid, DateTime createdate, string createuser, int issend)
        {
            this.HWID = hwid;
            this.HomeWork = homework;
            this.CompleteTime = completetime;
            this.ClaName = claname;
            this.CID = cid;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.IsSend = issend;
        }

        private string hwid;//ID
        private string homework;//作业内容
        private int completetime;//完成时间
        private string claname;//班级
        private int cid;//课程
        private DateTime createdate;//录入时间
        private string createuser;//录入人
        private int issend;//是否发送
        private string cidName;
        private string claids;

        public string Claids
        {
            get { return claids; }
            set { claids = value; }
        }

        public string CidName
        {
            get { return cidName; }
            set { cidName = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string HWID
        {
            get
            {
                return hwid;
            }
            set
            {
                hwid = value;
            }
        }

        ///<summary>
        ///作业内容
        ///</summary>
        public string HomeWork
        {
            get
            {
                return homework;
            }
            set
            {
                homework = value;
            }
        }

        ///<summary>
        ///完成时间
        ///</summary>
        public int CompleteTime
        {
            get
            {
                return completetime;
            }
            set
            {
                completetime = value;
            }
        }

        ///<summary>
        ///班级
        ///</summary>
        public string ClaName
        {
            get
            {
                return claname;
            }
            set
            {
                claname = value;
            }
        }

        ///<summary>
        ///课程
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
        ///是否发送
        ///</summary>
        public int IsSend
        {
            get
            {
                return issend;
            }
            set
            {
                issend = value;
            }
        }
    }
}

