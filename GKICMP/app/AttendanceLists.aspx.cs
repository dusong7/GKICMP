using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace GKICMP.app
{
    public partial class AttendanceLists : PageBaseApp
    {
        public SysUserDAL UserDal = new SysUserDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public AttendSetDAL AS = new AttendSetDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                this.datePicker.Value = DateTime.Now.ToString("yyyy-MM-dd");
                DataBindList();
            }
        }
        #region 数据绑定
        public void DataBindList()
        {
            string date = this.datePicker.Value;
           //获取未打卡人员
            #region 获取未打卡人员
            DataTable dtWeiDaKa = attendRecordDAL.DakaRenshuTongJi(date);
            string WeiDaKa = "";
            if (dtWeiDaKa != null && dtWeiDaKa.Rows.Count > 0)
            {
                this.lbl_YD.Text =(int.Parse( dtWeiDaKa.Rows[0]["zongrenshu"].ToString())-dtWeiDaKa.Rows.Count) + "/" + dtWeiDaKa.Rows[0]["zongrenshu"].ToString();
                foreach (DataRow dr in dtWeiDaKa.Rows)
                {
                    //WeiDaKa += "<li>" + dr["RealName"] + "</li>";
                    WeiDaKa += "<li>" + dr["RealName"] + "</li>";

                }
            }
            else
            {
                this.lbl_YD.Text = "0/0";
            }
            this.ltl_WeiDaKa.Text = WeiDaKa; 
            #endregion

           //迟到人员
            DataTable dtChiDao = attendRecordDAL.DakaChiDao(date);
            string chidao = "";
            if (dtChiDao != null && dtChiDao.Rows.Count > 0)
            {
                this.lbl_CD.Text = dtChiDao.Rows[0]["zongrenshu"].ToString();
                foreach (DataRow dr in dtChiDao.Rows)
                {
                    chidao += "<li>" + dr["RealName"] + ":" + dr["value"] + "</li>";
                }
            }
            else 
            {
                this.lbl_CD.Text = "0";
            }
            this.ltl_ChiDao.Text = chidao;

            //z早退
            DataTable dtZaoTui = attendRecordDAL.DakaZaoTui(date);
            string ZaoTui = "";
            if (dtZaoTui != null && dtZaoTui.Rows.Count > 0)
            {
                this.lbl_ZT.Text = dtZaoTui.Rows[0]["zongrenshu"].ToString();
                foreach (DataRow dr in dtZaoTui.Rows)
                {
                    //ZaoTui += "<p>" + dr["RealName"] + ":" + dr["value"] + "</p>";
                    ZaoTui += "<li>" + dr["RealName"] + ":" + dr["value"] + "</li>";
                }
            }
            else
            {
                this.lbl_ZT.Text = "0";
            }
            this.ltl_ZaoTui.Text = ZaoTui;

            //请假\外出
            DataTable dtQingJia = attendRecordDAL.DakaQingJia(date);
            string qingjia = "";
            if (dtQingJia != null && dtQingJia.Rows.Count > 0)
            {
                DataRow[] drqingjia = dtQingJia.Select("LFlag=1");
                if (drqingjia != null && drqingjia.Length > 0)
                {
                    this.lbl_QJ.Text = drqingjia.Length.ToString();
                    foreach (DataRow dr in drqingjia)
                    {
                        //qingjia += "<p>" + dr["RealName"] + ":" + dr["BeginDate"] + "-" + dr["EndDate"] + "共" + dr["LeaveDays"] + "天</p>";
                        //qingjia += "<p>" + dr["RealName"] + ":" + Convert.ToDateTime(dr["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(dr["EndDate"]).ToString("yyyy-MM-dd HH:mm") + "  " + dr["LTypeName"] + "  共" + double.Parse(dr["LeaveDays"].ToString()).ToString("0.####") + "天</p>";
                        qingjia += "<li>" + dr["RealName"] + ":" + Convert.ToDateTime(dr["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(dr["EndDate"]).ToString("HH:mm") + "  " + dr["LTypeName"] + "  共" + double.Parse(dr["LeaveDays"].ToString()).ToString("0.####") + "天</li>";                        
                    }
                }
                else
                {
                    this.lbl_QJ.Text = "0";
                }
                this.ltl_QingJia.Text = qingjia;

                DataRow[] drwaichu = dtQingJia.Select("LFlag=2", "LeaveDays desc");
                string waichu = "";
                if (drwaichu != null && drwaichu.Length > 0)
                {
                    this.lbl_WC.Text = drwaichu.Length.ToString();
                    foreach (DataRow dr in drwaichu)
                    {
                        //waichu += "<p>" + dr["RealName"] + ":" + dr["BeginDate"] + "-" + dr["EndDate"] + "共" + dr["LeaveDays"] + "天</p>";
                        //waichu += "<p>" + dr["RealName"] + ":" + Convert.ToDateTime(dr["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(dr["EndDate"]).ToString("yyyy-MM-dd HH:mm") + "  共" + double.Parse(dr["LeaveDays"].ToString()).ToString("0.####") + "天</p>";
                        waichu += "<li>" + dr["RealName"] + ":" + Convert.ToDateTime(dr["BeginDate"]).ToString("yyyy-MM-dd HH:mm") + "-" + Convert.ToDateTime(dr["EndDate"]).ToString("HH:mm") + "  共" + double.Parse(dr["LeaveDays"].ToString()).ToString("0.####") + "天</li>";
                    }
                }
                else
                {
                    this.lbl_WC.Text = "0";
                }
                this.ltl_WaiChu.Text = waichu;
            }
           
           // 缺卡
            DataTable dt1 = AS.List();//考勤规则
            DataTable dtQueKa = attendRecordDAL.DakaQueKa(date);
            //List<AttendRecordEntity> users = ModelConvertHelper<AttendRecordEntity>.ConvertToModel(dtQueKa);
            string queka = "";
            if (dtQueKa != null && dtQueKa.Rows.Count > 0)
            {
                int num = 0;
                foreach (DataRow dr in dtQueKa.Rows) 
                {
                    string[] recordDate = dr["value"].ToString().Split(',');
                    bool AMon = false; bool AMoff = false; bool PMon = false; bool PMoff = false;
                    foreach (string s in recordDate)
                    {
                        
                        if ( Convert.ToDateTime(s) <= Convert.ToDateTime(date + " " + dt1.Rows[1]["MEnd"].ToString()) && Convert.ToDateTime(s) >= Convert.ToDateTime(date + " " + dt1.Rows[0]["MBegin"].ToString()))//上午上班
                        {
                            AMon = true;
                        }
                        else if (Convert.ToDateTime(s) <= Convert.ToDateTime(date + " " + dt1.Rows[3]["MEnd"].ToString()) && Convert.ToDateTime(s) >= Convert.ToDateTime(date  + " " + dt1.Rows[2]["MBegin"].ToString()))//上午下班
                        {
                            AMoff = true;
                        }
                        else if (Convert.ToDateTime(s) <= Convert.ToDateTime(date + " " + dt1.Rows[5]["MEnd"].ToString()) && Convert.ToDateTime(s) >= Convert.ToDateTime(date + " " + dt1.Rows[4]["MBegin"].ToString()))//下午上班
                        {
                            PMon = true;
                        }
                        else if (Convert.ToDateTime(s) <= Convert.ToDateTime(date + " " + dt1.Rows[7]["MEnd"].ToString()) && Convert.ToDateTime(s) >= Convert.ToDateTime(date + " " + dt1.Rows[6]["MBegin"].ToString()))//下午下班
                        {
                            PMoff = true;
                        }
                    }
                    if (!AMon || !AMoff || !PMon || !PMoff)
                    {
                        string desc = "";
                        if (!AMon)
                            desc += "上午上班缺卡,";
                        if (!AMoff)
                            desc += "上午下班缺卡,";
                        if (!PMon)
                            desc += "下午上班缺卡,";
                        if (!PMoff)
                            desc += "下午下班缺卡,";
                        queka += "<p>" + dr["RealName"] + ":" + desc + "</p>"; 
                        num++;
                    }
                }
                this.lbl_QK.Text = num.ToString();
                this.ltl_QueKa.Text = queka;
            }
           

            //DataTable dt = attendRecordDAL.AnalysisCounts(10, 1, ref recordCount, model, (int)CommonEnum.UserType.老师);
            // if (dt != null && dt.Rows.Count > 0)
            //{
            //this.lbl_YD.Text=dt.Rows[0]["YD"].ToString();
            //this.lbl_SD.Text=dt.Rows[0]["SD"].ToString();
            //this.lbl_CD.Text=dt.Rows[0]["CD"].ToString();
            //this.lbl_ZT.Text=dt.Rows[0]["ZT"].ToString();
            //this.lbl_KG.Text=dt.Rows[0]["KG"].ToString();
            //this.lbl_QJ.Text=dt.Rows[0]["QJ"].ToString();
            //this.lbl_WC.Text=dt.Rows[0]["WC"].ToString();
            //}
        }
        #endregion

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataBindList();
        }
    }
}