<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetImport.aspx.cs" Inherits="GKICMP.assetmanage.AssetImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园基础管理平台</title>

    <link href="../css/green_formcss.css" rel="stylesheet" />

    <script src="../js/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../js/common.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="listcent pad0">
            <div>
                <table width="100%" cellspacing="0" cellpadding="0" class="listinfo">
                    <tr>
                        <th colspan="4" align="left">资产导入
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="100px">资产信息：</td>
                        <td>
                            <asp:FileUpload ID="fuimport" onchange="if(this.value)judgexls(this.value,this);"
                                runat="server" />&nbsp;&nbsp;<asp:LinkButton ID="lbtn_example" Style="color: blue" runat="server"
                                    OnClick="lbtn_example_Click">[模板下载]</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">导入说明：</td>
                        <td>
                            <span style="color: red;">1.下载的模板中标红字段均为必填字段，请仔细检查以免导入失败；<br />
                                2.资产数量、价值必须为有效数字；<br />
                                3.供应商必须为系统中已存在的供应商；<br />
                                4.资产分组不可为空，需填写系统中维护的资产分组；<br />
                                5.校区编号要根据系统的校区编号填写；
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btn_Sumbit" runat="server" Text="提交" CssClass="submit" OnClick="btn_Sumbit_Click" />
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>
