<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_MenuTree.aspx.cs" Inherits="proj_right_p_MenuTree" %>

<%@ Register Src="u_TreeViewMenu.ascx" TagName="u_TreeViewMenu" TagPrefix="uc1" %>

<!--使用 HTML 4.0-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>使用者權限操作功能選單</title>

<style type="text/css">
.tree_menu_d {/*定選單寬度*/ 
 margin-top: 3px; margin-right: 3px; margin-left: 3px; margin-bottom:3px;}
.tree_menu {font-size: 13px; margin-top: 0px;}
.tree_menu a {display: block; color: #333333; text-decoration: none; font-size: 13px; padding: 3px;}
.tree_menu td.mainnav {/*主選單（第一層）*/
 border-top-width: 1px; border-bottom-width: 1px; border-top-style: solid; border-bottom-style: solid; border-top-color: #FFFFFF;
 border-bottom-color: #CCCCCC;}
.tree_menu td.subnav {/*次選單(第二層)*/
 text-indent: 6px;
 background-repeat: no-repeat; background-position: 6px 3px;}
.tree_menu a:hover {
 color: #FFFFFF; background-color: #999999;}
.td { width: 210px; height:25px; }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="Frame_Left">
      <table width="200" border="0" cellpadding="0" cellspacing="0" class="tree_menu">
      <tr>
        <td class="td">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/proj_img/img-f1.jpg" />
          </td>
      </tr>
      <tr>
        <td class="td">
  		     <uc1:u_TreeViewMenu id="u_Menu" runat="server"></uc1:u_TreeViewMenu>
        </td>
      </tr>
      <tr>
        <td class="td">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/proj_img/img-f2.jpg" />
          </td>
      </tr>
      </table>
	</div>
    </form>
</body>
</html>
