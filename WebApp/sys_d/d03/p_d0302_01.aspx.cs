// *********************************************************************************
// 1. 程式描述：志工資料匯出 - 服勤時數匯出
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

public partial class sys_d_d03_p_d0302_01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	/// <summary>變數描述：排班主檔資料元件</summary>
	protected ndb_hme101a indb_hme101a = new ndb_hme101a();
	/// <summary>變數描述：</summary>
	protected static string ls_key = "";

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_hme101a, bt_Query);
		this.uf_InitializeComponent(null, dgG, this.indb_hme101a, null);
		this.dgG_Sort = "hme101a_tid , hme101a_syear desc , hme101a_smonth desc ";

		if (!this.IsPostBack)
		{
			ViewState["tid"] = "";
			ViewState["checked_list"] = "";
		}

	}

	protected void bt_Export_Click(object sender, EventArgs e)
	{
		string ls_query = "";
		for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
		{
			if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

			if (ls_query != "")
				ls_query += ",'" + dgG.DataKeys[li_row].ToString().Trim() + "'";
			else
				ls_query = "'" + dgG.DataKeys[li_row].ToString().Trim() + "'";
		}

		ViewState["checked_list"] = ls_query;

		if (ls_query == "")
		{
			uf_Msg("請勾選要匯出的服勤時數資料！");
			return;
		}
		else
		{
			ls_query = "select hmd201_cname, hmd201_ssn, dbo.uf_yyyy_to_yyy_format(hme101b_sdate,'A6','A') as hme101b_sdate, dbo.uf_yyyy_to_yyy_format(hme101b_sdate,'A6','A') as hme101b_edate, hme101b_hca213id, '' as service_note, 0 as service_num, hme101c_onduty, 0 as traffic_fees, 0 as meal_fees , '' as service_ps  FROM hmd201, hme101a, hme101b, hme101c"
					+ " WHERE hmd201_vid = hme101c_vid" 
					+ " AND hme101c_pdid = hme101b_pdid"
					+ " AND hme101b_psid = hme101a_psid"
					+ " AND IsNull(hme101c_onduty,0) > 0"
			        + " AND hme101a_psid in (" + ls_query + ")";
			if (ViewState["tid"].ToString().Trim() != "")
				ls_query += " AND hmd201_tid = '" + ViewState["tid"].ToString() + "'";
		}

		WExcel myexcel = new WExcel();
		// ##### 宣告變數 #####
		ls_key = "ServiceHour_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff");
		string ls_root = this.Request.PhysicalApplicationPath;
		string ls_dir = "App_Data\\File";
		string ls_fileName = ls_key + ".xls";
		string ls_file = ls_root + ls_dir + "\\" + ls_fileName;
		string ls_msg = "";
		string ls_report = "ServiceHour.xls";
		DataSet lds_data;
		DataView ldv_data;


		DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_query);

		ldv_data = lds_data.Tables[0].DefaultView;

		if (ldv_data.Count <= 0)
		{
			uf_Msg("無資料可匯出！");
			return;
		}

		ls_msg = myexcel.uf_Open(Server.MapPath(Request.ApplicationPath) + @"\App_Data\Report\" + ls_report + "", WExcel.FileMode.OpenOrCreate, ls_file, "服務時數記錄", 11, 0, 0, null, 1, 1, 1);

		string[] lsa_value = new string[11];

		for (int i = 0; i < ldv_data.Count; i++)
		{
			for (int li_array = 0; li_array < 11; li_array++)
			{
				lsa_value[li_array] = ldv_data[i][li_array].ToString().Trim();
			}
			myexcel.uf_InsertRow(lsa_value);
		}

		//------------------------------------------
		ls_msg = myexcel.uf_Save();

		// 將檔案內容讀入 Application 中
		this.Application[ls_key] = File.ReadAllBytes(ls_file);
		this.Application["name:" + ls_key] = ls_fileName;

		//刪除檔案
		try { File.Delete(ls_file); }
		catch (IOException ee)
		{
			uf_Msg(ee.Message);
			return;
		}
		// 下載檔案
		this.uf_AddJavaScript("window.open(\"" + this.Request.ApplicationPath + "/proj_uctrl/h_download_file.ashx?key=" + ls_key + "\");");

	}

	protected bool uf_Check_List(object ao_psid)
	{
		if (ViewState["checked_list"].ToString().Contains("'" + ao_psid.ToString().Trim() + "'"))
			return true;
		else
			return false;
	}
	// =========================================================================
	/// <summary>
	/// 函式描述：資料控制項容器控制項組合出查詢語法之後針對特殊或不能處理的子控制項再修改組合出的查詢語法（一個控制項處理一次）（覆蓋上層）
	/// </summary>
	/// <param name="acto_Child">資料控制項容器上的子控制項</param>
	/// <param name="as_ColType">子控制項對應欄位的型態種類–清空時(空字串)；字串等於(S)；字串相似(SL)；日期時間(DT)；日期(D)；時間(T)；數值(N)</param>
	/// <param name="as_Value">子控制項對應欄位的值(已去空白)–傳入的值已處理不安全內容，如有變更需自行確認其安全性</param>
	/// <param name="a_Action">處理種類–清空(New)；查詢(Set)</param>
	/// <param name="as_AddSQL">清空(New)為空字串；查詢(Set)則傳入之前組合出的查詢語法(尚未加入此控制項語法)</param>
	/// <param name="ab_IsAdd">是否加入此控制項語法或參數–是(true)；否(false)</param>
	/// <param name="a_Kind">資料查詢種類–語法(AddSQL)；參數(AddArg)</param>
	/// <returns>成功(true)；失敗(false)</returns>
	protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
	{
		if (a_Action == DwActions.Set)
		{
			if (acto_Child == dwQ_hme101_tid)
			{

				ViewState["tid"] = this.dwQ_hme101_tid.SelectedValue.Trim();
				if (ViewState["tid"].ToString() != "")
					as_AddSQL += " AND hme101a_psid in (SELECT DISTINCT hme101b_psid FROM hme101b, hme101c, hmd201 WHERE hme101c_vid = hmd201_vid AND hmd201_tid = '" + ViewState["tid"].ToString() + "' AND hme101b_pdid = hme101c_pdid AND IsNull(hme101c_onduty,0) > 0)";
				else
					as_AddSQL += " AND hme101a_psid in (SELECT DISTINCT hme101b_psid FROM hme101b, hme101c WHERE hme101b_pdid = hme101c_pdid AND IsNull(hme101c_onduty,0) > 0)";
				ab_IsAdd = false;
				return true;
			}

		}
		return true;
	}
}