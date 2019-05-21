<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectExercise.aspx.cs" Inherits="GKICMP.educational.SelectExercise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧校园行政办公平台</title>
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/My97/WdatePicker.js"></script>
    <script src="../js/Validform_v5.3.2.js"></script>
    <script src="../js/editinfor.js"></script>
    <script src="../utf8-net/ueditor.configs.js"></script>
    <script src="../utf8-net/ueditor.all.js"></script>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
        }

        body {
            margin: 0px;
            padding: 20px;
            color: #777777;
        }

        h2, h4 {
            text-align: center;
            line-height: 2;
        }

        ul, li {
            list-style: none;
        }

        #testid div {
            margin: 0px 25px;
        }

        #testid .test-title div {
            float: left;
            margin: 0px;
        }

        .test-title {
            font-weight: bold;
            margin: 5px 0px !important;
        }

        #testid .test-title .test-title-name {
            float: none;
            margin-left: 20px;
        }

            #testid .test-title .test-title-name p {
                /*display: inline;*/
            }

        .andiv {
            background: #FBFBFB;
            padding: 5px;
            margin: 5px 15px !important;
            /* border: 1px solid #F4F4F4;*/
        }

        #testid .test-title-name span {
            font-size: 12px;
            color: #FF0004;
            cursor: pointer;
        }

        #testid li {
            border-bottom: 1px solid #E7E7E7;
            padding: 10px 0px;
        }

        .editor {
            width: 98px;
            height: 39px;
            color: #fff;
            border: none;
            background: url(../images/green_sb_09.png);
            font-size: 18px;
            margin: 10px;
            padding: 0px;
            text-indent: 0px;
            text-align: center;
            cursor: pointer;
        }

        .submit {
            width: 98px;
            height: 39px;
            color: #fff;
            border: none;
            background: url(../images/green_sb_07.png);
            font-size: 18px;
            margin: 10px;
            padding: 0px;
            text-indent: 0px;
            text-align: center;
            cursor: pointer;
        }

        #testid td div {
            margin: 0px;
        }

        img.kfformula {
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </form>
</body>
</html>

