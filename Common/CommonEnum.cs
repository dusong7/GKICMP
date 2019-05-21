/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09时20分16秒
** 描    述:      公共枚举类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/

namespace GK.GKICMP.Common
{
    public class CommonEnum
    {
        #region 删除状态
        /// <summary>
        /// 删除状态
        /// </summary>
        public enum Deleted
        {
            /// <summary>
            /// 未删除
            /// </summary>
            未删除 = 0,

            /// <summary>
            /// 删除
            /// </summary>
            删除 = 1
        }
        #endregion


        #region 学生考勤状态
        /// <summary>
        /// 学生考勤状态
        /// </summary>
        public enum AttendState
        {
            /// <summary>
            /// 迟到
            /// </summary>
            迟到 = 1,
            /// <summary>
            /// 事假
            /// </summary>
            事假 = 2,
            /// <summary>
            /// 病假
            /// </summary>
            病假 = 3,
            /// <summary>
            /// 传染病
            /// </summary>
            传染病 = 4
        }
        #endregion


        #region 是否
        /// <summary>
        /// 是否
        /// </summary>
        public enum IsorNot
        {
            /// <summary>
            /// 是
            /// </summary>
            是 = 1,

            /// <summary>
            /// 是
            /// </summary>
            否 = 0
        }
        #endregion


        #region 操作日志类型
        /// <summary>
        /// 操作日志类型
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// 登录日志
            /// </summary>
            登录日志 = 1,
            /// <summary>
            /// 注销日志
            /// </summary>
            注销日志 = 2,
            /// <summary>
            /// 操作日志
            /// </summary>
            操作日志_添加 = 31,
            操作日志_删除 = 32,
            操作日志_修改 = 33,
            操作日志_下载 = 34,
            操作日志_导出 = 35,
            操作日志_导入 = 36,
            操作日志_其他 = 39,

            /// 系统日志
            /// </summary>
            系统日志 = 4

        }

        public enum LogFlag
        {
            /// <summary>
            /// 登录日志
            /// </summary>
            操作日志 = 1,
            /// <summary>
            /// 文件日志
            /// </summary>
            文件日志 = 2


        }
        #endregion


        #region 部门类型
        /// <summary>
        /// 部门类型
        /// </summary>
        public enum DepType
        {
            /// <summary>
            /// 普通班级
            /// </summary>
            普通班级 = -1,

            /// <summary>
            /// 职能部门                                                          
            /// </summary>
            职能部门 = -2,
            /// <summary>
            /// 自定义分组                                                           
            /// </summary>
            自定义分组 = -3

        }
        #endregion


        #region 年级
        /// <summary>
        /// 年级
        /// </summary>
        public enum NJ
        {
            一年级 = 1,
            二年级 = 2,
            三年级 = 3,
            四年级 = 4,
            五年级 = 5,
            六年级 = 6,
            七年级 = 7,
            八年级 = 8,
            九年级 = 9
        }
        #endregion


        #region 年级段
        /// <summary>
        /// 年级段
        /// </summary>
        public enum NJD
        {
            小学 = 1,
            初中 = 2,
            高中 = 3
        }
        #endregion


        #region 资源分类
        /// <summary>
        /// 资源分类
        /// </summary>
        public enum EType
        {
            课件 = 1,
            教案 = 2,
            试卷 = 3,
            素材 = 4,
            微课程 = 5,
            在线课堂 = 6,
            其他 = 7
        }
        #endregion


        #region 基础数据类型
        /// <summary>
        /// 基础数据类型
        /// </summary>
        public enum DataType
        {
            //  资产分类 = 1,
            仓库名称 = 2,
            计量单位 = 3,
            ///// <summary>
            ///// 宿舍楼类型
            ///// </summary>
            //宿舍楼类型 = 4,
            专业部 = 5,
            公文归档 = 6,
            获奖类别 = 7,
            获奖角色 = 8,
            幻灯片 = 9,
            友情链接 = 10,
            广告 = 11,
            培训类型 = 12,
            考试性质 = 13,
            考试方式 = 14,
            项目类型 = 15,
            学科 = 16,
            长假类型 = 17,
            通知公告 = 18,
            耗材分类 = 19,
            场地类型 = 20,
            车辆类型 = 21,
            学生活动类型 = 22,
            报销分类 = 23,
            报销方式 = 24,
            教学活动类型 = 25,
            课程类别 = 26,
            来访类型 = 27,
            资产分组=28,
        }
        #endregion


        #region 资产状态（领用/借出）
        /// <summary>
        /// 资产状态（领用/借出）
        /// </summary>
        public enum ABState
        {
            借出 = 1,
            归还 = 2,
            领用 = 3
        }
        #endregion


        #region 宿舍楼类型
        /// <summary>
        /// 宿舍楼类型
        /// </summary>
        public enum BType
        {
            未知 = 0,
            男生宿舍 = 1,
            女生宿舍 = 2,
            混住宿舍 = 9
        }
        #endregion


        #region 性别
        /// <summary>
        /// 性别
        /// </summary>
        public enum XB
        {
            未知 = 0,
            男 = 1,
            女 = 2,
            未说明的性别 = 9
        }
        #endregion


        #region 用户类型
        /// <summary>
        /// 用户类型
        /// </summary>
        public enum UserType
        {
            老师 = 1,
            学生 = 2,
            校外人士 = 3

        }
        #endregion


        #region 宿舍状态
        /// <summary>
        /// 宿舍状态
        /// </summary>
        public enum DorState
        {
            可用 = 1,
            不可用 = 2
        }
        #endregion


        #region 宿舍楼状态
        /// <summary>
        /// 宿舍楼状态
        /// </summary>
        public enum BState
        {
            正常使用 = 1,
            维修 = 2
        }
        #endregion


        /// <summary>
        /// 审核状态
        /// </summary>
        public enum AduitState
        {
            未审核 = 1,
            通过 = 2,
            驳回 = 3,
            审核中 = 4
        }
        /// <summary>
        /// 实习类型
        /// </summary>
        public enum PraType
        {
            集中实习 = 0,
            自主实习 = 1
        }

        /// <summary>
        /// 会议室状态
        /// </summary>
        public enum PraState
        {
            申请中 = 0,
            通过 = 1,
            驳回 = 2
        }

        /// <summary>
        /// 建设性质
        /// </summary>
        public enum BuildNature
        {
            新建 = 1,
            扩建 = 2,
            维修 = 3,
        }
        /// <summary>
        /// 资金来源
        /// </summary>
        public enum BSources
        {
            市级以上专项经费 = 1,
            教育附加费 = 2,
            自筹资金 = 3,
        }
        #region 系统消息类型
        /// <summary>
        /// 系统消息类型
        /// </summary>
        public enum MessType
        {
            公告通知 = 1,
            会议管理 = 2,
            报修通知 = 3,

        }
        #endregion


        #region 民族
        /// <summary>
        /// 民族
        /// </summary>
        public enum MZ
        {
            汉族 = 1,
            蒙古族 = 2,
            回族 = 3,
            藏族 = 4,
            维吾尔族 = 5,
            苗族 = 6,
            彝族 = 7,
            壮族 = 8,
            布依族 = 9,
            朝鲜族 = 10,
            满族 = 11,
            侗族 = 12,
            瑶族 = 13,
            白族 = 14,
            土家族 = 15,
            哈尼族 = 15,
            哈萨克族 = 16,
            傣族 = 18,
            黎族 = 19,
            僳僳族 = 20,
            佤族 = 21,
            畲族 = 22,
            高山族 = 23,
            拉祜族 = 24,
            水族 = 25,
            东乡族 = 26,
            纳西族 = 27,
            景颇族 = 28,
            柯尔克孜族 = 29,
            土族 = 30,
            达斡尔族 = 31,
            仫佬族 = 32,
            羌族 = 33,
            布朗族 = 34,
            撒拉族 = 35,
            毛南族 = 36,
            仡佬族 = 37,
            锡伯族 = 38,
            阿昌族 = 39,
            普米族 = 40,
            塔吉克族 = 41,
            怒族 = 42,
            乌孜别克族 = 43,
            俄罗斯族 = 44,
            鄂温克族 = 45,
            德昂族 = 46,
            保安族 = 47,
            裕固族 = 48,
            京族 = 49,
            塔塔尔族 = 50,
            独龙族 = 51,
            鄂伦春族 = 52,
            赫哲族 = 53,
            门巴族 = 54,
            珞巴族 = 55,
            基诺族 = 56
        }
        #endregion


        #region 政治面貌
        /// <summary>
        /// 政治面貌
        /// </summary>
        public enum ZZMM
        {
            中国共产党党员 = 1,
            中国共产党预备党员 = 2,
            中国共产主义青年团团员 = 3,
            中国国民党革命委员会会员 = 4,
            中国民主同盟盟员 = 5,
            中国民主建国会会员 = 6,
            中国民主促进会会员 = 7,
            中国农工民主党党员 = 8,
            中国致公党党员 = 9,
            九三学社社员 = 10,
            台湾民主自治同盟盟员 = 11,
            无党派民主人士 = 12,
            群众 = 13
        }
        #endregion


        #region 就读方式
        /// <summary>
        /// 就读方式
        /// </summary>
        public enum StudyWay
        {
            住校 = 1,
            走读 = 2
        }
        #endregion


        #region 学制
        /// <summary>
        /// 学制
        /// </summary>
        public enum SLength
        {
            一年 = 1,
            两年 = 2,
            三年 = 3,
            四年 = 4,
            五年 = 5,
            八年 = 8

        }
        #endregion


        #region 课程性质
        /// <summary>
        /// 课程性质
        /// </summary>
        public enum CourseNature
        {
            公共基础课 = 1,
            学科基础课 = 2,
            专业课 = 3,
            公共课 = 4

        }
        #endregion


        #region 奖学金类型
        /// <summary>
        /// 奖学金类型
        /// </summary>
        public enum Scholarship
        {
            国家奖学金 = 1,
            宏大奖学金 = 2,
            金诚信奖学金 = 3,
            国家励志奖学金 = 4
        }
        #endregion

        #region 助学金类型
        /// <summary>
        /// 助学金类型
        /// </summary>
        public enum GrantType
        {
            国家助学金 = 1,
            贫困助学 = 2
        }
        #endregion


        #region 楼栋类型
        /// <summary>
        /// 楼栋类型
        /// </summary>
        public enum BuildingType
        {
            宿舍楼 = 1,
            教学楼 = 2
        }
        #endregion


        #region 状态
        /// <summary>
        /// 状态
        /// </summary>
        public enum State
        {
            启用 = 0,
            禁用 = 1
        }
        #endregion


        #region 获奖等级
        /// <summary>
        /// 获奖等级
        /// </summary>
        public enum WinningGrade
        {
            特等 = 0,
            一等 = 1,
            二等 = 2,
            三等 = 3,
            四等 = 4,
            未评等级 = 5,
            其他 = 6
        }
        #endregion

        #region 奖励级别
        /// <summary>
        /// 将来级别
        /// </summary>
        public enum WinningLevel
        {
            一级 = 1,
            二级 = 2,
            三级 = 3,
            四级 = 4
        }
        #endregion

        #region 奖励方式
        /// <summary>
        /// 奖励方式
        /// </summary>
        public enum WinMode
        {
            奖状 = 1,
            荣誉称号 = 2,
            资金 = 3,
            实物 = 4,
            其他 = 7
        }
        #endregion


        #region 会议室类型
        /// <summary>
        /// 会议室类型
        /// </summary>
        public enum RoomState
        {
            会议室 = 1,
            阶梯教室 = 2,
            录播教室 = 3
        }
        #endregion


        #region 教材类别
        /// <summary>
        /// 教材类别
        /// </summary>
        public enum TMType
        {
            校本教材 = 0,
            通用教材 = 1
        }
        #endregion

        #region 学生请假类型
        /// <summary>
        /// 学生请假类型
        /// </summary>
        public enum StuLeaveType
        {
            事假 = 1,
            病假 = 2
        }
        #endregion


        #region 表示
        /// <summary>
        /// 表示
        /// </summary>
        public enum LFlag
        {
            请假 = 1,
            外出登记 = 2,
            外出备案 = 3,
        }
        #endregion


        #region 栏目类别
        /// <summary>
        /// 栏目类别
        /// </summary>
        public enum MType
        {
            单篇 = 1,
            新闻 = 2,
            链接 = 3,
            相册 = 4,
            下载 = 5,
            其他 = 6
        }
        #endregion


        #region 站点标识
        /// <summary>
        /// 站点标识
        /// </summary>
        public enum SiteFlag
        {
            基础管理平台 = 1,
            门户管理平台 = 2,
            教务管理平台 = 3,
            学生管理平台 = 4,
            行政办公平台 = 5,
            资源平台 = 6,
            综合查询与决策平台 = 7
        }
        #endregion


        #region 用户状态
        /// <summary>
        /// 用户状态
        /// </summary>
        public enum UState
        {
            正常 = 0,
            未审核 = 1,
            录取未报道 = 4,
            禁用 = -1,
            驳回 = -2,
            毕业 = 2
        }
        #endregion


        #region 报修状态
        /// <summary>
        /// 报修状态
        /// </summary>
        public enum ARState
        {
            驳回 = -1,
            未受理 = 0,
            已受理 = 1,
            完成 = 2,
            确认完成 = 3,
            移交 = -3,
        }
        #endregion




        #region 学期
        /// <summary>
        /// 学期
        /// </summary>
        public enum XQ
        {
            //秋季学期 = 1,
            //春季学期 = 2,
            //夏季学期 = 3,
            //其他 = 9
            上学期 = 1,
            下学期 = 2
        }
        #endregion


        //#region 教材版本
        ///// <summary>
        ///// 教材版本
        ///// </summary>
        //public enum Edition
        //{
        //    人教版 = 1,
        //    人教版2001 = 2,
        //    人教版2011 = 3,
        //    人教PEP2011三年级起点 = 4,
        //    人教版2001五线谱 = 5,
        //    人教版2001一年级起点 = 6,
        //    人教版2001三年级起点 = 7,
        //    人教PEP2013三年级起点 = 8,
        //    人教版2013 = 9,
        //    上教牛津英语三年级起点2013版 = 10,
        //    沪科版2013 = 11,
        //    电子工业出版社 = 12
        //}
        //#endregion


        #region 健康状况
        /// <summary>
        /// 健康状况
        /// </summary>
        public enum HealthStatus
        {
            健康或良好 = 1,
            一般或较弱 = 2,
            有慢性病 = 3,
            残疾 = 6
        }
        #endregion

        #region 教职工类别
        /// <summary>
        /// 教职工类别
        /// </summary>
        public enum EmploymentType
        {
            任课 = 1,
            未任课 = 2,
            其他 = 3

        }
        #endregion

        #region 签订合同情况
        /// <summary>
        /// 签订合同情况
        /// </summary>
        public enum ContractState
        {
            未签合同 = 0,
            聘用合同 = 1,
            劳务合同 = 2,
            其他合同 = 3
        }
        #endregion


        #region 信息技术应用能力
        /// <summary>
        /// 信息技术应用能力
        /// </summary>
        public enum InformationLevel
        {
            精通 = 1,
            熟练 = 2,
            良好 = 3,
            一般 = 4,
            较弱 = 5
        }
        #endregion

        #region 学科领域
        /// <summary>
        /// 学科领域
        /// </summary>
        public enum SubjectField
        {
            哲学 = 1,
            经济学 = 2,
            法学 = 3,
            教育学 = 4,
            文学 = 5,
            历史学 = 6,
            理学 = 7,
            工学 = 8,
            农学 = 9,
            医学 = 10,
            军事学 = 11,
            管理学 = 12,
            艺术学 = 13
        }
        #endregion


        #region 用人形式
        /// <summary>
        /// 用人形式
        /// </summary>
        public enum EmploymentForm
        {
            人事代理 = 1,
            劳务派遣 = 2,
            其他 = 3
        }
        #endregion

        #region 学历
        /// <summary>
        /// 学历
        /// </summary>
        public enum XL
        {
            博士研究生毕业 = 11,
            博士研究生结业 = 12,
            博士研究生肄业 = 13,

            硕士研究生毕业 = 14,
            硕士研究生结业 = 15,
            硕士研究生肄业 = 16,

            //研究生班毕业 = 17,
            //研究生班结业 = 18,
            //研究生班肄业 = 19,

            大学本科毕业 = 21,
            大学本科结业 = 22,
            大学本科肄业 = 23,

            //大学普通班毕业 = 28,

            大学专科毕业 = 31,
            大学专科结业 = 32,
            大学专科肄业 = 33,

            //高等职院毕业 = 34,
            中专毕业 = 41,
            高中毕业 = 51,
            初中毕业 = 71,
            小学毕业 = 72,
            其他 = 73,//学生分班
        }
        #endregion


        #region 交流水平
        /// <summary>
        /// 交流水平
        /// </summary>
        public enum JL
        {
            A = 1,
            B = 2,
            C = 3
        }
        #endregion


        #region 学位类别
        /// <summary>
        /// 学位类别
        /// </summary>
        public enum XWLB
        {
            无学位 = 0,
            学术型学士 = 11,
            专业学位学士 = 12,
            学术型硕士 = 21,
            专业学位硕士 = 22,
            学术型博士 = 31,
            专业学位博士 = 32
        }
        #endregion

        #region 学位层次
        /// <summary>
        /// 学位层次
        /// </summary>
        public enum XWCC
        {
            学士 = 0,
            硕士 = 1,
            博士 = 2,
            无 = 3
        }
        #endregion

        #region 学位名称
        /// <summary>
        /// 学位名称
        /// </summary>
        public enum XWMC
        {

        }
        #endregion

        #region 学习方式
        /// <summary>
        /// 学习方式
        /// </summary>
        public enum XXFS
        {
            全脱产 = 1,
            半脱产 = 2,
            不脱产 = 3
        }
        #endregion

        #region 考核结果
        /// <summary>
        /// 考核结果
        /// </summary>
        public enum KHJG
        {
            优秀 = 1,
            合格 = 2,
            基本合格 = 3,
            不合格 = 4,
            不确定考核结果 = 5,
            未参加考核 = 6
        }
        #endregion


        #region 人员状态
        /// <summary>
        /// 人员状态
        /// </summary>
        public enum TeaState
        {
            在本单位任职 = 100,
            在本单位任职_交流轮岗 = 101,
            暂未在本单位任职_借出到机关 = 201,
            暂未在本单位任职_借出到事业单位 = 202,
            暂未在本单位任职_长病假 = 203,
            暂未在本单位任职_进修 = 204,
            暂未在本单位任职_交流轮岗 = 205,
            暂未在本单位任职_企业实践 = 206,
            暂未在本单位任职_因公出国 = 207,
            暂未在本单位任职_离岗创业 = 208,
            暂未在本单位任职_待退休 = 209,
            暂未在本单位任职_待岗 = 210,
            暂未在本单位任职_下落不明 = 211,
            //暂未在本单位任职_其他 = 299
            暂未在本单位任职_退休 = 301,
            暂未在本单位任职_离休 = 302,
            暂未在本单位任职_死亡 = 303,
            暂未在本单位任职_辞职 = 306,
            暂未在本单位任职_离职 = 307,
            暂未在本单位任职_开除 = 308
        }
        #endregion

        #region 教师状态
        /// <summary>
        /// 教师状态
        /// </summary>
        public enum TeacherState
        {
            退休 = 1,
            离休 = 2,
            死亡 = 3,
            调出 = 5,
            辞职 = 6,
            离职 = 7,
            开除 = 8,
            下落不明 = 9,
            待退休 = 13,
            长病假 = 14,
            因公出国 = 15,
            停职留薪 = 16,
            待岗 = 17,
            其他 = 99
        }
        #endregion

        #region  课程等级
        /// <summary>
        ///  课程登记
        /// </summary>
        public enum CourseGrade
        {
            国家课程 = 1,
            地方课程 = 2,
            校本课程 = 3
        }
        #endregion


        #region  预设基础数据类别
        /// <summary>
        ///  预设基础数据类别
        /// </summary>
        public enum BaseDataType
        {
            教职工类别 = 1,
            婚姻状况 = 2,
            在学单位类别 = 3,
            学科领域 = 4,
            身份证件类型 = 5,
            国家 = 6,
            教职工来源 = 7,
            考核结果 = 8,
            教师职务角色 = 9,
            合同类型 = 10,
            交流性质 = 11,
            学习类型 = 12,
            论文收录情况 = 13,
            流动人口 = 14,
            专业技术岗位等级 = 15,
            备课类型 = 16,
            考勤节点类型 = 17,
            课程等级 = 18,
            请假类型 = 19,
            加班类型 = 20,
        }
        #endregion

        #region 合同状态
        /// <summary>
        /// 合同状态
        /// </summary>
        public enum TState
        {
            正常 = 1,
            到期 = 2,
            解除 = 3
        }
        #endregion

        #region 附件类型
        /// <summary>
        /// 附件类型
        /// </summary>
        public enum AccessoryType
        {
            /// <summary>
            /// Tb_Web_Slide
            /// </summary>
            Tb_Web_Slide = 1,//
            Tb_Project = 2,//项目附件类型
            Tb_VisitLog = 3,//拜访日志类型
            Tb_Contract = 4,//
            Tb_Labor = 5,//劳务附件类型
            Tb_MeetingQuest = 6,//会议附件类型
            报销附件 = 7,
            活动LOGO = 8,
            Tb_Tender=9,//中标附件
        }
        #endregion

        #region 资产文件类型
        public enum ProjectFile
        {
            技术参数 = 1,
            委托函 = 2,
            代理协议 = 3,
            资金预算证明 = 4,
            资产清单 = 5,
        }

        #endregion

        #region 项目验收综合评价
        public enum ProjectCheck
        {
            好 = 1,
            较好 = 2,
            一般 = 3,
            较差 = 4
        }
        #endregion

        #region 文章审核
        public enum NewsAuditState
        {
            未审 = 0,
            通过 = 1,
            不通过 = 2,
        }

        #endregion


        #region 幻灯片分类
        /// <summary>
        /// 幻灯片、友情链接、宣传标语分类
        /// </summary>
        public enum SlideType
        {
            友情链接 = 1,
            幻灯片 = 2,
            宣传标语 = 3
        }
        #endregion

        /// <summary>
        /// 邮件类别
        /// </summary>
        public enum RecType
        {
            私人消息 = 1,
            群发消息 = 2,
        }

        #region 考勤方式
        public enum AttendType
        {
            考勤机 = 0,
            微信签到 = 1,
            人脸识别 = 3,
            补卡 = 4,
            钉钉打卡 = 5,
            其他 = 10,
        }

        #endregion
        /// <summary>
        /// 论文中本人所属角色
        /// </summary>
        public enum URole
        {
            独立完成 = 10,
            第一作者 = 11,
            通讯作者 = 12,
            其他 = 99,
        }

        #region 奖励级别
        /// <summary>
        /// 将来级别
        /// </summary>
        public enum RGrade
        {
            国家级 = 1,
            教育部 = 2,
            中央其他部委 = 3,
            省级或自治区直辖市级 = 4,
            省教育行政部门级 = 5,
            省级其他部门 = 6,
            地市州级 = 7,
            地级教育行政部门级 = 8,
            地级其他部门 = 9,
            县级 = 10,
            县级教育行政部门 = 11,
            县级其他部门 = 12,
            乡镇级 = 13,
            学校级 = 14,
            国际级 = 15,
            其他 = 16
        }
        #endregion
        #region 奖励等级
        public enum RewardType
        {
            特等 = 1,
            一等 = 2,
            二等 = 3,
            三等 = 4,
            四等 = 5,
            未评等级 = 6,
            其他 = 7,
        }

        #endregion
        #region 奖励类别
        /// <summary>
        /// 奖励类别
        /// </summary>
        public enum RType
        {
            学科获奖 = 1,
            科技获奖 = 2,
            文艺获奖 = 3,
            体育获奖 = 4,
            综合获奖 = 5,
            社会工作获奖 = 6,
            公益事业获奖 = 7,
            其他 = 8,
        }
        #endregion

        #region 奖励类型
        /// <summary>
        /// 奖励类型
        /// </summary>
        public enum RStyle
        {
            集体 = 1,
            个人综合 = 2,
            个人单项 = 3,
        }
        #endregion
        #region 奖励方式
        /// <summary>
        /// 奖励方式
        /// </summary>
        public enum RMode
        {
            奖状 = 1,
            荣誉称号 = 2,
            奖金 = 3,
            实物 = 4,
            其他 = 5,
        }
        #endregion
        #region 著作类别
        /// <summary>
        /// 著作类别
        /// </summary>
        public enum JournalType
        {
            专著 = 1,
            编著 = 2,
            译著 = 3,
            教材 = 4,
            科普读物 = 5
        }
        #endregion

        #region 本人排名
        /// <summary>
        /// 本人排名
        /// </summary>
        public enum Ranking
        {
            一 = 0,
            二 = 1,
            三 = 2,
            无 = 3,
            其他 = 4
        }

        #endregion

        #region 户口类型
        /// <summary>
        /// 户口类型
        /// </summary>
        public enum HKLX
        {

            农村户口 = 1,
            城市户口 = 2
        }
        #endregion


        #region 变动类型
        /// <summary>
        /// 变动类型
        /// </summary>
        public enum BDLX
        {

            招生 = 11,
            复学 = 12,
            转入 = 13,
            毕业 = 21,
            结业 = 22,
            休学 = 23,
            退学 = 24,
            开除 = 25,
            死亡 = 26,
            转出 = 27,
            辍学 = 28
        }
        #endregion


        #region 资产类别
        /// <summary>
        /// 资产类别
        /// </summary>
        public enum AIType
        {
            有账无物 = 1,
            有物无账 = 2,
            调拨 = 3,
            退回 = 4
        }
        #endregion

        #region 公文状态
        public enum GWType
        {
            未处理 = 0,
            批转中 = 1,
            已处理 = 2,
            归档 = 3,
            上报 = 4,
            已阅 = 5,
        }
        #endregion

        public enum HumanType
        {
            报修受理人 = 1,
            政务接受人 = 2,
            请假审核人 = 3,
            资产盘点负责人 = 4,
            校区负责人 = 5,
            会议室管理员 = 6,
            会议主持人 = 7,
            场室管理员 = 8,
            宿舍楼管理员 = 9,
            外出审核人 = 10,
            考勤异常接收人 = 11,
            采购审核人 = 12,
            请假抄送人 = 13,
            代课安排人 = 14,
            外出抄送人 = 15,
            加班审核人 = 16,
            补卡审核人 = 17,
            考勤管理 = 18,
        }

        #region 灵信LED屏入场特效值
        /// <summary>
        /// 灵信LED屏入场特效值
        /// </summary>
        public enum LedPLAYPROP
        {
            立即显示 = 0,
            随机 = 1,
            左移 = 2,
            右移 = 3,
            上移 = 4,
            下移 = 5,
            连续左移 = 6,
            连续右移 = 7,
            连续上移 = 8,
            连续下移 = 9,
            闪烁 = 10,
            激光字向上 = 11,
            激光字向下 = 12,
            激光字向左 = 13,
            激光字向右 = 14,
            水平交叉拉幕 = 15,
            上下交叉拉幕 = 16,
            左右切入 = 17,
            上下切入 = 18,
            左覆盖 = 19,
            右覆盖 = 20,
            上覆盖 = 21,
            下覆盖 = 22,
            水平百叶左右 = 23,
            水平百叶右左 = 24,
            垂直百叶上下 = 25,
            垂直百叶下上 = 26,
            左右对开 = 27,
            上下对开 = 28,
            左右闭合 = 29,
            上下闭合 = 30,
            向左拉伸 = 31,
            向右拉伸 = 32,
            向上拉伸 = 33,
            向下拉伸 = 34,
            分散向左拉伸 = 35,
            分散向右拉伸 = 36,
            冒泡 = 37,
            下雪 = 38,
        }
        #endregion

        #region Led卡类型
        public enum LedType
        {
            单色双色七彩卡 = 1,
            全彩 = 2,
        }
        #endregion

        #region Led屏颜色
        public enum LedColor
        {
            单色 = 1,
            双色 = 2,
            七彩 = 3,
            全彩 = 4,
        }
        #endregion
        #region LED通讯方式
        public enum LedConn
        {
            固定IP通讯 = 0,
            单机直连 = 1,
            串口通讯 = 2,
        }
        #endregion

        #region LED品牌
        public enum LedBrand
        {
            灵信 = 1,
        }
        #endregion
        #region LED节目添加类型
        public enum LedAddType
        {
            文字 = 0,
            文件 = 1,
        }
        #endregion

        #region 车型
        /// <summary>
        /// 车型           
        /// </summary>
        public enum Vtype
        {
            A1 = 1,
            A2 = 2,
            A3 = 3,
            B1 = 4,
            B2 = 5,
            C1 = 6,
            C2 = 7
        }
        #endregion


        #region 车辆状态
        /// <summary>
        /// 车辆状态           
        /// </summary>
        public enum VState
        {
            正常 = 1,
            维修中 = 2,
            报废 = 3
        }
        #endregion


        #region 工资标识
        /// <summary>
        /// 工资标识           
        /// </summary>
        public enum WFlag
        {
            在编 = 1,
            聘用 = 2
        }
        #endregion


        #region 题型
        /// <summary>
        /// 题型           
        /// </summary>
        public enum ExerciseType
        {
            主观题 = 5,
            单项选 = 1,
            多选题 = 2,
            填空题 = 3,
            判断题 = 4
        }
        #endregion

        #region 难易程度
        /// <summary>
        /// 难易程度           
        /// </summary>
        public enum DifficultyType
        {
            基础题 = 1,
            中档题 = 2,
            难题 = 3
        }
        #endregion


        #region 生成方式
        /// <summary>
        /// 生成方式           
        /// </summary>
        public enum SCFS
        {
            手动生成 = 1,
            自动生成 = 2
        }
        #endregion


        #region 等级分类
        /// <summary>
        /// 等级分类
        /// </summary>
        public enum ProfessGradeType
        {
            试用期 = 332,
            管理人员 = 333,
            专业技术人员 = 334,
            技术工人 = 335,
            普通工人 = 336
        }
        #endregion


        #region 现任专业技术资格
        /// <summary>
        /// 现任专业技术资格
        /// </summary>
        public enum CurrentProfessional
        {
            正高级教师 = 1,
            高级教师 = 2,
            一级教师 = 3,
            二级教师 = 4,
            三级教师 = 5,
            未定级 = 0,
        }
        #endregion
        #region 普通话水平
        /// <summary>
        /// 普通话水平
        /// </summary>
        public enum MandarinType
        {
            一级甲等 = 1,
            一级乙等 = 2,
            二级甲等 = 3,
            二级乙等 = 4,
            三级甲等 = 5,
            三级乙等 = 6
        }
        #endregion
        #region 教师资格类型
        /// <summary>
        /// 教师资格类型
        /// </summary>
        public enum TeaQualiType
        {
            幼儿园教师资格 = 1,
            小学教师资格 = 2,
            初级中学教师资格 = 3,
            高级中学教师资格 = 4,
            中等职业学校教师资格 = 5,
            中等职业学校实习指导教师资格 = 6,
            高等学校教师资格 = 7
        }
        #endregion

        #region 类型
        /// <summary>
        /// 类型
        /// </summary>
        public enum PType
        {
            普通 = 0,
            必须 = 1,
            推荐 = 2,
            禁止 = 3

        }
        #endregion

        #region 班班通使用登记类型
        /// <summary>
        /// 班班通使用登记类型
        /// </summary>
        public enum RegType
        {
            自动登记 = 1,
            补录 = 2,
            手机端登记 = 3
        }
        #endregion

        #region 打卡分析类型
        /// <summary>
        /// 打卡分析类型
        /// </summary>
        public enum RecordType
        {
            未分析 = 0,
            正常 = 1,
            迟到 = 2,
            早退 = 3,
            加班 = 4
        }
        #endregion

        #region 分数等级
        /// <summary>
        /// 分数等级
        /// </summary>
        public enum SLName
        {
            优秀 = 1,
            良好 = 2,
            合格 = 3,
            不合格 = 4
        }
        #endregion

        #region 退回调拨
        /// <summary>
        /// 退回调拨
        /// </summary>
        public enum AFlag
        {
            调拨 = 1,
            退回 = 2
        }
        #endregion

        #region 自定义流类型
        /// <summary>
        /// 退回调拨
        /// </summary>
        public enum WFType
        {
            单行文本 = 1,
            多行文本 = 2,
            数字输入框 = 3,
            选择 = 4,
            日期 = 5,
            文件 = 6,
            说明文字 = 7,
            联系人 = 8,
            金额 = 9,
        }
        #endregion

        #region 自定义审批数据类型
        /// <summary>
        /// 退回调拨
        /// </summary>
        public enum FAVType
        {
            审核 = 1,
            抄送 = 2,
        }
        #endregion

        #region 自定义审批审核类型
        /// <summary>
        /// 退回调拨
        /// </summary>
        public enum AuditType
        {
            指定成员 = 1,
            角色 = 2,
            自己 = 3,
            抄送 = 4,
        }
        #endregion

        #region 自定义审批结果类型
        /// <summary>
        /// 自定义审批结果类型
        /// </summary>
        public enum CState
        {
            拟办 = -2,
            无需审核 = -1,
            未审核 = 0,
            审核中 = 1,
            审核通过 = 2,
            审核退回 = 3
        }
        #endregion

        #region 选课任务状态
        /// <summary>
        /// 选课任务状态
        /// </summary>
        public enum ElectiveState
        {
            未发布 = 0,
            未开始 = 1,
            预选阶段 = 2,
            选课阶段 = 3,
            结束 = 4
        }
        #endregion

        #region 选课类型
        /// <summary>
        /// 选课类型
        /// </summary>
        public enum ElectiverEType
        {
            预选 = 1,
            实选 = 2
        }
        #endregion


        #region 钉钉考勤
        public enum sourceType
        {
            ATM = 1,//考勤机
            BEACON = 2,//蓝牙
            DING_ATM = 3,//钉钉考勤机
            USER = 4,//用户打卡
            BOSS = 5,//老板改签
            APPROVE = 6,//审批系统
            SYSTEM = 7,//考勤系统
            AUTO_CHECK = 8//自动打卡
        }

        public enum timeResult
        {
            Normal = 1,//正常
            Early = 2,//早退
            Late = 3,//迟到
            SeriousLate = 4,//严重迟到
            Absenteeism = 5,//旷工迟到
            NotSigned = 6,//未打卡
        }

        public enum checkType
        {
            //上班
            OnDuty = 1,
            //下班
            OffDuty = 2
        }
        #endregion
    }
}
