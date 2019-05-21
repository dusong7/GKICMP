/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 03点21分
** 描   述:      评分标准实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Lecture_StandardEntity
    {

        /// <summary>
        /// Lecture_Standard表实体
        ///</summary>
        public Lecture_StandardEntity()
        {
        }


        /// <summary>
        /// Lecture_Standard表实体
        /// </summary>
        /// <param name="lsid">ID</param>
        /// <param name="standardcontent">打分标准</param>
        /// <param name="lscore">对应分数</param>
        /// <param name="parentid">父级ID</param>
        /// <param name="sorder">排序</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="isdel">是否删除</param>
        public Lecture_StandardEntity(int lsid, string standardcontent, int lscore, int parentid, int sorder, string createuser, DateTime createdate, int isdel)
        {
            this.LSID = lsid;
            this.StandardContent = standardcontent;
            this.LScore = lscore;
            this.ParentID = parentid;
            this.SOrder = sorder;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private int lsid;//ID
        private string standardcontent;//打分标准
        private int lscore;//对应分数
        private int parentid;//父级ID
        private int sorder;//排序
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private int isdel;//是否删除
        private int lsflag;//标识 1：听课标准 2：考核标准
        private int pfid;//考核标准ID

        /// <summary>
        /// 标识 1：听课标准 2：考核标准
        /// </summary>
        public int LSFlag
        {
            get { return lsflag; }
            set { lsflag = value; }
        }

        /// <summary>
        /// 考核标准ID
        /// </summary>
        public int PFID
        {
            get { return pfid; }
            set { pfid = value; }
        }

        ///<summary>
        ///ID
        ///</summary>
        public int LSID
        {
            get
            {
                return lsid;
            }
            set
            {
                lsid = value;
            }
        }

        ///<summary>
        ///打分标准
        ///</summary>
        public string StandardContent
        {
            get
            {
                return standardcontent;
            }
            set
            {
                standardcontent = value;
            }
        }

        ///<summary>
        ///对应分数
        ///</summary>
        public int LScore
        {
            get
            {
                return lscore;
            }
            set
            {
                lscore = value;
            }
        }

        ///<summary>
        ///父级ID
        ///</summary>
        public int ParentID
        {
            get
            {
                return parentid;
            }
            set
            {
                parentid = value;
            }
        }

        ///<summary>
        ///排序
        ///</summary>
        public int SOrder
        {
            get
            {
                return sorder;
            }
            set
            {
                sorder = value;
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

