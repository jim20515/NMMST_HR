<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0201_03.aspx.cs" Inherits="sys_d_d02_p_d0201_03" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <base target="_self" />
    <meta content="no-cache" http-equiv="Pragma" />
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />
        <div>
            <table align="center" cellpadding="0" cellspacing="0" class="MainTable">
                <tbody>
                    <tr>
                        <td class="MainTitle">
                        </td>
                    </tr>
                    <tr>
                        <td class="SubTitle">
                            <asp:Label ID="dwF_hmd201_vid_t" runat="server" CssClass="D" Style="z-index: 99; left: 0px; position: absolute; top: 16px" Width="100px">◎志工姓名：</asp:Label>
                            <asp:Label ID="dwF_hmd201_vid" runat="server" CssClass="G" Style="z-index: 100; left: 104px; position: absolute; top: 16px" Width="150px"></asp:Label>
                            <br />
                            <table align="center" class="MainTable">
                                <tbody>
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="PersonPhoto" runat="server" BorderStyle="Solid" Height="160px" Width="128px" ImageUrl="hmd201.ashx" BorderWidth="1px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="dwF" runat="server" Width="100%">
                                                <asp:FileUpload ID="dwF_filepath" runat="server" CssClass="inputText98Per" />
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; height: 28px;">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <div style="font-size: 12pt; color: white; position: absolute; background-color: red; z-index: 99;">
                                                                上傳中，請稍候...</div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:Button ID="bt_Upload" runat="server" CssClass="inputButton" OnClick="bt_Upload_Click" Text="上傳附件" />
                                                    <%--<input class="inputButton" name="Submit" onclick="javascript:window.close();" type="button" value="無附件" />--%>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="pic_t" runat="server" CssClass="G" ForeColor="Purple" Style="position: relative;" Width="226px">※ 建議圖片上傳大小為160px * 128px</asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
