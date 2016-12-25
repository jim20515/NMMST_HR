<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_SuperWITCrypto.aspx.cs" Inherits="proj_right_p_SuperWITCrypto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>字串加解密</title>
	<link href="../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<asp:Panel ID="pn_Contain" runat="server" Height="420px" Style="z-index: 101; left: 20px; position: absolute; top: 20px" Width="780px">
			<table border="0" cellpadding="0" cellspacing="0" class="G" style="z-index: 101; left: 8px; position: absolute; top: 8px">
				<tr style="padding-bottom: 8px" valign="top">
					<td>
						<table>
							<tr>
								<td class="Frame_SysImg" valign="middle"><img align="absMiddle" alt="" src="../proj_img/Funcname.gif" /></td>
								<td class="Frame_SysName" valign="middle">字串加解密</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="padding-bottom: 4px" valign="top">
					<td>
						<span style="color: Red">金鑰(Key)／初始化向量(IV)為16進位字串且長度為16個字元</span><br />
						<span style="color: Navy">金鑰(Key)：</span>
						<asp:TextBox ID="tbx_Key" runat="server" Width="176px"></asp:TextBox>
						<span style="color: Navy">初始化向量(IV)：</span>
						<asp:TextBox ID="tbx_IV" runat="server" Width="176px"></asp:TextBox>
					</td>
				</tr>
				<tr style="padding-bottom: 4px" valign="top">
					<td>
						<span>加密前的字串：</span>
						<asp:TextBox ID="tbx_Before" runat="server" Width="400px"></asp:TextBox>
						<asp:Button ID="bt_Encrypt" runat="server" CssClass="B" OnClick="bt_Encrypt_Click" Text="加密" /><br />
						<span>加密後的字串：</span>
						<asp:TextBox ID="tbx_After" runat="server" Width="400px"></asp:TextBox>
						<asp:Button ID="bt_Decrypt" runat="server" CssClass="B" OnClick="bt_Decrypt_Click" Text="解密" />
					</td>
				</tr>
				<tr style="padding-bottom: 20px" valign="top">
					<td>

					</td>
				</tr>
			</table>
		</asp:Panel>
	</div>
    </form>
</body>
</html>
