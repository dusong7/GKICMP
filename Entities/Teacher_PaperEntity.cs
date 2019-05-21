/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年06月14日 09点50分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Teacher_PaperEntity
    {

        /// <summary>
        /// Teacher_Paper表实体
        ///</summary>
        public Teacher_PaperEntity()
        {
        }


        /// <summary>
        /// Teacher_Paper表实体
        /// </summary>
        /// <param name="tpid">ID</param>
        /// <param name="tid">教师ID</param>
        /// <param name="publication">发表刊物名称</param>
        /// <param name="papername">论文名称</param>
        /// <param name="pubdate">发表年月</param>
        /// <param name="volume">卷号</param>
        /// <param name="termnum">期号</param>
        /// <param name="endpage">结束页码</param>
        /// <param name="uroles">本人角色</param>
        /// <param name="subjectarea">学科领域</param>
        /// <param name="included">论文收录情况</param>
        /// <param name="isdel">是否删除</param>
        public Teacher_PaperEntity(string tpid, string tid, string publication, string papername, DateTime pubdate, string volume, string termnum, int endpage, int uroles, string subjectarea, int included, int isdel)
        {
            this.TPID = tpid;
            this.TID = tid;
            this.Publication = publication;
            this.PaperName = papername;
            this.PubDate = pubdate;
            this.Volume = volume;
            this.TermNum = termnum;
            this.EndPage = endpage;
            this.URoles = uroles;
            this.SubjectArea = subjectarea;
            this.Included = included;
            this.Isdel = isdel;
        }

        private string tpid;//ID
        private string tid;//教师ID
        private string publication;//发表刊物名称
        private string papername;//论文名称
        private DateTime pubdate;//发表年月
        private string volume;//卷号
        private string termnum;//期号
        private int endpage;//结束页码
        private int uroles;//本人角色
        private string subjectarea;//学科领域
        private int included;//论文收录情况
        private int isdel;//是否删除
        public string IncludedName { get; set; }
        public string SubjectAreaName { get; set; }
        public int BeginPage { get; set; }
        public int IsReport { get; set; }
        public string TeacherName { get; set; }
        ///<summary>
        ///ID
        ///</summary>
        public string TPID
        {
            get
            {
                return tpid;
            }
            set
            {
                tpid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TID
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
        ///发表刊物名称
        ///</summary>
        public string Publication
        {
            get
            {
                return publication;
            }
            set
            {
                publication = value;
            }
        }

        ///<summary>
        ///论文名称
        ///</summary>
        public string PaperName
        {
            get
            {
                return papername;
            }
            set
            {
                papername = value;
            }
        }

        ///<summary>
        ///发表年月
        ///</summary>
        public DateTime PubDate
        {
            get
            {
                return pubdate;
            }
            set
            {
                pubdate = value;
            }
        }

        ///<summary>
        ///卷号
        ///</summary>
        public string Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        ///<summary>
        ///期号
        ///</summary>
        public string TermNum
        {
            get
            {
                return termnum;
            }
            set
            {
                termnum = value;
            }
        }

        ///<summary>
        ///结束页码
        ///</summary>
        public int EndPage
        {
            get
            {
                return endpage;
            }
            set
            {
                endpage = value;
            }
        }

        ///<summary>
        ///本人角色
        ///</summary>
        public int URoles
        {
            get
            {
                return uroles;
            }
            set
            {
                uroles = value;
            }
        }

        ///<summary>
        ///学科领域
        ///</summary>
        public string SubjectArea
        {
            get
            {
                return subjectarea;
            }
            set
            {
                subjectarea = value;
            }
        }

        ///<summary>
        ///论文收录情况
        ///</summary>
        public int Included
        {
            get
            {
                return included;
            }
            set
            {
                included = value;
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

