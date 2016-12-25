// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–加解密服務
// 2. 撰寫人員：magi
// *********************************************************************************
using System;
using System.IO;
using System.Text;

namespace WIT.Template.Project
{
	/// <summary>
	/// 環域科技共用函式庫–加解密程式
	/// </summary>
	public class SIMCrypto
	{
		#region ☆ Declare Variables -------------------------------------- 撰寫人員：magi

		/// <summary>變數描述：加密字串</summary>
		private string strkey = "";

		#endregion

        // =========================================================================
		/// <summary>
		/// 事件描述：Constructor
		/// </summary>
        public SIMCrypto()
		{
            strkey = "9876543210";
        }

		// =========================================================================
		/// <summary>
		/// 函式描述：字串加密
		/// </summary>
		/// <param name="as_Data">加密前的字串</param>
		/// <returns>加密後的字串</returns>
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
		/// 函式描述：字串解密
		/// </summary>
		/// <param name="as_Data">解密前的字串</param>
		/// <returns>解密後的字串</returns>
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
