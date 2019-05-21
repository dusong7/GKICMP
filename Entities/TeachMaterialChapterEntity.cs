/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年06月01日 03点00分
** 描   述:      教材章节实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class TeachMaterial_ChapterEntity
    {

        /// <summary>
        /// TeachMaterial_Chapter表实体
        ///</summary>
        public TeachMaterial_ChapterEntity()
        {
        }


        /// <summary>
        /// TeachMaterial_Chapter表实体
        /// </summary>
        /// <param name="tcid">章节ID</param>
        /// <param name="tmid">教材ID</param>
        /// <param name="chaptername">章节名称</param>
        /// <param name="chaptercontent">内容</param>
        public TeachMaterial_ChapterEntity( int tmid, string chaptername)
        {
            this.TMID = tmid;
            this.ChapterName = chaptername;
        }

        private int tcid;//章节ID
        private int tmid;//教材ID
        private string chaptername;//章节名称
        private string chaptercontent;//内容


        ///<summary>
        ///章节ID
        ///</summary>
        public int TCID
        {
            get
            {
                return tcid;
            }
            set
            {
                tcid = value;
            }
        }

        ///<summary>
        ///教材ID
        ///</summary>
        public int TMID
        {
            get
            {
                return tmid;
            }
            set
            {
                tmid = value;
            }
        }

        ///<summary>
        ///章节名称
        ///</summary>
        public string ChapterName
        {
            get
            {
                return chaptername;
            }
            set
            {
                chaptername = value;
            }
        }

        ///<summary>
        ///内容
        ///</summary>
        public string ChapterContent
        {
            get
            {
                return chaptercontent;
            }
            set
            {
                chaptercontent = value;
            }
        }
    }
}