/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年04月26日 04点36分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Project_FileEntity
    {

        /// <summary>
        /// Project_File表实体
        ///</summary>
        public Project_FileEntity()
        {
        }

        public Project_FileEntity(string filename)
        {
            this.FileName = filename;
        }

        /// <summary>
        /// Project_File表实体
        /// </summary>
        /// <param name="pfid"></param>
        /// <param name="pid"></param>
        /// <param name="filename"></param>
        /// <param name="fileurl"></param>
        /// <param name="prostage">类型1.技术参数，2.委托函，3.代理协议，4.资金预算证明，5资产清单</param>
        /// <param name="createuser">创建时间</param>
        /// <param name="createdate">创建时间</param>
        public Project_FileEntity(string pfid, string pid, string filename, string fileurl, int prostage, string createuser, DateTime createdate)
        {
            this.PFID = pfid;
            this.PID = pid;
            this.FileName = filename;
            this.FileUrl = fileurl;
            this.ProStage = prostage;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private string pfid;//
        private string pid;//
        private string filename;//
        private string fileurl;//
        private int prostage;//类型1.技术参数，2.委托函，3.代理协议，4.资金预算证明，5资产清单
        private string createuser;//创建时间
        private DateTime createdate;//创建时间

        private int isreport;
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
        ///
        ///</summary>
        public string PFID
        {
            get
            {
                return pfid;
            }
            set
            {
                pfid = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string PID
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
        ///
        ///</summary>
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }

        ///<summary>
        ///
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
        ///类型1.技术参数，2.委托函，3.代理协议，4.资金预算证明，5资产清单
        ///</summary>
        public int ProStage
        {
            get
            {
                return prostage;
            }
            set
            {
                prostage = value;
            }
        }

        ///<summary>
        ///创建时间
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
        ///创建时间
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

