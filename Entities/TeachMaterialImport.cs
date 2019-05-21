using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
    public class TeachMaterialImport
    {
        public TeachMaterialImport() { }
        public int TMID { get; set; }
        public string TMName { get; set; }
        public int TEdition { get; set; }
        public int TMCourse { get; set; }
        public int GID { get; set; }
        public int TermID { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int Isdel { get; set; }
        public string ChapterName { get; set; }
        public string ChapterContent { get; set; }
    }
}
