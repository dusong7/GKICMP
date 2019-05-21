/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年03月27日 08时55分
** 描 述:       会议室管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Text;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;


namespace GKICMP.meeting
{
    public partial class MRoomDayView : PageBase
    {
        public ClassRoomDAL croomDAL = new ClassRoomDAL();
        public MeetingDAL meetDAL = new MeetingDAL();
                             
    

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                    
                DateTime now = Convert.ToDateTime(DateTime.Now.ToString(" 00:00"));  //当前时间
                this.txt_MDate.Text = now.ToString("yyyy-MM-dd");
                HourBind();//星期绑定
                BindRoom(now);
            }
        }
        #endregion


        #region 绑定会议室使用情况
        /// <summary>
        /// 绑定会议室使用情况
        /// </summary>
        /// <param name="startweek"></param>
        private void BindRoom(DateTime startweek)
        {
            DataTable dv = croomDAL.GetList("-2", 2, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DorState.可用);
            DataView dvroom = meetDAL.GetApplyList(startweek, startweek.AddHours(24), (int)CommonEnum.Deleted.未删除);
            StringBuilder sbrooms = new StringBuilder("");
            if (dv != null && dv != null && dv.Rows.Count > 0)
            {
                foreach (DataRow row in dv.Rows)
                {
                    sbrooms.Append("<tr>");
                    sbrooms.AppendFormat("<td style='background-color: #43c177; color: White;text-align:center;'>{0}</td>", row["RoomName"].ToString());
                    sbrooms.Append(BindDay(startweek, dvroom, row));
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
        private static string BindDay(DateTime startweek, DataView dvroom, DataRow row)
        {
            StringBuilder sbrooms = new StringBuilder("");
            for (int i = 8; i < 21; i++)
            {
                sbrooms.Append(BindMin(startweek.ToString("yyyy-MM-dd"), dvroom, row, i, 1));
                sbrooms.Append(BindMin(startweek.ToString("yyyy-MM-dd"), dvroom, row, i, 2));
            }
            return sbrooms.ToString();
        }

        private static string BindMin(string begin, DataView dvroom, DataRow row, int i, int type)
        {
            string title = "";
            int ischecked = 0;
            StringBuilder sbrooms = new StringBuilder("");
            foreach (DataRow rrow in dvroom.Table.Rows)
            {
                string beginday = begin + " " + i.ToString() + (type == 1 ? ":00:00" : ":30:00");
                string endday = begin + " " + i.ToString() + (type == 1 ? ":29:59" : ":59:59");
                DateTime begins = Convert.ToDateTime(rrow["MBegin"]);
                DateTime ends = Convert.ToDateTime(rrow["MEnd"]);
                if (begins <= Convert.ToDateTime(beginday) && ends >= Convert.ToDateTime(beginday) && row["CRID"].ToString() == rrow["MeetingRoom"].ToString())
                {
                    ischecked = 1;
                    title += "\"" + rrow["MTitle"] + "【" + begins.ToString("HH:mm") + "-" + ends.ToString("HH:mm") + "】\"&#10";
                    break;
                }
              
            }

            if (ischecked == 0)
            {
                sbrooms.Append(" <td width='34' style='background: white;text-align:center;'>");
            }
            else
            {
                sbrooms.Append(" <td width='34' style='background: #a3bfae;text-align:center;cursor:pointer;' title='" + title + "'>");
            }
            ischecked = 0;
            return sbrooms.ToString();
        }
        #endregion


        #region 星期绑定
        /// <summary>
        /// 星期绑定
        /// </summary>
        /// <param name="now"></param>
        private void HourBind()
        {
            StringBuilder sbhours = new StringBuilder("");
            StringBuilder sbdmin = new StringBuilder("");
            for (int i = 8; i < 21; i++)
            {
                sbhours.AppendFormat(@"<th colspan='2' width='6%'>{0}</th>", i.ToString());
                sbdmin.Append(@"<td width='34' style='background-color: #43c177; color: #c7e3ff;'>00
                                            </td><td width='34' style='background-color: #43c177; color: #c7e3ff;'>
                                                30 </td>");
            }

            this.ltl_Hours.Text = sbhours.ToString();
            this.ltl_Mins.Text = sbdmin.ToString();
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

            HourBind();
            BindRoom(now);
        }
        #endregion
    }
}