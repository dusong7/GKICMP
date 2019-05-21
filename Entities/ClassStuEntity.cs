using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class ClassStuEntity
    {
       public string ClassID { get; set; }
      
       public List<Student> Stu { get; set; }
       public double AvgMark { get; set; }
       public double AvgAge { get; set; }
    }

   public class Student
   {
       public string ID { get; set; }
       public int Sex { get; set; }
       public int Age { get; set; }
       public double Mark { get; set; }
   }


   //public class WeightingClass2
   //{
   //    public int ID { get; set; }
   //    public string ClassName { get; set; }
   //    public List<WeightingData2> UserList { get; set; }
   //    public double Average { get; set; }
   //}

   //public class WeightingData2
   //{
   //    public string Name { get; set; }
   //    public int ParnetEdu { get; set; }
   //    public int SpeakLevel { get; set; }
   //    public bool IsBoy { get; set; }
   //}



    
}
