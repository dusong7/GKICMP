/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      刘福洲
** 创建日期:      2017年08月15日 14时44分01秒
** 描    述:      会议室周查看页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.assetmanage
{
    public partial class AppointmentWeekView : PageBase
    {
        public ClassRoomDAL croomDAL = new ClassRoomDAL();
        public MeetingDAL meetDAL = new MeetingDAL();
        public AppointmentDAL appointmentDAL = new AppointmentDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime now = Convert.ToDateTime(DateTime.Now.ToString(" 00:00"));  //当前时间
                this.txt_MDate.Text = now.ToString("yyyy-MM-dd");
                DateTime startweek = now.AddDays(1 - Convert.ToInt32(now.DayOfWeek.ToString("d")));  //本周周一
                WeekBind(startweek);//星期绑定
                BindRoom(startweek);
            }
        }

        #region 绑定会议室使用情况
        /// <summary>
        /// 绑定会议室使用情况
        /// </summary>
        /// <param name="startweek"></param>
        private void BindRoom(DateTime startweek)
        {
            string begindate = startweek.ToString("yyyy-MM-dd") + " 00:00:00";
            string enddate = startweek.AddDays(6).ToString("yyyy-MM-dd") + " 23:59:59";
            DataTable dt = croomDAL.GetList("-2", 3, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DorState.可用);
            DataTable dvroom = appointmentDAL.GetPaged(Convert.ToDateTime(begindate), Convert.ToDateTime(enddate));
            StringBuilder sbrooms = new StringBuilder("");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    sbrooms.Append("<tr>");
                    sbrooms.AppendFormat("<td rowspan='2' style='background-color: #43c177; color: White;text-align:center;'>{0}</td>", row["RoomName"].ToString());
                    sbrooms.Append(BindDay(Convert.ToDateTime(begindate), dvroom, row, 1));
                    sbrooms.Append("</tr>");
                    sbrooms.Append("<tr>");
                    sbrooms.Append(BindDay(Convert.ToDateTime(begindate), dvroom, row, 2));
                    sbrooms.Append("</tr>");
                }
            }
            this.ltl_Rooms.Text = sbrooms.ToString();
        }
        #endregion

        #region 绑定日期
        /// <summary>
        /// 绑定日期
        /// </summary>
        /// <param name="startweek"></param>
        /// <param name="dvroom"></param>
        /// <param name="row"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string BindDay(DateTime startweek, DataTable dvroom, DataRow row, int type)
        {
            int ischecked = 0;
            string name = type == 1 ? "上午" : "下午";
            StringBuilder sbrooms = new StringBuilder("");
            string title = "";
            for (int i = 0; i < 7; i++)
            {
                string begin = startweek.AddDays(i).ToString("yyyy-MM-dd");
                foreach (DataRow rrow in dvroom.Rows)
                {
                    DateTime mbegin = Convert.ToDateTime(rrow["BeginDate"]);
                    DateTime mend = Convert.ToDateTime(rrow["EndDate"]);
                    string mmbegin = mbegin.ToString("yyyy-MM-dd");
                    string mmend = mend.ToString("yyyy-MM-dd");
                    if ((Convert.ToDateTime(mmend) - Convert.ToDateTime(mmbegin)).Days > 0)
                    {
                        for (int j = 0; j < (Convert.ToDateTime(mmend) - Convert.ToDateTime(mmbegin)).Days; j++)
                        {
                            mmbegin = Convert.ToDateTime(mmbegin).AddDays(j).ToString("yyyy-MM-dd");
                            if (type == 1 && begin == mbegin.ToString("yyyy-MM-dd"))//会议第一天上午
                            {
                                mend = Convert.ToDateTime(mmbegin + " 12:00");
                                break;
                            }
                            else if (type == 2 && begin == mbegin.ToString("yyyy-MM-dd"))//会议第一天下午
                            {
                                mbegin = Convert.ToDateTime(mmbegin + " 12:01");
                                mend = Convert.ToDateTime(mmbegin + " 23:59");
                                break;
                            }
                            else if (type == 1 && begin == mend.ToString("yyyy-MM-dd"))//会议最后一天上午
                            {
                                mbegin = Convert.ToDateTime(mmend + " 00:01");
                                if (Convert.ToDateTime(mend.ToString("HH:mm")) >= Convert.ToDateTime("12:00"))
                                {
                                    mend = Convert.ToDateTime(mmend + " 12:00");
                                }
                                break;
                            }
                            else if (type == 2 && begin == mend.ToString("yyyy-MM-dd"))//会议最后一天下午
                            {
                                mbegin = Convert.ToDateTime(mmend + " 12:01");
                                break;
                            }
                            else if (type == 1 && begin == mmbegin)
                            {
                                mbegin = Convert.ToDateTime(begin + " 00:01");
                                mend = Convert.ToDateTime(begin + " 12:00");
                                break;
                            }
                            else if (type == 2 && begin == mmbegin)
                            {
                                mbegin = Convert.ToDateTime(begin + " 12:01");
                                mend = Convert.ToDateTime(begin + " 23:59");
                                break;
                            }
                        }
                    }

                    string beginday = type == 1 ? begin + " 00:01" : begin + " 12:01";
                    string endday = type == 1 ? begin + " 12:00" : begin + " 23:59";

                    if ((mbegin >= Convert.ToDateTime(beginday) && mbegin <= Convert.ToDateTime(endday)) && row["CRID"].ToString() == rrow["MRID"].ToString() && type == 1)
                    {
                        ischecked = 1;
                        title +=  "&#10;预约人："+rrow["UserName"]+"&#10;预约时间：" + mbegin.ToString("HH:mm") + "至" + mend.ToString("HH:mm") + "&#10;预约说明：" + rrow["AppointmentDesc"] + "&#10;";
                        // break;
                    }
                    if ((mend >= Convert.ToDateTime(beginday) && mend <= Convert.ToDateTime(endday)) && row["CRID"].ToString() == rrow["MRID"].ToString() && type == 2)
                    {
                        ischecked = 1;
                        title += "&#10;预约人：" + rrow["UserName"] + "&#10;预约时间：" + mbegin.ToString("HH:mm") + "至" + mend.ToString("HH:mm") + "&#10;预约说明：" + rrow["AppointmentDesc"] + "&#10;";
                        //break;
                    }
                }

                if (ischecked == 0)
                {
                    sbrooms.AppendFormat(" <td style='background: white;text-align:center;'>{0}</td>", name);
                }
                else
                {
                    sbrooms.AppendFormat(" <td style='background: #27b975;color:#fff;text-align:center;' title='{1}'>{0}</td>", name, title);
                }
                ischecked = 0;
            }
            return sbrooms.ToString();
        }
        #endregion

        #region 星期绑定
        /// <summary>
        /// 星期绑定
        /// </summary>
        /// <param name="now"></param>
        private void WeekBind(DateTime startweek)
        {
            StringBuilder sbdays = new StringBuilder("");
            for (int i = 0; i < 7; i++)
            {
                sbdays.AppendFormat(@"<td style='background: url(../images/highbg.png) top; font-weight: bold; border-right: 1px solid #cccccc;
                                                        text-align: center; border-top: 1px solid #cccccc;'>
                                                       {0}<br />
                                                        （{1}）
                                                    </td>", GetWeekName(startweek.AddDays(i).DayOfWeek.ToString()), startweek.AddDays(i).ToString("MM月dd日"));
            }

            this.ltl_Days.Text = sbdays.ToString();
        }
        #endregion

        #region 获取周
        /// <summary>
        /// 获取周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetWeekName(string dt)
        {
            string week = "";
            switch (dt)
            {
                case "Monday":
                    week = "星期一";
                    break;
                case "Tuesday":
                    week = "星期二";
                    break;
                case "Wednesday":
                    week = "星期三";
                    break;
                case "Thursday":
                    week = "星期四";
                    break;
                case "Friday":
                    week = "星期五";
                    break;
                case "Saturday":
                    week = "星期六";
                    break;
                case "Sunday":
                    week = "星期日";
                    break;
            }
            return week;
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DateTime now = this.txt_MDate.Text.Trim() == "" ? Convert.ToDateTime(DateTime.Now.ToString(" 00:00")) : Convert.ToDateTime(this.txt_MDate.Text.Trim());  //当前时间
            int dayposition = Convert.ToInt32(now.DayOfWeek.ToString("d"));
            if (dayposition == 0)
            {
                dayposition = 7;
            }
            DateTime startweek = now.AddDays(1 - dayposition);  //本周周一
            WeekBind(startweek);
            BindRoom(startweek);
        }
        #endregion
    }
}