using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GK.GKICMP.Entities;
using System.Web;
namespace GKICMP.ashx
{
    /// <summary>
    /// ExamPaperEeStu 的摘要说明
    /// </summary>
    public class ExamPaperEeStu : IHttpHandler
    {
        public ExamPaperDAL examPaperDAL = new ExamPaperDAL();
        public ExerciseDAL exerciseDAL = new ExerciseDAL();
        public ExamPaper_PractStuDAL practStuDAL = new ExamPaper_PractStuDAL();
        public ExamPaper_EeStuDAL EeStuDAL = new ExamPaper_EeStuDAL();
        public ExamPaper_PracticeDAL practiceDAL = new ExamPaper_PracticeDAL();

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Add":
                    Add(context);
                    break;
            }
        }
        private void Add(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            int ppsid = Convert.ToInt32(context.Request.Params["ppsid"].ToString());
            int type = Convert.ToInt32(context.Request.Params["type"].ToString());
            string answer = context.Request.Params["answer"].ToString();
            int eid = Convert.ToInt32(context.Request.Params["eid"].ToString());
            DateTime begin = Convert.ToDateTime(context.Request.Params["begin"].ToString());
            DateTime end = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            string uid = context.Request.Params["uid"].ToString();
            string eppid = "";
            string epid = "";
            ExamPaper_PractStuEntity model = practStuDAL.GetObjByID(ppsid);
            if (model != null)
            {
                eppid = model.EPPID;
                ExamPaper_PracticeEntity model1 = practiceDAL.GetObjByID(model.EPPID);
                if (model1 != null)
                {
                    epid = model1.EPID;
                }
            }
            ExamPaper_EeStuEntity model2 = new ExamPaper_EeStuEntity();
            model2.StuID = uid;
            model2.EPPID = eppid;
            model2.EPID = epid;
            model2.EPEID = -1;
            model2.EID = eid;
            model2.EAnswer = answer;
            if (type == (int)CommonEnum.ExerciseType.单项选 || type == (int)CommonEnum.ExerciseType.多选题 || type == (int)CommonEnum.ExerciseType.判断题)
            {
                ExerciseEntity model3 = exerciseDAL.GetObjByID(eid);
                if (model3 != null)
                {
                    if (model3.Answer == answer)
                    {
                        model2.EScore = model3.Score;
                    }
                    else
                    {
                        model2.EScore = 0;
                    }
                }
            }
            else
            {
                model2.EScore = 0;
            }
            int result = EeStuDAL.Edit(model2, type,begin,end,ppsid);
            if (result == 0)
            {
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}