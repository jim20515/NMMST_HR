// *********************************************************************************
// 1. 程式描述：簡訊賀卡系統–簡訊發送 - 簡訊即時發送
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

public partial class sys_h_h02_p_h0201_04 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：人員主檔資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();
    private string is_ReturnObjectID;
    private string is_ReturnObjectID1;
    private string is_ReturnFormID;
    private string ls_ID;
    private string ls_name;

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        // 不驗證 Frame
        this.IsCheckFrame = false;
        // 不顯示 Version
        this.IsShowVersion = false;
        // 不顯示網頁 Title
        this.IsShowTitle = false;

        string ls_sql = " select dbo.uf_PicTable(6) as CCTable  ", ls_CCTable = "";
        DbMethods.uf_ExecSQL(ls_sql, ref ls_CCTable);

        Literal1.Text = ls_CCTable;
	}
}
