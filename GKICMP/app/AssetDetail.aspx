<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetDetail.aspx.cs" Inherits="GKICMP.app.AssetDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>资产详情</title>
    <link href="../appcss/mui.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../appcss/iconfont.css" />
    <link href="../appcss/new_file.css" rel="stylesheet" />
    <style>
        .infospan {
            display: inline-block;
            padding: 11px;
            padding-left: 0px;
        }
        .spanmore{ padding:5px 15px 10px 15px;display:inline-block}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mui-content">

            <%--<ul class="mui-table-view">
                <li class="mui-table-view-cell margin10">
                    <span>
                        <div class="mui-table">
                            <div class="mui-table-cell mui-col-xs-10" style="text-align: left">

                                <h5 class="mui-ellipsis color-2 mui-ellipsis">资产编号:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">名称:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">分类:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">规格型号:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">品牌:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">供应商:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">计量单位:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">购置时间:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">计划使用年限:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">采购人:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">所属校区:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">物品描述:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                                <h5 class="mui-ellipsis color-2 mui-ellipsis">物品图片:<span class="color-0" style="color: #47AE6F; font-size: 20px"></span></h5>
                            </div>
                        </div>
                    </span>
                </li>

            </ul>--%>
            <div class="mui-content-padded w100">
                <div class="mui-input-group linght40">
                    <div class="mui-input-row">
                        <label>资产编号</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_DataDesc" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>名称</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_AssetName" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>分类</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_DataType" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>规格型号</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_SpecificationModel" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>品牌</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_Brand" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>供应商</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_Suppliers" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>计量单位</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_AUnit" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>购置时间</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_BuyDate" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>计划使用年限</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_PlanYear" runat="server"></asp:Literal>(年)</span>
                    </div>
                    <div class="mui-input-row">
                        <label>采购人</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_BuyUser" runat="server"></asp:Literal></span>
                    </div>
                    <div class="mui-input-row">
                        <label>所属校区</label>
                        <span class="infospan">
                            <asp:Literal ID="ltl_CID" runat="server"></asp:Literal></span>
                    </div>

                    <div class="textarea-div">
                        <div class="mui-input-group hybt linght40">
                            <p>物品描述</p>
                            <span class="spanmore"><asp:Literal ID="ltl_AssetMark" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                     <div class="textarea-div">
                        <div class="mui-input-group hybt linght40">
                            <p>物品图片</p>
                           <asp:Image ID="imgs" runat="server" Width="200" Height="200" Visible="false" />
                        </div>
                    </div>
                   
                </div>

            </div>
    </form>
</body>
</html>
