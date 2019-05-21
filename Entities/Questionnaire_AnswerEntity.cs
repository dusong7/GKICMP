/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年03月27日 05点08分
** 描   述:      文件调查答题管理实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Questionnaire_AnswerEntity
    {

        /// <summary>
        /// Questionnaire_Answer表实体
        ///</summary>
        public Questionnaire_AnswerEntity()
        {
        }


        /// <summary>
        /// Questionnaire_Answer表实体
        /// </summary>
        /// <param name="qaid">ID</param>
        /// <param name="uid">答卷人ID</param>
        /// <param name="qid">问卷ID</param>
        /// <param name="qsid">题目ID</param>
        /// <param name="oid">答案</param>
        public Questionnaire_AnswerEntity(string qaid, string uid, string qid, int qsid, string oid)
        {
            this.QAID = qaid;
            this.UID = uid;
            this.QID = qid;
            this.QSID = qsid;
            this.OID = oid;
        }

        private string qaid;//ID
        private string uid;//答卷人ID
        private string qid;//问卷ID
        private int qsid;//题目ID
        private string oid;//答案


        ///<summary>
        ///ID
        ///</summary>
        public string QAID
        {
            get
            {
                return qaid;
            }
            set
            {
                qaid = value;
            }
        }

        ///<summary>
        ///答卷人ID
        ///</summary>
        public string UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }

        ///<summary>
        ///问卷ID
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
        ///题目ID
        ///</summary>
        public int QSID
        {
            get
            {
                return qsid;
            }
            set
            {
                qsid = value;
            }
        }

        ///<summary>
        ///答案
        ///</summary>
        public string OID
        {
            get
            {
                return oid;
            }
            set
            {
                oid = value;
            }
        }
    }
}

