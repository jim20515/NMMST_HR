// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 框架相關 JavaScript
// 2. 撰寫人員：fen
// *********************************************************************************

// ----------------------------------------------------------------- ☆ 特定事件(版面)

// =========================================================================
// 事件：onLoad–fen
// =========================================================================
function ue_onLoad()
{
	/*
	// Close MenuBar and Toolbar
	if (document.body.children[0].id == "Login" && opener == null)
	{
		var li_Left = 0;
		var li_Top = 0;		//72;
		var li_Width = screen.availWidth - 4;
		var li_Height = screen.availHeight - 48;		// 452;
		window.open('Login.aspx','','left=' + li_Left + ',top=' + li_Top + ',width=' + li_Width + ',height=' + li_Height + ',status=yes,scrollbars=yes,toolbar=no,menubar=no,location=no','');
		history.back();
	}
	*/

	// Set ScrollBar Position
	uf_SetScrollPosition(document.body, document.all.page_scrollTop.value, document.all.page_scrollLeft.value);

	// Set Version Text Position
	uf_SetObjectFix(document.all.appversion);

	// Set pn_Contain Position
//	uf_SetObjectPageCenter("pn_Contain");
}

// =========================================================================
// 事件：onResize–fen
// =========================================================================
function ue_onResize()
{
	// Set Version Text Position
	uf_SetObjectFix(document.all.appversion);

	// Set pn_Contain Position
//	uf_SetObjectPageCenter("pn_Contain");
}

// =========================================================================
// 事件：onScroll–fen
// =========================================================================
function ue_onScroll()
{
	// Get ScrollBar Position
	uf_GetScrollPosition(document.body, document.all.page_scrollTop, document.all.page_scrollLeft);

	// Set Version Text Position
	uf_SetObjectFix(document.all.appversion);
}

// =========================================================================
// 事件：ue_onKeyDown–fen
// =========================================================================
function ue_onKeyDown()
{
	// Peplace Enter Key To Tab Key
	if (window.event.keyCode == 13
		&& window.event.srcElement.type != "submit"
		&& window.event.srcElement.type != "textarea")
		window.event.keyCode = 9;
}

// =========================================================================
// 事件：ue_onLoadOk–fen
// =========================================================================
function ue_onLoadOk()
{

}


// ----------------------------------------------------------------- ☆ 特定函式(版面)

// =========================================================================
// 函式：在視窗上顯示最新版本日期–fen
// =========================================================================
function uf_ShowAppVersion(as_VersionDate)
{
	// Create Version DIV
	document.write("<div class=\"RV\" id=\"appversion\" style=\"z-index: 998; left: -500px; position: absolute\">Version Date: " + as_VersionDate + "</div>")
}


// ----------------------------------------------------------------- ☆ 共用函式(版面)

// =========================================================================
// 函式：開啟 Popup 小視窗顯示訊息–fen
// =========================================================================
var iw_PopupWin;
function uf_ShowWindow(as_Title, as_Content, as_Color)
{
	var	ls_bcolor;
	var	ls_scolor;
	var	ls_fcolor;
	var ls_WinDocument;

	if (as_Color == "Green")		// 綠色
	{
		ls_bcolor = "#c8dcc8";
		ls_scolor = "#ffc8dcc8";
		ls_fcolor = "#004000";
	}
	else if (as_Color == "Red")		// 紅色
	{
		ls_bcolor = "#dcc8c8";
		ls_scolor = "#ffdcc8c8";
		ls_fcolor = "#400000";
	}
	else if (as_Color == "Violet")	// 紫色
	{
		ls_bcolor = "#d2c8dc";
		ls_scolor = "#ffd2c8dc";
		ls_fcolor = "#200040";
	}
	else							// 藍色
	{
		ls_bcolor = "#e0e9f8";
		ls_scolor = "#ffe0e9f8";
		ls_fcolor = "#1f336b";
	}

	var li_Width = 500;
	var li_Height = 400;
	if (navigator.appName == 'Netscape')
	{
		var li_Top = 100;
		var li_Left = 100;
	}
	else
	{
		var li_Top = (screen.availHeight - li_Height) / 2;
		if (li_Top < 0) li_Top = 0;
		var li_Left = (screen.availWidth - li_Width) / 2;
		if (li_Left < 0) li_Left = 0;
	}

	as_Title = top.document.title.replace(" - 登入視窗", "") + " - " + as_Title;

	ls_WinDocument = "<html><head><title>" + as_Title + "</title><style type=\"text/css\">body {    background:" + ls_bcolor + "; padding:5px;    filter:progid:DXImageTransform.Microsoft.Gradient(     GradientType=0,StartColorStr='" + ls_scolor + "', EndColorStr='#ffffffFF');  }  h1 {    font:bold 16px arial,sans-serif; color:" + ls_fcolor + ";     text-align:center; margin:0px;  }  p {    font:14px arial,sans-serif; color:" + ls_fcolor + ";  }</style></head><body><h1>" + as_Title + "</h1><p>" + as_Content + "</p></body></html>";

	if (iw_PopupWin!=null) iw_PopupWin.close();
	iw_PopupWin=window.open('','iw_PopupWin','width=' + li_Width + ',height=' + li_Height + ',top=' + li_Top + ',left=' + li_Left + ',scrollbars=yes,menubar=no,resizable=yes,status=no,toolbar=no,location=no');
	iw_PopupWin.document.write(ls_WinDocument);
}

// =========================================================================
// 函式：開啟 Popup 視窗–fen
// =========================================================================
function uf_OpenWindow(as_URL, as_Name, ai_Width, ai_Height, as_ScrollBar, as_Status)
{
	if (navigator.appName == 'Netscape')
	{
		var li_Top = 50;
		var li_Left = 50;
	}
	else
	{
		var li_Top = (screen.availHeight - ai_Height) / 2;
		if (li_Top < 0) li_Top = 0;
		var li_Left = (screen.availWidth - ai_Width) / 2;
		if (li_Left < 0) li_Left = 0;
	}
	return window.open(as_URL,as_Name,'top=' + li_Top + ',left=' + li_Left + ',width=' + ai_Width + ',height=' + ai_Height + ',scrollbars=' + as_ScrollBar + ',menubar=no,resizable=yes,status=' + as_Status + ',toolbar=no,location=no');
}

// =========================================================================
// 函式：將物件內部語法另外開啟 Popup 視窗進行列印–fen
// =========================================================================
function uf_PrintObject(as_Title, ao_Object, as_Script, ab_outerHTML)
{
	// Check the InValid Value
	if (as_Title == "undefined" || as_Title == null) return;
	if (ao_Object == "undefined" || ao_Object == null) return;
	if (ab_outerHTML == "undefined" || ab_outerHTML == null || typeof(ab_outerHTML) != "boolean") ab_outerHTML = false;

	var ls_WinDocument;
	var li_Width = 10;
	var li_Height = 10;
	if (navigator.appName == 'Netscape')
	{
		var li_Top = 1000;
		var li_Left = 1000;
	}
	else
	{
		var li_Top = screen.availHeight + 100;
		if (li_Top < 0) li_Top = 0;
		var li_Left = (screen.availWidth - li_Width) / 2;
		if (li_Left < 0) li_Left = 0;
	}

	ls_WinDocument = '<html><head><link href="../../proj_css/s_GeneralStyle.css" type="text/css" rel="stylesheet" /><object id="minBtn" type="application/x-oleobject" classid="clsid:adb880a6-d8ff-11cf-9377-00aa003b7a11"><param name="Command" value="minimize" /></object></head><body onLoad="uf_PrintPage()"><h1>' + as_Title + '</h1>' + (ab_outerHTML ? ao_Object.outerHTML : ao_Object.innerHTML) + '</body></html>' + as_Script + '<script language=\'javascript\'>function uf_PrintPage() { minBtn.Click(); window.print(); window.close(); }</script>';

	if (iw_PopupWin!=null) iw_PopupWin.close();
	iw_PopupWin=window.open('','iw_PopupWin','width=' + li_Width + ',height=' + li_Height + ',top=' + li_Top + ',left=' + li_Left + ',scrollbars=no,menubar=no,resizable=no,status=no,toolbar=no,location=no');
	iw_PopupWin.document.write(ls_WinDocument);
	iw_PopupWin.location.reload();
}

// =========================================================================
// 函式：得到 Scroll Bar 位置–WenHui
// =========================================================================
function uf_GetScrollPosition(ao_Obj, ao_HideTop, ao_HideLeft)
{
	if (ao_Obj == null) return;

	if (ao_HideTop != null) ao_HideTop.value = ao_Obj.scrollTop;
	if (ao_HideLeft != null) ao_HideLeft.value = ao_Obj.scrollLeft;
}

// =========================================================================
// 函式：設定 Scroll Bar 位置–WenHui
// =========================================================================
function uf_SetScrollPosition(ao_Obj, ai_Top, ai_Left)
{
	if (ao_Obj == null) return;

	// Not a Number
	if (isNaN(ai_Top)) ai_Top = 0;
	if (isNaN(ai_Left)) ai_Left = 0;

	ao_Obj.scrollTop = ai_Top;
	ao_Obj.scrollLeft = ai_Left;
}


// =========================================================================
// 函式：設定物件高度–fen
// =========================================================================
function uf_SetObjectHeight(ao_Obj, ao_Source, ai_Top, ai_Sub, ai_OverAdd)
{
	if (ao_Obj == null) return;
	if (ao_Source == null) return;

	var li_height;

	if (navigator.appName == 'Netscape')
	{
		if (ao_Source.document.height <= window.innerHeight - ai_Top)
			li_height = window.innerHeight - ai_Top;
		else
			li_height = ao_Source.document.height + ai_OverAdd;
		ao_Obj.height = li_height - ai_Sub;
	}
	else
	{
		if (document.body.clientHeight)
		{
			if (ao_Source.offsetHeight <= document.body.clientHeight - ai_Top)
				li_height = document.body.clientHeight - ai_Top;
			else
				li_height = ao_Source.offsetHeight + ai_OverAdd;
		}
		else
		{
			if (ao_Source.offsetHeight <= document.documentElement.clientHeight - ai_Top)
				li_height = document.documentElement.clientHeight - ai_Top - 12;
			else
				li_height = ao_Source.offsetHeight + ai_OverAdd;
		}
		ao_Obj.style.height = li_height - ai_Sub;
	}
}


// =========================================================================
// 函式：設定跟隨式物件–fen
// =========================================================================
function uf_SetObjectFix(ao_Obj)
{
	if (ao_Obj == null) return;

	if (navigator.appName == 'Netscape')
	{
		uf_SetObjectFixStat(ao_Obj);
	}
	else
	{
		var li_top;
		var li_left;
		if (document.body.clientHeight)
		{
			li_top = document.body.scrollTop + document.body.clientHeight - ao_Obj.offsetHeight;
			li_left = document.body.scrollLeft + document.body.clientWidth - ao_Obj.offsetWidth - 4;
		}
		else
		{
			li_top = document.documentElement.scrollTop + document.documentElement.clientHeight - ao_Obj.offsetHeight - 8;
			li_left = document.documentElement.scrollLeft + document.documentElement.clientWidth - ao_Obj.offsetWidth - 4;
		}
		ao_Obj.style.top = li_top;
		ao_Obj.style.left = li_left;

		// only for this' project
		if (document.all.pic_cancel != null)
		{
			document.all.pic_cancel.style.top = li_top - 68;
			document.all.pic_cancel.style.left = li_left + 180;
		}
	}
}

function uf_SetObjectFixStat(ao_Obj)
{
	var li_top = pageYOffset + window.innerHeight - ao_Obj.document.height;
	var li_left = pageXOffset + window.innerWidth - ao_Obj.document.width - 4;
	ao_Obj.top = li_top;
	ao_Obj.left = li_left;
	setTimeout('uf_SetObjectFixStat(' + ao_Obj + ')', 2);
}


// =========================================================================
// 函式：設定跟隨式物件–fen
// =========================================================================
function uf_SetObjectPageCenter(as_ObjName)
{
	var lo_obj;

	lo_obj = document.getElementById(as_ObjName);
	if (lo_obj == null) return;

	var li_left;

	if (navigator.appName == 'Netscape')
	{
		li_left = (window.innerWidth - ao_Obj.document.width) / 2;
		if (li_left < 10) li_left = 0;
		ao_Obj.left = li_left;
	}
	else
	{
		if (document.body.clientWidth)
			li_left = (document.body.clientWidth - lo_obj.offsetWidth) / 2;
		else
			li_left = (document.documentElement.clientWidth - lo_obj.offsetWidth) / 2;
		if (li_left < 10) li_left = 0;
		lo_obj.style.left = li_left;
	}
}


// =========================================================================
// 函式：取得 IE 瀏覽器的版本–fen
// =========================================================================
function uf_GetAppVersion()
{
	for (var li_i = 0; li_i < 10; li_i++)
	{
		for (var li_j = 0; li_j < 10; li_j++)
		{
			if (navigator.appVersion.match("MSIE " + li_i + "." + li_j) != null)
				return parseFloat(li_i + "." + li_j);
		}
	}
	return 0;
}


// =========================================================================
// 函式：取得 OS 的版本–fen
// =========================================================================
function uf_GetWinVersion()
{
	for (var li_i = 0; li_i < 10; li_i++)
	{
		for (var li_j = 0; li_j < 10; li_j++)
		{
			if (navigator.appVersion.match("Windows NT " + li_i + "." + li_j) != null)
				return parseFloat(li_i + "." + li_j);
		}
	}
	return 0;
}


// =========================================================================
// 函式：取得 IE 瀏覽器適合的寬度–fen
// =========================================================================
function uf_FixWidth(ai_Width)
{
	return ai_Width + (uf_GetAppVersion() < 7 ? 8 : 0);
}


// =========================================================================
// 函式：取得 IE 瀏覽器適合的高度–fen
// =========================================================================
function uf_FixHeight(ai_Height)
{
	// WinXP Height must add 24
	return ai_Height + (uf_GetAppVersion() < 7 ? 28 : 0) + (uf_GetWinVersion() == 5.1 ? 24 : 0);
}
