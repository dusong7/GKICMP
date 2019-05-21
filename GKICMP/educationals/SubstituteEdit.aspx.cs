/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       代课安排修改
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.educationals
{
    public partial class SubstituteEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public AbsentDAL absentDAL = new AbsentDAL();



        #region 参数集合
        public int AbID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AbID != -1)
                {
                    GetSchedule();
                }
            }
        }
        #endregion


        #region 获取代课人的信息
        public void GetSchedule()
        {
            AbsentEntity model = absentDAL.GetObjByID(AbID);
            if (model != null)
            {
                StringBuilder str = new StringBuilder();
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
                string[] arryStr = new string[] { "", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
                str.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' class='tb'>");
                str.Append("<tr>");
                for (int i = 0; i <= WeekDays; i++)
                {
                    if (i == Convert.ToInt32(model.SubDate.DayOfWeek))
                    {
                        str.AppendFormat("<th>{0}</th>", arryStr[Convert.ToInt32(model.SubDate.DayOfWeek)].ToString() + "</br>" + model.SubDate.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        str.AppendFormat("<th>{0}</th>", arryStr[i].ToString());
                    }
                }
                str.Append("</tr>");

                for (int j = 1; j <= (WSnum + SWnum + XWnum); j++)
                {
                    str.Append("<tr>");
                    for (int k = 0; k <= WeekDays; k++)
                    {
                        if (k == 0)
                        {
                            str.AppendFormat("<th>第{0}节课</th>", j.ToString());
                        }
                        else
                        {
                            if (j == model.SubNum && k == Convert.ToInt32(model.SubDate.DayOfWeek))
                            {
                                str.AppendFormat("<td tid=\"{0}\" pos=\"{1}\" data=\"{2}\" abid=\"{3}\" onContextMenu=\"showteacher(this)\">{4}</td>", model.SubUser, Convert.ToInt32(model.SubDate.DayOfWeek).ToString() + "0" + j.ToString(), model.SubDate.ToString("yyyy-MM-dd"), AbID, model.SubCoruseName + "   (" + model.SubUserName + ")");
                            }
                            else
                            {
                                str.AppendFormat("<td>{0}</td>", "");
                            }
                        }
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                this.lbl_SC.Text = str.ToString();
            }
        }
        #endregion


        #region 刷新
        protected void btn_Freash_Click(object sender, EventArgs e)
        {
            GetSchedule();
        }
        #endregion


        #region 返回
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('SubstituteManage.aspx', '_self')</script>");
            Response.Write(aa);
        }
        #endregion
    }
}