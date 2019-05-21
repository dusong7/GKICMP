/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       学生信息管理编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Linq;

namespace GKICMP.freshmen
{
    public partial class StuPlacement : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();
        //public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        //#region 参数集合
        ///// <summary>
        ///// UID
        ///// </summary>
        //public string UID
        //{
        //    get
        //    {
        //        return GetQueryString<string>("id", "");
        //    }
        //}
        //#endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                int count =departmentDAL.GetClassCount().Rows.Count;
                if (count > 0)
                {
                    string bj = "";
                    DataTable dt=departmentDAL.GetClassCount();
                    this.txt_ClassCount.Text = dt.Rows.Count.ToString();
                    this.txt_ClassCount.Enabled = false;
                    foreach (DataRow dr in dt.Rows) 
                    {
                        bj += dr["DID"] + ",";
                    }
                    ViewState["Class"] =bj.TrimEnd(',');
                }
                else 
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请先创建年级和班级！');winclose();", true);
                }
                //ClassGet();
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int i=0;int stu=0;
                List<ClassStuEntity> cslist = new List<ClassStuEntity>();

                while (i < 99)
                {
                    cslist = GetClassStu();
                    foreach (ClassStuEntity cs in cslist)
                    {
                        stu += cs.Stu.Count;
                    }
                    if (stu < cslist.Count)
                    {
                        break;
                    }
                    else
                    {
                        if (cslist.Count > 0)
                        {
                            cslist = cslist.OrderBy(a => a.AvgMark).ToList();
                            double b = Math.Abs(cslist[0].AvgMark - cslist[cslist.Count - 1].AvgMark);
                            if (b < int.Parse(this.txt_Score.Text))
                            {
                                break;
                            }
                            //else if(){}
                            else { cslist.Clear(); }
                        }
                        else
                        {
                            ShowMessage("无学生信息，请先添加学生"); return;
                        }
                        i++;
                    }
                }
                if (cslist.Count <= 0) 
                {
                    ShowMessage("请适当增加平均分误差值"); return;
                }
                int result = studentDAL.Update(cslist);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "新生分班", UserID));
                    ShowMessage();
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "新生分班失败", UserID));
                    ShowMessage("提交失败");
                }
            }
            catch (Exception error)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                ShowMessage(error.Message);
               return;
            }
        }

        private List<ClassStuEntity> GetClassStu()
        {
             List<ClassStuEntity> cslist = new List<ClassStuEntity>();
             DataTable dt  = studentDAL.GetStuReg();
          

                 List<Student> studentlist = new List<Student>();
                 if (dt.Rows.Count > 0)
                 {
                     foreach (DataRow dr in dt.Rows)
                     {
                         Student stu = new Student();
                         stu.Sex =int.Parse(dr["UserSex"].ToString());
                         stu.ID = dr["StID"].ToString();
                         stu.Mark = double.Parse(dr["StuMark"].ToString());
                         stu.Age =int.Parse( dr["Age"].ToString());
                         studentlist.Add(stu);
                     }
                 }
                 else
                 {
                     return cslist;
                 }
                 int total = studentlist.Count;
                 int classcount = int.Parse(this.txt_ClassCount.Text);

                 string[] cla = ViewState["Class"].ToString().Split(',');
                 //if (studentlist.Count > cla.Length)
                 //{
                     for (int i = 1; i <= classcount; i++)
                     {
                         cslist.Add(new ClassStuEntity
                         {
                             ClassID = cla[i - 1],
                             Stu = new List<Student>(),
                         });
                     }
                 //}
                 //else 
                 //{
                 //    cslist.Add(new ClassStuEntity
                 //    {
                 //        ClassID = cla[new Random().Next(0, (cla.Length - 1))],
                 //        Stu = new List<Student>(),
                 //    });
                 //}

                 while (studentlist.Count > 0)
                 {

                         // List<Student> toplist = new List<Student>();
                         //男生
                       List<Student> toplistb  = this.cb_Age.Checked ? studentlist.Where(t => t.Sex == 1).OrderBy(t => t.Age).Take(classcount).ToList() : studentlist.Where(t => t.Sex == 1).OrderBy(t => t.Mark).Take(classcount).ToList();
                         //女生
                       List<Student>  toplistg = this.cb_Age.Checked ? studentlist.Where(t => t.Sex == 2).OrderBy(t => t.Age).Take(classcount).ToList() : studentlist.Where(t => t.Sex == 2).OrderBy(t => t.Mark).Take(classcount).ToList();
                         //studentlist = this.cb_Age.Checked ? studentlist.RemoveAll(toplistb) : studentlist.OrderBy(t => t.Mark).Skip(toplistb.Count + toplistg.Count).ToList();
                         foreach (Student model in toplistb)
                         {
                             studentlist.Remove(model);
                         }
                         foreach (Student model in toplistg)
                         {
                             studentlist.Remove(model);
                         }
                  
                    
                     //studentlist = this.cb_Age.Checked ? studentlist.OrderBy(t => t.Age).Skip(classcount).ToList() : studentlist.OrderBy(t => t.Mark).Skip(toplistb.Count + toplistg.Count).ToList();
                     List<int> topnum = new List<int>();
                     for (int i = 0; i < toplistb.Count; i++)
                     {
                         topnum.Add(i);
                     }
                     Random ran = new Random();
                     int k = 0;
                     while (toplistb.Count > 0)
                     {
                         int number = ran.Next(0, toplistb.Count - 1);
                         cslist[k].Stu.Add(toplistb[number]);
                         toplistb.Remove(toplistb[number]);
                         k = k + 1;
                     }
                     int j = 0;
                     while (toplistg.Count > 0)
                     {
                         int number = ran.Next(0, toplistg.Count - 1);
                         cslist[j].Stu.Add(toplistg[number]);
                         toplistg.Remove(toplistg[number]);
                         j = j + 1;
                     }
                 }

                 foreach (ClassStuEntity cs in cslist)
                 {
                     double ranktotal = 0;
                     double agetotal = 0;
                     foreach (Student student in cs.Stu)
                     {
                         ranktotal += student.Mark;
                         agetotal += student.Age;
                     }
                     cs.AvgAge = agetotal / cs.Stu.Count;
                     cs.AvgMark = ranktotal / cs.Stu.Count;
                 }
             //}
             //else 
             //{
             //    dt = new StudentDAL().GetStuReg();

             //    List<Student> studentlist = new List<Student>();
             //    if (dt.Rows.Count > 0)
             //    {
             //        foreach (DataRow dr in dt.Rows)
             //        {
             //            Student stu = new Student();
             //            stu.Age = dr["Age"].ToString();
             //            stu.ID = dr["StID"].ToString();
             //            stu.Mark = double.Parse(dr["StuMark"].ToString());
             //            studentlist.Add(stu);
             //        }
             //    }
             //    else
             //    {
             //        return cslist;
             //    }
             //    int total = studentlist.Count;
             //    int classcount = int.Parse(this.txt_ClassCount.Text);

             //    string[] cla = ViewState["Class"].ToString().Split(',');
             //    for (int i = 1; i <= classcount; i++)
             //    {
             //        cslist.Add(new ClassStuEntity
             //        {
             //            ClassID = cla[i - 1],
             //            Stu = new List<Student>(),
             //        });
             //    }

             //    while (studentlist.Count > 0)
             //    {
             //        List<Student> toplist = studentlist.Take(classcount).ToList();
             //        studentlist = studentlist.Skip(classcount).ToList();
             //        List<int> topnum = new List<int>();
             //        for (int i = 0; i < toplist.Count; i++)
             //        {
             //            topnum.Add(i);
             //        }
             //        Random ran = new Random();
             //        int k = 0;
             //        while (toplist.Count > 0)
             //        {
             //            int number = ran.Next(0, toplist.Count - 1);
             //            cslist[k].Stu.Add(toplist[number]);
             //            toplist.Remove(toplist[number]);
             //            k = k + 1;
             //        }
             //    }

             //    foreach (ClassStuEntity cs in cslist)
             //    {
             //        double ranktotal = 0;
             //        foreach (Student student in cs.Stu)
             //        {
             //            ranktotal = ranktotal + student.Mark;
             //        }
             //        cs.AvgMark = ranktotal / cs.Stu.Count;
             //    }
             //}
            return cslist;
        }
        public void ClassGet( )
        {   
            //studentlist = studentlist.OrderBy(t => t.Rank).ToList();
            DataTable dt = new StudentDAL().GetStuReg();
            List<Student> studentlist = new List<Student>();
            if (dt.Rows.Count > 0) 
            {
                foreach (DataRow dr in dt.Rows) 
                {
                    Student stu = new Student();
                    stu.Age =int.Parse( dr["Age"].ToString());
                    stu.ID = dr["StID"].ToString();
                    stu.Mark =double.Parse( dr["StuMark"].ToString());
                    studentlist.Add(stu);
                }
            }
            int total = studentlist.Count;
            int classcount =int.Parse(this.txt_ClassCount.Text);
            List<ClassStuEntity> cslist = new List<ClassStuEntity>();
            string[] cla = ViewState["Class"].ToString().Split(',');
            for (int i = 1; i <= classcount; i++)
            {
                cslist.Add(new ClassStuEntity
                {
                    ClassID = cla[i-1],
                    Stu = new List<Student>(),
                });
            }

            while (studentlist.Count > 0)
            {
                List<Student> toplist = studentlist.Take(classcount).ToList();
                studentlist = studentlist.Skip(classcount).ToList();
                List<int> topnum = new List<int>();
                for (int i = 0; i < toplist.Count; i++)
                {
                    topnum.Add(i);
                }
                Random ran = new Random();
                int k = 0;
                while (toplist.Count > 0)
                {
                    int number = ran.Next(0, toplist.Count - 1);
                    cslist[k].Stu.Add(toplist[number]);
                    toplist.Remove(toplist[number]);
                    k = k + 1;
                }
            }

            foreach (ClassStuEntity cs in cslist)
            {
                double ranktotal = 0;
                foreach (Student student in cs.Stu)
                {
                    ranktotal = ranktotal + student.Mark;
                }
                cs.AvgMark = ranktotal / cs.Stu.Count;
            }

        }
        //public void ClassGet(List<Student> studentlist, int classcapacity)
        //{
        //    //studentlist = studentlist.OrderBy(t => t.Rank).ToList();
        //    int total = studentlist.Count;
        //    int classcount = Convert.ToInt32(Math.Ceiling((double)total / (double)classcapacity));
        //    List<ClassStudent> cslist = new List<ClassStudent>();
        //    for (int i = 1; i <= classcount; i++)
        //    {
        //        cslist.Add(new ClassStudent
        //        {
        //            ClassName = "班级" + i,
        //            StudentList = new List<Student>(),
        //        });
        //    }

        //    while (studentlist.Count > 0)
        //    {
        //        List<Student> toplist = studentlist.OrderBy(t => t.Rank).Take(classcount).ToList();
        //        studentlist = studentlist.OrderBy(t => t.Rank).Skip(classcount).ToList();
        //        List<int> topnum = new List<int>();
        //        for (int i = 0; i < toplist.Count; i++)
        //        {
        //            topnum.Add(i);
        //        }
        //        Random ran = new Random();
        //        int k = 0;
        //        while (toplist.Count > 0)
        //        {
        //            int number = ran.Next(0, toplist.Count - 1);
        //            cslist[k].StudentList.Add(toplist[number]);
        //            toplist.Remove(toplist[number]);
        //            k = k + 1;
        //        }
        //    }

        //    foreach (ClassStudent cs in cslist)
        //    {
        //        int ranktotal = 0;
        //        foreach (Student student in cs.StudentList)
        //        {
        //            ranktotal = ranktotal + student.Rank;
        //        }
        //        cs.RankAverage = ranktotal / cs.StudentList.Count;
        //    }

        //}

      

    }
}