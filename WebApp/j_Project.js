// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 專案相關 JavaScript
// 2. 撰寫人員：fen
// *********************************************************************************

// ----------------------------------------------------------------- ☆ 特定函式


// =========================================================================
// 函式：切換 sysfunc 使用者權限操作功能標題頁的操作項目 – fen
// =========================================================================
function uf_SelectFrame(ai_frameno)
{
	if (top.menuleadFrame.funcFrame != null)
		top.menuleadFrame.funcFrame.uf_ShowFrame(is_rootpath, ai_frameno);
}

function uf_SelectFrame(ai_frameno, as_argument)
{
	if (top.menuleadFrame.funcFrame != null)
		top.menuleadFrame.funcFrame.uf_ShowFrame(is_rootpath, ai_frameno, as_argument);
}

function uf_SelectFrameStop()
{
	if (top.menuleadFrame.funcFrame != null)
		top.menuleadFrame.funcFrame.ib_stop = true;
}


// ----------------------------------------------------------------- ☆ 共用函式

// =========================================================================
// 函式：字串控制項–依種類轉換大寫(U)或小寫(L)或不轉換(其他)–fen
// =========================================================================
function uf_GetTextCase(ao_value_text, as_casekind)
{
	if (ao_value_text == null) return false;

	// No Input
	if (ao_value_text.value == "") return true;

	switch (as_casekind.toUpperCase())
	{
		case "U" :
			// Get UpperCase Text
			ao_value_text.value = ao_value_text.value.toUpperCase();
			return true;

		case "L" :
			// Get LowerCase Text
			ao_value_text.value = ao_value_text.value.toLowerCase();
			return true;
			
		default :
			return true;
	}
}


// =========================================================================
// 函式：日期控制項–西元年–fen
// =========================================================================
function uf_GetDateTime(ao_value_dt)
{
	if (ao_value_dt == null) return false;

	// No Input
	if (ao_value_dt.value == "") return true;
	if (ao_value_dt.Mask != null && ao_value_dt.Mask != "undefined" && ao_value_dt.Mask != "")
	{
		if (ao_value_dt.value == ao_value_dt.Mask) return true;
	}

	// Convert date split character
	ao_value_dt.value = ao_value_dt.value.replace(" ", "/");
	ao_value_dt.value = ao_value_dt.value.replace(" ", "/");
	ao_value_dt.value = ao_value_dt.value.replace("-", "/");
	ao_value_dt.value = ao_value_dt.value.replace("-", "/");

	// Not a Date will be next valid date
	ldt_date = new Date(ao_value_dt.value);

	// Not a Number
	if (isNaN(ldt_date))
	{
		ao_value_dt.value = "";
		window.alert("輸入無效的日期!");
		ao_value_dt.focus();
		return false;
	}

	var li_year = ldt_date.getFullYear();
	var li_month = ldt_date.getMonth() + 1;
	var li_day = ldt_date.getDate();
	var ls_date = li_year + "/" + (li_month >= 10 ? '': '0') + li_month + "/" + (li_day >= 10 ? '': '0') + li_day;

	var li_hour = ldt_date.getHours();
	var li_min = ldt_date.getMinutes();
	var li_sec = ldt_date.getSeconds();
	
	// Get Time
	if (li_hour != 0 || li_min != 0 || li_sec != 0)
		ls_date += " " + (li_hour >= 10 ? '': '0') + li_hour + ":" + (li_min >= 10 ? '': '0') + li_min + ":" + (li_sec >= 10 ? '': '0') + li_sec;

	// Get MinValue
	if (ao_value_dt.MinValue != null
		&& ao_value_dt.MinValue != "undefined"
		&& ao_value_dt.MinValue != "")
	{
		ldt_min = new Date(ao_value_dt.MinValue);

		// Small than MinValue
		if (ldt_date < ldt_min)
		{
			ao_value_dt.value = ao_value_dt.MinValue;
			window.alert("輸入值必須在 " + ao_value_dt.MinValue + " (含)以上!");
			ao_value_dt.focus();
			return false;
		}
	}

	// Get MaxValue
	if (ao_value_dt.MaxValue != null
		&& ao_value_dt.MaxValue != "undefined"
		&& ao_value_dt.MaxValue != "")
	{
		ldt_max = new Date(ao_value_dt.MaxValue);

		// Large than MaxValue
		if (ldt_date > ldt_max)
		{
			ao_value_dt.value = ao_value_dt.MaxValue;
			window.alert("輸入值必須在 " + ao_value_dt.MaxValue + " (含)以下!");
			ao_value_dt.focus();
			return false;
		}
	}

	// Get ValidDate
	ao_value_dt.value = ls_date;
	return true;
}

// =========================================================================
// 函式：日期控制項–民國年–fen
// =========================================================================
function uf_GetDateTime_ROC(ao_value_dt)
{
	if (ao_value_dt == null) return false;

	// No Input
	if (ao_value_dt.value == "") return true;
	if (ao_value_dt.Mask != null && ao_value_dt.Mask != "undefined" && ao_value_dt.Mask != "")
	{
		if (ao_value_dt.value == ao_value_dt.Mask) return true;
	}

	// Not a Date will be next valid date
	ldt_date = new uf_YYY_To_YYYY(ao_value_dt.value);

	// Not a Number
	if (isNaN(ldt_date))
	{
		ao_value_dt.value = "";
		window.alert("輸入無效的日期!");
		ao_value_dt.focus();
		return false;
	}

	// Get MinValue
	if (ao_value_dt.MinValue != null
		&& ao_value_dt.MinValue != "undefined"
		&& ao_value_dt.MinValue != "")
	{
		ldt_min = new Date(ao_value_dt.MinValue);

		// Small than MinValue
		if (ldt_date < ldt_min)
		{
			ao_value_dt.value = uf_YYYY_To_YYY(ldt_min);
			window.alert("輸入值必須在 " + ao_value_dt.value + " (含)以上!");
			ao_value_dt.focus();
			return false;
		}
	}

	// Get MaxValue
	if (ao_value_dt.MaxValue != null
		&& ao_value_dt.MaxValue != "undefined"
		&& ao_value_dt.MaxValue != "")
	{
		ldt_max = new Date(ao_value_dt.MaxValue);

		// Large than MaxValue
		if (ldt_date > ldt_max)
		{
			ao_value_dt.value = uf_YYYY_To_YYY(ldt_max);
			window.alert("輸入值必須在 " + ao_value_dt.value + " (含)以下!");
			ao_value_dt.focus();
			return false;
		}
	}

	// Get ValidDate
	ao_value_dt.value = uf_YYYY_To_YYY(ldt_date);
	return true;
}

// =========================================================================
// 函式：將民國年字串轉換成西元年–fen
// =========================================================================
function uf_YYY_To_YYYY(as_YYY)
{
	var ls_yyyy = "";

	// Find first year split character
	var li_find = as_YYY.indexOf("/");
	if (li_find < 0) li_find = as_YYY.indexOf(" ");
	if (li_find < 0) li_find = as_YYY.indexOf("-");
	if (li_find < 0) li_find = as_YYY.indexOf(".");

	// 將民國年轉換成西元年
	if (li_find >= 0)
		ls_yyyy = (as_YYY.substring(0, li_find) / 1 + 1911) + as_YYY.substring(li_find);

	ls_yyyy = ls_yyyy.replace(" ", "/");
	ls_yyyy = ls_yyyy.replace(" ", "/");
	ls_yyyy = ls_yyyy.replace("-", "/");
	ls_yyyy = ls_yyyy.replace("-", "/");
	ls_yyyy = ls_yyyy.replace(".", "/");
	ls_yyyy = ls_yyyy.replace(".", "/");

	// Not a Date will be next valid date
	ldt_date = new Date(ls_yyyy);

	return ldt_date;
}

// =========================================================================
// 函式：將西元年轉換成民國年字串(需為合法日期)–fen
// =========================================================================
function uf_YYYY_To_YYY(adt_YYYY)
{
	var ls_yyy = "";

	var li_year = adt_YYYY.getFullYear();
	var li_month = adt_YYYY.getMonth() + 1;
	var li_day = adt_YYYY.getDate();
	var ls_yyy = ((li_year - 1911) >= 100 ? '' :  ((li_year - 1911) >= 10 ? '0' : '00')) + (li_year - 1911) + "/" + (li_month >= 10 ? '' : '0') + li_month + "/" + (li_day >= 10 ? '' : '0') + li_day;

	var li_hour = adt_YYYY.getHours();
	var li_min = adt_YYYY.getMinutes();
	var li_sec = adt_YYYY.getSeconds();
	
	// Get Time
	if (li_hour != 0 || li_min != 0 || li_sec != 0)
		ls_yyy += " " + (li_hour >= 10 ? '': '0') + li_hour + ":" + (li_min >= 10 ? '': '0') + li_min + ":" + (li_sec >= 10 ? '': '0') + li_sec;

	return ls_yyy;
}

// =========================================================================
// 函式：數量控制項、以屬性 NumScale (小數以下幾位)得到四捨五入的值–fen
// =========================================================================
function uf_GetNumeric(ao_value_amt)
{
	if (ao_value_amt == null) return false;

	// No Input
	if (ao_value_amt.value == "") return true;

	// Not a Number
	if (isNaN(ao_value_amt.value))
	{
		ao_value_amt.value = "";
		window.alert("輸入無效的字元!");
		ao_value_amt.focus();
		return false;
	}

	// Get MinValue
	if (ao_value_amt.MinValue != null
		&& ao_value_amt.MinValue != "undefined"
		&& ao_value_amt.MinValue != ""
		&& ! isNaN(ao_value_amt.MinValue))
	{
		// Small than MinValue
		if (parseInt(ao_value_amt.value) < parseInt(ao_value_amt.MinValue))
		{
			if (ao_value_amt.MinValue == 0)
			{
				ao_value_amt.value = "";
				window.alert("輸入值必須在 0 (含)以上!");
			}
			else
			{
				ao_value_amt.value = ao_value_amt.MinValue;
				window.alert("輸入值必須在 " + ao_value_amt.MinValue + " (含)以上!");
			}
			ao_value_amt.focus();
			return false;
		}
	}

	// Get MaxValue
	if (ao_value_amt.MaxValue != null
		&& ao_value_amt.MaxValue != "undefined"
		&& ao_value_amt.MaxValue != ""
		&& ! isNaN(ao_value_amt.MaxValue))
	{
		// Large than MaxValue
		if (parseInt(ao_value_amt.value) > parseInt(ao_value_amt.MaxValue))
		{
			ao_value_amt.value = ao_value_amt.MaxValue;
			window.alert("輸入值必須在 " + ao_value_amt.MaxValue + " (含)以下!");
			ao_value_amt.focus();
			return false;
		}
	}

	// Get Numeric Scale
	var li_float = 0;
	if (ao_value_amt.NumScale != null
		&& ao_value_amt.NumScale != "undefined"
		&& ao_value_amt.NumScale != "")
		li_float = ao_value_amt.NumScale;

	// Calculate Math Round
	ao_value_amt.value = uf_MathRound(ao_value_amt.value, li_float);
	return true;
}

// =========================================================================
// 函式：利用數量、小數以下幾位得到四捨五入的值–fen
// =========================================================================
function uf_MathRound(adc_Value, ai_float)
{
	// Check Error Input
	if (isNaN(adc_Value)) return "";
//	if (adc_Value < 0) return "";
	if (isNaN(ai_float)) return "";

	// Calculate Math Round
	if (ai_float <= 0)
		return Math.round(adc_Value);
	else
		return Math.round(adc_Value * Math.pow(10, ai_float)) / Math.pow(10, ai_float);
}

// =========================================================================
// 函式：判斷資料是否有值 – fen
// =========================================================================
function uf_IsInput(ao_Value)
{
	if (ao_Value == "undefined" || ao_Value == null || Trim(ao_Value) == "")
		return false;
	else
		return true;
}

// =========================================================================
// 函式：將空值轉成空字串 – fen
// =========================================================================
function uf_Null_To_Empty(ao_Value)
{
	if (ao_Value == "undefined" || ao_Value == null)
		return "";
	else
		return Trim(ao_Value);
}

// =========================================================================
// 函式：字串去空白(含 &nbsp; ASCII(160)=A0)及處理自訂函式 – fen
// =========================================================================
String.prototype.Trim  = function() {if (this == null) return null; else return this.replace(/(^\s*)|(\s*$)/g,"").replace(/(^\xa0*)|(\xa0*$)/g,"");}
String.prototype.LTrim = function() {if (this == null) return null; else return this.replace(/(^\s*)/g, "").replace(/(^\xa0*)/g, "");}
String.prototype.RTrim = function() {if (this == null) return null; else return this.replace(/(\s*$)/g, "").replace(/(\xa0*$)/g, "");}

function Trim(ao_Value)
{
	if (ao_Value == null || typeof(ao_Value) != "string") return ao_Value;

//	return ao_Value.replace(/(^\s*)|(\s*$)/g,"");
	return ao_Value.replace(/(^\s*)|(\s*$)/g,"").replace(/(^\xa0*)|(\xa0*$)/g,"");
}

function LTrim(ao_Value)
{
	if (ao_Value == null || typeof(ao_Value) != "string") return ao_Value;
	
//	return ao_Value.replace(/(^\s*)/g, "");
	return ao_Value.replace(/(^\s*)/g, "").replace(/(^\xa0*)/g, "");
}

function RTrim(ao_Value)
{
	if (ao_Value == null || typeof(ao_Value) != "string") return ao_Value;
	
//	return ao_Value.replace(/(\s*$)/g, "");
	return ao_Value.replace(/(\s*$)/g, "").replace(/(\xa0*$)/g, "");
}

// =========================================================================
// 函式：判斷查語用資料是否正確（不含特殊字元） – fen
// =========================================================================
function uf_Check_QueryValue(ao_value_str)
{
	if (ao_value_str == null) return false;

	if (ao_value_str.value == "undefined" || ao_value_str.value == null || typeof(ao_value_str.value) != "string" || Trim(ao_value_str.value) == "") return true;

	if (ao_value_str.value.match(/['"~;]/i) != null)
	{
		ao_value_str.value = "";
		window.alert("輸入不合法的字元「' \" ~ ;」！");
		ao_value_str.focus();
		return false;
	}
	else
	{
		if (ao_value_str.value.match(/OR |AND /i) != null)
		{
			ao_value_str.value = "";
			window.alert("輸入不合法的字串「OR AND」！");
			ao_value_str.focus();
			return false;
		}
		else
		{
			return true;
		}
	}
}

// =========================================================================
// 函式：判斷資料長度是否超出指定長度 – fen
// =========================================================================
function uf_Check_MaxLength(as_Value, ai_maxlength)
{
	if (typeof(as_Value) != "string") return true;
	if (typeof(ai_maxlength) != "number" || ai_maxlength == 0) return true;
	if (uf_ByteLength(as_Value) > ai_maxlength)
	{
		window.alert("輸入的內容超出此欄位長度 " + ai_maxlength + "（中文字長度算 2）！");
		return false;
	}  
	else
	{
		return true;
	}
}

// =========================================================================
// 函式：中文判斷為兩個字元的 subString – fen
// =========================================================================
function uf_SubString(as_orgString, ai_endindex)
{
	var ls_newString = "";
	var li_result = 0;

	for (var li_i = 0; li_i < as_orgString.length; li_i++)
	{
		if (as_orgString.charCodeAt(li_i) >= 128)
		{
			// Non 7-bit char, count 2 bytes
			li_result += 2;
		}
		else
		{
			// 7-bit char
			li_result++;
		}
	  
		if(li_result < ai_endindex)	 ls_newString += as_orgString.charAt(li_i);
	}
	return ls_newString;
}

// =========================================================================
// 函式：判斷字串實際長度，中文可分辨為兩個字元 – fen
// =========================================================================
function uf_ByteLength(as_Value)
{
	// For single byte browser, string length = no. of byte
	if ("中".length == 2)  return as_Value.length;
	
	// For double byte browser
	var li_result = 0;
	for (var li_i = 0; li_i < as_Value.length; li_i++)
	{
		if (as_Value.charCodeAt(li_i) >= 128)
		{
			// Non 7-bit char, count 2 bytes
			li_result += 2;
		}
		else
		{
			// 7-bit char
			li_result++;
		}
	}
	return li_result;
}

// =========================================================================
// 函式：檢查身分證字號 –Wenchung
// =========================================================================
function uf_Check_Id(ao_Obj)
{
	//檢查身分證字號
	//欄位參數ao_Obj :檢查的身分證欄位
	//回傳型態:boolean
	
	//null檢驗
	if (ao_Obj == null){
		return true;
	}
	else{
		var t= "ABCDEFGHJKLMNPQRSTUVXYWZIO";
		s = ao_Obj.value;
		c= s.substring(0,1);
		c2 = s.substring(1,10);
		
		if (s == ''){
		//沒填--不做任何處理
		return true;
		}
		else{
			ao_Obj.value = c.toUpperCase() + c2;
			//alert(ao_Obj.value);
			c= t.indexOf(c.toUpperCase());
			if((s.length!= 10) || (c<0)){ 
				ao_Obj.focus();
				alert('輸入錯誤\n'+'長度不符未滿十碼!!');
				return false;
			}
			n= parseInt(c/10)+ c%10*9+ 1;
			for(i=1; i<9; i++) n= n+ parseInt(s.substring(i,i+1))* (9-i);
			n= (10- (n% 10))% 10;
			if(n!= parseInt(s.substring(9,10))) {
				ao_Obj.focus();
				alert('輸入錯誤\n'+'不是有效的身分證字號!!');
				return false;
			}
			return true;
		}
	}
}

// =========================================================================
// 函式：開啟 Crystal Report Viewer 視窗 – Wenchung (Modified by fen)
// 參數：01.as_ReportPath	string		顯示報表來源路徑(從「../App_Data/Report/」之後開始指定)
//       02.as_Arguments	string		查詢參數值字串組合(中間以(;)隔開)
//       03.as_CRSelection	string		Crystal Report Select Expert 資料取出語法
//       04.as_Type			string		開啟報表種類–Crystal viewer(crs／空字串)；PDf檔(pdf)；Debug(dbg)
// =========================================================================
function uf_report(as_ReportPath, as_Arguments, as_CRSelection, as_vType)
{
	//  將 Select Expert 的語法轉換成 Unicode 碼字串，中間以(,)隔開
	as_CRSelection = uf_ConvertTo(as_CRSelection);

	// 將查詢參數值轉換成 Unicode 碼字串，中間以(,)隔開
	as_Arguments = uf_ConvertTo(as_Arguments);

	// 開啟 Report 視窗
	var lw_win = uf_OpenWindow("", "crReport", 800, screen.availHeight, "yes", "yes");
	var lo_form = uf_createForm(is_rootpath + "proj_uctrl/p_crReport.aspx", lw_win.name);
	uf_createHidden(lo_form, "Report", as_ReportPath);
	uf_createHidden(lo_form, "Addsql", "");
	uf_createHidden(lo_form, "Argument", as_Arguments);
	uf_createHidden(lo_form, "CRSelection", as_CRSelection);
	uf_createHidden(lo_form, "vType", as_vType);
	uf_submitForm(lo_form);
	lw_win.focus();
}

// =========================================================================
// 函式：開啟 ReportServices 視窗(參數過長時使用) – rong
// 參數：01.as_ReportPath	string		顯示報表來源路徑
//       02.as_Type			string		開啟報表種類
//       03.as_Arguments	string		查詢參數值字串組合
// =========================================================================
function uf_rsreport(as_ReportPath, as_vType, as_Arguments)
{
	//  將 Select Expert 的語法轉換成 Unicode 碼字串，中間以(,)隔開
	//as_CRSelection = uf_ConvertTo(as_CRSelection);

	// 將查詢參數值轉換成 Unicode 碼字串，中間以(,)隔開
	//as_Arguments = uf_ConvertTo(as_Arguments);

	// 開啟 Report 視窗
	var lw_win = uf_OpenWindow("", "ReportServices", 1024, screen.availHeight, "no", "no");
	var lo_form = uf_createForm(is_rootpath + "proj_uctrl/p_render.aspx", lw_win.name);
	uf_createHidden(lo_form, "path", as_ReportPath);
	uf_createHidden(lo_form, "format", as_vType);
	uf_createHidden(lo_form, "query", as_Arguments);
	uf_submitForm(lo_form);
	lw_win.focus();
}

function uf_ConvertTo(ao_Value)
{
	// ##### 宣告變數 #####
	var ls_value = ao_Value + "";
	var ls_return = "";

	// 將值轉換成 Unicode 碼字串，中間以(,)隔開
	for (var li_i = 0; li_i < ls_value.length; li_i++)
	{
		if (li_i > 0) ls_return += ",";
		ls_return += ls_value.charCodeAt(li_i);
	}

	return ls_return;
}

// =========================================================================
// 函式：動態產生 form 進行 submit 用相關函式– fen
// 參考：本文件的 uf_report
// =========================================================================
function uf_createForm(as_Action, as_Target)
{
	var lo_form = document.createElement("form");
	with (lo_form)
	{
		style.display = "none";
		name = "submitDynamic";
		method = "post";
		action = as_Action;
		target = as_Target;
	}
	return lo_form;
}

function uf_createHidden(ao_form, as_Name, as_Value)
{
	var lo_obj = document.createElement("input");
	with (lo_obj) { type="hidden"; name=as_Name; value=as_Value; }

	ao_form.appendChild(lo_obj);
}

function uf_submitForm(ao_form)
{
	// Add to document
	for (var li_i = document.childNodes.length - 1; li_i >= 0; --li_i)
	{
		if (document.childNodes[li_i].nodeType == 1)	// HTML
		{
			document.childNodes[li_i].appendChild(ao_form);
			break;
		}
	}

	ao_form.submit();

	// Remove from document
	document.childNodes[li_i].removeChild(ao_form);
}

// =========================================================================
// 函式：連結到傳回檔案內容的網頁並強制顯示檔案下載對話框 – fen
// 參數：01.as_URL			string		連結網頁的完整 URL(視實際情形帶參數)
//       02.as_Type			string		檢視種類(可不傳)–正常(空字串)：預設；Debug(dbg)
// =========================================================================
function uf_DownLoad(as_URL, as_Type)
{
	if (as_URL == "undefined" || as_URL == null || typeof(as_URL) != "string") as_URL = "about:blank";
	if (as_Type == "undefined" || as_Type == null || typeof(as_Type) != "string") as_Type = "";

	// 動態產生 iframe 連到 DownLoad 網頁
	var lo_iframe = document.createElement("iframe");
	with (lo_iframe)
	{
		src = as_URL;
		style.zIndex = 999;
		style.position = "absolute";
		style.display = "none";
	}

	if (as_Type == "dbg")
		lo_iframe.style.display = "";

	// Add iframe to document
	var lo_panel = document.getElementById("pn_Contain");
	if (lo_panel != null)
		lo_panel.appendChild(lo_iframe);
	else
		document.body.appendChild(lo_iframe);
}

// ----------------------------------------------------------------- ☆ 特定專案

// =========================================================================
// 函式：開啟 02 Frame 視窗 – fen
// =========================================================================
function uf_LinkFrame(as_url, as_Frame, as_args)
{
	var lo_form = uf_createForm(as_url, as_Frame);
	uf_createHidden(lo_form, "args", as_args);
	uf_submitForm(lo_form);
}

// =========================================================================
// 函式：計算訊息則數–demon
// =========================================================================
function uf_CountMsg(ao_value)
{
	if (ao_value == null) return 0;

	// No Input
	if (ao_value.value == "") return 0;
	
	var li_return = 0 , li_length = 0;

	// Not a Number
	if (uf_ByteLength(ao_value.value) == ao_value.value.length) //相等代表都是英文，160字元為一則
	{
	    li_length = uf_ByteLength(ao_value.value);
	    if (li_length % 160 > 0)
            li_return = Math.floor(li_length / 160) + 1;
        else
            li_return = li_length / 160;
	}
	else
	{
	    li_length = ao_value.value.length;
	    if (li_length % 70 > 0)
            li_return = Math.floor(li_length / 70) + 1;
        else
            li_return = li_length / 70;
	}
	return li_return;
}
