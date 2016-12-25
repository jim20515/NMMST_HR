// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 動態語法查詢
// 2. 撰寫人員：fen
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

public partial class proj_right_p_SuperQuery : p_SuperPage
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Query 《查詢》按鈕所做的處理
	/// </summary>
	protected void bt_Query_Click(object sender, System.EventArgs e)
	{
		this.uf_Action(false);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Export 《匯出》按鈕所做的處理
	/// </summary>
	protected void bt_Export_Click(object sender, EventArgs e)
	{
		this.uf_Action(true);
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：按下查詢／匯出按鈕所做的處理
	/// </summary>
	/// <param name="ab_IsExport">是否為匯出–是(true)；否(false)</param>
	private void uf_Action(bool ab_IsExport)
	{
		// 錯誤的執行語法
		if (dwQ_sql.Text.Trim() == "")
		{
			this.uf_Msg("(Info) 「執行語法」欄位一定要輸入");
			this.uf_SetFocus(dwQ_sql);
			return;
		}
		else if (!dwQ_sql.Text.Trim().ToLower().StartsWith("select"))
		{
			this.uf_Msg("(WIT) 只能執行 Select 語法");
			this.uf_SetFocus(dwQ_sql);
			return;
		}

		// 錯誤的執行密碼
		if (dwQ_pwd.Text.Trim() == "")
		{
			this.uf_Msg("(Info) 「執行密碼」欄位一定要輸入");
			this.uf_SetFocus(dwQ_pwd);
			return;
		}
		else if (dwQ_pwd.Text.Trim() != Convert.ToChar(119).ToString() + Convert.ToChar(105).ToString() + Convert.ToChar(116).ToString() + Convert.ToChar(119).ToString() + Convert.ToChar(105).ToString() + Convert.ToChar(116).ToString())
		{
			this.uf_Msg("(WIT) 錯誤的執行密碼");
			this.uf_SetFocus(dwQ_pwd);
			return;
		}

		dwG.Visible = false;

		// ##### 宣告變數 #####
		DataSet lds_Data;

		// 利用執行語法取出資料
		try
		{
			DbMethods.Timeout = 0;
			if (DbMethods.uf_Retrieve_FromSQL(out lds_Data, dwQ_sql.Text) == -1)
			{
				DbMethods.Timeout = DbMethods.Timeout_Default;
				this.uf_Msg(DbMethods.ErrorMsg);
				return;
			}
			DbMethods.Timeout = DbMethods.Timeout_Default;
			dwG.Visible = true;
			dgG.DataSource = lds_Data;
			dgG.DataBind();
			for (int li_i = 0; li_i < dgG.Columns.Count; li_i++)
			{
				dgG.Columns[li_i].HeaderStyle.Wrap = false;
				dgG.Columns[li_i].ItemStyle.Wrap = false;
				dgG.Columns[li_i].FooterStyle.Wrap = false;
			}
			if (lds_Data.Tables[0].Rows.Count <= 0)
				this.uf_Msg("查無符合資料");
			else
			{
				if (ab_IsExport)
				{
					// ##### 宣告變數 #####
					string ls_key = "superquery_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
					string ls_fileName = ls_key + ".txt";
					string ls_file = System.Web.HttpRuntime.AppDomainAppPath + "App_Data\\File\\" + ls_fileName;
					string ls_ret;

					WText lo_WText = new WText(lds_Data.Tables[0]);
					ls_ret = lo_WText.uf_FileExport(ls_file, true, WText.SplitMode.Char);
					if (ls_ret.StartsWith("-"))
						this.uf_Msg(ls_ret);
					else
					{
						// 將檔案內容讀入 Application 中
						this.Application[ls_key] = System.IO.File.ReadAllBytes(ls_file);
						this.Application["name:" + ls_key] = ls_fileName;

						// 下載檔案
						this.ClientScript.RegisterStartupScript(this.GetType(), "", "document.downloadFrame.location = \"" + this.Request.ApplicationPath + "/proj_uctrl/h_download_file.ashx?key=" + ls_key + "\";", true);
					}

					// 刪除檔案
					try { System.IO.File.Delete(ls_file); }	catch { }
					lo_WText = null;
				}
			}
		}
		catch (SystemException e1)
		{
			this.uf_Msg("(System) 執行 SQL 語法失敗。\\n\\n◎ Error Message: \\n" + e1.Message);
		}
	}
}
