// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–《新增；修改；刪除；清除》按鈕 之 Web 使用者控制項
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

public partial class proj_uctrl_u_BtSet_iduc : WIT.Template.Project.u_BtSet_iduc
{
	#region ☆ Declare Properties ------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>屬性描述：《新增》按鈕</summary>
	public Button ibt_Insert
	{
		get { return this.bt_Insert; }
		set { this.bt_Insert = value; }
	}

	// =========================================================================
	/// <summary>屬性描述：《修改》按鈕</summary>
	public Button ibt_Update
	{
		get { return this.bt_Update; }
		set { this.bt_Update = value; }
	}

	// =========================================================================
	/// <summary>屬性描述：《刪除》按鈕</summary>
	public Button ibt_Delete
	{
		get { return this.bt_Delete; }
		set { this.bt_Delete = value; }
	}

	// =========================================================================
	/// <summary>屬性描述：《清除》按鈕</summary>
	public Button ibt_Clean
	{
		get { return this.bt_Clean; }
		set { this.bt_Clean = value; }
	}

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 執行成功顯示訊息
		//this.InsertMsg = "新增成功";
		//this.UpdateMsg = "修改成功";
		//this.DeleteMsg = "刪除成功";
		//this.CleanMsg = "清除成功";

		// 防止重複提交
		this.uf_OnClick(bt_Insert);
		this.uf_OnClick(bt_Update);
		this.uf_OnClick(bt_Delete);
		this.uf_OnClick(bt_Clean);
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：按鈕防止重複提交
	/// </summary>
	/// <param name="abt_Button">按鈕</param>
	private void uf_OnClick(Button abt_Button)
	{
		string ls_script = this.Page.ClientScript.GetPostBackEventReference(abt_Button, "") + ";this.disabled=true;";
		if (abt_Button.Attributes["onclick"] != null && abt_Button.Attributes["onclick"].IndexOf(ls_script) < 0)
			abt_Button.Attributes["onclick"] += ls_script;
		else
			abt_Button.Attributes["onclick"] = ls_script;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定欲顯示的按鈕（覆蓋上層）
	/// </summary>
	/// <param name="as_DisplayBt">欲顯示的按鈕組（IUDC）</param>
	public override void uf_Display(string as_DisplayBt)
	{
		// 恢復初始值
		ii_btindex = 0;
		this.uf_BtVisible(as_DisplayBt, "C", bt_Clean);
		this.uf_BtVisible(as_DisplayBt, "D", bt_Delete);
		this.uf_BtVisible(as_DisplayBt, "U", bt_Update);
		this.uf_BtVisible(as_DisplayBt, "I", bt_Insert);
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定所有顯示的按鈕 Enabled 屬性（覆蓋上層）
	/// </summary>
	/// <param name="ab_IsEnabled">可按(true)；不可按(false)</param>
	public override void uf_Enabled(bool ab_IsEnabled)
	{
		bt_Insert.Enabled = ab_IsEnabled;
		bt_Update.Enabled = ab_IsEnabled;
		bt_Delete.Enabled = ab_IsEnabled;
		bt_Clean.Enabled = ab_IsEnabled;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定顯示的按鈕及位置（覆蓋上層）
	/// </summary>
	/// <param name="as_DisplayCmd">顯示的按鈕組</param>
	/// <param name="as_Index">處理的按鈕</param>
	/// <param name="abt_Button">處理的按鈕</param>
	protected new void uf_BtVisible(string as_DisplayCmd, string as_Index, Button abt_Button)
	{
		if (this.UseButton.IndexOf(as_Index) == -1 || as_DisplayCmd.IndexOf(as_Index) == -1)
		{
			abt_Button.Visible = false;
		}
		else
		{
			// Button Add 1
			this.ii_btindex++;
			int li_buttonwidth = 80;
			abt_Button.Style.Add("left", Convert.ToString((li_buttonwidth + 5) * 3 - ((li_buttonwidth + 5) * (ii_btindex - 1))) + "px");
			abt_Button.Visible = true;
		}
	}
}
