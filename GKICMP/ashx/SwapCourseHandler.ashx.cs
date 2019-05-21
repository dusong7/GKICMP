using Baidu.Aip.Speech;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// SwapCourseHandler 的摘要说明
    /// </summary>
    public class SwapCourseHandler : IHttpHandler
    {

        public ScheduleCourseDAL scourseDAL = new ScheduleCourseDAL();
        //public LessonNotesDAL lessonDAL = new LessonNotesDAL();
        public SysUserDAL userDAL = new SysUserDAL();
        public AbsentDAL absentDAL = new AbsentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        private StringBuilder sb = new StringBuilder("");

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Tip":
                    TipPost(context);
                    break;
                case "Swap":
                    SwapCourse(context);
                    break;
                case "Del":
                    Delete(context);
                    break;
                case "ShowAdd":
                    ShowAdd(context);
                    break;
                case "Add":
                    Add(context);
                    break;
                case "ShowTeacher":
                    ShowTeacher(context);
                    break;
                case "TeacherAdd":
                    TeacherAdd(context);
                    break;
                case "TeacherUpdate":
                    TeacherUpdate(context);
                    break;
                case "SEL":
                    SEL(context);
                    break;
                case "Read":
                    Read(context);
                    break;
            }
        }

        /// <summary>
        /// 获取要交换课程的信息
        /// </summary>
        /// <param name="context"></param>
        private void TipPost(HttpContext context)
        {
            string parentscid = context.Request.Params["parentscid"];
            string childscid = context.Request.Params["childscid"];
            //根据ID获取需要调换的课程信息
            string sqlp = " and SCID='" + parentscid + "'";
            DataTable dtp = scourseDAL.GetAllScheduleCourseByWhere(sqlp);
            string s = "";

            //判断被调换课程的位置是否为空
            if (childscid.Length > 10)
            {
                //根据ID获取被调换课程的信息
                string sqlc = " and SCID='" + childscid + "'";
                DataTable dtc = scourseDAL.GetAllScheduleCourseByWhere(sqlc);
                s = "您确认将" + SwapPosition(dtp.Rows[0][5].ToString()) + "的" + dtp.Rows[0][8].ToString() + "课和" + SwapPosition(dtc.Rows[0][5].ToString()) + "的" + dtc.Rows[0][8].ToString() + "课进行调换吗？";
            }
            else
            {
                s = SwapPosition(childscid) + "尚未安排课程，您确认将" + SwapPosition(dtp.Rows[0][5].ToString()) + "的" + dtp.Rows[0][8].ToString() + "课调换到" + SwapPosition(childscid) + "吗？";
            }
            
            sb.Append("{\"result\":\"" + s + "\"}");

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        /// <summary>
        /// 将位置转为星期
        /// </summary>
        /// <param name="pos">传入的位置信息</param>
        /// <returns></returns>
        public string SwapPosition(string pos)
        {
            string days = pos.Substring(0, 1).ToString();
            string section = pos.Substring(pos.Length - 1, 1).ToString();
            switch (days)
            {
                case "1": days = "一"; break;
                case "2": days = "二"; break;
                case "3": days = "三"; break;
                case "4": days = "四"; break;
                case "5": days = "五"; break;
                case "6": days = "六"; break;
                case "7": days = "日"; break;
            }
            string res = "星期" + days + "第" + section + "节";
            return res;
        }

        /// <summary>
        /// 交换课程
        /// </summary>
        /// <param name="context"></param>
        private void SwapCourse(HttpContext context)
        {
            string parentscid = context.Request.Params["parentscid"];
            string childscid = context.Request.Params["childscid"];
            string userid = context.Request.Params["userid"];
            userid = userid.Split(',')[0].ToString();
            //根据当前用户ID获取用户真实姓名
            SysUserEntity userEntity = userDAL.GetObjByID(userid.ToString());

            //根据ID获取需要调换的课程信息
            string sqlp = " and SCID='" + parentscid + "'";
            DataTable dtp = scourseDAL.GetAllScheduleCourseByWhere(sqlp);
            //根据ID获取被调换课程的信息
            string sqlc = " and SCID='" + childscid + "'";
            DataTable dtc = scourseDAL.GetAllScheduleCourseByWhere(sqlc);

            ////调课纪录
            ////LessonNotesEntity entity = new LessonNotesEntity();

            //entity.LSID = Guid.NewGuid().ToString();
            //entity.ClaID = int.Parse(dtp.Rows[0][1].ToString());
            //if (userEntity != null)
            //{
            //    entity.CreateUser = userEntity.RealName;
            //}
            //else
            //{
            //    entity.CreateUser = "";
            //}
            //entity.TID = dtp.Rows[0][3].ToString();
            //entity.OriginalTime = int.Parse(dtp.Rows[0][5].ToString());
            //entity.CID = int.Parse(dtp.Rows[0][2].ToString());

            //判断被调换课程的位置是否为空
            if (childscid.Length > 10)
            {
                ////被调换课程不为空
                //entity.NowTime = int.Parse(dtc.Rows[0][5].ToString());
                //entity.ExTID = dtc.Rows[0][3].ToString();
                //entity.EXCID = int.Parse(dtc.Rows[0][2].ToString());
                //对需要调换课程位置进行修改
                string upPar = "update dbo.Tb_ScheduleCourse set Position=" + dtc.Rows[0][5].ToString() + " where SCID='" + parentscid + "'";
                scourseDAL.Update_Tb_ScheduleCourse(upPar);
                //对被调换课程位置进行修改
                string upChild = "update dbo.Tb_ScheduleCourse set Position=" + dtp.Rows[0][5].ToString() + " where SCID='" + childscid + "'";
                scourseDAL.Update_Tb_ScheduleCourse(upChild);               
            }
            else
            {
                ////被调换课程为空
                //entity.NowTime = int.Parse(childscid.ToString());
                //entity.ExTID = "";
                //entity.EXCID = 0;
                //对需要调换课程位置进行修改
                string upPar = "update dbo.Tb_ScheduleCourse set Position=" + childscid + " where SCID='" + parentscid + "'";
                scourseDAL.Update_Tb_ScheduleCourse(upPar);
            }
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "调课信息", userid));
            ////添加调课纪录
            //int res = lessonDAL.Add(entity);
            //string s = "";
            //if (res == 0)
            //{
            //    s = "success";
            //}
            //else
            //{
            //    s = "fail";
            //}
            sb.Append("{\"result\":\"" + "success" + "\"}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        #region 删除课表根据单元格id
        public void Delete(HttpContext context)
        {
            string scid = context.Request.Params["scid"];
            int result = scourseDAL.Delete(scid);
            if (result > 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "删除课表课程信息", CommonFunction.Decrypt(context.Request.Params["UserID"])));
                sb.Append("{\"result\":\"success\"}");
            }
            else
            {
                sb.Append("{\"result\":\"fail\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 获取可以调的课
        public void ShowAdd(HttpContext context)
        {
            string EYear = "";
            int Term = 0;
            GetTerm(out EYear, out Term);
            string claid = context.Request.Params["claid"];
            string pos = context.Request.Params["pos"];
            StringBuilder sb = new StringBuilder();
            DataTable dt = scourseDAL.GetByclaidorpos(Convert.ToInt32(claid), Convert.ToInt32(pos), EYear, Term);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = "";
                string tid = "";
                int cid = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (cid == Convert.ToInt32(row["CID"].ToString()) && tid == row["TID"].ToString())
                    {

                    }
                    else
                    {
                        name += "{\"CIDName\":\"" + row["CIDName"].ToString() + "\",\"TIDName\":\"" + row["TIDName"].ToString() + "\",\"Flag\":\"" + row["Flag"].ToString() + "\",\"SCID\":\"" + row["SCID"].ToString() + "\",\"CRIDName\":\"" + row["CRIDName"].ToString() + "\"},";
                        cid = Convert.ToInt32(row["CID"].ToString());
                        tid = row["TID"].ToString();
                    }
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion



        #region 添加课程
        public void Add(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string scid = context.Request.Params["scid"];
            string pos = context.Request.Params["pos"];
            int result = scourseDAL.Update(scid, Convert.ToInt32(pos));
            if (result > 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "添加课程信息", CommonFunction.Decrypt(context.Request.Params["UserID"])));
                sb.Append("{\"result\":\"true\"}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 获取可以调的老师信息
        public void ShowTeacher(HttpContext context)
        {
            string EYear = "";
            int Term = 0;
            GetTerm(out EYear, out Term);
            string tid = context.Request.Params["tid"];
            string pos = context.Request.Params["pos"];
            string datas = context.Request.Params["datas"];
            StringBuilder sb = new StringBuilder();
            DataTable dt = scourseDAL.GetShowTeacher(pos, Convert.ToDateTime(datas), tid, EYear, Term);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = "";
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Flag"].ToString() == "1")
                    {
                          //name += "{\"TeacherName\":\"" + row["TIDName"].ToString() + "\",\"TID\":\"" + row["TID"].ToString() + "\",\"Position\":\"" + pos + "\",\"datas\":\"" + datas + "\"},";
                          name += "{\"TeacherName\":\"" + row["TIDName"].ToString() + "\",\"nj\":\"" + row["nj"].ToString() + "\",\"TID\":\"" + row["TID"].ToString() + "\",\"Position\":\"" + pos + "\",\"datas\":\"" + datas + "\"},";
                    }
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 获取可以调的老师信息
        public void TeacherAdd(HttpContext context)
        {
            string SubUser = context.Request.Params["SubUser"];
            string SubDate = context.Request.Params["SubDate"];
            string SubCoruse = context.Request.Params["SubCoruse"];
            string DID = context.Request.Params["DID"];
            string LID = context.Request.Params["LID"];
            string SubNum = context.Request.Params["SubNum"];
            string UID = context.Request.Params["UID"];
            StringBuilder sb = new StringBuilder();
            AbsentEntity model = new AbsentEntity();
            model.SubDate = Convert.ToDateTime(SubDate);
            model.SubUser = SubUser;
            model.SubCoruse = Convert.ToInt32(SubCoruse);
            model.SubNum = Convert.ToInt32(SubNum.Substring(2, 1).ToString());
            model.LID = LID;
            model.CreateUser = UID;
            model.DID = Convert.ToInt32(DID);
            model.Isdel = (int)CommonEnum.IsorNot.否;
            int result = absentDAL.Edit(model);
            if (result == 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "添加教师信息", CommonFunction.Decrypt(context.Request.Params["UserID"])));
                sb.Append("{\"result\":\"true\"}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion



        #region 更新代课老师信息
        public void TeacherUpdate(HttpContext context)
        {
            string tid = context.Request.Params["tid"];
            string abid = context.Request.Params["abid"];

            StringBuilder sb = new StringBuilder();
            int result = absentDAL.Update(tid, Convert.ToInt32(abid));
            if (result > 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "更新代课老师信息", CommonFunction.Decrypt(context.Request.Params["UserID"])));
                sb.Append("{\"result\":\"true\"}");
            }
            else
            {
                sb.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 根据scid获取课表信息
        public void SEL(HttpContext context)
        {
            string scid = context.Request.Params["scid"];
            StringBuilder str = new StringBuilder();
            DataTable dt = scourseDAL.GetTables(scid);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = "";
                string title = "";
                string aa = "";
                foreach (DataRow row in dt.Rows)
                {
                    aa = Split(row["CourseRepeat"].ToString()) + "<label style='display:none;'>:a:c" + row["SCID"].ToString() + ":b:c</label>";
                    title = row["CourseRepeat"].ToString() + "  (" + row["TeacherRepeat"].ToString() + ")" + (row["CRIDName"].ToString() == "" ? "" : "  (" + row["CRIDName"].ToString() + ")");
                    name += "{\"SCID\":\"" + row["SCID"] + "\",\"CourseRepeat\":\"" + row["CourseRepeat"] + "\",\"TeacherRepeat\":\"" + row["TeacherRepeat"] + "\",\"CRIDName\":\"" + row["CRIDName"] + "\",\"Position\":\"" + row["Position"] + "\",\"ClaID\":\"" + row["ClaID"] + "\",\"id\":\"" + row["ClaID"].ToString() + row["Position"].ToString().Substring(0, 1) + row["Position"].ToString().Substring(2, 1) + "\",\"title\":\"" + title + "\",\"teacher\":\"" + row["TID"] + "\",\"aa\":\"" + aa + "\"},";
                }
                str.Append("{\"result\":\"true\",\"data\":[");
                str.Append(name.ToString().TrimEnd(','));
                str.Append("]}");
            }
            else
            {
                str.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(str.ToString());
            context.Response.End();
        }
        #endregion


        #region 换行输出
        public string Split(string name)
        {
            string cname = "";
            if (name != "" && name != "无课")
            {
                for (int i = 0; i < name.Length; i += 2)
                {
                    if (name.Length <= i + 2)
                    {
                        cname += name.Substring(i, name.Length - i).ToString();
                    }
                    else
                    {
                        cname += name.Substring(i, 2).ToString() + "<br>";
                    }
                }
            }
            return cname;
        }
        #endregion


        #region 获取当前学期
        private static void GetTerm(out string EYear, out int term)
        {
            EYear = "";
            term = 0;
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 8 && month >= 2)
            {
                EYear = (year - 1) + "-" + year;
                term = (int)CommonEnum.XQ.下学期;
            }
            else
            {
                if (month <= 12 && month >= 8)
                {
                    EYear = year + "-" + (year + 1);
                }
                else
                {
                    EYear = (year - 1) + "-" + year;
                }
                term = (int)CommonEnum.XQ.上学期;
            }
        }
        #endregion


        public void Read(HttpContext context)
        {
            string aa = context.Request.Params["aa"];
            context.Response.ContentType = "audio/mp3";
            Tts _ttsClient = new Tts("zBoqwIjlyXPT1cKeWxEYwnfg", "j99fGL2teCGk9QTaXfjY6McstdF51dvY");
            var option = new Dictionary<string, object>()
                        {
                            {"spd", 5}, // 语速
                            {"vol", 7}, // 音量
                            {"per", 1}  // 发音人，4：情感度丫丫童声
                         };

            var result = _ttsClient.Synthesis(aa, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {
                string pah = System.Web.HttpContext.Current.Server.MapPath("~/voice.mp3");
                File.WriteAllBytes(pah, result.Data);
            }
            //Speech("~/voice/voice.mp3");
            context.Response.TransmitFile("~/voice.mp3");
        }


        public void Speech(string path)
        {
            //new MCI().Play(AppDomain.CurrentDomain.BaseDirectory + "\voice\voice.mp3", 1); 
            new MCI().Play(System.Web.HttpContext.Current.Server.MapPath(path), 1);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}