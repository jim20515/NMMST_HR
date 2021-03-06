﻿// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–日期選擇 之 Web 使用者控制項–民國年（用表格定位）
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
using System.Drawing;
using WIT.Template.Project;

public partial class proj_uctrl_u_DateSelect_ROC1 : WIT.Template.Project.u_UserControl
{
	#region ☆ Declare Events ----------------------------------------- 撰寫人員：fen

	public event System.EventHandler ue_TextChanged;

	#endregion

	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：最小選擇日</summary>
	private DateTime idt_selectday_min = new DateTime(1912, 1, 1);
	/// <summary>變數描述：最大選擇日</summary>
	private DateTime idt_selectday_max = new DateTime(2910, 12, 31);
	/// <summary>變數描述：原來的背景色</summary>
	private Color i_color = Color.White; // Color.FromArgb(222, 255, 255);

	#endregion

	#region ☆ Declare Properties ------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>屬性描述：選擇日期值–yyyy/MM/dd hh:mm:ss(錯誤值則直接傳回空字串)（覆蓋上層）</summary>
	public override string Value
	{
		get
		{
			// ##### 宣告變數 #####
			string ls_date;

			// 將輸入的民國年轉換成西元年
			ls_date = DateMethods.uf_YYY_To_YYYY(tbx_Input.Text);

			// 如果傳回空字串表示有錯誤，清空控制項資料
			if (ls_date == "") tbx_Input.Text = "";

			return ls_date;
		}

		set
		{
			// ##### 宣告變數 #####
			string ls_date;

			// 將顯示的西元年轉換成民國年
			ls_date = DateMethods.uf_YYYY_To_YYY(value);

			// 如果傳回空字串表示有錯誤，恢復控制項資料
			if (ls_date == "") tbx_Input.Text = value;

			tbx_Input.Text = ls_date;
		}
	}

	// =========================================================================
	/// <summary>屬性描述：最小選擇日期值</summary>
	public DateTime MinValue
	{
		get { return this.idt_selectday_min; }
		set { this.idt_selectday_min = value; }
	}

	// =========================================================================
	/// <summary>屬性描述：最大選擇日期值</summary>
	public DateTime MaxValue
	{
		get { return this.idt_selectday_max; }
		set { this.idt_selectday_max = value; }
	}

	// =========================================================================
	/// <summary>屬性描述：是否自動 PostBack </summary>
	public bool AutoPostBack
	{
		get { return this.tbx_Input.AutoPostBack; }
		set { this.tbx_Input.AutoPostBack = value; }
	}

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟（在 WebForm 的 Page_Load 之後處理）
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 第一次執行時記錄背景色
		if (!this.IsPostBack) this.i_color = tbx_Input.BackColor;

		// 顯示圖片
		bt_Select.Src = Request.ApplicationPath + "/proj_img/Calendar.gif";

		// 設定執行事件
		//bt_Select.Attributes["onclick"] = "window.open('" + Request.ApplicationPath + "/proj_uctrl/p_DateSelect.aspx?ReturnFormID=" + this.Page.Form.ID + "&ReturnObjectID=" + tbx_Input.ClientID + "&MinValue=" + this.idt_selectday_min.ToString("yyyy/MM/dd") + "&MaxValue=" + this.idt_selectday_max.ToString("yyyy/MM/dd") + "&Value=' + " + tbx_Input.ClientID + ".value + '&ValueType=ROC','','top=200,left=300,height=216,width=225,status=no,toolbar=no,menubar=no,location=no',''); return false;";
		bt_Select.Attributes["onclick"] = "window.showModalDialog('" + Request.ApplicationPath + "/proj_uctrl/p_DateSelect.aspx?ReturnFormID=" + this.Page.Form.ID + "&ReturnObjectID=" + tbx_Input.ClientID + "&MinValue=" + this.idt_selectday_min.ToString("yyyy/MM/dd") + "&MaxValue=" + this.idt_selectday_max.ToString("yyyy/MM/dd") + "&Value=' + " + tbx_Input.ClientID + ".value + '&ValueType=ROC', window, 'dialogHeight:' + uf_FixHeight(216) + 'px;dialogWidth:' + uf_FixWidth(224) + 'px;resizable:yes;status:no;'); return false;";
		tbx_Input.Attributes["onBlur"] = "uf_GetDateTime_ROC(" + tbx_Input.ClientID + ");";
		tbx_Input.Attributes["Mask"] = "___/__/__";
		if (this.idt_selectday_min.ToString("yyyy/MM/dd") != "0001/01/01")
			tbx_Input.Attributes["MinValue"] = this.idt_selectday_min.ToString("yyyy/MM/dd");
		if (this.idt_selectday_max.ToString("yyyy/MM/dd") != "9999/12/31")
			tbx_Input.Attributes["MaxValue"] = this.idt_selectday_max.ToString("yyyy/MM/dd");
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定所有顯示的控制項 Enabled 屬性
	/// </summary>
	/// <param name="ab_IsEnabled">可按(true)；不可按(false)</param>
	public void uf_Enabled(bool ab_IsEnabled)
	{
		tbx_Input.Enabled = ab_IsEnabled;
		if (ab_IsEnabled)
			tbx_Input.BackColor = this.i_color;
		else
			tbx_Input.BackColor = Color.Silver;
		bt_Select.Visible = ab_IsEnabled;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定所有顯示的控制項 ReadOnly 屬性
	/// </summary>
	/// <param name="ab_IsReadOnly">唯讀(true)；不唯讀(false)</param>
	public void uf_ReadOnly(bool ab_IsReadOnly)
	{
		tbx_Input.ReadOnly = ab_IsReadOnly;
		if (ab_IsReadOnly)
		{
			tbx_Input.BackColor = Color.Transparent;
			tbx_Input.BorderStyle = BorderStyle.None;
		}
		else
		{
			tbx_Input.BackColor = this.i_color;
			tbx_Input.BorderStyle = BorderStyle.NotSet;
		}
		bt_Select.Visible = !ab_IsReadOnly;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：修改《日期》資料所做的處理
	/// </summary>
	protected void tbx_Input_TextChanged(object sender, System.EventArgs e)
	{
		if (this.ue_TextChanged != null)
		{
			this.ue_TextChanged(this, System.EventArgs.Empty);
		}
	}
}
