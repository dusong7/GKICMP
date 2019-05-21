/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      201611月11日 9时55分47秒
** 描    述:     供应商详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using System.Text;

namespace GKICMP.app
{

    public partial class AppRepairDetail : PageBaseApp
    {
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SupplierDAL SupplierDAL = new SupplierDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL asset_RepairDAL = new Asset_RepairDAL();
        #region 参数集合
        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        /// <summary>
        /// 1代表校产管理 2 代表耗材管理
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (AID != "")
                {
                    BindInfo();
                }
            }
        }
        #region 数据绑定
        public void BindInfo()
        {
            AssetEntity model = assetDAL.GetObjByID(AID);
            if (model != null)
            {
                this.txt_RepairObj.Text = model.AssetName;
                this.txt_DataDesc.Text = model.DataDesc;
                this.txt_SpecificationModel.Text = model.SpecificationModel;
                this.txt_Brand.Text = model.Brand;
                this.txt_BuyDate.Text = model.BuyDate.ToString("yyyy-MM-dd");
                this.txt_PlanYear.Text = Convert.ToString(model.PlanYear);
                this.txt_Type.Text = model.DataTypeName;
                this.txt_AUnit.Text = model.AUnitName;
                SupplierEntity smodel = SupplierDAL.GetList(model.Suppliers);
                this.txt_Suppliers.Text = smodel.SupplierName;//供应商

            }
        }
        #endregion
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Asset_RepairEntity model = new Asset_RepairEntity();
                model.ARID = "";
                model.RepairObj = this.txt_RepairObj.Text.Trim();
                model.CreaterUser = UserID;
                model.DutyDep = Convert.ToInt32(this.hf_Dep.Value);
                //model.DutyDep = Convert.ToInt32(this.ddl_Dep.SelectedValue);
                //model.DutyUser = this.ddl_User.SelectedValue;
                //model.DutyDep = int.Parse(this.hf_Dep.Value);
                model.DutyUser = this.hf_User.Value;
                model.SDID = this.hf_D.Value;
                model.RepairContent = this.txt_RepairContent.Text.Trim();
                model.ARState = Convert.ToInt32(CommonEnum.ARState.已受理);
                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);

                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_File, "AssetFile");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_File.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_File.HasFile)
                        model.ARFile = accessinfo.AccessUrl;
                    else
                        model.ARFile = this.hf_File.Value;
                }
                int result = asset_RepairDAL.EditAPP(model);
                if (result == 0)
                {
                    string msg = "";
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加报修对象为：" + this.txt_RepairObj.Text + "的数据", UserID));
                    string a = XMLHelper.GetXmlNodesAttributes("~/BaseInfoSet.xml", "DX", "IsOpen");
                    if (a == "1")
                    {
                        if (!string.IsNullOrEmpty(this.hf_D.Value))
                        {
                            SupplierEntity sub = new SupplierDAL().GetObjByID(this.hf_D.Value);
                            if (!string.IsNullOrEmpty(sub.LinkPhone))
                            {
                                MessageConfigEntity msmodel = new MessageConfigDAL().GetObjByID("售后服务");
                                msg = ALiDaYu.SendMessage(msmodel, "", sub.LinkPhone);
                                //msg = ALiDaYu.SendMessage("", sub.LinkPhone);
                            }
                            if (!string.IsNullOrEmpty(ID))
                                ShowMessage("提交成功" + msg);
                            else
                                RegisterStartupScript("false", "<script>alert('提交成功" + msg + "');window.location.href='AppMain.aspx'</script>");
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ID))
                                ShowMessage("提交成功");
                            else
                                RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='AppMain.aspx'</script>");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ID))
                            ShowMessage("提交成功");
                        else
                            RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='AppMain.aspx'</script>");
                    }


                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        protected void btn_SearchUser_Click(object sender, EventArgs e)
        {
            string str = "";
            this.txt_User.Text = "";
            DataTable dt = new SysUserDAL().GetSysUserByDepid(1, int.Parse(this.hf_Dep.Value));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "{value:'" + dt.Rows[i]["UID"].ToString() + "',text:'" + dt.Rows[i]["RealName"].ToString() + "'},";
            }
            str = str.TrimEnd(',');
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("(function ($, doc) {");
            sb.Append("$.init();");
            sb.Append("$.ready(function () {");
            sb.Append("    var userPicker1 = new $.PopPicker();");
            sb.Append("    userPicker1.setData([");
            sb.Append(str.ToString());
            sb.Append("    ]);");
            sb.Append("    var showUserPickerButton = doc.getElementById('txt_User');");
            sb.Append("    var userResult = doc.getElementById('txt_User');");
            sb.Append("    var userCustInt = doc.getElementById('hf_User');");
            sb.Append("    showUserPickerButton.addEventListener('tap', function (event) {");
            sb.Append("        userPicker1.show(function (items) {");
            sb.Append("            userResult.value = items[0].text;");
            sb.Append("            userCustInt.value = items[0].value;");
            sb.Append("        });");
            sb.Append("    }, false);");
            sb.Append("});");
            sb.Append("})");
            sb.Append("(mui, document);");
            sb.Append("</script>");
            this.ltl_User.Text = sb.ToString();
        }
    }
}