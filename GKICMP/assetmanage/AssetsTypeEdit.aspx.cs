/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:    2016年11月17日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;


namespace ICMP.assetmanage
{
    public partial class AssetsTypeEdit : PageBase
    {
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();


        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public int SDID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        public int PID
        {
            get
            {
                return GetQueryString<int>("pid", -1);
            }
        }

        /// <summary>
        /// 资产 1 耗材 2
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -2);
            }
        }
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Flag == 1)//资产
                {
                    this.ltl_Type.Text = "资产分类信息";
                    this.ltl_Name.Text = "资产名称";
                    this.ltl_DataDesc.Text = "代码";
                    DataTable DataType = assetTypeDAL.GetList((int)CommonEnum.Deleted.未删除, 1);
                    ModelParent(DataType, "-1", this.ddl_Parent, "");//递归栏目菜单
                    this.ddl_Parent.SelectedValue = PID.ToString();
                }
                if (Flag == 2)//耗材
                {
                    this.ltl_Type.Text = "分类信息";
                    this.ltl_Name.Text = "分类名称";
                    this.ltl_DataDesc.Text = "备注";
                    DataTable Type = SysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.耗材分类);
                    this.ddl_Parent.Items.Add(new ListItem("--请选择--", "-2"));
                    ModelParent(Type, "-1", this.ddl_Parent, ""); //递归栏目菜单
                    this.ddl_Parent.SelectedValue = PID.ToString();
                }
                if (SDID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            string slt;
            slt = string.Format("PID='{0}'", parentid);
            DataRow[] drarr = dt.Select(slt);

            // ListItem item = new ListItem();
            //item.Text = "--请选择--";
            //item.Value = "-1";
            foreach (DataRow dr in drarr)
            {
                if (parentid == "-1")
                {
                    str_ = "";
                }
                else
                {
                    str_ = "├";
                }
                ListItem item = new ListItem();
                // ddl.Items.Add("--请选择--");
                item.Text = str + str_ + dr["DataName"].ToString();     //Bind text
                item.Value = dr["SDID"].ToString();                                //Bind value
                string parent_id = item.Value;

                ddl.Items.Add(item);


                ModelParent(dt, parent_id, ddl, str + "..          ");
            }

        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            if (Flag == 1)
            {
                AssetTypeEntity model = assetTypeDAL.GetObjByID(SDID);
                if (model != null)
                {
                    this.ddl_Parent.SelectedValue = Convert.ToString(model.PID);//上级名称
                    this.txt_DataName.Text = model.DataName.Trim();
                    this.txt_DataDesc.Text = model.DataDesc;
                }
            }
            else
            {
                SysDataEntity model = SysDataDAL.GetObjByID(SDID);
                if (model != null)
                {
                    this.ddl_Parent.SelectedValue = Convert.ToString(model.PID);//上级名称
                    this.txt_DataName.Text = model.DataName.Trim();
                    this.txt_DataDesc.Text = model.DataDesc;
                }
            }

        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Flag == 1)
                {
                    int mid = -1;
                    if (SDID == -1)//添加时获取大类信息
                    {
                        AssetTypeEntity amodel = assetTypeDAL.GetObjByID(PID);
                        if(amodel.PID==-1)
                        {
                            mid = PID;
                        }
                        else
                        {
                            mid = amodel.MaxID;
                        }
                    }
                    AssetTypeEntity model = new AssetTypeEntity();
                    model.SDID = SDID;
                    model.DataName = this.txt_DataName.Text.ToString().Trim();
                    model.DataDesc = this.txt_DataDesc.Text.ToString().Trim();
                    model.DataType = Flag;
                    model.Isdel = (int)CommonEnum.Deleted.未删除;
                    model.MaxID = mid;
                    if (Convert.ToInt32(this.ddl_Parent.SelectedValue) == -2)
                    {
                        model.PID = -1;
                    }
                    else
                    {
                        model.PID = Convert.ToInt32(this.ddl_Parent.SelectedValue);
                    }

                    int result = assetTypeDAL.Edit(model);
                    if (result == -1)
                    {
                        ShowMessage("提交失败");
                        return;
                    }
                    else if (result == -2)
                    {
                        ShowMessage(model.DataName + "名称已存在，请重新输入");
                        return;
                    }
                    else
                    {
                        int log = SDID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                        sysLogDAL.Edit(new SysLogEntity(log, (SDID == -1 ? "添加" : "修改") + this.ltl_Name.Text + "【" + this.txt_DataName.Text + "】信息", UserID));
                        ShowMessage();
                    }
                }
                else
                {
                    SysDataEntity model = new SysDataEntity();
                    model.SDID = SDID;
                    model.DataName = this.txt_DataName.Text.ToString().Trim();
                    model.DataDesc = this.txt_DataDesc.Text.ToString().Trim();
                    model.DataType = (int)CommonEnum.DataType.耗材分类;
                    model.Isdel = (int)CommonEnum.Deleted.未删除;
                    if (Convert.ToInt32(this.ddl_Parent.SelectedValue) == -2)
                    {
                        model.PID = -1;
                    }
                    else
                    {
                        model.PID = Convert.ToInt32(this.ddl_Parent.SelectedValue);
                    }

                    int result = SysDataDAL.Edit(model);
                    if (result == -1)
                    {
                        ShowMessage("提交失败");
                        return;
                    }
                    else if (result == -2)
                    {
                        ShowMessage(model.DataName + "名称已存在，请重新输入");
                        return;
                    }
                    else
                    {
                        int log = SDID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                        sysLogDAL.Edit(new SysLogEntity(log, SDID == -1 ? "添加" : "修改" + this.ltl_Name.Text + "【" + this.txt_DataName.Text + "】信息", UserID));
                        ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, "admin"));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}