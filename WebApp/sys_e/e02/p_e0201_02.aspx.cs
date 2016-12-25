// *********************************************************************************
// 1. 程式描述：服務勤務管理–勤務紀錄管理–明細
// 2. 撰寫人員：demon
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;

public partial class sys_e_e02_p_e0201_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (by QFLin)

	/// <summary>變數描述：人員類別資料元件</summary>
	protected ndb_hle201 indb_hle201 = new ndb_hle201();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hle201, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hle201, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

		// 註冊執行事件
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataUpdate_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
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
			this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

        this.indb_hle201.dv_View.Table.Columns["hle201_sdatetime"].DefaultValue = DbMethods.uf_GetDateTime().ToString();
        this.indb_hle201.dv_View.Table.Columns["hle201_cancel"].DefaultValue = "N";
        this.indb_hle201.dv_View.Table.Columns["hle201_cway"].DefaultValue = "2";


		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[1];
		this.dgG_FindValue[0] = this.StoredKey;

        bt_choose1.Attributes["OnClick"] = "uf_OpenWindow('p_e0201_03.aspx?ReturnFormID=" + this.uf_GetFormID() + "&ReturnObjectID=" + dwF_hle201_vid.ClientID + "&ReturnObjectID1=" + dwF_hle201_vname.ClientID + "', '', 640, 420, 'no', 'no')";

	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;
        IPAddress IPtest = new IPAddress(0);

		// 如果資料為新增的
		if (adrv_Row.IsNew)
		{
			// 取得流水號的系統編號–資料庫最大值+1
            adrv_Row["hle201_lid"] = e01Project.uf_Get_SystemNo("hle201.hle201_lid", "Slog");
			dwF_hle201_lid.Text = adrv_Row["hle201_lid"].ToString();

            //adrv_Row["hle201_cdt"] = DbMethods.uf_GetDateTime();  //建檔時間
            //dwF_hle201_cdt.Text = adrv_Row["hle201_cdt"].ToString();
		}

        if (dwF_hle201_ip.Text.Trim() != "")
        {
            if (!IPAddress.TryParse(dwF_hle201_ip.Text, out IPtest))
            {
                this.uf_Msg(dwF_hle201_ip.Text.Trim() + "不符合IP格式，請修正！");
                return false;
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
		this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
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
            // 建檔方式
            if (acto_Child == dwF_hle201_cway_c)
            {
                dwF_hle201_cway_c.Text = uf_Dg_Bind(dwF_hle201_cway.Items, "2");
                return true;
            }
            // 志工姓名
            if (acto_Child == dwF_hle201_vname)
            {
                dwF_hle201_vname.Text = uf_Dg_Bind("hmd201", adrv_Row["hle201_vid"]);
                return true;
            }
            // 刷卡時間
            if (acto_Child == dwF_hle201_sdatetime)
            {
                DateTime ldt_date;
                ListItem lli_Item;
                ldt_date = Convert.ToDateTime(adrv_Row["hle201_sdatetime"]);
                lli_Item = dwF_SHour.Items.FindByValue(ldt_date.Hour.ToString("00"));
                if (lli_Item != null)
                    dwF_SHour.SelectedIndex = dwF_SHour.Items.IndexOf(lli_Item);

                lli_Item = dwF_SMin.Items.FindByValue(ldt_date.Minute.ToString("00"));
                if (lli_Item != null)
                    dwF_SMin.SelectedIndex = dwF_SMin.Items.IndexOf(lli_Item);

                lli_Item = dwF_SSec.Items.FindByValue(ldt_date.Second.ToString("00"));
                if (lli_Item != null)
                    dwF_SSec.SelectedIndex = dwF_SSec.Items.IndexOf(lli_Item);

                return true;
            }
        }
        else if (a_Action == DwActions.Set)
        {
            // 刷卡時間
            if (acto_Child == dwF_hle201_sdatetime)
            {
                as_Value = u_Date1.Value + " " + dwF_SHour.SelectedValue + ":" + dwF_SMin.SelectedValue + ":" + dwF_SSec.SelectedValue;
                return true;
            }
        }

        return true;
	}

	#endregion

}
