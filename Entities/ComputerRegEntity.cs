/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月12日 09点27分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ComputerRegEntity
    {

        /// <summary>
        /// ComputerReg表实体
        ///</summary>
        public ComputerRegEntity()
        {
        }


        /// <summary>
        /// ComputerReg表实体
        /// </summary>
        /// <param name="crid">ID</param>
        /// <param name="guid">Guid</param>
        /// <param name="sysid">用户</param>
        /// <param name="cid">学科</param>
        /// <param name="chaptername">课题</param>
        /// <param name="computername">计算机名</param>
        /// <param name="ip">IP</param>
        /// <param name="regdate">登记日期</param>
        /// <param name="uploadmd5">加密</param>
        /// <param name="xyear">年份</param>
        /// <param name="xterm">学期</param>
        public ComputerRegEntity(string crid, string guid, string sysid, int cid, string chaptername, string computername, string ip, DateTime regdate, string uploadmd5, string xyear, int xterm)
        {
            this.CRID = crid;
            this.Guid = guid;
            this.SysID = sysid;
            this.CID = cid;
            this.ChapterName = chaptername;
            this.ComputerName = computername;
            this.IP = ip;
            this.RegDate = regdate;
            this.UploadMD5 = uploadmd5;
            this.Xyear = xyear;
            this.XTerm = xterm;
        }

        private string crid;//ID
        private string guid;//Guid
        private string sysid;//用户
        private int cid;//学科
        private string chaptername;//课题
        private string computername;//计算机名
        private string ip;//IP
        private DateTime regdate;//登记日期
        private string uploadmd5;//加密
        private string xyear;//年份
        private int xterm;//学期
        private int regtype;//登记形式 1:自动登记 2:补录 ；3：手机端登记

        /// <summary>
        /// 登记形式 1:自动登记 2:补录 ；3：手机端登记
        /// </summary>
        public int RegType
        {
            get { return regtype; }
            set { regtype = value; }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 学科名称
        /// </summary>
        public string CIDName{get;set;}

        ///<summary>
        ///ID
        ///</summary>
        public string CRID
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
        ///Guid
        ///</summary>
        public string Guid
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }

        ///<summary>
        ///用户
        ///</summary>
        public string SysID
        {
            get
            {
                return sysid;
            }
            set
            {
                sysid = value;
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
        ///课题
        ///</summary>
        public string ChapterName
        {
            get
            {
                return chaptername;
            }
            set
            {
                chaptername = value;
            }
        }

        ///<summary>
        ///计算机名
        ///</summary>
        public string ComputerName
        {
            get
            {
                return computername;
            }
            set
            {
                computername = value;
            }
        }

        ///<summary>
        ///IP
        ///</summary>
        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        ///<summary>
        ///登记日期
        ///</summary>
        public DateTime RegDate
        {
            get
            {
                return regdate;
            }
            set
            {
                regdate = value;
            }
        }

        ///<summary>
        ///加密
        ///</summary>
        public string UploadMD5
        {
            get
            {
                return uploadmd5;
            }
            set
            {
                uploadmd5 = value;
            }
        }

        ///<summary>
        ///年份
        ///</summary>
        public string Xyear
        {
            get
            {
                return xyear;
            }
            set
            {
                xyear = value;
            }
        }

        ///<summary>
        ///学期
        ///</summary>
        public int XTerm
        {
            get
            {
                return xterm;
            }
            set
            {
                xterm = value;
            }
        }
    }
}

