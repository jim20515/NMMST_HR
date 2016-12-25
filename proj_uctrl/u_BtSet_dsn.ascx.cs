// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–《刪除；儲存；下一步》按鈕 之 Web 使用者控制項
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

public partial class proj_uctrl_u_BtSet_dsn : System.Web.UI.UserControl
{
	#region ☆ Declare Events ----------------------------------------- 撰寫人員：fen

	public event System.EventHandler ue_DeleteClick;
	public event System.EventHandler ue_SaveClick;
	public event System.EventHandler ue_NextClick;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {

    }

	// =========================================================================
	/// <summary>
	/// 函式描述：設定欲顯示的按鈕
	/// </summary>
	/// <param name="as_DisplayBt">欲顯示的按鈕組（DSN）</param>
	public void uf_Display(string as_DisplayBt)
	{
		this.uf_BtVisible(as_DisplayBt, "D", bt_Delete);
		this.uf_BtVisible(as_DisplayBt, "S", bt_Save);
		this.uf_BtVisible(as_DisplayBt, "N", bt_Next);
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定顯示的按鈕及位置
	/// </summary>
	/// <param name="as_DisplayCmd">顯示的按鈕組</param>
	/// <param name="as_Index">處理的按鈕</param>
	/// <param name="abt_Button">處理的按鈕</param>
	private void uf_BtVisible(string as_DisplayCmd, string as_Index, Button abt_Button)
	{
		if (as_DisplayCmd.IndexOf(as_Index) == -1)
		{
			abt_Button.Visible = false;
		}
		else
		{
			abt_Button.Visible = true;
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下《刪除》按鈕所做的處理
	/// </summary>
	protected void bt_Delete_Click(object sender, System.EventArgs e)
	{
		if (this.ue_DeleteClick != null)
		{
			this.ue_DeleteClick(this, System.EventArgs.Empty);
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下《儲存》按鈕所做的處理
	/// </summary>
	protected void bt_Save_Click(object sender, System.EventArgs e)
	{
		if (this.ue_SaveClick != null)
		{
			this.ue_SaveClick(this, System.EventArgs.Empty);
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下《下一步》按鈕所做的處理
	/// </summary>
	protected void bt_Next_Click(object sender, System.EventArgs e)
	{
		if (this.ue_NextClick != null)
		{
			this.ue_NextClick(this, System.EventArgs.Empty);
		}
	}
}
