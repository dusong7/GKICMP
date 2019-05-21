/*****************************************************************
** Copyright (c) 芜湖易通信息技术有限公司
** 创 建 人:      ygb
** 创建日期:      2018年04月04日 04点51分
** 描   述:      积分实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class IntegralInfoEntity
    {

        /// <summary>
        /// IntegralInfo表实体
        ///</summary>
        public IntegralInfoEntity()
        {
        }


        /// <summary>
        /// IntegralInfo表实体
        /// </summary>
        /// <param name="iid">ID</param>
        /// <param name="userid">用户ID</param>
        /// <param name="integralscore">积分分数</param>
        /// <param name="integraldate">积分日期</param>
        /// <param name="intedesc">积分原因</param>
        /// <param name="itype">类型</param>
        public IntegralInfoEntity(int iid, string userid, int integralscore, DateTime integraldate, string intedesc, int itype)
        {
            this.IID = iid;
            this.UserID = userid;
            this.IntegralScore = integralscore;
            this.IntegralDate = integraldate;
            this.InteDesc = intedesc;
            this.IType = itype;
        }

        private int iid;//ID
        private string userid;//用户ID
        private int integralscore;//积分分数
        private DateTime integraldate;//积分日期
        private string intedesc;//积分原因
        private int itype;//类型


        ///<summary>
        ///ID
        ///</summary>
        public int IID
        {
            get
            {
                return iid;
            }
            set
            {
                iid = value;
            }
        }

        ///<summary>
        ///用户ID
        ///</summary>
        public string UserID
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }

        ///<summary>
        ///积分分数
        ///</summary>
        public int IntegralScore
        {
            get
            {
                return integralscore;
            }
            set
            {
                integralscore = value;
            }
        }

        ///<summary>
        ///积分日期
        ///</summary>
        public DateTime IntegralDate
        {
            get
            {
                return integraldate;
            }
            set
            {
                integraldate = value;
            }
        }

        ///<summary>
        ///积分原因
        ///</summary>
        public string InteDesc
        {
            get
            {
                return intedesc;
            }
            set
            {
                intedesc = value;
            }
        }

        ///<summary>
        ///类型
        ///</summary>
        public int IType
        {
            get
            {
                return itype;
            }
            set
            {
                itype = value;
            }
        }
    }
}

