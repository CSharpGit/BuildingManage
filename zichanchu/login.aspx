<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>用户登录</title>
<style type="text/css">
 body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow:hidden;
	font-size: 12px
}
.bb{ border: solid 1px black;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgcolor="9fc967">&nbsp;</td>
  </tr>
  <tr>
    <td height="604"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="604" background="images/login_02.gif">&nbsp;</td>
        <td width="989"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="345" background="images/login_1.jpg">&nbsp;</td>
          </tr>
          <tr>
            <td height="47"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="539" height="47" background="images/login_05.gif" nowrap="nowrap">&nbsp;</td>
                <td width="206" background="images/login_06.gif" nowrap="nowrap"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="17%" style="height: 22px"><div align="center"><span class="STYLE1">用户</span></div></td>
                    <td width="58%" style="height: 22px"><div align="center">
                        <asp:TextBox ID="txtName" runat="server" Width="104px" 
                        onmouseover="this.style.borderColor='red'" onmouseout="this.style.borderColor='black'"
                        CssClass="bb"></asp:TextBox>&nbsp;</div></td>
                    <td width="25%" style="height: 22px">&nbsp;</td>
                  </tr>
                  <tr>
                    <td style="height: 22px"><div align="center"><span class="STYLE1">密码</span></div></td>
                    <td style="height: 22px"><div align="center">
                        <asp:TextBox ID="txtPwd" runat="server" Width="104px" CssClass="bb" 
                        onmouseover="this.style.borderColor='red'" onmouseout="this.style.borderColor='black'"
                        TextMode="Password"></asp:TextBox>&nbsp;</div></td>
                    <td style="height: 22px"><div align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/zichanchu/images/dl.gif" OnClick="ImageButton1_Click" />&nbsp;</div></td>
                  </tr>
                </table></td>
                <td width="244" background="images/login_07.gif" nowrap="nowrap">&nbsp;</td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td height="212" background="images/login_08.gif">&nbsp;</td>
          </tr>
        </table></td>
        <td background="images/login_04.gif">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td bgcolor="70ad21">&nbsp;</td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
