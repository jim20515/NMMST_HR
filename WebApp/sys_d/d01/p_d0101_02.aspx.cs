// *********************************************************************************
// 1. 程式描述：
// 2. 撰寫人員：QFLin
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

public partial class sys_d_d01_p_d0101_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：QFLin

	/// <summary>變數描述：人員類別資料元件</summary>
	protected ndb_hmd101 indb_hmd101 = new ndb_hmd101();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hmd101, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hmd101, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

		// 註冊執行事件
		this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
		this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		// ADD BY RONG 2009/09/07 增加刪除資料前的檢核
		this.ue_DataDelete_PreDelete += new DataHandler(this.u_Edit_F_PreDelete);
		this.ue_DataUpdate_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
			if (this.Request["args"] != null)
				this.StoredKey = this.Request["args"].Trim();

			// 將頁面切換到此頁
			this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

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


		// 如果資料為新增的
		if (adrv_Row.IsNew)
		{
			// 取得流水號的系統編號–資料庫最大值+1

                string NY ="000"+ Convert.ToString((DateTime.Now.Year -1911)); 
                NY = NY.Substring(NY.Length-3,3);

			adrv_Row["hmd101_tid"] = d01Project.uf_Get_SystemNo("hmd101.hmd101_tid", "T" + NY  +  "-");
			dwF_hmd101_tid.Text = adrv_Row["hmd101_tid"].ToString();
		}

		int li_count = 0;
		DbMethods.uf_ExecSQL("Select Count(Distinct hmd201_vid) FROM hmd201 WHERE hmd201_tid = '" + dwF_hmd101_tid.Text + "'", ref li_count);
		if (li_count > 0)
		{
			uf_Msg("已有志工資料屬於此志工隊，無法停用！若仍要停用需先將志工移轉至其他志工隊。");
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
		// 重新取出查詢及清單資料
		this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
		return true;
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（刪除）
	/// </summary>
	private bool u_Edit_F_PreDelete(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;

		// add by rong 2009/09/07不可刪除已有幹部任命資料
		int li_count = 0;
		DbMethods.uf_ExecSQL("Select Count(Distinct hmd201_vid) FROM hmd201 WHERE hmd201_tid = '" + dwF_hmd101_tid.Text + "'", ref li_count);
		if (li_count > 0)
		{
			uf_Msg("已有志工資料屬於此志工隊，無法刪除！");
			return false;
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
			if (acto_Child == dwF_hmd101_stop)
			{
				dwF_hmd101_stop.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}

			if (acto_Child == dwF_vcount)
			{
				int li_count = 0;
				DbMethods.uf_ExecSQL(" Select Count(Distinct hmd201_vid) FROM hmd201 WHERE hmd201_tid = '" + adrv_Row["hmd101_tid"].ToString() + "' ", ref li_count);
				dwF_vcount.Text = li_count.ToString() + " 人";
				return true;
			}
		}
		else if (a_Action == DwActions.Set)
		{
			if (acto_Child == dwF_hmd101_stop)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_hmd101_stop.Checked);

				return true;
			}
		}
		return true;
	}

	#endregion

    protected void dwF_report1_Click(object sender, EventArgs e)
    {
        string ls_tid = "";
        if (dwF_hmd101_tid.Text.Trim() == "")
        {
            this.uf_Msg("請選擇志工隊！");
            return;
        }

        ls_tid = dwF_hmd101_tid.Text.Trim();

        this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_d0101&format=" + "PDF" + "&query=tid=" + ls_tid + "','',1024,768,'no','no');");

    }
}
