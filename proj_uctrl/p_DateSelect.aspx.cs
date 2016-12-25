// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–日期選擇之月曆
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

public partial class proj_uctrl_p_DateSelect : System.Web.UI.Page
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：開啟月曆的 WebPage FormID</summary>
	private string is_ReturnFormID;
	/// <summary>變數描述：開啟月曆的 WebControl ID</summary>
	private string is_ReturnObjectID;
	/// <summary>變數描述：開啟月曆的最小選擇日</summary>
	private DateTime idt_selectday_min = new DateTime(1, 1, 1);
	/// <summary>變數描述：開啟月曆的最大選擇日</summary>
	private DateTime idt_selectday_max = new DateTime(9999, 12, 31);
	/// <summary>變數描述：是否回傳民國年</summary>
	private bool ib_IsROC = false;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		this.is_ReturnFormID = this.Request["ReturnFormID"];
		this.is_ReturnObjectID = this.Request["ReturnObjectID"];
		try
		{
			this.idt_selectday_min = Convert.ToDateTime(this.Request["MinValue"]);
		}
		catch { }

		try
		{
			this.idt_selectday_max = Convert.ToDateTime(this.Request["MaxValue"]);
		}
		catch { }

		// 判斷是否為民國年處理
		if (this.Request["ValueType"] != null
			&& this.Request["ValueType"].ToString() == "ROC")
		{
			ib_IsROC = true;
			lb_Year_t.Text = "民國年：";
		}

		// 如果是第一次執行
		if (!IsPostBack)
		{
			// 替年份下拉增加項目
			for (int li_i = 1912; li_i <= 2079; li_i++)
			{
				if (ib_IsROC)
					ddl_Year.Items.Add(new ListItem(Convert.ToString(li_i - 1911), li_i.ToString()));
				else
					ddl_Year.Items.Add(new ListItem(Convert.ToString(li_i), li_i.ToString()));
			}
			MyCalendar.VisibleDate = DateTime.Now;

			try
			{
				// 判斷是否有傳入日期
				if (this.Request["Value"] != null
					&& this.Request["Value"].ToString() != "")
				{
					string ls_value = this.Request["Value"].ToString();

					if (ib_IsROC) ls_value = DateMethods.uf_YYY_To_YYYY(ls_value);

					// 將顯示日期改為輸入的日期
					MyCalendar.VisibleDate = Convert.ToDateTime(ls_value);
					MyCalendar.SelectedDate = MyCalendar.VisibleDate;
				}
			}
			catch { }

			try
			{
				ddl_Year.Items.FindByValue(MyCalendar.VisibleDate.Year.ToString()).Selected = true;
				ddl_Month.Items.FindByValue(MyCalendar.VisibleDate.Month.ToString()).Selected = true;
			}
			catch
			{
				// 將顯示日期改為輸入的日期
				MyCalendar.VisibleDate = DateTime.Now;
				MyCalendar.SelectedDate = MyCalendar.VisibleDate;
				ddl_Year.Items.FindByValue(MyCalendar.VisibleDate.Year.ToString()).Selected = true;
				ddl_Month.Items.FindByValue(MyCalendar.VisibleDate.Month.ToString()).Selected = true;
			}
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇年份做的處理
	/// </summary>
	protected void ddl_Year_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		MyCalendar.VisibleDate = new DateTime(Convert.ToInt32(ddl_Year.SelectedItem.Value), Convert.ToInt32(ddl_Month.SelectedItem.Value), 1);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇月份做的處理
	/// </summary>
	protected void ddl_Month_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		MyCalendar.VisibleDate = new DateTime(Convert.ToInt32(ddl_Year.SelectedItem.Value), Convert.ToInt32(ddl_Month.SelectedItem.Value), 1);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：選擇今天做的處理
	/// </summary>
	protected void lbt_Today_Click(object sender, System.EventArgs e)
	{
		MyCalendar.VisibleDate = DateTime.Now;

		// 改變查詢條件的年份和月份
		ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(DateTime.Now.Year.ToString()));
		ddl_Month.SelectedIndex = ddl_Month.Items.IndexOf(ddl_Month.Items.FindByValue(DateTime.Now.Month.ToString()));
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 MyCalendar 前後月份所做的處理
	/// </summary>
	protected void MyCalendar_VisibleMonthChanged(object sender, System.Web.UI.WebControls.MonthChangedEventArgs e)
	{
		// 改變查詢條件的年份和月份
		ddl_Year.SelectedIndex = ddl_Year.Items.IndexOf(ddl_Year.Items.FindByValue(e.NewDate.Year.ToString()));
		ddl_Month.SelectedIndex = ddl_Month.Items.IndexOf(ddl_Month.Items.FindByValue(e.NewDate.Month.ToString()));
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 MyCalendar 某一日期所做的處理
	/// </summary>
	protected void MyCalendar_SelectionChanged(object sender, System.EventArgs e)
	{
		// ##### 宣告變數 #####
		DateTime ldt_SelectedDate;
		string ls_JavaScript = "";


		// 取得選擇的日期
		ldt_SelectedDate = MyCalendar.SelectedDate;

		// 判斷選擇的日期是否小於最小選擇日或大於最大選擇日，不處理
		if (ldt_SelectedDate < this.idt_selectday_min || ldt_SelectedDate > this.idt_selectday_max) return;

		// 組成 JavaScript
		ls_JavaScript += "<script language=\"javascript\">" + "\r\n";
		ls_JavaScript += "	var lo_opener = opener;" + "\r\n";
		ls_JavaScript += "	if (lo_opener == null)" + "\r\n";
		ls_JavaScript += "		lo_opener = dialogArguments;" + "\r\n";
		// 判斷如果為民國年處理則轉換成民國年
		if (ib_IsROC)
			ls_JavaScript += "	lo_opener." + this.is_ReturnFormID + "." + this.is_ReturnObjectID + ".value='" + DateMethods.uf_YYYY_To_YYY(ldt_SelectedDate.ToString("yyyy/MM/dd")) + "';" + "\r\n";
		else
			ls_JavaScript += "	lo_opener." + this.is_ReturnFormID + "." + this.is_ReturnObjectID + ".value='" + ldt_SelectedDate.ToString("yyyy/MM/dd") + "';" + "\r\n";
		ls_JavaScript += "	if (lo_opener." + this.is_ReturnFormID + "." + this.is_ReturnObjectID + ".onchange != null)" + "\r\n";
		ls_JavaScript += "		lo_opener." + this.is_ReturnFormID + "." + this.is_ReturnObjectID + ".onchange();" + "\r\n";
		ls_JavaScript += "	close();" + "\r\n";
		ls_JavaScript += "</script>" + "\r\n";
		this.ClientScript.RegisterStartupScript(this.GetType(), "", ls_JavaScript, false);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：MyCalendar 產生每一個日期所做的處理
	/// </summary>
	protected void MyCalendar_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
	{
		// 判斷本日是否小於最小選擇日或大於最大選擇日，灰階
		if (e.Day.Date < this.idt_selectday_min || e.Day.Date > this.idt_selectday_max)
		{
			e.Cell.BackColor = Color.White;
			e.Cell.Enabled = false;
		}
	}
}
