/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年02月13日 08点59分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Questionnaire_SubjectEntity
    {

        /// <summary>
        /// Questionnaire_Subject表实体
        ///</summary>
        public Questionnaire_SubjectEntity()
        {
        }


        /// <summary>
        /// Questionnaire_Subject表实体
        /// </summary>
        /// <param name="qsid">题目ID</param>
        /// <param name="qid">问卷ID</param>
        /// <param name="subcontent">题目内容</param>
        /// <param name="subtype">题目类型</param>
        public Questionnaire_SubjectEntity(int qsid, string qid, string subcontent, int subtype)
        {
            this.QSID = qsid;
            this.QID = qid;
            this.SubContent = subcontent;
            this.SubType = subtype;
        }

        private int qsid;//题目ID
        private string qid;//问卷ID
        private string subcontent;//题目内容
        private int subtype;//题目类型


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
        ///题目内容
        ///</summary>
        public string SubContent
        {
            get
            {
                return subcontent;
            }
            set
            {
                subcontent = value;
            }
        }

        ///<summary>
        ///题目类型
        ///</summary>
        public int SubType
        {
            get
            {
                return subtype;
            }
            set
            {
                subtype = value;
            }
        }
    }
}
