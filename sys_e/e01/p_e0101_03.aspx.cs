// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表設定–排班主檔–排班需求設定
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
using System.Data.SqlClient;

public partial class sys_e_e01_p_e0101_03 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hme101b indb_hme101b = new ndb_hme101b();

    /// <summary>變數描述：樣版需求資料元件</summary>
    protected ndb_hme105b indb_hme105b = new ndb_hme105b();

    /// <summary>變數描述：人員類別資料元件</summary>
    protected ndb_hme101b indb_hme101b_tmp = new ndb_hme101b();


    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
       
        // 初始化
        //this.uf_InitializeQuery(null, u_Show.indb_hme101a_hme101b, null);
        this.uf_InitializeComponent(dwF, null, this.indb_hme101b, u_Edit_F);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
        this.dgG_Retrieve = "no";
        this.IsQuery_UseSession = false;
        this.IsQuery_SessionRemove = false;
        u_Time1.MinPeriod = 5;
        u_Time2.MinPeriod = 5;
        u_Show.i_CalendarSelectionMode = CalendarSelectionMode.None;

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
            if (this.Request["args"] != null) //0:hme101a_psid 1:hme101a_syear 2:hme101a_smonth 3:hme101a_tid
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                if (lsa_Arguments.Length >= 4)
                {
                    this.StoredKey = lsa_Arguments[0];
                    ViewState["Year"] = lsa_Arguments[1];
                    ViewState["Month"] = lsa_Arguments[2];
                    ViewState["tid"] = lsa_Arguments[3];

                    Dbcfg.uf_Bind(dwS_hme105a_name, "hme105a", " hme105a_tid = '" + ViewState["tid"].ToString() + "' ", true);
                }
                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(3);uf_SelectFrame(2);");

            }

            // 在按鈕上增加確認視窗
            bt_t_insert.Attributes["OnClick"] = "if (! confirm('將新增樣版資料！是否確定要繼續？')) return false;";

            //sandra 20131024 新增一個刪除全部的按鈕
            bt_t_deleteall.Attributes["OnClick"] = "if (! confirm('將刪除全部樣版資料！是否確定要繼續？')) return false;";
        }

        this.uf_MyCalendar_ShowOtherMonth();

        // 增加欄位
        this.indb_hme101b.dv_View.Table.Columns.Add("hme101b_edate", System.Type.GetType("System.DateTime"));

        // 設定資料初始值
        if (u_Show.Year != "" && u_Show.Month != "")
            this.indb_hme101b.dv_View.Table.Columns["hme101b_sdate"].DefaultValue = Convert.ToDateTime(u_Show.YearE + "/" + u_Show.Month + "/01");
        else
            this.indb_hme101b.dv_View.Table.Columns["hme101b_sdate"].DefaultValue = DbMethods.uf_GetDate();

        this.indb_hme101b.dv_View.Table.Columns["hme101b_psid"].DefaultValue = (this.StoredKey != "" ? this.StoredKey : "");

        // 註冊執行事件
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataInsert_PreSave += new DataHandler(this.u_Edit_F_PreSave);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
        //u_Show.ue_VisibleMonthChanged += new MonthChangedEventHandler(this.MyCalendar_VisibleMonthChanged);
        //u_Show.ue_SelectionChanged += new sys_e_u_e_month_view.SelectionHandler(this.MyCalendar_SelectionChanged);
        u_Show.ue_EventEditChanged += new sys_e_u_e_month_view.BtChangedHandler(this.MyCalendar_EventEditChanged);

        this.u_Edit_F.ibt_Insert.Attributes["OnClick"] = "if (! confirm('是否確定要新增? ')) return false;";
        this.u_Edit_F.ibt_Delete.Attributes["OnClick"] = "if (! confirm('是否確定要刪除? ')) return false;";


        // 將主鍵值記錄為尋找資料的條件
        //this.dgG_FindValue = new object[1];
        //this.dgG_FindValue[0] = this.StoredKey;
    }

    protected void u_Time_ue_TimeChanged(object sender, EventArgs e)
    {
        dwF_hme101b_hour.Text = e01Project.uf_GetHourPeriod(Convert.ToDateTime(u_Time1.Value), Convert.ToDateTime(u_Time2.Value)).ToString();
    }

    // =========================================================================
    // 事件
    // =========================================================================
    /// <summary>
    /// 事件描述：按下 編輯 所做的處理
    /// </summary>
    private void MyCalendar_EventEditChanged(string as_pdid)
    {
        if (as_pdid == null) return;

        string[] lsa_args = as_pdid.Trim().Split('|');

        if (lsa_args.Length < 2) return;

        // ##### 宣告變數 #####
        int li_index = -1;
        string ls_pdid = lsa_args[1].Trim();

        // 將主鍵值記錄為尋找資料的條件
        this.dgG_FindValue = new object[1];
        this.dgG_FindValue[0] = ls_pdid;

        // 顯示出此需求班次的基本資料
        li_index = this.indb_hme101b.uf_FindSortIndex(ls_pdid);

        // 判斷是否找到符合的資料，沒有則離開
        if (li_index == -1) return;

        // 取出需求班次的基本資料
        if (!this.uf_DwF_GetData(this.dwF, this.indb_hme101b[li_index]))
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
    protected void uf_MyCalendar_ShowOtherMonth()
    {
        if (ViewState["Year"] != null && ViewState["Month"] != null && ViewState["tid"] != null)
        {
            this.dgG_Retrieve = " AND hme101b_psid = '" + this.StoredKey + "' ";

            dwF_YM_t.Text = "★ " + uf_Dg_Bind("hmd101", ViewState["tid"]) + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月排班班表";
            u_Show.Year = ViewState["Year"].ToString();
            u_Show.Month = ViewState["Month"].ToString();
            u_Show.Tid = this.StoredKey;

            // 需求班次查詢
            string ls_AddSQL = "";
            ls_AddSQL += " AND hme101b_sdate >= '" + Convert.ToDateTime(u_Show.YearE + "/" + u_Show.Month + "/01").AddMonths(-1).ToString("yyyy/MM/dd") + "' ";
            ls_AddSQL += " AND hme101b_sdate <  '" + Convert.ToDateTime(u_Show.YearE + "/" + u_Show.Month + "/01").AddMonths(2).ToString("yyyy/MM/dd") + "' ";
            u_Show.indb_hme101a_hme101b.uf_Retrieve(ls_AddSQL);

            // 產生出月曆
            u_Show.uf_BuildMonth();

            // 若班表為正式班表，不能修改
            string ls_okflag = "";
            DbMethods.uf_ExecSQL(" SELECT Isnull(hme101a_okflag , 'N') From hme101a Where hme101a_psid = '" + this.StoredKey + "' ", ref ls_okflag);
            if (ls_okflag == "N")
            {
                u_Edit_F.uf_Enabled(true);
                bt_t_insert.Enabled = true;
                //sandra 20131024新增一個刪除全部排班的按鈕
                bt_t_deleteall.Enabled = true;
            }
            else
            {
                u_Edit_F.uf_Enabled(false);
                bt_t_insert.Enabled = false;
                //sandra 20131024新增一個刪除全部排班的按鈕
                bt_t_deleteall.Enabled = false;
            }
        }
        else
        {
            dwF_YM_t.Text = "請先點選欲新增之排班表！";
            dwF_YM_t.ForeColor = System.Drawing.Color.Red;
            u_Edit_F.uf_Enabled(false);
        }
    }	// End of uf_MyCalendar_ShowOtherMonth

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

        // 設定異動人員及異動時間
        //adrv_Row["hme101b_uid"] = LoginUser.ID; // 需修正為session
        //adrv_Row["hme101b_udt"] = DbMethods.uf_GetDateTime();

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
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Monday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(1); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Tuesday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(2); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Wednesday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(3); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Thursday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(4); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Friday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(5); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Saturday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
                {
                    for (DateTime ldt_repeat = ldt_day.AddDays(6); ldt_repeat <= ldt_month_end; ldt_repeat = ldt_repeat.AddDays(7))
                    {
                        if (ldt_repeat > ldt_edate)
                        {
                            // 複製資料（取得流水號的系統編號–資料庫最大值+1）（IDENTITY 欄位，資料庫自動+1）
                            li_seq++;
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            this.indb_hme101b.uf_CloneRowFrom(out ldrv_New, adrv_Row, ls_pdid_i, adrv_Row["hme101b_psid"], ldt_repeat);
                            if (adrv_Row["hme101b_starttime"] != DBNull.Value)
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_New.EndEdit();
                        }
                    }
                }
            }
        }

        if (dwF_repeat_Sunday.Checked)
        {
            for (DateTime ldt_day = ldt_sdate; ldt_day <= ldt_edate; ldt_day = ldt_day.AddDays(1))
            {
                if (ldt_day < ldt_sdate.AddDays(1)) //不需重覆新增
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
                                ldrv_New["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_starttime"]).ToString("HH:mm:ss"));
                            if (adrv_Row["hme101b_endtime"] != DBNull.Value)
                                ldrv_New["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(adrv_Row["hme101b_endtime"]).ToString("HH:mm:ss"));
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
        //if (adrv_Row == null) return true;

        this.uf_MyCalendar_ShowOtherMonth();

        // 重新取出查詢及清單資料
        this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');  uf_LinkFrame('p_e0101_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
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
            // 是否每週一重複
            if (acto_Child == dwF_repeat_Monday)
            {
                dwF_repeat_Monday.Checked = false;
                return true;
            }
            // 是否每週二重複
            if (acto_Child == dwF_repeat_Tuesday)
            {
                dwF_repeat_Tuesday.Checked = false;
                return true;
            }

            // 是否每週三重複
            if (acto_Child == dwF_repeat_Wednesday)
            {
                dwF_repeat_Wednesday.Checked = false;
                return true;
            }

            // 是否每週四重複
            if (acto_Child == dwF_repeat_Thursday)
            {
                dwF_repeat_Thursday.Checked = false;
                return true;
            }

            // 是否每週五重複
            if (acto_Child == dwF_repeat_Friday)
            {
                dwF_repeat_Friday.Checked = false;
                return true;
            }

            // 是否每週六重複
            if (acto_Child == dwF_repeat_Saturday)
            {
                dwF_repeat_Saturday.Checked = false;
                return true;
            }

            // 是否每週日重複
            if (acto_Child == dwF_repeat_Sunday)
            {
                dwF_repeat_Sunday.Checked = false;
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
            // 開始時間、結束時間
            if (acto_Child == dwF_hme101b_starttime || acto_Child == dwF_hme101b_endtime)
            {
                if (Convert.ToInt16(Convert.ToDateTime(u_Time1.Value).ToString("HHmm")) >= Convert.ToInt16(Convert.ToDateTime(u_Time2.Value).ToString("HHmm")))
                {
                    this.uf_Msg("「結束時間」必須大於「結束時間」！");
                    return false;
                }

                as_Value = (as_Value.Substring(11, 8) == "00:00:00" ? "" : Convert.ToDateTime(adrv_Row["hme101b_sdate"]).ToString("yyyy/MM/dd") + " " + as_Value.Substring(11, 8));
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

    protected void bt_t_insert_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        DateTime ldt_sdate, ldt_edate, ldt_sdate_i;
        string ls_pdid = "", ls_pdid_i = "";
        int li_seq = 0;
        DataRowView ldrv_Row;

        if (dwS_hme105a_name.SelectedIndex == -1)
        {
            uf_Msg("請確認存在排班樣版！");
            return;
        }

        this.indb_hme105b.uf_Retrieve(" AND hme105b_ssid = '" + dwS_hme105a_name.SelectedValue + "' ");
        this.indb_hme105b.uf_Sort("hme105b_type , hme105b_weekday , hme105b_sdate , hme105b_starttime , hme105b_endtime");
        if (this.indb_hme105b.uf_RowCount() == 0)
        {
            uf_Msg("請確認存在排班樣版需求資料！");
            return;
        }

        ls_pdid = e01Project.uf_Get_SystemNo("hme101b.hme101b_pdid", "SR" + ViewState["Year"].ToString());
        li_seq = Convert.ToInt16(ls_pdid.Substring(5));

        ldt_sdate = Convert.ToDateTime(Convert.ToString(Convert.ToInt16(ViewState["Year"]) + 1911) + "/" + ViewState["Month"].ToString() + "/01");
        ldt_edate = ldt_sdate.AddMonths(1).AddDays(-1);

        for (int li_counter = 0; li_counter < indb_hme105b.uf_RowCount(); li_counter++)
        {
            if (indb_hme105b[li_counter]["hme105b_type"].ToString() == "1") //固定每週禮拜幾
            {
                for (DateTime ldt_day = ldt_sdate; ldt_day < ldt_sdate.AddDays(7); ldt_day = ldt_day.AddDays(1))
                {
                    if (Convert.ToInt16(ldt_day.DayOfWeek).ToString() == indb_hme105b[li_counter]["hme105b_weekday"].ToString()) //確認需新增的日期
                    {
                        for (DateTime ldt_repeat = ldt_day; ldt_repeat <= ldt_edate; ldt_repeat = ldt_repeat.AddDays(7))
                        {
                            // 新增資料
                            ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                            li_seq++;
                            this.indb_hme101b_tmp.uf_InsertRow(out ldrv_Row);

                            ldrv_Row["hme101b_pdid"] = ls_pdid_i;
                            ldrv_Row["hme101b_psid"] = this.StoredKey;
                            ldrv_Row["hme101b_sdate"] = ldt_repeat;
                            ldrv_Row["hme101b_starttime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(indb_hme105b[li_counter]["hme105b_starttime"]).ToString("HH:mm:ss"));
                            ldrv_Row["hme101b_endtime"] = Convert.ToDateTime(ldt_repeat.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(indb_hme105b[li_counter]["hme105b_endtime"]).ToString("HH:mm:ss"));
                            ldrv_Row["hme101b_hour"] = indb_hme105b[li_counter]["hme105b_hour"];
                            ldrv_Row["hme101b_addtext"] = indb_hme105b[li_counter]["hme105b_addtext"];
                            ldrv_Row["hme101b_needno"] = indb_hme105b[li_counter]["hme105b_needno"];
                            ldrv_Row["hme101b_note"] = indb_hme105b[li_counter]["hme105b_note"];
                            ldrv_Row["hme101b_fooda"] = indb_hme105b[li_counter]["hme105b_fooda"];
                            ldrv_Row["hme101b_foodb"] = indb_hme105b[li_counter]["hme105b_foodb"];
                            ldrv_Row["hme101b_foodct"] = indb_hme105b[li_counter]["hme105b_foodct"];
                            ldrv_Row["hme101b_hca213id"] = indb_hme105b[li_counter]["hme105b_hca213id"];
                            ldrv_Row["hme101b_aid"] = LoginUser.ID;
                            ldrv_Row["hme101b_adt"] = DbMethods.uf_GetDateTime();
                            ldrv_Row["hme101b_uid"] = LoginUser.ID;
                            ldrv_Row["hme101b_udt"] = DbMethods.uf_GetDateTime();

                            ldrv_Row.EndEdit();
                        }
                    }
                }
            }
            else //固定每月幾號
            {

                // 新增資料
                ls_pdid_i = ls_pdid.Substring(0, 5) + li_seq.ToString("000000");
                li_seq++;

                ldt_sdate_i = Convert.ToDateTime(Convert.ToString(Convert.ToInt16(ViewState["Year"]) + 1911) + "/" + ViewState["Month"].ToString() + "/" + indb_hme105b[li_counter]["hme105b_sdate"].ToString());
                this.uf_Msg(ls_pdid_i);
                this.indb_hme101b_tmp.uf_InsertRow(out ldrv_Row);

                ldrv_Row["hme101b_pdid"] = ls_pdid_i;
                ldrv_Row["hme101b_psid"] = this.StoredKey;
                ldrv_Row["hme101b_sdate"] = ldt_sdate_i;
                ldrv_Row["hme101b_starttime"] = Convert.ToDateTime(ldt_sdate_i.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(indb_hme105b[li_counter]["hme105b_starttime"]).ToString("HH:mm:ss"));
                ldrv_Row["hme101b_endtime"] = Convert.ToDateTime(ldt_sdate_i.ToString("yyyy/MM/dd") + " " + Convert.ToDateTime(indb_hme105b[li_counter]["hme105b_endtime"]).ToString("HH:mm:ss"));
                ldrv_Row["hme101b_hour"] = indb_hme105b[li_counter]["hme105b_hour"];
                ldrv_Row["hme101b_addtext"] = indb_hme105b[li_counter]["hme105b_addtext"];
                ldrv_Row["hme101b_needno"] = indb_hme105b[li_counter]["hme105b_needno"];
                ldrv_Row["hme101b_note"] = indb_hme105b[li_counter]["hme105b_note"];
                ldrv_Row["hme101b_fooda"] = indb_hme105b[li_counter]["hme105b_fooda"];
                ldrv_Row["hme101b_foodb"] = indb_hme105b[li_counter]["hme105b_foodb"];
                ldrv_Row["hme101b_foodct"] = indb_hme105b[li_counter]["hme105b_foodct"];
                ldrv_Row["hme101b_hca213id"] = indb_hme105b[li_counter]["hme105b_hca213id"];
                ldrv_Row["hme101b_aid"] = LoginUser.ID;
                ldrv_Row["hme101b_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hme101b_uid"] = LoginUser.ID;
                ldrv_Row["hme101b_udt"] = DbMethods.uf_GetDateTime();

                ldrv_Row.EndEdit();
            }
        }

        // 儲存資料
        if (this.indb_hme101b_tmp.uf_Update() != 1)
        {
            this.indb_hme101b_tmp.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hme101b_tmp.ErrorMsg);
            return;
        }
        else
        {
            indb_hme101b_tmp.uf_Retrieve(this.dgG_Retrieve);
            this.uf_MyCalendar_ShowOtherMonth();
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');  uf_LinkFrame('p_e0101_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
            this.uf_Msg("新增樣版完成！");
        }
    }
    //sandra 20131024
    protected void bt_t_deleteall_Click(object sender, EventArgs e)
    {
            //  this.uf_Msg(sqlstr);
        DbMethods.uf_ExecSQL("DELETE FROM [NMMST_VW].[dbo].[hme101b] WHERE hme101b_psid = '" + this.StoredKey + "'");
        DbMethods.uf_ExecSQL("DELETE FROM hme101b WHERE hme101b_psid = '" + this.StoredKey + "'");
        indb_hme101b_tmp.uf_Retrieve(this.dgG_Retrieve);
        this.uf_MyCalendar_ShowOtherMonth();
        // 重新取出查詢及清單資料
        this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');  uf_LinkFrame('p_e0101_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
        this.uf_Msg("全部刪除完成！！");
    }
}
