using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class LDapEntity
    {
       public LDapEntity() { }
       public string Path { get; set; }
       public string DN { get; set; }
       public string UserName { get; set; }
       public string Psw { get; set; }
       public string OU { get; set;  }
    }
}
