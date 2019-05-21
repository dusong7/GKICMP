/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      fzh
** 创建日期:      2016年11月10日 05点34分
** 描   述:      资产领用/借出实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Asset_BorrowEntity
    {

        /// <summary>
        /// Asset_Borrow表实体
        ///</summary>
        public Asset_BorrowEntity()
        {
        }


        /// <summary>
        /// Asset_Borrow表实体
        /// </summary>
        /// <param name="abflag">标示</param>
        /// <param name="isdel">是否删除</param>
        public Asset_BorrowEntity(DateTime begindate, DateTime enddate, int abflag, int isdel)
        {
            this.BeginDate = begindate;
            this.EndDate = enddate;
            this.ABFlag = abflag;
            this.Isdel = isdel;
        }

        private int abid;//ID
        private string aid;//资产ID
        private string abuser;//领用人
        private int abstate;//状态 1：借出 2：归还
        private DateTime backdate;//归还日期
        private string abmak;//说明
        private string createruser;//录入人
        private DateTime createdate;//录入日期
        private DateTime userdate;//领用日期
        private int abflag;//标示 1：借出 2：领用
        private int isdel;//是否删除
        private int flag;//资产和耗材
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
        private int assetnum;//领用数量
        public int AssetNum
        {
            get
            {
                return assetnum;
            }
            set
            {
                assetnum = value;
            }
        }

        private DateTime begindate;
        private DateTime enddate;

        private string assetname;//物品名称
        private string typename;
        private string datadesc;//资产编号
        private string abusername;//领用人名称
        public string AssetName
        {
            get
            {
                return assetname;
            }
            set
            {
                assetname = value;
            }
        }
        public string DataDesc
        {
            get
            {
                return datadesc;
            }
            set
            {
                datadesc = value;
            }
        }

        public string ABUserName
        {
            get
            {
                return abusername;
            }
            set
            {
                abusername = value;
            }
        }

        public string TypeName
        {
            get
            {
                return typename;
            }
            set
            {
                typename = value;
            }
        }  


        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        public DateTime BeginDate
        {
            get { return begindate; }
            set { begindate = value; }
        }



        ///<summary>
        ///ID
        ///</summary>
        public int ABID
        {
            get
            {
                return abid;
            }
            set
            {
                abid = value;
            }
        }

        ///<summary>
        ///资产ID
        ///</summary>
        public string AID
        {
            get
            {
                return aid;
            }
            set
            {
                aid = value;
            }
        }

        ///<summary>
        ///领用人
        ///</summary>
        public string ABUser
        {
            get
            {
                return abuser;
            }
            set
            {
                abuser = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int ABState
        {
            get
            {
                return abstate;
            }
            set
            {
                abstate = value;
            }
        }

        ///<summary>
        ///归还日期
        ///</summary>
        public DateTime BackDate
        {
            get
            {
                return backdate;
            }
            set
            {
                backdate = value;
            }
        }

        ///<summary>
        ///说明
        ///</summary>
        public string ABMak
        {
            get
            {
                return abmak;
            }
            set
            {
                abmak = value;
            }
        }

        ///<summary>
        ///录入人
        ///</summary>
        public string CreaterUser
        {
            get
            {
                return createruser;
            }
            set
            {
                createruser = value;
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
        ///领用日期
        ///</summary>
        public DateTime UserDate
        {
            get
            {
                return userdate;
            }
            set
            {
                userdate = value;
            }
        }

        ///<summary>
        ///标示
        ///</summary>
        public int ABFlag
        {
            get
            {
                return abflag;
            }
            set
            {
                abflag = value;
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

