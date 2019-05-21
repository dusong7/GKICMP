/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:     LFZ
** 创建日期:     2017年01月03日
** 描   述:      基础数据实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{
    public class SysDataEntity
    {
        /// <summary>
        /// SysData表实体
        ///</summary>
        public SysDataEntity()
        {

        }
        /// <summary>
        /// SysDate表实体
        /// </summary>
        /// <param name="sdid">数据ID</param>
        /// <param name="dataname">数据名称</param>
        /// <param name="datadesc">数据色备注</param>
        /// <param name="datatype">数据类型</param>
        /// <param name="isdel">是否删除</param>

        public SysDataEntity(string dataname, int isdel)
        {

            this.DataName = dataname;
            this.Isdel = isdel;
        }


        private int sdid;//数据ID
        private string dataname;//数据名称
        private string datadesc;//数据备注
        private int datatype;//数据类型
        private int isdel;//是否删除
        private int pid;//父级ID
        private int issysset;//是否系统预设

        public int IsSysSet
        {
            get { return issysset; }
            set { issysset = value; }
        }
        public int PID
        {
            get { return pid; }
            set { pid = value; }
        }

        ///<summary>
        ///数据ID
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
        ///数据名称
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
        ///数据备注
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
        ///数据类型
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
