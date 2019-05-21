/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月26日 10点38分
** 描   述:      工资实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class WageEntity
    {

        /// <summary>
        /// Wage表实体
        ///</summary>
        public WageEntity()
        {
        }


        /// <summary>
        /// Wage表实体
        /// </summary>
        /// <param name="sid">ID</param>
        /// <param name="wyear">年份</param>
        /// <param name="wmonth">月份</param>
        /// <param name="tid">教师ID</param>
        /// <param name="postwage">岗位工资</param>
        /// <param name="salaryscale">薪级工资/学历工资</param>
        /// <param name="allowance">教龄津贴/基本工资</param>
        /// <param name="teachnursing">教护10%</param>
        /// <param name="basicpay">基础性绩效工资/上月绩效工资</param>
        /// <param name="rewarding">奖励性绩效工资</param>
        /// <param name="shouldwage">小计/应发工资</param>
        /// <param name="accumulation">公积金</param>
        /// <param name="unemployment">失业保险</param>
        /// <param name="medicalfee">医保费</param>
        /// <param name="insurance">养老保险</param>
        /// <param name="union">工会费</param>
        /// <param name="assesswage">考核工资</param>
        /// <param name="income">个人所得税</param>
        /// <param name="serious">大病救助</param>
        /// <param name="withhold">代扣小计</param>
        /// <param name="actualwages">实发工资</param>
        /// <param name="rentalfee">提租补贴</param>
        /// <param name="wdesc">备注</param>
        /// <param name="wflag">标识 1在编 2 聘用</param>
        /// <param name="isdel">是否删除</param>
        public WageEntity(string sid, int wyear, int wmonth, string tid, decimal postwage, decimal salaryscale, decimal allowance, decimal teachnursing, decimal basicpay, decimal rewarding, decimal shouldwage, decimal accumulation, decimal unemployment, decimal medicalfee, decimal insurance, decimal union, decimal assesswage, decimal income, decimal serious, decimal withhold, decimal actualwages, decimal rentalfee, string wdesc, int wflag, int isdel)
        {
            this.SID = sid;
            this.WYear = wyear;
            this.WMonth = wmonth;
            this.TID = tid;
            this.PostWage = postwage;
            this.SalaryScale = salaryscale;
            this.Allowance = allowance;
            this.TeachNursing = teachnursing;
            this.BasicPay = basicpay;
            this.Rewarding = rewarding;
            this.ShouldWage = shouldwage;
            this.Accumulation = accumulation;
            this.Unemployment = unemployment;
            this.MedicalFee = medicalfee;
            this.Insurance = insurance;
            this.Union = union;
            this.AssessWage = assesswage;
            this.Income = income;
            this.Serious = serious;
            this.Withhold = withhold;
            this.ActualWages = actualwages;
            this.RentalFee = rentalfee;
            this.WDesc = wdesc;
            this.WFlag = wflag;
            this.Isdel = isdel;
        }

        private string sid;//ID
        private int wyear;//年份
        private int wmonth;//月份
        private string tid;//教师ID
        private decimal postwage;//岗位工资
        private decimal salaryscale;//薪级工资/学历工资
        private decimal allowance;//教龄津贴/基本工资
        private decimal teachnursing;//教护10%
        private decimal basicpay;//基础性绩效工资/上月绩效工资
        private decimal rewarding;//奖励性绩效工资
        private decimal shouldwage;//小计/应发工资
        private decimal accumulation;//公积金
        private decimal unemployment;//失业保险
        private decimal medicalfee;//医保费
        private decimal insurance;//养老保险
        private decimal union;//工会费
        private decimal assesswage;//考核工资
        private decimal income;//个人所得税
        private decimal serious;//大病救助/20%工资
        private decimal withhold;//代扣小计
        private decimal actualwages;//实发工资
        private decimal rentalfee;//提租补贴
        private string wdesc;//备注
        private int wflag;//标识 1在编 2 聘用
        private int isdel;//是否删除
        private string tIDName;
      

        public string TIDName
        {
            get { return tIDName; }
            set { tIDName = value; }
        }


        ///<summary>
        ///ID
        ///</summary>
        public string SID
        {
            get
            {
                return sid;
            }
            set
            {
                sid = value;
            }
        }

        ///<summary>
        ///年份
        ///</summary>
        public int WYear
        {
            get
            {
                return wyear;
            }
            set
            {
                wyear = value;
            }
        }

        ///<summary>
        ///月份
        ///</summary>
        public int WMonth
        {
            get
            {
                return wmonth;
            }
            set
            {
                wmonth = value;
            }
        }

        ///<summary>
        ///教师ID
        ///</summary>
        public string TID
        {
            get
            {
                return tid;
            }
            set
            {
                tid = value;
            }
        }

        ///<summary>
        ///岗位工资
        ///</summary>
        public decimal PostWage
        {
            get
            {
                return postwage;
            }
            set
            {
                postwage = value;
            }
        }

        ///<summary>
        ///薪级工资/学历工资
        ///</summary>
        public decimal SalaryScale
        {
            get
            {
                return salaryscale;
            }
            set
            {
                salaryscale = value;
            }
        }

        ///<summary>
        ///教龄津贴/基本工资
        ///</summary>
        public decimal Allowance
        {
            get
            {
                return allowance;
            }
            set
            {
                allowance = value;
            }
        }

        ///<summary>
        ///教护10%
        ///</summary>
        public decimal TeachNursing
        {
            get
            {
                return teachnursing;
            }
            set
            {
                teachnursing = value;
            }
        }

        ///<summary>
        ///基础性绩效工资/上月绩效工资
        ///</summary>
        public decimal BasicPay
        {
            get
            {
                return basicpay;
            }
            set
            {
                basicpay = value;
            }
        }

        ///<summary>
        ///奖励性绩效工资
        ///</summary>
        public decimal Rewarding
        {
            get
            {
                return rewarding;
            }
            set
            {
                rewarding = value;
            }
        }

        ///<summary>
        ///小计/应发工资
        ///</summary>
        public decimal ShouldWage
        {
            get
            {
                return shouldwage;
            }
            set
            {
                shouldwage = value;
            }
        }

        ///<summary>
        ///公积金
        ///</summary>
        public decimal Accumulation
        {
            get
            {
                return accumulation;
            }
            set
            {
                accumulation = value;
            }
        }

        ///<summary>
        ///失业保险
        ///</summary>
        public decimal Unemployment
        {
            get
            {
                return unemployment;
            }
            set
            {
                unemployment = value;
            }
        }

        ///<summary>
        ///医保费
        ///</summary>
        public decimal MedicalFee
        {
            get
            {
                return medicalfee;
            }
            set
            {
                medicalfee = value;
            }
        }

        ///<summary>
        ///养老保险
        ///</summary>
        public decimal Insurance
        {
            get
            {
                return insurance;
            }
            set
            {
                insurance = value;
            }
        }

        ///<summary>
        ///工会费
        ///</summary>
        public decimal Union
        {
            get
            {
                return union;
            }
            set
            {
                union = value;
            }
        }

        ///<summary>
        ///考核工资
        ///</summary>
        public decimal AssessWage
        {
            get
            {
                return assesswage;
            }
            set
            {
                assesswage = value;
            }
        }

        ///<summary>
        ///个人所得税
        ///</summary>
        public decimal Income
        {
            get
            {
                return income;
            }
            set
            {
                income = value;
            }
        }

        ///<summary>
        ///大病救助/20%工资
        ///</summary>
        public decimal Serious
        {
            get
            {
                return serious;
            }
            set
            {
                serious = value;
            }
        }

        ///<summary>
        ///代扣小计
        ///</summary>
        public decimal Withhold
        {
            get
            {
                return withhold;
            }
            set
            {
                withhold = value;
            }
        }

        ///<summary>
        ///实发工资
        ///</summary>
        public decimal ActualWages
        {
            get
            {
                return actualwages;
            }
            set
            {
                actualwages = value;
            }
        }

        ///<summary>
        ///提租补贴
        ///</summary>
        public decimal RentalFee
        {
            get
            {
                return rentalfee;
            }
            set
            {
                rentalfee = value;
            }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string WDesc
        {
            get
            {
                return wdesc;
            }
            set
            {
                wdesc = value;
            }
        }

        ///<summary>
        ///标识 1在编 2 聘用
        ///</summary>
        public int WFlag
        {
            get
            {
                return wflag;
            }
            set
            {
                wflag = value;
            }
        }

        ///<summary>
        ///是否删除
        ///</summary>
        public int Isdel
        {
            get
            {
                return isdel;
            }
            set
            {
                isdel = value;
            }
        }
    }
}

