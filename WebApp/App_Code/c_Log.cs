// *********************************************************************************
// 1. �{���y�z�G�n�J�n�X�������ާ@�����B�z�V�M�צ@��
// 2. ���g�H���Gfen
// *********************************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WIT.Template.Project
{
	/// <summary>
	/// �n�J�n�X�������ާ@�����B�z�V�M�צ@��
	/// </summary>
	public class Log
	{
		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�g�J�n�J����
		/// </summary>
		static public void uf_LoginLog()
		{
			if (LoginUser.ID == null) return;

			Page l_Page = (Page)HttpContext.Current.Handler;
			DbMethods.uf_ExecSQL(String.Format("INSERT INTO LoginLog (DeptName, UID, UName, LoginTime, LIP) VALUES ('{0}', '{1}', '{2}', GetDate(), '{3}')", ComMethods.uf_GetSQLInput(LoginUser.DeptName), ComMethods.uf_GetSQLInput(LoginUser.ID), ComMethods.uf_GetSQLInput(LoginUser.Name), l_Page.Request.UserHostAddress));
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�g�J�n�X����
		/// </summary>
		static public void uf_LogoutLog()
		{
			if (LoginUser.ID == null) return;

			Page l_Page = (Page)HttpContext.Current.Handler;
			DbMethods.uf_ExecSQL(String.Format("UPDATE LoginLog SET LogoutTime = GetDate() WHERE L_Id = (SELECT Max(L_Id) FROM LoginLog WHERE UID = '{0}' AND LIP = '{1}' AND LoginTime <= GetDate()) AND LogoutTime is null", ComMethods.uf_GetSQLInput(LoginUser.ID), l_Page.Request.UserHostAddress));
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G���ͥΨӰO���ާ@�O���D��Ȫ� Hidden ����]�Цb Page_Init �I�s�^
		/// </summary>
		/// <param name="a_Page">Page</param>
		static public void uf_AddLogKeysControl(Page a_Page)
		{
			HiddenField lhf_ActionLogKeys = new HiddenField();
			lhf_ActionLogKeys.ID = "ActionLogKeys";
			a_Page.Form.Controls.Add(lhf_ActionLogKeys);
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�O���ާ@�O���D���
		/// </summary>
		/// <param name="a_Page">Page</param>
		/// <param name="aoa_Keys">�D��Ȱ}�C</param>
		static public void uf_SetLogKeysValue(Page a_Page, object[] aoa_Keys)
		{
			string ls_keys = "";

			if (aoa_Keys != null)
			{
				string[] lsa_keys = new string[aoa_Keys.Length];
				for (int li_i = 0; li_i < aoa_Keys.Length; li_i++)
					lsa_keys[li_i] = aoa_Keys[li_i].ToString();
				ls_keys = String.Join(",", lsa_keys);
			}
			//ScriptManager.RegisterHiddenField(a_Page, "ActionLogKeys", ls_keys);	// ���k�L�k������ܹL����

			Control lctl_find = a_Page.FindControl("ActionLogKeys");
			if (lctl_find != null)
				(lctl_find as HiddenField).Value = ls_keys;
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�g�J�ާ@����
		/// </summary>
		/// <param name="context">HttpContext</param>
		/// <param name="as_KeyValues">�D���</param>
		static public void uf_ActionLog(HttpContext context, string as_KeyValues)
		{
			uf_ActionLog(context, as_KeyValues, "");
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�g�J�ާ@����
		/// </summary>
		/// <param name="context">HttpContext</param>
		/// <param name="as_KeyValues">�D���</param>
		/// <param name="as_Action">�D�C�����s�ާ@�W��</param>
		static public void uf_ActionLog(HttpContext context, string as_KeyValues, string as_Action)
		{
			if (LoginUser.ID == null) return;

			// ���oĲ�o PostBack �����
			Control lcto_sender = uf_GetPostBackControl(context);
			if (lcto_sender != null && (lcto_sender is Button || lcto_sender is ImageButton || !String.IsNullOrEmpty(as_Action)))
			{
				// ���o�ާ@�{���W��
				#region Script
				string ls_prgid = LoginUser.MenuID;
				DbMethods.uf_ExecSQL(String.Format("SELECT IsNull((SELECT s04_func_text + '>' FROM sys04 A WHERE RTrim(A.s04_sys_id) + RTrim(A.s04_func_id) = sys04.s04_func_parent), '') + s04_func_text FROM sys04 WHERE s04_sys_id = '{0}' AND s04_func_id = '{1}'", ls_prgid.Split('.')[0], ls_prgid.Split('.')[1].Replace(ls_prgid.Split('.')[0], "")), ref ls_prgid);
				if (String.IsNullOrEmpty(ls_prgid)) return;
				#endregion

				// ���o�ާ@�ʧ@�W��
				#region Script
				if (String.IsNullOrEmpty(as_Action))
				{
					object lo_target = null;
					if (lcto_sender is Button)
					{
						lo_target = HttpContext.GetGlobalResourceObject("r_ButtonImg", ((Button)lcto_sender).CssClass);
					}
					else if (lcto_sender is Button)
					{
						lo_target = HttpContext.GetGlobalResourceObject("r_ButtonImg", ((ImageButton)lcto_sender).CssClass);
					}
					if (lo_target == null) return;
					as_Action = lo_target.ToString();
				}
				#endregion

				string ls_action = "";
				string ls_prgdesc = ls_prgid + "-" + as_Action;

				if (as_KeyValues == null) as_KeyValues = "";

				DbMethods.uf_ExecSQL(String.Format("INSERT INTO ActionLog (DeptName, UID, UName, PRG_ID, ACTION, PRG_DESC, Keys, LDate, LIP) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', GetDate(), '{7}')", ComMethods.uf_GetSQLInput(LoginUser.DeptName), ComMethods.uf_GetSQLInput(LoginUser.ID), ComMethods.uf_GetSQLInput(LoginUser.Name), ls_prgid, ls_action, ls_prgdesc, ComMethods.uf_GetSQLInput(as_KeyValues), context.Request.UserHostAddress));
			}
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G���oĲ�o PostBack ������W��
		/// </summary>
		/// <param name="context">HttpContext</param>
		/// <returns>����W��</returns>
		static public string uf_GetPostBackControlName(HttpContext context)
		{
			Control lcto_sender = uf_GetPostBackControl(context);
			if (lcto_sender != null)
				return lcto_sender.ID;
			else
				return "";
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G���oĲ�o PostBack �����
		/// </summary>
		/// <param name="context">HttpContext</param>
		/// <returns>���</returns>
		static public Control uf_GetPostBackControl(HttpContext context)
		{
			// ##### �ŧi�ܼ� #####
			Control lcto_sender = null;
			Page l_Page = (Page)context.Handler;

			// first we will check the "__EVENTTARGET" because if post back made by the controls 
			// which used "_doPostBack" function also available in Request.Form collection. 
			string ls_ctrlname = context.Request.Params["__EVENTTARGET"];
			if (!String.IsNullOrEmpty(ls_ctrlname))
			{
				lcto_sender = l_Page.FindControl(ls_ctrlname);
			}
			// if __EVENTTARGET is null, the control is a button type and we need to 
			// iterate over the form collection to find it
			else
			{
				Control lcto_tmp = null;

				foreach (string ls_ctl in context.Request.Form)
				{
					// handle ImageButton they having an additional "quasi-property" in their Id which identifies 
					// mouse x and y coordinates
					if (ls_ctl.EndsWith(".x") || ls_ctl.EndsWith(".y"))
					{
						ls_ctrlname = ls_ctl.Substring(0, ls_ctl.Length - 2);
						lcto_tmp = l_Page.FindControl(ls_ctrlname);
					}
					else
					{
						lcto_tmp = l_Page.FindControl(ls_ctl);
					}

					if (lcto_tmp is System.Web.UI.WebControls.Button || lcto_tmp is System.Web.UI.WebControls.ImageButton)
					{
						lcto_sender = lcto_tmp;
						break;
					}
				}
			}

			return lcto_sender;
		}
	}
}
