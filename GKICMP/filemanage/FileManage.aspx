<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileManage.aspx.cs" Inherits="GKICMP.filemanage.FileManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>智慧校园平台</title>
    <%-- <link href="../css/green_list.css" rel="stylesheet" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />--%>
    <link href="../css/zycss.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#btn_Add').click(function () {
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', 'FileEdit.aspx', '', 960, 400, -1);
            });
        });
        function editinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', 'FileEdit.aspx', 'id=' + id, 960, 400, 0);
        }
        function AddNew()
        {
            //alert(1);
            var a = '<%=PID%>';
            $("#addNew").remove();
            $("#new").prepend(" <li  id='addNew'><span><img src='../images/zy.png'></span><span><h6><input id='FileNmae' type='text' style='width:60px' onBlur='AddFile(this)' /></h6></span></li>");
            $("#FileNmae").focus();
        }
        function AddFile(e)
        {
            //alert(e.value);
            if (e.value != "") {
                $.ajax({
                    //提交数据的类型 POST GET
                    type: "POST",
                    //提交的网址
                    url: "../ashx/AddFile.ashx",
                    //提交的数据
                    data: { method: "Add", Name: e.value, pid: "<%=PID%>" },
                    //返回数据的格式
                    datatype: "html",//"xml", "html", "script", "json", "jsonp", "text".
                    //在请求之前调用的函数
                    //beforeSend: function () { $("#msg").html("logining"); },
                    //成功返回之后调用的函数             
                    success: function (data) {
                        //alert("success");
                        location.reload();
                    },
                    //调用执行后调用的函数
                    //complete: function (XMLHttpRequest, textStatus) {
                    //    alert(XMLHttpRequest.responseText);
                    //    alert(textStatus);
                    //    //HideLoading();
                    //},
                    //调用出错执行的函数
                    error: function () {
                        //请求出错处理
                        alert("error");
                    }
                });
            }
            else
            {
                $("#addNew").remove();
            }
        }
        var uploading = false;

       
        //function aa()
        //{
        //    $("#FileUpload").click();
        //}
        function uploadFile(filePath) {
            if (filePath.length > 0) {
                __doPostBack('btnUploadFile', '');
               // $("#btnUploadFile").click();
                formReset();
            }
        }
        function formReset() {
            document.getElementById("form1").reset()
        }
        function skip()
        {
            var a = document.getElementById("hf_PID").value;
            window.location.href = "FileManage.aspx?id=" + a;
        }
        function rename()
        {
            var a = document.getElementById("hf_FBID").value;
            var c = $("#18").val();
            document.getElementById("hf_FileName").value = $("#" + a).val();
            var b = document.getElementById("hf_FileName").value
            //$("#" + a).attr("");
            $("#" + a).css('display', 'block');
            $("#" + a).next().hide();
            $("#"+a).focus();
        }
        function UpdateFile(e)
        {
            //alert(e.value);
            //AddFile(e);
            var a = document.getElementById("hf_FileName").value
            var b = document.getElementById("hf_FBID").value
            var c = e.value;
            if (e.value == a || e.value == "") { location.reload(); }
            else
            {
                $.ajax({
                    //提交数据的类型 POST GET
                    type: "POST",
                    //提交的网址
                    url: "../ashx/AddFile.ashx",
                    cache: false,
                    //提交的数据
                    data: { method: "Update", Name: c, fbid: b ,OName:a,pid: "<%=PID%>" },
                     //返回数据的格式
                    dataType: "json",//"xml", "html", "script", "json", "jsonp", "text".
                     //在请求之前调用的函数
                     //beforeSend: function () { $("#msg").html("logining"); },
                     //成功返回之后调用的函数             
                    success: function (data) {
                        //alert("success");
                        var a = data.result;
                        if (data.result!= "success")
                        {
                            alert(data.result);
                            $("#" + b).focus();
                        }
                        else {
                            location.reload();
                        }
                    },
                     //调用执行后调用的函数
                     //complete: function (XMLHttpRequest, textStatus) {
                     //    alert(XMLHttpRequest.responseText);
                     //    alert(textStatus);
                     //    //HideLoading();
                     //},
                     //调用出错执行的函数
                    error: function () {
                        //请求出错处理
                        alert("error");
                    }
                 });
            }
            //$("#" + b).css('display', 'none');
            //document.getElementById("hf_PID").value = "";
            //document.getElementById("hf_FileName").value = "";
            //$("#" + b).next().show();
        }
    </script>
    <style>
        body, ul, li, div {
            margin: 0px;
            padding: 0px;
            box-sizing: border-box;
        }

        a {
            color: #5E5E5E;
            text-decoration: none;
        }

        ul, li {
            list-style: none;
        }

        .filelist li {
            float: left;
            height: 60px;
            width: 200px;
            margin-top: 15px;
        }

            .filelist li span {
                float: left;
                margin-left: 5px;
            }

             .filelist li span span span{white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    width: 135px;
    margin-left: 0px;}


        h6, h5 {
            margin: 0px;
            padding: 0px;
            line-height: 1.5;
            width: 135px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        h6 {
            color: #6C6C6C;
        }

        .filelist img {
            width: 50px; float:left
        }

        .filebtn {
            border-bottom: 1px solid #c9cdd5;
            background: #f5f7f9;
            height: 40px;
        }

            .filebtn span {
                display: block;
                float: left;
                border: 1px solid #c9cdd5;
                background: #fff;
                height: 24px;
                line-height: 24px;
                margin-top: 7px;
                padding: 0px 5px;
                font-size: 12px;
                padding-left: 25px;
                margin-left: 5px;
            }

            .filebtn .addzy {
                background: url(../images/adzy.png) 5px center no-repeat;
            }
            .filebtn .addfh {
                background: url(../images/fh.png) 5px center no-repeat;
            }
            .filebtn .uploadzy {
                background: url(../images/upload.png) 5px center no-repeat;
            }

        .myMenu {
            border: 1px solid #D8D8D8;
            background: #fff;
            padding: 10px 0px;
            box-shadow: #939393 3px 3px 3px;
        }

            .myMenu li {
                border-bottom: 1px dashed #DDDDDD;
                width: 150px;
                text-indent: 20px;
                line-height: 30px;
            }

                .myMenu li:hover {
                    background: #5FB878;
                }

                .myMenu li a {
                    display: block;
                }

                .myMenu li:hover a {
                    color: #fff;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_FBID" runat="server" />
        <asp:HiddenField ID="hf_PID" runat="server" />
        <asp:HiddenField ID="hf_File" runat="server" />
        <asp:HiddenField ID="hf_FileName" runat="server" />
        <div class="filebtn">
             <span class="addfh" <%=PID.ToString()=="-1"? "style='display:none'" :""%>  >
                <%--<asp:LinkButton ID="lbtn_New" runat="server" OnClientClick="AddNew()">新建文件夹</asp:LinkButton>--%>
                <a href="javascript:;" onclick="skip()">返回上一级</a>
            </span>
            <span class="addzy">
                <%--<asp:LinkButton ID="lbtn_New" runat="server" OnClientClick="AddNew()">新建文件夹</asp:LinkButton>--%>
                <a href="javascript:;" onclick="AddNew()">新建文件夹</a>
            </span>
            <span class="uploadzy">
                 <%--<button type="button" onclick="document.getElementById('FileUpload').click();">上传</button>--%>  
                <%--<asp:LinkButton ID="lbtn_Up"  onclick="document.getElementById('FileUpload').click();">上传</asp:LinkButton>--%>
                 <a href="javascript:;" onclick="document.getElementById('FileUpload').click();">上传</a>
               <%-- <input id="FileUp" type="file"  />--%>
                <asp:FileUpload ID="FileUpload" runat="server" Style="display:none"  onchange="uploadFile(this.value)"  />
                <asp:LinkButton ID="btnUploadFile" runat="server" onclick="btnUploadFile_Click" Style="display:none">上传</asp:LinkButton>
           
            </span>
        </div>
        <div class="filelist">
            
            <ul id="new">
                
                <asp:Repeater runat="server" ID="rp_List">
                    <ItemTemplate>
                        <li oncontextmenu='<%#Eval("FFlag").ToString()=="1"?"mymenu("+Eval("fbid")+")":"filename("+Eval("fbid")+")"%>' ondblclick="<%#Eval("FFlag").ToString()=="1"?"dbmymenu("+Eval("fbid")+")":"dbfilename("+Eval("fbid")+")"%>" title='文件名:<%#Eval("FBName")%>&#10;上传人:<%#Eval("CreateUserName")%>&#10;上传时间:<%#Eval("CreateDate")%>'>
                            <span>
                                <img src='<%#GetPic(int.Parse(Eval("FFlag").ToString()),Eval("RFormat").ToString()) %>'</span>
                            <span>
                                <h5>
                                    <input id='<%#Eval("FBID")%>' style="display:none ;" type="text" value='<%#Eval("FBName")%>' onblur="UpdateFile(this)"/>
                                   <span> <%#Eval("FBName")%></span></h5>
                                <h6><%#Eval("CreateUserName")%></h6>
                            </span>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>

        <ul id="filename" class="myMenu" style="position: absolute; visibility: hidden;">
            <li>
               <%-- <a href="javascript:;" id="add_class">下载</a>--%>
               <%-- <asp:Button ID="btn_Down" runat="server" Text="下载" OnClick="btn_Down_Click" />--%>
                 <asp:LinkButton ID="ltbn_Down" runat="server" OnClick="btn_Down_Click">下载</asp:LinkButton>
            </li>
            <li>
               <%-- <a href="javascript:;" id="edi_class">删除</a>--%>
                 <%--<asp:Button ID="btn_Delete" runat="server" Text="删除" OnClick="btn_Delete_Click" />--%>
                 <asp:LinkButton ID="lbtn_Delete" runat="server" OnClick="btn_Delete_Click">删除</asp:LinkButton>
            </li>
            <li>
                <%--<a href="javascript:;">刷新</a>--%>
               <%-- <asp:Button ID="btn_Reload" runat="server" Text="刷新" OnClick="btn_Reload_Click" />--%>
                 <asp:LinkButton ID="lbtn_Reload" runat="server" OnClick="btn_Reload_Click">刷新</asp:LinkButton>
            </li>
        </ul>

        <ul id="folder" class="myMenu" style="position: absolute; visibility: hidden;">
            <li>
               <%-- <a href="javascript:;" id="add_class1">上传文件</a>--%>
              <%--  <asp:LinkButton ID="lbtn_Upload" runat="server" OnClientClick="aa()">上传文件</asp:LinkButton>--%>
                 <a href="javascript:;" onclick="document.getElementById('FileUpload').click();">上传文件</a>
            </li>
            <li>
               <%-- <a href="javascript:;" id="add_class1">上传文件</a>--%>
              <%--  <asp:LinkButton ID="lbtn_Upload" runat="server" OnClientClick="aa()">上传文件</asp:LinkButton>--%>
                 <a href="javascript:;" onclick="rename()">重命名</a>
            </li>
            <li>
               <%-- <a href="javascript:;" id="getdel">删除</a>--%>
             <%--   <asp:Button ID="Button2" runat="server" Text="删除" OnClick="btn_Delete_Click" />--%>
                <asp:LinkButton ID="lbtn_Deleted" runat="server" OnClick="btn_Delete_Click">删除</asp:LinkButton>
            </li>
            <li>
               <%-- <a href="javascript:;">刷新</a>--%>
               <%-- <asp:Button ID="Button1" runat="server" Text="刷新" OnClick="btn_Reload_Click" />--%>
                <asp:LinkButton ID="lbtn_Reloadd" runat="server" OnClick="btn_Reload_Click">刷新</asp:LinkButton>
            </li>
        </ul>

        <script type="text/javascript">
            document.oncontextmenu = new Function("event.returnValue=false;");
            document.onselectstart = new Function("event.returnValue=false;");

            function mymenu(divid) {        //设置文件夹右键菜单的位置以及显示出来
                event.preventDefault = false;
                var menu = document.getElementById("folder");
                menu.style.left = event.clientX + "px";
                menu.style.top = event.clientY + "px";
                menu.style.visibility = "visible";
                document.getElementById("hf_FBID").value = divid;
                document.getElementById("filename").style.visibility = "hidden";
                document.onclick = function (event) {
                    //当左键点击的时候隐藏右键菜单
                    document.getElementById("folder").style.visibility = "hidden";

                }
            }
            function dbmymenu(divid) {
                //文件夹双击效果
               // document.getElementById("hf_PID").value = pid;
                // window.open('FileManage?id=' + pid, 'newwindow', 'height=100, width=400, top=0, left=0, toolbar=no,menubar=no, scrollbars=no,resizable=no,location=n o, status=no')
                window.location.href = "FileManage.aspx?id=" + divid;
            }
            function filename(divid) {        //设置文件右键菜单的位置以及显示出来
                event.preventDefault = false;
                var menu = document.getElementById("filename");
                menu.style.left = event.clientX + "px";
                menu.style.top = event.clientY + "px";
                menu.style.visibility = "visible";
                document.getElementById("hf_FBID").value = divid;
                document.getElementById("folder").style.visibility = "hidden";
                document.onclick = function (event) {
                    //当左键点击的时候隐藏右键菜单
                    document.getElementById("filename").style.visibility = "hidden";
                }
            }

            function dbfilename(divid) {        //文件双击效果
            }
        </script>

    </form>
</body>
</html>

