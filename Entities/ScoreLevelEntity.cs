/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年10月19日 03点37分
** 描   述:      分数等级实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class ScoreLevelEntity
    {

        /// <summary>
        /// ScoreLevel表实体
        ///</summary>
        public ScoreLevelEntity()
        {
        }


        /// <summary>
        /// ScoreLevel表实体
        /// </summary>
        /// <param name="slid">ID</param>
        /// <param name="gid">年级</param>
        /// <param name="bscore">开始分数</param>
        /// <param name="escore">结束分数</param>
        /// <param name="slname">等级名称</param>
        public ScoreLevelEntity(int slid, int gid, int bscore, int escore, string slname)
        {
            this.SLID = slid;
            this.GID = gid;
            this.BScore = bscore;
            this.EScore = escore;
            this.SLName = slname;
        }

        private int slid;//ID
        private int gid;//年级
        private int bscore;//开始分数
        private int escore;//结束分数
        private string slname;//等级名称
        private int cID;//课程
        private string gIDS;//年级名称

        public string GIDS
        {
            get { return gIDS; }
            set { gIDS = value; }
        }

        public int CID
        {
            get { return cID; }
            set { cID = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public int SLID
        {
            get
            {
                return slid;
            }
            set
            {
                slid = value;
            }
        }

        ///<summary>
        ///年级
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
        ///开始分数
        ///</summary>
        public int BScore
        {
            get
            {
                return bscore;
            }
            set
            {
                bscore = value;
            }
        }

        ///<summary>
        ///结束分数
        ///</summary>
        public int EScore
        {
            get
            {
                return escore;
            }
            set
            {
                escore = value;
            }
        }

        ///<summary>
        ///等级名称
        ///</summary>
        public string SLName
        {
            get
            {
                return slname;
            }
            set
            {
                slname = value;
            }
        }
    }
}

