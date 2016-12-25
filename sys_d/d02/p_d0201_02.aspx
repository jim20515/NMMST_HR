<%@ Page Language="C#" AutoEventWireup="true" CodeFile="p_d0201_02.aspx.cs" Inherits="sys_d_d02_p_d0201_02" %>

<%@ Register Src="../../proj_uctrl/u_DateSelect_ROC.ascx" TagName="u_DateSelect_ROC" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_BtSet_iduc.ascx" TagName="u_BtSet_iduc" TagPrefix="uc1" %>
<%@ Register Src="../../proj_uctrl/u_ProgressShow.ascx" TagName="u_ProgressShow" TagPrefix="uc1" %>
<%@ Import Namespace="WIT.Template.Project" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>明細</title>
    <link href="../../proj_css/s_GeneralStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../proj_css/s_webstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="pn_Contain" runat="server">
                        <table class="G">
                            <tr>
                                <td style="height: 1360px">
                                    <witc:DWPanel ID="dwF" runat="server" CssClass="Form" Height="1311px" Style="position: relative; left: 0px; top: 0px;" Width="820px">
                                        <asp:Label Style="z-index: 99; left: 0px; position: absolute; top: 8px" ID="dwF_hmd201_vid_t" runat="server" Width="100px" CssClass="D">志工代碼：</asp:Label>
                                        <asp:Label Style="z-index: 100; left: 104px; position: absolute; top: 8px" ID="dwF_hmd201_vid" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 104; left: 329px; position: absolute; top: 8px" ID="dwF_hmd201_id_t" runat="server" Width="84px" CssClass="D">人資代碼：</asp:Label>
                                        <asp:Label Style="z-index: 105; left: 417px; position: absolute; top: 8px" ID="dwF_hmd201_id" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 99; left: 664px; position: absolute; top: 40px" ID="Label1" runat="server" Width="100px" CssClass="I">志工照片：</asp:Label>
                                        <asp:Label ID="pic_t" runat="server" CssClass="G" ForeColor="Purple" Style="z-index: 99; left: 553px; position: absolute; top: 256px" Width="226px">※ 建議圖片上傳大小為160px * 128px</asp:Label>
                                        <asp:Image Style="z-index: 104; left: 640px; position: absolute; top: 56px" ID="PersonPhoto" runat="server" Width="128px" Height="160px" BorderWidth="1px" ImageUrl="hmd201.ashx?ax='<%   =DateTime.Now.ToString()   %>'" BorderStyle="Solid"></asp:Image>
                                        <asp:Button Style="z-index: 104; left: 664px; position: absolute; top: 224px" ID="bt_GotoUploadPic" OnClick="bt_GotoUploadPic_Click" runat="server" Width="88px" CssClass="inputButton" Text="上傳照片"></asp:Button>
										<asp:Label ID="dwF_hmd201_bookid_t" runat="server" CssClass="I" Style="z-index: 237; left: 0px; position: absolute; top: 34px" Width="100px">志工手冊編號：</asp:Label>
										<asp:TextBox ID="dwF_hmd201_bookid" runat="server" CssClass="G" Style="z-index: 116; left: 104px; position: absolute; top: 30px" Width="153px"></asp:TextBox>
                                        <asp:Label Style="z-index: 114; left: 0px; position: absolute; top: 60px" ID="dwF_hmd201_cname_t" runat="server" Width="100px" CssClass="N">姓名：</asp:Label>
                                        <asp:TextBox Style="z-index: 115; left: 104px; position: absolute; top: 57px" ID="dwF_hmd201_cname" runat="server" Width="152px" CssClass="G"></asp:TextBox>
										<asp:Label ID="dwF_hmd201_ename_t" runat="server" CssClass="I" Style="z-index: 114; left: 285px; position: absolute; top: 61px" Width="130px">英文姓名(與護照同)：</asp:Label>
										<asp:TextBox ID="dwF_hmd201_ename" runat="server" CssClass="G" Style="z-index: 115; left: 418px; position: absolute; top: 58px" Width="200px"></asp:TextBox>
                                        <asp:Label Style="z-index: 119; left: 0px; position: absolute; top: 88px" ID="dwF_hmd201_gent_t" runat="server" Width="100px" CssClass="I">性別：</asp:Label>
                                        <asp:RadioButtonList Style="left: 104px; position: relative; top: 78px" ID="dwF_hmd201_gent" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="M">男</asp:ListItem>
                                            <asp:ListItem Value="F">女</asp:ListItem>
                                        </asp:RadioButtonList>&nbsp;
                                        <asp:Label Style="z-index: 124; left: 0px; position: absolute; top: 112px" ID="dwF_hmd201_bday_t" runat="server" Width="100px" CssClass="I">生日：</asp:Label>
                                        <asp:Panel Style="z-index: 125; left: 104px; position: absolute; top: 108px" ID="dwF_hmd201_bday" runat="server" Width="240px" Height="16px" CssClass="G">
                                            <uc1:u_DateSelect_ROC ID="u_Date2" runat="server" />
                                        </asp:Panel>
                                        <asp:Label Style="z-index: 129; left: 712px; position: absolute; top: 8px" ID="dwF_hmd201_ssntype_t" runat="server" Width="100px" CssClass="I" Visible="false">身分註記類別：</asp:Label>
                                        <asp:DropDownList Style="z-index: 130; left: 104px; position: absolute; top: 141px" ID="dwF_hmd201_ssntype" runat="server" Width="105px" AutoPostBack="True" OnSelectedIndexChanged="dwF_hmd201_ssntype_SelectedIndexChanged">
                                            <asp:ListItem Value="1">身分證</asp:ListItem>
                                            <asp:ListItem Value="2">護照</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 134; left: 0px; position: absolute; top: 144px" ID="dwF_hmd201_SSN_t" runat="server" Width="100px" CssClass="N">身份證：</asp:Label>
                                        <asp:TextBox Style="z-index: 135; left: 216px; position: absolute; top: 141px" ID="dwF_hmd201_SSN" runat="server" Width="200px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 144; left: 0px; position: absolute; top: 176px" ID="dwF_hmd201_eduid_t" runat="server" Width="100px" CssClass="N">教育程度：</asp:Label>
                                        <asp:DropDownList Style="z-index: 145; left: 104px; position: absolute; top: 172px" ID="dwF_hmd201_eduid" runat="server" Width="105px" DataMember="hca203">
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 149; left: 0px; position: absolute; top: 204px" ID="dwF_hmd201_jobid_t" runat="server" Width="100px" CssClass="I">職業：</asp:Label>
                                        <asp:DropDownList Style="z-index: 150; left: 104px; position: absolute; top: 201px" ID="dwF_hmd201_jobid" runat="server" Width="105px" DataMember="hca204">
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 154; left: 0px; position: absolute; top: 236px" ID="dwF_hmd201_joborg_t" runat="server" Width="100px" CssClass="I">服務單位：</asp:Label>
                                        <asp:TextBox Style="z-index: 155; left: 104px; position: absolute; top: 232px" ID="dwF_hmd201_joborg" runat="server" Width="200px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 159; left: 0px; position: absolute; top: 260px" ID="dwF_hmd201_jobtitle_t" runat="server" Width="100px" CssClass="I">職稱：</asp:Label>
                                        <asp:TextBox Style="z-index: 160; left: 104px; position: absolute; top: 257px" ID="dwF_hmd201_jobtitle" runat="server" Width="200px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 164; left: 0px; position: absolute; top: 289px" ID="dwF_hmd201_addid_t" runat="server" Width="100px" CssClass="N" >郵遞區號：</asp:Label>
										<asp:TextBox ID="dwF_hmd201_addid" runat="server" AutoPostBack="true" CssClass="I" OnTextChanged="dwF_hmd201_addid_OnTextChanged" Style="z-index: 149; left: 105px; position: absolute; top: 286px" Width="35px"></asp:TextBox>
										<asp:Label ID="dwF_hmd201_addid_h_t" runat="server" CssClass="I" Style="z-index: 149; left: 152px; position: absolute; top: 289px" Width="31px">縣市</asp:Label>
										<asp:DropDownList ID="dwF_hmd201_addid_h" runat="server" AutoPostBack="true" DataMember="hca212" OnSelectedIndexChanged="dwF_hmd201_addid_h_OnSelectedIndexChanged" Style="z-index: 150; left: 190px; position: absolute; top: 285px">
										</asp:DropDownList>
										<asp:Label ID="dwF_hmd201_addid_b_t" runat="server" CssClass="I" Style="z-index: 149; left: 304px; position: absolute; top: 287px" Width="31px">鄉鎮</asp:Label>
										<asp:DropDownList ID="dwF_hmd201_addid_b" runat="server" AutoPostBack="true" DataMember="hca205" OnSelectedIndexChanged="dwF_hmd201_addid_b_OnSelectedIndexChanged" Style="z-index: 150; left: 342px; position: absolute; top: 285px">
										</asp:DropDownList>
                                        <asp:Label Style="z-index: 169; left: 0px; position: absolute; top: 315px" ID="dwF_hmd201_addot_t" runat="server" Width="100px" CssClass="N">聯絡地址：</asp:Label>
                                        <asp:TextBox Style="z-index: 170; left: 104px; position: absolute; top: 313px" ID="dwF_hmd201_addot" runat="server" Width="352px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 174; left: 0px; position: absolute; top: 345px" ID="dwF_hmd201_email_t" runat="server" Width="100px" CssClass="I">電子信箱：</asp:Label>
                                        <asp:TextBox Style="z-index: 175; left: 104px; position: absolute; top: 341px" ID="dwF_hmd201_email" runat="server" Width="464px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 179; left: 0px; position: absolute; top: 372px" ID="dwF_hmd201_phnow_t" runat="server" Width="100px" CssClass="I">公司電話：</asp:Label>
                                        <asp:TextBox Style="z-index: 180; left: 104px; position: absolute; top: 369px" ID="dwF_hmd201_phnow" runat="server" Width="200px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 184; left: 264px; position: absolute; top: 371px" ID="dwF_hmd201_phnowex_t" runat="server" Width="100px" CssClass="I">分機：</asp:Label>
                                        <asp:TextBox Style="z-index: 185; left: 368px; position: absolute; top: 369px" ID="dwF_hmd201_phnowex" runat="server" Width="72px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 189; left: 0px; position: absolute; top: 399px" ID="dwF_hmd201_phnoa_t" runat="server" Width="100px" CssClass="N">住宅電話：</asp:Label>
                                        <asp:TextBox Style="z-index: 190; left: 104px; position: absolute; top: 397px" ID="dwF_hmd201_phnoa" runat="server" Width="200px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 194; left: 0px; position: absolute; top: 426px" ID="dwF_hmd201_phnom_t" runat="server" Width="100px" CssClass="N">行動電話：</asp:Label>
                                        <asp:TextBox Style="z-index: 195; left: 104px; position: absolute; top: 423px" ID="dwF_hmd201_phnom" runat="server" Width="200px" CssClass="G"></asp:TextBox>
										<asp:Label ID="dwF_hmd201_marriage_t" runat="server" CssClass="I" Style="z-index: 194; left: 3px; position: absolute; top: 456px" Width="100px">婚姻狀況：</asp:Label>
										<asp:RadioButtonList ID="dwF_hmd201_marriage" runat="server" CssClass="G" RepeatDirection="Horizontal" Style="z-index: 195; left: 107px; position: absolute; top: 450px" Width="109px">
											<asp:ListItem Selected="True" Value="N">未婚</asp:ListItem>
											<asp:ListItem Value="Y">已婚</asp:ListItem>
										</asp:RadioButtonList>
										<asp:Label ID="dwF_hmd201_children_t" runat="server" CssClass="I" Style="z-index: 194; left: 224px; position: absolute; top: 456px">子女　　　　人</asp:Label>
										<asp:TextBox ID="dwF_hmd201_children" runat="server" CssClass="G" Style="z-index: 195; left: 254px; position: absolute; top: 450px" Width="35px"></asp:TextBox>
                                        <asp:Label Style="z-index: 199; left: 0px; position: absolute; top: 482px" ID="dwF_hmd201_memberid_t" runat="server" Width="100px" CssClass="I">會員帳號：</asp:Label>
                                        <asp:TextBox Style="z-index: 200; left: 104px; position: absolute; top: 479px" ID="dwF_hmd201_memberid" runat="server" Width="200px" CssClass="G"></asp:TextBox>
                                        <asp:Label Style="z-index: 204; left: 0px; position: absolute; top: 512px" ID="dwF_hmd201_memberpwd_t" runat="server" Width="100px" CssClass="I">會員密碼：</asp:Label>
                                        <asp:TextBox Style="z-index: 205; left: 104px; position: absolute; top: 509px" ID="dwF_hmd201_memberpwd" runat="server" Width="200px" CssClass="G"></asp:TextBox>
										<asp:Label ID="dwF_hmd201_account_t" runat="server" CssClass="N" Style="z-index: 214; left: 0px; position: absolute; top: 539px" Width="100px">志工網帳號：</asp:Label>
										<asp:TextBox ID="dwF_hmd201_account" runat="server" CssClass="G" Style="z-index: 215; left: 104px; position: absolute; top: 536px" Width="200px"></asp:TextBox>
                                        <asp:Label Style="z-index: 209; left: 0px; position: absolute; top: 568px" ID="dwF_hmd201_pwd_t" runat="server" Width="100px" CssClass="N">志工網密碼：</asp:Label>
                                        <asp:TextBox Style="z-index: 210; left: 104px; position: absolute; top: 565px" ID="dwF_hmd201_pwd" runat="server" Width="200px" CssClass="G" TextMode="Password"></asp:TextBox>
                                        <asp:CheckBox Style="z-index: 220; left: 72px; position: absolute; top: 598px" ID="dwF_hmd201_passed" runat="server" Text="通過認證"></asp:CheckBox>
                                        <asp:CheckBox Style="z-index: 225; left: 200px; position: absolute; top: 598px" ID="dwF_hmd201_rejectepaper" runat="server" Text="拒收電子報"></asp:CheckBox>
                                        <asp:Label Style="z-index: 229; left: 0px; position: absolute; top: 633px" ID="dwF_hmd201_tid_t" runat="server" Width="100px" CssClass="N">所屬志工隊：</asp:Label>
                                        <asp:DropDownList Style="z-index: 230; left: 104px; position: absolute; top: 630px" ID="dwF_hmd201_tid" runat="server" Width="208px" DataMember="hmd101">
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 231; left: 0px; position: absolute; top: 665px" ID="dwF_hmd201_lvid_t" runat="server" Width="100px" CssClass="N">志工階級：</asp:Label>
                                        <asp:DropDownList Style="z-index: 232; left: 104px; position: absolute; top: 661px" ID="dwF_hmd201_lvid" runat="server" Width="208px" DataMember="hca206">
                                        </asp:DropDownList>
                                        <asp:Label Style="z-index: 233; left: 0px; position: absolute; top: 697px" ID="dwF_hmd201_status_t" runat="server" Width="100px" CssClass="N">服務狀態：</asp:Label>
                                        <asp:DropDownList Style="z-index: 234; left: 104px; position: absolute; top: 693px" ID="dwF_hmd201_status" runat="server" Width="208px" DataMember="hca207">
                                        </asp:DropDownList>
										<asp:Label ID="dwF_hmd201_serviceexp_t" runat="server" CssClass="I" Style="z-index: 244; left: 3px; position: absolute; top: 724px" Width="98px" Height="34px">參與志願服務經歷：</asp:Label>
										<asp:TextBox ID="dwF_hmd201_serviceexp" runat="server" CssClass="G" Height="80px" Style="z-index: 245; left: 103px; position: absolute; top: 724px" TextMode="MultiLine" Width="256px"></asp:TextBox>
                                        <asp:Label Style="z-index: 235; left: 0px; position: absolute; top: 822px" ID="dwF_hmd201_workday_t" runat="server" Width="100px" CssClass="I">可服勤時間：</asp:Label>
                                        <asp:TextBox Style="z-index: 236; left: 584px; position: absolute; top: 791px" ID="dwF_hmd201_workday" runat="server" Width="184px" CssClass="G" Visible="False"></asp:TextBox>
                                        <asp:Label Style="z-index: 239; left: -14px; position: absolute; top: 930px" ID="dwF_hmd201_lappdt_t" runat="server" Width="184px" CssClass="I">最後申請志工榮譽證時間：</asp:Label>
                                        <asp:Panel Style="z-index: 240; left: 168px; position: absolute; top: 926px" ID="dwF_hmd201_lappdt" runat="server" Width="132px" Height="16px" CssClass="G">
                                            <uc1:u_DateSelect_ROC ID="u_Date3" runat="server" />
                                        </asp:Panel>
										&nbsp;&nbsp;
                                        <asp:Label Style="z-index: 244; left: 8px; position: absolute; top: 963px" ID="dwF_hmd201_introtext_t" runat="server" Width="100px" CssClass="N">參與動機：</asp:Label>
                                        <asp:TextBox Style="z-index: 245; left: 112px; position: absolute; top: 963px" ID="dwF_hmd201_introtext" runat="server" Width="256px" Height="80px" CssClass="G" TextMode="MultiLine"></asp:TextBox>
                                        <asp:Label Style="z-index: 269; left: 379px; position: absolute; top: 963px" ID="dwF_hmd201_expert_t" runat="server" Width="113px" CssClass="N">與本處服務有關的個人專長或學識：</asp:Label>
                                        <asp:TextBox Style="z-index: 270; left: 496px; position: absolute; top: 963px" ID="dwF_hmd201_expert" runat="server" Width="256px" Height="80px" CssClass="G" TextMode="MultiLine"></asp:TextBox>
                                        <asp:Label Style="z-index: 274; left: 392px; position: absolute; top: 1059px" ID="dwF_hmd201_notel_t" runat="server" Width="100px" CssClass="I">重要註記：</asp:Label>
                                        <asp:TextBox Style="z-index: 275; left: 496px; position: absolute; top: 1059px" ID="dwF_hmd201_notel" runat="server" Width="256px" Height="80px" CssClass="G" TextMode="MultiLine">
                                        </asp:TextBox>
                                        <asp:Label Style="z-index: 279; left: 8px; position: absolute; top: 1059px" ID="dwF_hmd201_ps_t" runat="server" Width="100px" CssClass="I">備註：</asp:Label>
                                        <asp:TextBox Style="z-index: 280; left: 112px; position: absolute; top: 1059px" ID="dwF_hmd201_ps" runat="server" Width="256px" Height="80px" CssClass="G" TextMode="MultiLine">
                                        </asp:TextBox>
										<asp:Label ID="dwF_hld201_logdate_t" runat="server" CssClass="D" Style="z-index: 104; left: 22px; position: absolute; top: 1150px" Width="84px">核定日期：</asp:Label>
										<asp:Label ID="dwF_hld201_logdate" runat="server" CssClass="G" Style="z-index: 105; left: 113px; position: absolute; top: 1152px" Width="150px"></asp:Label>
										<asp:Label ID="dwF_hld201_ps_t" runat="server" CssClass="D" Style="z-index: 104; left: 409px; position: absolute; top: 1153px" Width="82px">核定文號：</asp:Label>
										<asp:Label ID="dwF_hld201_ps" runat="server" CssClass="G" Style="z-index: 105; left: 497px; position: absolute; top: 1152px" Width="150px"></asp:Label>
                                        <asp:Label Style="z-index: 284; left: 8px; position: absolute; top: 1175px" ID="dwF_hmd201_creatway_t" runat="server" Width="100px" CssClass="D">新增方式：</asp:Label>
                                        <asp:Label Style="z-index: 285; left: 112px; position: absolute; top: 1175px" ID="dwF_hmd201_creatway" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 289; left: 8px; position: absolute; top: 1199px" ID="dwF_hmd201_aid_t" runat="server" Width="100px" CssClass="D">新增人員：</asp:Label>
                                        <asp:Label Style="z-index: 290; left: 112px; position: absolute; top: 1199px" ID="dwF_hmd201_aid" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 294; left: 8px; position: absolute; top: 1223px" ID="dwF_hmd201_adt_t" runat="server" Width="100px" CssClass="D">新增時間：</asp:Label>
                                        <asp:Label Style="z-index: 295; left: 112px; position: absolute; top: 1223px" ID="dwF_hmd201_adt" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 299; left: 8px; position: absolute; top: 1247px" ID="dwF_hmd201_uid_t" runat="server" Width="100px" CssClass="D">異動人員：</asp:Label>
                                        <asp:Label Style="z-index: 300; left: 112px; position: absolute; top: 1247px" ID="dwF_hmd201_uid" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        <asp:Label Style="z-index: 304; left: 8px; position: absolute; top: 1271px" ID="dwF_hmd201_udt_t" runat="server" Width="100px" CssClass="D">異動時間：</asp:Label>
                                        <asp:Label Style="z-index: 305; left: 112px; position: absolute; top: 1271px" ID="dwF_hmd201_udt" runat="server" Width="150px" CssClass="G"></asp:Label>
                                        &nbsp;
                                        <table style="left: 104px; position: absolute; top: 821px" id="myCBT" class="content_Blue" border="1">
                                            <tbody>
                                                <tr align="center">
                                                    <td>
                                                        ＼</td>
                                                    <td>
                                                        日</td>
                                                    <td>
                                                        一</td>
                                                    <td>
                                                        二</td>
                                                    <td>
                                                        三</td>
                                                    <td>
                                                        四</td>
                                                    <td>
                                                        五</td>
                                                    <td>
                                                        六</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        上午</td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 250" ID="dwF_CB_A" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 251" ID="dwF_CB_B" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 252" ID="dwF_CB_C" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 253" ID="dwF_CB_D" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 254" ID="dwF_CB_E" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 255" ID="dwF_CB_F" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 256" ID="dwF_CB_G" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        下午</td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 257" ID="dwF_CB_H" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 258" ID="dwF_CB_I" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 259" ID="dwF_CB_J" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 260" ID="dwF_CB_K" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 261" ID="dwF_CB_L" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 262" ID="dwF_CB_M" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                    <td>
                                                        <asp:CheckBox Style="z-index: 263" ID="dwF_CB_N" runat="server" Width="10px" CssClass="G" OnCheckedChanged="rcWorkDay" AutoPostBack="true"></asp:CheckBox></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <br />
                                    </witc:DWPanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="position: relative; float: right">
                                        <uc1:u_BtSet_iduc ID="u_Edit_F" runat="server" />
                                    </div>
                                    <asp:Button ID="dwF_report2" runat="server" OnClick="dwF_report2_Click" Style="left: 171px; position: relative; top: 8px" CssClass="Bt_B9005" Width="80px" /></td>
                            </tr>
                            <tr>
                                <td style="height: 8px">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <uc1:u_ProgressShow ID="u_Progress" runat="server" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
