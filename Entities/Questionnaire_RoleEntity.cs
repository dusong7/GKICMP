/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年02月10日 02点10分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Questionnaire_RoleEntity
    {

        /// <summary>
        /// Questionnaire_Role表实体
        ///</summary>
        public Questionnaire_RoleEntity()
        {
        }


        /// <summary>
        /// Questionnaire_Role表实体
        /// </summary>
        /// <param name="qid">ID</param>
        /// <param name="roleid">角色ID</param>
        public Questionnaire_RoleEntity(string qid, int roleid)
        {
            this.QID = qid;
            this.RoleID = roleid;
        }

        private string qid;//ID
        private int roleid;//角色ID


        ///<summary>
        ///ID
        ///</summary>
        public string QID
        {
            get
            {
                return qid;
            }
            set
            {
                qid = value;
            }
        }

        ///<summary>
        ///角色ID
        ///</summary>
        public int RoleID
        {
            get
            {
                return roleid;
            }
            set
            {
                roleid = value;
            }
        }
    }
}
