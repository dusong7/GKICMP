/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年10月06日 10点56分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class FileBoxEntity
    {

        /// <summary>
        /// FileBox表实体
        ///</summary>
        public FileBoxEntity()
        {
        }


        /// <summary>
        /// FileBox表实体
        /// </summary>
        /// <param name="fbid">文件夹ID</param>
        /// <param name="fbname">文件夹名字</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建日期</param>
        /// <param name="adminid">管理员</param>
        /// <param name="pid">父级ID</param>
        /// <param name="fileurl">地址</param>
        /// <param name="rsize">大小</param>
        /// <param name="rformat">格式</param>
        /// <param name="downloadnum">下载次数</param>
        /// <param name="fflag">标示 1:文件夹  2：文件</param>
        public FileBoxEntity(int fbid, string fbname, string createuser, DateTime createdate, string adminid, int pid, string fileurl, int rsize, string rformat, int downloadnum, int fflag)
        {
            this.FBID = fbid;
            this.FBName = fbname;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.AdminID = adminid;
            this.PID = pid;
            this.FileUrl = fileurl;
            this.RSize = rsize;
            this.RFormat = rformat;
            this.DownLoadNum = downloadnum;
            this.FFlag = fflag;
        }

        private int fbid;//文件夹ID
        private string fbname;//文件夹名字
        private string createuser;//创建人
        private DateTime createdate;//创建日期
        private string adminid;//管理员
        private int pid;//父级ID
        private string fileurl;//地址
        private int rsize;//大小
        private string rformat;//格式
        private int downloadnum;//下载次数
        private int fflag;//标示 1:文件夹  2：文件

        
        ///<summary>
        ///文件夹ID
        ///</summary>
        public int FBID
        {
            get
            {
                return fbid;
            }
            set
            {
                fbid = value;
            }
        }

        ///<summary>
        ///文件夹名字
        ///</summary>
        public string FBName
        {
            get
            {
                return fbname;
            }
            set
            {
                fbname = value;
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
        ///创建日期
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
        ///管理员
        ///</summary>
        public string AdminID
        {
            get
            {
                return adminid;
            }
            set
            {
                adminid = value;
            }
        }

        ///<summary>
        ///父级ID
        ///</summary>
        public int PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        ///<summary>
        ///地址
        ///</summary>
        public string FileUrl
        {
            get
            {
                return fileurl;
            }
            set
            {
                fileurl = value;
            }
        }

        ///<summary>
        ///大小
        ///</summary>
        public int RSize
        {
            get
            {
                return rsize;
            }
            set
            {
                rsize = value;
            }
        }

        ///<summary>
        ///格式
        ///</summary>
        public string RFormat
        {
            get
            {
                return rformat;
            }
            set
            {
                rformat = value;
            }
        }

        ///<summary>
        ///下载次数
        ///</summary>
        public int DownLoadNum
        {
            get
            {
                return downloadnum;
            }
            set
            {
                downloadnum = value;
            }
        }

        ///<summary>
        ///标示 1:文件夹  2：文件
        ///</summary>
        public int FFlag
        {
            get
            {
                return fflag;
            }
            set
            {
                fflag = value;
            }
        }
    }
}

