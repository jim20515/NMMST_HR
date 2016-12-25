﻿// *********************************************************************************
// 1. 程式描述：代碼維護 - 服務項目 - 查詢及清單
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

public partial class sys_a_a02_p_a0213_01 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：WITSETER (QFLin)

	/// <summary>變數描述：資料元件</summary>
	protected ndb_hca213 indb_hca213 = new ndb_hca213();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>

	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeQuery(dwQ, this.indb_hca213, bt_Query);
		this.uf_InitializeComponent(null, dgG, this.indb_hca213, null);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：dgG 選擇某筆資料所要做的處理
	/// </summary>
	protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.uf_AddJavaScript("uf_LinkFrame('p_a0213_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "')");
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


		return true;
	}

}
