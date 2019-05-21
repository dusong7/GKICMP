/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月10日 10点04分
** 描   述:      资产实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AssetEntity
    {

        /// <summary>
        /// Asset表实体
        ///</summary>
        public AssetEntity()
        {
        }

        public AssetEntity(int datatype, int isdel)
        {
            this.DataType = datatype;
            this.Isdel = isdel;
        }


        /// <summary>
        /// Asset表实体
        /// </summary>
        /// <param name="aid">ID</param>
        /// <param name="assetname">物品名称</param>
        /// <param name="datadesc">资产编号</param>
        /// <param name="datatype">物品分类</param>
        /// <param name="aprice">物品单价</param>
        /// <param name="aimage">物品图片</param>
        /// <param name="brand">品牌</param>
        /// <param name="buydate">购置时间</param>
        /// <param name="planyear">计划使用年限</param>
        /// <param name="assetmark">物品描述</param>
        /// <param name="specificationmodel">规格型号</param>
        /// <param name="suppliers">供应商</param>
        /// <param name="buyuser">采购人</param>
        /// <param name="createuser">录入人</param>
        /// <param name="createdate">录入日期</param>
        /// <param name="assetnum">数量</param>
        /// <param name="aunit">单位</param>
        /// <param name="isdel">是否删除</param>
        public AssetEntity(string aid, string assetname, string datadesc, int datatype, decimal aprice, string aimage, string brand, DateTime buydate, int planyear, string assetmark, string specificationmodel, string suppliers, string buyuser, string createuser, DateTime createdate, int assetnum, int aunit, int isdel)
        {
            this.AID = aid;
            this.AssetName = assetname;
            this.DataDesc = datadesc;
            this.DataType = datatype;
            this.APrice = aprice;
            this.AImage = aimage;
            this.Brand = brand;
            this.BuyDate = buydate;
            this.PlanYear = planyear;
            this.AssetMark = assetmark;
            this.SpecificationModel = specificationmodel;
            this.Suppliers = suppliers;
            this.BuyUser = buyuser;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.AssetNum = assetnum;
            this.AUnit = aunit;
            this.Isdel = isdel;
        }

        private string aid;//ID
        private string assetname;//物品名称
        private string datadesc;//资产编号
        private int datatype;//物品分类
        private decimal aprice;//物品单价
        private string aimage;//物品图片
        private string brand;//品牌
        private DateTime buydate;//购置时间
        private int planyear;//计划使用年限
        private string assetmark;//物品描述
        private string specificationmodel;//规格型号
        private string suppliers;//供应商
        private string buyuser;//采购人
        private string createuser;//录入人
        private DateTime createdate;//录入日期
        private int assetnum;//数量
        private int aunit;//单位
        private int isdel;//是否删除
        private decimal assrate;//折旧率
        private int isstoprate;//是否停止折旧
        private decimal lastvalue;//停止折旧价值
        private DateTime lastdate;//停止折旧时间
        //办公用品分类
        private string officetypename;
        private int typename;
        private string aunitname;
        private string suppliersname;

        /// <summary>
        /// 停止折旧时间
        /// </summary>
        public DateTime LastDate
        {
            get { return lastdate; }
            set { lastdate = value; }
        }
        /// <summary>
        /// 停止折旧价值
        /// </summary>
        public decimal LastValue
        {
            get { return lastvalue; }
            set { lastvalue = value; }
        }

        /// <summary>
        /// 是否停止折旧
        /// </summary>
        public int IsStopRate
        {
            get { return isstoprate; }
            set { isstoprate = value; }
        }
        /// <summary>
        /// 折旧率
        /// </summary>
        public decimal AssRate
        {
            get { return assrate; }
            set { assrate = value; }
        }


        /// <summary>
        /// 办公用品分类
        /// </summary>
        public string OfficeTypeName
        {
            get { return officetypename; }
            set { officetypename = value; }
        }

        private int isreport;
        /// <summary>
        /// 校区
        /// </summary>
        public int CID { get; set; }
        /// <summary>
        /// 存放位置
        /// </summary>
        public int CRID { get; set; }
        /// <summary>
        /// 校区名称
        /// </summary>
        public string CName { get; set; }
        public string DataTypeName { get; set; }//物品分类名称

        public string ProName { get; set; }//项目名称
       // public string AunitName { get; set; }
        public int IsReport
        {
            get
            {
                return isreport;
            }
            set
            {
                isreport = value;
            }
        }
        public int IsChecked { get; set; }//是否验收
        public int Flag { get; set; }
        public string PID { get; set; }
        public string CreateUserName { get; set; }
        public string BuyUserName { get; set; }

        public string SuppliersName
        {
            get
            {
                return suppliersname;
            }
            set
            {
                suppliersname = value;
            }
        }
        /// <summary>
        /// 计量单位名称
        /// </summary>
        public string AUnitName
        {
            get
            {
                return aunitname;
            }
            set
            {
                aunitname = value; 
            }
        }
        public int TypeName
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

        ///<summary>
        ///ID
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
        ///物品名称
        ///</summary>
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

        ///<summary>
        ///资产编号
        ///</summary>
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

        ///<summary>
        ///物品分类
        ///</summary>
        public int DataType
        {
            get
            {
                return datatype;
            }
            set
            {
                datatype = value;
            }
        }

        ///<summary>
        ///物品单价
        ///</summary>
        public decimal APrice
        {
            get
            {
                return aprice;
            }
            set
            {
                aprice = value;
            }
        }

        ///<summary>
        ///物品图片
        ///</summary>
        public string AImage
        {
            get
            {
                return aimage;
            }
            set
            {
                aimage = value;
            }
        }

        ///<summary>
        ///品牌
        ///</summary>
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }

        ///<summary>
        ///购置时间
        ///</summary>
        public DateTime BuyDate
        {
            get
            {
                return buydate;
            }
            set
            {
                buydate = value;
            }
        }

        ///<summary>
        ///计划使用年限
        ///</summary>
        public int PlanYear
        {
            get
            {
                return planyear;
            }
            set
            {
                planyear = value;
            }
        }

        ///<summary>
        ///物品描述
        ///</summary>
        public string AssetMark
        {
            get
            {
                return assetmark;
            }
            set
            {
                assetmark = value;
            }
        }

        ///<summary>
        ///规格型号
        ///</summary>
        public string SpecificationModel
        {
            get
            {
                return specificationmodel;
            }
            set
            {
                specificationmodel = value;
            }
        }

        ///<summary>
        ///供应商
        ///</summary>
        public string Suppliers
        {
            get
            {
                return suppliers;
            }
            set
            {
                suppliers = value;
            }
        }

        ///<summary>
        ///采购人
        ///</summary>
        public string BuyUser
        {
            get
            {
                return buyuser;
            }
            set
            {
                buyuser = value;
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
        ///数量
        ///</summary>
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

        ///<summary>
        ///单位
        ///</summary>
        public int AUnit
        {
            get
            {
                return aunit;
            }
            set
            {
                aunit = value;
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
        public int AssetGroup { get; set; }
        public string AssetGroupName { get; set; }
    }
}
