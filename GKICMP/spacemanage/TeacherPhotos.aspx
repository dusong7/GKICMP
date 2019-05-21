<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPhotos.aspx.cs" Inherits="GKICMP.spacemanage.TeacherPhotos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>智慧校园管理平台</title>
    <link href="../css/zstyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/green_asyncbox.css" rel="stylesheet" />
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/AsyncBox.v1.4.js"></script>
    <script src="../js/AsyncBox.v1.4.5.js"></script>
    <script src="../js/choice.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#btn_Upload').click(function () {
                var claid = document.getElementById("hf_ClaID").value;
                //box的ID，Url,data传值，宽，高,Type(-1为添加，0为修改,其他为查看)
                return openbox('A_id', '../office/HomeWorkEdit.aspx', '', 1040, 480, -1);
            });
        });

        function viewinfo(e) {
            var id = $(e).next().val();
            return openbox('A_id', '../office/HomeWorkDetail.aspx', 'id=' + id, 750, 290, 1);
        }

        function editinfo(e) {
            var id = $(e).next().next().next().val();
            return openbox('A_id', '../office/HomeWorkEdit.aspx', 'id=' + id, 910, 400, 0);
        }
    </script>
    <style>
        .zyadd {
            width: 100%;
            padding: 5px;
        }

            .zyadd li {
                margin: 5px;
                padding: 5px;
            }

                .zyadd li a:first-child span {
                    float: right !important;
                    display: inline;
                    width: auto;
                    background: none;
                }

                    .zyadd li a:first-child span.flnone {
                        float: none !important;
                        font-size: 14px;
                    }

                .zyadd li a {
                    display: block;
                }

        .listb {
            height: 25px;
            line-height: 25px;
        }

            .listb span a {
                color: #25b782;
                display: inline-block;
                background: none !important;
            }

            .listb span:nth-child(1) {
                float: left;
                color: #ff8400;
            }

            .listb span:nth-child(2) {
                float: right;
                color: #ff8400;
            }

        .classtopright li span:first-child {
            float: none;
        }

        .classtopright li {
            height: auto;
        }

        .listb span {
            float: right !important;
            width: auto !important;
            background: none !important;
            margin-top: 0px !important;
        }

            .listb span:first-child {
                float: left !important;
            }

        .classtopright {
            height: auto;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
        <asp:HiddenField runat="server" ID="hf_UID" />
        <asp:HiddenField runat="server" ID="hf_ClaID" />
        <div class="menucs">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassHome" Text="个人主页" OnClick="lbtn_ClassHome_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassCul" Text="我的日志" OnClick="lbtn_ClassCul_Click"></asp:LinkButton></li>
                <li class="selected">
                    <asp:LinkButton runat="server" ID="lbtn_Studio" Text="教学工作室"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_Lesson" Text="协同备课" OnClick="lbtn_Lesson_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton runat="server" ID="lbtn_ClassSpace" Text="班级空间" OnClick="lbtn_ClassSpace_Click"></asp:LinkButton></li>
            </ul>
        </div>
        <div class="bancs gr">
            <div class="bancent">
                <div class="bantit">
                    <asp:Literal runat="server" ID="ltl_RealName"></asp:Literal>的教学工作室
                </div>
                <%--<div class="baninfo1">
                    <asp:Literal runat="server" ID="ltl_GradeName"></asp:Literal><asp:Literal runat="server" ID="ltl_ClassName"></asp:Literal>
                </div>--%>
            </div>
        </div>
        <div class="whlist">
            <asp:Button runat="server" ID="btn_Upload" Text="布置作业" CssClass="listupload" />
        </div>
        <div class="classcs">
            <div class="classtopright zyadd">
                <div class="righttit">作业布置</div>
                <ul>
                    <asp:Repeater runat="server" ID="rp_List">
                        <ItemTemplate>
                            <li>
                                <a href="#">【<%#Eval("CourseName") %>】<span class="flnone"><%#Eval("ClassName") %></span><span style="color: #747474; text-align: right;"><%#Eval("CreateDate","{0:yyyy-MM-dd}") %></span></a>
                                <a href="#">
                                    <span><span><%#Eval("HomeWork").ToString().Length>30?Eval("HomeWork").ToString().Substring(0,30):Eval("HomeWork") %></span></span>
                                </a>
                                <div class="listb">
                                    <span>
                                        <asp:LinkButton runat="server" ID="lbtn_ReadAll" OnClientClick='return viewinfo(this);'>作业查看>></asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField1" Value='<%#Eval("HWID") %>' runat="server" />
                                    </span>
                                    <span>
                                        <asp:LinkButton runat="server" ID="lbtn_Edit" Visible='<%#IsVisible(Eval("IsSend"),Eval("CreateUser")) %>' OnClientClick='return editinfo(this);'>编辑</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lbtn_Delete" OnClick="lbtn_Delete_Click" Visible='<%#IsVisible(Eval("IsSend"),Eval("CreateUser")) %>' CommandArgument='<%#Eval("HWID") %>'>删除</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="ltl_IsSend" Visible='<%#Eval("IsSend").ToString()=="1"?true:false %>'>已发送</asp:LinkButton>
                                        <asp:HiddenField ID="HiddenField2" Value='<%#Eval("HWID") %>' runat="server" />
                                    </span>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <li runat="server" id="li1" style="text-align: center; border-bottom: 1px dashed #eae3e3;">暂无记录</li>
                </ul>
                <div class="righttit" style="border-top: 1px solid #e0e0e0;">我的资源</div>
                <asp:Repeater ID="rp_ResList" runat="server">
                    <ItemTemplate>
                        <div class="listmre">
                            <div class="titname">
                                <img src='<%#GetPic(Eval("RFormat")) %>' class="zybs"><%#Eval("ResourseName") %>
                            </div>
                            <div class="infocss">
                                <span>资源分类：</span><span><%#GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.EType>(Eval("EType")) %></span><span>资源学科：</span><span><%# Eval("CIDName")%>资源</span>
                                <div style="float: left">
                                    <span><%#Eval("CreateDate","{0:yyyy.MM.dd}")%></span><span><%#GetSize(Eval("RSize"))%></span><span style="width: 100px;"><%#(Eval("CreateUserName"))%></span><span>（<%#(Eval("DownLoadNum"))%>）</span>
                                    <div style="clear: both"></div>
                                </div>
                                <div class="dowcss">
                                    <asp:LinkButton ID="lbtn_DownLoad" runat="server" CommandArgument='<%#Eval ("Erid") %>' CommandName='<%#Eval("ResourseName") %>' OnClick="lbtn_DownLoad_Click"><img src="../images/zy_19.png" /></asp:LinkButton>
                                </div>
                                <div style="clear: both"></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div runat="server" id="tr_null" style="text-align: center">
                    暂无记录                                              
                </div>
                <div class="listmre" style="border: none; text-align: right">
                    <div class="titname" style="font-size: 14PX;">
                        <wuc:Pager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged" />
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </form>
</body>
</html>
