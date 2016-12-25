<%@ Page Language="VB" AutoEventWireup="false" CodeFile="choosexls.aspx.vb" Inherits="WebApp_sys_d_d02_choosexls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<div id=jsscript runat=server></div>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="90%" border="0" cellspacing="1" cellpadding="0" bgcolor="#c8dd8a" id="tabs-1">
                      <tr class="tabtitle">
                        <td colspan="2"  align="center" class="tabtitle">基本志工資料資料轉入作業</td>
                        </tr>
                      　<tr>
                        <td align="right" width="20%" class="tabitem"><span class="imp">*</span> 檔案</td>
                        <td align="left" >
                       <asp:FileUpload ID="wfile" runat="server" CssClass="c12border" size="40"/>  <asp:Button ID="btnsent" runat="server" alt="送出" text="送出"/></td>
                        </td>
                      　</tr>                  
                      <tr>
                        <td align="right" class="tabitem">&nbsp;</td>
                        <td align="left">請您先下載範例依照格式輸入資料，在上傳此檔案即可。範例：<a href="sample.csv" target="_blank" style="color:red">sample.csv</a></td>                        
                      </tr>
                         </table>
    </div>
    </form>
</body>
</html>
