// *********************************************************************************
// 1. 程式描述：統一速達人事考勤管理系統 - 上下班刷卡系統（JavaScript）
// 2. 撰寫人員：fen
// *********************************************************************************

if (top.location.toString().indexOf("SignPage") == -1)
	top.location = "SignPage.htm";

function uf_MouseClicked()
{
	if ((navigator.appName == 'Netscape' && mousebutton.which == 1) || (navigator.appName == 'Microsoft Internet Explorer' && event.button == 2))
		alert("此網頁不允許使用滑鼠右鍵");
}
document.onmousedown = uf_MouseClicked;

function uf_KeyDown()
{
	if ((window.event.keyCode == 49 || window.event.keyCode == 97) && window.event.srcElement.type != "password")
	{
		uf_click(1);
		window.event.keyCode = 8;	// backspace
	}
	else if ((window.event.keyCode == 50 || window.event.keyCode == 98) && window.event.srcElement.type != "password")
	{
		uf_click(2);
		window.event.keyCode = 8;	// backspace
	}
}
document.onkeydown = uf_KeyDown;

function uf_Timer()
{
	window.setTimeout("uf_Timer()", 1000);
	var ldt_date = new Date();

	var li_year = ldt_date.getFullYear();
	var li_month = ldt_date.getMonth() + 1;
	var li_day = ldt_date.getDate();
	var ls_date = li_year + "/" + (li_month >= 10 ? '': '0') + li_month + "/" + (li_day >= 10 ? '': '0') + li_day;
	document.getElementById("lb_ShowDate").innerText = ls_date;

	var li_hour = ldt_date.getHours();
	var li_min = ldt_date.getMinutes();
	var li_sec = ldt_date.getSeconds();
	ls_date = (li_hour >= 10 ? '': '0') + li_hour + ":" + (li_min >= 10 ? '': '0') + li_min + ":" + (li_sec >= 10 ? '': '0') + li_sec;
	document.getElementById("lb_ShowTime").innerText = ls_date;
}

function uf_Timer1()
{   
    var ldt_date = new Date(document.getElementById("lb_realtime").innerText);
    var li_date = Date.parse(ldt_date);
    var li_addsec = 1000;
    var newdate = new Date();
    var ldt_ndate = new Date(newdate.setTime(li_date + li_addsec));
    var li_year = ldt_ndate.getFullYear();
    var li_month = ldt_ndate.getMonth() + 1;
	var li_day = ldt_ndate.getDate();
	var ls_date = li_year + "/" + (li_month >= 10 ? '': '0') + li_month + "/" + (li_day >= 10 ? '': '0') + li_day;
	document.getElementById("lb_ShowDate").innerText = ls_date;
	
	var li_hour = ldt_ndate.getHours();
	var li_min = ldt_ndate.getMinutes();
	var li_sec = ldt_ndate.getSeconds();
	ls_date = (li_hour >= 10 ? '': '0') + li_hour + ":" + (li_min >= 10 ? '': '0') + li_min + ":" + (li_sec >= 10 ? '': '0') + li_sec;
	document.getElementById("lb_ShowTime").innerText = ls_date;
	
	ls_date = li_year + "/" + (li_month >= 10 ? '': '0') + li_month + "/" + (li_day >= 10 ? '': '0') + li_day + " " + (li_hour >= 10 ? '': '0') + li_hour + ":" + (li_min >= 10 ? '': '0') + li_min + ":" + (li_sec >= 10 ? '': '0') + li_sec;
	document.getElementById("lb_realtime").innerText = ls_date;
	
    window.setTimeout("uf_Timer1()", 1000);
}

function uf_click(ai_ViewIndex)
{
	uf_Reset();
	uf_doSwitch(ai_ViewIndex);
}

function uf_Reset()
{
	document.getElementById("msg1").innerHTML = "";
	document.getElementById("msg2").innerHTML = "";
}

function uf_doSwitch(ai_ViewIndex)
{
	var lo_obj;
	for (var li_i = 0; li_i < 3; li_i++)
	{
		lo_obj = document.getElementById("view" + li_i);
		if (lo_obj == null) return;

		if (li_i == ai_ViewIndex)
			lo_obj.style.display = "block";
		else
			lo_obj.style.display = "none";
	}

	var lo_bt1 = document.getElementById("bt_SignIn");
	var lo_bt2 = document.getElementById("bt_SignOut");

	lo_bt1.style.borderStyle = "";
	lo_bt1.style.borderColor = "";
	lo_bt1.style.backgroundColor = "";
	lo_bt2.style.borderStyle = "";
	lo_bt2.style.borderColor = "";
	lo_bt2.style.backgroundColor = "";

	if (ai_ViewIndex == 0)
	{
	}
	else if (ai_ViewIndex == 1)
	{
		lo_bt1.style.borderStyle = "dashed";
		lo_bt1.style.borderTopStyle = "none";
		lo_bt1.style.borderColor = "Black";
		lo_bt1.style.backgroundColor = "";
		lo_bt2.style.borderStyle = "none";
		lo_bt2.style.borderTopStyle = "dashed";
		lo_bt2.style.borderColor = "Black";
		lo_bt2.style.backgroundColor = "Transparent";
		lo_obj = document.getElementById("tbx_SignIn");
		if (lo_obj == null) return;

		lo_obj.value = "";
		lo_obj.focus();
	}
	else if (ai_ViewIndex == 2)
	{
		lo_bt2.style.borderStyle = "dashed";
		lo_bt2.style.borderTopStyle = "none";
		lo_bt2.style.borderColor = "Black";
		lo_bt2.style.backgroundColor = "";
		lo_bt1.style.borderStyle = "none";
		lo_bt1.style.borderTopStyle = "dashed";
		lo_bt1.style.borderColor = "Black";
		lo_bt1.style.backgroundColor = "Transparent";
		lo_obj = document.getElementById("tbx_SignOut");
		if (lo_obj == null) return;

		lo_obj.value = "";
		lo_obj.focus();
	}
}
