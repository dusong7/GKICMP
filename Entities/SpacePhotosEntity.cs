/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月24日 05点34分
** 描   述:      照片实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SpacePhotosEntity
    {

        /// <summary>
        /// SpacePhotos表实体
        ///</summary>
        public SpacePhotosEntity()
        {
        }


        /// <summary>
        /// SpacePhotos表实体
        /// </summary>
        /// <param name="tid">ID</param>
        /// <param name="photoname">照片名称</param>
        /// <param name="photourl">地址</param>
        /// <param name="photodesc">描述</param>
        /// <param name="createuser">上传人</param>
        /// <param name="createdate">上传时间</param>
        /// <param name="classid">班级ID</param>
        /// <param name="pflag">标示 1:班级空间  2：个人空间</param>
        public SpacePhotosEntity(int tid, string photoname, string photourl, string photodesc, string createuser, DateTime createdate, int classid, int pflag)
        {
            this.TID = tid;
            this.PhotoName = photoname;
            this.PhotoUrl = photourl;
            this.PhotoDesc = photodesc;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.ClassID = classid;
            this.PFlag = pflag;
        }

        private int tid;//ID
        private string photoname;//照片名称
        private string photourl;//地址
        private string photodesc;//描述
        private string createuser;//上传人
        private DateTime createdate;//上传时间
        private int classid;//班级ID
        private int pflag;//标示 1:班级空间  2：个人空间


        ///<summary>
        ///ID
        ///</summary>
        public int TID
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
        ///照片名称
        ///</summary>
        public string PhotoName
        {
            get
            {
                return photoname;
            }
            set
            {
                photoname = value;
            }
        }

        ///<summary>
        ///地址
        ///</summary>
        public string PhotoUrl
        {
            get
            {
                return photourl;
            }
            set
            {
                photourl = value;
            }
        }

        ///<summary>
        ///描述
        ///</summary>
        public string PhotoDesc
        {
            get
            {
                return photodesc;
            }
            set
            {
                photodesc = value;
            }
        }

        ///<summary>
        ///上传人
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
        ///上传时间
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
        ///班级ID
        ///</summary>
        public int ClassID
        {
            get
            {
                return classid;
            }
            set
            {
                classid = value;
            }
        }

        ///<summary>
        ///标示 1:班级空间  2：个人空间
        ///</summary>
        public int PFlag
        {
            get
            {
                return pflag;
            }
            set
            {
                pflag = value;
            }
        }
    }
}

