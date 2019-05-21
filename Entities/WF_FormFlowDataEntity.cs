
using System;

namespace GK.GKICMP.Entities
{
    public class WF_FormFlowDataEntity
    {
        private int ffdid;
        private string wffid;
        private int fdid;
        private string cid;
        private string fdvalue;

        public int FFDID
        {
            get
            {
                return ffdid;
            }
            set
            {
                ffdid = value;
            }
        }

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

        public string CID
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

    }
}
