// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–加解密服務
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WIT.Template.Project
{
	/// <summary>
	/// 環域科技共用函式庫–加解密程式
	/// </summary>
	public class DESCrypto
	{
		#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

		/// <summary>變數描述：使用 DES 加密演算法的物件</summary>
		private DESCryptoServiceProvider io_DES;
		/// <summary>變數描述：加解密金鑰(Key)</summary>
		private byte[] iba_mKey = new byte[8];
		/// <summary>變數描述：加解密初始化向量(IV)</summary>
		private byte[] iba_mIV = new byte[8];

		#endregion

		// =========================================================================
		/// <summary>
		/// 事件描述：Constructor
		/// </summary>
		public DESCrypto()
		{
			this.io_DES = new DESCryptoServiceProvider();

			#region 金鑰初始值
			this.iba_mKey[0] = 52;
			this.iba_mKey[1] = 153;
			this.iba_mKey[2] = 119;
			this.iba_mKey[3] = 79;
			this.iba_mKey[4] = 177;
			this.iba_mKey[5] = 136;
			this.iba_mKey[6] = 99;
			this.iba_mKey[7] = 152;

			this.iba_mIV[0] = 216;
			this.iba_mIV[1] = 232;
			this.iba_mIV[2] = 17;
			this.iba_mIV[3] = 219;
			this.iba_mIV[4] = 99;
			this.iba_mIV[5] = 2;
			this.iba_mIV[6] = 22;
			this.iba_mIV[7] = 254;
			#endregion

			// 設定金鑰
			this.io_DES.Key = this.iba_mKey;
			this.io_DES.IV = this.iba_mIV;
		}


		// =========================================================================
		/// <summary>
		/// 函式描述：在檔案中寫入加解密的金鑰
		/// </summary>
		/// <param name="as_FileName">檔案路徑及名稱</param>
		public void uf_WriteKeyFile(string as_Filename) 
		{
			// 事實上，建立 DESCryptoServiceProvider 時便會自動產生一組 Key 及 IV
			// 因此不需特別呼叫以下這兩行程式也行
			this.io_DES.GenerateKey();
			this.io_DES.GenerateIV();

			// 取得金鑰
			this.iba_mKey = this.io_DES.Key;
			this.iba_mIV = this.io_DES.IV;

			// 開啟寫入的檔案並寫入金鑰
			FileStream lo_fOut = new FileStream(as_Filename, FileMode.OpenOrCreate, FileAccess.Write);
			lo_fOut.Write(this.iba_mKey, 0, this.iba_mKey.Length);
			lo_fOut.Write(this.iba_mIV, 0, this.iba_mIV.Length);
			lo_fOut.Close();
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：從檔案中讀取加解密的金鑰
		/// </summary>
		/// <param name="as_FileName">檔案路徑及名稱</param>
		public void uf_ReadKeyFile(string as_Filename) 
		{
			// 開啟讀取的檔案並讀取金鑰
			FileStream lo_fIn = new FileStream(as_Filename, FileMode.Open, FileAccess.Read);
			lo_fIn.Read(this.iba_mKey, 0, 8);
			lo_fIn.Read(this.iba_mIV, 0, 8);
			lo_fIn.Close();

			// 設定金鑰
			this.io_DES.Key = this.iba_mKey;
			this.io_DES.IV = this.iba_mIV;
		}


		// =========================================================================
		/// <summary>
		/// 函式描述：字串加密
		/// </summary>
		/// <param name="as_Data">加密前的字串</param>
		/// <returns>加密後的字串</returns>
		public string uf_Encrypt(string as_Data)
		{
			ICryptoTransform lo_ICT = this.io_DES.CreateEncryptor(this.io_DES.Key, this.io_DES.IV);

			try
			{
				byte[] lba_bufIn = Encoding.UTF8.GetBytes(as_Data);
				byte[] lba_bufOut = lo_ICT.TransformFinalBlock(lba_bufIn, 0, lba_bufIn.Length);

				//return Convert.ToBase64String(lba_bufOut);
				return this.uf_GetHexString(lba_bufOut);
			}
			catch
			{
				return "";
			}
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：字串解密
		/// </summary>
		/// <param name="as_Data">解密前的字串</param>
		/// <returns>解密後的字串</returns>
		public string uf_Decrypt(string as_Data)
		{
			ICryptoTransform lo_ICT = this.io_DES.CreateDecryptor(this.io_DES.Key, this.io_DES.IV);

			try
			{
				//byte[] lba_bufIn = Convert.FromBase64String(as_Data);
				byte[] lba_bufIn = this.uf_FromHexString(as_Data);
				byte[] lba_bufOut = lo_ICT.TransformFinalBlock(lba_bufIn, 0, lba_bufIn.Length);

				return Encoding.UTF8.GetString(lba_bufOut);
			}
			catch
			{
				return "";
			}
		}


		// =========================================================================
		/// <summary>
		/// 函式描述：將 byte 陣列轉換成 16 進位字串
		/// </summary>
		/// <param name="aba_buf">轉換前的 byte 陣列</param>
		/// <returns>轉換後的 16 進位字串</returns>
		private string uf_GetHexString(byte[] aba_buf)
		{
			StringBuilder lsb_value = new StringBuilder();

			foreach (byte lb_byte in aba_buf)
				lsb_value.Append(Convert.ToString(lb_byte, 16).PadLeft(2, '0'));

			return lsb_value.ToString();
		}

		// =========================================================================
		/// <summary>
		/// 函式描述：將 16 進位字串轉換成 byte 陣列
		/// </summary>
		/// <param name="as_value">轉換前的 16 進位字串</param>
		/// <returns>轉換後的 byte 陣列</returns>
		private byte[] uf_FromHexString(string as_value)
		{
			byte[] lba_buf = new byte[Convert.ToInt32(as_value.Length / 2)];	// 商(無條件捨去)，所以如長度不滿2則會捨去

			for (int li_i = 0; li_i < lba_buf.Length; li_i++)
				lba_buf[li_i] = Convert.ToByte(as_value.Substring(li_i * 2, 2), 16);

			return lba_buf;
		}
	}
}
