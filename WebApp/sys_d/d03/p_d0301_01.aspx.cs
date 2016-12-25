// *********************************************************************************
// 1. 程式描述：志工資料匯出 - 志工基本資料匯出
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

public partial class sys_d_d03_p_d0301_01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	/// <summary>變數描述：志工基本資料元件</summary>
	protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
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
		this.uf_InitializeQuery(dwQ, this.indb_hmd201, bt_Query);
		this.uf_InitializeComponent(null, dgG, this.indb_hmd201, null);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

		if (!this.IsPostBack)
		{
			ViewState["checked_list"] = "";
		}

	}

	protected void bt_Export_Click(object sender, EventArgs e)
	{
		string ls_query = "";
		string ls_query1 = "";
		for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
		{
			ls_query1 += "'" + dgG.DataKeys[li_row].ToString().Trim() + "',"; 
			if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

			if (ls_query != ""){
				ls_query += ",'" + dgG.DataKeys[li_row].ToString().Trim() + "'";
			}else{
				ls_query = "'" + dgG.DataKeys[li_row].ToString().Trim() + "'";
			}

				
		}
		if(ls_query1 !=""){
		ls_query1 = ls_query1.Substring(0, ls_query1.Length-1);
		}
		ViewState["checked_list"] = ls_query;

		if (ls_query == "")
		{
            		ls_query = ls_query1;
            		ViewState["checked_list"] = ls_query;
 			//當都沒勾時，當全部匯出，20140219
            		ls_query = "SELECT hmd201_cname, hmd201_ssn, (CASE WHEN hmd201_ssntype = '1' THEN '0' ELSE '1' END) as hmd201_ssntype, '0' as aborigine, hmd201_vid as volteer_type, '' as volteer_pwd, (CASE WHEN hmd201_gent = 'M' THEN '1' WHEN hmd201_gent = 'F' THEN '0' ELSE '' END) as hmd201_sex, dbo.uf_yyyy_to_yyy_format(hmd201_bday,'A6','A') as hmd201_birthday, hmd201_jobid, hmd201_eduid, hmd201_email,'' as volteer_serial, hmd201_jobtitle, (SELECT  dbo.uf_yyyy_to_yyy_format(MIN(hld201_logdate),'A6','A') FROM hld201 WHERE hld201_vid = hmd201_vid AND hld201_logtype = '1') as hmd201_logdate, hmd201_addid, hmd201_addid as hmd201_countyid, hmd201_addot, hmd201_phnow, hmd201_phnoa, hmd201_phnom, hmd201_introtext, '' as hmd201_expert1, '' as hmd201_expert2, '' as hmd201_expert3 , '0240' as hmd201_service1, '' as hmd201_service2, '' as hmd201_service3, '' as service_sdate, '' as service_edate, hmd201_workday"
                    	+ " FROM hmd201"
			+ " WHERE hmd201_vid in (" + ls_query + ")";
			//uf_Msg("請勾選要匯出的志工人員資料！");
			//return;
		}
		else
		{
			ls_query = "SELECT hmd201_cname, hmd201_ssn, (CASE WHEN hmd201_ssntype = '1' THEN '0' ELSE '1' END) as hmd201_ssntype, '0' as aborigine, hmd201_vid as volteer_type, '' as volteer_pwd, (CASE WHEN hmd201_gent = 'M' THEN '1' WHEN hmd201_gent = 'F' THEN '0' ELSE '' END) as hmd201_sex, dbo.uf_yyyy_to_yyy_format(hmd201_bday,'A6','A') as hmd201_birthday, hmd201_jobid, hmd201_eduid, hmd201_email,'' as volteer_serial, hmd201_jobtitle, (SELECT  dbo.uf_yyyy_to_yyy_format(MIN(hld201_logdate),'A6','A') FROM hld201 WHERE hld201_vid = hmd201_vid AND hld201_logtype = '1') as hmd201_logdate, hmd201_addid, hmd201_addid as hmd201_countyid, hmd201_addot, hmd201_phnow, hmd201_phnoa, hmd201_phnom, hmd201_introtext, '' as hmd201_expert1, '' as hmd201_expert2, '' as hmd201_expert3 , '0240' as hmd201_service1, '' as hmd201_service2, '' as hmd201_service3, '' as service_sdate, '' as service_edate, hmd201_workday"
                    + " FROM hmd201"
					+ " WHERE hmd201_vid in (" + ls_query + ")";
		}

		WExcel myexcel = new WExcel();
		// ##### 宣告變數 #####
		ls_key = "volteer_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff");
		string ls_root = this.Request.PhysicalApplicationPath;
		string ls_dir = "App_Data\\File";
		string ls_fileName = ls_key + ".xls";
		string ls_file = ls_root + ls_dir + "\\" + ls_fileName;
		string ls_msg = "";
		string ls_report = "volteer.xls";
		DataSet lds_data;
		DataView ldv_data;


		DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_query);

		ldv_data = lds_data.Tables[0].DefaultView;

		if (ldv_data.Count <= 0)
		{
			uf_Msg("無資料可匯出！");
			return;
		}

		ls_msg = myexcel.uf_Open(Server.MapPath(Request.ApplicationPath) + @"\App_Data\Report\" + ls_report + "", WExcel.FileMode.OpenOrCreate, ls_file, "志工基本資料記錄", 30, 0, 0, null, 1, 1, 1);

		string[] lsa_value = new string[30];

		for (int i = 0; i < ldv_data.Count; i++)
		{
			
			lsa_value[0] = ldv_data[i][0].ToString().Trim();
			lsa_value[1] = ldv_data[i][1].ToString().Trim();
			lsa_value[2] = ldv_data[i][2].ToString().Trim();
			lsa_value[3] = ldv_data[i][3].ToString().Trim();
			lsa_value[4] = d03Project.uf_Get_Volteer("A", ldv_data[i][4].ToString().Trim());
			lsa_value[5] = ldv_data[i][5].ToString().Trim();
			lsa_value[6] = ldv_data[i][6].ToString().Trim();
			lsa_value[7] = ldv_data[i][7].ToString().Trim();
			lsa_value[8] = ldv_data[i][8].ToString().Trim();
			lsa_value[9] = ldv_data[i][9].ToString().Trim();
			lsa_value[10] = ldv_data[i][10].ToString().Trim();
			lsa_value[11] = ldv_data[i][11].ToString().Trim();
			lsa_value[12] = ldv_data[i][12].ToString().Trim();
			lsa_value[13] = ldv_data[i][13].ToString().Trim();
			lsa_value[14] = ldv_data[i][14].ToString().Trim();
			lsa_value[15] = d03Project.uf_Get_Volteer("B", ldv_data[i][15].ToString().Trim());
			lsa_value[16] = ldv_data[i][16].ToString().Trim();
			lsa_value[17] = ldv_data[i][17].ToString().Trim();
			lsa_value[18] = ldv_data[i][18].ToString().Trim();
			lsa_value[19] = ldv_data[i][19].ToString().Trim();
			lsa_value[20] = ldv_data[i][20].ToString().Trim();
			lsa_value[21] = ldv_data[i][21].ToString().Trim();
			lsa_value[22] = ldv_data[i][22].ToString().Trim();
			lsa_value[23] = ldv_data[i][23].ToString().Trim();
			lsa_value[24] = ldv_data[i][24].ToString().Trim();
			lsa_value[25] = ldv_data[i][25].ToString().Trim();
			lsa_value[26] = ldv_data[i][26].ToString().Trim();
			lsa_value[27] = ldv_data[i][27].ToString().Trim();
			lsa_value[28] = ldv_data[i][28].ToString().Trim();
			lsa_value[29] = d03Project.uf_Get_Volteer("C", ldv_data[i][29].ToString().Trim());

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

	protected bool uf_Check_List(object ao_vid)
	{
		if (ViewState["checked_list"].ToString().Contains("'" + ao_vid.ToString().Trim() + "'"))
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
			if (acto_Child == dwQ_hmd201_bday_s)
			{
				if (u_Date0.Value != "")
				{
					as_AddSQL += " AND hmd201_bday >= '" + u_Date0.Value + "' ";
				}
				return true;
			}
			if (acto_Child == dwQ_hmd201_bday_e)
			{
				if (u_Date1.Value != "")
				{
					as_AddSQL += " AND hmd201_bday < DateAdd(dd , 1 , CAST ('" + u_Date1.Value + "' as datetime)) ";
				}
				return true;
			}

		}
		return true;
	}
}