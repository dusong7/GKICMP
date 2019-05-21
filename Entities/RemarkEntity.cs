/*****************************************************************
** Copyright (c) 芜湖易通信息技术有限公司
** 创 建 人:      ygb
** 创建日期:      2018年01月04日 05点34分
** 描   述:      评语库类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class RemarkEntity
    {

        /// <summary>
        /// Remark表实体
        ///</summary>
        public RemarkEntity()
        {
        }


        /// <summary>
        /// Remark表实体
        /// </summary>
        /// <param name="rid">ID</param>
        /// <param name="remarkcontent">评语内容</param>
        /// <param name="createuser">创建人</param>
        /// <param name="createdate">创建时间</param>
        /// <param name="isdel">是否删除</param>
        public RemarkEntity(int rid, string remarkcontent, string createuser, DateTime createdate, int isdel)
        {
            this.RID = rid;
            this.RemarkContent = remarkcontent;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private int rid;//ID
        private string remarkcontent;//评语内容
        private string createuser;//创建人
        private DateTime createdate;//创建时间
        private int isdel;//是否删除
        private string createusername;


        public string CreateUserName
        {
            get
            {
                return createusername;
            }
            set
            {
                createusername = value;
            }
        }

        ///<summary>
        ///ID
        ///</summary>
        public int RID
        {
            get
            {
                return rid;
            }
            set
            {
                rid = value;
            }
        }

        ///<summary>
        ///评语内容
        ///</summary>
        public string RemarkContent
        {
            get
            {
                return remarkcontent;
            }
            set
            {
                remarkcontent = value;
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

