// *********************************************************************************
// 1. �{���y�z�G�����ަ@�Ψ禡�w�V�[�ѱK�A��
// 2. ���g�H���Gfen
// *********************************************************************************
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WIT.Template.Project
{
	/// <summary>
	/// �����ަ@�Ψ禡�w�V�[�ѱK�{��
	/// </summary>
	public class DESCrypto
	{
		#region �� Declare Variables -------------------------------------- ���g�H���Gfen

		/// <summary>�ܼƴy�z�G�ϥ� DES �[�K�t��k������</summary>
		private DESCryptoServiceProvider io_DES;
		/// <summary>�ܼƴy�z�G�[�ѱK���_(Key)</summary>
		private byte[] iba_mKey = new byte[8];
		/// <summary>�ܼƴy�z�G�[�ѱK��l�ƦV�q(IV)</summary>
		private byte[] iba_mIV = new byte[8];

		#endregion

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�GConstructor
		/// </summary>
		public DESCrypto()
		{
			this.io_DES = new DESCryptoServiceProvider();

			#region ���_��l��
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

			// �]�w���_
			this.io_DES.Key = this.iba_mKey;
			this.io_DES.IV = this.iba_mIV;
		}


		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�b�ɮפ��g�J�[�ѱK�����_
		/// </summary>
		/// <param name="as_FileName">�ɮ׸��|�ΦW��</param>
		public void uf_WriteKeyFile(string as_Filename) 
		{
			// �ƹ�W�A�إ� DESCryptoServiceProvider �ɫK�|�۰ʲ��ͤ@�� Key �� IV
			// �]�����ݯS�O�I�s�H�U�o���{���]��
			this.io_DES.GenerateKey();
			this.io_DES.GenerateIV();

			// ���o���_
			this.iba_mKey = this.io_DES.Key;
			this.iba_mIV = this.io_DES.IV;

			// �}�Ҽg�J���ɮרüg�J���_
			FileStream lo_fOut = new FileStream(as_Filename, FileMode.OpenOrCreate, FileAccess.Write);
			lo_fOut.Write(this.iba_mKey, 0, this.iba_mKey.Length);
			lo_fOut.Write(this.iba_mIV, 0, this.iba_mIV.Length);
			lo_fOut.Close();
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�q�ɮפ�Ū���[�ѱK�����_
		/// </summary>
		/// <param name="as_FileName">�ɮ׸��|�ΦW��</param>
		public void uf_ReadKeyFile(string as_Filename) 
		{
			// �}��Ū�����ɮר�Ū�����_
			FileStream lo_fIn = new FileStream(as_Filename, FileMode.Open, FileAccess.Read);
			lo_fIn.Read(this.iba_mKey, 0, 8);
			lo_fIn.Read(this.iba_mIV, 0, 8);
			lo_fIn.Close();

			// �]�w���_
			this.io_DES.Key = this.iba_mKey;
			this.io_DES.IV = this.iba_mIV;
		}


		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�r��[�K
		/// </summary>
		/// <param name="as_Data">�[�K�e���r��</param>
		/// <returns>�[�K�᪺�r��</returns>
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
		/// �禡�y�z�G�r��ѱK
		/// </summary>
		/// <param name="as_Data">�ѱK�e���r��</param>
		/// <returns>�ѱK�᪺�r��</returns>
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
		/// �禡�y�z�G�N byte �}�C�ഫ�� 16 �i��r��
		/// </summary>
		/// <param name="aba_buf">�ഫ�e�� byte �}�C</param>
		/// <returns>�ഫ�᪺ 16 �i��r��</returns>
		private string uf_GetHexString(byte[] aba_buf)
		{
			StringBuilder lsb_value = new StringBuilder();

			foreach (byte lb_byte in aba_buf)
				lsb_value.Append(Convert.ToString(lb_byte, 16).PadLeft(2, '0'));

			return lsb_value.ToString();
		}

		// =========================================================================
		/// <summary>
		/// �禡�y�z�G�N 16 �i��r���ഫ�� byte �}�C
		/// </summary>
		/// <param name="as_value">�ഫ�e�� 16 �i��r��</param>
		/// <returns>�ഫ�᪺ byte �}�C</returns>
		private byte[] uf_FromHexString(string as_value)
		{
			byte[] lba_buf = new byte[Convert.ToInt32(as_value.Length / 2)];	// ��(�L����˥h)�A�ҥH�p���פ���2�h�|�˥h

			for (int li_i = 0; li_i < lba_buf.Length; li_i++)
				lba_buf[li_i] = Convert.ToByte(as_value.Substring(li_i * 2, 2), 16);

			return lba_buf;
		}
	}
}
