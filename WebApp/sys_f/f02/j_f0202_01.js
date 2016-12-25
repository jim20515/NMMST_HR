// *********************************************************************************
// 1. 程式描述：教育訓練管理 － 教育訓練刷卡記錄批次匯入作業 － 批次匯入（JavaScript）
// 2. 撰寫人員：rong
// *********************************************************************************

function uf_Upload()
{
	// Check Input
	var ls_data = document.getElementById("dwU_filepath").value.Trim();
	if (ls_data == "")
	{
		alert("請先選擇匯入檔案！");
		return false;
	}
	
	if (ls_data.substr(ls_data.length - 4).toLowerCase() != ".xls")
	{
		alert("匯入檔案類型需為 Excel 97-2003 活頁簿 (*.xls)！");
		return false;
	}

	return true;
}
