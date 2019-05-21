using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.sysmanage
{
    

    public partial class SysConfig : PageBaseApp
    {
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");//学期
                if (DateTime.Now.Month > 8)
                {
                    this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                   
                }
                else
                {
                    this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                }

                InfoBind();
            }
        }


        #region 数据绑定
        public void InfoBind() 
        {
         //   this.txt_TFirst.Text = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "TFristDate");
            this.txt_ServerUrl.Text = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl");
            string xd= XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "XD");
            string[] a = xd.Split(',');
            foreach (ListItem li in this.cbl_XD.Items)
            {
                foreach (string s in a) 
                {
                    if (s == li.Value)
                        li.Selected = true;
                }
            }

            SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
            if (model != null)
            {
                this.txt_EYear.Text= model.EYear;//学年
                this.ddl_Term.SelectedValue = Convert.ToString(model.NowTerm);//学期
                this.txt_TFirst.Text = model.BeginFristDate.ToString();
            }
            

        }
        #endregion


        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            string value = "";
            try
            {
                if (this.txt_ServerUrl.Text != "")
                {
                    localhost1.WebService1 ws = new localhost1.WebService1();
                    ws.Url = this.txt_ServerUrl.Text + "/WebService1.asmx";
                    value = ws.HelloWorld();
                }
                else
                {
                    XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "ServerUrl", this.txt_ServerUrl.Text);
                }
            }
            catch (Exception error)
            {
                //ShowMessage("地址出错，请重新输入");
                this.txt_ServerUrl.Text = "";
                //return;
            }

            if (XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TFristDate", this.txt_TFirst.Text))
            {
                //ShowMessage("提交成功");
            }
            else
            {
                //ShowMessage("提交失败，请稍候再试");
            }

            if (value == "You Are Welcome")
            {
                XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "ServerUrl", this.txt_ServerUrl.Text);
            }
            else 
            {
                //ShowMessage("请配置正确的区平台地址");
                this.txt_ServerUrl.Text = "";
            }

            string xd = "";
            foreach (ListItem li in this.cbl_XD.Items)
            {
                if (li.Selected)
                {
                    xd = xd + li.Value + ",";
                }
            }
            if (XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "XD", xd.TrimEnd(',')))
            {
                ShowMessage("提交成功");
            }


           SysSetConfigEntity model = new SysSetConfigEntity();
           model.EYear =  this.txt_EYear.Text;//学年
           model.NowTerm = Convert.ToInt32(this.ddl_Term.SelectedValue) ;//学期
           model.BeginFristDate = Convert.ToDateTime(this.txt_TFirst.Text);//开学第一天

            int result = sysSetConfigDAL.Add(model);
            if (result == 0)
            {
                int log = (int)CommonEnum.LogType.操作日志_修改;
                sysLogDAL.Edit(new SysLogEntity(log, "修改系统配置项", UserID));
                ShowMessage("提交成功");
            }
            else
            {
                ShowMessage("提交失败");
                return;
            }

            //ShowMessage("提交成功");
            //if (XMLHelper.UpdateXmlNodes("~/BaseInfoSet.xml", "TFristDate", this.txt_TFirst.Text)) 
            //{
            //    ShowMessage("提交成功");
            //}
           
        }
    }
}