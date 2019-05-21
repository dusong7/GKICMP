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
using System.Threading;

namespace GKICMP.freshmen
{
    public partial class StuDivideClass : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable ds = campusDAL.GetList((int)CommonEnum.Deleted.未删除);//所属校区
                CommonFunction.DDlTypeBind(this.ddl_CID, ds, "CID", "CampusName", "-2");

                this.txt_ClassCount.Enabled = false;

                #region 初始加载
                //int count = departmentDAL.GetClassCount().Rows.Count;
                //if (count > 0)
                //{
                //    string bj = "";
                //    DataTable dt = departmentDAL.GetClassCount();
                //    this.txt_ClassCount.Text = dt.Rows.Count.ToString();
                //    this.txt_ClassCount.Enabled = false;
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        bj += dr["DID"] + ",";
                //    }
                //    ViewState["Class"] = bj.TrimEnd(',');
                //}
                //else
                //{
                //    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请先创建年级和班级！');winclose();", true);
                //}
                 #endregion
                
            }
        }
        #endregion

        #region 下拉框触发事件
        protected void ddl_ProType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = departmentDAL.GetCountByCID(int.Parse(this.ddl_CID.SelectedValue)).Rows.Count;
            if (count > 0)
            {
                string bj = "";
                string depname = "";
                DataTable dt = departmentDAL.GetCountByCID(int.Parse(this.ddl_CID.SelectedValue));
                this.txt_ClassCount.Text = dt.Rows.Count.ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    bj += dr["DID"] + ",";
                    depname += dr["DepName"] + ",";
                }
                ViewState["Class"] = bj.TrimEnd(',');
                this.ltl_DepName.Text = depname.TrimEnd(',');//分班班级名称
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请先创建年级和班级！');winclose();", true);
            }

            DataTable xs = new StudentDAL().GetStuAvg(int.Parse(this.ddl_CID.SelectedValue));//获取全部未删除的新生
            if (xs != null && xs.Rows.Count > 0)
            {
                this.ltl_Num.Text = Convert.ToString(xs.Rows.Count);//学生数
            }
            else
            {
                this.ltl_Num.Text = "";//学生数
            }

        }
        #endregion


        #region 分班循环
        //private class WeightingClass2
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


        //private List<WeightingClass2> Weighting2(List<WeightingData2> WeightingDataList, int ClassCount, bool IsSex)
        //{
        //    List<WeightingClass2> WeightingClassList = new List<WeightingClass2>();
        private List<StuDivideClassEntity> Weighting2(List<WeightingData2> WeightingDataList, int ClassCount, bool IsSex)
        {
            List<StuDivideClassEntity> WeightingClassList = new List<StuDivideClassEntity>();

            string[] cla = ViewState["Class"].ToString().Split(',');
            for (int i = 0; i < ClassCount; i++)
            {
                //WeightingClassList.Add(new WeightingClass2
                WeightingClassList.Add(new StuDivideClassEntity
                {
                    ID = Convert.ToInt32(cla[i]),
                    ClassName = "班级" + (i + 1),
                    UserList = new List<WeightingData2>()
                });
            }

            #region 循环判断
            if (IsSex)
            {
                #region 男生
                List<WeightingData2> BoyList = WeightingDataList.Where(t => t.IsBoy).ToList();
                List<WeightingData2> GirlList = WeightingDataList.Where(t => !t.IsBoy).ToList();

                var boyspeaklist = BoyList.OrderBy(t => t.SpeakLevel).Select(t => t.SpeakLevel).Distinct().ToList();
                foreach (int speak in boyspeaklist)
                {
                    List<WeightingData2> SelWeightingDataList = BoyList.Where(t => t.SpeakLevel == speak).OrderBy(t => t.ParnetEdu).ToList();
                    while (SelWeightingDataList.Count > 0)
                    {
                        List<WeightingData2> SelList = SelWeightingDataList.Take(ClassCount).ToList();

                        List<Test> testnum = new List<Test>();
                        Random ran = new Random();
                        List<int> RanList = new List<int>();
                        for (int i = 0; i < WeightingClassList.Count; i++)
                        {
                            RanList.Add(WeightingClassList[i].ID);
                        }

                        if (SelList.Count < ClassCount)
                        {
                            //补足
                            var RemainList = WeightingClassList.Where(t => t.UserList.Count != WeightingClassList.OrderBy(m => m.UserList.Count).FirstOrDefault().UserList.Count).Select(t => t.ID).ToList();
                            foreach (var Remain in RemainList)
                            {
                                if (RanList.Count > SelList.Count)
                                    RanList.Remove(Remain);
                            }

                        }

                        for (int i = 1; i < SelList.Count+1; i++)
                        {
                            int RandKey = ran.Next(0, RanList.Count);
                            WeightingClassList.FirstOrDefault(t=>t.ID==RanList[RandKey]).UserList.Add(SelList[i - 1]);
                            RanList.Remove(RanList[RandKey]);
                        }
                        SelWeightingDataList.RemoveRange(0, SelList.Count);
                    }
                }

                var girlspeaklist = GirlList.OrderBy(t => t.SpeakLevel).Select(t => t.SpeakLevel).Distinct().ToList();
                foreach (int speak in girlspeaklist)
                {
                    List<WeightingData2> SelWeightingDataList = GirlList.Where(t => t.SpeakLevel == speak).OrderBy(t => t.ParnetEdu).ToList();
                    while (SelWeightingDataList.Count > 0)
                    {
                        List<WeightingData2> SelList = SelWeightingDataList.Take(ClassCount).ToList();
                        List<Test> testnum = new List<Test>();
                        Random ran = new Random();
                        List<int> RanList = new List<int>();
                        for (int i = 0; i < WeightingClassList.Count; i++)
                        {
                            RanList.Add(WeightingClassList[i].ID);
                            //RanList.Add(i);
                        }
                        if (SelList.Count < ClassCount)
                        {
                            //补足
                            var RemainList = WeightingClassList.Where(t => t.UserList.Count != WeightingClassList.OrderBy(m => m.UserList.Count).FirstOrDefault().UserList.Count).Select(t => t.ID).ToList();
                            foreach (var Remain in RemainList)
                            {
                                if (RanList.Count > SelList.Count)
                                    RanList.Remove(Remain);
                            }

                        }
                        for (int i = 1; i < SelList.Count+1; i++)
                        {
                            int RandKey = ran.Next(0, RanList.Count);
                            WeightingClassList.FirstOrDefault(t => t.ID == RanList[RandKey]).UserList.Add(SelList[i - 1]);
                            //WeightingClassList[RanList[RandKey]].UserList.Add(SelList[i - 1]);
                            RanList.Remove(RanList[RandKey]);
                        }
                        SelWeightingDataList.RemoveRange(0, SelList.Count);
                    }
                }
                #endregion
            }
            else
            {
                #region 女生
                var speaklist = WeightingDataList.OrderBy(t => t.SpeakLevel).Select(t => t.SpeakLevel).Distinct().ToList();
                foreach (int speak in speaklist)
                {
                    List<WeightingData2> SelWeightingDataList = WeightingDataList.Where(t => t.SpeakLevel == speak).OrderBy(t => t.ParnetEdu).ToList();
                    while (SelWeightingDataList.Count > 0)
                    {
                        List<WeightingData2> SelList = SelWeightingDataList.Take(ClassCount).ToList();

                        List<Test> testnum = new List<Test>();
                        Random ran = new Random();
                        List<int> RanList = new List<int>();
                        for (int i = 0; i < WeightingClassList.Count; i++)
                        {
                            RanList.Add(WeightingClassList[i].ID);
                            //RanList.Add(i);
                        }
                        for (int i = 1; i < SelList.Count+1; i++)
                        {
                            //int RandKey = ran.Next(0, RanList.Count);
                            ////WeightingClassList.FirstOrDefault(t => t.ID == RanList[RandKey]).UserList.Add(SelList[i - 1]);
                            //WeightingClassList[RanList[RandKey]].UserList.Add(SelList[i - 1]);
                            //RanList.Remove(RanList[RandKey]);

                            int RandKey = ran.Next(0, RanList.Count);
                            WeightingClassList.FirstOrDefault(t => t.ID == RanList[RandKey]).UserList.Add(SelList[i - 1]);
                            //WeightingClassList[RanList[RandKey]].UserList.Add(SelList[i - 1]);
                            RanList.Remove(RanList[RandKey]);

                        }
                        SelWeightingDataList.RemoveRange(0, SelList.Count);
                    }
                }
                #endregion
            }

            #endregion

            return WeightingClassList;
           

        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                List<StuDivideClassEntity> WeightingClassList = new List<StuDivideClassEntity>();
                //DataTable dt = new StudentDAL().GetStuReg();//获取全部新生
                DataTable dt = new StudentDAL().GetStuAvg(int.Parse(this.ddl_CID.SelectedValue));//获取全部未删除的新生
                Random ran = new Random();
                List<WeightingData2> WeightingDataList = new List<WeightingData2>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        WeightingData2 WeightingData2 = new WeightingData2();
                        WeightingData2.IsBoy = Convert.ToInt32(dt.Rows[i]["UserSex"].ToString()) == 1 ? true : false;
                        WeightingData2.SpeakLevel = Convert.ToInt32(dt.Rows[i]["LevelCommunication"].ToString());
                        WeightingData2.ParnetEdu = Convert.ToInt32(dt.Rows[i]["HighEducation"].ToString());
                        WeightingData2.Name = dt.Rows[i]["StID"].ToString();
                        WeightingDataList.Add(WeightingData2);//
                    }
                    int classcount = int.Parse(this.txt_ClassCount.Text);//班级数量
                    WeightingClassList = Weighting2(WeightingDataList, classcount, true);
                }

               int result = studentDAL.UpdateAvg(WeightingClassList);
               //int result = 0;
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
        #endregion


        



    }
}