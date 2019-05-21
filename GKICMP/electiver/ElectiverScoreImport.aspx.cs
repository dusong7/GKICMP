/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月08日 17时27分33秒
** 描    述:      选课分数导入
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.IO;
using System.Collections.Generic;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.electiver
{
    public partial class ElectiverScoreImport : PageBase
    {
        public Electiver_CourseDAL eleCourseDAL = new Electiver_CourseDAL();
        public Electiver_StuDAL eleStuDAL = new Electiver_StuDAL();
        public ElectiverDAL electiverDAL = new ElectiverDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Electiver_ScoreDAL scoreDAL = new Electiver_ScoreDAL();

        #region 参数集合
        /// <summary>
        /// 任务ID
        /// </summary>
        public int EleID
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
                ElectiverEntity model = electiverDAL.GetObjByID(EleID);
                this.ltl_EYear.Text = model.EYear.ToString();
                this.ltl_TermID.Text = Enum.GetName(typeof(CommonEnum.XQ), model.TermID);
                this.hf_TermID.Value = model.TermID.ToString();

                DataTable dt = eleCourseDAL.GetList(EleID);
                CommonFunction.DDlTypeBind(this.ddl_CourseID, dt, "CourseID", "CourseName", "-2");
            }
        }
        #endregion


        #region 上传导入的文件
        /// <summary>
        /// 上传导入的文件
        /// </summary>
        /// <returns></returns>
        protected string up()
        {
            string path = Server.MapPath("../Template/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (fuimport.HasFile)
            {
                string name = UserID.ToString() + "_ImportGrades_";
                string strfile = System.IO.Path.GetExtension(fuimport.FileName);
                string filename = name + strfile;
                path += filename;
                fuimport.SaveAs(path);
                return path;
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 读取Excel文件
        /// <summary>
        /// 读取Excel文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataTable ReadExcel(string path)
        {
            return CommonFunction.ExportExcel(path);
        }
        #endregion


        #region 导入事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            string path = up();
            //判断是否上传成功
            if (path != "")
            {
                //获取数据
                DataTable dt = ReadExcel(path);
                if (dt != null)
                {
                    // 检查列名
                    string colname = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        colname += dc.ColumnName + ",";
                    }

                    List<string> needcol = new List<string>();
                    if (this.ddl_CourseID.SelectedValue != "")
                    {
                        needcol.Add("选课任务名称");
                        needcol.Add("学年度");
                        needcol.Add("学期");
                        needcol.Add("学生姓名");
                        needcol.Add("身份证号");
                        needcol.Add(this.ddl_CourseID.SelectedItem.Text.ToString());
                    }
                    int count = 0;
                    for (int i = 0; i < needcol.Count; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Count)
                    {
                        List<Electiver_ScoreEntity> list = new List<Electiver_ScoreEntity>();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Electiver_ScoreEntity model = new Electiver_ScoreEntity();
                            if (dt.Rows[i]["身份证号"].ToString() == "" || dt.Rows[i]["选课任务名称"].ToString() == "" || dt.Rows[i]["学年度"].ToString() == "" || dt.Rows[i]["学期"].ToString() == "" || dt.Rows[i]["学生姓名"].ToString() == "")
                            {
                                ShowMessage("导入数据中有不可为空项为空，请检查后重新导入");
                                return;
                            }
                            model.SSID = -1;
                            model.EleID = EleID;
                            string result = sysUserDAL.GetUID(dt.Rows[i]["身份证号"].ToString());
                            if (result != "")
                            {
                                model.StID = result;
                            }
                            else
                            {
                                ShowMessage("【第" + (i + 1) + "行】系统中不存在身份证为：" + dt.Rows[i]["身份证号"].ToString() + ",请修改后再导入。");
                                return;
                            }
                            model.Score = Convert.ToInt32(dt.Rows[i][this.ddl_CourseID.SelectedItem.Text.ToString()].ToString());
                            model.CourseID = Convert.ToInt32(this.ddl_CourseID.SelectedValue.ToString());
                            model.EYear = this.ltl_EYear.Text.ToString();
                            model.TermID = Convert.ToInt32(this.hf_TermID.Value.ToString());
                            model.CreateUser = UserID;

                            list.Add(model);
                        }
                        if (list != null)
                        {
                            int returnvalue = scoreDAL.Import(list);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入成绩信息", UserID));
                                ShowMessage();
                            }
                            else
                            {
                                ShowMessage("提交失败");
                                return;
                            }
                        }
                        else
                        {
                            ShowMessage("导入的信息存在错误");
                            return;
                        }
                    }
                    else
                    {
                        ShowMessage("文件中缺少必要的信息，请检查后重新导入");
                        return;
                    }
                }
                else
                {
                    ShowMessage("文件读取失败，请检查文件是否已损坏");
                    return;
                }
            }
            else
            {
                ShowMessage("文件导入失败");
                return;
            }
        }
        #endregion


        #region 下载学生名单
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable stu = eleStuDAL.GetList(EleID, Convert.ToInt32(this.ddl_CourseID.SelectedValue.ToString()), 1);
            dt.Columns.Add("选课任务名称", typeof(string));
            dt.Columns.Add("学年度", typeof(string));
            dt.Columns.Add("学期", typeof(string));
            dt.Columns.Add("学生姓名", typeof(string));
            dt.Columns.Add("身份证号", typeof(string));
            dt.Columns.Add(this.ddl_CourseID.SelectedItem.Text, typeof(string));

            foreach (DataRow dr in stu.Rows)
            {
                List<string> list = new List<string>();
                list.Add(dr[12].ToString());
                list.Add(this.ltl_EYear.Text.ToString());
                list.Add(this.ltl_TermID.Text.ToString());
                list.Add(dr[10].ToString());
                list.Add(dr[13].ToString());
                list.Add("");

                dt.Rows.Add(list.ToArray());
            }
            try
            {
                //调用导出方法
                CommonFunction.ExportByWeb(dt, "", "学生成绩表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            }
            catch (Exception ee)
            {
                string _err = ee.Message;
            }
        }
        #endregion
    }
}