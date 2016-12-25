// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排轉正式班表–編輯名單
// 2. 撰寫人員：demon
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

public partial class sys_e_e01_p_e0104_03 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hme101b indb_hme101b = new ndb_hme101b();

    /// <summary>變數描述：排班表主檔元件</summary>
    protected ndb_hme101a indb_hme101a = new ndb_hme101a();

    /// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hme101b indb_hme101b_tmp = new ndb_hme101b();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.uf_InitializeQuery(null, this.indb_hme101b, null);
        this.uf_InitializeComponent(dwF, null, this.indb_hme101b, u_Edit_F);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        this.IsQuery_UseSession = false;

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];
                ViewState["psid"] = lsa_Arguments[1];
                ViewState["Year"] = lsa_Arguments[2];
                ViewState["Month"] = lsa_Arguments[3];
                ViewState["tid"] = lsa_Arguments[4];

                this.dgG_Retrieve = " AND hme101b_psid = '" + ViewState["psid"].ToString() + "' ";
                indb_hme101b.uf_Retrieve(dgG_Retrieve);

                dwF_YM_t.Text = "★ " + uf_Dg_Bind("hmd101", ViewState["tid"]) + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月排班班表";

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(3);");
            }
            else
            {
                dwF_YM_t.Text = "請先點選欲修改之班表需求！";
                dwF_YM_t.ForeColor = System.Drawing.Color.Red;
                u_Edit_F.uf_Enabled(false);
            }
            Dbcfg.uf_Bind(dwF_SHour, "hh", "", true);
            Dbcfg.uf_Bind(dwF_EHour, "hh", "", true);
            uf_BindMin(dwF_SMin);
            uf_BindMin(dwF_EMin);

        }

        // 增加欄位
        this.indb_hme101b.dv_View.Table.Columns.Add("hme101b_edate", System.Type.GetType("System.DateTime"));

        this.indb_hme101b.dv_View.Table.Columns["hme101b_psid"].DefaultValue = (ViewState["psid"] != null ? ViewState["psid"].ToString() : "");

        // 註冊執行事件
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataInsert_PreSave += new DataHandler(this.u_Edit_F_PreSave);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataDelete_PreDelete += new DataHandler(this.u_Edit_F_PreDelete);

        this.u_Edit_F.ibt_Insert.Attributes["OnClick"] = "if (! confirm('是否確定要新增? ')) return false;";
        this.u_Edit_F.ibt_Delete.Attributes["OnClick"] = "if (! confirm('是否確定要刪除? ')) return false;";


        // 將主鍵值記錄為尋找資料的條件
        this.dgG_FindValue = new object[1];
        this.dgG_FindValue[0] = this.StoredKey;
        uf_dwFShow();

    }

    protected void u_Time_ue_TimeChanged(object sender, EventArgs e)
    {
        dwF_hme101b_hour.Text = e01Project.uf_GetHourPeriod(Convert.ToDateTime(DbMethods.uf_GetDate().ToString("yyyy/MM/dd") +" " + dwF_SHour.SelectedValue + ":" + dwF_SMin.SelectedValue), Convert.ToDateTime(DbMethods.uf_GetDate().ToString("yyyy/MM/dd") +" " + dwF_EHour.SelectedValue + ":" + dwF_EMin.SelectedValue)).ToString();
    }

    protected void uf_BindMin( DropDownList addl_Min )
    {
        for (int li_i = 0; li_i <= 59; li_i++)
        {
            if (Math.IEEERemainder(li_i, 5) == 0)
                addl_Min.Items.Add(new ListItem(li_i.ToString("00"), li_i.ToString()));
        }
    }

    protected void uf_dwFShow()
    {
        if (this.StoredKey == "") return;

        
    }

    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
    /// </summary>
    private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        if (adrv_Row == null) return true;

        // 如果資料為新增的
        if (adrv_Row.IsNew)
        {
            // 取得流水號的系統編號–資料庫最大值+1
            adrv_Row["hme101b_pdid"] = e01Project.uf_Get_SystemNo("hme101b.hme101b_pdid", "SR" + ViewState["Year"].ToString());
            //adrv_Row["hme101b_cdt"] = DbMethods.uf_GetDateTime();  //建檔時間
        }

        return true;
    }

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（刪除）
	/// </summary>
	private bool u_Edit_F_PreDelete(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;

		// add by rong 2010/11/11
		int li_count = 0;
		DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101c WHERE hme101c_pdid = '" + adrv_Row["hme101b_pdid"].ToString().Trim() + "'", ref li_count);
		if (li_count > 0)
		{
			uf_Msg("已有排班的人員資料，請先移除人員資料再刪除！");
			return false;
		}

		return true;
	}

    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改、刪除）
    /// </summary>
    private bool u_Edit_F_PreSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        if (adrv_Row == null) return true;

        // ##### 宣告變數 #####
        DateTime ldt_sdate, ldt_edate, ldt_month_end;
        TimeSpan lts_day;
        string ls_pdid = "", ls_pdid_i = "";
        int li_seq = 0;
        DataRowView ldrv_New;

        ldt_sdate = Convert.ToDateTime(adrv_Row["hme101b_sdate"]);
        ldt_edate = Convert.ToDateTime(adrv_Row["hme101b_edate"]);
        ls_pdid = adrv_Row["hme101b_pdid"].ToString();
        li_seq = Convert.ToInt16(ls_pdid.Substring(5));

        lts_day = ldt_edate.Subtract(ldt_sdate);
        ldt_month_end = Convert.ToDateTime(ldt_sdate.ToString("yyyy/MM/") + "01").AddMonths(1).AddDays(-1);

        // 依據處理日期區間
        for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
        {
            // 日期不等於開始日期時新增一筆「日期」不同的資料
            if (ldt_day != ldt_sdate)
            {
                // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                li_seq++;
                ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_day);
                if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                    ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_day.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                    ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_day.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                ldrv_New.EndEdit();
            }
        }

        // 若每週重複
        if (dwF_repeat.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(7)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(7); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_day.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_day.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        return true;
    }

    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改、刪除）
    /// </summary>
    private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        // 重新取出查詢及清單資料
        //this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');  uf_LinkFrame('p_e0101_02.aspx', '02Frame', '" + ViewState["psid"].ToString() + "|" + ViewState["Year"].ToString() + "|" + ViewState["Month"].ToString() + "|" + ViewState["Tid"].ToString() + "'); ");
        this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');parent.frames[2].__doPostBack('','');uf_SelectFrame(2);");

        return true;
    }

    #region ☆ Override Methods --------------------------------------- 撰寫人員：demon

    // =========================================================================
    // 函式（覆蓋上層）
    // =========================================================================
    /// <summary>
    /// 函式描述：資料控制項容器做相關處理之後針對特殊或不能處理的子控制項做相關處理
    /// </summary>
    /// <param name="acto_Child">資料控制項容器上的子控制項</param>
    /// <param name="as_Value">子控制項對應欄位的值(如為取出則沒去空白)</param>
    /// <param name="a_Action">處理種類–新增(New)；取出(Get)；放入(Set)；繫結(Bind)</param>
    /// <param name="adrv_Row">當筆資料列</param>
    /// <returns>成功(true)；失敗(false)</returns>
    protected override bool uf_DwF_DataAfter(Control acto_Child, ref string as_Value, DwActions a_Action, DataRowView adrv_Row)
    {
        if (a_Action == DwActions.New || a_Action == DwActions.Get)
        {
            // 報到地點
            if (acto_Child == dwF_hme101b_addtext)
            {
                bool lb_in = false;
                foreach (ListItem lli_Item in dwF_hme101b_addtext.Items)
                {
                    if (lli_Item.Text.Trim() == as_Value)
                    {
                        dwF_hme101b_addtext.SelectedIndex = dwF_hme101b_addtext.Items.IndexOf(lli_Item);
                        lb_in = true;
                        dwF_addtext.Visible = false;
                        break;
                    }
                }
                if (lb_in == false)
                {
                    dwF_hme101b_addtext.SelectedIndex = 0;
                    dwF_addtext.Text = as_Value;
                    dwF_addtext.Visible = true;
                }

                return true;
            }
            // 是否提供午餐
            if (acto_Child == dwF_hme101b_fooda)
            {
                dwF_hme101b_fooda.Checked = this.uf_Dg_BindBool("Y", as_Value);
                return true;
            }
            // 是否提供晚餐
            if (acto_Child == dwF_hme101b_foodb)
            {
                dwF_hme101b_foodb.Checked = this.uf_Dg_BindBool("Y", as_Value);
                return true;
            }
            // 是否每週重複
            if (acto_Child == dwF_repeat)
            {
                dwF_repeat.Checked = false;
                return true;
            }

            if (acto_Child == dwF_SHour && a_Action == DwActions.Get)
            {
                ListItem lli_Item = dwF_SHour.Items.FindByText(Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH"));
                if (lli_Item != null)
                    dwF_SHour.SelectedIndex = dwF_SHour.Items.IndexOf(lli_Item);
                return true;
            }

            if (acto_Child == dwF_EHour && a_Action == DwActions.Get)
            {
                ListItem lli_Item = dwF_EHour.Items.FindByText(Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH"));
                if (lli_Item != null)
                    dwF_EHour.SelectedIndex = dwF_EHour.Items.IndexOf(lli_Item);
                return true;
            }

            if (acto_Child == dwF_SMin && a_Action == DwActions.Get)
            {
                ListItem lli_Item = dwF_SMin.Items.FindByValue(Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("mm"));
                if (lli_Item != null)
                    dwF_SMin.SelectedIndex = dwF_SMin.Items.IndexOf(lli_Item);
                return true;
            }

            if (acto_Child == dwF_EMin && a_Action == DwActions.Get)
            {
                ListItem lli_Item = dwF_EMin.Items.FindByValue(Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("mm"));
                if (lli_Item != null)
                    dwF_EMin.SelectedIndex = dwF_EMin.Items.IndexOf(lli_Item);
                return true;
            }

        }
        else if (a_Action == DwActions.Set)
        {
            // 日期
            if (acto_Child == dwF_hme101b_sdate)
            {
                as_Value = (as_Value.Length > 10 ? as_Value.Substring(0, 10) : as_Value);
                return true;
            }
            // 開始時間
            if (acto_Child == dwF_hme101b_starttime )
            {
                if (Convert.ToInt16(dwF_SHour.SelectedValue + dwF_SMin.SelectedValue) >= Convert.ToInt16(dwF_EHour.SelectedValue + dwF_EMin.SelectedValue))
                {
                    this.uf_Msg("「結束時間」必須大於「結束時間」！");
                    return false;
                }

                as_Value = (Convert.ToDateTime(adrv_Row["hme101b_sdate"]).ToString("yyyy/MM/dd") + " " + dwF_SHour.SelectedValue + ":" + dwF_SMin.SelectedValue);
                return true;
            }

            // 結束時間
            if (acto_Child == dwF_hme101b_endtime)
            {
                if (Convert.ToInt16(dwF_SHour.SelectedValue + dwF_SMin.SelectedValue) >= Convert.ToInt16(dwF_EHour.SelectedValue + dwF_EMin.SelectedValue))
                {
                    this.uf_Msg("「結束時間」必須大於「結束時間」！");
                    return false;
                }

                as_Value = (Convert.ToDateTime(adrv_Row["hme101b_sdate"]).ToString("yyyy/MM/dd") + " " + dwF_EHour.SelectedValue + ":" + dwF_EMin.SelectedValue);
                return true;
            }

            // 報到地點
            if (acto_Child == dwF_hme101b_addtext)
            {
                if (dwF_hme101b_addtext.SelectedItem.Text.Trim() == "其它")
                    as_Value = dwF_addtext.Text;
                else
                    as_Value = dwF_hme101b_addtext.SelectedItem.Text.Trim();
                return true;
            }
            // 延續到
            if (acto_Child == dwF_hme101b_edate)
            {
                as_Value = (as_Value.Length > 10 ? as_Value.Substring(0, 10) : as_Value);
                if (as_Value == "") as_Value = Convert.ToDateTime(adrv_Row["hme101b_sdate"]).ToString("yyyy/MM/dd");
                if (Convert.ToDateTime(as_Value) < Convert.ToDateTime(adrv_Row["hme101b_sdate"]))
                {
                    this.uf_Msg("「延續日期」必須大於等於「起始日期」！");
                    return false;
                }
                return true;
            }
            // 是否提供午餐
            if (acto_Child == dwF_hme101b_fooda)
            {
                //if (dwF_hme101b_fooda.Checked)
                //{ 
                //    //判斷是否可提供午餐
                //    if (!(Convert.ToInt16(Convert.ToDateTime(u_Time1.Value).ToString("HH")) <= 12 && Convert.ToInt16(Convert.ToDateTime(u_Time2.Value).ToString("HH")) >= 12))
                //    {
                //        this.uf_Msg("「延續日期」必須大於等於「起始日期」！");
                //        return false;
                //    }
                //}

                as_Value = this.uf_Dg_BindBool("Y,N", dwF_hme101b_fooda.Checked);
                return true;
            }
            // 是否提供晚餐
            if (acto_Child == dwF_hme101b_foodb)
            {
                as_Value = this.uf_Dg_BindBool("Y,N", dwF_hme101b_foodb.Checked);
                return true;
            }

        }
        return true;
    }	// End of uf_Dw_DataAfter

    #endregion

    protected void dwF_hme101b_addtext_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dwF_hme101b_addtext.SelectedItem.Text.Trim() == "其它")
            dwF_addtext.Visible = true;
        else
            dwF_addtext.Visible = false;
    }
}
