/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2019年05月09日 02点43分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class Project_ContractEntity
    {

        /// <summary>
        /// Project_Contract表实体
        ///</summary>
        public Project_ContractEntity()
        {
        }


        /// <summary>
        /// Project_Contract表实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="partya"></param>
        /// <param name="partyb"></param>
        /// <param name="signdate"></param>
        /// <param name="price"></param>
        /// <param name="starttime"></param>
        /// <param name="pcdesc"></param>
        /// <param name="createuser"></param>
        /// <param name="createdate"></param>
        /// <param name="isdel"></param>
        /// <param name="bidnumber">标书编号</param>
        /// <param name="serveryears">维保周期</param>
        /// <param name="serverdate">维保开始时间</param>
        /// <param name="serverlinkuser">维保联系人</param>
        /// <param name="serverphone">维保联系方式</param>
        public Project_ContractEntity(string id, string pid, string partya, string partyb, DateTime signdate, decimal price, int starttime, string pcdesc, string createuser, DateTime createdate, int isdel, string bidnumber, string serveryears, DateTime serverdate, string serverlinkuser, string serverphone)
        {
            this.ID = id;
            this.PID = pid;
            this.PartyA = partya;
            this.PartyB = partyb;
            this.SignDate = signdate;
            this.Price = price;
            this.StartTime = starttime;
            this.PCDesc = pcdesc;
            this.CreateUser = createuser;
            this.CreateDate = createdate;
            this.Isdel = isdel;
            this.BidNumber = bidnumber;
            this.ServerYears = serveryears;
            this.ServerDate = serverdate;
            this.ServerLinkUser = serverlinkuser;
            this.ServerPhone = serverphone;
        }

        private string id;//
        private string pid;//
        private string partya;//
        private string partyb;//
        private DateTime signdate;//
        private decimal price;//
        private int starttime;//
        private string pcdesc;//
        private string createuser;//
        private DateTime createdate;//
        private int isdel;//
        private string bidnumber;//标书编号
        private string serveryears;//维保周期
        private DateTime serverdate;//维保开始时间
        private string serverlinkuser;//维保联系人
        private string serverphone;//维保联系方式
        public string FileID { get; set; }
        public string Name { get; set; }
        public string PName { get; set; }
        public string PartyBName { get; set; }
        public int IsReport { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        ///<summary>
        ///
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
        ///
        ///</summary>
        public string PartyA
        {
            get
            {
                return partya;
            }
            set
            {
                partya = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string PartyB
        {
            get
            {
                return partyb;
            }
            set
            {
                partyb = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime SignDate
        {
            get
            {
                return signdate;
            }
            set
            {
                signdate = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int StartTime
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string PCDesc
        {
            get
            {
                return pcdesc;
            }
            set
            {
                pcdesc = value;
            }
        }

        ///<summary>
        ///
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
        public string CreateUserName { get; set; }
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
        ///
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

        ///<summary>
        ///标书编号
        ///</summary>
        public string BidNumber
        {
            get
            {
                return bidnumber;
            }
            set
            {
                bidnumber = value;
            }
        }

        ///<summary>
        ///维保周期
        ///</summary>
        public string ServerYears
        {
            get
            {
                return serveryears;
            }
            set
            {
                serveryears = value;
            }
        }

        ///<summary>
        ///维保开始时间
        ///</summary>
        public DateTime ServerDate
        {
            get
            {
                return serverdate;
            }
            set
            {
                serverdate = value;
            }
        }

        ///<summary>
        ///维保联系人
        ///</summary>
        public string ServerLinkUser
        {
            get
            {
                return serverlinkuser;
            }
            set
            {
                serverlinkuser = value;
            }
        }

        ///<summary>
        ///维保联系方式
        ///</summary>
        public string ServerPhone
        {
            get
            {
                return serverphone;
            }
            set
            {
                serverphone = value;
            }
        }
    }
}

