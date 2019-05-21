
using System;

namespace GK.GKICMP.Entities
{
    public class WF_FormEntity
    {
        private string wffid;
        private string formname;
        private int isenable;
        private int isdel;
        private int issetauditor;
        private string createuser;
        private DateTime createdate;

        public string CreateUser
        {
            get { return createuser; }
            set { createuser = value; }
        }


        public DateTime CreateDate
        {
            get { return createdate; }
            set { createdate = value; }
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

        public string FormName
        {
            get
            {
                return formname;
            }
            set
            {
                formname = value;
            }
        }

        public int IsEnable
        {
            get
            {
                return isenable;
            }
            set
            {
                isenable = value;
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

        public int IsSetAuditor
        {
            get
            {
                return issetauditor;
            }
            set
            {
                issetauditor = value;
            }
        }

    }
}
