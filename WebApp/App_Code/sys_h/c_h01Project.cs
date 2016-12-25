// *********************************************************************************
// 1. �{���y�z�G�A�ȶ԰Ⱥ޲z�V�M�צ@��
// 2. ���g�H���Gdemon
// *********************************************************************************
using System;
using System.Data;
using SNSCOMSERVER;

namespace WIT.Template.Project
{
	/// <summary>
	/// �t�κ޲z�V�M�צ@��
	/// </summary>
	public class h01Project
	{
        static public SnsComObject m_sns = new SnsComObject();

		// =========================================================================
		/// <summary>
        /// �禡�y�z�G�n�J SNS ���A��
		/// </summary>
		/// <returns>�n�J���G�T��</returns>
		static public int uf_SNS_Login(ref string as_msg)
		{
            string ls_server = "", ls_port = "", ls_user = "", ls_pswd = "";
            ls_server = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "Server", "");
            ls_port = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "Port", "");
            ls_user = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "id", "");
            ls_pswd = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SNS", "passwd", "");

            //�n�J SNS ���A��
            int nResult = m_sns.Login(ls_server, Int32.Parse(ls_port), ls_user, ls_pswd);

            switch (nResult)
            {
                case -1:
                    as_msg = "[�L�k�s�u SNS]" + m_sns.RespMessage;
                    break;
                case 0:
                    as_msg = "[�إ߳s�u���\]" + m_sns.RespMessage;
                    break;
                case 1:
                    as_msg = "[�b��/�K�X��J���~]" + m_sns.RespMessage;
                    break;
                default:
                    as_msg = "[�аѦ� SNS ���]" + m_sns.RespMessage;
                    break;
            }

            return nResult;
		}

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�ǰe��r�T���ܫ��w�����T������X
        /// </summary>
        /// <returns>�n�J���G�T��</returns>
        static public int uf_SNS_Submit(string as_num , string as_msg , ref string as_returnmsg )
        {

            //�ǰe��r�T���ܫ��w�����T������X
            int nResult = m_sns.SubmitMessage(as_num, as_msg);

            switch (nResult)
            {
                case -1:
                    as_returnmsg = "[�ǰe�q�D�o�Ϳ��~�A�Э��s�s�u]" + m_sns.RespMessage;
                    break;
                case 0:
                    as_returnmsg = m_sns.RespMessage;
                    break;
                default:
                    as_returnmsg = "[�аѦ� SNS ���]" + m_sns.RespMessage;
                    break;
            }
            return nResult;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�d��²�T�ǰe���A
        /// </summary>
        /// <returns>�n�J���G�T��</returns>
        static public int uf_SNS_QueryStatus(string as_num, string as_msg, ref string as_returnmsg)
        {
            //�d��²�T�ǰe���A
            int nResult = m_sns.QryMessageStatus(as_num, as_msg);

            switch (nResult)
            {
                case -1:
                    as_returnmsg = "[�L�k�s�u SNS�A�Э��s�s�u]" + m_sns.RespMessage;
                    break;
                case 0:
                    as_returnmsg = "[²�T���\�e�F���T���] ²�T���\�e�F�ɶ��G" + m_sns.RespMessage;
                    break;
                case 1:
                    as_returnmsg = "[²�T�ǰe��]" + m_sns.RespMessage;
                    break;
                case 2:
                    as_returnmsg = "[�d�߸�ƿ��~]" + m_sns.RespMessage;
                    break;
                case 3:
                    as_returnmsg = "[²�T�ǰe����] ²�T���Ѯɶ��G" + m_sns.RespMessage;
                    break;
                case 4:
                    as_returnmsg = "[�d�ߥ���] �еy��A�d�G" + m_sns.RespMessage;
                    break;
                default:
                    as_returnmsg = "[�аѦ� SNS ���]" + m_sns.RespMessage;
                    break;
            }
            return nResult;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�����T��
        /// </summary>
        /// <returns>���G�T��</returns>
        static public int uf_SNS_GetMsg(ref string as_returnmsg)
        {
            //��������W�Ǫ�²�T
            int nResult = m_sns.GetMessage();

            switch (nResult)
            {
                case -2:
                    as_returnmsg = "[�T�����e��X����] �����T�����O BIG-5 �� ASCII �s�X���e�G" + m_sns.RespMessage;
                    break;
                case -1:
                    as_returnmsg = "[�L�k�s�u SNS] �Э��s�s�u�G" + m_sns.RespMessage;
                    break;
                case 0:
                    as_returnmsg = m_sns.FromMsisdn + "|!|" + m_sns.ToMsisdn + "|!|" + m_sns.RespMessage;
                    break;
                default:
                    as_returnmsg = "[�аѦ� SNS ���]" + m_sns.RespMessage;
                    break;
            }

            return nResult;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�����T��
        /// </summary>
        /// <returns>���G�T��</returns>
        static public void uf_SNS_Logout(ref string as_returnmsg)
        {
            m_sns.Logout();

            as_returnmsg = "���_�P SNS Server ���s�u";
        }

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
            string ls_sql = "";
            string ls_no, ls_maxno = null;
            int li_len = 0, li_flen = 0;	// li_len�G�y���������סAli_flen�G�s���W��X������
            string[] lsa_startswith;

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
                // ------------------------------------------------- �� ²�T�s��
                // "M" + ����~(3��) + �y����(9��)
                case "hlh101.hlh101_logid":

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 9;			// �y���� 9 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hlh101_logid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hlh101 " +
                                "WHERE SubString(hlh101_logid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

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
