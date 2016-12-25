﻿// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表樣板管理–排班主檔–排班需求設定
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

public partial class sys_e_e01_p_e0105_03 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	/// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hme105b indb_hme105b = new ndb_hme105b();
    protected ndb_hme105b indb_hme105b_g = new ndb_hme105b();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
        //this.uf_InitializeQuery(null, u_Show.indb_hme105a_hme105b, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hme105b, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        this.dgG_Retrieve = "no";
        this.IsQuery_UseSession = false;
		this.IsQuery_SessionRemove = false;
        u_Time1.MinPeriod = 5;
        u_Time2.MinPeriod = 5;
        u_Show.i_CalendarSelectionMode = CalendarSelectionMode.None;
        u_Show.ShowMode = sys_e_u_e_month_view.ShowModes.Week;

        u_Time1.mmAutoPostBack = true;
        u_Time1.hhAutoPostBack = true;
        u_Time2.mmAutoPostBack = true;
        u_Time2.hhAutoPostBack = true;
        u_Time1.ue_TimeChanged += new EventHandler(u_Time_ue_TimeChanged);
        u_Time2.ue_TimeChanged += new EventHandler(u_Time_ue_TimeChanged);


		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
            if (this.Request["args"] != null) //0:hme105a_ssid 1:hme105a_name 2:hme105a_tid 
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];
                ViewState["name"] = lsa_Arguments[1];
                ViewState["tid"] = lsa_Arguments[2];
            }

			// 將頁面切換到此頁
            this.uf_AddJavaScript("uf_SelectFrame(3);uf_SelectFrame(2);");
		}

        this.uf_MyCalendar_ShowWeek();

        // 增加欄位
        this.indb_hme105b.dv_View.Table.Columns.Add("hme105b_edate", System.Type.GetType("System.DateTime"));

        this.indb_hme105b.dv_View.Table.Columns["hme105b_ssid"].DefaultValue = (this.StoredKey != "" ? this.StoredKey : "");

        // 註冊執行事件
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        u_Show.ue_EventEditChanged += new sys_e_u_e_month_view.BtChangedHandler(this.MyCalendar_EventEditChanged);

	}

    protected void u_Time_ue_TimeChanged(object sender, EventArgs e)
    {
        dwF_hme105b_hour.Text = e01Project.uf_GetHourPeriod(Convert.ToDateTime(u_Time1.Value), Convert.ToDateTime(u_Time2.Value)).ToString();
    }

    // =========================================================================
    // 事件
    // =========================================================================
    /// <summary>
    /// 事件描述：按下 編輯 所做的處理
    /// </summary>
    private void MyCalendar_EventEditChanged(string as_sdid)
    {
        if (as_sdid == null) return;

        string[] lsa_args = as_sdid.Trim().Split('|');

        if (lsa_args.Length < 2) return;

        // ##### 宣告變數 #####
        int li_index = -1;
        string ls_pdid = lsa_args[1].Trim();

        // 將主鍵值記錄為尋找資料的條件
        this.dgG_FindValue = new object[1];
        this.dgG_FindValue[0] = ls_pdid;

        // 顯示出此需求班次的基本資料
        li_index = this.indb_hme105b.uf_FindSortIndex(ls_pdid);

        // 判斷是否找到符合的資料，沒有則離開
        if (li_index == -1) return;

        // 取出需求班次的基本資料
        if (!this.uf_DwF_GetData(this.dwF, this.indb_hme105b[li_index]))
        {
            this.uf_Msg("取出資料有誤！");
        }
        else
        {
            this.u_Edit_F.uf_Display("IDUC");
        }

    }	// End of MyCalendar_EventEditChanged

    // =========================================================================
    // 函式
    // =========================================================================
    /// <summary>
    /// 函式描述：顯示班表月份的月曆控制項資料
    /// </summary>
    protected void uf_MyCalendar_ShowWeek()
    {
        if (ViewState["name"] != null && ViewState["tid"] != null)
        {
            this.dgG_Retrieve = " AND hme105b_ssid = '" + this.StoredKey + "' ";

            dwF_YM_t.Text = uf_Dg_Bind("hmd101", ViewState["tid"]) + "  － " + ViewState["name"].ToString();
            u_Show.Year = "2009";
            u_Show.Month = "02";
            u_Show.SName = dwF_YM_t.Text;
            u_Show.Tid = this.StoredKey;

            // 需求班次查詢
            string ls_AddSQL = "";
            ls_AddSQL += " AND hme105b_ssid = '" + this.StoredKey + "' ";
            u_Show.indb_hme105a_hme105b.uf_Retrieve(ls_AddSQL);

            // 產生出月曆
            u_Show.uf_BuildWeek();
            u_Edit_F.uf_Enabled(true);

            this.indb_hme105b_g.uf_Retrieve(dgG_Retrieve + " AND hme105b_type = '2' ");
        }
        else
        {
            dwF_YM_t.Text = "請先點選欲新增之排班樣版主檔！";
            dwF_YM_t.ForeColor = System.Drawing.Color.Red;
            u_Edit_F.uf_Enabled(false);
        }
    }	// End of uf_MyCalendar_ShowWeek

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
            adrv_Row["hme105b_sdid"] = e01Project.uf_Get_SystemNo("hme105b.hme105b_sdid", "");
            //adrv_Row["hme105b_cdt"] = DbMethods.uf_GetDateTime();  //建檔時間
        }

        // 設定異動人員及異動時間
        adrv_Row["hme105b_uid"] = ""; // 需修正為session
        adrv_Row["hme105b_udt"] = DbMethods.uf_GetDateTime();

		return true;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改、刪除）
	/// </summary>
	private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
        //if (adrv_Row == null) return true;

        this.uf_MyCalendar_ShowWeek();

        // 重新取出查詢及清單資料
        this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');  uf_LinkFrame('p_e0105_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
        //this.uf_AddJavaScript("parent.frames[2].__doPostBack('','');");

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
            if (acto_Child == dwF_hme105b_addtext)
            {
                bool lb_in = false;
                foreach (ListItem lli_Item in dwF_hme105b_addtext.Items)
                {
                    if ( lli_Item.Text.Trim() == as_Value)
                    {
                        dwF_hme105b_addtext.SelectedIndex = dwF_hme105b_addtext.Items.IndexOf(lli_Item);
                        lb_in = true;
                        dwF_addtext.Visible = false;
                        break;
                    }
                }
                if( lb_in == false )
                {
                    dwF_hme105b_addtext.SelectedIndex = 0;
                    dwF_addtext.Text = as_Value;
                    dwF_addtext.Visible = true;
                }

                return true;
            }
            // 是否提供午餐
            if (acto_Child == dwF_hme105b_fooda)
            {
                dwF_hme105b_fooda.Checked = this.uf_Dg_BindBool("Y", as_Value);
                return true;
            }
            // 是否提供晚餐
            if (acto_Child == dwF_hme105b_foodb)
            {
                dwF_hme105b_foodb.Checked = this.uf_Dg_BindBool("Y", as_Value);
                return true;
            }
            // 選擇禮拜幾或特定日期
            //if (acto_Child == dwF_hme105b_type)
            //{
            //    if (dwF_hme105b_type.SelectedIndex == 0)
            //        dwF_hme105b_type.SelectedIndex = 0;
            //    else
            //        dwF_hme105b_type.SelectedIndex = 1;
            //    return true;
            //}
            if (acto_Child == dwF_hme105b_weekday && a_Action == DwActions.Get)
            {
                if (as_Value != "")
                {
                    dwF_hme105b_type.SelectedIndex = 0;
                    dwF_hme105b_weekday.Enabled = true;
                }
                else
                {
                    dwF_hme105b_type.SelectedIndex = 1;
                    dwF_hme105b_weekday.Enabled = false;
                }
                return true;
            }

            if (acto_Child == dwF_hme105b_sdate && a_Action == DwActions.Get)
            {
                if (a_Action == DwActions.Get)
                {
                    if (as_Value != "")
                        dwF_hme105b_sdate.Enabled = true;
                    else
                        dwF_hme105b_sdate.Enabled = false;
                    return true;
                }
            }

        }
        else if (a_Action == DwActions.Set)
        {
            // 開始時間、結束時間
            if (acto_Child == dwF_hme105b_starttime || acto_Child == dwF_hme105b_endtime)
            {
                if (Convert.ToInt16(Convert.ToDateTime(u_Time1.Value).ToString("HHmm")) >= Convert.ToInt16(Convert.ToDateTime(u_Time2.Value).ToString("HHmm")))
                {
                    this.uf_Msg("「結束時間」必須大於「結束時間」！");
                    return false;
                }

                as_Value = (as_Value.Substring(11, 8) == "00:00:00" ? "" : "2009/02/01" + " " + as_Value.Substring(11, 8));
                return true;
            }
            // 報到地點
            if (acto_Child == dwF_hme105b_addtext)
            {
                if (dwF_hme105b_addtext.SelectedItem.Text.Trim() == "其它")
                    as_Value = dwF_addtext.Text;
                else
                    as_Value = dwF_hme105b_addtext.SelectedItem.Text.Trim();
                return true;
            }
            // 是否提供午餐
            if (acto_Child == dwF_hme105b_fooda)
            {
                //if (dwF_hme105b_fooda.Checked)
                //{ 
                //    //判斷是否可提供午餐
                //    if (!(Convert.ToInt16(Convert.ToDateTime(u_Time1.Value).ToString("HH")) <= 12 && Convert.ToInt16(Convert.ToDateTime(u_Time2.Value).ToString("HH")) >= 12))
                //    {
                //        this.uf_Msg("「延續日期」必須大於等於「起始日期」！");
                //        return false;
                //    }
                //}

                as_Value = this.uf_Dg_BindBool("Y,N", dwF_hme105b_fooda.Checked);
                return true;
            }
            // 是否提供晚餐
            if (acto_Child == dwF_hme105b_foodb)
            {
                as_Value = this.uf_Dg_BindBool("Y,N", dwF_hme105b_foodb.Checked);
                return true;
            }
            // 選擇禮拜幾或特定日期
            if (acto_Child == dwF_hme105b_sdate)
            {
                if (dwF_hme105b_type.SelectedIndex == 0)
                {
                    as_Value = "";
                }
                else
                {
                    if (as_Value == "")
                    {
                        uf_Msg("請輸入特定日期！");
                        return false;
                    }
                }
                return true;
            }
            if (acto_Child == dwF_hme105b_weekday)
            {
                if (dwF_hme105b_type.SelectedIndex == 1)
                {
                    as_Value = "";
                }
                else
                {
                    if (as_Value == "")
                    {
                        uf_Msg("請輸入星期幾！");
                        return false;
                    }
                }
                return true;
            }
        }
        return true;
    }	// End of uf_Dw_DataAfter

	#endregion

    protected void dwF_hme105b_addtext_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dwF_hme105b_addtext.SelectedItem.Text.Trim() == "其它")
            dwF_addtext.Visible = true;
        else
            dwF_addtext.Visible = false;
    }

    protected void dwF_hme105b_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dwF_hme105b_type.SelectedIndex == 0)
        {
            dwF_hme105b_weekday.Enabled = true;
            dwF_hme105b_sdate.Enabled = false;
        }
        else if (dwF_hme105b_type.SelectedIndex == 1)
        {
            dwF_hme105b_weekday.Enabled = false;
            dwF_hme105b_sdate.Enabled = true;
        }
    }
}
