/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月01日 09点12分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class EduResourceEntity
    {

        /// <summary>
        /// EduResource表实体
        ///</summary>
        public EduResourceEntity()
        {
        }


        /// <summary>
        /// EduResource表实体
        /// </summary>
        /// <param name="erid">ID</param>
        /// <param name="resoursename">资源名称</param>
        /// <param name="gid">所属年级</param>
        /// <param name="tid">学期</param>
        /// <param name="cid">学科</param>
        /// <param name="etype">分类</param>
        /// <param name="resourseurl">地址</param>
        /// <param name="createuser">上传人</param>
        /// <param name="createdate">上传日期</param>
        /// <param name="rsize">大小</param>
        /// <param name="rformat">格式</param>
        /// <param name="downloadnum">下载次数</param>
        /// <param name="isexcellent">是否精品</param>
        /// <param name="isopen">是否对外公开</param>
        /// <param name="auditstate">审核状态</param>
        /// <param name="audituser">审核人</param>
        /// <param name="auditdate">审核时间</param>
        public EduResourceEntity(int erid, string resoursename, int gid, int tid, int cid, int etype, string resourseurl, string createuser, DateTime createdate, int rsize, string rformat, int downloadnum, int isexcellent, int isopen, int auditstate, string audituser, DateTime auditdate)
        {
            this.Erid = erid;
            this.ResourseName = resoursename;
            this.GID = gid;
            this.TID = tid;
            this.CID = cid;
            this.EType = etype;
            this.ResourseUrl = resourseurl;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.RSize = rsize;
            this.RFormat = rformat;
            this.DownLoadNum = downloadnum;
            this.IsExcellent = isexcellent;
            this.IsOpen = isopen;
            this.AuditState = auditstate;
            this.AuditUser = audituser;
            this.AuditDate = auditdate;
        }

        private int erid;//ID
        private string resoursename;//资源名称
        private int gid;//所属年级
        private int tid;//学期
        private int cid;//学科
        private int etype;//分类
        private string resourseurl;//地址
        private string createuser;//上传人
        private DateTime createdate;//上传日期
        private int rsize;//大小
        private string rformat;//格式
        private int downloadnum;//下载次数
        private int isexcellent;//是否精品
        private int isopen;//是否对外公开
        private int auditstate;//审核状态
        private string audituser;//审核人
        private DateTime auditdate;//审核时间
        public string AuditUserName { get; set; }//审核人
        public string CreateUserName { get; set; }//姓名
        public string GIDName { get; set; }//年级名称
        public string CIDName { get; set; }//学科名称
        /// <summary>
        /// 加密密码
        /// </summary>
        public string ERPwd { get; set; }//加密密码
        ///<summary>
        ///ID
        ///</summary>
        public int Erid
        {
            get
            {
                return erid;
            }
            set
            {
                erid = value;
            }
        }

        ///<summary>
        ///资源名称
        ///</summary>
        public string ResourseName
        {
            get
            {
                return resoursename;
            }
            set
            {
                resoursename = value;
            }
        }

        ///<summary>
        ///所属年级
        ///</summary>
        public int GID
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
        ///学期
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
        ///学科
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
        ///分类
        ///</summary>
        public int EType
        {
            get
            {
                return etype;
            }
            set
            {
                etype = value;
            }
        }

        ///<summary>
        ///地址
        ///</summary>
        public string ResourseUrl
        {
            get
            {
                return resourseurl;
            }
            set
            {
                resourseurl = value;
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
        ///上传日期
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
        ///是否精品
        ///</summary>
        public int IsExcellent
        {
            get
            {
                return isexcellent;
            }
            set
            {
                isexcellent = value;
            }
        }

        ///<summary>
        ///是否对外公开
        ///</summary>
        public int IsOpen
        {
            get
            {
                return isopen;
            }
            set
            {
                isopen = value;
            }
        }

        ///<summary>
        ///审核状态
        ///</summary>
        public int AuditState
        {
            get
            {
                return auditstate;
            }
            set
            {
                auditstate = value;
            }
        }

        ///<summary>
        ///审核人
        ///</summary>
        public string AuditUser
        {
            get
            {
                return audituser;
            }
            set
            {
                audituser = value;
            }
        }

        ///<summary>
        ///审核时间
        ///</summary>
        public DateTime AuditDate
        {
            get
            {
                return auditdate;
            }
            set
            {
                auditdate = value;
            }
        }
    }
}

