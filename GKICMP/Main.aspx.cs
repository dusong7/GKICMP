
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    20177214日
** 描 述:       工作计划管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

using Baidu.Aip.Speech;
using System.IO;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Threading;



namespace GKICMP
{
    public partial class Main : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public WorkPlanDAL workPlanDAL = new WorkPlanDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        public string text = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hffth.Value = UserID;
                this.ltl_Weeks.Text = CommonFunction.Weeks(DateTime.Now, sysSetConfigDAL.GetObjByID().BeginFristDate).ToString();

                BindList();//绑定条数

                DataBindList();
                DataBind();
                LoadClassSchedule();

               // ListenVoice();//电子政务语言播报
            }
        }

        #region 工作计划绑定
        public void DataBindList()
        {
            WorkPlanEntity model = new WorkPlanEntity();
            model.CreateUser = UserID;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            model.DutyUser = UserID;
            model.DutyUserName = UserRealName;
            DataTable dt = workPlanDAL.GetMainTable(model,int.Parse(this.ltl_Weeks.Text));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion

        #region 课表绑定
        
        #endregion


        #region 校内通知绑定
        public void DataBind()
        {
            AfficheEntity model = new AfficheEntity();
            model.SendUser = UserID;
            DataTable dt = afficheDAL.GetAfficheTable(UserID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ul_affice.Visible = false;
            }
            else
            {
                this.ul_affice.Visible = true;
            }
            this.rp_Affice.DataSource = dt;
            this.rp_Affice.DataBind();

        }
        #endregion

        #region 班级排课信息加载
        /// <summary>
        /// 班级排课信息加载
        /// </summary>
        public void LoadClassSchedule()
        {
            int WeekDays = 0;
            int SWnum = 0;
            int XWnum = 0;
            int WSnum = 0;
            ScheduleSetEntity smodel = setDAL.GetObjByID();//获取基础设置信息
            if (smodel != null)
            {
                WeekDays = smodel.CourseDay;
                SWnum = smodel.MorningPitch;
                XWnum = smodel.AfterPitch;
                WSnum = smodel.EveningPitch;
            }
            string[] arryStr = new string[] { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };

            //this.tab.Height = ((4 + 4 + 2) * 40 + 40);
            //this.tab.Width = (6 * 100 + 20);

            for (int a = 0; a <= (SWnum + XWnum + WSnum); a++)
            {
                TableRow myRow = new TableRow();
                if (a == 0)
                {
                    for (int b = 0; b < WeekDays + 1; b++)
                    {
                        TableHeaderCell myCell = new TableHeaderCell();
                        if (b == 0)
                        {
                            myCell.Text = "";
                        }
                        else
                        {
                            myCell.Text = arryStr[b - 1];
                        }
                        myRow.Cells.Add(myCell);
                    }
                }
                else
                {
                    for (int c = 0; c < WeekDays + 1; c++)
                    {
                        TableCell myCell = new TableCell();
                        if (c == 0)
                        {
                            myCell.Text = "第" + a + "节课";
                        }
                        else
                        {

                            myCell.Text = LoadClassScheduleData(a, c);
                            //myCell.Attributes.Add("onmouseover", "this.style.background='#C4C6C8'");
                            //myCell.Attributes.Add("onmouseout", "this.style.background=''");
                        }
                        myRow.Cells.Add(myCell);
                    }
                }
                tab.Rows.Add(myRow);
            }
        }
      
        public string LoadClassScheduleData(int a, int b)
        {
            string str = "";
            string sql = " and TID=" + "'" + UserID + "'";
            DataTable dt = scourseDAL.GetAllScheduleCourseByWhere(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int x = 0;
                    int y = 0;

                    string p = dt.Rows[i]["Position"].ToString();

                    x = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(0, 1));
                    y = Convert.ToInt32(dt.Rows[i]["Position"].ToString().Substring(1, 2));

                    if ((a == y) && (b == x))
                    {
                        str = dt.Rows[i]["CourseRepeat"].ToString() + "        (" + dt.Rows[i]["ClaIDName"].ToString() + ")" + "<br />" + "<label style='display:none;'>:a:c" + dt.Rows[i]["SCID"].ToString() + ":b:c</label>";

                        break;
                    }
                }
            }
            return str;
        }
        #endregion


        #region 绑定条数
        /// <summary>
        /// 绑定条数
        /// </summary>
        private void BindList()
        {
            DataTable dt = new MainDAL().GetPaged(UserID);
            this.lbl_wdzw.Text = dt.Rows[0]["dzzw"].ToString();//未读政务
            this.lbl_jsqj.Text = dt.Rows[0]["jsqj"].ToString();//教师请假
            this.lbl_wzsh.Text = dt.Rows[0]["wzsh"].ToString();//学生请假
            this.lbl_dkjl.Text = dt.Rows[0]["dkjl"].ToString();//代课记录
            this.lbl_bxjl.Text = dt.Rows[0]["bxjl"].ToString();//报修记录
            Thread tft = new Thread(delegate() 
            {
                ListenVoice(this.lbl_wdzw.Text);//电子政务语言播报
            });

            if (dt.Rows[0]["dzzw"].ToString()=="0")
            {
                text = " ";
            }
            else
            {
                text = "您有" + dt.Rows[0]["dzzw"].ToString() + "份新的电子政务，请及时查收！";
            }

            tft.Start();
            
        }
        #endregion

        #region 电子政务语言播报
        public void ListenVoice(string wdzw)
        {
            try
           {
               Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
               var option = new Dictionary<string, object>()
                        {
                            {"spd", 5}, // 语速
                            {"vol", 7}, // 音量
                            {"per", 0}  // 发音人，4：情感度丫丫童声
                         };

               var result = _ttsClient.Synthesis(wdzw == "0" ? " " : "您有" + wdzw + "份新的电子政务，请及时查收！", option);

               if (result.ErrorCode == 0)  // 或 result.Success
               {
                   string pah = Server.MapPath("~/voice/voice.mp3");
                   File.WriteAllBytes(pah, result.Data);
               }
               Speech("~/voice/voice.mp3");

               
            }
            catch (Exception ex)
            {
                ShowMessage("正在加载中");
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }

        public void Speech(string path)
        {
            //new MCI().Play(AppDomain.CurrentDomain.BaseDirectory + "\voice\voice.mp3", 1); 
            new MCI().Play(Server.MapPath(path), 1);
        }

        #endregion

       



    }
}