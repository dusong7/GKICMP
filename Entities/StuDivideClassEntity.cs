using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
    public class StuDivideClassEntity
    {
        public int ID { get; set; }//班级ID
        public string ClassName { get; set; }
        public List<WeightingData2> UserList { get; set; }
        public double Average { get; set; }

    }

    public class WeightingData2
    {
        public string Name { get; set; }//学生ID
        public int ParnetEdu { get; set; }
        public int SpeakLevel { get; set; }
        public bool IsBoy { get; set; }
    }
}
