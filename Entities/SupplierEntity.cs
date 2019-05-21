/*****************************************************************
** Copyright (c) 芜湖易通信息技术有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2016年11月09日 03点23分
** 描   述:      供应商实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SupplierEntity
    {

        /// <summary>
        /// Supplier表实体
        ///</summary>
        public SupplierEntity()
        {
        }


        /// <summary>
        /// Supplier表实体
        /// </summary>
        /// <param name="sdid">ID</param>
        /// <param name="suppliername">供应商名称</param>
        /// <param name="enterprise">企业性质</param>
        /// <param name="linkuser">业务联系人</param>
        /// <param name="linkpost">联系人职务</param>
        /// <param name="linkphone">业务联系电话</param>
        /// <param name="mainassest">主要经营范围</param>
        /// <param name="bankname">开户行</param>
        /// <param name="banknum">开户账号</param>
        /// <param name="qualifications">资信等级</param>
        /// <param name="legal">企业法人</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="isdel">是否删除</param>
        public SupplierEntity(string sdid, string suppliername, string enterprise, string linkuser, string linkpost, string linkphone, string mainassest, string bankname, string banknum, string qualifications, string legal, string createuser, DateTime createdate, int isdel)
        {
            this.SDID = sdid;
            this.SupplierName = suppliername;
            this.Enterprise = enterprise;
            this.LinkUser = linkuser;
            this.LinkPost = linkpost;
            this.LinkPhone = linkphone;
            this.MainAssest = mainassest;
            this.BankName = bankname;
            this.BankNum = banknum;
            this.Qualifications = qualifications;
            this.Legal = legal;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
        }

        private string sdid;//ID
        private string suppliername;//供应商名称
        private string enterprise;//企业性质
        private string linkuser;//业务联系人
        private string linkpost;//联系人职务
        private string linkphone;//业务联系电话
        private string mainassest;//主要经营范围
        private string bankname;//开户行
        private string banknum;//开户账号
        private string qualifications;//资信等级
        private string legal;//企业法人
        private string createuser;//录入人
        private DateTime createdate;//录入日期
        private int isdel;//是否删除


        ///<summary>
        ///ID
        ///</summary>
        public string SDID
        {
            get
            {
                return sdid;
            }
            set
            {
                sdid = value;
            }
        }

        ///<summary>
        ///供应商名称
        ///</summary>
        public string SupplierName
        {
            get
            {
                return suppliername;
            }
            set
            {
                suppliername = value;
            }
        }

        ///<summary>
        ///企业性质
        ///</summary>
        public string Enterprise
        {
            get
            {
                return enterprise;
            }
            set
            {
                enterprise = value;
            }
        }

        ///<summary>
        ///业务联系人
        ///</summary>
        public string LinkUser
        {
            get
            {
                return linkuser;
            }
            set
            {
                linkuser = value;
            }
        }

        ///<summary>
        ///联系人职务
        ///</summary>
        public string LinkPost
        {
            get
            {
                return linkpost;
            }
            set
            {
                linkpost = value;
            }
        }

        ///<summary>
        ///业务联系电话
        ///</summary>
        public string LinkPhone
        {
            get
            {
                return linkphone;
            }
            set
            {
                linkphone = value;
            }
        }

        ///<summary>
        ///主要经营范围
        ///</summary>
        public string MainAssest
        {
            get
            {
                return mainassest;
            }
            set
            {
                mainassest = value;
            }
        }

        ///<summary>
        ///开户行
        ///</summary>
        public string BankName
        {
            get
            {
                return bankname;
            }
            set
            {
                bankname = value;
            }
        }

        ///<summary>
        ///开户账号
        ///</summary>
        public string BankNum
        {
            get
            {
                return banknum;
            }
            set
            {
                banknum = value;
            }
        }

        ///<summary>
        ///资信等级
        ///</summary>
        public string Qualifications
        {
            get
            {
                return qualifications;
            }
            set
            {
                qualifications = value;
            }
        }

        ///<summary>
        ///企业法人
        ///</summary>
        public string Legal
        {
            get
            {
                return legal;
            }
            set
            {
                legal = value;
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

