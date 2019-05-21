/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月14日 14时42分45秒
** 描    述:      打卡记录分析
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Diagnostics;
using System.Transactions;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.teachermanage
{
    public partial class AttendRecordSynchro : PageBase
    {
        public AttendRecordDAL recordDAL = new AttendRecordDAL();
        public AttendSetDAL setDAL = new AttendSetDAL();
        public SysUserDAL sysuserDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendVacationDAL vacationDAL = new AttendVacationDAL();


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            #region 带短信
            //try
            //{
            //    int returnvalue = 0;
            //    int result = 0;

            //    DateTime date1 = Convert.ToDateTime(this.txt_BeginDate.Text.ToString());
            //    DateTime date2 = Convert.ToDateTime(this.txt_EndDate.Text.ToString());
            //    int days = (date2 - date1).Days;
            //    if (days > 31)
            //    {
            //        ShowMessage("只可分析31天之内的打卡数据，请重新选择分析时间");
            //        return;
            //    }
            //    DataTable dt = recordDAL.GetRecordList(Convert.ToDateTime(this.txt_BeginDate.Text.ToString()), Convert.ToDateTime(this.txt_EndDate.Text.ToString()), (int)CommonEnum.IsorNot.否);
            //    if (dt.Rows.Count > 0)
            //    {
            //        AttendSetEntity model = setDAL.GetObjByID(1);
            //        if (model == null)
            //        {
            //            ShowMessage("考勤时段未设置，请检查后重新分析");
            //            return;
            //        }
            //        DateTime carddate;
            //        DateTime mbegin;
            //        DateTime mend;
            //        DateTime abegin;
            //        DateTime aend;

            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            carddate = Convert.ToDateTime(dt.Rows[i]["RecordDate"].ToString());
            //            carddate = Convert.ToDateTime(carddate.ToString("HH:mm"));
            //            mbegin = Convert.ToDateTime(model.MBegin.ToString("HH:mm"));
            //            mend = Convert.ToDateTime(model.MEnd.ToString("HH:mm"));
            //            abegin = Convert.ToDateTime(model.ABegin.ToString("HH:mm"));
            //            aend = Convert.ToDateTime(model.AEnd.ToString("HH:mm"));
            //            if ((carddate > mbegin && carddate < mend) || (carddate > abegin && carddate < aend))
            //            {
            //                result = recordDAL.UpdateAnalysis(dt.Rows[i]["ARID"].ToString(), 1);
            //                if (result > 0)
            //                {
            //                    returnvalue = 0;
            //                }
            //                else
            //                {
            //                    returnvalue = -99;
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                result = recordDAL.UpdateAnalysis(dt.Rows[i]["ARID"].ToString(), 0);
            //                if (result > 0)
            //                {
            //                    returnvalue = 0;
            //                }
            //                else
            //                {
            //                    returnvalue = -99;
            //                    return;
            //                }
            //            }
            //        }
            //        if (returnvalue == 0)
            //        {
            //            //获取系统中分析时间内已分析并且异常的打卡数据
            //            DataTable dtDate = recordDAL.GetRecordList(Convert.ToDateTime(this.txt_BeginDate.Text.ToString()), Convert.ToDateTime(this.txt_EndDate.Text.ToString()), (int)CommonEnum.IsorNot.是);
            //            if (dtDate != null && dtDate.Rows.Count > 0)
            //            {
            //                for (int i = 0; i < dtDate.Rows.Count; i++)
            //                {
            //                    string uid = dtDate.Rows[i]["UserID"].ToString();
            //                    SysUserEntity smodel = sysuserDAL.GetObjByID(uid);
            //                    StringBuilder sb = new StringBuilder();
            //                    sb.Append("{");
            //                    sb.Append("\"name\":\"" + smodel.RealName + "\",");
            //                    sb.Append("\"date\":\"" + Convert.ToDateTime(dtDate.Rows[i]["RecordDate"].ToString()).ToString("yyyy-MM-dd") + "\"");
            //                    sb.Append("}");
            //                    string msg = "";

            //                    if (smodel.UserType == 2)
            //                    {
            //                        if (smodel.CompanyNum != "")
            //                        {
            //                            try
            //                            {
            //                                msg = ALiDaYu.SendMessage(sb.ToString(), smodel.CompanyNum, 1);
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                msg = "未通知到相关人员";
            //                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, ex.Message, UserID));
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (smodel.CellPhone != "")
            //                        {
            //                            try
            //                            {
            //                                msg = ALiDaYu.SendMessage(sb.ToString(), smodel.CellPhone, 1);
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                msg = "未通知到相关人员";
            //                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, ex.Message, UserID));
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            ShowMessage();
            //            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "分析时间段为【" + this.txt_BeginDate.Text.Trim().ToString() + "至" + this.txt_EndDate.Text.Trim().ToString() + "】的打卡记录", UserID));
            //        }
            //        else
            //        {
            //            ShowMessage("提交失败");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        ShowMessage("此时间段内没有需要分析的打卡记录");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowMessage();
            //    return;
            //} 
            #endregion
            
            //using (TransactionScope ts = new TransactionScope())
            //{
                try
                {
                    int result = 0;
                    DateTime date1 = Convert.ToDateTime(this.txt_BeginDate.Text.ToString());
                    DateTime date2 = Convert.ToDateTime(this.txt_EndDate.Text.ToString());
                    int days = (date2 - date1).Days;
                    if (days > 31)
                    {
                        ShowMessage("只可分析31天之内的打卡数据，请重新选择分析时间");
                        return;
                    }
                    #region 旧版
                    //DataTable dtUser = recordDAL.GetUserNum();//已分析人员则不再显示
                    //DataTable dtRecord = null;
                    //SysUserEntity smodel = null;
                    //DateTime carddate, mbegin, mend, abegin, aend;
                    //int asid = 0;
                    //int isvaca = 0;

                    //if (dtUser != null && dtUser.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < dtUser.Rows.Count; i++)//循环打卡表里人员数据
                    //    {
                    //        smodel = sysuserDAL.GetObjByID(dtUser.Rows[i]["UserNum"].ToString());
                    //        if (smodel != null)//系统中存在此userid信息
                    //        {
                    //            //根据人员id查询打卡记录
                    //            dtRecord = recordDAL.GetRecordList(Convert.ToDateTime(this.txt_BeginDate.Text.ToString()), Convert.ToDateTime(this.txt_EndDate.Text.ToString()), dtUser.Rows[i]["UserNum"].ToString());
                    //            if (dtRecord != null && dtRecord.Rows.Count > 0)
                    //            {
                    //                asid = smodel.ASID;
                    //                AttendSetEntity model = setDAL.GetObjByID(asid);//获取考勤设置时间
                    //                if (model != null)
                    //                {
                    //                    mbegin = Convert.ToDateTime(model.MBegin.ToString("HH:mm"));
                    //                    mend = Convert.ToDateTime(model.MEnd.ToString("HH:mm"));
                    //                    abegin = Convert.ToDateTime(model.ABegin.ToString("HH:mm"));
                    //                    aend = Convert.ToDateTime(model.AEnd.ToString("HH:mm"));

                    //                    for (int j = 0; j < dtRecord.Rows.Count; j++)//循环打卡记录
                    //                    {
                    //                        carddate = Convert.ToDateTime(dtRecord.Rows[j]["RecordDate"].ToString());
                    //                        carddate = Convert.ToDateTime(carddate.ToString("HH:mm"));
                    //                        isvaca = vacationDAL.IsVacation(carddate);//判断打卡日期是否在假期内
                    //                        if (isvaca == -2)
                    //                        {
                    //                            result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.加班);
                    //                            continue;
                    //                        }

                    //                        if (mend == abegin)//上午结束时间和下午开始时间一致，表示一天可打两次卡
                    //                        {
                    //                            if (carddate <= mbegin || carddate >= aend)//打卡时间在上班时间之前或者下班时间之后
                    //                            {
                    //                                result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.正常);
                    //                                if (result > 0)
                    //                                {
                    //                                    returnvalue = 0;
                    //                                }
                    //                                else
                    //                                {
                    //                                    returnvalue = -99;
                    //                                    return;
                    //                                }
                    //                            }
                    //                            else if (carddate > mbegin && carddate < aend && j == 0)//打卡时间在上班开始时间之后，下班时间之前，并且是第一条数据
                    //                            {
                    //                                result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.迟到);
                    //                                if (result > 0)
                    //                                {
                    //                                    returnvalue = 0;
                    //                                }
                    //                                else
                    //                                {
                    //                                    returnvalue = -99;
                    //                                    return;
                    //                                }
                    //                            }
                    //                            else
                    //                            {
                    //                                result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.早退);
                    //                                if (result > 0)
                    //                                {
                    //                                    returnvalue = 0;
                    //                                }
                    //                                else
                    //                                {
                    //                                    returnvalue = -99;
                    //                                    return;
                    //                                }
                    //                            }
                    //                        }
                    //                        else//上午结束时间和下午开始时间不一致，按照一天四次卡算
                    //                        {
                    //                            if ((carddate <= mbegin && j == 0) || (carddate >= aend && j == dtRecord.Rows.Count - 1) || (carddate >= mend && carddate <= abegin))//打卡时间在上班时间之前并且是第一条数据||在下班之后并且是最后一条数据
                    //                            {
                    //                                result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.正常);
                    //                                if (result > 0)
                    //                                {
                    //                                    returnvalue = 0;
                    //                                }
                    //                                else
                    //                                {
                    //                                    returnvalue = -99;
                    //                                    return;
                    //                                }
                    //                            }
                    //                            else if (((carddate > mbegin && carddate < mend) || (carddate > abegin && carddate < aend)) && j == 0)
                    //                            {
                    //                                result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.迟到);
                    //                                if (result > 0)
                    //                                {
                    //                                    returnvalue = 0;
                    //                                }
                    //                                else
                    //                                {
                    //                                    returnvalue = -99;
                    //                                    return;
                    //                                }
                    //                            }
                    //                            else
                    //                            {
                    //                                result = recordDAL.UpdateAnalysis(dtRecord.Rows[j]["ARID"].ToString(), (int)CommonEnum.RecordType.早退);
                    //                                if (result > 0)
                    //                                {
                    //                                    returnvalue = 0;
                    //                                }
                    //                                else
                    //                                {
                    //                                    returnvalue = -99;
                    //                                    return;
                    //                                }
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    ShowMessage("请检查考勤节点信息设置是否正确");
                    //                    return;
                    //                }
                    //            }
                    //        }
                    //    }
                    //    if (returnvalue == 0)
                    //    {
                    //        ShowMessage();
                    //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "分析时间段为【" + this.txt_BeginDate.Text.Trim().ToString() + "至" + this.txt_EndDate.Text.Trim().ToString() + "】的打卡记录", UserID));
                    //    }
                    //    else
                    //    {
                    //        ShowMessage("提交失败");
                    //        return;
                    //    }
                    //}                
                    //else
                    //{
                    //    ShowMessage("此时间段内无未分析打卡数据");
                    //    return;
                    //}
                    #endregion

                    DataTable dtAttSet = setDAL.GetTable();//获取启用的考勤节点信息
                    DataTable dtRecord = null;
                    int atype = 0;
                    int returnvalue = 0;
                    if (dtAttSet != null && dtAttSet.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtAttSet.Rows.Count; i++)
                        {
                            //查询当前考勤节点是否有考勤数据，没有则跳过
                            dtRecord = recordDAL.GetRecordList(date1, date2, Convert.ToDateTime(dtAttSet.Rows[i]["MBegin"].ToString()), Convert.ToDateTime(dtAttSet.Rows[i]["MEnd"].ToString()));
                            if (dtRecord != null && dtRecord.Rows.Count > 0)
                            {
                                atype = Convert.ToInt32(dtAttSet.Rows[i]["AType"] == null ? "0" : dtAttSet.Rows[i]["AType"].ToString());//获取考勤节点的考勤类型
                                result = recordDAL.UpdateAnalysis(Convert.ToDateTime(dtAttSet.Rows[i]["MBegin"].ToString()), Convert.ToDateTime(dtAttSet.Rows[i]["MEnd"].ToString()), date1, date2, atype);
                                if (result > 0)
                                {
                                    returnvalue = 0;
                                }
                                else
                                {
                                    returnvalue = -1;
                                    return;
                                }
                            }
                        }
                        if (returnvalue == 0)
                        {
                            ShowMessage();
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "分析时间段为【" + this.txt_BeginDate.Text.Trim().ToString() + "至" + this.txt_EndDate.Text.Trim().ToString() + "】的打卡记录", UserID));
                            //ts.Complete();
                        }
                        else
                        {
                            ShowMessage("提交失败");
                            //ts.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        ShowMessage("当前没有启用的考勤节点，请联系系统管理员");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                    //ts.Dispose();
                    return;
                }
            //}
        }
        #endregion
    }
}