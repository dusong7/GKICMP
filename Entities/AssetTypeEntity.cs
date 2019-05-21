using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class AssetTypeEntity
    {
       public AssetTypeEntity() { }
        /// <summary>
        /// SysData1表实体
        /// </summary>
        /// <param name="sdid"></param>
        /// <param name="dataname"></param>
        /// <param name="datadesc"></param>
        /// <param name="datatype"></param>
        /// <param name="isdel"></param>
        /// <param name="issysset"></param>
        /// <param name="pid"></param>
       public AssetTypeEntity(int sdid, string dataname, string datadesc, int datatype, int isdel, int issysset, int pid)
        {
            this.SDID = sdid;
            this.DataName = dataname;
            this.DataDesc = datadesc;
            this.DataType = datatype;
            this.Isdel = isdel;
            this.IsSysSet = issysset;
            this.PID = pid;
        }
       public AssetTypeEntity(string dataname, int isdel)
        {

            this.DataName = dataname;
            this.Isdel = isdel;
        }
        private int sdid;//
        private string dataname;//
        private string datadesc;//
        private int datatype;//
        private int isdel;//
        private int issysset;//
        private int pid;//
        private int maxid;

        public int MaxID
        {
            get { return maxid; }
            set { maxid = value; }
        }


        ///<summary>
        ///
        ///</summary>
        public int SDID
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
        ///
        ///</summary>
        public string DataName
        {
            get
            {
                return dataname;
            }
            set
            {
                dataname = value;
            }
        }

        ///<summary>
        ///
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
        ///
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
        ///
        ///</summary>
        public int IsSysSet
        {
            get
            {
                return issysset;
            }
            set
            {
                issysset = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int PID
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
    }
}

