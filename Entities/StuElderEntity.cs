/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年09月01日 09点53分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class StuElderEntity
    {

        /// <summary>
        /// StuElder表实体
        ///</summary>
        public StuElderEntity()
        {
        }


        /// <summary>
        /// StuElder表实体
        /// </summary>
        /// <param name="pid">父母ID</param>
        /// <param name="stuid">学生ID</param>
        /// <param name="eldername">姓名</param>
        /// <param name="postdep">工作单位</param>
        /// <param name="cellphone">手机号码</param>
        /// <param name="postname">职务</param>
        /// <param name="epwd">密码</param>
        /// <param name="shipname">关系</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入时间</param>
        /// <param name="isdel">是否删除</param>
        public StuElderEntity(string pid, string stuid, string eldername, string postdep, string cellphone, string postname, string epwd, string shipname, string createuser, DateTime createdate, int isdel)
        {
            this.PID = pid;
            this.StuID = stuid;
            this.ElderName = eldername;
            this.PostDep = postdep;
            this.CellPhone = cellphone;
            this.PostName = postname;
            this.Epwd = epwd;
            this.ShipName = shipname;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string pid;//父母ID
        private string stuid;//学生ID
        private string eldername;//姓名
        private string postdep;//工作单位
        private string cellphone;//手机号码
        private string postname;//职务
        private string epwd;//密码
        private string shipname;//关系
        private string createuser;//录入人
        private DateTime createdate;//录入时间
        private int isdel;//是否删除


        ///<summary>
        ///父母ID
        ///</summary>
        public string PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        ///<summary>
        ///学生ID
        ///</summary>
        public string StuID
        {
            get
            {
                return stuid;
            }
            set
            {
                stuid = value;
            }
        }

        ///<summary>
        ///姓名
        ///</summary>
        public string ElderName
        {
            get
            {
                return eldername;
            }
            set
            {
                eldername = value;
            }
        }

        ///<summary>
        ///工作单位
        ///</summary>
        public string PostDep
        {
            get
            {
                return postdep;
            }
            set
            {
                postdep = value;
            }
        }

        ///<summary>
        ///手机号码
        ///</summary>
        public string CellPhone
        {
            get
            {
                return cellphone;
            }
            set
            {
                cellphone = value;
            }
        }

        ///<summary>
        ///职务
        ///</summary>
        public string PostName
        {
            get
            {
                return postname;
            }
            set
            {
                postname = value;
            }
        }

        ///<summary>
        ///密码
        ///</summary>
        public string Epwd
        {
            get
            {
                return epwd;
            }
            set
            {
                epwd = value;
            }
        }

        ///<summary>
        ///关系
        ///</summary>
        public string ShipName
        {
            get
            {
                return shipname;
            }
            set
            {
                shipname = value;
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

