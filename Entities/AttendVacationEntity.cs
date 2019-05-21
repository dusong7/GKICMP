/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年09月27日 03点27分
** 描   述:      考勤假期实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class AttendVacationEntity
    {

        /// <summary>
        /// AttendVacation表实体
        ///</summary>
        public AttendVacationEntity()
        {
        }


        /// <summary>
        /// AttendVacation表实体
        /// </summary>
        /// <param name="vid">假期ID</param>
        /// <param name="vacname">名称</param>
        /// <param name="vbegin">开始时间</param>
        /// <param name="vend">结束时间</param>
        public AttendVacationEntity(int vid, string vacname, DateTime vbegin, DateTime vend)
        {
            this.Vid = vid;
            this.VacName = vacname;
            this.VBegin = vbegin;
            this.VEnd = vend;
        }

        private int vid;//假期ID
        private string vacname;//名称
        private DateTime vbegin;//开始时间
        private DateTime vend;//结束时间


        ///<summary>
        ///假期ID
        ///</summary>
        public int Vid
        {
            get
            {
                return vid;
            }
            set
            {
                vid = value;
            }
        }

        ///<summary>
        ///名称
        ///</summary>
        public string VacName
        {
            get
            {
                return vacname;
            }
            set
            {
                vacname = value;
            }
        }

        ///<summary>
        ///开始时间
        ///</summary>
        public DateTime VBegin
        {
            get
            {
                return vbegin;
            }
            set
            {
                vbegin = value;
            }
        }

        ///<summary>
        ///结束时间
        ///</summary>
        public DateTime VEnd
        {
            get
            {
                return vend;
            }
            set
            {
                vend = value;
            }
        }
    }
}

