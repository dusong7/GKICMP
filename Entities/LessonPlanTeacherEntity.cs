/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月19日 03点26分
** 描   述:      执教教师实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LessonPlan_TeacherEntity
    {

        /// <summary>
        /// LessonPlan_Teacher表实体
        ///</summary>
        public LessonPlan_TeacherEntity()
        {
        }


        /// <summary>
        /// LessonPlan_Teacher表实体
        /// </summary>
        /// <param name="ltid"></param>
        /// <param name="lid"></param>
        /// <param name="teachid"></param>
        /// <param name="flag"></param>
        public LessonPlan_TeacherEntity(string ltid, string lid, string teachid, int flag)
        {
            this.LTID = ltid;
            this.LID = lid;
            this.TeachID = teachid;
            this.Flag = flag;
        }

        private string ltid;//
        private string lid;//计划ID
        private string teachid;//教师ID
        private int flag;//标识


        ///<summary>
        ///ID
        ///</summary>
        public string LTID
        {
            get
            {
                return ltid;
            }
            set
            {
                ltid = value;
            }
        }

        ///<summary>
        ///计划ID
        ///</summary>
        public string LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TeachID
        {
            get
            {
                return teachid;
            }
            set
            {
                teachid = value;
            }
        }

        ///<summary>
        ///标识
        ///</summary>
        public int Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }
    }
}

