/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年11月28日 09点56分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class LEDEntity
    {

        /// <summary>
        /// LED表实体
        ///</summary>
        public LEDEntity()
        {
        }


        /// <summary>
        /// LED表实体
        /// </summary>
        /// <param name="lid"></param>
        /// <param name="lname"></param>
        /// <param name="lip"></param>
        /// <param name="lwidth"></param>
        /// <param name="lheight"></param>
        /// <param name="ltype"></param>
        /// <param name="lcolor"></param>
        public LEDEntity(int lid, string lname, string lip, int lwidth, int lheight, int ltype, int lcolor)
        {
            this.LID = lid;
            this.LName = lname;
            this.LIP = lip;
            this.LWidth = lwidth;
            this.LHeight = lheight;
            this.LType = ltype;
            this.LColor = lcolor;
        }

        private int lid;//
        private string lname;//
        private string lip;//
        private int lwidth;//
        private int lheight;//
        private int ltype;//
        private int lcolor;//
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public int IsOpen { get; set; }
       /// <summary>
       /// 通讯方式
       /// </summary>
        public int LCType { get; set; }
        public int LBright { get; set; }
        public int LBrand { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int LID
        {
            get
            {
                return lid;
            }
            set
            {
                lid = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string LName
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string LIP
        {
            get
            {
                return lip;
            }
            set
            {
                lip = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int LWidth
        {
            get
            {
                return lwidth;
            }
            set
            {
                lwidth = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int LHeight
        {
            get
            {
                return lheight;
            }
            set
            {
                lheight = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int LType
        {
            get
            {
                return ltype;
            }
            set
            {
                ltype = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int LColor
        {
            get
            {
                return lcolor;
            }
            set
            {
                lcolor = value;
            }
        }
    }
}

