<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GKICMP.resourcesite.Index" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <title>智慧校园资源平台</title>
    <link rel="icon" href="../gzimages/yghd_favicon.ico" type="image/x-icon" />
    <style type="text/css">
        frameset {
            border: 0px;
            padding: 0px;
            margin: 0px;
        }

        frame {
            border: 0px;
            padding: 0px;
            margin: 0px;
        }
    </style>
</head>
<frameset name="middleframe" id="middleframe" rows="160,*,36" frameborder="no" border="0" framespacing="0">
    <frame src="Res_Top.aspx?1" name="topfr" id="topfr" />
    <frameset cols="40%,*" name="leftset" id="leftset" frameborder="no" border="0" framespacing="0">
        <frame src="Res_Left.aspx" id="leftfr" name="leftfr" />
        <frame src="Res_Main.aspx?RType=<%=RTypes %>" name="main" />
    </frameset>
    <frame src="../bot.html" name="botfr" id="botfr" />
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
