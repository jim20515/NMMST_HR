// *********************************************************************************
// 1. 程式描述：志工資料管理–志工資料維護–志工開放報名
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

public partial class sys_d_d02_p_d0204 : p_sBase
{

	#region ☆ Declare Variables -------------------------------------- 撰寫人員：rong

	/// <summary>變數描述：公告管理資料元件</summary>
	protected ndb_hmd202 indb_hmd202 = new ndb_hmd202();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁初始化
	/// </summary>
	private void Page_Init(object sender, EventArgs e)
	{
		Log.uf_AddLogKeysControl(this.Page);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>

	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeComponent(dwF, null, this.indb_hmd202, u_Edit_F);
		this.dgG_SelectFirstRow = true;

		if (!this.IsPostBack)
		{
			u_Edit_F.UseButton = "U";
		}

		this.StoredKey = this.uf_Dg_BindBool("Y,N", dwF_hmd202_open.Checked);
		object[] lo_value = new object[1];
		lo_value[0] = this.StoredKey;
		Log.uf_SetLogKeysValue(this.Page, lo_value);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：Html 送出前所要做的動作
	/// </summary>
	protected void Page_PreRender(object sender, EventArgs e)
	{
		// 記錄操作記錄主鍵值
		object[] lo_value = new object[1];
		lo_value[0] = this.StoredKey;
		Log.uf_SetLogKeysValue(this.Page, lo_value);
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
			if (acto_Child == dwF_hmd202_open)
			{
				dwF_hmd202_open.Checked = this.uf_Dg_BindBool("Y", as_Value);
				return true;
			}
		}
		else if (a_Action == DwActions.Set)
		{
			if (acto_Child == dwF_hmd202_open)
			{
				as_Value = this.uf_Dg_BindBool("Y,N", dwF_hmd202_open.Checked);
				return true;
			}
		}
		return true;
	}

	#endregion

}
