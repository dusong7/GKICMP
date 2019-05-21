/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2016年11月21日 03点42分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class EgovernmentEntity
    {

        /// <summary>
        /// Egovernment表实体
        ///</summary>
        public EgovernmentEntity()
        {
        }


        /// <summary>
        /// Egovernment表实体
        /// </summary>
        /// <param name="eid">政务ID</param>
        /// <param name="etitle">政务标题</param>
        /// <param name="ecode">政务编号</param>
        /// <param name="ekey">关键字</param>
        /// <param name="edepartment">来文单位</param>
        /// <param name="etitletype">文号</param>
        /// <param name="econtent">政务正文</param>
        /// <param name="opened">是否公开</param>
        /// <param name="completed">是否完成</param>
        /// <param name="isapproved">是否批转</param>
        /// <param name="etype">归档分类</param>
        /// <param name="createdate"></param>
        /// <param name="createuser"></param>
        /// <param name="estate"></param>
        public EgovernmentEntity(string eid, string etitle, string ecode, string ekey, string edepartment, string etitletype, string econtent, int opened, int completed, int isapproved, int etype, DateTime createdate, string createuser, int estate)
        {
            this.EID = eid;
            this.Etitle = etitle;
            this.Ecode = ecode;
            this.EKey = ekey;
            this.EDepartment = edepartment;
            this.EtitleType = etitletype;
            this.EContent = econtent;
            this.Opened = opened;
            this.Completed = completed;
            this.IsApproved = isapproved;
            this.Etype = etype;
            this.CreateDate = createdate;
            this.CreateUser = createuser;
            this.Estate = estate;
        }

        private string eid;//政务ID
        private string etitle;//政务标题
        private string ecode;//政务编号
        private string ekey;//关键字
        private string edepartment;//来文单位
        private string etitletype;//文号
        private string econtent;//政务正文
        private int opened;//是否公开
        private int completed;//是否完成
        private int isapproved;//是否批转
        private int etype;//归档分类
        private DateTime createdate;//
        private string createuser;//
        private int estate;//
        private DateTime begin;//开始时间
        private DateTime end;//结束时间
        public int IsSave { get; set; }//保存或提交
        public int IsSuperior { get; set; }//上级公文
        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        ///<summary>
        ///政务ID
        ///</summary>
        public string EID
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
        }

        ///<summary>
        ///政务标题
        ///</summary>
        public string Etitle
        {
            get
            {
                return etitle;
            }
            set
            {
                etitle = value;
            }
        }

        ///<summary>
        ///政务编号
        ///</summary>
        public string Ecode
        {
            get
            {
                return ecode;
            }
            set
            {
                ecode = value;
            }
        }

        ///<summary>
        ///关键字
        ///</summary>
        public string EKey
        {
            get
            {
                return ekey;
            }
            set
            {
                ekey = value;
            }
        }

        ///<summary>
        ///来文单位
        ///</summary>
        public string EDepartment
        {
            get
            {
                return edepartment;
            }
            set
            {
                edepartment = value;
            }
        }

        ///<summary>
        ///文号
        ///</summary>
        public string EtitleType
        {
            get
            {
                return etitletype;
            }
            set
            {
                etitletype = value;
            }
        }

        ///<summary>
        ///政务正文
        ///</summary>
        public string EContent
        {
            get
            {
                return econtent;
            }
            set
            {
                econtent = value;
            }
        }

        ///<summary>
        ///是否公开
        ///</summary>
        public int Opened
        {
            get
            {
                return opened;
            }
            set
            {
                opened = value;
            }
        }

        ///<summary>
        ///是否完成
        ///</summary>
        public int Completed
        {
            get
            {
                return completed;
            }
            set
            {
                completed = value;
            }
        }

        ///<summary>
        ///是否批转
        ///</summary>
        public int IsApproved
        {
            get
            {
                return isapproved;
            }
            set
            {
                isapproved = value;
            }
        }

        ///<summary>
        ///归档分类
        ///</summary>
        public int Etype
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
        ///
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
        ///
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
        ///
        ///</summary>
        public int Estate
        {
            get
            {
                return estate;
            }
            set
            {
                estate = value;
            }
        }
    }
}
