/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      ygb
** 创建日期:      2017年02月27日 09点15分
** 描   述:      年级类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class GradeEntity
    {

        /// <summary>
        /// Grade表实体
        ///</summary>
        public GradeEntity()
        {
        }


        /// <summary>
        /// Grade表实体
        /// </summary>
        /// <param name="gid">ID</param>
        /// <param name="gradename">年级名称</param>
        /// <param name="gradeyear">开学日期</param>
        /// <param name="isgraduate">是否毕业</param>
        /// <param name="graduatephoto">毕业照</param>
        /// <param name="shortname"></param>
        /// <param name="gradeduty"></param>
        /// <param name="createdate"></param>
        /// <param name="notes">备注</param>
        /// <param name="isdel">是否删除</param>
        public GradeEntity(int gid, string gradename, int gradeyear, int isgraduate, string graduatephoto, int shortname, string gradeduty, DateTime createdate, string notes, int isdel)
        {
            this.GID = gid;
            this.GradeName = gradename;
            this.GradeYear = gradeyear;
            this.IsGraduate = isgraduate;
            this.GraduatePhoto = graduatephoto;
            this.ShortName = shortname;
            this.GradeDuty = gradeduty;
            this.CreateDate = createdate;
            this.Notes = notes;
            this.Isdel = isdel;
        }

        private int gid;//ID
        private string gradename;//年级名称
        private int gradeyear;//开学日期
        private int isgraduate;//是否毕业
        private string graduatephoto;//毕业照
        private int shortname;//
        private string gradeduty;//
        private DateTime createdate;//
        private string notes;//备注
        private int isdel;//是否删除
        private string shortGName;

        public string ShortGName
        {
            get { return shortGName; }
            set { shortGName = value; }
        }

        private int classcount;//班级数
        public int ClassCount
        {
            get
            {
                return classcount;
            }
            set
            {
                classcount = value;
            }
        }
        public string GradeDutyName { get; set; }
        ///<summary>
        ///ID
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
        ///年级名称
        ///</summary>
        public string GradeName
        {
            get
            {
                return gradename;
            }
            set
            {
                gradename = value;
            }
        }

        ///<summary>
        ///开学日期
        ///</summary>
        public int GradeYear
        {
            get
            {
                return gradeyear;
            }
            set
            {
                gradeyear = value;
            }
        }

        ///<summary>
        ///是否毕业
        ///</summary>
        public int IsGraduate
        {
            get
            {
                return isgraduate;
            }
            set
            {
                isgraduate = value;
            }
        }

        ///<summary>
        ///毕业照
        ///</summary>
        public string GraduatePhoto
        {
            get
            {
                return graduatephoto;
            }
            set
            {
                graduatephoto = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int ShortName
        {
            get
            {
                return shortname;
            }
            set
            {
                shortname = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string GradeDuty
        {
            get
            {
                return gradeduty;
            }
            set
            {
                gradeduty = value;
            }
        }

        ///<summary>
        ///
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
        ///备注
        ///</summary>
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
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

