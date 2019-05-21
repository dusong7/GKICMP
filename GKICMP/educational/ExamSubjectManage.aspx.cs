/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      liufuzhou 
** 创建日期:      2017年01月06日 09时48分17秒
** 描    述:      考试科目教师安排
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
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

namespace GKICMP.educational
{
    public partial class ExamSubjectManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Exam_SubjectDAL exam_SubjectDAL = new Exam_SubjectDAL();
        public Exam_RoomDAL exam_RoomDAL = new Exam_RoomDAL();
        public Exam_TeacherDAL teacherDAL = new Exam_TeacherDAL();

        #region 参数集合
        /// <summary>
        /// 考试ID
        /// </summary>
        public int EID
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
                this.hf_EID.Value = EID.ToString();
                RoomBind();
                GetCourseInfo();
            }
        } 
        #endregion


        #region 考场Repeater控件绑定
        /// <summary>
        /// 考场Repeater控件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rp_ExamRoom_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                for (int i = 0; i < Convert.ToInt32(this.hf_examroom.Value); i++)
                {
                    Repeater rp_Subject = (Repeater)e.Item.FindControl("rp_Subject");
                    string erid = ((HiddenField)e.Item.FindControl("hf_ERID")).Value;
                    this.hf_ERID1.Value = erid;
                    DataTable dt = exam_SubjectDAL.GetListByEIDAll(EID.ToString(), Convert.ToInt32(erid));
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        rp_Subject.DataSource = dt;
                        rp_Subject.DataBind();
                    }
                }
            }
        }
        #endregion


        #region 科目Repeater控件绑定
        /// <summary>
        /// 科目Repeater控件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rp_Subject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                TextBox txt = (TextBox)e.Item.FindControl("txt_TID");
                string cid = ((HiddenField)e.Item.FindControl("hf_CID")).Value;
                DataTable dt = teacherDAL.GetByObj(EID.ToString(), Convert.ToInt32(this.hf_ERID1.Value), Convert.ToInt32(cid));
                if (dt != null && dt.Rows.Count > 0)
                {
                    string text = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        text += dr["TID"].ToString() + ",";
                    }
                    txt.Text = text.TrimEnd(',');
                }
            }
        }
        #endregion


        #region 刷新页面
        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn_inquiry_Click(object sender, ImageClickEventArgs e)
        {
            RoomBind();
            GetCourseInfo();
        }
        #endregion


        #region 考场信息绑定
        /// <summary>
        /// 考场信息绑定
        /// </summary>
        private void RoomBind()
        {
            DataTable dt = exam_RoomDAL.GetList(EID.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                this.hf_examroom.Value = dt.Rows.Count.ToString();
                this.rp_ExamRoom.DataSource = dt;
                this.rp_ExamRoom.DataBind();
            }
        }
        #endregion


        #region 获取考试科目信息
        /// <summary>
        /// 获取考试科目信息
        /// </summary>
        private void GetCourseInfo()
        {
            DataTable dt = exam_SubjectDAL.GetByEID(EID.ToString());
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


        #region 删除科目信息
        /// <summary>
        /// 删除科目信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string esid = lbtn.CommandArgument.ToString();
                int result = exam_SubjectDAL.DeleteBat(esid);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除考试科目信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                RoomBind();
                GetCourseInfo();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExamManage.aspx", true);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string erid = "";
            //string cid = "";
            //string tid = "";
            string roomNum = "";
            string stuNum = "";
            try
            {
                List<ExamSetEntity> list = new List<ExamSetEntity>();
                //监考教师
                foreach (RepeaterItem i in this.rp_ExamRoom.Items)
                {
                    erid = ((HiddenField)i.FindControl("hf_ERID")).Value;//考场ID
                    Repeater rp_Subject = (Repeater)i.FindControl("rp_Subject");
                    stuNum = ((TextBox)i.FindControl("txt_StuNum")).Text;//考生数
                    roomNum = ((TextBox)i.FindControl("txt_ClassRoom")).Text;//考场号
                    foreach (RepeaterItem j in rp_Subject.Items)
                    {
                        ExamSetEntity model = new ExamSetEntity();
                        model.Exam = EID.ToString();
                        model.ERoom = int.Parse(erid);
                        model.CID = int.Parse(((HiddenField)j.FindControl("hf_CID")).Value);//课程id
                        model.TID = ((TextBox)j.FindControl("txt_TID")).Text;//监考教师
                        model.RoomNum = roomNum;
                        //model.StuNum =int.Parse( ((TextBox)j.FindControl("txt_StuNum")).Text);//考生数
                        model.StuNum = int.Parse(stuNum);//考生数
                        model.TNum = model.TID == "" ? 0 : model.TID.Split(',').Length;
                        list.Add(model);
                    }
                }
                //阅卷老师
                foreach (RepeaterItem i in this.rp_List.Items)
                {
                    ExamSetEntity model = new ExamSetEntity();
                    model.Exam = EID.ToString();
                    model.ERoom = -3;
                    model.CID = int.Parse(((HiddenField)i.FindControl("hf_CIDS")).Value);
                    model.TID = ((TextBox)i.FindControl("txt_TIDS")).Text;
                    model.RoomNum = "0";
                    model.StuNum = 0;
                    model.TNum = 0;
                    list.Add(model);
                }

                int result = teacherDAL.SetTeacher(list);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "设置考场信息：教师安排，考场号、学生数、监考教师数", UserID));
                    //ShowMessage("提交成功");
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('提交成功');window.location.href='ExamManage.aspx'</script>");
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage("操作失败，请刷新页面重新再试");
            }
        }

        #region 获取阅卷老师
        protected void rp_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                TextBox txt = (TextBox)e.Item.FindControl("txt_TIDS");
                string cid = ((HiddenField)e.Item.FindControl("hf_CIDS")).Value;
                DataTable dt = teacherDAL.GetByObj(EID.ToString(), -3, Convert.ToInt32(cid));
                if (dt != null && dt.Rows.Count > 0)
                {
                    string text = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        text += dr["TID"].ToString() + ",";
                    }
                    txt.Text = text.TrimEnd(',');
                }
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            string erid = "";
            string roomNum = "";
            string stuNum = "";


            //获取监考教师列表
            List<string> tlist = new List<string>();//教师列表
            DataTable dt = teacherDAL.GetTList(EID);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    tlist.Add(dr[0].ToString());
                }
            }
            else 
            {
                ShowMessage("未获取到符合条件的教师，请手动添加");
                return;
            }
            List<ExamSetEntity> list = new List<ExamSetEntity>();
            foreach (RepeaterItem i in this.rp_ExamRoom.Items)
            {
                //tlist.Remove();
                erid = ((HiddenField)i.FindControl("hf_ERID")).Value;//考场ID
                Repeater rp_Subject = (Repeater)i.FindControl("rp_Subject");
                stuNum = ((TextBox)i.FindControl("txt_StuNum")).Text;//考生数
                roomNum = ((TextBox)i.FindControl("txt_ClassRoom")).Text;//考场号
                foreach (RepeaterItem j in rp_Subject.Items)
                {
                    ExamSetEntity model = new ExamSetEntity();
                    model.Exam = EID.ToString();
                    model.ERoom = int.Parse(erid);
                    model.CID = int.Parse(((HiddenField)j.FindControl("hf_CID")).Value);//课程id
                    //排除同一门课同一个教师
                    foreach (ExamSetEntity es in list)
                    {
                        if (es.CID == model.CID)
                        {
                            string[] t = es.TID.Split(',');
                            foreach (string s in t)
                            {
                                tlist.Remove(s);
                            }
                        }
                    }
                    List<int> rlist = CommonFunction.GetRandom(0, true, tlist.Count, false,int.Parse( this.txt_TCount.Text), false);//随机数列表
                    string tid = "";
                    foreach (int a in rlist) 
                    {
                        tid += tlist[a] + ",";
                    }
                    model.TID = tid.TrimEnd(',');//监考教师


                    model.RoomNum = roomNum;
                    model.StuNum = int.Parse(stuNum);//考生数
                    model.TNum = model.TID == "" ? 0 : model.TID.Split(',').Length;
                    list.Add(model);
                }
            }
            int result = teacherDAL.SetTeacher(list);
            if (result == 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "系统自动分配监考教师", UserID));
                //ShowMessage("提交成功");
                //ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('提交成功');window.location.href='ExamManage.aspx'</script>");
            }
            else
            {
                ShowMessage("提交失败");
                return;
            }

            RoomBind();
            GetCourseInfo();
        }
    }
}