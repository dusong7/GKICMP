/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月24日 05点33分
** 描   述:      评论实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SpaceCommentEntity
    {

        /// <summary>
        /// SpaceComment表实体
        ///</summary>
        public SpaceCommentEntity()
        {
        }


        /// <summary>
        /// SpaceComment表实体
        /// </summary>
        /// <param name="egid">日志ID</param>
        /// <param name="sysid">用户ID</param>
        /// <param name="scomment">评论内容</param>
        /// <param name="scdate">发布时间</param>
        /// <param name="objectid">对象ID</param>
        /// <param name="scflag">Flag</param>
        public SpaceCommentEntity(int egid, string sysid, string mcontent, DateTime createdate, int objectid, int scflag)
        {
            this.EGID = egid;
            this.SysID = sysid;
            this.MContent = mcontent;
            this.CreateDate = createdate;
            this.ObjectID = objectid;
            this.SCFlag = scflag;
        }

        private int egid;//日志ID
        private string sysid;//用户ID
        private string mcontent;//评论内容
        private DateTime createdate;//发布时间
        private int objectid;//对象ID
        private int scflag;//Flag 1:日志 2：照片 3：留言


        ///<summary>
        ///日志ID
        ///</summary>
        public int EGID
        {
            get
            {
                return egid;
            }
            set
            {
                egid = value;
            }
        }

        ///<summary>
        ///用户ID
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
        ///评论内容
        ///</summary>
        public string MContent
        {
            get
            {
                return mcontent;
            }
            set
            {
                mcontent = value;
            }
        }

        ///<summary>
        ///发布时间
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
        ///对象ID
        ///</summary>
        public int ObjectID
        {
            get
            {
                return objectid;
            }
            set
            {
                objectid = value;
            }
        }

        ///<summary>
        ///Flag
        ///</summary>
        public int SCFlag
        {
            get
            {
                return scflag;
            }
            set
            {
                scflag = value;
            }
        }
    }
}