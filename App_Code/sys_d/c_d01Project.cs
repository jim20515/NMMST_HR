// *********************************************************************************
// 1. �{���y�z�G�t�κ޲z�V�M�צ@��
// 2. ���g�H���GQFLin
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
    /// <summary>
    /// �t�κ޲z�V�M�צ@��
    /// </summary>
    public class d01Project
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

                //����: T098-00000
                case "hmd101.hmd101_tid":

                    // �o��W��X������
                    li_flen = as_startswith.Length;
                    li_len = 5;				// �y�������

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    //ls_sql = "SELECT 'T' + RIGHT('0'+Cast((Year(getDate())-1911) as varchar(3)),3) + '-' + RIGHT('00000'+ Convert(varchar(10), IsNull(Max(Cast(Right(hmd101_tid,5) as int)), 0) + 1) , 5 ) as no " +
                    //			"FROM hmd101 ";

                    ls_sql = "SELECT CAST(IsNull(Max(Cast(Right(hmd101_tid,5) as int)), '0') as varchar(5)) FROM hmd101 ";

                    break;

                // ------------------------------------------------- �� ¾��s��
                // "P" + ����~(3��) + �y����(9��)
                case "hmd100a.hmd100a_posid":

                    // �o��W��X������
                    as_startswith = "P" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000") + "-";

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 9;			// �y���� 9 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hmd100a_posid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hmd100a " +
                                "WHERE SubString(hmd100a_posid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                default:
                    break;
            }

            // ��ڨ��X�̤j�s������� ------------------------------ �� 2
            DbMethods.uf_ExecSQL(ls_sql, ref ls_maxno);

            // �P�_�O�_���̤j���s���A�S���h�q 1 �}�l --------------- �� 3
            if (ls_maxno == null || ls_maxno == "")				// ��椤�S�����
                ls_no = as_startswith + Convert.ToString(1).PadLeft(li_len, '0');
            else
                ls_no = as_startswith + Convert.ToString(Convert.ToInt64(ls_maxno) + 1).PadLeft(li_len, '0');

            return ls_no;
        }
    }
}
