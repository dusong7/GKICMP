/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年09月08日 08点17分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class RestTimeEntity
    {

        /// <summary>
        /// RestTime表实体
        ///</summary>
        public RestTimeEntity()
        {
        }


        /// <summary>
        /// RestTime表实体
        /// </summary>
        /// <param name="rtid">ID</param>
        /// <param name="restname">作息名称</param>
        /// <param name="begintime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="bmid">开始时间铃声</param>
        /// <param name="emid">结束铃声</param>
        /// <param name="weeks">适用星期</param>
        /// <param name="isuse">是否启用</param>
        /// <param name="isrecording">是否允许录制</param>
        /// <param name="isgetset">响预备铃</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="isdel">是否删除</param>
        public RestTimeEntity(int rtid, string restname, DateTime begintime, DateTime endtime, int bmid, int emid, string weeks, int isuse, int isrecording, int isgetset, string createuser, DateTime createdate, int isdel)
        {
            this.RTID = rtid;
            this.RestName = restname;
            this.BeginTime = begintime;
            this.EndTime = endtime;
            this.BMID = bmid;
            this.EMID = emid;
            this.Weeks = weeks;
            this.IsUse = isuse;
            this.IsRecording = isrecording;
            this.IsGetSet = isgetset;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private int rtid;//ID
        private string restname;//作息名称
        private DateTime begintime;
        private DateTime endtime;
        private int bmid;//开始时间铃声
        private int emid;//结束铃声
        private int rmid;//预备铃声
        private string weeks;//适用星期
        private int isuse;//是否启用
        private int isrecording;//是否允许录制
        private int isgetset;//响预备铃
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private int isdel;//是否删除


        /// <summary>
        /// 预备铃声
        /// </summary>
        public int RMID
        {
            get { return rmid; }
            set { rmid = value; }
        }

        ///<summary>
        ///ID
        ///</summary>
        public int RTID
        {
            get
            {
                return rtid;
            }
            set
            {
                rtid = value;
            }
        }

        ///<summary>
        ///作息名称
        ///</summary>
        public string RestName
        {
            get
            {
                return restname;
            }
            set
            {
                restname = value;
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
        ///开始时间铃声
        ///</summary>
        public int BMID
        {
            get
            {
                return bmid;
            }
            set
            {
                bmid = value;
            }
        }

        ///<summary>
        ///结束铃声
        ///</summary>
        public int EMID
        {
            get
            {
                return emid;
            }
            set
            {
                emid = value;
            }
        }

        ///<summary>
        ///适用星期
        ///</summary>
        public string Weeks
        {
            get
            {
                return weeks;
            }
            set
            {
                weeks = value;
            }
        }

        ///<summary>
        ///是否启用
        ///</summary>
        public int IsUse
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
        ///是否允许录制
        ///</summary>
        public int IsRecording
        {
            get
            {
                return isrecording;
            }
            set
            {
                isrecording = value;
            }
        }

        ///<summary>
        ///响预备铃
        ///</summary>
        public int IsGetSet
        {
            get
            {
                return isgetset;
            }
            set
            {
                isgetset = value;
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

