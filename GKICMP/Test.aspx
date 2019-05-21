<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="GKICMP.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Label ID="lbl_URL" runat="server" Text="请输入网址："></asp:Label>
        <asp:TextBox ID="txt_URL" runat="server"></asp:TextBox>

     <asp:Label ID="lbl_KeyWord" runat="server" Text="关键字："></asp:Label>
        <asp:TextBox ID="txt_KeyWord" runat="server"></asp:TextBox><asp:Button ID="btn_Serach" runat="server" Text="查询" OnClick="btn_Serach_Click" />
    </div>
        <asp:Button runat="server" ID="btn_DownLoad" Text="下载" OnClick="btn_DownLoad_Click" />
    </form>
</body>
    <script type="text/javascript">
        var poweroff = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABBCAIAAACo4ZaGAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA2FJREFUeNrsl+ttAjEQhCOUBqAEKAFKgBKgBCgBSoASoAQoAUqAEqAEKIF8YqSVZd+dUHJRFGnmB3L21uvd2Yedjw/DMAzDMAzDMAzDMAzDMAzDMAzDMAzDMP4zhsNhJplOp8vlUutut7vf7/v9fqZzPB5DR0AH5bpT5vP5drtdr9fsqlTj0/l8Lg+K7eEn/pQ+v4/PN/Wy8BQhfgwGg9vtFsLD4YDfODSbzSBuPB43sIBNdNiCncfjMRqNKtWwj+ZkMhEji8Ui84e9nIhEnmgR1qByt9tdLhflkk9QhmSz2fwWWaVpiCDIlKnQpBDkNIHhJZqn0ynVgUFFS5zoZwpl3SlOdETrarVijWXCxgEkUMkaUyiTPyRRVqxRhjJ2aQ04Ar5Crf3KaraOl8SjNWFQBYSBEC9JO+xQQZDCWsHjcV3jpInRXmLOshWV0uv1+Epr314QKZES/qTGcR47jxciwaXN1vB8Pjl4nAAPEFYq87XuEwHwiSpQcRFkOcXYfr/fkVChKBOVrLGLHGReyQis8Yld6bnoI8EIvxoIaLLQEZHa99F5X7Usq7IHKwHLBBxEqF6u12vDrCUw0k4xag5qC3u1Tq8Xfqky1YvKLUCJ0Z6QolpDR5UOv+nUb78NVfnpZGGdljFpDF/FCHTQuWI5xrzyiRwJrmezLCtPxaP2IUhtTHMgFsQjnzS/qCNmJbSyxiuO4CzORQFNdSt81d0n7bShKCjfAaUQmoikrB3YIRL6RU0X3adFPCDUhrpAiBaJ+jEb/Oo4jkAZLtDREIxO1KBAzldZRoJX6s1vkND5OY/ZnNZriKIjk/iUPh10P6qdkWeXICGJXIRKOzooYyTyhILoi+qDaN0VfMpeW/iAHU6klNSDWOOXokMIa7/VhnrLlJNF+Y8LaPkCk0JvAjwjADwTKXoiaX7xq+s/TAWtxM92QuIrRtRKuukQpoOSNQqo6TgU0tzEk1imcExTT6+Quru4BbKIU9nL5NCkoav7Ee/TZw67qAuCx1eu8IhTDwg4jfGn2tFYxKaeKUSl15OO0OQqyUqTl44FDTi9qjCFcWULI2l5/gE0dOr+K0oTTk01v+wb/p2K26Pynwp9rZyt5eio3G4YhmEYhmEYhmEYhmEYhmEYhmEYhmEYf4EvAQYAVk3FQ8C/kbkAAAAASUVORK5CYII=";
        //var websocket = new WebSocket("ws://"+window.location.hostname+":3030");
        //websocket.onmessage = function (d) {
        //    var obj = JSON.parse(d.data);
        //    $.each(obj, function (n, value) {
        //        $("#socket").text($("#" + value.guid).length + ",设备："+value.sguid);
        //        if ($("#" + value.guid).length > 0) {
        //            $("#" + value.guid).attr("src", "data:image/png;base64," + value.image);
        //        }
        //    }); 
        //}
        //websocket.onerror = function (evt) {
        //    $("#socket").text("连接错误");
        //}
        //websocket.onclose = function (evt) {
        //    $(".bbtcomputer li img").attr("src", "data:image/png;base64," + poweroff);
        //}
        //websocket.onopen = function (evt) { $("#socket").text("已连接"); }
        function refreshcomputer() {
            var I = $(".bbtcomputer li img");
            $.get("/Dj/GetScreenPic?tmp=" + Math.random() + "", function (d) {
                $.each(d, function (n, value) {
                    if ($("#" + value.Mac).length > 0) {
                        $("#" + value.Mac).attr("src", "data:image/png;base64," + value.Img);
                        I = I.not("#" + value.Mac);
                    }
                }); $("#S").html($(".bbtcomputer li img").length - I.length);
                I.attr("src", poweroff);
            });
            //alert(I.length);
        }
        $(document).ready(function () {
            window.setInterval(refreshcomputer, 5000);
        });
        $(".bbtcomputer li img").click(function () {
            var o = this;
            $(this).clone().dialog({
                width: 600,
                modal: true,
                onClose: function () { $(this).dialog("destroy"); }
            });
        });
        refreshcomputer();
</script>

</html>
