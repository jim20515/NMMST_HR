// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排班表設定–排班主檔–明細
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

public partial class sys_e_e01_p_e0101_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

	/// <summary>變數描述：排班表資料元件</summary>
	protected ndb_hme101a indb_hme101a = new ndb_hme101a();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hme101a, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hme101a, u_Edit_F);
        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

		// 註冊執行事件
		this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataUpdate_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataDelete_PreDelete += new DataHandler(this.u_Edit_F_PreDelete);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
			if (this.Request["args"] != null)
				this.StoredKey = this.Request["args"].Trim();

			// 將頁面切換到此頁
			//this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

        this.indb_hme101a.dv_View.Table.Columns["hme101a_okflag"].DefaultValue = "N";

        dwF_hme101a_syear.Attributes["onBlur"] = "uf_GetNumeric(" + dwF_hme101a_syear.ClientID + ");";
        dwF_hme101a_smonth.Attributes["onBlur"] = "uf_GetNumeric(" + dwF_hme101a_smonth.ClientID + ");";
        dwF_hme101a_hrneedno.Attributes["onBlur"] = "uf_GetNumeric(" + dwF_hme101a_hrneedno.ClientID + ");";

		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[1];
        this.dgG_FindValue[0] = this.StoredKey;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;

        if (dwF_hme101a_syear.Text.Trim() == "")
        {
            uf_Msg("請輸入班表年度！");
            return false;
        }

        if (dwF_hme101a_smonth.Text.Trim() == "")
        {
            uf_Msg("請輸入班表月份！");
            return false;
        }

        // 志工排班次數
        if (dwF_hme101a_hrneedno.Text.Trim() == "")
        {
            uf_Msg("請輸入志工排班次數！");
            return true;
        }


        int li_year = Convert.ToInt16(dwF_hme101a_syear.Text);
        int li_month = Convert.ToInt16(dwF_hme101a_smonth.Text);
        int li_count = 0;

		// 如果資料為新增的
		if (adrv_Row.IsNew)
		{            
            DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101a WHERE hme101a_tid = '" + dwF_hme101a_tid.SelectedValue + "' AND hme101a_syear = '" + li_year.ToString("000") + "' AND hme101a_smonth = '" + li_month.ToString("00") + "' ", ref li_count);
            if (li_count > 0)
            {
                uf_Msg(dwF_hme101a_tid.SelectedItem.Text.Trim() + "已存在" + li_year.ToString("000") + "年" + li_month.ToString("00") + "月的排班表！");
                return false;
            }

			// 取得流水號的系統編號–資料庫最大值+1
            adrv_Row["hme101a_psid"] = e01Project.uf_Get_SystemNo("hme101a.hme101a_psid", "S" + li_year.ToString("000"));
            this.StoredKey = adrv_Row["hme101a_psid"].ToString();

            //adrv_Row["hme101a_cdt"] = DbMethods.uf_GetDateTime();  //建檔時間
            
            dwF_rcount.Text = "班次：已安排 0 班次";
            dwF_pcount.Text = "人次：需 0 人次";

		}
        else
        {
            if (!(adrv_Row.Row["hme101a_syear", DataRowVersion.Original].ToString().Trim() == adrv_Row["hme101a_syear"].ToString().Trim() &&
                  adrv_Row.Row["hme101a_smonth", DataRowVersion.Original].ToString().Trim() == adrv_Row["hme101a_smonth"].ToString().Trim() &&
                  adrv_Row.Row["hme101a_tid", DataRowVersion.Original].ToString().Trim() == adrv_Row["hme101a_tid"].ToString().Trim()))
            {
                DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + this.StoredKey + "' ", ref li_count);

                //若此資料存在班表需求，不允許修改
                if (li_count > 0)
                {
                    uf_Msg(dwF_hme101a_tid.SelectedItem.Text.Trim() + li_year.ToString("000") + "年" + li_month.ToString("00") + "月的排班表已新增班表需求，不可修改！");
                    return false;
                }
            }
            else
            {
                if (adrv_Row["hme101a_okflag"].ToString().Trim() == "Y")
                {
                    uf_Msg(dwF_hme101a_tid.SelectedItem.Text.Trim() + li_year.ToString("000") + "年" + li_month.ToString("00") + "月的排班表已為正式班表，不可修改！");
                    return false;
                }
            }
        }

		return true;
	}

    // =========================================================================
    // 事件
    // =========================================================================
    /// <summary>
    /// 事件描述：按下 u_Edit_F 按鈕資料刪除之前所做的處理（刪除）
    /// </summary>
    private bool u_Edit_F_PreDelete(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
    {
        // 若此資料存在班表需求，不允許修改
        int li_year = Convert.ToInt16(dwF_hme101a_syear.Text);
        int li_month = Convert.ToInt16(dwF_hme101a_smonth.Text);
        int li_count = 0;

        DbMethods.uf_ExecSQL("SELECT COUNT(*) FROM hme101b WHERE hme101b_psid = '" + this.StoredKey + "' ", ref li_count);
        if (li_count > 0)
        {
            this.uf_Msg(dwF_hme101a_tid.SelectedItem.Text.Trim() + li_year.ToString("000") + "年" + li_month.ToString("00") + "月的排班表已新增班表需求，不可刪除！");
            return false;
        }

        return true;
    }

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料儲存之後所做的處理（新增、修改、刪除）
	/// </summary>
	private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
        if (adrv_Row == null)
        {
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_LinkFrame('p_e0101_03.aspx', '03Frame', ''); ");
        }
        else
        {
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_LinkFrame('p_e0101_03.aspx', '03Frame', '" + adr_Row["hme101a_psid"].ToString() + "|" + adr_Row["hme101a_syear"].ToString() + "|" + adr_Row["hme101a_smonth"].ToString() + "|" + adr_Row["hme101a_tid"].ToString() + "'); ");
        }

		return true;
	}

	#region ☆ Override Methods --------------------------------------- 撰寫人員：fen

	// =========================================================================
	/// <summary>
	/// 函式描述：資料控制項容器做相關處理之後針對特殊或不能處理的子控制項做相關處理（覆蓋上層）
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
			// 是否停用
            if (acto_Child == dwF_hme101a_makeflag)
			{
                dwF_hme101a_makeflag.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}

			// 是否允許其它小隊報名
			if (acto_Child == dwF_hme101a_openflag)
			{
				dwF_hme101a_openflag.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}

            // 是否為正式班表
            if (acto_Child == dwF_hme101a_okflag_c)
            {
                dwF_hme101a_okflag_c.Text = (as_Value == "Y" ? "是" : "否");
                return true;
            }

            // 班次
            if (acto_Child == dwF_rcount)
            {
                dwF_rcount.Text = "班次：已安排 " + e01Project.uf_rcount(adrv_Row["hme101a_psid"]) + " 班次";
                return true;
            }

            // 人次
            if (acto_Child == dwF_pcount)
            {
                dwF_pcount.Text = "人次：需 " + e01Project.uf_pcount(adrv_Row["hme101a_psid"]) + " 人次";
                return true;
            }

		}
		else if (a_Action == DwActions.Set)
		{
			// 是否停用
            if (acto_Child == dwF_hme101a_makeflag)
			{
                as_Value = this.uf_Dg_BindBool("Y,N", dwF_hme101a_makeflag.Checked);
				return true;
			}

			// 是否允許其他小隊報名
			if (acto_Child == dwF_hme101a_openflag)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_hme101a_openflag.Checked);
				return true;
			}

            // 年份
            if (acto_Child == dwF_hme101a_syear)
            {
                if (dwF_hme101a_syear.Text.Trim() == "")
                {
                    uf_Msg("請輸入年份！");
                    return false;
                }
                int li_year = Convert.ToInt16(dwF_hme101a_syear.Text);
                as_Value = li_year.ToString("000");
                return true;
            }

            // 月份
            if (acto_Child == dwF_hme101a_smonth)
            {
                if (dwF_hme101a_smonth.Text.Trim() == "")
                {
                    uf_Msg("請輸入月份！");
                    return false;
                }
                int li_month = Convert.ToInt16(dwF_hme101a_smonth.Text);
                as_Value = li_month.ToString("00");
                return true;
            }

		}
		return true;
	}

	#endregion

}
