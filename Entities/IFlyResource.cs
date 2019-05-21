using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
    public class IFlyResult 
    {
        public IFlyResult() { }
        public int Code { get; set; }
        public IFlyData DataList { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
    public class IFlyData 
    {

    }
   public  class IFlyResource
    {
      
       public IFlyResource() { }
    //    备课明细ID Integer preInfoId;
       /// <summary>
       /// 备课明细ID
       /// </summary>
       public int PreInfoID { get; set; }
    //文件id Integer prepareFileId;
       /// <summary>
       /// 文件id
       /// </summary>
       public int PrepareFileId { get; set; }
    //课程目录编码 String indexCd;
       /// <summary>
       /// 课程目录编码
       /// </summary>
       public string IndexCd { get; set; }
    //备课明细名称String preInfoName;
       /// <summary>
       /// 备课明细名称
       /// </summary>
       public string PreInfoName { get; set; }
    //备课时段，逗号分割 String periods;
       /// <summary>
       /// 备课时段，逗号分割
       /// </summary>
       public string Periods { get; set; }
    //荐级别Integer recomLevel;
       /// <summary>
       /// 推荐级别
       /// </summary>
       public int RecomLevel { get; set; }
    // 集备状态Integer referenceType;
       /// <summary>
       /// 集备状态
       /// </summary>
       public int ReferenceType { get; set; }
    //学校ID String schoolId;
       /// <summary>
       /// 学校ID
       /// </summary>
       public string SchoolId { get; set; }
    //单位类型 String orgType;
       /// <summary>
       /// 单位类型
       /// </summary>
       public string OrgType { get; set; }
    // 作者 String writer;
       /// <summary>
       /// 作者
       /// </summary>
       public string Writer { get; set; }
    // * 创建时间 Date crtDttm;
       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime CrtDttm { get; set; }
    // 最后修改时间 Date lastupDttm;
       /// <summary>
       /// 最后修改时间
       /// </summary>
       public DateTime LastupDttm { get; set; }
    //分享标识 Integer shareFlg;
       /// <summary>
       /// 分享标识
       /// </summary>
       public int ShareFlg { get; set; }
    //分享时间 Date shareDttm;
       /// <summary>
       /// 分享时间
       /// </summary>
       public DateTime ShareDttm { get; set; }
    //导学案个数 Integer learnGuideNum;
       /// <summary>
       /// 导学案个数
       /// </summary>
       public int LearnGuideNum { get; set; }
    //教学设计个数 Integer teachDesignNum;
       /// <summary>
       /// 教学设计个数
       /// </summary>
       public int TeachDesignNum { get; set; }
    //课件个数 Integer courseWareNum ;
       /// <summary>
       /// 课件个数
       /// </summary>
       public int CourseWareNum { get; set; }
    //检测习题个数	 Integer testPaperNum;
       /// <summary>
       /// 检测习题个数
       /// </summary>
       public int TestPaperNum { get; set; }
    //微课视频个数 Integer minVideoNum;
       /// <summary>
       /// 微课视频个数
       /// </summary>
       public int MinVideoNum { get; set; }
    //教学反思个数 Integer teachThinkNum;
       /// <summary>
       /// 教学反思个数
       /// </summary>
       public int TeachThinkNum { get; set; }
    // 是否收藏 Integer isCollect;
       /// <summary>
       /// 是否收藏
       /// </summary>
       public int IsCollect { get; set; }
	
    // 学年 Integer schoolYear;
       /// <summary>
       /// 学年
       /// </summary>
       public int SchoolYear { get; set; }
    }

}
