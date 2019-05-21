/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月10日 10时38分24秒
** 描    述:      办公用品信息导入
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AssetImportOffice : PageBase
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
            string expath = @"~\Template\AssetOfficeImport.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "办公用品导入模板"))
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
                string name = UserID.ToString() + "_AssetOfficeImportTemplate_";
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
                        string[] needcol = { "名称", "数量", "单价", "分类", "购置日期", "校区编号", "品牌", "规格型号", "计量单位", "供应商", "计划使用年限", "物品描述" };
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
                                model.PID = "";
                                model.DataDesc = "";
                                if (dt.Rows[i]["名称"].ToString() == "")
                                {
                                    ShowMessage("名称不能为空，请重新输入【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.AssetName = dt.Rows[i]["名称"].ToString();//
                                if (IsNum(dt.Rows[i]["数量"].ToString()) == false)
                                {
                                    ShowMessage("请输入正确的数量,数量为整数【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.AssetNum = Convert.ToInt32(dt.Rows[i]["数量"].ToString());//
                                if (IsChange(dt.Rows[i]["单价"].ToString()) == false)
                                {
                                    ShowMessage("请输入正确的单价（注：保留2位有效小数）【第" + (i + 1) + "行】");
                                    return;
                                }
                                model.APrice = Convert.ToDecimal(dt.Rows[i]["单价"].ToString());//
                                int sdid = sysDataDAL.GetSDID(dt.Rows[i]["分类"].ToString(), (int)CommonEnum.DataType.耗材分类);
                                if (sdid != -1)
                                {
                                    model.DataType = sdid;
                                }
                                else
                                {
                                    ShowMessage("【第" + (i + 1) + "行】不存在分类名称：【" + dt.Rows[i]["分类"].ToString() + "】，请修改后重新导入");
                                    return;
                                }

                                if (IsDate(dt.Rows[i]["购置日期"].ToString().Trim()) == false)
                                {
                                    ShowMessage("【第" + (i + 1) + "行】请输入正确的购置日期");
                                    return;
                                }
                                model.BuyDate = Convert.ToDateTime(dt.Rows[i]["购置日期"].ToString());//
                                model.Brand = dt.Rows[i]["品牌"].ToString();//
                                model.SpecificationModel = dt.Rows[i]["规格型号"].ToString();//

                                //计量单位
                                string ms = sysDataDAL.GetSDIDByName(dt.Rows[i]["计量单位"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.计量单位);
                                if (ms == "-1")
                                {
                                    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["计量单位"].ToString() + "的计量单位，请修改后重新导入【第" + i + "行】");
                                    return;
                                }
                                model.AUnit = Convert.ToInt32(ms);

                                //计划使用年限
                                if (IsNum(dt.Rows[i]["计划使用年限"].ToString() == "" ? "0" : dt.Rows[i]["计划使用年限"].ToString()) == false)
                                {
                                    ShowMessage("【第" + (i + 1) + "行】请输入正确的计划使用年限(计划使用年限为整数)");
                                    return;
                                }
                                model.PlanYear = Convert.ToInt32(dt.Rows[i]["计划使用年限"].ToString() == "" ? "0" : dt.Rows[i]["计划使用年限"].ToString());
                                if (dt.Rows[i]["供应商"].ToString().Trim() != "")
                                {
                                    string st = supplierDAL.TableByName(dt.Rows[i]["供应商"].ToString().Trim(), (int)CommonEnum.Deleted.未删除);
                                    if (st == "")
                                    {
                                        ShowMessage("系统中不存在【第" + (i + 1) + "行】供应商名称【：" + dt.Rows[i]["供应商"].ToString() + "】，请修改后重新导入！");
                                        return;
                                    }
                                    else
                                    {
                                        model.Suppliers = st;
                                    }
                                }
                                else
                                {
                                    model.Suppliers = "";
                                }

                                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                                model.CreateUser = UserID;
                                model.Flag = 2;
                                model.AssetMark = dt.Rows[i]["物品描述"].ToString();
                                try
                                {
                                    model.CID = Convert.ToInt32(dt.Rows[i]["校区编号"].ToString());
                                }
                                catch
                                {
                                    ShowMessage("【第" + (i + 1) + "行】校区编号【" + dt.Rows[i]["校区编号"] + "】填写有误，请根据系统中已有数据填写！");
                                    return;
                                }
                                model.CRID = -2;
                                list[i] = model;
                            }

                            if (list != null && list.Length > 0)
                            {
                                int returnvalue = assetDAL.Import(list);
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