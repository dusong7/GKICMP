/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09点35分
** 描   述:      部门实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class DepartmentEntity
    {

        public DepartmentEntity()
        {
        }

        public DepartmentEntity(string depname, int isdel)
        {
            this.DepName = depname;
            this.Isdel = isdel;
        }

        private int did;   //部门ID
        private string depname; //部门名称
        private string master;  //部门负责人
        private string depmark;  //部门简述
        private int gid;        //所属年级
        private int deporder;   //排序
        private int deptype;   //类型
        private int isdisplayweb;  //是否展现
        private int isdel;   //是否删除
        private int cid;   //所属校区
        public string OtherName { get; set; }
        private string uIDName;

        public int CID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
            }
        }

        public string UIDName
        {
            get { return uIDName; }
            set { uIDName = value; }
        }
        public int DID
        {
            get
            {
                return did;
            }
            set
            {
                did = value;
            }
        }

        public string DepName
        {
            get
            {
                return depname;
            }
            set
            {
                depname = value;
            }
        }

        public string Master
        {
            get
            {
                return master;
            }
            set
            {
                master = value;
            }
        }

        public string DepMark
        {
            get
            {
                return depmark;
            }
            set
            {
                depmark = value;
            }
        }

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

        public int DepOrder
        {
            get
            {
                return deporder;
            }
            set
            {
                deporder = value;
            }
        }

        public int DepType
        {
            get
            {
                return deptype;
            }
            set
            {
                deptype = value;
            }
        }

        public int IsDisplayInWeb
        {
            get
            {
                return isdisplayweb;
            }
            set
            {
                isdisplayweb = value;
            }
        }

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
