/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       部门页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using gk.rjb_Y.DataEntityProvider;
using gk.rjb_Y.Libraries;
using gk.rjb_Y.DBAccessConvertorProvider;
using GK.GKICMP.Entities;

namespace GK.GKICMP.DAL
{
    public partial class DepartmentDAL : DataEntity<DepartmentEntity>
    {
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        ///</summary>
        public int Edit(DepartmentEntity model,ref int depid)
        {
            int resultvalue = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_Add";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("depid", depid, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("DID", model.DID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepName", model.DepName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("DepMark", model.DepMark, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("Master", model.Master, DatabaseType.SQL_NVarChar, 500));
            DbParameters.Add(new DatabaseParameter("IsDisplayInWeb", model.IsDisplayInWeb, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepOrder", model.DepOrder, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("GID", model.GID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepType", model.DepType, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("OtherName", model.OtherName, DatabaseType.SQL_NVarChar, 40));
            DbParameters.Add(new DatabaseParameter("CID", model.CID, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("resultvalue", resultvalue, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            //return stmessage.AffectRows;
            depid = Convert.ToInt32(DbParameters[0].Value);
            resultvalue = Convert.ToInt32(DbParameters[12].Value);
            return resultvalue;
        }
        #endregion


        #region 根据实体条件分页获取数据集，返回DataSet
        /// <summary>
        /// 根据实体条件分页获取数据集，返回DataSet
        /// </summary>
        /// <param name="pagesize">每页显示条数</param>
        /// <param name="pageindex">当前页码,从1开始</param>
        /// <param name="recordCount">为-1时统计满足条件的记录总数</param>
        /// <param name="model">条件实体</param>
        public DataTable GetPaged(int pagesize, int pageindex, ref int recordCount, DepartmentEntity model)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_Paged";
            DbParameters.Add(new DatabaseParameter("pagesize", pagesize, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("pageindex", pageindex, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("recordCount", recordCount, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            DbParameters.Add(new DatabaseParameter("DepName", model.DepName, DatabaseType.SQL_NVarChar, 50));
            DbParameters.Add(new DatabaseParameter("Isdel", model.Isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepType", model.DepType, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            recordCount = Convert.ToInt32(DbParameters[2].Value);
            return DataReflectionContainer;
        }
        #endregion


        #region 删除栏目
        /// <summary>
        /// 删除栏目
        ///</summary>
        public int DeleteBat(int did, int deptype)
        {
            int result = 0;

            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_DelBat";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepType", deptype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[2].Value);
            return result;
        }
        #endregion
        #region 删除栏目
        /// <summary>
        /// 删除栏目
        ///</summary>
        public int DeleteBat(string did, int deptype)
        {
            int result = 0;

            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_Del";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("DepType", deptype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;

            result = Convert.ToInt32(DbParameters[2].Value);
            return result;
        }
        #endregion

        #region 获取所有部门信息
        /// <summary>
        ///    获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDeparInfo()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetDepart";
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 绑定子节点-获取年级
        /// <summary>
        /// 绑定子节点-获取年级
        ///</summary>
        //public DataTable GetTable(int cid, int Id)
        public DataTable GetTable(int Id)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetTable";
            //DbParameters.Add(new DatabaseParameter("GID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", Id, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion
        public DataTable GetDepList(int isdel)
        {
            string sql = "select * from tb_department where isdel=" + isdel;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        public DataTable GetClassByBZR(string userid, int type, int isdel)
        {
            string sql = "select * from tb_department where isdel=" + isdel + " and deptype=" + type + "and master='" + userid + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }

        #region 获取一年级的班级数
        /// <summary>
        /// 获取一年级的班级数
        ///</summary>
        public DataTable GetClassCount()
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_ClassCount";
            //DbParameters.Add(new DatabaseParameter("GID", cid, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            //DbParameters.Add(new DatabaseParameter("DepType", deptype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 根据校区获取一年级的班级数
        /// <summary>
        /// 根据校区获取一年级的班级数
        ///</summary>
        public DataTable GetCountByCID(int cid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_ClassCountByCID";
            DbParameters.Add(new DatabaseParameter("CID", cid, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 绑定子节点-获取部门
        /// <summary>
        /// 绑定子节点-获取部门
        ///</summary>
        public DataTable GetList(int isdel, int deptype)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetList";
            //DbParameters.Add(new DatabaseParameter("GID", cid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepType", deptype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        public DataTable GetClass(int isdel, int deptype, int gid)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetClass";
            DbParameters.Add(new DatabaseParameter("GID", gid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("DepType", deptype, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 获取班级
        /// <summary>
        /// 获取部门-班级
        /// </summary>
        /// <returns></returns>
        public DataTable GetByGID(int gid, int isdel)
        {
            string sql = "select a.* from dbo.Tb_Department a inner join dbo.Tb_Grade b on a.GID = b.GID where a.Isdel=" + isdel + " and a.GID = " + gid + " and a.DepType = -1 order by a.DepOrder asc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion



        #region 获取班级
        public DataTable GetClassByGID(int gid, string uid)
        {
            string sql = "select *,dbo.getGradeLevelName(ShortName) ShortGName from Tb_Grade a,Tb_Department b ,Tb_TeacherPlane c where a.GID=b.GID and a.GID='"+gid+"' and b.DID=c.ClaID and TeacherID='" + uid + "' and DepType=-1 and IsGraduate=0 and a.Isdel=0 and b.Isdel=0 ";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取班级
        /// <summary>
        /// 获取部门-班级
        /// </summary>
        /// <returns></returns>
        public DataTable GetByShortName(int gid, int isdel)
        {
            string sql = "select a.* from dbo.Tb_Department a inner join dbo.Tb_Grade b on a.GID = b.GID where a.Isdel=" + isdel + " and b.ShortName = " + gid + " and a.DepType = -1 and IsGraduate=0 order by a.DepOrder asc";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion

        #region 获取部门-年级详细信息
        /// <summary>
        /// 获取部门-年级信息
        /// </summary>
        /// <returns></returns>
        public DepartmentEntity GetObj(int did)
        {
            string sql = "select *,dbo.getUserName([Master]) as MasterName from Tb_Department where DID=" + did;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion

        #region 根据学生UserID查询班级课表
        /// <summary>
        /// 根据学生UserID查询班级课表
        /// </summary>
        /// <returns></returns>
        public DepartmentEntity GetMyObj(string userid)
        {
            //string sql = "select *,dbo.getUserName([Master]) as MasterName from Tb_Department where DID=" + did;
            string sql = "select * from Tb_Department where DepType=-1 and Isdel=0 and DID  in (SELECT DepID FROM Tb_SysUser where UID='" + userid + "')";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        //#region 学生信息页面通过DID来获取专业名称
        ///// <summary>
        ///// 通过PID来获取专业名称
        /////</summary>
        //public DepartmentEntity GetByDID(int did, int deptype)
        //{
        //    DbParameters.Clear();
        //    ProcedureName = "up_Tb_Department_GetByDID";
        //    DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_Int, 4));
        //    DbParameters.Add(new DatabaseParameter("DepType", deptype, DatabaseType.SQL_Int, 4));
        //    if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
        //    {
        //        throw new Exception(DataReturn.SqlMessage);
        //    }
        //    return First();
        //}
        //#endregion


        #region 获取所有职能部门信息
        /// <summary>
        ///    获取所有职能部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetZNBM(int deptype, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetZNBM";
            DbParameters.Add(new DatabaseParameter("deptype", deptype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 获取班级信息
        /// <summary>
        /// 获取班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllClass(string sql)
        {
            DbParameters.Clear();
            ProcedureName = "select * from dbo.Tb_Department  " + sql;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, ProcedureName).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }

            return DataReflectionContainer;
        }
        #endregion


        #region 获取年级根据教师id
        /// <summary>
        /// 获取年级根据教师id
        ///</summary>        
        public DataTable GetClaIDByTID(string TID)
        {
            string sql = "select distinct ClaID,dbo.getDepName(ClaID) ClaIDName from Tb_TeacherPlane where TeacherID='" + TID + "'";
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }


        public DataTable GetClass(string TID, int cid)
        {
            string sql = "select distinct ClaID,dbo.getDepName(ClaID) ClaIDName from Tb_TeacherPlane where TeacherID='" + TID + "' and CourseID=" + cid;
            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 个人空间获取班级信息
        /// <summary>
        /// 个人空间获取班级信息
        /// </summary>
        /// <param name="claid"></param>
        /// <param name="isdel"></param>
        /// <returns></returns>
        public DataTable GetInfo(int claid, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetInfo";
            DbParameters.Add(new DatabaseParameter("ClaID", claid, DatabaseType.SQL_NVarChar, 100));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 用户导入获取部门ID
        /// <summary>
        /// 用户导入获取部门ID
        /// </summary>
        /// <param name="dataname"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        public int GetByDID(int did, int isdel)
        {
            int id = -1;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Tb_Department_GetDepID";
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataView dv = DataReflectionContainer.DefaultView;
            if (dv != null)
            {
                id = Convert.ToInt32(dv.Table.Rows[0]["DID"].ToString());
            }
            return id;
        }
        #endregion


        #region 获取所有普通班级信息
        /// <summary>
        ///    获取所有普通班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPTBJ(int gid, int deptype, int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetPTBJ";
            DbParameters.Add(new DatabaseParameter("GID", gid, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("deptype", deptype, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据部门ID获取部门信息
        public DepartmentEntity GetObjbyID(int did)
        {
            string sql = "select * from Tb_Department where DID=" + did;

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 删除自定义分组及成员
        /// <summary>
        /// 删除自定义分组及成员
        ///</summary>
        public int DelCustom(string did, int isdel)
        {
            int result = 0;
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_DelCustom";
            DataAccessChannelProtection = true;
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_NVarChar, 2000));
            DbParameters.Add(new DatabaseParameter("isdel", isdel, DatabaseType.SQL_Int, 4));
            DbParameters.Add(new DatabaseParameter("result", result, DatabaseType.SQL_Int, 4, ParameterDirection.Output));
            STMessage stmessage = ExecuteStoredProcedure(DataOperationValue.IDU_OPERATION).DataReturn;
            if (stmessage.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            DataAccessChannel.CommitRelease();
            DataAccessChannelProtection = false;
            result = Convert.ToInt32(DbParameters[2].Value);
            return result;
        }
        #endregion


        #region 获取自定义分组信息
        /// <summary>
        /// 获取自定义分组信息
        /// </summary>
        /// <returns></returns>
        public DepartmentEntity GetObjByDID(int did)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Group_User_GetByDID";
            DbParameters.Add(new DatabaseParameter("DID", did, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion


        #region 获取部门包含自定义分组
        /// <summary>
        /// 获取部门包含自定义分组
        ///</summary>
        public DataTable GetGroupList(int isdel)
        {
            DbParameters.Clear();
            ProcedureName = "up_Tb_Department_GetGroupList";
            DbParameters.Add(new DatabaseParameter("Isdel", isdel, DatabaseType.SQL_Int, 4));
            if (ExecuteStoredProcedure(DataOperationValue.SEL_OPERATION).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return DataReflectionContainer;
        }
        #endregion


        #region 根据uid获取班级信息
        public DepartmentEntity GetObjbyuid(string  uid)
        {
            string sql = "select * from Tb_Department where Master='"+uid+"' and DepType=-1 and Isdel=0";

            if (ExecuteStoredCommandtext(DataOperationValue.SEL_OPERATION, sql).DataReturn.SqlCode != 0)
            {
                throw new Exception(DataReturn.SqlMessage);
            }
            return First();
        }
        #endregion
    }
}