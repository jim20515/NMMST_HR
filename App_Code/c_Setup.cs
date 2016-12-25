// *********************************************************************************
// 1. �{���y�z�G�����ަ@�Ψ禡�w�V�M�׳]�w
// 2. ���g�H���Gfen
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project.Invoke
{
	/// <summary>
	/// �����ަ@�Ψ禡�w�V�M�׳]�w
	/// </summary>
	public class Setup
	{
		#region �� Declare Variables -------------------------------------- ���g�H���Gfen

		/// <summary>�ܼƴy�z�G�ާ@�\������ܺ����VTreeView�FPanel</summary>
		public enum MenuTreeKinds { TreeView, Panel };

		#endregion

		// ========================================================================= �� �@��(����)
		/// <summary>�ܼƴy�z�G���ε{���W��</summary>
		static public string is_AppName = "��߮��v��޳ժ��]-�H�O�귽�t��";
		/// <summary>�ܼƴy�z�G���ε{���ϥΪ� ini �ɦW��</summary>
		static public string is_INIFile = "NMMST_HR.ini";

		// ========================================================================= �� PBL
		/// <summary>�ܼƴy�z�G���ε{���ϥΪ� pbl �ɦW��</summary>
		static public string is_PBLFile = "NMMST_HR.pbl";
		/// <summary>�ܼƴy�z�G���D�I���C��</summary>
		static public string is_HeadBackColor = "31383756";
		/// <summary>�ܼƴy�z�G��J�حI���C��</summary>
		static public string is_EditBackColor = "31326207";

		// ========================================================================= �� ��Ʈw
		/// <summary>�ܼƴy�z�G�s�W�H�����W�ٵ����]�w�]�O�u_aid�v�^</summary>
		static public string is_aid = "_aid";
		/// <summary>�ܼƴy�z�G�s�W������W�ٵ����]�w�]�O�u_adt�v�^</summary>
		static public string is_adt = "_adt";
		/// <summary>�ܼƴy�z�G���ʤH�����W�ٵ����]�w�]�O�u_uid�v�^</summary>
		static public string is_chp = "_uid";
		/// <summary>�ܼƴy�z�G���ʤ�����W�ٵ����]�w�]�O�u_udt�v�^</summary>
		static public string is_chd = "_udt";
		/// <summary>�ܼƴy�z�G���ʤH����ƺ����V�n�J�b��(id)�F�W��(name)�F���u�s��(empno)</summary>
		static public string is_chp_vtype = "id";
		/// <summary>�ܼƴy�z�G��Ʈw�O�_�Ϥ��j�p�g</summary>
		static public bool ib_IsDbCaseSensitive = false;
		/// <summary>�ܼƴy�z�G�O�_�ϥαK�X�[�K�޳N</summary>
		static public bool ib_IsPasswdHash = false;

		// ========================================================================= �� ���
		/// <summary>�ܼƴy�z�G�����׸귽��(�ݩ�b App_GlobalResources)</summary>
		static public string is_r_DbColLength = "r_DbColLength";
		/// <summary>�ܼƴy�z�G���r�������귽��(�ݩ�b App_GlobalResources)</summary>
		static public string is_r_DbColCase = "r_DbColCase";

		// ========================================================================= �� ����
		/// <summary>�ܼƴy�z�G�ާ@�\������ܺ����VTreeView�FPanel</summary>
		static public MenuTreeKinds i_MenuTreeKind = MenuTreeKinds.TreeView;
		/// <summary>�ܼƴy�z�G�O�_�ާ@�\��������i�}</summary>
		static public bool ib_IsMenuTreeExpandAll = true;
		/// <summary>�ܼƴy�z�G�ާ@�\����n�i�}���s�զr��զX�]�����H�u,�v�j�} ex."s00,s01,s02"�^</summary>
		static public string is_MenuTreeExpandGroup = "";
		/// <summary>�ܼƴy�z�G�O�_�ϥΥ���~</summary>
		static public bool ib_IsROC = true;
		/// <summary>�ܼƴy�z�G�O�_��ܪ��������T���w�]��</summary>
		static public bool ib_IsShowVersionDefault = true;
		/// <summary>�ܼƴy�z�G�O�_��ܺ��� Title ���w�]��</summary>
		static public bool ib_IsShowTitleDefault = true;
		/// <summary>�ܼƴy�z�G�O�_��ܲŸ���</summary>
		static public bool ib_IsShowSymbol = false;
		/// <summary>�ܼƴy�z�G�O�_�û��Q�� Window.Alert �覡��ܰT��</summary>
		static public bool ib_IsAlwaysAlert = true;
		/// <summary>�ܼƴy�z�G�O�_�ϥ� AJAX Script ���w�]��</summary>
		static public bool ib_IsAJAXScriptDefault = true;
		/// <summary>�ܼƴy�z�G�O�_��ܼh�Ū��ާ@�W��</summary>
		static public bool ib_IsShowLevelFuncName = true;
		/// <summary>�ܼƴy�z�G�O�_��ܤl�t�ΦW��</summary>
		static public bool ib_IsShowSysName = true;
		/// <summary>�ܼƴy�z�G�h�Ū��ާ@�W�٤��j�Ÿ��]�w�]�O�u�O�v�^</summary>
		static public string is_SysFuncNameSplit = " >> ";

		// ========================================================================= �� Dbcfg
		/// <summary>(Dbcfg)�ܼƴy�z�G�ѼƦs��b Cache ���̫�@���s�����O���ɶ�</summary>
		static public int ii_DbcfgCacheDurationMin = 10;
		/// <summary>(Dbcfg)�ܼƴy�z�G�ƧǡB�j�M�M�z��ɦr��O�_�Ϥ��j�p�g</summary>
		static public bool ib_DbcfgIsCaseSensitive = false;
		/// <summary>(Dbcfg)�ܼƴy�z�G�m�S�O�n�Ѽƫ��w�N�X(�~��)���̤p��(����~�Τ��n�p��1912)</summary>
		static public int ii_DbcfgYY_Start = 2002;
		/// <summary>(Dbcfg)�ܼƴy�z�G�m�S�O�n�Ѽƫ��w�N�X(�~��)���̤j��</summary>
		static public int ii_DbcfgYY_End = 2031;
		/// <summary>(Dbcfg)�ܼƴy�z�GDDDW �O�_���ץ��n��J�@�ߴ��J�Ŷ���</summary>
		static public bool ib_IsDDDWAlwaysEmpty = false;
		/// <summary>(Dbcfg)�ܼƴy�z�GDDDW ���J�Ŷ��ت���ܦW��(�@��)</summary>
		static public string is_IsDDDWEmptyText = "�m�п�ܡn";
		/// <summary>(Dbcfg)�ܼƴy�z�GDDDW ���J�Ŷ��ت���ܦW��(�d��)</summary>
		static public string is_IsDDDWEmptyText_Q = "�m�����n";

		// ========================================================================= �� �ҥ~�B�z
		static public Exception LastError;

		#region �� Password Methods --------------------------------------- ���g�H���Gfen

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G���ҨϥΪ̿�J���K�X�O�_���T
		/// </summary>
		/// <param name="as_UserID">�ϥΪ̱b��</param>
		/// <param name="as_KeyinPwd">�ϥΪ̿�J���K�X</param>
		/// <returns>���T(true)�F���~(false)</returns>
		static public bool uf_CheckPasswd(string as_UserID, string as_KeyinPwd)
		{
			// ##### �ŧi�ܼ� #####
			DataSet lds_user;
			string ls_KeyinPwd, ls_SavePwd;
			bool lb_IsPasswdHash = Setup.ib_IsPasswdHash;


			// �̾ڨϥΪ̱b����X�ϥΪ̱K�X
			DbMethods.uf_Retrieve_FromSQL(out lds_user,
				"SELECT IsNull(RTrim(user01_pwd), '')" + (lb_IsPasswdHash ? ", IsNull(RTrim(user01_pwdhash), ''), IsNull(RTrim(user01_pwdsalt), '')" : "") + " " +
					"FROM user01 " +
					"WHERE RTrim(user01_id) = '" + ComMethods.uf_GetSQLInput(as_UserID) + "' ");

			// �P�_�O�_�������
			if (lds_user.Tables[0].Rows.Count > 0)
			{
				// �o��ϥΪ̱K�X
				ls_KeyinPwd = as_KeyinPwd.Trim();
				if (!lb_IsPasswdHash)
				{
					ls_SavePwd = lds_user.Tables[0].Rows[0][0].ToString().Trim();		// user01_pwd
				}
				else
				{
					if (lds_user.Tables[0].Rows[0][1].ToString().Trim() != "")
					{
						WITCrypto lo_Crypto = new WITCrypto();
						lo_Crypto.HexKey = lds_user.Tables[0].Rows[0][2].ToString().Trim();	// user01_pwdsalt
						ls_SavePwd = lo_Crypto.uf_Decrypt(lds_user.Tables[0].Rows[0][1].ToString().Trim());	// user01_pwdhash
						// ���~������
						if (ls_SavePwd == "" && lo_Crypto.uf_Encrypt(ls_SavePwd) != lds_user.Tables[0].Rows[0][1].ToString().Trim())
							ls_SavePwd = "*".PadRight(25, '*');
					}
					else
						ls_SavePwd = "";
				}
			}
			else
			{
				return false;
			}

			// �P�_��X�Ӫ��K�X�O�_���J���ۦP
			if (ls_KeyinPwd == ls_SavePwd)
				return true;
			else
				return false;
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�]�w�ϥΪ̱K�X�]�۰ʲ��ͶüƱK�X�^
		/// </summary>
		/// <param name="as_UserID">�ϥΪ̱b��</param>
		/// <returns>���\(true)�F����(false)</returns>
		static public bool uf_SetPasswd(string as_UserID)
		{
			return uf_SetPasswd(as_UserID, "", true);
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�]�w�ϥΪ̱K�X�]�ϥΪ̫��w�K�X�^
		/// </summary>
		/// <param name="as_UserID">�ϥΪ̱b��</param>
		/// <param name="as_KeyinPwd">�ϥΪ̿�J���K�X</param>
		/// <returns>���\(true)�F����(false)</returns>
		static public bool uf_SetPasswd(string as_UserID, string as_KeyinPwd)
		{
			return uf_SetPasswd(as_UserID, as_KeyinPwd, false);
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�]�w�ϥΪ̱K�X
		/// </summary>
		/// <param name="as_UserID">�ϥΪ̱b��</param>
		/// <param name="as_KeyinPwd">�ϥΪ̿�J���K�X</param>
		/// <param name="ab_IsAutoGen">�O�_�۰ʲ��ͶüƱK�X�V�O(true)�F�_(false)</param>
		/// <returns>���\(true)�F����(false)</returns>
		static private bool uf_SetPasswd(string as_UserID, string as_KeyinPwd, bool ab_IsAutoGen)
		{
			// ##### �ŧi�ܼ� #####
			string ls_Pwd, ls_PwdHash, ls_PwdSalt;
			bool lb_IsPasswdHash = Setup.ib_IsPasswdHash;

			// �P�_�p�G���۰ʲ��ͱK�X
			if (ab_IsAutoGen)
				as_KeyinPwd = ComMethods.uf_CreateSalt(5);

			// �o��ϥΪ̱K�X
			if (!lb_IsPasswdHash)
			{
				ls_Pwd = as_KeyinPwd.Trim();	// user01_pwd
				ls_PwdSalt = "";				// user01_pwdsalt
				ls_PwdHash = "";				// user01_pwdhash
			}
			else
			{
				ls_Pwd = "*****";				// user01_pwd
				WITCrypto lo_Crypto = new WITCrypto();
				lo_Crypto.uf_GenerateKey();
				ls_PwdSalt = lo_Crypto.HexKey;	// user01_pwdsalt
				ls_PwdHash = lo_Crypto.uf_Encrypt(as_KeyinPwd.Trim());	// user01_pwdhash
			}

			// �ק�ϥΪ̱K�X
			if (DbMethods.uf_ExecSQL("UPDATE user01 " +
										"SET user01_pwd = '" + ComMethods.uf_GetSQLInput(ls_Pwd) + "'" + (lb_IsPasswdHash ? ", user01_pwdhash = '" + ls_PwdHash + "', user01_pwdsalt = '" + ls_PwdSalt + "'" : "") + " " +
										"WHERE RTrim(user01_id) = '" + ComMethods.uf_GetSQLInput(as_UserID) + "' ") == 1)
			{
				// ���o�ϥΪ� Email �b���H�o�T���q��
				string ls_Email = Email.uf_GetMailAddr(as_UserID);
				if (ls_Email != "")
					Email.uf_SendMail(ls_Email,
										"�ϥΪ̱b�� " + as_UserID + " ���K�X�w�ק�",
										"�̷s�K�X���y" + as_KeyinPwd.Trim() + "�z�A�U���Шϥηs�K�X�n�J���t�ΡI" + (ab_IsAutoGen ? Email.uf_LineEnter(2) + "���G���K�X���t�ζüƲ��͡A�еn�J���t�ΦA�ۦ�ק�I" : ""));
				return true;
			}
			else
				return false;
		}

		#endregion

	}
}
