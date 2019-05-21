/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月15日 05点58分
** 描   述:      学生信息管理实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class StudentEntity
    {

        /// <summary>
        /// Student表实体
        ///</summary>
        public StudentEntity()
        {
        }


        /// <summary>
        /// Student表实体
        /// </summary>
        /// <param name="stid">用户ID</param>
        /// <param name="claid"></param>班级
        /// <param name="realname">姓名</param>
        /// <param name="usedname">曾用名</param>
        /// <param name="usersex">性别</param>
        /// <param name="idcard">身份证号码</param>
        /// <param name="cellphone">父母手机号码</param>
        /// <param name="birthday">出生年月</param>
        /// <param name="nation">民族</param>
        /// <param name="photos">照片</param>
        /// <param name="cardnum">电子校牌</param>
        /// <param name="registtype">户口类型</param>
        /// <param name="guardian">监护人</param>
        /// <param name="guardnum">监护人身份证号码</param>
        /// <param name="enterdate">入学时间</param>
        /// <param name="registeredplace">户口所在地</param>
        /// <param name="isleftbehind">留守儿童</param>
        /// <param name="isfield">外地学生</param>
        /// <param name="placeorigin">籍贯</param>
        /// <param name="ustate">状态</param>
        /// <param name="politics">政治面貌</param>
        /// <param name="loindate">入团党时间</param>
        /// <param name="isflow">流动人口</param>
        /// <param name="isonly">独生子女</param>
        /// <param name="genrollment">全国学籍号</param>
        /// <param name="penrollment">省学籍号</param>
        /// <param name="isdel">是否删除</param>
        public StudentEntity(string stid, int claid, string realname, string usedname, int usersex, string idcard, string cellphone, DateTime birthday, int nation, string photos, string cardnum, int registtype, string guardian, string guardnum, DateTime enterdate, string registeredplace, int isleftbehind, int isfield, string placeorigin, int ustate, int politics, DateTime loindate, string isflow, int isonly, string genrollment, string penrollment, int isdel)
        {
            this.StID = stid;
            this.ClaID = claid;
            this.RealName = realname;
            this.UsedName = usedname;
            this.UserSex = usersex;
            this.IDCard = idcard;
            this.CellPhone = cellphone;
            this.BirthDay = birthday;
            this.Nation = nation;
            this.Photos = photos;
            this.CardNum = cardnum;
            this.RegistType = registtype;
            this.Guardian = guardian;
            this.GuardNum = guardnum;
            this.EnterDate = enterdate;
            this.RegisteredPlace = registeredplace;
            this.IsLeftBehind = isleftbehind;
            this.IsField = isfield;
            this.PlaceOrigin = placeorigin;
            this.UState = ustate;
            this.Politics = politics;
            this.LoinDate = loindate;
            this.IsFlow = isflow;
            this.IsOnly = isonly;
            this.GEnrollment = genrollment;
            this.PEnrollment = penrollment;
            this.Isdel = isdel;
        }

        private string stid;//用户ID
        private int claid;// 班级
        private string realname;//姓名
        private string usedname;//曾用名
        private int usersex;//性别
        private string idcard;//身份证号码
        private string cellphone;//父母手机号码
        private DateTime birthday;//出生年月
        private int nation;//民族
        private string photos;//照片
        private string cardnum;//电子校牌
        private int registtype;//户口类型
        private string guardian;//监护人
        private string guardnum;//监护人身份证号码
        private DateTime enterdate;//入学时间
        private string registeredplace;//户口所在地
        private int isleftbehind;//留守儿童
        private int isfield;//外地学生
        private string placeorigin;//籍贯
        private int ustate;//状态
        private int politics;//政治面貌
        private DateTime loindate;//入团党时间
        private string isflow;//流动人口
        private int isonly;//独生子女
        private string genrollment;//全国学籍号
        private string penrollment;//省学籍号
        private int isdel;//是否删除
        private string claIDName;
        private string uStateName;
        private int cid;//校区
        private int higheducation;//家长最高学历
        private int levelcommunication;//交流水平

        public int HighEducation
        {
            get { return higheducation; }
            set { higheducation = value; }
        }
        public int LevelCommunication
        {
            get { return levelcommunication; }
            set { levelcommunication = value; }
        }


        /// <summary>
        /// 校区
        /// </summary>
        public int CID
        {
            get { return cid; }
            set { cid = value; }
        }

        public string IsFlowName { get; set; }
        public string UStateName
        {
            get { return uStateName; }
            set { uStateName = value; }
        }

        public string ClaIDName
        {
            get { return claIDName; }
            set { claIDName = value; }
        }

        ///<summary>
        ///用户ID
        ///</summary>
        public string StID
        {
            get
            {
                return stid;
            }
            set
            {
                stid = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int ClaID
        {
            get
            {
                return claid;
            }
            set
            {
                claid = value;
            }
        }

        ///<summary>
        ///姓名
        ///</summary>
        public string RealName
        {
            get
            {
                return realname;
            }
            set
            {
                realname = value;
            }
        }

        ///<summary>
        ///曾用名
        ///</summary>
        public string UsedName
        {
            get
            {
                return usedname;
            }
            set
            {
                usedname = value;
            }
        }

        ///<summary>
        ///性别
        ///</summary>
        public int UserSex
        {
            get
            {
                return usersex;
            }
            set
            {
                usersex = value;
            }
        }

        ///<summary>
        ///身份证号码
        ///</summary>
        public string IDCard
        {
            get
            {
                return idcard;
            }
            set
            {
                idcard = value;
            }
        }

        ///<summary>
        ///父母手机号码
        ///</summary>
        public string CellPhone
        {
            get
            {
                return cellphone;
            }
            set
            {
                cellphone = value;
            }
        }

        ///<summary>
        ///出生年月
        ///</summary>
        public DateTime BirthDay
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        ///<summary>
        ///民族
        ///</summary>
        public int Nation
        {
            get
            {
                return nation;
            }
            set
            {
                nation = value;
            }
        }

        ///<summary>
        ///照片
        ///</summary>
        public string Photos
        {
            get
            {
                return photos;
            }
            set
            {
                photos = value;
            }
        }

        ///<summary>
        ///电子校牌
        ///</summary>
        public string CardNum
        {
            get
            {
                return cardnum;
            }
            set
            {
                cardnum = value;
            }
        }

        ///<summary>
        ///户口类型
        ///</summary>
        public int RegistType
        {
            get
            {
                return registtype;
            }
            set
            {
                registtype = value;
            }
        }

        ///<summary>
        ///监护人
        ///</summary>
        public string Guardian
        {
            get
            {
                return guardian;
            }
            set
            {
                guardian = value;
            }
        }

        ///<summary>
        ///监护人身份证号码
        ///</summary>
        public string GuardNum
        {
            get
            {
                return guardnum;
            }
            set
            {
                guardnum = value;
            }
        }

        ///<summary>
        ///入学时间
        ///</summary>
        public DateTime EnterDate
        {
            get
            {
                return enterdate;
            }
            set
            {
                enterdate = value;
            }
        }

        ///<summary>
        ///户口所在地
        ///</summary>
        public string RegisteredPlace
        {
            get
            {
                return registeredplace;
            }
            set
            {
                registeredplace = value;
            }
        }

        ///<summary>
        ///留守儿童
        ///</summary>
        public int IsLeftBehind
        {
            get
            {
                return isleftbehind;
            }
            set
            {
                isleftbehind = value;
            }
        }

        ///<summary>
        ///外地学生
        ///</summary>
        public int IsField
        {
            get
            {
                return isfield;
            }
            set
            {
                isfield = value;
            }
        }

        ///<summary>
        ///籍贯
        ///</summary>
        public string PlaceOrigin
        {
            get
            {
                return placeorigin;
            }
            set
            {
                placeorigin = value;
            }
        }

        ///<summary>
        ///状态
        ///</summary>
        public int UState
        {
            get
            {
                return ustate;
            }
            set
            {
                ustate = value;
            }
        }

        ///<summary>
        ///政治面貌
        ///</summary>
        public int Politics
        {
            get
            {
                return politics;
            }
            set
            {
                politics = value;
            }
        }

        ///<summary>
        ///入团党时间
        ///</summary>
        public DateTime LoinDate
        {
            get
            {
                return loindate;
            }
            set
            {
                loindate = value;
            }
        }

        ///<summary>
        ///流动人口
        ///</summary>
        public string IsFlow
        {
            get
            {
                return isflow;
            }
            set
            {
                isflow = value;
            }
        }

        ///<summary>
        ///独生子女
        ///</summary>
        public int IsOnly
        {
            get
            {
                return isonly;
            }
            set
            {
                isonly = value;
            }
        }

        ///<summary>
        ///全国学籍号
        ///</summary>
        public string GEnrollment
        {
            get
            {
                return genrollment;
            }
            set
            {
                genrollment = value;
            }
        }

        ///<summary>
        ///省学籍号
        ///</summary>
        public string PEnrollment
        {
            get
            {
                return penrollment;
            }
            set
            {
                penrollment = value;
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

