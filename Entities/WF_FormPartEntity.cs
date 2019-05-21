
using System;

namespace GK.GKICMP.Entities
{
    public class WF_FormPartEntity
    {
        private int fpid;
        private string fpartname;
        private int fptype;
        private int isdel;
        private int isrequired;

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

        public string FPartName
        {
            get
            {
                return fpartname;
            }
            set
            {
                fpartname = value;
            }
        }

        public int FPType
        {
            get
            {
                return fptype;
            }
            set
            {
                fptype = value;
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

    }
}
