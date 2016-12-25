
// *********************************************************************************
// 1. 程式描述：系統公告管理–系統公告
// 2. 撰寫人員：
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

public partial class sys_d_d02_p_d0201_04 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

	/// <summary>變數描述：公告管理資料元件</summary>
    //protected ndb_aec02 indb_aec02 = new ndb_aec02();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        this.IsQuery_SessionRemove = false;
		dwQ_Year.Attributes["onBlur"] = "uf_GetNumeric(" + dwQ_Year.ClientID + ");";
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
            {
                this.StoredKey = this.Request["args"].Trim();
            }
			dwQ_Year.Text = Convert.ToString(DateTime.Now.Year - 1911).PadLeft(3, '0');
            uf_query();

            // 將頁面切換到此頁
            //this.uf_AddJavaScript("uf_SelectFrame(2);");

        }		
      
	}

    protected void uf_query()
    {

        string ax = "";
        DbMethods.uf_ExecSQL(" SELECT hmd201_cname FROM hmd201  WHERE hmd201_vid = '" + this.StoredKey + "' ", ref ax);
		dwF_hmd201_vid.Text = ax + "(" + this.StoredKey + ")";

		DataSet lds_data;
		DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hca215.hca215_cname,Isnull(Round(SUM(hmf10123.onduty),1),0) as Total FROM hca215 left join hmf10123 on hca215_id = CType and vid ='" + this.StoredKey + "' AND Onduty is not null group by hca215_cname order by hca215_cname");
		Literal1.Text = "<font color=\"Purple\">◎累積教育訓練總時數：</font><font color=\"SlateGray\"> " + lds_data.Tables[0].Compute("Sum(Total)", "").ToString() + "小時 ";
		for (int i = 0; i < lds_data.Tables[0].Rows.Count; i++)
		{
			Literal1.Text += "(" + lds_data.Tables[0].Rows[i]["hca215_cname"].ToString() + "：" + lds_data.Tables[0].Rows[i]["Total"].ToString() + "小時)";
		}
		Literal1.Text += "</font><P><font color=\"Purple\">◎此年度教育訓練狀況：</font><font color=\"SlateGray\">";

		string ct2 = "";
		DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "'AND NOT(Onduty is null) AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref ct2);

		if (ct2 == "")
		{
			ct2 = "0_0_0";
		}

		string[] ctX = ct2.Split('_');

		Literal1.Text += "應到 " + ctX[2] + " 小時,  實到 " + ctX[0] + " 小時<p>";

		string percentage = "";
		if (ctX[2] == "0")
		{
			percentage = "0";
		}
		else
		{
			percentage = Convert.ToString(Math.Round((Double.Parse(ctX[0], System.Globalization.NumberStyles.Float) * 100) / Double.Parse(ctX[2], System.Globalization.NumberStyles.Float), 1));
		}

		Literal1.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;缺席 " + ctX[1] + "小時, 到課率為 " + percentage + "%<p>";

		string ct3 = "";
		DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND Force = 'Y'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref ct3);

		if (ct3 == "")
		{
			ct3 = "0_0_0";
		}
		
		string[] ctX3 = ct3.Split('_');
		Literal1.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;強制參加： " + ctX3[2] + " 小時,  實到 " + ctX3[0] + " 小時<p>";

		string cx4 = "";
		DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND Force = 'N'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref cx4);

		if (cx4 == "")
		{
			cx4 = "0_0_0";
		}

		string[] ctx4 = cx4.Split('_');
		Literal1.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;報名參加： " + ctx4[2] + " 小時,  實到 " + ctx4[0] + " 小時<br><hr>";


		DataSet lds_data2;
		DbMethods.uf_Retrieve_FromSQL(out lds_data2, "SELECT hca215.hca215_cname,Isnull(Round(SUM(hmf10123.onduty),1),0) as Total, IsNull(Round(SUM(Total),1),0) as absent FROM hca215 left join hmf10123 on hca215_id = CType and vid ='" + this.StoredKey + "' AND Onduty is not null AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) group by hca215_cname order by hca215_cname");
		for (int i = 0; i < lds_data2.Tables[0].Rows.Count; i++)
		{
			Literal1.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + lds_data2.Tables[0].Rows[i]["hca215_cname"].ToString() + "： " + lds_data2.Tables[0].Rows[i]["absent"].ToString() + " 小時,  實到 " + lds_data2.Tables[0].Rows[i]["Total"].ToString() + "小時<p>";
		}

		string cx9 = "";
		DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hmf101_name FROM hmf101 Where hmf101_courseid IN (SELECT hmf102_courseid FROM hmf102 as A, hmf302 as B WHERE A.hmf102_trainid = B.hmf302_trainid AND hmf302_passed = 'Y'  AND hmf302_vid ='" + this.StoredKey + "')");
		int li_count = lds_data.Tables[0].Rows.Count;
		for (int i = 0; i < li_count; i++)
		{
			if (cx9 != "")
				cx9 += "、";
			cx9 += lds_data.Tables[0].Rows[i][0].ToString().Trim();
		}
		Literal1.Text += "</font><font color=\"Purple\">◎目前已通過訓練：</font><font color=\"SlateGray\">" + cx9 + "</font><p>";

		string cx10 = "";
		DbMethods.uf_Retrieve_FromSQL(out lds_data, " SELECT hmf101a_name FROM hmf101a Where hmf101a_certid IN (SELECT hmf401_certid FROM hmf401 WHERE hmf401_vid ='" + this.StoredKey + "')");
		li_count = lds_data.Tables[0].Rows.Count;
		for (int i = 0; i < li_count; i++)
		{
			if (cx10 != "")
				cx10 += "、";
			cx10 += lds_data.Tables[0].Rows[i][0].ToString().Trim();
		}
		Literal1.Text += "</font><font color=\"Purple\">◎目前已通過認證：</font><font color=\"SlateGray\">" + cx10 + "</font><br>";

		//string ctsum = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(hmf103_onduty),1) as varchar(10)) FROM hmf103 WHERE hmf103_vid ='" + this.StoredKey + "' ", ref ctsum);
		//if (ctsum == "")
		//    ctsum = "0";

		//string ctsum1 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '基礎教育訓練'  AND NOT(Onduty is null)  ", ref ctsum1);
		//if (ctsum1 == "")
		//    ctsum1 = "0";
		//string ctsum2 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '特殊訓練'  AND NOT(Onduty is null)  ", ref ctsum2);
		//if (ctsum2 == "")
		//    ctsum2 = "0";
		//string ctsum3 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '在職訓練'  AND NOT(Onduty is null)  ", ref ctsum3);
		//if (ctsum3 == "")
		//    ctsum3 = "0";
		//string ctsum4 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '成長訓練'  AND NOT(Onduty is null)  ", ref ctsum4);
		//if (ctsum4 == "")
		//    ctsum4 = "0";
		//dwF_hoursTotal.Text = ctsum + "小時 (基礎教育訓練： " + ctsum1 + " 小時) (特殊訓練： " + ctsum2 + " 小時) (在職訓練： " + ctsum3 + " 小時) (成長訓練： " + ctsum4 + " 小時)";

		//string ct2 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "'AND NOT(Onduty is null) AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref ct2);

		//if (ct2 == "")
		//{
		//    ct2 = "0_0_0";
		//}

		//string[] ctX = ct2.Split('_');

		//dwF_ThisYear1.Text = "應到 " + ctX[2] + " 小時,  實到 " + ctX[0] + " 小時";

		//string percentage = "";
		//if (ctX[2] == "0")
		//{
		//    percentage = "0";
		//}
		//else
		//{
		//    percentage = Convert.ToString(Math.Round((Double.Parse(ctX[0], System.Globalization.NumberStyles.Float) * 100) / Double.Parse(ctX[2], System.Globalization.NumberStyles.Float), 1));
		//}

		//dwF_ThisYear2.Text = "缺席 " + ctX[1] + "小時, 到課率為 " + percentage + "%";

		//string ct3 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND Force = 'Y'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref ct3);

		//if (ct3 == "")
		//{
		//    ct3 = "0_0_0";
		//}

		//string[] ctX3 = ct3.Split('_');
		//dwF_ThisYear3.Text = "強制參加： " + ctX3[2] + " 小時,  實到 " + ctX3[0] + " 小時";

		//string cx4 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND Force = 'N'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref cx4);

		//if (cx4 == "")
		//{
		//    cx4 = "0_0_0";
		//}

		//string[] ctx4 = cx4.Split('_');
		//dwF_ThisYear4.Text = "報名參加： " + ctx4[2] + " 小時,  實到 " + ctx4[0] + " 小時";

		//string cx5 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '基礎教育訓練'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref cx5);

		//if (cx5 == "")
		//{
		//    cx5 = "0_0_0";
		//}

		//string[] ctx5 = cx5.Split('_');
		//dwF_ThisYear5.Text = "基礎教育訓練： " + ctx5[2] + " 小時,  實到 " + ctx5[0] + " 小時";

		//string cx6 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '特殊教育訓練'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref cx6);

		//if (cx6 == "")
		//{
		//    cx6 = "0_0_0";
		//}

		//string[] ctx6 = cx6.Split('_');
		//dwF_ThisYear6.Text = "特殊訓練： " + ctx6[2] + " 小時,  實到 " + ctx6[0] + " 小時";

		//string cx7 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '在職訓練'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref cx7);

		//if (cx7 == "")
		//{
		//    cx7 = "0_0_0";
		//}

		//string[] ctx7 = cx7.Split('_');
		//dwF_ThisYear7.Text = "在職訓練： " + ctx7[2] + " 小時,  實到 " + ctx7[0] + " 小時";

		//string cx8 = "";
		//DbMethods.uf_ExecSQL(" SELECT CAST(Round(SUM(onduty),1) as varchar(10)) +'_' + CAST(Round(SUM(absent),1) as varchar(10)) +'_' + CAST(Round(SUM(Total),1) as varchar(10)) as Total FROM hmf10123 WHERE vid ='" + this.StoredKey + "' AND CType = '成長訓練'  AND NOT(Onduty is null)  AND year(Tdate) = (CAST('" + dwQ_Year.Text + "'  as int)+1911) ", ref cx8);

		//if (cx8 == "")
		//{
		//    cx8 = "0_0_0";
		//}

		//string[] ctx8 = cx8.Split('_');
		//dwF_ThisYear8.Text = "成長訓練： " + ctx8[2] + " 小時,  實到 " + ctx8[0] + " 小時";


		//string cx9 = "";
		//DataSet lds_data;
		//DbMethods.uf_Retrieve_FromSQL(out lds_data, "SELECT hmf101_name FROM hmf101 Where hmf101_courseid IN (SELECT hmf102_courseid FROM hmf102 as A, hmf302 as B WHERE A.hmf102_trainid = B.hmf302_trainid AND hmf302_passed = 'Y'  AND hmf302_vid ='" + this.StoredKey + "')");
		//int li_count = lds_data.Tables[0].Rows.Count;
		//for (int i=0;i < li_count; i++)
		//{
		//    if (cx9 != "")
		//        cx9 += "、";
		//    cx9 += lds_data.Tables[0].Rows[i][0].ToString().Trim();
		//}
		//dwF_AllCourse.Text = cx9;

		//string cx10 = "";
		//DbMethods.uf_Retrieve_FromSQL(out lds_data, " SELECT hmf101a_name FROM hmf101a Where hmf101a_certid IN (SELECT hmf401_certid FROM hmf401 WHERE hmf401_vid ='" + this.StoredKey + "')");
		//li_count = lds_data.Tables[0].Rows.Count;
		//for (int i=0;i < li_count; i++)
		//{
		//    if (cx10 != "")
		//        cx10 += "、";
		//    cx10 += lds_data.Tables[0].Rows[i][0].ToString().Trim();
		//}
		//dwF_AllCert.Text = cx10;
    }

    protected void bt_Query_Click(object sender, EventArgs e)
    {
        if (dwQ_Year.Text.Trim() == "")
        {
            uf_Msg("請輸入查詢年度！");
            return;
        }

        uf_query();
    }
}
