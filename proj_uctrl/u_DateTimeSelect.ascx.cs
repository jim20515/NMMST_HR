// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–日期時間時間選擇 之 Web 使用者控制項–西元年
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

public partial class proj_uctrl_u_DateTimeSelect : WIT.Template.Project.u_UserControl
{
	// =========================================================================
	/// <summary>屬性描述：選擇日期時間值–yyyy/MM/dd HH:mm:ss(日期為傳入值，沒有則為1900/01/01)（覆蓋上層）</summary>
	public override string Value
	{
		get
		{
			// ##### 宣告變數 #####
			DateTime ldt_date;
			string ls_date;

			// 得到組成的日期
			ls_date = YMD.Text.Trim() + " " + hh.SelectedItem.Text + ":" + mm.SelectedItem.Text + ":00";
			try
			{
				ldt_date = Convert.ToDateTime(ls_date);
				return ls_date;
			}
			catch
			{
				return "1900/01/01 00:00:00";
			}
		}

		set
		{
			// ##### 宣告變數 #####
			DateTime ldt_date;
			ListItem lli_Item;

			// 判斷時間是否正確
			try
			{
				ldt_date = Convert.ToDateTime(value);
			}
			catch
			{
				ldt_date = Convert.ToDateTime("1900/01/01");
			}

			// 日期
			YMD.Text = ldt_date.Date.ToString("yyyy/MM/dd");

			// 小時
			lli_Item = hh.Items.FindByValue(ldt_date.Hour.ToString());
			if (lli_Item != null)
				hh.SelectedIndex = hh.Items.IndexOf(lli_Item);

			// 分鐘
			lli_Item = mm.Items.FindByValue(ldt_date.Minute.ToString());
			if (lli_Item != null)
				mm.SelectedIndex = mm.Items.IndexOf(lli_Item);
		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟（在 WebForm 的 Page_Load 之後處理）
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 顯示圖片
		bt_Select.Src = Request.ApplicationPath + "/proj_img/Calendar.gif";

		// 設定控制項的 OnClick JavaScript
		//bt_Select.Attributes["onclick"] = "window.open('" + Request.ApplicationPath + "/proj_uctrl/p_DateSelect.aspx?ReturnFormID=" + this.Page.Form.ID + "&ReturnObjectID=" + YMD.ClientID + "','','top=200,left=300,height=216,width=225,status=no,toolbar=no,menubar=no,location=no',''); return false;";
		bt_Select.Attributes["onclick"] = "window.showModalDialog('" + Request.ApplicationPath + "/proj_uctrl/p_DateSelect.aspx?ReturnFormID=" + this.Page.Form.ID + "&ReturnObjectID=" + YMD.ClientID + "', window, 'dialogHeight:' + uf_FixHeight(216) + 'px;dialogWidth:' + uf_FixWidth(224) + 'px;resizable:yes;status:no;'); return false;";
		YMD.Attributes["onblur"] = "uf_GetDateTime(" + YMD.ClientID + ");";
		YMD.Attributes["Mask"] = "____/__/__";

		// 如果是第一次執行
		if (!IsPostBack)
		{
			// 替小時下拉增加項目
			for (int li_i = 0; li_i <= 23; li_i++)
			{
				hh.Items.Add(new ListItem(li_i.ToString("00"), li_i.ToString()));
			}
			hh.SelectedIndex = 0;

			// 替分鐘下拉增加項目
			for (int li_i = 0; li_i <= 59; li_i++)
			{
				mm.Items.Add(new ListItem(li_i.ToString("00"), li_i.ToString()));
			}
			mm.SelectedIndex = 0;
		}
	}
}
