/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      fzh
** 创建日期:      2016年11月11日 03点08分
** 描   述:      宿舍楼实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class BuildingEntity
    {

        /// <summary>
        /// Building表实体
        ///</summary>
        public BuildingEntity()
        {
        }


        /// <summary>
        /// Building表实体
        /// </summary>
        /// <param name="bname">宿舍楼名称</param>
        /// <param name="btype">宿舍楼类型：男生宿舍楼 女生宿舍楼 混住宿舍楼</param>
        /// <param name="isdel">是否删除</param>
        public BuildingEntity(string bname, int btype, int isdel,int bflag)
        {
            this.BName = bname;
            this.BType = btype;
            this.Isdel = isdel;
            this.BFlag = bflag;
        }

        private int bid;//宿舍楼ID
        private string bname;//宿舍楼名称
        private string bnumber;//宿舍楼代码
        private int btype;//宿舍楼类型：男生宿舍楼 女生宿舍楼 混住宿舍楼
        private decimal allbuilding;//总建筑面积
        private decimal allusearea;//总使用面积
        private string baddress;//宿舍楼地址
        private int floornum;//楼层数
        private int bstate;//宿舍楼状态
        private int border;//排序
        private string bphoto;//宿舍楼图片
        private string badmin;//宿舍楼管理员
        private int isdel;//是否删除
        private string campusname;//校区名称
        private int bflag;//1:宿舍楼  2：教学楼
        private int cid;
        public int CID
        {
            get { return cid; }
            set { cid = value; }
        }

        public int BFlag
        {
            get { return bflag; }
            set { bflag = value; }
        }


        /// <summary>
        /// 校区名称
        /// </summary>
        public string CampusName
        {
            get { return campusname; }
            set { campusname = value; }
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
        ///宿舍楼名称
        ///</summary>
        public string BName
        {
            get
            {
                return bname;
            }
            set
            {
                bname = value;
            }
        }

        ///<summary>
        ///宿舍楼代码
        ///</summary>
        public string BNumber
        {
            get
            {
                return bnumber;
            }
            set
            {
                bnumber = value;
            }
        }


        ///<summary>
        ///宿舍楼类型：男生宿舍楼 女生宿舍楼 混住宿舍楼
        ///</summary>
        public int BType
        {
            get
            {
                return btype;
            }
            set
            {
                btype = value;
            }
        }

        ///<summary>
        ///总建筑面积
        ///</summary>
        public decimal AllBuilding
        {
            get
            {
                return allbuilding;
            }
            set
            {
                allbuilding = value;
            }
        }

        ///<summary>
        ///总使用面积
        ///</summary>
        public decimal AllUseArea
        {
            get
            {
                return allusearea;
            }
            set
            {
                allusearea = value;
            }
        }

        ///<summary>
        ///宿舍楼地址
        ///</summary>
        public string BAddress
        {
            get
            {
                return baddress;
            }
            set
            {
                baddress = value;
            }
        }

        ///<summary>
        ///楼层数
        ///</summary>
        public int FloorNum
        {
            get
            {
                return floornum;
            }
            set
            {
                floornum = value;
            }
        }

        ///<summary>
        ///宿舍楼状态
        ///</summary>
        public int BState
        {
            get
            {
                return bstate;
            }
            set
            {
                bstate = value;
            }
        }

        ///<summary>
        ///排序
        ///</summary>
        public int BOrder
        {
            get
            {
                return border;
            }
            set
            {
                border = value;
            }
        }

        ///<summary>
        ///宿舍楼图片
        ///</summary>
        public string BPhoto
        {
            get
            {
                return bphoto;
            }
            set
            {
                bphoto = value;
            }
        }

        ///<summary>
        ///宿舍楼管理员
        ///</summary>
        public string BAdmin
        {
            get
            {
                return badmin;
            }
            set
            {
                badmin = value;
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

