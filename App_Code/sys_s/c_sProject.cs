// *********************************************************************************
// 1. �{���y�z�G�t�κ޲z�V�M�צ@��
// 2. ���g�H���Gfen
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project.sys_s
{
	/// <summary>
	/// �t�κ޲z�V�M�צ@��
	/// </summary>
	public class sProject
	{
		#region �� �s���B�z Methods --------------------------------------- ���g�H���Gfen

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G���X�M�׸�Ʈw�t�νs��
		/// </summary>
		/// <param name="as_nokind">�n���o�t�νs��������</param>
		/// <param name="as_startswith">�t�νs���}�l�W��X</param>
		/// <returns>�t�νs��(���Ʈw�̤j�s�X�A�[�W 1)</returns>
		static public string uf_Get_SystemNo(string as_nokind, string as_startswith)
		{
			// ##### �ŧi�ܼ� #####
			string		ls_sql = "";
			string		ls_no, ls_maxno = null;
			int			li_len = 0, li_flen = 0;	// li_len�G�y���������סAli_flen�G�s���W��X������
			string[]	lsa_startswith;

			// �P�_�ǤJ�ѼƬO�_���T
			if (as_nokind == null)
				as_nokind = "";

			if (as_startswith == null)
				as_startswith = "";
			
			// ���� as_startswith ��}�C��
			lsa_startswith = as_startswith.Split(',');
			
			// �P�_�O���ӽs���A�]�w���X�̤j�s�����覡 -------------- �� 1
			switch (as_nokind.ToLower())
			{

				// ------------------------------------------------- �� ���i�s��
				// �褸�~(4��) + ��(2��) + ��(2��) + �y����(2��)
				case "sys07.s07_no" :

					// �o��W��X������
					as_startswith = DbMethods.uf_GetDate().ToString("yyyyMMdd");
					li_flen = as_startswith.Length;

					li_len = 2;			// �y���� 2 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT IsNull(Max(SubString(s07_no, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
								"FROM sys07 " +
								"WHERE SubString(s07_no, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

					break;

				// ------------------------------------------------- �� �{����X�֭��v����y����
				// �y����(int)
				case "trc36.c36_seq_no" :

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(c36_seq_no), 0)) as no " +
								"FROM trc36 " +
								"WHERE c36_com_code = " + lsa_startswith[0] + " " +
									"AND c36_sc_code = '" + lsa_startswith[1] + "' ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- �� �״ڧǸ�
				// �褸�~(4��) + ��(2��) + ��(2��) + �y����(4��)
				case "trm04.m04_output_no" :

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 4;			// �y���� 4 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT IsNull(Max(SubString(m04_output_no, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
								"FROM trm04 " +
								"WHERE SubString(m04_output_no, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

					break;

				// ------------------------------------------------- �� �I�ڼf�ֳ�����Ǹ�
				// �y����(smallint)
				case "trm09.m09_seq_no" :

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(m09_seq_no), 0)) as no " +
								"FROM trm09 " +
								"WHERE m09_com_code = " + lsa_startswith[0] + " " +
									"AND m09_bill_no = " + lsa_startswith[1] + " ";

					// �M�����W��X
					as_startswith = "";

					break;

				default :
					break;
			}

			// ��ڨ��X�̤j�s������� ------------------------------ �� 2
			DbMethods.uf_ExecSQL(ls_sql, ref ls_maxno);

			// �P�_�O�_�����ŦX�����
			ls_maxno = ls_maxno.Trim();

			// �P�_�O�_���̤j���s���A�S���h�q 1 �}�l --------------- �� 3
			if (ls_maxno == null || ls_maxno == "")				// ��椤�S�����
				ls_no = as_startswith + Convert.ToString(1).PadLeft(li_len, '0');
			else
				ls_no = as_startswith + Convert.ToString(Convert.ToInt64(ls_maxno) + 1).PadLeft(li_len, '0');

			return ls_no;
		}

		#endregion

		#region �� ��Ƨ�M Methods --------------------------------------- ���g�H���Gfen

		#endregion

	}
}
