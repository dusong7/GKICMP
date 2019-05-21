/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月12日 10点49分
** 描   述:      打卡实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;


namespace GK.GKICMP.DAL
{
    public partial class AttendMachineDAL : DataEntity<AttendMachineEntity>
    {

        #region 根据ip port获取项:返回实体对象
        /// <summary>
        /// 根据ip port获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public AttendMachineEntity GetObjByIP(string ip, int port)
        {
            string sql = "select * from [Tb_AttendMachine] where IPUrl='" + ip + "' and PotCode='" + port + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
        public DataTable GetList(int attendtype)
        {
            string sql = "select * from Tb_AttendMachine where attendtype=" + attendtype;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

    }


}
