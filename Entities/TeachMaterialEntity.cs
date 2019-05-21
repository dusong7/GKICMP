/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年05月27日 09点20分
** 描   述:      教材实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class TeachMaterialEntity
    {

        /// <summary>
        /// TeachMaterial表实体
        ///</summary>
        public TeachMaterialEntity()
        {
        }


        public TeachMaterialEntity(string tmname, int tedition, int tmcourses, int isdel)
        {
            this.TMName = tmname;
            this.TEdition = tedition;
            this.TMCourses = tmcourses;
            this.Isdel = isdel;
        }

        private int tmid;//教材ID
        private string tmname;//教材名称
        private int tedition;//所属版本
        private int tmcourses;//适用课程
        private int gid;//所属年级
        private int termid;//学期
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private int isdel;//是否删除


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
        ///教材名称
        ///</summary>
        public string TMName
        {
            get
            {
                return tmname;
            }
            set
            {
                tmname = value;
            }
        }

        ///<summary>
        ///所属版本
        ///</summary>
        public int TEdition
        {
            get
            {
                return tedition;
            }
            set
            {
                tedition = value;
            }
        }

        ///<summary>
        ///适用课程
        ///</summary>
        public int TMCourses
        {
            get
            {
                return tmcourses;
            }
            set
            {
                tmcourses = value;
            }
        }

        ///<summary>
        ///所属年级
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
        ///学期
        ///</summary>
        public int TermID
        {
            get
            {
                return termid;
            }
            set
            {
                termid = value;
            }
        }

        ///<summary>
        ///录入人
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
        ///录入时间
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

