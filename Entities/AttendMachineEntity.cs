/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2016年12月28日 03点51分
** 描   述:      教室实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AttendMachineEntity
    {

        /// <summary>
        /// ClassRoom表实体
        ///</summary>
        public AttendMachineEntity()
        {
        }

        private int machinecode;//
        private string machiname;//名称
        private string ipurl;//ip
        private string userid;//用户名
        private string pwd;//密码
        private string potcode;//端口
        private int outtype;//类型    
        private string machdesc;
        private int attendtype;

        public int AttendType
        {
            get { return attendtype; }
            set { attendtype = value; }
        }

        public int MachineCode
        {
            get { return machinecode; }
            set { machinecode = value; }
        }

        public string MachiName
        {
            get { return machiname; }
            set { machiname = value; }
        }


        public string IPUrl
        {
            get { return ipurl; }
            set { ipurl = value; }
        }

        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        public string PotCode
        {
            get { return potcode; }
            set { potcode = value; }
        }

        public int OutType
        {
            get { return outtype; }
            set { outtype = value; }
        }

        public string MachDesc
        {
            get { return machdesc; }
            set { machdesc = value; }
        }


    }
}

