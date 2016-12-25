// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–時間選擇 之 Web 使用者控制項
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

public partial class proj_uctrl_u_TimeSelect : WIT.Template.Project.u_UserControl
{
    #region ☆ Declare Events ----------------------------------------- 撰寫人員：fen

    public event System.EventHandler ue_TimeChanged;

    #endregion

	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：選擇分的區間(預設為 1)</summary>
	private int ii_MinPeriod = 1;

	#endregion

	#region ☆ Declare Properties ------------------------------------- 撰寫人員：fen

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
			ls_date = YMD.Value + " " + hh.SelectedItem.Text + ":" + mm.SelectedItem.Text + ":00";
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
			YMD.Value = ldt_date.Date.ToString("yyyy/MM/dd");

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
	/// <summary>屬性描述：選擇分的區間(預設為 1)</summary>
	public int MinPeriod
	{
		get { return this.ii_MinPeriod; }
		set { this.ii_MinPeriod = value; }
	}

    // =========================================================================
    /// <summary>屬性描述：hh是否自動 PostBack </summary>
    public bool hhAutoPostBack
    {
        get { return this.hh.AutoPostBack; }
        set { this.hh.AutoPostBack = value; }
    }

    // =========================================================================
    /// <summary>屬性描述：hh是否自動 PostBack </summary>
    public bool mmAutoPostBack
    {
        get { return this.mm.AutoPostBack; }
        set { this.mm.AutoPostBack = value; }
    }

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟（在 WebForm 的 Page_Load 之後處理）
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
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
				if (Math.IEEERemainder(li_i, this.ii_MinPeriod) == 0)
					mm.Items.Add(new ListItem(li_i.ToString("00"), li_i.ToString()));
			}
			mm.SelectedIndex = 0;
		}
	}
    protected void time_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ue_TimeChanged != null)
        {
            this.ue_TimeChanged(this, System.EventArgs.Empty);
        }
    }

}
