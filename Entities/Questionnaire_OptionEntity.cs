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

    public class Questionnaire_OptionEntity
    {

        /// <summary>
        /// Questionnaire_Option表实体
        ///</summary>
        public Questionnaire_OptionEntity()
        {
        }


        /// <summary>
        /// Questionnaire_Option表实体
        /// </summary>
        /// <param name="oid">选项ID</param>
        /// <param name="qsid">题目ID</param>
        /// <param name="optioncontent">选项内容</param>
        /// <param name="optionvlaue">选项值</param>
        public Questionnaire_OptionEntity(int oid, int qsid, string optioncontent, string optionvlaue)
        {
            this.OID = oid;
            this.QSID = qsid;
            this.OptionContent = optioncontent;
            this.OptionVlaue = optionvlaue;
        }

        private int oid;//选项ID
        private int qsid;//题目ID
        private string optioncontent;//选项内容
        private string optionvlaue;//选项值


        ///<summary>
        ///选项ID
        ///</summary>
        public int OID
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
        ///选项内容
        ///</summary>
        public string OptionContent
        {
            get
            {
                return optioncontent;
            }
            set
            {
                optioncontent = value;
            }
        }

        ///<summary>
        ///选项值
        ///</summary>
        public string OptionVlaue
        {
            get
            {
                return optionvlaue;
            }
            set
            {
                optionvlaue = value;
            }
        }
    }
}
