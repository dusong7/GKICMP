/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月21日 05点33分
** 描   述:      司机信息实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class DriverEntity
    {

        /// <summary>
        /// Driver表实体
        ///</summary>
        public DriverEntity()
        {
        }


        /// <summary>
        /// Driver表实体
        /// </summary>
        /// <param name="did">司机ID</param>
        /// <param name="sysuid">用户ID</param>
        /// <param name="drivercode">驾驶证号</param>
        /// <param name="fristgetdate">初次领证日期</param>
        /// <param name="stype">准驾车型</param>
        /// <param name="ddesc">备注</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入日期</param>
        public DriverEntity(int did, string sysuid, string drivercode, DateTime fristgetdate, int stype, string ddesc, string createuser, DateTime createdate)
        {
            this.DID = did;
            this.SysUid = sysuid;
            this.DriverCode = drivercode;
            this.FristGetDate = fristgetdate;
            this.SType = stype;
            this.DDesc = ddesc;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
        }

        private int did;//司机ID
        private string sysuid;//用户ID
        private string drivercode;//驾驶证号
        private DateTime fristgetdate;//初次领证日期
        private int stype;//准驾车型
        private string ddesc;//备注
        private string createuser;//录入人
        private DateTime createdate;//录入日期
        private int userSex;
        private string realName;
        private string cellPhone;
        private DateTime birthDay;
        public string CellPhone
        {
            get { return cellPhone; }
            set { cellPhone = value; }
        }


        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }






        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }



        public int UserSex
        {
            get { return userSex; }
            set { userSex = value; }
        }
      

        ///<summary>
        ///司机ID
        ///</summary>
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

        ///<summary>
        ///用户ID
        ///</summary>
        public string SysUid
        {
            get
            {
                return sysuid;
            }
            set
            {
                sysuid = value;
            }
        }

        ///<summary>
        ///驾驶证号
        ///</summary>
        public string DriverCode
        {
            get
            {
                return drivercode;
            }
            set
            {
                drivercode = value;
            }
        }

        ///<summary>
        ///初次领证日期
        ///</summary>
        public DateTime FristGetDate
        {
            get
            {
                return fristgetdate;
            }
            set
            {
                fristgetdate = value;
            }
        }

        ///<summary>
        ///准驾车型
        ///</summary>
        public int SType
        {
            get
            {
                return stype;
            }
            set
            {
                stype = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string DDesc
        {
            get
            {
                return ddesc;
            }
            set
            {
                ddesc = value;
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
        ///录入日期
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
    }
}

