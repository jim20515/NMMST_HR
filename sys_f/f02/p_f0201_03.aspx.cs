// *********************************************************************************
// 1. 程式描述：服務勤務管理–勤務紀錄管理–志工選擇
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

public partial class sys_f_f02_p_f0201_03 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：人員主檔資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
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

        //初始化
        this.uf_InitializeQuery(dwQ, this.indb_hmd201, bt_Query);
        this.uf_InitializeComponent(null, dgG, this.indb_hmd201, null);

        this.is_ReturnFormID = this.Request["ReturnFormID"];

        if (this.Request["ReturnObjectID"] != null)
            this.is_ReturnObjectID = this.Request["ReturnObjectID"].Trim();
        else
            this.is_ReturnObjectID = "";

        if (this.Request["ReturnObjectID1"] != null)
            this.is_ReturnObjectID1 = this.Request["ReturnObjectID1"].Trim();
        else
            this.is_ReturnObjectID1 = "";

	}

	// =========================================================================
	/// <summary>
	/// 事件描述：dgG 選擇某筆資料所要做的處理
	/// </summary>
	protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.uf_AddJavaScript("uf_LinkFrame('p_f0201_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "'); uf_LinkFrame('p_f0101_03.aspx', '03Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "|" + dgG.Items[dgG.SelectedIndex].Cells[2].Text.Trim() + "|" + dgG.Items[dgG.SelectedIndex].Cells[3].Text.Trim() + "|" + dgG.Items[dgG.SelectedIndex].Cells[4].Text.Trim() + "')");

        // ##### 宣告變數 #####
        string ls_JavaScript = "";

        // 取得選擇的品項
        ls_ID = dgG.Items[dgG.SelectedIndex].Cells[1].Text.Trim();
        ls_name = dgG.Items[dgG.SelectedIndex].Cells[4].Text.Trim();

        // 組成 JavaScript

        ls_JavaScript += "	if (opener.document.getElementById(\"" + this.Request["ReturnObjectID"].Trim() + "\") != null)" + "\r\n";
        ls_JavaScript += "		opener.document.all." + this.Request["ReturnObjectID"].Trim() + ".value=\"" + ls_ID + "\";" + "\r\n";
        ls_JavaScript += "	if (opener.document.getElementById(\"" + this.Request["ReturnObjectID1"].Trim() + "\") != null)" + "\r\n";
        ls_JavaScript += "		opener.document.all." + this.Request["ReturnObjectID1"].Trim() + ".value=\"" + ls_name + "\";" + "\r\n";

        ls_JavaScript += " close();" + "\r\n";
        this.uf_AddJavaScript(ls_JavaScript);

	}

    // =========================================================================
    /// <summary>
    /// 函式描述：資料控制項容器控制項組合出查詢語法之後針對特殊或不能處理的子控制項再修改組合出的查詢語法（一個控制項處理一次）（覆蓋上層）
    /// </summary>
    /// <param name="acto_Child">資料控制項容器上的子控制項</param>
    /// <param name="as_ColType">子控制項對應欄位的型態種類–清空時(空字串)；字串等於(S)；字串相似(SL)；日期時間(DT)；日期(D)；時間(T)；數值(N)</param>
    /// <param name="as_Value">子控制項對應欄位的值(已去空白)–傳入的值已處理不安全內容，如有變更需自行確認其安全性</param>
    /// <param name="a_Action">處理種類–清空(New)；查詢(Set)</param>
    /// <param name="as_AddSQL">清空(New)為空字串；查詢(Set)則傳入之前組合出的查詢語法(尚未加入此控制項語法)</param>
    /// <param name="ab_IsAdd">是否加入此控制項語法或參數–是(true)；否(false)</param>
    /// <param name="a_Kind">資料查詢種類–語法(AddSQL)；參數(AddArg)</param>
    /// <returns>成功(true)；失敗(false)</returns>
    protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
    {
        if (a_Action == DwActions.Set)
        {
            // 人員姓名
            if (acto_Child == dwQ_hmd201_vname)
            {
                if (dwQ_hmd201_vname.Text.Trim() != "")
                {
                    as_AddSQL += " AND Hmd201_id in ( Select hmc101_id From hmc101 where hmc101_cname like '%" + dwQ_hmd201_vname.Text.Trim() + "%')";
                }
                return true;
            }

        }
        return true;
    }
}
