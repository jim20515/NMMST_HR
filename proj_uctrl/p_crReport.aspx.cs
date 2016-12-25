// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–Crystal Report Viewer
// 2. 撰寫人員：fen
// 3. 使用方式：(1)參數：Report				報表名稱（統一放置於 /App_Data/Report 下）
//              (2)參數：Addsql				動態加入的 SQL 語法 目前僅可使用完整的 SELECT 語法替代（暫不提供）
//              (3)參數：Argument			報表需要的 Paramiter 參數，中間以「;」區別，一個參數如果允許多個值則以「|」串連
//                 　　　					值如果含有「,」需轉成「$ASCII44$」，「;」需轉成「$ASCII59$」
//              (4)參數：CRSelection		報表的 RecordSelection 語法 需符合 Crystal 的語法規範
//              (5)參數：Margins			報表列印邊界(上邊界;左邊界;下邊界;右邊界)–單位為公分(cm)
//              (6)參數：vType				開啟報表種類–Crystal viewer(crs)；PDf檔(pdf)
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class proj_uctrl_p_crReport : p_WebPage
{
	/// <summary>變數描述：是否顯示提供 Debug 的訊息</summary>
	private bool ib_ShowDebugMsg = (DbMethods.uf_ProfileString(DbMethods.is_INIPath, "HideSetup", "CRShowDebugMsg", "").ToUpper() == "Y" ? true : false);
	/// <summary>控制描述：報表檔案物件</summary>
	private ReportDocument ird_Report;

	#region ☆ (參數) Declare Properties ------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>屬性描述：[ViewState] 取得參數 Report</summary>
	protected string argReport
	{
		get
		{
			if (!this.IsPostBack)
			{
				string ls_value = (this.Request["Report"] != null ? this.Request["Report"].Trim().Replace("'", "").Replace("\"", "") : "");
				this.ViewState["vs_Report"] = ls_value;
				return ls_value;
			}
			else
				return this.ViewState["vs_Report"].ToString();
		}
	}

	// =========================================================================
	/// <summary>屬性描述：[ViewState] 取得參數 Addsql</summary>
	protected string argAddsql
	{
		get
		{
			if (!this.IsPostBack)
			{
				string ls_value = (this.Request["Addsql"] != null ? ComMethods.uf_ConvertFrom(this.Request["Addsql"].Trim()) : "");
				this.ViewState["vs_Addsql"] = ls_value;
				return ls_value;
			}
			else
				return this.ViewState["vs_Addsql"].ToString();
		}
	}

	// =========================================================================
	/// <summary>屬性描述：[ViewState] 取得參數 Argument</summary>
	protected string argArgument
	{
		get
		{
			if (!this.IsPostBack)
			{
				string ls_value = (this.Request["Argument"] != null ? ComMethods.uf_ConvertFrom(this.Request["Argument"].Trim()).Replace("$ASCII44$", ",") : "");
				this.ViewState["vs_Argument"] = ls_value;
				return ls_value;
			}
			else
				return this.ViewState["vs_Argument"].ToString();
		}
	}

	// =========================================================================
	/// <summary>屬性描述：[ViewState] 取得參數 CRSelection</summary>
	protected string argCRSelection
	{
		get
		{
			if (!this.IsPostBack)
			{
				string ls_value = (this.Request["CRSelection"] != null ? ComMethods.uf_ConvertFrom(this.Request["CRSelection"].Trim()) : "");
				this.ViewState["vs_CRSelection"] = ls_value;
				return ls_value;
			}
			else
				return this.ViewState["vs_CRSelection"].ToString();
		}
	}

	// =========================================================================
	/// <summary>屬性描述：[ViewState] 取得參數 Margins</summary>
	protected string argMargins
	{
		get
		{
			if (!this.IsPostBack)
			{
				string ls_value = (this.Request["Margins"] != null ? this.Request["Margins"].Trim() : "");
				this.ViewState["vs_Margins"] = ls_value;
				return ls_value;
			}
			else
				return this.ViewState["vs_Margins"].ToString();
		}
	}

	// =========================================================================
	/// <summary>屬性描述：[ViewState] 取得參數 vType</summary>
	protected string argvType
	{
		get
		{
			if (!this.IsPostBack)
			{
				string ls_value = (this.Request["vType"] != null ? this.Request["vType"].Trim().ToLower() : "");
				this.ViewState["vs_vType"] = ls_value;
				return ls_value;
			}
			else
				return this.ViewState["vs_vType"].ToString();
		}
	}

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 如果使用者沒有登入則不允許顯示報表，直接離開
		if (LoginUser.ID == null)
		{
			this.uf_ShowMsg("-使用者未登入");
			return;
		}

		// 宣告並接收傳入值
		String ls_Report, ls_Addsql, ls_Argument, ls_CRSelection, ls_Margins, ls_vType;

		ls_Report = this.argReport;
		ls_Addsql = this.argAddsql;
		ls_Argument = this.argArgument;
		ls_CRSelection = this.argCRSelection;
		ls_Margins = this.argMargins;
		ls_vType = this.argvType;
		// 此頁不接受 dbg 參數，如要顯示 Debug 訊息則到 ini 檔中設定
		if (ls_vType == "dbg") ls_vType = "";

		// 判斷是否指定顯示報表且報表檔案存在
		if (ls_Report == "")
		{
			this.uf_ShowMsg("-未指定顯示報表");
			return;
		}
		ls_Report = "../App_Data/Report/" + ls_Report;
		ls_Report = Server.MapPath(ls_Report);
		if (! System.IO.File.Exists(ls_Report))
		{
			this.uf_ShowMsg("-報表檔案不存在");
			return;
		}

		if (this.ib_ShowDebugMsg)
			this.uf_ShowMsg("Report=" + ls_Report + "<br/>Addsql=" + ls_Addsql + "<br/>Argument=" + ls_Argument + "<br/>CRSelection=" + ls_CRSelection + "<br/>Margins=" + ls_Margins + "<br/>");

		// 設定報表檔案物件
		this.ird_Report = new ReportDocument();
		this.ird_Report.Load(ls_Report);

		// 設定報表參數值
		if (ls_Argument != "") this.uf_SetParameterFieldValue(ls_Argument.Split(';'));

		// 設定報表 CRSelection
		if (ls_CRSelection != "") this.uf_SetRecordSelectionFormula(ls_CRSelection);

		// 設定報表列印邊界
		if (ls_Margins != "") this.uf_SetPageMargins(ls_Margins.Split(';'));

		// 設定報表資料庫連接資訊
		this.uf_SetDBLogon();

		// 顯示出報表／匯出報表
		if (ls_vType != "pdf")
		{
			crViewer.Visible = true;
			crViewer.ReportSource = this.ird_Report;
		}
		else
			this.uf_ExportPDF();
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁卸載
	/// </summary>
	protected void Page_Unload(object sender, EventArgs e)
	{
		try
		{
			if (this.ird_Report != null)
			{
				this.ird_Report.Close();
				this.ird_Report.Dispose();
			}
			crViewer.Dispose();
		}
		catch { }
	}

	#region ☆ 設定報表屬性 Methods ----------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：設定報表參數值
	/// </summary>
	/// <param name="asa_ArgValues">參數值陣列</param>
	private void uf_SetParameterFieldValue(string[] asa_ArgValues)
	{
		// 依序處理每個參數
		int li_i = 0;
		foreach (ParameterFieldDefinition l_ParameterFieldDefinition in this.ird_Report.DataDefinition.ParameterFields)
		{
			// 如果超出傳入參數值的數量則離開
			if (li_i >= asa_ArgValues.Length) return;

			ParameterValues la_CurrentParameterValues = new ParameterValues();
			string[] lsa_SubValues = asa_ArgValues[li_i].Replace("$ASCII59$", ";").Split('|');

			if (l_ParameterFieldDefinition.DiscreteOrRangeKind == DiscreteOrRangeKind.RangeValue)
			{
				if (lsa_SubValues.Length >= 2)
				{
					ParameterRangeValue l_ParameterRangeValue = new ParameterRangeValue();
					l_ParameterRangeValue.StartValue = lsa_SubValues[0];
					l_ParameterRangeValue.EndValue = lsa_SubValues[1];
					l_ParameterRangeValue.LowerBoundType = RangeBoundType.BoundInclusive;
					l_ParameterRangeValue.UpperBoundType = RangeBoundType.BoundInclusive;
					la_CurrentParameterValues.Add(l_ParameterRangeValue);
				}
			}
			else
			{
				// 依序處理每個參數的子值
				foreach (string ls_SubValue in lsa_SubValues)
				{
					ParameterDiscreteValue l_ParameterDiscreteValue = new ParameterDiscreteValue();
					l_ParameterDiscreteValue.Value = ls_SubValue;
					la_CurrentParameterValues.Add(l_ParameterDiscreteValue);
				}
			}

			l_ParameterFieldDefinition.ApplyCurrentValues(la_CurrentParameterValues);
			li_i ++;
		}
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定報表 CRSelection
	/// </summary>
	/// <param name="as_CRSelection">RecordSelectionFormula 值</param>
	private void uf_SetRecordSelectionFormula(string as_CRSelection)
	{
		this.ird_Report.DataDefinition.RecordSelectionFormula = as_CRSelection;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定報表列印邊界
	/// </summary>
	/// <param name="asa_ArgMargins">報表列印邊界陣列(上邊界;左邊界;下邊界;右邊界)</param>
	private void uf_SetPageMargins(string[] asa_ArgMargins)
	{
		/*
			1、單位是 Twips
			2、換算關係：
			點素(Twip)、英吋(Inch)、點(Point)、毫米(Millimeter)、像素(Pixel，這與屏幕分辨率有關)、厘米(Centimeter)

			1英吋		= 1440 Twips
			1厘米(cm)	= 567 Twips
			1英吋		= 72 Points
		 */
		int li_unit = 567;
		PageMargins l_PageMargins = this.ird_Report.PrintOptions.PageMargins;
		try
		{
			if (asa_ArgMargins.Length > 0 && asa_ArgMargins[0].Trim() != "") l_PageMargins.topMargin = Convert.ToInt32(li_unit * Convert.ToDecimal(asa_ArgMargins[0]));
			if (asa_ArgMargins.Length > 1 && asa_ArgMargins[1].Trim() != "") l_PageMargins.leftMargin = Convert.ToInt32(li_unit * Convert.ToDecimal(asa_ArgMargins[1]));
			if (asa_ArgMargins.Length > 2 && asa_ArgMargins[2].Trim() != "") l_PageMargins.bottomMargin = Convert.ToInt32(li_unit * Convert.ToDecimal(asa_ArgMargins[2]));
			if (asa_ArgMargins.Length > 3 && asa_ArgMargins[3].Trim() != "") l_PageMargins.rightMargin = Convert.ToInt32(li_unit * Convert.ToDecimal(asa_ArgMargins[3]));
			this.ird_Report.PrintOptions.ApplyPageMargins(l_PageMargins);
		}
		catch
		{
		}
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定報表資料庫連接資訊(含以下所有子報表)
	/// </summary>
	private void uf_SetDBLogon()
	{
		// 設定資料庫連接資訊
		ConnectionInfo l_ConnInfo = new ConnectionInfo();
		l_ConnInfo.ServerName = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SYSDB", "Data Source", "").Trim();
		l_ConnInfo.DatabaseName = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SYSDB", "Initial Catalog", "").Trim();
		l_ConnInfo.UserID = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SYSDB", "User ID", "").Trim();
		l_ConnInfo.Password = DbMethods.uf_ProfileString(DbMethods.is_INIPath, "SYSDB", "Password", "").Trim();

		// 設定主報表所有表格的資料庫連接資訊
		this.uf_SetDBLogonForReport(l_ConnInfo, this.ird_Report);

		// 設定子報表所有表格的資料庫連接資訊–依序處理每個區域（好像不用設也可以顯示）
		//foreach (Section l_Section in this.ird_Report.ReportDefinition.Sections)
		//{
		//    // 依序處理每個子報表
		//    foreach (ReportObject l_ReportObject in l_Section.ReportObjects)
		//    {
		//        if (l_ReportObject.Kind == ReportObjectKind.SubreportObject)
		//        {
		//            SubreportObject l_SubreportObject = (SubreportObject)l_ReportObject;
		//            ReportDocument l_SubReportDocument = l_SubreportObject.OpenSubreport(l_SubreportObject.SubreportName);
		//            this.uf_SetDBLogonForReport(l_ConnInfo, l_SubReportDocument);
		//        }
		//    }
		//}
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：設定報表所有表格的資料庫連接資訊
	/// </summary>
	/// <param name="a_ConnInfo">資料庫連接資訊</param>
	/// <param name="ard_Report">要顯示的報表物件(主報表／子報表)</param>
	private void uf_SetDBLogonForReport(ConnectionInfo a_ConnInfo, ReportDocument ard_Report)
	{
		// 依序處理每個表格
		foreach (CrystalDecisions.CrystalReports.Engine.Table l_Table in ard_Report.Database.Tables)
		{
			TableLogOnInfo l_TableLogOnInfo = l_Table.LogOnInfo;
			l_TableLogOnInfo.ConnectionInfo = a_ConnInfo;
			l_Table.ApplyLogOnInfo(l_TableLogOnInfo);
		}
	}

	#endregion

	#region ☆ 匯出報表 Methods --------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：將報表匯出成 PDF 檔
	/// </summary>
	private void uf_ExportPDF()
	{
		// ##### 宣告變數 #####
		DiskFileDestinationOptions l_ExportFile = new DiskFileDestinationOptions();
		string ls_report;

		// 取得報表的名稱
		ls_report = this.ird_Report.FilePath.Substring(this.ird_Report.FilePath.LastIndexOf(@"\") + 1);
		ls_report = ls_report.Substring(0, ls_report.Length - 4);

		// ##### 宣告變數 #####
		string ls_key = "crReport_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
		string ls_root = this.Request.PhysicalApplicationPath;
		string ls_dir = "App_Data\\File";
		string ls_fileName = ls_report + ".pdf";
		string ls_file = ls_root + ls_dir + "\\" + ls_key + ".pdf";

		// 設定匯出檔案名稱(含路徑)
		l_ExportFile.DiskFileName = ls_file;

		// 設定報表匯出選項並匯出
		this.ird_Report.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
		this.ird_Report.ExportOptions.FormatOptions = null;
		this.ird_Report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
		this.ird_Report.ExportOptions.DestinationOptions = l_ExportFile;
		try
		{
			this.ird_Report.Export();
		}
		catch (Exception e)
		{
			this.uf_ShowMsg("-匯出檔案失敗，錯誤訊息：" + e.Message);
			return;
		}

		// 將檔案內容讀入 Application 中
		this.Application[ls_key] = System.IO.File.ReadAllBytes(ls_file);
		this.Application["name:" + ls_key] = ls_fileName;

		// 刪除檔案
		try { System.IO.File.Delete(ls_file); } catch { }

		// 將頁面引導到匯出檔案
		this.Response.Redirect(this.Request.ApplicationPath + "/proj_uctrl/h_download_file.ashx?key=" + ls_key + "&open=");
	}

	#endregion

	// =========================================================================
	/// <summary>
	/// 函式描述：顯示訊息
	/// </summary>
	/// <param name="as_Message">要顯示的訊息</param>
	private void uf_ShowMsg(string as_Message)
	{
		if (as_Message.StartsWith("-"))
		{
			lb_Msg.Text += as_Message.Substring(1);
			lb_Msg.ForeColor = System.Drawing.Color.Red;
		}
		else
			lb_Msg.Text += as_Message;
	}
}
