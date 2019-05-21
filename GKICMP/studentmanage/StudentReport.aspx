<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentReport.aspx.cs" Inherits="GKICMP.studentmanage.StudentReport" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>无标题文档</title>
<!--595*842-->
<style>
body{ font-size:14px}
table table table td{ padding:5px 0px; line-height:1.2}
table table table.left td{ padding:5px 0px; line-height:1.4}
.leftspan{ display:inline-block; width:40px; border-bottom:1px solid #000000; height:25px; text-align:center}
.spanright{ display:inline-block; width:90px; border-bottom:1px solid #000000; height:25px;}
.spantime{display:inline-block; width:55px; border-bottom:1px solid #000000;}
</style>
    <style>
body{ font-size:14px}
table table table td{ padding:5px 0px; line-height:1.3}
table table table.left td{ padding:5px 0px; line-height:1.4}
</style>
</head>

<body>
<div style="width: 1000px; height: 625px; overflow: hidden; margin: auto; margin-top: 60px; font-size: 16px;">
<table width="1000" border="0" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td><table width="480" border="0" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td bgcolor="#000"><table width="100%" border="0" cellspacing="1" cellpadding="0">
          <tbody>
            <tr>
              <td width="9%" align="center" bgcolor="#FFFFFF" style="line-height:1.3; font-family: '黑体';"><strong>学<br>
                生<br>
                自<br>
                评</strong></td>
              <td colspan="5" bgcolor="#FFFFFF">&nbsp;</td>
              </tr>
            <tr>
              <td align="center" bgcolor="#FFFFFF" style="line-height:1.5; font-family: '黑体';"><strong>
                班<br>
                主<br>
                任<br>
                寄<br>
                语
              </strong></td>
              <td colspan="5" bgcolor="#FFFFFF"><asp:Literal ID="Literal12" runat="server"></asp:Literal></td>
              </tr>
            <tr>
              <td align="center" bgcolor="#FFFFFF" style="line-height: 1.3; font-family: '黑体';"><strong>校<br>
                长<br>
                签<br>
                章</strong></td>
              <td width="24%" bgcolor="#FFFFFF">&nbsp;</td>
              <td width="10%" align="center" bgcolor="#FFFFFF" style="font-family: '黑体';"><strong>教签<br>
                导　<br>
                主　<br>
                任章</strong></td>
              <td width="24%" bgcolor="#FFFFFF">&nbsp;</td>
              <td width="10%" align="center" bgcolor="#FFFFFF" style="line-height:1.9; font-family: '黑体';"><strong>班签<br>
                主　<br>
                任章</strong></td>
              <td width="24%" bgcolor="#FFFFFF">&nbsp;</td>
            </tr>
            <tr>
              <td align="center" bgcolor="#FFFFFF">附<br>
                知</td>
              <td colspan="5" bgcolor="#FFFFFF" style=" line-height:2.2; padding:10px">　　本学期<span class="leftspan"><asp:Literal ID="Literal13" runat="server"></asp:Literal></span>月<span class="leftspan"><asp:Literal ID="Literal14" runat="server"></asp:Literal></span>日假期开始，下学期定于<span class="leftspan"><asp:Literal ID="Literal15" runat="server"></asp:Literal></span>月<span class="leftspan"><asp:Literal ID="Literal16" runat="server"></asp:Literal></span>日正式上课。学生须在<span class="leftspan"><asp:Literal ID="Literal17" runat="server"></asp:Literal></span>月<span class="leftspan"><asp:Literal ID="Literal18" runat="server"></asp:Literal></span>日上午9:00-11:00携带假期作业、本报告单等有关材料来校报到注册。</td>
              </tr>
          </tbody>
        </table></td>
    </tr>
  </tbody>
      </table>
        
        <table width="480" border="0" cellspacing="0" cellpadding="0">
          <tbody>
            <tr> </tr>
          </tbody>
        </table>
      </td>
      <td><table width="480" border="0" align="right" cellpadding="0" cellspacing="0">
  <tbody>
    <tr>
      <td align="center" bgcolor="#FFFFFF"><strong style="font-size: 24px; line-height: 60px; font-family: '黑体';">芜湖市小学生素质发展报告单</strong></td>
    </tr>
    <tr>
      <td height="40" align="center" bgcolor="#FFFFFF" style="line-height: 20px; font-size: 18px;">
          （<span class="spantime"><asp:Literal ID="Literal1" runat="server"></asp:Literal></span>年－<span class="spantime"><asp:Literal ID="Literal2" runat="server"></asp:Literal></span>年学年度第<span class="spantime"><asp:Literal ID="Literal3" runat="server"></asp:Literal></span>学期）</td>
    </tr>
    <tr>
      <td height="50" align="center" bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td height="50" align="center" bgcolor="#FFFFFF" style="font-size:18px">学校（盖章）<span style="border-bottom: 1px solid #000000; padding-bottom: 2px; font-family: '华文新魏';"><asp:Literal ID="Literal4" runat="server"></asp:Literal></span></td>
    </tr>
    <tr>
      <td height="50" align="center" bgcolor="#FFFFFF" style="font-size:18px">年级<span class="spanright"><asp:Literal ID="Literal5" runat="server"></asp:Literal></span>班级<span class="spanright"><asp:Literal ID="Literal6" runat="server"></asp:Literal></span></td>
    </tr>
    <tr>
      <td height="50" align="center" bgcolor="#FFFFFF" style="font-size:18px">姓名<span class="spanright"><asp:Literal ID="Literal7" runat="server"></asp:Literal></span>学号<span class="spanright"><asp:Literal ID="Literal8" runat="server"></asp:Literal></span></td>
    </tr>
    <tr>
      <td height="50" align="center" bgcolor="#FFFFFF">&nbsp;</td>
    </tr>
    <tr>
      <td height="50" align="right" bgcolor="#FFFFFF" style="font-size: 24px">芜湖市教育局监制　　</td>
    </tr>
    <tr>
      <td height="50" align="right" bgcolor="#FFFFFF" style="font-size: 24px"><span class="spantime"><asp:Literal ID="Literal9" runat="server"></asp:Literal></span>年<span class="spantime"><asp:Literal ID="Literal10" runat="server"></asp:Literal></span>月<span class="spantime"><asp:Literal ID="Literal11" runat="server"></asp:Literal></span>日</td>
    </tr>
  </tbody>
</table></td>
    </tr>
    <tr>
      <td colspan="2"><hr style=" height:1px;border:none;border-top:1px dashed #000; margin:15px 0px"></td>
      </tr>
    <tr>
      <td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tbody>
          <tr>
            <td bgcolor="#000"><table width="100%" border="0" cellspacing="1" cellpadding="0">
              <tbody>
                <tr>
                  <td width="9%" align="center" bgcolor="#FFFFFF">家　长<br>
                    意　见<br>
                    （回执）<br>
                    可另附页</td>
                  <td width="19%" bgcolor="#FFFFFF" style="padding-left:10px"><p>孩子姓名：</p>
                    <p>所在班级：</p>
                    <p>家长签名：</p></td>
                  <td width="72%" bgcolor="#FFFFFF">&nbsp;</td>
                </tr>
              </tbody>
            </table></td>
          </tr>
        </tbody>
      </table></td>
      </tr>
  </tbody>
</table>

</div>

    <div style=" width:1000px; height:625px; overflow:hidden; margin:auto; margin-top:60px">
<table width="1000" border="0" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td><table width="480" border="0" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td bgcolor="#000"><table width="100%" border="0" cellspacing="1" cellpadding="0" class="left">
        <tbody>
          <tr>
            <td colspan="4" align="center" valign="middle" bgcolor="#FFFFFF">评价内容</td>
            <td width="17%" align="center" valign="middle" bgcolor="#FFFFFF">平时等级</td>
            <td width="18%" align="center" valign="middle" bgcolor="#FFFFFF">期综等级</td>
            <td width="16%" align="center" valign="middle" bgcolor="#FFFFFF">总评等级</td>
          </tr>
          <tr>
            <td width="8%" rowspan="14" align="center" valign="middle" bgcolor="#FFFFFF">学<br>
              科<br>
              课<br>
              程<br>
              学<br>
              习<br>
              状<br>
              况</td>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">品　　德</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal34" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal35" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal36" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td width="8%" rowspan="3" align="center" valign="middle" bgcolor="#FFFFFF">语<br>
              文</td>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">阅　　　　读</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal37" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal38" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal39" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">作文（说话）</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal40" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal41" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal42" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">写　　　　字</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal43" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal44" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal45" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">数　　　学</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal46" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal47" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal48" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">英　　　语</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal49" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal50" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal51" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">科　　　学</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal52" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal53" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal54" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">劳　　　动</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal55" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal56" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal57" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">社　　　会</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal58" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal59" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal60" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">音　　　乐</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal61" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal62" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal63" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">体　　　育</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal64" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal65" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal66" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">美　　　术</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal67" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal68" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal69" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">计算机起步</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal70" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal71" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal72" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle" bgcolor="#FFFFFF">健康教育</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal73" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal74" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal75" runat="server"></asp:Literal></td>
          </tr>
          <tr>
            <td colspan="2" rowspan="2" align="center" valign="middle" bgcolor="#FFFFFF" style="padding:20px 0px"><br>活动课程<br>
              学习状况<br>
              总评等级<br><br></td>
            <td width="17%" height="47" align="center" valign="middle" bgcolor="#FFFFFF">班队活动</td>
            <td width="16%" align="center" valign="middle" bgcolor="#FFFFFF">科技活动</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">文娱活动</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">体育锻炼</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">社会实践</td>
          </tr>
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal76" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal77" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal78" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal79" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal80" runat="server"></asp:Literal></td>
          </tr>
        </tbody>
      </table></td>
    </tr>
  </tbody>
</table>
</td>
      <td><table width="480" border="0" align="right" cellpadding="0" cellspacing="0">
  <tbody>
    <tr>
      <td bgcolor="#000">
      <table width="100%" border="0" cellspacing="1" cellpadding="0" >
        <tbody>
          <tr>
            <td colspan="8" align="center" bgcolor="#FFFFFF">综合考核项目</td>
          </tr>
          <tr>
            <td width="12%" align="center" bgcolor="#FFFFFF">评价<br>
              内容</td>
            <td width="12%" align="center" bgcolor="#FFFFFF">思想<br>
              道德</td>
            <td width="12%" align="center" bgcolor="#FFFFFF">勤奋<br>
              学习</td>
            <td width="12%" align="center" bgcolor="#FFFFFF">身体<br>
              素质</td>
            <td width="16%" align="center" bgcolor="#FFFFFF">审美塑美<br>
              能　　力</td>
            <td width="16%" align="center" bgcolor="#FFFFFF">生活劳动<br>
              技　　能</td>
            <td width="20%" colspan="2" align="center" bgcolor="#FFFFFF">创新精神<br>
              创造能力</td>
            </tr>
          <tr>
            <td align="center" bgcolor="#FFFFFF"><asp:Literal ID="Literal19" runat="server"></asp:Literal></td>
            <td align="center" bgcolor="#FFFFFF"><asp:Literal ID="Literal20" runat="server"></asp:Literal></td>
            <td align="center" bgcolor="#FFFFFF"><asp:Literal ID="Literal21" runat="server"></asp:Literal></td>
            <td align="center" bgcolor="#FFFFFF"><asp:Literal ID="Literal22" runat="server"></asp:Literal></td>
            <td align="center" bgcolor="#FFFFFF"><asp:Literal ID="Literal23" runat="server"></asp:Literal></td>
            <td align="center" bgcolor="#FFFFFF"><asp:Literal ID="Literal24" runat="server"></asp:Literal></td>
            <td colspan="2" align="center" bgcolor="#FFFFFF">&nbsp;</td>
            </tr></tbody></table>
            <div style="height:15px; background:#fff; border-left:1px solid #000; border-right:1px solid #000"></div>
      <table width="100%" border="0" cellspacing="1" cellpadding="0">
        <tbody>
       
          <tr>
            <td width="7%" rowspan="5" align="center" valign="middle" bgcolor="#FFFFFF">身<br>
              体<br>
              状<br>
              况<br></td>
            <td width="12%" align="center" valign="middle" bgcolor="#FFFFFF">体重</td>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal25" runat="server"></asp:Literal></td>
            <td width="13%" rowspan="2" align="center" valign="middle" bgcolor="#FFFFFF">听力</td>
            <td width="14%" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal26" runat="server"></asp:Literal></td>
            <td width="8%" rowspan="5" align="center" valign="middle" bgcolor="#FFFFFF">兴<br>
趣<br>
特<br>
长</td>
            <td colspan="2" rowspan="5" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal27" runat="server"></asp:Literal></td>
            </tr>
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF">身高</td>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal28" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal29" runat="server"></asp:Literal></td>
            </tr>
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF">胸围</td>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal30" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">肺活量</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal31" runat="server"></asp:Literal></td>
            </tr>
          <tr>
            <td rowspan="2" align="center" valign="middle" bgcolor="#FFFFFF">视力</td>
            <td colspan="2" align="left" valign="middle" bgcolor="#FFFFFF"> &nbsp;左&nbsp;<asp:Literal ID="Literal32" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">锯齿</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">个</td>
            </tr>
          <tr>
            <td colspan="2" align="left" valign="middle" bgcolor="#FFFFFF">&nbsp;右&nbsp;<asp:Literal ID="Literal33" runat="server"></asp:Literal></td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">&nbsp;</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">&nbsp;</td>
            </tr>
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF">特<br>
              别<br>
              表<br>
              现<br>
              记<br>
              载</td>
            <td colspan="8" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal81" runat="server"></asp:Literal></td>
            </tr>
          <tr>
            <td rowspan="2" align="center" valign="middle" bgcolor="#FFFFFF">出<br>
              勤<br>
              情<br>
              况</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">应到</td>
            <td width="13%" align="center" valign="middle" bgcolor="#FFFFFF">实到</td>
            <td width="13%" align="center" valign="middle" bgcolor="#FFFFFF">病假</td>
            <td width="13%" align="center" valign="middle" bgcolor="#FFFFFF">事假</td>
            <td width="14%" align="center" valign="middle" bgcolor="#FFFFFF">旷课</td>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">迟到</td>
            <td width="14%" align="center" valign="middle" bgcolor="#FFFFFF">早退</td>
          </tr>
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal82" runat="server"></asp:Literal>天</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal83" runat="server"></asp:Literal>天</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal84" runat="server"></asp:Literal>天</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal85" runat="server"></asp:Literal>天</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal86" runat="server"></asp:Literal>天</td>
            <td colspan="2" align="center" valign="middle" bgcolor="#FFFFFF">天</td>
            <td align="center" valign="middle" bgcolor="#FFFFFF">天</td>
          </tr>
          <tr>
            <td align="center" valign="middle" bgcolor="#FFFFFF"><br>
              奖<br>
              惩<br>
              情<br>
              况<br><br>
</td>
            <td colspan="8" align="center" valign="middle" bgcolor="#FFFFFF"><asp:Literal ID="Literal87" runat="server"></asp:Literal></td>
            </tr>
        </tbody>
      </table></td>
    </tr>
  </tbody>
</table></td> 
    </tr>
  </tbody>
</table>

</div>
</body>
</html>

