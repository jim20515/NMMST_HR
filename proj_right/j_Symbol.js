// *********************************************************************************
// 1. �{���y�z�G�����ަ@�Ψ禡�w - ���I�Ÿ������ JavaScript
// 2. ���g�H���Gfen
// *********************************************************************************

// =========================================================================
// �禡�G�o����w Frame �W�J�I�Ҧb��m������Vfen
// =========================================================================
var io_focus;
function uf_GetFocus(ao_Frame)
{
	var lo_obj = ao_Frame.document.activeElement;
	if (lo_obj != null && (lo_obj.type == "text" || lo_obj.type == "textarea"))
		io_focus = lo_obj;
}


// =========================================================================
// �禡�G�N���w���ȥ[��J�I���󤺮e���̫᭱�Vfen
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
// �禡�G��ܡ�������ܬY�Ӷ��ؤ���n�N���ܶ��ت��˦��Vfen
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
// �禡�G�]�w Symbol Bar �O�_��ܡVfen
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
