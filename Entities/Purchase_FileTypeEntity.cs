using System;

namespace GK.GKICMP.Entities
{
    public class Purchase_FileTypeEntity
    {
        public Purchase_FileTypeEntity()
        {

        }

        public Purchase_FileTypeEntity(string id, string purchasetypeid, string name, int isdel)
        {
            this.ID = id;
            this.PurchaseTypeID = purchasetypeid;
            this.Name = name;
            this.Isdel = isdel;
        }

        private string id;//
        private string purchasetypeid;//
        private string name;//
        private int isdel;

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

        public string PurchaseTypeID
        {
            get
            {
                return purchasetypeid;
            }
            set
            {
                purchasetypeid = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
