
using System;

namespace GK.GKICMP.Entities
{
    public class WF_FormDValueEntity
    {
        private int fdvid;
        private int fdid;
        private string fdvalue;

        public int FDVID
        {
            get
            {
                return fdvid;
            }
            set
            {
                fdvid = value;
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
