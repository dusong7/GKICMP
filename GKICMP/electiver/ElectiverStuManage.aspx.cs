/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:      班级选课名单
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;

namespace GKICMP.electiver
{
    public partial class ElectiverStuManage : PageBase
    {
        public ElectiverDAL electiverDAL = new ElectiverDAL();
        public Electiver_StuDAL electivestuDAL = new Electiver_StuDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        protected int v = 0;
        protected int x = 0;

        #region 参数集合
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// Depth
        /// </summary>
        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
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
                DataTable dt = electiverDAL.GetTable();
                CommonFunction.DDlTypeBind(this.ddl_EleID, dt, "EleID", "ElectiverName", "-999");
                DepartmentEntity model = departmentDAL.GetObj(ClaID);
                if (model != null)
                {
                    this.lbl_claid.Text = model.OtherName;
                }
                if (Deep != -1 && Deep != 0)
                {
                    DataBindList();
                }
                else
                {
                    this.tr_null.Visible = false;
                }
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            Electiver_StuEntity model = new Electiver_StuEntity();

            model.EleID = Convert.ToInt32(this.ddl_EleID.SelectedValue == "" ? "0" : this.ddl_EleID.SelectedValue);
            model.GroupID = ClaID;
            model.IsBack = (int)CommonEnum.IsorNot.否;
            model.EType = (int)CommonEnum.ElectiverEType.实选;
            DataTable dt = electivestuDAL.GetPaged(model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            x = dt.Rows.Count;
            this.rp_List.DataSource = dt;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";

        }
        #endregion

        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}