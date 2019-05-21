/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2016年12月28日 03点51分
** 描   述:      教室实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ClassRoomEntity
    {

        /// <summary>
        /// ClassRoom表实体
        ///</summary>
        public ClassRoomEntity()
        {
        }


        /// <summary>
        /// ClassRoom表实体
        /// </summary>
        /// <param name="crid">CRID</param>
        /// <param name="fid">楼层ID</param>
        /// <param name="roomname">教室名称</param>
        /// <param name="roomdesc">教室备注</param>
        /// <param name="isuseable">是否可用</param>
        /// <param name="isdel">是否删除</param>
        //public ClassRoomEntity(string roomname,int isuseable, int isdel,string fid)
        //public ClassRoomEntity(string roomname, int isuseable, int isdel, int fid)
        public ClassRoomEntity(string roomname, int isuseable, int isdel)
        {
            this.RoomName = roomname;
            this.IsUseable = isuseable;
            this.Isdel = isdel;
            //this.FID = fid;
        }

        private int crid;//CRID
        private string fid;//楼层ID
        private string roomname;//教室名称
        private string roomdesc;//教室备注
        private int isuseable;//是否可用
        private int isdel;//是否删除
        private int rflag;//flag 1:教室 2:会议室 3:场室
        private string iscome;//管理员
        private int ctype;//类型

        /// <summary>
        /// 班级id
        /// </summary>
        public int DID { get; set; }
        /// <summary>
        /// 班级名称（别名）
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int CType
        {
            get { return ctype; }
            set { ctype = value; }
        }

        /// <summary>
        /// 管理员
        /// </summary>
        public string IsCome
        {
            get { return iscome; }
            set { iscome = value; }
        }

        /// <summary>
        /// flag 1:教室 2:会议室 3:场室
        /// </summary>
        public int RFlag
        {
            get { return rflag; }
            set { rflag = value; }
        }

        ///<summary>
        ///CRID
        ///</summary>
        public int CRID
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

        ///<summary>
        ///楼层ID
        ///</summary>
        public string FID
        {
            get
            {
                return fid;
            }
            set
            {
                fid = value;
            }
        }

        ///<summary>
        ///教室名称
        ///</summary>
        public string RoomName
        {
            get
            {
                return roomname;
            }
            set
            {
                roomname = value;
            }
        }

        ///<summary>
        ///教室备注
        ///</summary>
        public string RoomDesc
        {
            get
            {
                return roomdesc;
            }
            set
            {
                roomdesc = value;
            }
        }

        ///<summary>
        ///是否可用
        ///</summary>
        public int IsUseable
        {
            get
            {
                return isuseable;
            }
            set
            {
                isuseable = value;
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

