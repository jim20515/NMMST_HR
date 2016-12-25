// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 標點符號表相關 JavaScript
// 2. 撰寫人員：fen
// *********************************************************************************

// =========================================================================
// 函式：得到指定 Frame 上焦點所在位置的物件–fen
// =========================================================================
var io_focus;
function uf_GetFocus(ao_Frame)
{
	var lo_obj = ao_Frame.document.activeElement;
	if (lo_obj != null && (lo_obj.type == "text" || lo_obj.type == "textarea"))
		io_focus = lo_obj;
}


// =========================================================================
// 函式：將指定的值加到焦點物件內容的最後面–fen
// =========================================================================
function uf_Insert(as_Value)
{
	if (io_focus != null)
	{
		io_focus.focus();
		io_focus.value += as_Value;
	}
}


// =========================================================================
// 函式：選擇／取消選擇某個項目之後要將改變項目的樣式–fen
// =========================================================================
function uf_SelectItem(as_ItemID, ab_Selected)
{
	var lo_obj;
	
	lo_obj = document.getElementById(as_ItemID);
	if (lo_obj != null)
	{
		if (ab_Selected)
			lo_obj.className = "SBItemS";
		else
			lo_obj.className = "SBItem";
	}
}


// =========================================================================
// 函式：設定 Symbol Bar 是否顯示–fen
// =========================================================================
function uf_SetSymbolVisible(ab_Visibe)
{
	var lo_div = document.getElementById("Symbol_Out");
	if (lo_div == null) return;
	if (document.getElementById("Symbol") == null) return;

	if (ab_Visibe)
		lo_div.style.display = "";
	else
		lo_div.style.display = "none";
}
