
using System;

namespace GK.GKICMP.Entities
{
    public class WF_FormDataEntity
    {
        private int fdid;
        private string wffid;
        private int fpid;
        private int fdorder;
        private int fdtype;
        private string fdvalue;
        private int isrequired;
        private int isdel;

        public int FDID
        {
            get
            {
                return fdid;
            }
            set
            {
                fdid = value;
            }
        }

        public string WFFID
        {
            get
            {
                return wffid;
            }
            set
            {
                wffid = value;
            }
        }

        public int FPID
        {
            get
            {
                return fpid;
            }
            set
            {
                fpid = value;
            }
        }

        public int FDOrder
        {
            get
            {
                return fdorder;
            }
            set
            {
                fdorder = value;
            }
        }

        public int FDType
        {
            get
            {
                return fdtype;
            }
            set
            {
                fdtype = value;
            }
        }

        public string FDValue
        {
            get
            {
                return fdvalue;
            }
            set
            {
                fdvalue = value;
            }
        }

        public int IsRequired
        {
            get
            {
                return isrequired;
            }
            set
            {
                isrequired = value;
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
