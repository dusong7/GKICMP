
using System;

namespace GK.GKICMP.Entities
{
    public class WF_FormUserEntity
    {
        private int wfuid;
        private string wffid;
        private string sysid;

        public int WFUID
        {
            get
            {
                return wfuid;
            }
            set
            {
                wfuid = value;
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

        public string SysID
        {
            get
            {
                return sysid;
            }
            set
            {
                sysid = value;
            }
        }
    }
}
