/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师课时导入
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.freshmen
{
    public partial class StuUserImport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public CampusDAL campusDAL = new CampusDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();

        #region 参数集合
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion

        #region 页面初始化
        /// <summary>
        /// 页面初始化0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region 下载模板文件
        /// <summary>
        /// 下载模板文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_example_Click(object sender, EventArgs e)
        {
            string expath = @"~\Template\StuUserImport.xls";
            if (!CommonFunction.UpLoadFunciotn(expath, "新生导入模板"))
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
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + path + "';" + "Extended Properties=Excel 8.0;";
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
                string name = UserID.ToString() + "_UserImportTemplate_";
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

                    int id = 0;
                    int higheducation = 0;
                    int levelcommunication = 0;

                    //switch (Flag)
                    //{
                    //    case 1:
                    //        id = (int)CommonEnum.UserType.老师; break;//教师
                    //    case 2:
                    //        id = (int)CommonEnum.UserType.学生; break;//学生
                    //    case 3:
                     // id = 3; //新生
                    //        break;
                    //}

                    DataTable dep = departmentDAL.GetList((int)CommonEnum.IsorNot.否, id == 2 ? (int)CommonEnum.DepType.普通班级 : (int)CommonEnum.DepType.职能部门);
                    
                    string[] needcol = { "校区ID", "用户名", "姓名", "身份证号", "性别", "手机号", "家庭住址", "民族", "邮箱", "家长最高学历", "交流水平", "备注" };
                    int count = 0;
                    for (int i = 0; i < needcol.Length; i++)
                    {
                        count += colname.IndexOf(needcol[i]) == -1 ? -1 : 1;
                    }
                    if (count >= needcol.Length)
                    {

                        SysUserEntity[] list = new SysUserEntity[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            SysUserEntity model = new SysUserEntity();
                            model.UID = "";

                            #region 判断错误提示友好度
                            //DataTable username = sysUserDAL.GetUserName(dt.Rows[i]["用户名"].ToString(), (int)CommonEnum.Deleted.未删除,(int)CommonEnum.UserType.学生);
                            //if (username != null && username.Rows.Count > 0)
                            //{
                            //    ShowMessage("用户名已经存在，请修改【第" + (i + 2) + "行】");
                            //    return;
                            //}
                            //else 
                            //{
                            //    //用户名
                            //    model.UserName = dt.Rows[i]["用户名"].ToString() == "" ? dt.Rows[i]["手机号"].ToString() : dt.Rows[i]["用户名"].ToString();
                            //}

                            //DataTable cellphone = sysUserDAL.GetCellPhone(dt.Rows[i]["手机号"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.UserType.学生);
                            //if (cellphone != null && cellphone.Rows.Count > 0)
                            //{
                            //    ShowMessage("手机号已经存在，请修改【第" + (i + 2) + "行】");
                            //    return;
                            //}
                            //else
                            //{

                            //} 
                           // DataTable idcard = sysUserDAL.GetIDCard(dt.Rows[i]["身份证号"].ToString(), (int)CommonEnum.Deleted.未删除, (int)CommonEnum.UserType.学生);
                            #endregion

                            //手机号
                            if (!string.IsNullOrEmpty(dt.Rows[i]["手机号"].ToString()))
                            { 
                                model.CellPhone = dt.Rows[i]["手机号"].ToString();
                            }
                            else
                            {
                                ShowMessage("手机号不能为空【第" + (i + 2) + "行】"); 
                                return;
                            }

                            //用户名
                            model.UserName = dt.Rows[i]["用户名"].ToString() == "" ? dt.Rows[i]["手机号"].ToString() : dt.Rows[i]["用户名"].ToString();

                            //身份证号
                            if (!string.IsNullOrEmpty(dt.Rows[i]["身份证号"].ToString()))
                            {
                                if (!CheckIDCard(dt.Rows[i]["身份证号"].ToString()))
                                {
                                    ShowMessage("身份证错误【第" + (i + 2) + "行】");
                                    return;
                                }
                                model.IDCard = dt.Rows[i]["身份证号"].ToString();
                            }
                            else
                            {
                                ShowMessage("身份证号不能为空【第" + (i + 2) + "行】");
                                return;
                            }


                            //校区ID
                            if (IsNum(dt.Rows[i]["校区ID"].ToString()) == false)
                            {
                                ShowMessage("请输入正确的校区ID,校区ID为整数，请修改【第" + (i + 2) + "行】");
                                return;
                            }
                            int gd = campusDAL.GetByCID(Convert.ToInt32(dt.Rows[i]["校区ID"].ToString()), (int)CommonEnum.Deleted.未删除);
                            if (gd == -1)
                            {
                                ShowMessage("系统中不存在名称为：" + dt.Rows[i]["校区ID"].ToString() + "的校区ID，请修改后重新导入【第" + (i + 2) + "行】");
                                return;
                            }
                            else
                            {
                                model.CID = gd;
                            }

                             #region 部门ID
                            //if (IsNum(dt.Rows[i]["部门ID"].ToString()) == false)
                            //{
                            //    ShowMessage("请输入正确的部门ID,部门ID为整数，请修改【第" + (i + 2) + "行】");
                            //    return;
                            //}
                            //int dd = departmentDAL.GetByDID(Convert.ToInt32(dt.Rows[i]["部门ID"].ToString()), (int)CommonEnum.Deleted.未删除);
                            //if (dd == -1)
                            //{
                            //    ShowMessage("系统中不存在名称为：" + dt.Rows[i]["部门ID"].ToString() + "的部门ID，请修改后重新导入【第" + (i + 2) + "行】");
                            //    return;
                            //}
                            //else
                            //{
                            //    model.DepID = Convert.ToString(dd);
                            //}
                            #endregion

                            //姓名
                            if (!string.IsNullOrEmpty(dt.Rows[i]["姓名"].ToString()))
                            { 
                                model.RealName = dt.Rows[i]["姓名"].ToString();
                            }
                            else
                            {
                                ShowMessage("姓名不能为空【第" + (i + 2) + "行】"); 
                                return;
                            }


                            //性别
                            if (!string.IsNullOrEmpty(dt.Rows[i]["性别"].ToString()))
                            { 
                                model.UserSex = dt.Rows[i]["性别"].ToString() == "男" ? (int)CommonEnum.XB.男 : (int)CommonEnum.XB.女; 
                            }
                            else
                            {
                                ShowMessage("性别不能为空【第" + (i + 2) + "行】"); 
                                return;
                            }

                            //家庭住址
                            if (!string.IsNullOrEmpty(dt.Rows[i]["家庭住址"].ToString()))
                            { 
                                model.Address = dt.Rows[i]["家庭住址"].ToString(); 
                            }
                            else
                            {
                                ShowMessage("家庭住址不能为空【第" + (i + 2) + "行】"); 
                                return;
                            }

                            //民族
                            if (!string.IsNullOrEmpty(dt.Rows[i]["民族"].ToString()))
                            { 
                                model.Nation = (int)Enum.Parse(typeof(CommonEnum.MZ), dt.Rows[i]["民族"].ToString()); 
                            }
                            else
                            {
                                ShowMessage("民族不能为空【第" + (i + 2) + "行】"); 
                                return;
                            }

                           
                            #region 部门ID
                            //string[] deps = dt.Rows[i]["部门ID"].ToString().Split(',');
                            //string depid = "";
                            //foreach (string s in deps)
                            //{
                            //    DataRow[] drd = dep.Select("DepName='" + s + "'");
                            //    if (drd != null && drd.Length > 0)
                            //    {
                            //        depid += drd[0]["did"].ToString() + ",";
                            //    }
                            //}
                            //model.DepID = depid.Trim(',');
                            model.DepID = "";
                            #endregion

                            //家长最高学历
                            if (XL(dt.Rows[i]["家长最高学历"].ToString()) == 0)
                            {
                                ShowMessage("第" + (i + 1) + "行获得家长最高学历录入错误，请按照模板中给出的进行选择");
                                return;
                            }
                            higheducation = Convert.ToInt32(XL(dt.Rows[i]["家长最高学历"].ToString()));

                            //交流水平
                            if (JL(dt.Rows[i]["交流水平"].ToString()) == 0)
                            {
                                ShowMessage("第" + (i + 1) + "行交流水平录入错误，请按照模板中给出的进行选择");
                                return;
                            }
                             levelcommunication = Convert.ToInt32(JL(dt.Rows[i]["交流水平"].ToString()));

                            //备注
                            model.UserDesc = dt.Rows[i]["备注"].ToString();
                            //出生年月
                            model.BirthDay = DateTime.Parse(model.IDCard.Substring(6, 4) + "-" + model.IDCard.Substring(10, 2) + "-" + model.IDCard.Substring(12, 2));
                            //model.MailNum = dt.Rows[i]["邮箱"].ToString();
                            model.MailNum = ""; //邮箱
                            model.QQNum = "";//QQ
                            model.WeiNum = "";//微信
                            model.UserPwd = CommonFunction.Encrypt("888888");//密码
                            // model.Roles="1";
                            model.CompanyNum = "";//办公座机
                            model.UState = (int)CommonEnum.UState.正常;
                            model.Isdel = (int)CommonEnum.Deleted.未删除;
                            model.CreateDate = DateTime.Now;
                            model.CreateUser = UserID;
                            model.UserType = 3;//新生=3 学生=2  教师=1
                           
                            list[i] = model;
                        }

                        if (list != null)
                        {
                            int returnvalue = sysUserDAL.StuImport(list, id, higheducation, levelcommunication);
                            if (returnvalue == 0)
                            {
                                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导入, "新生用户信息导入", UserID));
                                ShowMessage();
                            }
                            else if (returnvalue == -2)
                            {
                                ShowMessage("该用户名已经存在");
                                return;
                            }
                            else if (returnvalue == -3)
                            {
                                ShowMessage("该身份证已经存在");
                                return;
                            }
                            else if (returnvalue == -4)
                            {
                                ShowMessage("该手机号（并且登录名）已被注册");
                                return;
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
                        ShowMessage("文件中第缺少必要的信息，请检查后重新导入");
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

        #region 验证身份证
        public static bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }

            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        public static int DivRem(int a, int b, out int result)
        {
            result = a % b;
            return (a / b);
        }

        public static bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
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

        #region 判断学历是否存在
        public int XL(string xl)
        {
            int value = 0;
            if (xl == CommonEnum.XL.硕士研究生毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.硕士研究生毕业);
            }
            else if (xl == CommonEnum.XL.博士研究生毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.博士研究生毕业);
            }
            else if (xl == CommonEnum.XL.大学本科毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学本科毕业);
            }
            else if (xl == CommonEnum.XL.大学专科毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.大学专科毕业);
            }
            else if (xl == CommonEnum.XL.高中毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.高中毕业);
            }
            else if (xl == CommonEnum.XL.初中毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.初中毕业);
            }
            else if (xl == CommonEnum.XL.小学毕业.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.小学毕业);
            }
            else if (xl == CommonEnum.XL.其他.ToString())
            {
                value = Convert.ToInt32(CommonEnum.XL.其他);
            }
            else
            {
                value = 0;
            }
            return value;
        }
        #endregion

        #region 判断交流水平是否存在
        public int JL(string xl)
        {
            int value = 0;
            if (xl == CommonEnum.JL.A.ToString())
            {
                value = Convert.ToInt32(CommonEnum.JL.A);
            }
            else if (xl == CommonEnum.JL.B.ToString())
            {
                value = Convert.ToInt32(CommonEnum.JL.B);
            }
            else
            {
                value = Convert.ToInt32(CommonEnum.JL.C);
            }
            return value;
        }
        #endregion

    }
}