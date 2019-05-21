<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DutyLogEdit.aspx.cs" Inherits="GKICMP.office.DutyLogEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <link href="../css/green_formcss.css" rel="stylesheet" />
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <link href="../css/easyui.css" rel="stylesheet" />
    <link href="../css/demo.css" rel="stylesheet" />
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
    <script type="text/javascript" src="https://api.map.baidu.com/api?v=2.0&ak=A63e90def3d0f5488ab9032056429a0d"></script>
    <script type="text/javascript" src="https://api.map.baidu.com/library/DrawingManager/1.4/src/DrawingManager_min.js"></script>
    <script src="../utf8-net/ueditor.config.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajaxSettings.async = false;
            var url = "../ashx/GetBaseDate.ashx?method=GetUser&data=js";
            $.getJSON(url, function (data) { $('#Series').combotree({ data: data.data, multiple: true, multiline: true, }); });
            jQuery("#form1").Validform();
        });
        function setValue() {
            //var val = $('#Series').combotree('getValues');             获取包含上级id的集合
            //document.getElementById("hf_TID").value = val;
            var U = new Array();                                                                                     //获取选中的不包含上级id的集合
            $($("#Series").combotree("tree").tree("getChecked")).each(function () {
                if (this.children == null && $("#Series").combotree("tree").tree("find", this.id) != null) {
                    U.push(this.id);
                    document.getElementById("hf_TID").value = U;
                }
            });

        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Literal ID="ltl_Content" runat="server"></asp:Literal>
        <asp:Literal ID="ltl_xz" runat="server"></asp:Literal>
        <asp:HiddenField ID="hf_TID" runat="server" />
        <div class="listcent pad0">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="listinfo">
                <tbody>
                    <tr>
                        <th colspan="4" align="left">值班日志</th>
                    </tr>
                    <tr>
                        <td align="right" width="120">值班人员：</td>
                        <td align="left" colspan="3">
                            <input id="Series" name="Series" style="width: 85%;" class="easyui-combotree" />
                            <span style="color: Red; float: none">*</span>
                            <%--<asp:TextBox ID="Series"  runat="server" name="Series"  url="../ashx/Tea.ashx?method=TeaL" CssClass="easyui-combotree"    Width="70%"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">天气：</td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txt_Weather" runat="server" Width="400" datatype="*" nullmsg="请填写天气"></asp:TextBox>
                            <span style="color: Red; float: none">*</span></td>
                    </tr>
                    <tr>
                        <td align="right" width="120">学年度：</td>
                        <td align="left">
                            <asp:TextBox ID="txt_SYear" runat="server" Width="200" datatype="*" nullmsg="请填写学年度"></asp:TextBox>
                            <span style="color: Red; float: none">*</span>
                        </td>
                        <td align="right" width="120">学期：</td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddl_Term" datatype="ddl" errormsg="请选择学期信息"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="120">值班日志内容：</td>
                        <td align="left" colspan="5" style="line-height: 20px;">
                            <asp:TextBox ID="txt_Content" runat="server" Width="100%" Height="400px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" OnClientClick='setValue()' />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
    <script type="text/javascript">

        //实例化编辑器
        //建议使用工厂方法getEditor创建和引用编辑器实例，如果在某个闭包下引用该编辑器，直接调用UE.getEditor('editor')就能拿到相关的实例
        var ue = UE.getEditor('txt_Content');

    </script>
    <script type="text/javascript">
        //用百度地图API获得当前所在城市
        var map = new BMap.Map('map');
        var myCity = new BMap.LocalCity();
        var cityName;
        myCity.get(myFun); //异步获得当前城市
        function myFun(result) {
            cityName = result.name.replace('市', '');
        }

        //动态创建script标签
        function jsonp(url) {
            var script = document.createElement('script');
            script.src = url;
            document.body.append(script);
            document.body.removeChild(script);
        }

        //设置延时，因为获得当前城市所在地是异步的
        setTimeout(function () {
            var urls = [];
            urls[0] = 'https://sapi.k780.com/?app=weather.future&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=json&jsoncallback=getWeather_week&weaid=' + encodeURI(cityName);
            urls[1] = 'https://api.map.baidu.com/telematics/v3/weather?output=json&ak=FK9mkfdQsloEngodbFl4FeY3&callback=getTodayWeather&location=' + encodeURI(cityName);
            jsonp(urls[0]);  //jsonp跨域请求
            jsonp(urls[1]);
        }, 1000);

        //获得这一周的天气， 解析json数据，写入DOM
        function getWeather_week(response) {
            var result = response.result;
            var doc = document;
            var item = doc.querySelectorAll('.item');
            var i = 0;

            for (var index in result) {

                if (i == 0) {
                    document.getElementById("txt_Weather").value = result[index].weather + ' 温度：' + result[index].temperature + ' 风力：' + result[index].winp;
                    //$("#txt_Weather").attr("value", result[index].weather + ' 温度：' + result[index].temperature + ' 风力：' + result[index].winp);
                }
                i++;
            }
        }

    </script>
</body>
</html>

