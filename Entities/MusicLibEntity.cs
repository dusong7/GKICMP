/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年09月06日 02点44分
** 描   述:      音乐库实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class MusicLibEntity
    {

        /// <summary>
        /// MusicLib表实体
        ///</summary>
        public MusicLibEntity()
        {
        }


        /// <summary>
        /// MusicLib表实体
        /// </summary>
        /// <param name="mid">id</param>
        /// <param name="name">名称</param>
        /// <param name="src">路径</param>
        /// <param name="size">文件大小</param>
        /// <param name="createdate">上传时间</param>
        /// <param name="createuser">上传人</param>
        public MusicLibEntity(int mid, string name, string src, int size, DateTime createdate, string createuser)
        {
            this.MID = mid;
            this.Name = name;
            this.Src = src;
            this.Size = size;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
        }

        private int mid;//id
        private string name;//名称
        private string src;//路径
        private int size;//文件大小
        private DateTime createdate;//上传时间
        private string createuser;//上传人


        ///<summary>
        ///id
        ///</summary>
        public int MID
        {
            get
            {
                return mid;
            }
            set
            {
                mid = value;
            }
        }

        ///<summary>
        ///名称
        ///</summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        ///<summary>
        ///路径
        ///</summary>
        public string Src
        {
            get
            {
                return src;
            }
            set
            {
                src = value;
            }
        }

        ///<summary>
        ///文件大小
        ///</summary>
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
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
    }
}

