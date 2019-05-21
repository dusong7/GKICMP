 

using System;

namespace GK.GKICMP.Entities{  
        
    /// <summary>
    /// 接收普通消息
    /// </summary>
    public abstract class Receive_Msg
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 当前实体的XML字符串
        /// </summary>
        public string Xml { get; set; }
    }

    /// <summary>
    /// 接收普通消息-文本消息
    /// </summary>
    public class Receive_Text:Receive_Msg
    {
			
        /// <summary>
        ///  文本消息内容
        /// </summary>
        public string Content{get;set;}
			
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public string MsgId{get;set;}
    }

    /// <summary>
    /// 接收普通消息-图片消息
    /// </summary>
    public class Receive_Image:Receive_Msg
    {
			
        /// <summary>
        ///  图片链接
        /// </summary>
        public string PicUrl{get;set;}
			
        /// <summary>
        ///  图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId{get;set;}
			
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public string MsgId{get;set;}
    }

    /// <summary>
    /// 接收普通消息-语音消息
    /// </summary>
    public class Receive_Voice:Receive_Msg
    {
			
        /// <summary>
        ///  语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId{get;set;}
			
        /// <summary>
        ///  语音格式，如amr，speex等
        /// </summary>
        public string Format{get;set;}
			
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public string MsgID{get;set;}
    }

    /// <summary>
    /// 接收普通消息-视频消息
    /// </summary>
    public class Receive_Video:Receive_Msg
    {
			
        /// <summary>
        ///  视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId{get;set;}
			
        /// <summary>
        ///  视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId{get;set;}
			
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public string MsgId{get;set;}
    }

    /// <summary>
    /// 接收普通消息-地理位置消息
    /// </summary>
    public class Receive_Location:Receive_Msg
    {
			
        /// <summary>
        ///  地理位置维度
        /// </summary>
        public string Location_X{get;set;}
			
        /// <summary>
        ///  地理位置经度
        /// </summary>
        public string Location_Y{get;set;}
			
        /// <summary>
        ///  地图缩放大小
        /// </summary>
        public string Scale{get;set;}
			
        /// <summary>
        ///  地理位置信息
        /// </summary>
        public string Label{get;set;}
			
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public string MsgId{get;set;}
    }

    /// <summary>
    /// 接收普通消息-链接消息
    /// </summary>
    public class Receive_Link:Receive_Msg
    {
			
        /// <summary>
        ///  消息标题
        /// </summary>
        public string Title{get;set;}
			
        /// <summary>
        ///  消息描述
        /// </summary>
        public string Description{get;set;}
			
        /// <summary>
        ///  消息链接
        /// </summary>
        public string Url{get;set;}
			
        /// <summary>
        ///  消息id，64位整型
        /// </summary>
        public string MsgId{get;set;}
    }
    
    
    /// <summary>
    /// 接收事件推送-关注/取消关注事件
    /// </summary>
    public class Receive_Event:Receive_Msg
    {
			
        /// <summary>
        ///  事件类型，subscribe(订阅)、unsubscribe(取消订阅)
        /// </summary>
        public string Event{get;set;}
    }

    /// <summary>
    /// 接收事件推送-扫描带参数二维码事件
    /// </summary>
    public class Receive_Event_Scan:Receive_Msg
    {
			
        /// <summary>
        ///  事件类型，SCAN
        /// </summary>
        public string Event{get;set;}
			
        /// <summary>
        ///  事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id
        /// </summary>
        public string EventKey{get;set;}
			
        /// <summary>
        ///  二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket{get;set;}
    }

    /// <summary>
    /// 接收事件推送-上报地理位置事件
    /// </summary>
    public class Receive_Event_Location:Receive_Msg
    {
			
        /// <summary>
        ///  事件类型，LOCATION
        /// </summary>
        public string Event{get;set;}
			
        /// <summary>
        ///  地理位置纬度
        /// </summary>
        public string Latitude{get;set;}
			
        /// <summary>
        ///  地理位置经度
        /// </summary>
        public string Longitude{get;set;}
			
        /// <summary>
        ///  地理位置精度
        /// </summary>
        public string Precision{get;set;}
    }

    /// <summary>
    /// 接收事件推送-自定义菜单事件
    /// </summary>
    public class Receive_Event_Click:Receive_Msg
    {
			
        /// <summary>
        ///  事件类型，CLICK
        /// </summary>
        public string Event{get;set;}
			
        /// <summary>
        ///  事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey{get;set;}
    }

    /// <summary>
    /// 接收事件推送-点击菜单跳转链接时的事件推送
    /// </summary>
    public class Receive_Event_View:Receive_Msg
    {
			
        /// <summary>
        ///  事件类型，VIEW
        /// </summary>
        public string Event{get;set;}
			
        /// <summary>
        ///  事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey{get;set;}
    }
    
    

    
    /// <summary>
    /// 发送被动响应消息
    /// </summary>
    public abstract class Send_Msg
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }
    }

    /// <summary>
    /// 发送被动响应消息-回复文本消息
    /// </summary>
    public class Send_Text:Send_Msg
    {
			
        /// <summary>
        ///  回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）
        /// 是否必须： 是
        /// </summary>
        public string Content{get;set;}
    }

    /// <summary>
    /// 发送被动响应消息-回复图片消息
    /// </summary>
    public class Send_Image:Send_Msg
    {
			
        /// <summary>
        ///  通过上传多媒体文件，得到的id。
        /// 是否必须： 是
        /// </summary>
        public string MediaId{get;set;}
    }

    /// <summary>
    /// 发送被动响应消息-回复语音消息
    /// </summary>
    public class Send_Voice:Send_Msg
    {
			
        /// <summary>
        ///  通过上传多媒体文件，得到的id
        /// 是否必须： 是
        /// </summary>
        public string MediaId{get;set;}
    }

    /// <summary>
    /// 发送被动响应消息-回复视频消息
    /// </summary>
    public class Send_Video:Send_Msg
    {
			
        /// <summary>
        ///  通过上传多媒体文件，得到的id
        /// 是否必须： 是
        /// </summary>
        public string MediaId{get;set;}
			
        /// <summary>
        ///  视频消息的标题
        /// 是否必须： 否
        /// </summary>
        public string Title{get;set;}
			
        /// <summary>
        ///  视频消息的描述
        /// 是否必须： 否
        /// </summary>
        public string Description{get;set;}
    }

    /// <summary>
    /// 发送被动响应消息-回复音乐消息
    /// </summary>
    public class Send_Music:Send_Msg
    {
			
        /// <summary>
        ///  音乐标题
        /// 是否必须： 否
        /// </summary>
        public string Title{get;set;}
			
        /// <summary>
        ///  音乐描述
        /// 是否必须： 否
        /// </summary>
        public string Description{get;set;}
			
        /// <summary>
        ///  音乐链接
        /// 是否必须： 否
        /// </summary>
        public string MusicURL{get;set;}
			
        /// <summary>
        ///  高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// 是否必须： 否
        /// </summary>
        public string HQMusicUrl{get;set;}
			
        /// <summary>
        ///  缩略图的媒体id，通过上传多媒体文件，得到的id
        /// 是否必须： 是
        /// </summary>
        public string ThumbMediaId{get;set;}
    }

    /// <summary>
    /// 发送被动响应消息-回复图文消息
    /// </summary>
    public class Send_News:Send_Msg
    {
			
        /// <summary>
        ///  图文消息个数，限制为10条以内
        /// 是否必须： 是
        /// </summary>
        public string ArticleCount{get;set;}
			
        /// <summary>
        ///  多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// 是否必须： 是
        /// </summary>
        public string Articles{get;set;}
			
        /// <summary>
        ///  图文消息标题
        /// 是否必须： 否
        /// </summary>
        public string Title{get;set;}
			
        /// <summary>
        ///  图文消息描述
        /// 是否必须： 否
        /// </summary>
        public string Description{get;set;}
			
        /// <summary>
        ///  图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// 是否必须： 否
        /// </summary>
        public string PicUrl{get;set;}
			
        /// <summary>
        ///  点击图文消息跳转链接
        /// 是否必须： 否
        /// </summary>
        public string Url{get;set;}
    }
    
}
