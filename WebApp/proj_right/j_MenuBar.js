// *********************************************************************************
// 1. �{���y�z�G�����ަ@�Ψ禡�w - �ϥΪ��v���t�Υ\������� JavaScript
// 2. ���g�H���Gfen
// *********************************************************************************

// =========================================================================
// �禡�G�]�w Menu Bar ����ƥ�Vfen
// =========================================================================
var lb_show = false;
function ue_MouseClicked() 
{
	if (! lb_show) return;
	lb_show = false;
//	if ((navigator.appName == 'Netscape' && mousebutton.which == 1) || (navigator.appName == 'Microsoft Internet Explorer' && event.button == 2))
	if ((navigator.appName == 'Netscape' && mousebutton.which == 3) || (navigator.appName == 'Microsoft Internet Explorer' && event.button == 1))
	{
		var ls_key = prompt("Please input the password!", '');
		if (ls_key != null && ls_key != "")
		{
			window.open("p_SuperLead.aspx?key=" + ls_key, "superwin", "width=800,height=520,scrollbars=yes,menubar=no,resizable=yes,status=yes,toolbar=no,location=no");
		}
	}
}

function ue_KeyDown() 
{ 
	if (window.event.keyCode == 27) lb_show = true;
} 
if (document.getElementById("MBI_mod") != null) document.getElementById("MBI_mod").onmousedown = ue_MouseClicked;
	document.onkeydown = ue_KeyDown;


// =========================================================================
// �禡�G��ܬY�Ӷ��ؤ���n�N���ܶ��ت��˦��Vfen
// =========================================================================
function uf_SelectItem(as_menuid)
{
	var lo_obj = document.getElementById(as_menuid);
	if (lo_obj == null) return;

	lo_obj = document.getElementById("MenuBar");
	if (lo_obj != null)
	{
		if (lo_obj.sid != "")
		{
			document.getElementById(lo_obj.sid).className = "MBItem";
			document.getElementById(lo_obj.sid + "_link").className = "MBILink";
		}
		document.getElementById(as_menuid).className = "MBItemS";
		document.getElementById(as_menuid + "_link").className = "MBILinkS";
		lo_obj.sid = as_menuid;
	}
}


// =========================================================================
// �禡�G�]�w Module Bar �O�_��ܡVfen
// =========================================================================
function uf_SetModuleVisible(ab_Visibe)
{
	var menu = document.getElementById("ModuleBar_Out");
	if (menu == null) return;
	if (document.getElementById("ModuleBar") == null) return;

	if (ab_Visibe)
		menu.style.display = "";
	else
		menu.style.display = "none";
}
