// *********************************************************************************
// 1. �{���y�z�G�A�ȶ԰Ⱥ޲z�V�M�צ@��
// 2. ���g�H���Gdemon
// *********************************************************************************
using System;
using System.Data;

namespace WIT.Template.Project
{
	/// <summary>
	/// �t�κ޲z�V�M�צ@��
	/// </summary>
	public class e01Project
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

                // ------------------------------------------------- �� �w�ƯZ��s��
                // "S" + ����~(3��) + �y����(6��)
                case "hme101a.hme101a_psid":

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 6;			// �y���� 6 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hme101a_psid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme101a " +
                                "WHERE SubString(hme101a_psid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- �� �ݨD�Z���s��
                // "SR" + ����~(3��) + �y����(6��)
                case "hme101b.hme101b_pdid":

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 6;			// �y���� 6 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hme101b_pdid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme101b " +
                                "WHERE SubString(hme101b_pdid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;


                // ------------------------------------------------- �� �Z��˪O�s��
                // "ST" + ����~(3��) + �y����(6��)
                case "hme105a.hme105a_ssid":

                    // �o��W��X������
                    as_startswith = "ST" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000");

                    li_flen = as_startswith.Length;

                    li_len = 6;			// �y���� 6 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hme105a_ssid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme105a " +
                                "WHERE SubString(hme105a_ssid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- �� �˪O�ݨD�s��
                // "TR" + ����~(3��) + �y����(6��)
                case "hme105b.hme105b_sdid":

                    // �o��W��X������
                    as_startswith = "TR" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000");

                    li_flen = as_startswith.Length;

                    li_len = 6;			// �y���� 6 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hme105b_sdid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hme105b " +
                                "WHERE SubString(hme105b_sdid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- �� �԰Ȭ����s��
                // "Slog" + �y����(9��)
                case "hle201.hle201_lid":

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 9;			// �y���� 9 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hle201_lid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hle201 " +
                                "WHERE SubString(hle201_lid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

                    break;

                // ------------------------------------------------- �� �A�Ԫ�{�s��
                // "R" + ����~(3��) + �y����(6��)
                case "hle501.hle501_plid":

                    // �o��W��X������
                    li_flen = as_startswith.Length;

                    li_len = 6;			// �y���� 6 ��

                    // ��X��Ʈw���̤j���s���V�B�W��X�ŦX�ǤJ����
                    ls_sql = "SELECT IsNull(Max(SubString(hle501_plid, " + Convert.ToString(li_flen + 1) + ", " + Convert.ToString(li_len) + ")), '0') as no " +
                                "FROM hle501 " +
                                "WHERE SubString(hle501_plid, 1, " + Convert.ToString(li_flen) + ") = '" + as_startswith + "' ";

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
        /// �禡�y�z�G�p��ݨD�Z��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�Z���ƶq</returns>
        static public string uf_rcount(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "'", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p�⤣���H�ƯZ��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�Z���ƶq</returns>
        static public string uf_rcount_short(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' And hme101b_needno > ( SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = hme101b_pdid ) ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��L�h�H�ƯZ��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�Z���ƶq</returns>
        static public string uf_rcount_more(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' And hme101b_needno < ( SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = hme101b_pdid )", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p�⺡���H�ƯZ��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�Z���ƶq</returns>
        static public string uf_rcount_satisfy(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' And hme101b_needno = ( SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = hme101b_pdid ) ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��ݨD�H��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�H���ƶq</returns>
        static public string uf_pcount(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT IsNull(SUM(hme101b_needno) , 0) FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "'", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��w�ƤH��
        /// </summary>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�H���ƶq</returns>
        static public string uf_pcount_actual(object ao_psid)
        {
            int li_count = 0;
            if (ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid in ( SELECT hme101b_pdid FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString().Trim() + "' ) ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��w�ƤH��
        /// </summary>
        /// <param name="ao_psid">�ƯZ�ݨD�N�X</param>
        /// <returns>�H���ƶq</returns>
        static public string uf_pcount_hme101c(object ao_pdid)
        {
            int li_count = 0;
            if (ao_pdid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid  = '" + ao_pdid.ToString().Trim() + "' ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��w�ƤH�W
        /// </summary>
        /// <param name="ao_psid">�ƯZ�ݨD�N�X</param>
        /// <returns>�H�W</returns>
        static public string uf_pname_hme101c(object ao_pdid)
        {
            DataSet lds_data;
            int li_rowcount;
            string ls_datastring = "";

            if (ao_pdid != null)
            {
                // �Q�� SQL �y�k���͸�ƶ�
                DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hmc101.hmc101_cname FROM hme101c Inner Join hmd201 ON hmd201_vid = hme101c_vid Inner Join hmc101 ON hmc101_id = hmd201_id WHERE hme101c_pdid = '" + ao_pdid.ToString() + "' ");

                // ���o�`����
                li_rowcount = lds_data.Tables[0].Rows.Count;

                ls_datastring = "";
                for (int li_row = 0; li_row <= (li_rowcount - 1); li_row++)
                {
                    ls_datastring += lds_data.Tables[0].Rows[li_row]["hmc101_cname"].ToString().Trim() + "�B";
                }

                if (ls_datastring != "")
                {
                    ls_datastring = ls_datastring.Substring(0, ls_datastring.Length - 1);
                }
            }
            return ls_datastring;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��ӤH�b�S�w�Ӥu�ƯZ��U�w�ƯZ��
        /// </summary>
        /// <param name="ao_vid">�Ӥu�N�X</param>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�Z���ƶq</returns>
        static public string uf_pc_vid_all(object ao_vid, object ao_psid)
        {
            int li_count = 0;
            if (ao_vid != null && ao_psid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' AND hme101c_pdid in ( SELECT hme101b_pdid FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString() + "' )  ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��ӤH�b�S�w�Ӥu�ƯZ��U�w�Ʈɼ�
        /// </summary>
        /// <param name="ao_vid">�Ӥu�N�X</param>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <returns>�w�ƯZ�ɼ�</returns>
        static public string uf_ts_vid_all(object ao_vid, object ao_psid)
        {
            int li_count = 0;
            string ls_sql = "";
            if (ao_vid != null && ao_psid != null)
            {
                ls_sql = " SELECT IsNull(SUM(DateDiff(hh ,hme101b_starttime , hme101b_endtime)),0) " + 
                         "   FROM hme101b " +
                         "  WHERE hme101b_pdid in ( SELECT hme101c_pdid FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' ) " +
                         "    AND hme101b_psid = '" + ao_psid.ToString() + "'";
                DbMethods.uf_ExecSQL( ls_sql, ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��ӤH�b�S�w�Ӥu�ƯZ��U�w�ƯZ���A�L�o�ǤJ�ݨD�渹
        /// </summary>
        /// <param name="ao_vid">�Ӥu�N�X</param>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <param name="ao_pdid">�ƯZ�ݨD�N�X</param>
        /// <returns>�Z���ƶq</returns>
        static public string uf_pc_vid_all(object ao_vid, object ao_psid, object ao_pdid)
        {
            int li_count = 0;
            if (ao_vid != null && ao_psid != null && ao_pdid != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' AND hme101c_pdid in ( SELECT hme101b_pdid FROM hme101b WHERE hme101b_psid = '" + ao_psid.ToString() + "' ) AND hme101c_pdid <> '" + ao_pdid.ToString() + "' ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��ӤH�b�S�w�Ӥu�ƯZ��U�w�ƮɼơA�L�o�ǤJ�ݨD�渹
        /// </summary>
        /// <param name="ao_vid">�Ӥu�N�X</param>
        /// <param name="ao_psid">�ƯZ��N�X</param>
        /// <param name="ao_pdid">�ƯZ�ݨD�N�X</param>
        /// <returns>�w�ƯZ�ɼ�</returns>
        static public string uf_ts_vid_all(object ao_vid, object ao_psid, object ao_pdid)
        {
            int li_count = 0;
            string ls_sql = "";
            if (ao_vid != null && ao_psid != null && ao_pdid != null)
            {
                ls_sql = " SELECT IsNull(SUM(DateDiff(hh ,hme101b_starttime , hme101b_endtime)),0) " +
                         "   FROM hme101b " +
                         "  WHERE hme101b_pdid in ( SELECT hme101c_pdid FROM hme101c WHERE hme101c_vid = '" + ao_vid.ToString() + "' ) " +
                         "    AND hme101b_psid = '" + ao_psid.ToString() + "'" +
                         "    AND hme101b_pdid <> '" + ao_pdid.ToString() + "'";
                DbMethods.uf_ExecSQL(ls_sql, ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�ݨD�Z���ɶ�
        /// </summary>
        /// <param name="ao_psid">�ƯZ�ݨD�N�X</param>
        /// <returns>�ݨD�Z���ɶ�</returns>
        static public string uf_get_hme101b_time(object ao_pdid)
        {
            DataSet lds_data;
            string ls_datastring = "";

            if (ao_pdid != null)
            {
                // �Q�� SQL �y�k���͸�ƶ�
                DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hme101b_sdate , hme101b_starttime , hme101b_endtime FROM hme101b WHERE hme101b_pdid = '" + ao_pdid.ToString() + "' ");

                if(  lds_data.Tables[0].Rows.Count > 0  )
                {
                    ls_datastring = DateMethods.uf_YYYY_To_YYY(lds_data.Tables[0].Rows[0]["hme101b_sdate"], false) + " " + Convert.ToDateTime(lds_data.Tables[0].Rows[0]["hme101b_starttime"]).ToString("HHmm") + " ~ " + Convert.ToDateTime(lds_data.Tables[0].Rows[0]["hme101b_endtime"]).ToString("HHmm");
                }
            }
            return ls_datastring;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��S�w�Ӥu���B�~�סB�u�O���A�Ԫ�{�`�H��
        /// </summary>
        /// <param name="ao_tid">�Ӥu���N�X</param>
        /// <param name="ao_syear">�~��</param>
        /// <param name="ao_sseason">�u�O</param>
        /// <returns>�A���`�H��</returns>
        static public string uf_hle501_pcount(object ao_tid , object ao_syear , object ao_sseason)
        {
            int li_count = 0;
            if (ao_tid != null && ao_syear != null && ao_sseason != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hle501 WHERE hle501_tid = '" + ao_tid.ToString().Trim() + "' And hle501_syear ='" + ao_syear.ToString() + "' AND hle501_sseason = '"+ ao_sseason.ToString() +"'", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p��S�w�Ӥu���B�~�סB�u�O���A�Ԫ�{�����H��
        /// </summary>
        /// <param name="ao_tid">�Ӥu���N�X</param>
        /// <param name="ao_syear">�~��</param>
        /// <param name="ao_sseason">�u�O</param>
        /// <returns>�A���`�H��</returns>
        static public string uf_hle501_fcount(object ao_tid, object ao_syear, object ao_sseason)
        {
            int li_count = 0;
            if (ao_tid != null && ao_syear != null && ao_sseason != null)
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hle501 WHERE hle501_tid = '" + ao_tid.ToString().Trim() + "' And hle501_syear ='" + ao_syear.ToString() + "' AND hle501_sseason = '" + ao_sseason.ToString() + "' AND hle501_score is not null ", ref li_count);
            }
            return li_count.ToString();
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G�p���Ӥ���϶����ɼơA�̤p��쬰0.5�p��
        /// </summary>
        /// <param name="adt_sdate">�}�l���</param>
        /// <param name="adt_edate">�������</param>
        /// <returns>�ۮt�ɼ�</returns>
        static public float uf_GetHourPeriod(DateTime adt_sdate, DateTime adt_edate)
        {
            float lf_return = 0 ;
            int li_min = 0;
            TimeSpan lts_period;

            if (adt_sdate != null && adt_edate != null)
            {
                if (adt_sdate <= adt_edate)
                {
                    // �p��ۮt�ɶ�
                    lts_period = adt_edate - adt_sdate;
                    lf_return = lts_period.Hours;

                    li_min = lts_period.Minutes;
                    if (li_min >= 30)
                        lf_return += (float)0.5;
                }
            }
            return lf_return;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G��ܤH���򥻤���
        /// </summary>
        /// <param name="ao_psid">�򥻸�ƥN�X</param>
        /// <returns>�򥻤���</returns>
        static public string uf_get_hmc102(object ao_id)
        {
            DataSet lds_data;
            int li_rowcount , li_seq = 0;
            string ls_datastring = "";

            if (ao_id != null && ao_id.ToString() != "")
            {
                // �Q�� SQL �y�k���͸�ƶ�
                DbMethods.uf_Retrieve_FromSQL(out lds_data, "Select hmc102_name From hmc102 Where hmc102_id in ( SELECT hmc101_102.hmc102_id From hmc101_102 Where hmc101_102.hmc101_id = '" + ao_id.ToString() + "' ) AND hmc102_id <> 0");

                // ���o�`����
                li_rowcount = lds_data.Tables[0].Rows.Count;

                ls_datastring = "";
                for (int li_row = 0; li_row <= (li_rowcount - 1); li_row++)
                {
                    if (li_seq > 5)
                    {
                        ls_datastring += "<BR />";
                        li_seq = 0;
                    }
                    li_seq++;
                    ls_datastring += lds_data.Tables[0].Rows[li_row]["hmc102_name"].ToString().Trim() + "�A";
                }

                if (ls_datastring != "")
                {
                    ls_datastring = ls_datastring.Substring(0, ls_datastring.Length - 1);
                }
            }
            return ls_datastring;
        }

        // =========================================================================
        /// <summary>
        /// �禡�y�z�G����ɮ׮榡
        /// </summary>
        /// <param name="mineType">�榡</param>
        /// <returns>�榡</returns>
        static public string GetExtensions(string mineType)
        {
            string retVal = "";

            switch (mineType)
            {
                case "text/html":
                    retVal = "html";
                    break;
                case "multipart/related":
                    retVal = "html";
                    break;
                case "text/xml":
                    retVal = "xml";
                    break;
                case "text/plain":
                    retVal = "csv";
                    break;
                case "image/tiff":
                    retVal = "tif";
                    break;
                case "application/pdf":
                    retVal = "pdf";
                    break;
                case "application/vnd.ms-excel":
                    retVal = "xls";
                    break;
            }

            return retVal;
        }


        // =========================================================================
        // �禡
        // =========================================================================
        /// <summary>
        /// �禡�y�z�G���o������ݪ��g��
        /// </summary>
        /// <param name="adt_Date">���</param>
        /// <returns>������ݪ��g��</returns>
        static public int uf_GetWeek(DateTime adt_Date)
        {
            // ##### �ŧi�ܼ� #####
            DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
            int li_weekday;
            TimeSpan lts_period;

            // ���o���Ĥ@�ѡA�çP�_�O�P���X
            ldt_MonthFirstDay = new DateTime(adt_Date.Year, adt_Date.Month, 1);
            li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

            // ���o���Ĥ@�g���Ĥ@��(�P����)�����
            ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

            // �p������Ĥ@�g���Ĥ@�Ѭۮt�X�Ѩíp��X�g��
            lts_period = adt_Date - ldt_FirstWeekStartDay;

            return 1 + Convert.ToInt16(Decimal.Truncate(Convert.ToDecimal(lts_period.TotalDays / 7)));
        }	// End of uf_GetWeek

        // =========================================================================
        // �禡
        // =========================================================================
        /// <summary>
        /// �禡�y�z�G���o���w������ݪ��g�����}�l�ε������
        /// </summary>
        /// <param name="adt_Date">���</param>
        /// <param name="adt_sDate">�^�Ƕ}�l���(�P����)</param>
        /// <param name="adt_eDate">�^�ǵ������(�P����)</param>
        static public void uf_GetWeekPeriod(DateTime adt_Date, out DateTime adt_sDate, out DateTime adt_eDate)
        {
            uf_GetWeekPeriod(adt_Date.Year, adt_Date.Month, uf_GetWeek(adt_Date), out adt_sDate, out adt_eDate);
        }	// End of uf_GetWeekPeriod(1)

        // =========================================================================
        // �禡
        // =========================================================================
        /// <summary>
        /// �禡�y�z�G���o���w�~�סB����B�g�����}�l�ε������
        /// </summary>
        /// <param name="ao_Year">�褸�~��</param>
        /// <param name="ao_Month">���</param>
        /// <param name="ao_Week">�g��</param>
        /// <param name="adt_sDate">�^�Ƕ}�l���(�P����)</param>
        /// <param name="adt_eDate">�^�ǵ������(�P����)</param>
        static public void uf_GetWeekPeriod(object ao_Year, object ao_Month, object ao_Week, out DateTime adt_sDate, out DateTime adt_eDate)
        {
            // ##### �ŧi�ܼ� #####
            DateTime ldt_MonthFirstDay, ldt_FirstWeekStartDay;
            int li_weekday;

            // ���o���Ĥ@�ѡA�çP�_�O�P���X
            ldt_MonthFirstDay = new DateTime(Convert.ToInt16(ao_Year), Convert.ToInt16(ao_Month), 1);
            li_weekday = Convert.ToInt16(ldt_MonthFirstDay.DayOfWeek);

            // ���o���Ĥ@�g���Ĥ@��(�P����)�����
            ldt_FirstWeekStartDay = ldt_MonthFirstDay.AddDays(-li_weekday);

            // �p��X�}�l���
            adt_sDate = ldt_FirstWeekStartDay.AddDays(7 * (Convert.ToInt16(ao_Week) - 1));

            // �p��X�}�l���
            adt_eDate = adt_sDate.AddDays(6);
        }	// End of uf_GetWeekPeriod(2)
	}
}
