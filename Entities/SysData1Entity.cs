/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月22日 02点38分
** 描   述:      基础数据1实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class SysData1Entity
    {

        /// <summary>
        /// SysData1表实体
        ///</summary>
        public SysData1Entity()
        {
        }


        /// <summary>
        /// SysData1表实体
        /// </summary>
        /// <param name="sdid"></param>
        /// <param name="dataname"></param>
        /// <param name="datadesc"></param>
        /// <param name="datatype"></param>
        /// <param name="isdel"></param>
        /// <param name="issysset"></param>
        /// <param name="pid"></param>
        public SysData1Entity(int sdid, string dataname, string datadesc, int datatype, int isdel, int issysset, int pid)
        {
            this.SDID = sdid;
            this.DataName = dataname;
            this.DataDesc = datadesc;
            this.DataType = datatype;
            this.Isdel = isdel;
            this.IsSysSet = issysset;
            this.PID = pid;
        }

        private int sdid;//
        private string dataname;//
        private string datadesc;//
        private int datatype;//
        private int isdel;//
        private int issysset;//
        private int pid;//


        ///<summary>
        ///
        ///</summary>
        public int SDID
        {
            get
            {
                return sdid;
            }
            set
            {
                sdid = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string DataName
        {
            get
            {
                return dataname;
            }
            set
            {
                dataname = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string DataDesc
        {
            get
            {
                return datadesc;
            }
            set
            {
                datadesc = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int DataType
        {
            get
            {
                return datatype;
            }
            set
            {
                datatype = value;
            }
        }

        ///<summary>
        ///
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

        ///<summary>
        ///
        ///</summary>
        public int IsSysSet
        {
            get
            {
                return issysset;
            }
            set
            {
                issysset = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int PID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }
    }
}

