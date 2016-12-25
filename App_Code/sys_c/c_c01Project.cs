// *********************************************************************************
// 1. �{���y�z�G�A�ȶ԰Ⱥ޲z�V�M�צ@��
// 2. ���g�H���GEmily
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// �t�κ޲z�V�M�צ@��
	/// </summary>
	public class c01Project
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

                // ------------------------------------------------- �� �ժ��]���ͥN�X
                // "F" + ����~(3��) + �y����(6��)
                case "hmc101.hmc101_id":

                    // �o��W��X������
                    as_startswith = "F" + Convert.ToString(DbMethods.uf_GetDate().Year - 1911).PadLeft(3, '0')+"-";
                    li_flen = as_startswith.Length;

                    li_len = 6;			// �y���� 6 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hmc101_id, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hmc101 " +
                                "WHERE SubString(hmc101_id, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;    
                

                 //------------------------------------------------- �� hmc102�������h�N�X
                // int �y����
                case "hmc102.hmc102_id":

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 0;			// �y���� 0 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = " SELECT IsNull(Convert(varchar(5) , Max(hmc102_id)), '0') as no FROM hmc102 ";

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

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��Z��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�Z���ƶq</returns>
        //static public string uf_rcount(object ao_psid)
        //{
        //    int li_count = 0;
        //    if (ao_psid != null)
        //    {
        //        DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "'", ref li_count);
        //    }
        //    return li_count.ToString();
        //}

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��H��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�H���ƶq</returns>
        //static public string uf_pcount(object ao_psid)
        //{
        //    int li_count = 0;
        //    if (ao_psid != null)
        //    {
        //        DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE (hme101c_pdid IN (SELECT hme101b_pdid FROM hme101b WHERE (hme101b_psid = '" + ao_psid.ToString().Trim() + "')))", ref li_count);
        //    }
        //    return li_count.ToString();
        //}

        // =========================================================================
        // �禡
        // =========================================================================
        /// <summary>
        /// �禡�y�z�G���o������ݪ��g��
        /// </summary>
        /// <param name="adt_Date">���</param>
        /// <returns>������ݪ��g��</returns>
    //    static public int uf_GetWeek(DateTime adt_Date)
    //    {
    //        // ##### �ŧi�ܼ� #####
    //        DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
    //        int li_weekday;
    //        TimeSpan lts_period;

    //        // ���o���Ĥ@�ѡA�çP�_�O�P���X
    //        ldt_MonthFirstDay = new DateTime(adt_Date.Year, adt_Date.Month, 1);
    //        li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

    //        // ���o���Ĥ@�g���Ĥ@��(�P����)�����
    //        ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

    //        // �p������Ĥ@�g���Ĥ@�Ѭۮt�X�Ѩíp��X�g��
    //        lts_period = adt_Date - ldt_FirstWeekStartDay;

    //        return 1 + Convert.ToInt16(Decimal.Truncate(Convert.ToDecimal(lts_period.TotalDays / 7)));
    //    }	// End of uf_GetWeek

    //    // =========================================================================
    //    // �禡
    //    // =========================================================================
    //    /// <summary>
    //    /// �禡�y�z�G���o���w������ݪ��g�����}�l�ε������
    //    /// </summary>
    //    /// <param name="adt_Date">���</param>
    //    /// <param name="adt_sDate">�^�Ƕ}�l���(�P����)</param>
    //    /// <param name="adt_eDate">�^�ǵ������(�P����)</param>
    //    static public void uf_GetWeekPeriod(DateTime adt_Date, out DateTime adt_sDate, out DateTime adt_eDate)
    //    {
    //        uf_GetWeekPeriod(adt_Date.Year, adt_Date.Month, uf_GetWeek(adt_Date), out adt_sDate, out adt_eDate);
    //    }	// End of uf_GetWeekPeriod(1)

    //    // =========================================================================
    //    // �禡
    //    // =========================================================================
    //    /// <summary>
    //    /// �禡�y�z�G���o���w�~�סB����B�g�����}�l�ε������
    //    /// </summary>
    //    /// <param name="ao_Year">�褸�~��</param>
    //    /// <param name="ao_Month">���</param>
    //    /// <param name="ao_Week">�g��</param>
    //    /// <param name="adt_sDate">�^�Ƕ}�l���(�P����)</param>
    //    /// <param name="adt_eDate">�^�ǵ������(�P����)</param>
    //    static public void uf_GetWeekPeriod(object ao_Year, object ao_Month, object ao_Week, out DateTime adt_sDate, out DateTime adt_eDate)
    //    {
    //        // ##### �ŧi�ܼ� #####
    //        DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
    //        int li_weekday;

    //        // ���o���Ĥ@�ѡA�çP�_�O�P���X
    //        ldt_MonthFirstDay = new DateTime(Convert.ToInt16(ao_Year), Convert.ToInt16(ao_Month), 1);
    //        li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

    //        // ���o���Ĥ@�g���Ĥ@��(�P����)�����
    //        ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

    //        // �p��X�}�l���
    //        adt_sDate = ldt_FirstWeekStartDay.AddDays(7 * (Convert.ToInt16(ao_Week) - 1));

    //        // �p��X�}�l���
    //        adt_eDate = adt_sDate.AddDays(6);
    //    }	// End of uf_GetWeekPeriod(2)
    }
}
