// *********************************************************************************
// 1. 程式描述：
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

public partial class sys_d_d01_p_d0102_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：QFLin

	/// <summary>變數描述：人員類別資料元件</summary>
	protected ndb_hmd102 indb_hmd102 = new ndb_hmd102();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeQuery(null, this.indb_hmd102, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hmd102, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

		this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);

		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
			string[] lsa_Arguments = null;
			if (this.Request["args"] != null)
			{
				lsa_Arguments = this.Request["args"].Split('|');
				if (lsa_Arguments.Length >= 4)
				{
					this.StoredKey = lsa_Arguments[0];
					ViewState["season"] = lsa_Arguments[1];
					ViewState["tid"] = lsa_Arguments[2];
					ViewState["ktype"] = lsa_Arguments[3];
				}
			}
			// 將頁面切換到此頁
			this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

		// 將主鍵值記錄為尋找資料的條件
		this.dgG_FindValue = new object[4];
		this.dgG_FindValue[0] = this.StoredKey;
		this.dgG_FindValue[1] = ViewState["season"];
		this.dgG_FindValue[2] = ViewState["tid"];
		this.dgG_FindValue[3] = ViewState["ktype"];

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
		return true;
	}

	#endregion
}
