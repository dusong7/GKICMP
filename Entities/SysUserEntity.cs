/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      fsc
** 创建日期:      2017年02月27日 04点50分
** 描   述:      用户实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GK.GKICMP.Entities
{
    public class SysUserEntity
    {
        /// <summary>
        /// SysUser实体
        /// </summary>
        public SysUserEntity()
        {

        }

        public SysUserEntity(int usertype, int isdel)
        {
            this.UserType = usertype;
            this.Isdel = isdel;
        }

        private string uid;//用户ID
        private string username;//用户名
        private string idcard;//身份证号码
        private string userpwd;//密码
        private string cellphone;//手机号码
        private string address;//家庭住址
        private string companynum;//公司座机
        private string mailnum;//邮箱
        private string qqnum;//QQ号码
        private string weinum;//微信号
        private DateTime birthday;//出生年月
        private int usersex;//性别
        private int usertype;//用户类别
        private string realname;//姓名
        private DateTime createdate;//创建日期
        private string createuser;//创建人
        private int nation;//民族
        private string photos;//照片
        private DateTime lastdate;//最后一次登录时间
        private int ustate;//状态
        private string userdesc;//描述
        private string cardnum;//一卡通
        private int isdel;//是否删除
        private string depid;//部门
        public string DepID { get { return depid; } set { depid = value; } }
        public string DepName { get; set; }
        private string uStateName;
        private string gradeName;
        private int isSeries;
        private int cid;//校区
        private string campusname;//校区名称

        private string classid;//班级
        private string roleid;//角色

        private int higheducation;//家长最高学历
        private int levelcommunication;//交流水平

        public int HighEducation
        {
            get { return higheducation; }
            set { higheducation = value; }
        }
        public int LevelCommunication
        {
            get { return levelcommunication; }
            set { levelcommunication = value; }
        }

        public string ClassID { get { return classid; } set { classid = value; } }
        public string RoleID { get { return roleid; } set { roleid = value; } }
        public int ASID { get; set; }
        public string FaceNum { get; set; }
        public int Followed { get; set; }
        /// <summary>
        /// 校区
        /// </summary>
        public int CID
        {
            get { return cid; }
            set { cid = value; }
        }

        /// <summary>
        /// 校区名称
        /// </summary>
        public string CampusName
        {
            get
            {
                return campusname;
            }
            set
            {
                campusname = value;
            }
        }


        public int IsSeries
        {
            get { return isSeries; }
            set { isSeries = value; }
        }

        public string UserID { get; set; }//微信用户的userid（可直接使用userid发送微信消息）
        public decimal Mark { get; set; }
        public string UStateName
        {
            get { return uStateName; }
            set { uStateName = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
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

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IDCard
        {
            get
            {
                return idcard;
            }
            set
            {
                idcard = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd
        {
            get
            {
                return userpwd;
            }
            set
            {
                userpwd = value;
            }
        }

        /// <summary>
        /// 手机号码
        /// </summary>
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

        /// <summary>
        /// 家庭住址
        /// </summary>
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        /// <summary>
        /// 办公座机
        /// </summary>
        public string CompanyNum
        {
            get
            {
                return companynum;
            }
            set
            {
                companynum = value;
            }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string MailNum
        {
            get
            {
                return mailnum;
            }
            set
            {
                mailnum = value;
            }
        }

        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQNum
        {
            get
            {
                return qqnum;
            }
            set
            {
                qqnum = value;
            }
        }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WeiNum
        {
            get
            {
                return weinum;
            }
            set
            {
                weinum = value;
            }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDay
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public int UserSex
        {
            get
            {
                return usersex;
            }
            set
            {
                usersex = value;
            }
        }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType
        {
            get
            {
                return usertype;
            }
            set
            {
                usertype = value;
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            get
            {
                return realname;
            }
            set
            {
                realname = value;
            }
        }

        /// <summary>
        /// 创建日期
        /// </summary>
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

        /// <summary>
        /// 创建人
        /// </summary>
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

        /// <summary>
        /// 民族
        /// </summary>
        public int Nation
        {
            get
            {
                return nation;
            }
            set
            {
                nation = value;
            }
        }

        /// <summary>
        /// 照片
        /// </summary>
        public string Photos
        {
            get
            {
                return photos;
            }
            set
            {
                photos = value;
            }
        }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastDate
        {
            get
            {
                return lastdate;
            }
            set
            {
                lastdate = value;
            }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int UState
        {
            get
            {
                return ustate;
            }
            set
            {
                ustate = value;
            }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string UserDesc
        {
            get
            {
                return userdesc;
            }
            set
            {
                userdesc = value;
            }
        }

        /// <summary>
        ///  一卡通
        /// </summary>
        public string CardNum
        {
            get
            {
                return cardnum;
            }
            set
            {
                cardnum = value;
            }
        }
        public string Roles { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
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
