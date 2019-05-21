/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年11月11日 04点09分
** 描   述:      楼层实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class FloorEntity
    {

        /// <summary>
        /// Floor表实体
        ///</summary>
        public FloorEntity()
        {
        }


        /// <summary>
        /// Floor表实体
        /// </summary>
        /// <param name="fid">楼层ID</param>
        /// <param name="bid">宿舍楼ID</param>
        /// <param name="floorname">楼层名称</param>
        /// <param name="fnumber">楼层代码</param>
        /// <param name="forder">排序</param>
        /// <param name="isdel">是否删除</param>
        public FloorEntity(string fid, int bid, string floorname, string fnumber, int forder, int isdel)
        {
            this.FID = fid;
            this.BID = bid;
            this.FloorName = floorname;
            this.FNumber = fnumber;
            this.FOrder = forder;
            this.Isdel = isdel;
        }

        private string fid;//楼层ID
        private int bid;//宿舍楼ID
        private string floorname;//楼层名称
        private string fnumber;//楼层代码
        private int forder;//排序
        private int isdel;//是否删除


        ///<summary>
        ///楼层ID
        ///</summary>
        public string FID
        {
            get
            {
                return fid;
            }
            set
            {
                fid = value;
            }
        }

        ///<summary>
        ///宿舍楼ID
        ///</summary>
        public int BID
        {
            get
            {
                return bid;
            }
            set
            {
                bid = value;
            }
        }

        ///<summary>
        ///楼层名称
        ///</summary>
        public string FloorName
        {
            get
            {
                return floorname;
            }
            set
            {
                floorname = value;
            }
        }

        ///<summary>
        ///楼层代码
        ///</summary>
        public string FNumber
        {
            get
            {
                return fnumber;
            }
            set
            {
                fnumber = value;
            }
        }

        ///<summary>
        ///排序
        ///</summary>
        public int FOrder
        {
            get
            {
                return forder;
            }
            set
            {
                forder = value;
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
