/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年08月15日 08时30分
** 描 述:       缴费项目管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Linq;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace GKICMP.payment
{
    public partial class PayItemSelect : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayProjectDAL payProjectDAL = new PayProjectDAL();
        public PayItemDAL payItemDAL = new PayItemDAL();
        public PayProject_ItemDAL payProject_ItemDAL = new PayProject_ItemDAL();

        #region 参数集合
        public string PPID
        {
            get
            {
                return GetQueryString<string>("eid", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //获取已启用的缴费项
                DataTable dt = payItemDAL.GetTable((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.否);
                ////CommonFunction.CBLTypeBind(this.cbl_Button, dt, "PIID", "PayName");   
                //foreach (DataRow row in dt.Rows)
                //{
                //    ListItem li = new ListItem();
                //    li.Text = row["PayName"].ToString();
                //    li.Value = row["PIID"].ToString();
                //    li.Attributes.Add("myValue", row["PIID"].ToString());
                //    cbl_Button.Items.Add(li);
                //}

                this.hf_PPID.Value = PPID.ToString();
            }
        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                PayProject_ItemEntity model = new PayProject_ItemEntity();
                model.PPIID = 0;
                model.PPID = PPID;


                #region 获取缴费项的id
                string button = "";
                foreach (ListItem li in this.cbl_Button.Items)
                {
                    if (li.Selected)
                    {
                        button = button + li.Value + ",";
                    }
                }
                if (button.Length > 0)
                {
                    button = button.Substring(0, button.Length - 1);
                }

                #endregion

                int result = payProject_ItemDAL.Edit(model, button);
                if (result == 0)
                {
                    ShowMessage();
                    int log = PPID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PPID == "" ? "添加" : "修改") + "缴费项的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("缴费项名称已存在，请重新选择");
                    return;
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion




        #region 绑定缴费项(第一次加载和提交失败触发)
        /// <summary>
        /// 绑定缴费项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string Get()
        {

            //获取已启用的缴费项
            DataTable dt = payItemDAL.GetTable((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.否);
            foreach (DataRow row in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Text = row["PayName"].ToString();
                li.Value = row["PIID"].ToString();
                li.Attributes.Add("myValue", row["PIID"].ToString());
                cbl_Button.Items.Add(li);

            }
            return "";
        }
        #endregion

    }
}