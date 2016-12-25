// *********************************************************************************
// 1. �{���y�z�G�����ަ@�Ψ禡�w�V�[�ѱK�A��
// 2. ���g�H���Gmagi
// *********************************************************************************
using System;
using System.IO;
using System.Text;

namespace WIT.Template.Project
{
	/// <summary>
	/// �����ަ@�Ψ禡�w�V�[�ѱK�{��
	/// </summary>
	public class SIMCrypto
	{
		#region �� Declare Variables -------------------------------------- ���g�H���Gmagi

		/// <summary>�ܼƴy�z�G�[�K�r��</summary>
		private string strkey = "";

		#endregion

        // =========================================================================
		/// <summary>
		/// �ƥ�y�z�GConstructor
		/// </summary>
        public SIMCrypto()
		{
            strkey = "9876543210";
        }

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�r��[�K
		/// </summary>
		/// <param name="as_Data">�[�K�e���r��</param>
		/// <returns>�[�K�᪺�r��</returns>
		public string uf_Encrypt(string as_Data)
		{
            string strDest = "";
            int intSS = 0;
            int intFt;
            string strAsc;
            string strKey;

            if (as_Data.Length == 0)
                strDest = "";

            for (intFt = 0; intFt < as_Data.Length; intFt++)
            {
                strAsc = as_Data.Substring(intFt, 1);
                strKey = strkey.Substring(intFt, 1);
                intSS = (Convert.ToInt16(strAsc) + (Convert.ToInt16(strKey)));
                if (intSS >= 10)
                    intSS = intSS - 10;
                strDest += Convert.ToString(intSS);
            }
            return strDest;
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�r��ѱK
		/// </summary>
		/// <param name="as_Data">�ѱK�e���r��</param>
		/// <returns>�ѱK�᪺�r��</returns>
		public string uf_Decrypt(string as_Data)
		{
            string strDest = "";
            int intSS = 0;
            int intFt;
            string strAsc;
            string strKey;

            if (as_Data.Length == 0)
                strDest = "";

            for (intFt = 0; intFt < as_Data.Length; intFt++)
            {
                strAsc = as_Data.Substring(intFt, 1);
                strKey = strkey.Substring(intFt, 1);
                if (Convert.ToInt16(strAsc) < Convert.ToInt16(strKey))
                    intSS = (Convert.ToInt16(strAsc) + 10 - (Convert.ToInt16(strKey)));
                else
                    intSS = (Convert.ToInt16(strAsc) - (Convert.ToInt16(strKey)));

                strDest += Convert.ToString(intSS);
            }
            return strDest;
        }
	}
}
