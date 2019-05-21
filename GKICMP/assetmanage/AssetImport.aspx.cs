/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月18日 14时14分24秒
** 描    述:      资产导入
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Text.RegularExpressions;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AssetImport : PageBase
    {
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();
        public ClassRoomDAL classRoomDAL = new ClassRoomDAL();

        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region 模板下载
        /// <summary>
        /// 模板下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            string expath = @"~\Template\AssetImport.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "资产导入模板"))
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
                string name = UserID.ToString() + "_AssetImportTemplate_";
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


        #region 判断输入是否为日期类型
        /// <summary>   
        /// 判断输入是否为日期类型   
        /// </summary>   
        /// <param name="s">待检查数据</param>   
        /// <returns></returns>   
        public bool IsDate(string s)
        {
            if (s == "")
            {
                return true;
            }
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
            if (Str == "")
            {
                return false;
            }
            bool bl = false;
            string Rx = @"^[0-9]\d*$";
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
            if (Str == "")
            {
                return true;
            }
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


        #region 导入事件
        /// <summary>
        /// 导入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBig = null;
                DataTable dtSmall = null;
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
                        string[] needcol = { "资产编号", "资产名称", "数量", "价值", "资产大类", "资产分类", "取得日期", "品牌", "规格型号", "计量单位", "供应商", "计划使用年限", "资产分组", "备注", "校区编号", "存放位置" };
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
                                if (dt.Rows[i]["资产名称"].ToString().Trim() == "" || dt.Rows[i]["数量"].ToString().Trim() == "" || dt.Rows[i]["价值"].ToString().Trim() == "" || dt.Rows[i]["资产大类"].ToString().Trim() == "" || dt.Rows[i]["资产分类"].ToString().Trim() == "" || dt.Rows[i]["取得日期"].ToString().Trim() == "" || dt.Rows[i]["品牌"].ToString().Trim() == "" || dt.Rows[i]["规格型号"].ToString().Trim() == "" || dt.Rows[i]["计量单位"].ToString().Trim() == "" || dt.Rows[i]["供应商"].ToString().Trim() == "" || dt.Rows[i]["计划使用年限"].ToString().Trim() == "" || dt.Rows[i]["资产分组"].ToString().Trim() == "" || dt.Rows[i]["校区编号"].ToString().Trim() == "")
                                {
                                    ShowMessage("【第" + (i + 2) + "行】资产信息中有必填项为空，请检查输入后重新提交");
                                    return;
                                }
                                model.AID = "";
                                model.PID = "";
                                model.DataDesc = dt.Rows[i]["资产编号"].ToString() == "" ? (DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999)) : dt.Rows[i]["资产编号"].ToString();
                                model.AssetName = dt.Rows[i]["资产名称"].ToString();//
                                if (IsNum(dt.Rows[i]["数量"].ToString()) == false)
                                {
                                    ShowMessage("【第" + (i + 2) + "行】请输入正确的数量信息（数量为整数）");
                                    return;
                                }
                                model.AssetNum = Convert.ToInt32(dt.Rows[i]["数量"].ToString());//

                                if (IsChange(dt.Rows[i]["价值"].ToString()) == false)
                                {
                                    ShowMessage("【第" + (i + 2) + "行】请输入正确的价值信息（保留2位有效小数）");
                                    return;
                                }
                                model.APrice = Convert.ToDecimal(dt.Rows[i]["价值"].ToString());//
                                //dtBig = assetTypeDAL.GetAssetType(dt.Rows[i]["资产大类"].ToString(), -1, (int)CommonEnum.Deleted.未删除);
                                //if (dtBig != null && dtBig.Rows.Count > 0)
                                //{
                                //    dtSmall = assetTypeDAL.GetAssetType(dt.Rows[i]["资产分类"].ToString(), Convert.ToInt32(dtBig.Rows[0]["SDID"].ToString()), (int)CommonEnum.Deleted.未删除);
                                //    if (dtSmall != null && dtSmall.Rows.Count > 0)
                                //    {
                                //        model.DataType = Convert.ToInt32(dtSmall.Rows[0]["SDID"].ToString());
                                //    }
                                //    else
                                //    {
                                //        ShowMessage("【第" + (i + 1) + "行】资产一级分类【" + dt.Rows[i]["资产大类"].ToString() + "】下不存在资产分类名称：【" + dt.Rows[i]["资产分类"].ToString() + "】，请修改后重新导入");
                                //        return;
                                //    }
                                //}
                                //else
                                //{
                                //    ShowMessage("系统中不存在【第" + (i + 1) + "行】资产一级分类名称：【" + dt.Rows[i]["资产大类"].ToString() + "】，请修改后重新导入");
                                //    return;
                                //}
                                if (dt.Rows[i]["资产大类"].ToString() != "")
                                {
                                    dtBig = assetTypeDAL.GetAssetType(dt.Rows[i]["资产分类"].ToString(), (int)CommonEnum.Deleted.未删除);
                                    if (dtBig != null && dtBig.Rows.Count > 0)
                                    {
                                        model.DataType = Convert.ToInt32(dtBig.Rows[0]["SDID"].ToString());
                                    }
                                    else
                                    {
                                        ShowMessage("【第" + (i + 2) + "行】不存在资产分类名称：【" + dt.Rows[i]["资产分类"].ToString() + "】，请修改后重新导入");
                                        return;
                                    }
                                }
                                else
                                {
                                    ShowMessage("资产分类不能为空");
                                    return;
                                }
                                if (IsDate(dt.Rows[i]["取得日期"].ToString().Trim()) == false)
                                {
                                    ShowMessage("【第" + (i + 2) + "行】请输入正确的取得日期");
                                    return;
                                }
                                model.BuyDate = Convert.ToDateTime(dt.Rows[i]["取得日期"].ToString());//
                                model.Brand = dt.Rows[i]["品牌"].ToString();//
                                model.SpecificationModel = dt.Rows[i]["规格型号"].ToString();//

                                //计量单位
                                string ms = sysDataDAL.GetSDIDByName(dt.Rows[i]["计量单位"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.计量单位);
                                if (ms == "-1")
                                {
                                    ShowMessage("【第" + (i + 2) + "行】系统中不存在名称为：【" + dt.Rows[i]["计量单位"].ToString() + "】的计量单位信息，请修改后重新导入");
                                    return;
                                }
                                model.AUnit = Convert.ToInt32(ms);

                                string st = supplierDAL.TableByName(dt.Rows[i]["供应商"].ToString().Trim(), (int)CommonEnum.Deleted.未删除);
                                if (st == "")
                                {
                                    ShowMessage("【第" + (i + 2) + "行】系统中不存在【" + dt.Rows[i]["供应商"].ToString() + "】的供应商信息，请修改后重新导入！");
                                    return;
                                }
                                model.Suppliers = st;

                                //计划使用年限
                                if (IsNum(dt.Rows[i]["计划使用年限"].ToString().Trim()) == false)
                                {
                                    ShowMessage("【第" + (i + 2) + "行】请输入正确的计划使用年限(计划使用年限为整数)");
                                    return;
                                }
                                model.PlanYear = Convert.ToInt32(dt.Rows[i]["计划使用年限"].ToString().Trim());

                                string zcfz = sysDataDAL.GetSDIDByName(dt.Rows[i]["资产分组"].ToString().Trim(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.资产分组);
                                if (zcfz == "-1")
                                {
                                    ShowMessage("【第" + (i + 2) + "行】系统中不存在【" + dt.Rows[i]["资产分组"].ToString() + "】的资产分组信息，请修改后重新导入");
                                    return;
                                }
                                model.AssetGroup = int.Parse(zcfz);
                                model.AssetMark = dt.Rows[i]["备注"].ToString();

                                try
                                {
                                    CampusEntity campus = new CampusDAL().GetObjByID(Convert.ToInt32(dt.Rows[i]["校区编号"].ToString().Trim()));
                                    if (campus != null)
                                    {
                                        model.CID = Convert.ToInt32(dt.Rows[i]["校区编号"].ToString());
                                    }
                                    else
                                    {
                                        ShowMessage("【第" + (i + 2) + "行】系统中不存在【" + dt.Rows[i]["校区编号"] + "】的校区编号信息，请根据系统中已有数据填写！");
                                        return;
                                    }
                                }
                                catch
                                {
                                    ShowMessage("【第" + (i + 2) + "行】校区编号【" + dt.Rows[i]["校区编号"] + "】填写有误，请根据系统中已有数据填写！");
                                    return;
                                }

                                if (dt.Rows[i]["存放位置"].ToString() == "")
                                {
                                    model.CRID = -2;
                                }
                                else
                                {
                                    DataTable crid = classRoomDAL.GetList(dt.Rows[i]["存放位置"].ToString().Trim().Replace(" ", ""), (int)CommonEnum.IsorNot.否);
                                    if (crid != null && crid.Rows.Count > 0 && crid.Rows.Count < 2)
                                    {
                                        model.CRID = int.Parse(crid.Rows[0]["CRID"].ToString());
                                    }
                                    else
                                    {
                                        ShowMessage("【第" + (i + 2) + "行】系统中不存在【" + dt.Rows[i]["存放位置"].ToString() + "】的存放位置信息，请根据系统中已有数据填写！");
                                        return;
                                    }
                                }

                                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                                model.CreateUser = UserID;
                                model.Flag = 1;
                                model.IsChecked = 1;
                                model.IsReport = 0;

                                //ProjectManageEntity pmodel = ProjectManageBLL.GetObj(PID);
                                //model.DepID = pmodel.DepID;  //学校
                                //model.DataDesc = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1000, 9999).ToString();
                                list[i] = model;
                            }

                            if (list != null && list.Length > 0)
                            {
                                int returnvalue = assetDAL.Import(list);
                                // int returnvalue = 0;
                                if (returnvalue == 0)
                                {
                                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "导入资产信息", UserID));
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
    }
}