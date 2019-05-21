using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class ExamSetEntity
    {
       public ExamSetEntity() { }
       /// <summary>
       /// 考试id
       /// </summary>
       public string Exam { get; set; }//考试id
       /// <summary>
       /// 考场id
       /// </summary>
       public int ERoom { get; set; }//考场id
       /// <summary>
       /// 课程id
       /// </summary>
       public int CID { get; set; }//课程id
       /// <summary>
       /// 教师id
       /// </summary>
       public string TID { get; set; }//教师id
       /// <summary>
       /// 学生数
       /// </summary>
       public int StuNum { get; set; }//学生数
       /// <summary>
       /// 教师数
       /// </summary>
       public int TNum { get; set; }//教师数
       /// <summary>
       /// 考场号
       /// </summary>
       public string RoomNum { get; set; }//考场号 
    }
}
