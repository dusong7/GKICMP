/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GKICMP.localhost1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.IO;


namespace GKICMP.purchase
{
    public partial class PurchaseImportEdit : PageBase
    {
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();

        #region 参数集合
        /// <summary>
        /// 状态
        /// </summary>
        public String PID
        {
            get
            {
                return GetQueryString<String>("id", "");
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        #region 下载模板文件
        /// <summary>
        /// 下载模板文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            string expath = @"~\Template\ProAssetListImport.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "资产清单导入模板"))
            {
                ShowMessage("模板文件不存在，请联系系统管理员");
                return;
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
            //DataTable dt = new DataTable();
            ////string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties=Excel 8.0;HDR=Yes;IMEX=1'";
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";

            //OleDbConnection conn = new OleDbConnection(strConn);
            //try
            //{
            //    conn.Open();
            //    //获取表名
            //    DataTable dtname = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //    string sheetName = dtname.Rows[0][2].ToString().Trim();
            //    //读取excel文件数据
            //    string strExcel = string.Format("select * from [{0}]", sheetName);
            //    OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
            //    myCommand.Fill(dt);
            //}
            //catch (Exception ex)
            //{
            //    dt = null;
            //}
            //conn.Close();
            //CommonFunction.delfile(path);
            //return dt;
            return CommonFunction.ExportExcel(path);
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
                string name = UserID.ToString() + "_ImportTemplate_";
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


        #region 导入
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
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
                        string[] needcol = { "资产分类", "资产名称", "品牌", "规格型号", "计量单位", "物品单价", "数量", "供应商", "计划使用年限", "购置时间", "资产分组", "物品描述" };
                        int count = 0;
                        for (int i = 0; i < needcol.Length; i++)
                        {
                            count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                        }
                        #region for语句

                        if (count >= needcol.Length)
                        {
                            GK.GKICMP.Entities.AssetEntity[] list = new GK.GKICMP.Entities.AssetEntity[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                GK.GKICMP.Entities.AssetEntity model = new GK.GKICMP.Entities.AssetEntity();
                                model.AID = "";
                                model.PID = PID;
                                
                                if (dt.Rows[i]["资产分类"].ToString() == "")
                                {
                                    ShowMessage("资产分类不能为空，请重新输入【第" + i + "行】");
                                    return;
                                }
                                //判断资产类别
                                //DataTable sdt = SysData1BLL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.资产分类);
                                //string sdt = sysDataDAL.GetSDIDByName(dt.Rows[i]["资产分类"].ToString().Trim(),(int)CommonEnum.IsorNot.否, 1);
                                string sdt = assetTypeDAL.GetSDIDByName(dt.Rows[i]["资产分类"].ToString().Trim(), (int)CommonEnum.IsorNot.否, 1);
                                if (sdt == "-1")
                                {
                                    ShowMessage("系统中不存在资产分类名称为：" + dt.Rows[i]["资产分类"].ToString() + "，请修改后重新导入！【第" + (i + 1) + "行】");
                                    return;
                                }
                                else
                                {
                                    //model.DataType = int.Parse(sdt);
                                    model.DataType = Convert.ToInt32(sdt);
                                }

                                if (dt.Rows[i]["资产名称"].ToString() == "")
                                {
                                    ShowMessage("资产名称不能为空，请重新输入【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.AssetName = dt.Rows[i]["资产名称"].ToString();//

                                if (dt.Rows[i]["品牌"].ToString() == "")
                                {
                                    ShowMessage("品牌不能为空，请重新输入【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.Brand = dt.Rows[i]["品牌"].ToString();//

                                if (dt.Rows[i]["规格型号"].ToString() == "")
                                {
                                    ShowMessage("规格型号不能为空，请重新输入【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.SpecificationModel = dt.Rows[i]["规格型号"].ToString();//

                                if (IsChange(dt.Rows[i]["物品单价"].ToString()) == false)
                                {
                                    ShowMessage("请输入正确的价格注：（保留2位有效小数）【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.APrice = Convert.ToDecimal(dt.Rows[i]["物品单价"].ToString());//


                                //计量单位
                                string ms = sysDataDAL.GetSDIDByName(dt.Rows[i]["计量单位"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.计量单位);
                                if (ms == "-1")
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["计量单位"].ToString() + "的计量单位，请修改后重新导入【第" + i + "行】");
                                    return;
                                }
                                model.AUnit = Convert.ToInt32(ms);


                                if (IsNum(dt.Rows[i]["数量"].ToString()) == false)
                                {
                                    ShowMessage("请输入正确的数量,数量为整数【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.AssetNum = Convert.ToInt32(dt.Rows[i]["数量"].ToString());//

                                //计划使用年限
                                if (IsNum(dt.Rows[i]["计划使用年限"].ToString()) == false)
                                {
                                    ShowMessage("请输入正确的计划使用年限,年限为整数【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.PlanYear = Convert.ToInt32(dt.Rows[i]["计划使用年限"].ToString());


                                if (dt.Rows[i]["供应商"].ToString() == "")
                                {
                                    ShowMessage("供应商不能为空，请重新输入【第" + (i + 1) + "行】");
                                    return;
                                }

                                string st = supplierDAL.TableByName(dt.Rows[i]["供应商"].ToString().Trim(), (int)CommonEnum.Deleted.未删除);
                                if (st == "")
                                {
                                    ShowMessage("系统中不存在供应商名称为：" + dt.Rows[i]["供应商"].ToString() + "，请修改后重新导入！【第" + (i + 1) + "行】");
                                    return;
                                }
                                else
                                {
                                    model.Suppliers = st;
                                    // model.Suppliers = dt.Rows[i]["供应商"].ToString();
                                }


                                if (IsDate(dt.Rows[i]["购置时间"].ToString().Trim()) == false)
                                {
                                    ShowMessage("请录入正确的购置时间【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.BuyDate = Convert.ToDateTime(dt.Rows[i]["购置时间"].ToString());//

                                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                                model.CreateUser = UserID;
                                model.Flag = 1;
                                model.AssetMark = dt.Rows[i]["物品描述"].ToString();





                                model.IsChecked = 0;
                                string zcfz = sysDataDAL.GetSDIDByName(dt.Rows[i]["资产分组"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.资产分组);
                                if (zcfz == "-1")
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["资产分组"].ToString() + "的信息，请修改后重新导入【第" + i + "行】");
                                    return;
                                }
                                else
                                    model.AssetGroup = int.Parse(zcfz);



                                //ProjectManageEntity pmodel = ProjectManageBLL.GetObj(PID);
                                //model.DepID = pmodel.DepID;  //学校
                                model.DataDesc = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999).ToString();
                                list[i] = model;

                            }

                            if (list != null && list.Length > 0)
                            {
                                int returnvalue = assetDAL.Import(list);
                                // int returnvalue = 0;
                                if (returnvalue == 0)
                                {
                                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入资产", UserID));
                                    ShowMessage();
                                }
                                else
                                {
                                    ShowMessage("保存失败");
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
                            ShowMessage("文件读取失败，请检查文件是否已损坏");
                            return;
                        }
                        #endregion
                    }
                    else
                    {
                        ShowMessage("文件导入失败");
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));

            }
        }

        #endregion

        #region 判断输入是否为日期类型
        /// <summary>   
        /// 判断输入是否为日期类型   
        /// </summary>   
        /// <param name="s">待检查数据</param>   
        /// <returns></returns>   
        public bool IsDate(string s)
        {
            try
            {
                DateTime d = DateTime.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region 判断是否为数字
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public bool IsNum(string Str)
        {
            bool bl = false;
            string Rx = @"^[1-9]\d*$";
            if (Regex.IsMatch(Str, Rx))
            {
                bl = true;
            }
            else
            {
                bl = false;
            }
            return bl;
        }
        #endregion


        #region 判断是否为decimal类型
        /// <summary>
        /// 判断是否为decimal类型
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public bool IsChange(string Str)
        {
            bool ret;
            int myNumber;
            decimal number;
            try
            {
                myNumber = Convert.ToInt32(Str);
                if (myNumber <= 0)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
            }
            catch
            {
                try
                {
                    number = Convert.ToDecimal(Str);
                    //if (number.ToString().Split('.')[1].Length > 2)
                    if (number.ToString().Split('.')[1].Length == 4)
                    {
                        ret = false;
                    }
                    else
                    {
                        ret = true;

                    }
                }
                catch
                {
                    ret = false;
                }

            }
            return ret;
        }
        #endregion
    }
}