//// *********************************************************************************
//// 1. �{���y�z�G�����ަ@�Ψ禡�w�V�M�צ@��
//// 2. ���g�H���Gfen
//// *********************************************************************************
//using System;
//using System.Data;
//using System.Text;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace WIT.Template.Project.Invoke
//{
//	/// <summary>
//	/// �����ަ@�Ψ禡�w�V�M�צ@��
//	/// </summary>
//	public class Project
//	{
//		// =========================================================================
//		/// <summary>
//		/// �禡�y�z�G�Q�Ϊ��W�٨��o���W�ٰ_�l�r��
//		/// </summary>
//		/// <param name="as_TableName">���W��</param>
//		/// <returns>���W�ٰ_�l�r��</returns>
//		static public string uf_Get_ColNameStartsWith(string as_TableName)
//		{
//			// �p�G���}�Y�O sys �h�h�e2�X�Y�����W�ٰ_�l�r��
//			if (as_TableName.StartsWith("sys"))
//				as_TableName = as_TableName.Substring(2);

//			return as_TableName;
//		}

//		#region �� Mail Methods ------------------------------------------- ���g�H���Gfen

//		// =========================================================================
//		/// <summary>
//		/// �禡�y�z�G���o���w�ϥΪ̱b���}�C���Ҧ� Email Address �r��]�����H;�j�}�^
//		///	return: Email Address �r��(�����H;�j�})
//		/// </summary>
//		/// <param name="asa_UserID">�ϥΪ̱b���}�C</param>
//		/// <returns>Email Address �r��(�����H;�j�})</returns>
//		static public string uf_GetMailAddr(params string[] asa_UserID)
//		{
//			// ##### �ŧi�ܼ� #####
//			string ls_datastring = "", ls_data;
//			DataSet lds_data;
//			int li_rowcount;

//			// ���~���ǤJ��
//			if (asa_UserID.Length == 0) return "";

//			// ���o�Ҧ��ϥΪ̱b���r��
//			for (int li_row = 0; li_row <= (asa_UserID.Length - 1); li_row++)
//			{
//				// ���o�ϥΪ̱b��
//				ls_data = asa_UserID[li_row].Trim();
//				if (ls_data != "")
//				{
//					if (ls_datastring != "") ls_datastring += "', '";
//					ls_datastring += ComMethods.uf_GetSQLInput(ls_data);
//				}
//			}

//			// �Q�� SQL �y�k���͸�ƶ�
//			DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT user01_email FROM user01 WHERE user01_id in ('" + ls_datastring + "') ");

//			// ���o�`����
//			li_rowcount = lds_data.Tables[0].Rows.Count;

//			// ���o�Ҧ� Email Address �r��
//			ls_datastring = "";
//			for (int li_row = 0; li_row <= (li_rowcount - 1); li_row++)
//			{
//				// ���o Email
//				ls_data = lds_data.Tables[0].Rows[li_row]["user01_email"].ToString().Trim();
//				if (ls_data != "")
//				{
//					if (ls_datastring != "") ls_datastring += ";";
//					ls_datastring += ls_data;
//				}
//			}

//			return ls_datastring;
//		}

//		// =========================================================================
//		/// <summary>
//		/// �禡�y�z�G�q���w�� SMTP Server �ǰe�q�l�l�󥢱ѩҰ����B�z
//		/// </summary>
//		/// <param name="as_MailFrom">�H��̪��q�l�l��a�}</param>
//		/// <param name="as_MailTo">����̪��q�l�l��a�}</param>
//		/// <param name="as_MailSubject">�q�l�l��T�����D��</param>
//		/// <param name="as_MailMessage">Message</param>
//		/// <param name="as_MailException">Exception</param>
//		/// <param name="as_MailInnerException">InnerException</param>
//		static public void uf_SendMailError(string as_MailFrom, string as_MailTo, string as_MailSubject, string as_MailMessage, string as_MailException, string as_MailInnerException)
//		{

//		}

//		#endregion

//		#region �� JavaScript Methods ------------------------------------- ���g�H���Gfen

//		// =========================================================================
//		/// <summary>
//		/// �禡�y�z�G���� JavaScript �y�k
//		/// </summary>
//		/// <param name="ap_Form">����</param>
//		/// <param name="as_Script">JavaScript �y�k(���]�t ScriptTags)</param>
//		/// <param name="ab_IsAJAX">�O�_�ϥ� AJAX�V�O(true)�F�_(false)</param>
//		static public void uf_ClientScript(Page ap_Form, string as_Script, bool ab_IsAJAX)
//		{
//			if (ab_IsAJAX)
//			{
//			    string ls_key = "AJAX";
//			    if (as_Script.ToLower().Contains("alert("))
//			        ls_key += "1";
//			    else if (as_Script.ToLower().Contains(".focus()"))
//			        ls_key += "2";
//			    else
//			        ls_key += "3";
//			    ScriptManager.RegisterStartupScript(ap_Form, ap_Form.GetType(), ls_key + "_" + DateTime.Today.ToString("mmss") + DateTime.Now.Millisecond.ToString(), as_Script, true);
//			}
//			else
//			{
//				//int li_key = DateTime.Now.Millisecond;
//				//while (ap_Form.ClientScript.IsStartupScriptRegistered(ap_Form.GetType(), "NoAJAX_" + DateTime.Today.ToString("mmss") + li_key.ToString()))
//				//    li_key++;
//				//ap_Form.ClientScript.RegisterStartupScript(ap_Form.GetType(), "NoAJAX_" + DateTime.Today.ToString("mmss") + li_key.ToString(), "<script language=\"JavaScript\" type=\"text/javascript\">\n" + as_Script + "\n" + "</script>\n");
//				Literal litr_Script = new Literal();
//				litr_Script.Text = "<script language=\"JavaScript\" type=\"text/javascript\">\n" + as_Script + "\n" + "</script>\n";
//				ap_Form.Controls.Add(litr_Script);
//			}
//		}

//		// =========================================================================
//		/// <summary>
//		/// �禡�y�z�G���� JavaScript �y�k
//		/// </summary>
//		/// <param name="ac_Control">���</param>
//		/// <param name="as_Script">JavaScript �y�k(���]�t ScriptTags)</param>
//		/// <param name="ab_IsAJAX">�O�_�ϥ� AJAX�V�O(true)�F�_(false)</param>
//		static public void uf_ControlScript(Control ac_Control, string as_Script, bool ab_IsAJAX)
//		{
//			if (ab_IsAJAX)
//			{
//			    string ls_key = ac_Control.ClientID + "AJAX";
//			    if (as_Script.ToLower().Contains("alert("))
//			        ls_key += "1";
//			    else if (as_Script.ToLower().Contains(".focus()"))
//			        ls_key += "2";
//			    else
//			        ls_key += "3";
//			    ScriptManager.RegisterStartupScript(ac_Control, ac_Control.GetType(), ls_key + "_" + DateTime.Today.ToString("mmss") + DateTime.Now.Millisecond.ToString(), as_Script, true);
//			}
//			else
//			{
//				Literal litr_Script = new Literal();
//				litr_Script.Text = "<script language=\"JavaScript\" type=\"text/javascript\">\n" + as_Script + "\n" + "</script>\n";
//				ac_Control.Controls.Add(litr_Script);
//			}
//		}

//		#endregion

//	}
//}
