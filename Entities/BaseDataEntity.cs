/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年03月02日 04点01分
** 描   述:      预设基础数据类别实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class BaseDataEntity
    {

        /// <summary>
        /// BaseData表实体
        ///</summary>
        public BaseDataEntity()
        {
        }


        /// <summary>
        /// BaseData表实体
        /// </summary>
        /// <param name="sdid">ID</param>
        /// <param name="dataname">数据类型名称</param>
        /// <param name="datatype">类型</param>
        /// <param name="dcode">编码</param>
        /// <param name="pid">父级</param>
        public BaseDataEntity(int sdid, string dataname, int datatype, string dcode, int pid)
        {
            this.SDID = sdid;
            this.DataName = dataname;
            this.DataType = datatype;
            this.DCode = dcode;
            this.PID = pid;
        }

        private int sdid;//ID
        private string dataname;//数据类型名称
        private int datatype;//类型
        private string dcode;//编码
        private int pid;//父级


        ///<summary>
        ///ID
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
        ///数据类型名称
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
        ///类型
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
        ///编码
        ///</summary>
        public string DCode
        {
            get
            {
                return dcode;
            }
            set
            {
                dcode = value;
            }
        }

        ///<summary>
        ///父级
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

