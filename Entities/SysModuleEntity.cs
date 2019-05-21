/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月04日 09点24分
** 描   述:      模块实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SysModuleEntity
    {

        /// <summary>
        /// SysModule表实体
        ///</summary>
        public SysModuleEntity()
        {
        }


        /// <summary>
        /// SysModule表实体
        /// </summary>
        /// <param name="moduleid">模块ID</param>
        /// <param name="modulename">模块名称</param>
        /// <param name="moduleurl">链接地址</param>
        /// <param name="moduleicon">图标</param>
        /// <param name="parentid">父级ID</param>
        /// <param name="moduleorder">排序</param>
        /// <param name="isright">是否有效 1:有效 -：无效</param>
        /// <param name="modulebutton">模块按钮</param>
        public SysModuleEntity(int moduleid, string modulename, string moduleurl, string moduleicon, int parentid, int moduleorder, int isright, string modulebutton)
        {
            this.ModuleID = moduleid;
            this.ModuleName = modulename;
            this.ModuleUrl = moduleurl;
            this.ModuleIcon = moduleicon;
            this.ParentID = parentid;
            this.ModuleOrder = moduleorder;
            this.IsRight = isright;
            this.ModuleButton = modulebutton;
        }

        private int moduleid;//模块ID
        private string modulename;//模块名称
        private string moduleurl;//链接地址
        private string moduleicon;//图标
        private int parentid;//父级ID
        private int moduleorder;//排序
        private int isright;//是否有效 1:有效 -：无效
        private string modulebutton;//模块按钮
        private string parentname;

        public string ParentName
        {
            get { return parentname; }
            set { parentname = value; }
        }



        ///<summary>
        ///模块ID
        ///</summary>
        public int ModuleID
        {
            get
            {
                return moduleid;
            }
            set
            {
                moduleid = value;
            }
        }

        ///<summary>
        ///模块名称
        ///</summary>
        public string ModuleName
        {
            get
            {
                return modulename;
            }
            set
            {
                modulename = value;
            }
        }

        ///<summary>
        ///链接地址
        ///</summary>
        public string ModuleUrl
        {
            get
            {
                return moduleurl;
            }
            set
            {
                moduleurl = value;
            }
        }

        ///<summary>
        ///图标
        ///</summary>
        public string ModuleIcon
        {
            get
            {
                return moduleicon;
            }
            set
            {
                moduleicon = value;
            }
        }

        ///<summary>
        ///父级ID
        ///</summary>
        public int ParentID
        {
            get
            {
                return parentid;
            }
            set
            {
                parentid = value;
            }
        }

        ///<summary>
        ///排序
        ///</summary>
        public int ModuleOrder
        {
            get
            {
                return moduleorder;
            }
            set
            {
                moduleorder = value;
            }
        }

        ///<summary>
        ///是否有效 1:有效 -：无效
        ///</summary>
        public int IsRight
        {
            get
            {
                return isright;
            }
            set
            {
                isright = value;
            }
        }

        ///<summary>
        ///模块按钮
        ///</summary>
        public string ModuleButton
        {
            get
            {
                return modulebutton;
            }
            set
            {
                modulebutton = value;
            }
        }
    }
}

