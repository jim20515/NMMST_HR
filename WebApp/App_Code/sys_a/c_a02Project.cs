// *********************************************************************************
// 1. �{���y�z�G�t�κ޲z�V�M�צ@��
// 2. ���g�H���GJing
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// �t�κ޲z�V�M�צ@��
	/// </summary>
	public class a02Project
	{
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

				// ------------------------------------------------- �� �H�����O�N�X
				// �y����(smallint)
				case "hca201.hca201_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca201_id), 0)) as no " +
								"FROM hca201 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- �� ���u�����N�X
				// �y����(smallint)
				case "hca202.hca202_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca202_id), 0)) as no " +
								"FROM hca202 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- �� �Ǿ��N�X
				// �y����(smallint)
				case "hca203.hca203_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca203_id), 0)) as no " +
								"FROM hca203 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- �� ¾�~�N�X
				// �y����(smallint)
				case "hca204.hca204_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca204_id), 0)) as no " +
								"FROM hca204 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- �� �q�T�a�}�N�X
				// �y����(smallint)
				case "hca205.hca205_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca205_id), 0)) as no " +
								"FROM hca205 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- ���Ӥu���ťN�X
				// �y����(smallint)
				case "hca206.hca206_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca206_id), 0)) as no " +
								"FROM hca206 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- ���Ӥu�N�X
				// �y����(smallint)
				case "hca207.hca207_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca207_id), 0)) as no " +
								"FROM hca207 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- ��������]�N�X
				// �y����(smallint)
				case "hca208.hca208_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca208_id), 0)) as no " +
								"FROM hca208 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- ������a�I�N�X
				// �y����(smallint)
				case "hca209.hca209_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca209_id), 0)) as no " +
								"FROM hca209 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- ���O�Ϊ��B�N�X
				// �y����(smallint)
				case "hca210.hca210_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca210_id), 0)) as no " +
								"FROM hca210 ";

					// �M�����W��X
					as_startswith = "";

					break;

				// ------------------------------------------------- �����~�N�X
				// �y����(smallint)
				case "hca211.hca211_id":

					// �o��W��X������
					li_flen = as_startswith.Length;

					li_len = 0;				// �y���� 0 ��

					// ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
					ls_sql = "SELECT Convert(varchar(10), IsNull(Max(hca211_id), 0)) as no " +
								"FROM hca211 ";

					// �M�����W��X
					as_startswith = "";

					break;

				
                 //��EntityAddHere!

                 //���ѡG
                 case "hmd100a.hmd100a_posid":

                 	li_flen = as_startswith.Length;
                 	li_len = 5;
                 	ls_sql = "SELECT CAST(IsNull(Max(Cast(Right(hmd100a_posid,5) as int)), '0') as varchar(5)) FROM hmd100a ";
                 	
                 	break;



                           default:
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
	}
}
