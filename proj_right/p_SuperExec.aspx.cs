// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫 - 動態語法執行
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

public partial class proj_right_p_SuperExec : p_SuperPage
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
	/// 事件描述：按下 bt_Query 《執行》按鈕所做的處理
	/// </summary>
	protected void bt_Query_Click(object sender, System.EventArgs e)
	{
		// 錯誤的執行語法
		if (dwQ_sql.Text.Trim() == "")
		{
			this.uf_Msg("(Info) 「執行語法」欄位一定要輸入！");
			this.uf_SetFocus(dwQ_sql);
			return;
		}

		// 錯誤的執行密碼
		if (dwQ_pwd.Text.Trim() == "")
		{
			this.uf_Msg("(Info) 「執行密碼」欄位一定要輸入！");
			this.uf_SetFocus(dwQ_pwd);
			return;
		}
		else if (dwQ_pwd.Text.Trim() != Convert.ToChar(119).ToString() + Convert.ToChar(105).ToString() + Convert.ToChar(116).ToString() + Convert.ToChar(119).ToString() + Convert.ToChar(105).ToString() + Convert.ToChar(116).ToString())
		{
			this.uf_Msg("(WIT) 錯誤的執行密碼！");
			this.uf_SetFocus(dwQ_pwd);
			return;
		}

		dwG.Visible = false;

		// 判斷執行的語法種類
		if (!dwQ_sql.Text.Trim().ToLower().StartsWith("select") && !dwQ_sql.Text.Trim().ToLower().StartsWith("exec"))
		{
			DbMethods.Timeout = 0;
			if (DbMethods.uf_ExecSQL(dwQ_sql.Text) == -1)
			{
				this.uf_Msg(DbMethods.ErrorMsg);
			}
			else
			{
				this.uf_Msg("執行完成");
			}
			DbMethods.Timeout = DbMethods.Timeout_Default;
		}
		else
		{
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
			}
			catch (SystemException e1)
			{
				this.uf_Msg("(System) 執行 SQL 語法失敗。\\n\\n◎ Error Message: \\n" + e1.Message);
			}
		}
	}
}
