/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年01月03日
** 描 述:       基础数据页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.DBAccessConvertorProvider;
using gk.rjb_Y.Libraries;
using GK.GKICMP.Entities;
using System;
using System.Data;

namespace GK.GKICMP.DAL
{
    public partial class  BaseDataDAL: DataEntity<BaseDataEntity>
    {
        #region 绑定树
        /// <summary>
        /// 绑定树
        ///</summary>
        public DataTable GetList(int datatype, int pid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BaseData_GetList";
           // DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DataType", datatype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("PID", pid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 通过SDID来获取名称
        /// <summary>
        /// 通过SDID来获取名称
        ///</summary>
        public BaseDataEntity GetList(int type)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BaseData_GetTable";
            DbParameters.Add(new DatabaseParameter("SDID", type, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
        public int GetSDID(string dataname,int datatype) 
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_BaseData_GetSDID";
            // DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DataName", dataname, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("DataType", datatype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
           if( DataReflectionContainer!=null&&DataReflectionContainer.Rows.Count>0)
           {
               return int.Parse( DataReflectionContainer.Rows[0]["SDID"].ToString());
           }
           else 
           {
               return 0;
           }
        }
    }

}
