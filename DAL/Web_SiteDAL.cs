/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年05月31日 03点19分
** 描   述:      网站站点实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;

namespace GK.GKICMP.DAL
{
    public partial class Web_SiteDAL : DataEntity<Web_SiteEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(Web_SiteEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Web_Site_Add";
            DataAccessChannelProtection = true;

            DbParameters.Add(new DatabaseParameter("SID", model.SID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("CompanyName", model.CompanyName, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("WebTtitle", model.WebTtitle, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("AttachTtile", model.AttachTtile, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("LogoUrl", model.LogoUrl, DatabaseType.SQL_NVarChar, 100));

            DbParameters.Add(new DatabaseParameter("IcoUrl", model.IcoUrl, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("DWebsite", model.DWebsite, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("SitePath", model.SitePath, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("LinkUser", model.LinkUser, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("TellPhone", model.TellPhone, DatabaseType.SQL_NVarChar, 30));

            DbParameters.Add(new DatabaseParameter("CellPhone", model.CellPhone, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("Fax", model.Fax, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("EmailCode", model.EmailCode, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("PostCode", model.PostCode, DatabaseType.SQL_NVarChar, 30));
            DbParameters.Add(new DatabaseParameter("RecordCode", model.RecordCode, DatabaseType.SQL_NVarChar, 50));

            DbParameters.Add(new DatabaseParameter("Address", model.Address, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("TotelCode", model.TotelCode, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("Copyright", model.Copyright, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("SiteKey", model.SiteKey, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("SiteDesc", model.SiteDesc, DatabaseType.SQL_NVarChar, 200));

            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));

            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            return stmessage.AffectRows;
        }
        #endregion


        #region 根据编号（主键）获取项:返回实体对象
        /// <summary>
        /// 根据编号（主键）获取项:返回实体对象
        /// </summary>
        /// <returns></returns>
        public Web_SiteEntity GetObjByID(int id)
        {
            string sql = "select * from Tb_Web_Site where SID=" + id;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
    }
}
