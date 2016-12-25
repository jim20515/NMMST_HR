// *********************************************************************************
// 1. 程式描述：服務勤務管理–服勤刷卡記錄批次匯入
// 2. 撰寫人員：rong
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;
using System.IO;
using System.Data.OleDb;

public partial class sys_e_e02_p_e0202_01 : p_hrBase
{
	protected ndb_hle201 indb_hle201 = new ndb_hle201();
	/// <summary>變數描述：檔案存放的根目錄</summary>
	private string is_root = System.Web.HttpRuntime.AppDomainAppPath;
	/// <summary>變數描述：檔案存放的子目錄</summary>
	private string is_dir = "App_Data\\File";

    protected void Page_Load(object sender, EventArgs e)
    {
		//第一次執行
		if (!IsPostBack)
		{

		}
		this.bt_Upload.Attributes["OnClick"] = "if (! confirm('是否要匯入該班學員資料？')) return false;";

    }

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Download 《下載》按鈕所做的處理
	/// </summary>
	protected void bt_Download_Click(object sender, EventArgs e)
	{
		// ##### 宣告變數 #####
		string ls_key = "E0202_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
		string ls_fileName = "E0202_志工服勤刷卡記錄批次匯入格式.xls";
		string ls_file = this.is_root + this.is_dir + "\\Template\\" + ls_fileName;

		// 將檔案內容讀入 Application 中
		this.Application[ls_key] = File.ReadAllBytes(ls_file);
		this.Application["name:" + ls_key] = ls_fileName.Replace("E0202_", "");

		// 下載檔案
		this.uf_AddJavaScript("window.open(\"" + this.Request.ApplicationPath + "/proj_uctrl/h_download_file.ashx?key=" + ls_key + "\");");
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Upload 《匯入》按鈕所做的處理
	/// </summary>
	protected void bt_Upload_Click(object sender, EventArgs e)
	{
		if (!dwU_filepath.HasFile)
		{
			this.uf_Msg("請先選擇匯入檔案！");
			return;
		}
		if (!dwU_filepath.FileName.ToLower().EndsWith(".xls"))
		{
			this.uf_Msg("匯入檔案類型需為 Excel 97-2003 活頁簿 (*.xls)！");
			return;
		}

		// 上傳暫存檔案 ------------------------------------------------------ ☆

		// ##### 宣告變數 #####
		string ls_key = "E0202_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
		string ls_file = this.is_root + this.is_dir + "\\" + ls_key + ".xls";

		// 上傳檔案
		try
		{
			dwU_filepath.SaveAs(ls_file);
		}
		catch
		{
			this.uf_Msg("檔案上傳失敗！");
			return;
		}

		// 檔案內容處理 ------------------------------------------------------ ☆
		try
		{
			this.uf_Run(ls_file);

			// 顯示成功訊息
			this.uf_AddJavaScript("alert(\"檔案匯入成功！\");");
		}
		catch (SystemException e1)
		{
			this.uf_Msg("檔案匯入失敗！\\n" + e1.Message);
		}
		catch (Exception e2)
		{
			this.uf_Msg("檔案匯入失敗！\\n" + e2.Message);
		}
		finally
		{
			// 刪除檔案
			try { File.Delete(ls_file); } catch { }
		}
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：將上傳檔案資料匯入資料庫
	/// </summary>
	/// <param name="as_file">檔案名稱路徑</param>
	private void uf_Run(string as_file)
	{
		// ##### 宣告變數 #####
		string ls_connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + as_file + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
		OleDbConnection lcn_Conn = new OleDbConnection(ls_connstr);
		DataSet lds_data = new DataSet();
		DataView ldv_data = null;
		DataRowView ldrv_new;

		try
		{
			lcn_Conn.Open();

			string ls_Select = "Select *  From [匯入資料$] WHERE 正確 = 'V'";

			#region Retrieve Data
			OleDbDataAdapter lda_DataAdapter = new OleDbDataAdapter(ls_Select, lcn_Conn);
			lds_data.Reset();
			lda_DataAdapter.Fill(lds_data);
			lda_DataAdapter.Dispose();
			ldv_data = lds_data.Tables[0].DefaultView;
			#endregion

			if (ldv_data.Count <= 0)
				throw new Exception("匯入檔案中沒有可匯入的資料，請修正後再重新匯入！");

			#region Get hle201_lid
			// 得到規格碼的長度
			string ls_maxno = "", ls_vid = "", ls_sql = "";
			Int32 li_no = 0;
			// 找出資料庫中最大的編號–且規格碼符合傳入的值
			ls_sql = "SELECT IsNull(Max(SubString(hle201_lid, 5, 9)), '0') as no " +
						"FROM hle201 " +
						"WHERE SubString(hle201_lid, 1, 4) = 'Slog' ";

			// 實際取出最大編號的資料 ------------------------------ ☆ 2
			DbMethods.uf_ExecSQL(ls_sql, ref ls_maxno);

			// 判斷是否有找到符合的資料
			ls_maxno = ls_maxno.Trim();

			// 判斷是否有最大的編號，沒有則從 1 開始 --------------- ☆ 3
			if (ls_maxno == null || ls_maxno == "")				// 表格中沒有資料
				li_no = 0;
			else
				li_no = Convert.ToInt32(ls_maxno);
			#endregion

			string ls_msg = "";
			// 依序處理每一筆資料
			foreach (DataRowView ldrv_Row in ldv_data)
			{
				ls_vid = "";
				ls_sql = "SELECT hmd201_vid FROM hmd201 WHERE (1 = 1)";
				if (ldrv_Row["身分證字號"].ToString().Trim() != "")
					ls_sql += " AND hmd201_ssn = '" + ldrv_Row["身分證字號"].ToString().Trim() + "'";
				if (ldrv_Row["志工手冊編號"].ToString().Trim() != "")
					ls_sql += " AND hmd201_bookid = '" + ldrv_Row["志工手冊編號"].ToString().Trim() + "'";
				if (ldrv_Row["志工代碼"].ToString().Trim() != "")
					ls_sql += " AND hmd201_vid = '" + ldrv_Row["志工代碼"].ToString().Trim() + "'";

				
				DbMethods.uf_ExecSQL(ls_sql, ref ls_vid);
				
				if (ls_vid == "")
				{
					ls_msg = "";

					if (ldrv_Row["身分證字號"].ToString().Trim() != "")
						ls_msg += "身分證字號「" + ldrv_Row["身分證字號"].ToString().Trim() + "」";
					if (ldrv_Row["志工手冊編號"].ToString().Trim() != "")
						ls_msg += "志工手冊編號「" + ldrv_Row["志工手冊編號"].ToString().Trim() + "」";
					if (ldrv_Row["志工代碼"].ToString().Trim() != "")
						ls_msg += "志工代碼「" + ldrv_Row["志工代碼"].ToString().Trim() + "」";

					throw new Exception(ls_msg + "找不到此志工基本資料，請修正後重新匯入！");
				}
				else
				{
					indb_hle201.uf_InsertRow(out ldrv_new);
					li_no++;

					ldrv_new["hle201_lid"] = "Slog" + Convert.ToString(li_no).PadLeft(9, '0');
					ldrv_new["hle201_vid"] = ls_vid;
					ldrv_new["hle201_type"] = "1";
					ldrv_new["hle201_sdatetime"] = Convert.ToDateTime(ldrv_Row["服勤日期"].ToString().Trim()).AddHours(Convert.ToInt16(ldrv_Row["開始時間(小時)"].ToString().Trim())).AddMinutes(Convert.ToInt16(ldrv_Row["開始時間(分鐘)"].ToString().Trim()));
					ldrv_new["hle201_cancel"] = "N";
					ldrv_new["hle201_ip"] = this.Request.UserHostAddress;
					ldrv_new["hle201_aid"] = LoginUser.ID;
					ldrv_new["hle201_adt"] = DbMethods.uf_GetDateTime();
					ldrv_new["hle201_uid"] = LoginUser.ID;
					ldrv_new["hle201_udt"] = DbMethods.uf_GetDateTime();

					ldrv_new.EndEdit();

					indb_hle201.uf_InsertRow(out ldrv_new);
					li_no++;

					ldrv_new["hle201_lid"] = "Slog" + Convert.ToString(li_no).PadLeft(9, '0');
					ldrv_new["hle201_vid"] = ls_vid;
					ldrv_new["hle201_type"] = "2";
					ldrv_new["hle201_sdatetime"] = Convert.ToDateTime(ldrv_Row["服勤日期"].ToString().Trim()).AddHours(Convert.ToInt16(ldrv_Row["結束時間(小時)"].ToString().Trim())).AddMinutes(Convert.ToInt16(ldrv_Row["結束時間(分鐘)"].ToString().Trim()));
					ldrv_new["hle201_cancel"] = "N";
					ldrv_new["hle201_ip"] = this.Request.UserHostAddress;
					ldrv_new["hle201_aid"] = LoginUser.ID;
					ldrv_new["hle201_adt"] = DbMethods.uf_GetDateTime();
					ldrv_new["hle201_uid"] = LoginUser.ID;
					ldrv_new["hle201_udt"] = DbMethods.uf_GetDateTime();

					ldrv_new.EndEdit();
				}
			}

			// 回存
			if (this.indb_hle201.uf_Update() != 1)
			{
				indb_hle201.ds_Data.RejectChanges();
				uf_Msg("匯入失敗" + indb_hle201.ErrorMsg);
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			if (ldv_data != null) ldv_data.Dispose();
			if (lds_data != null) lds_data.Dispose();
			if (lcn_Conn != null)
			{
				lcn_Conn.Close();
				lcn_Conn.Dispose();
			}
		}
	}
}
