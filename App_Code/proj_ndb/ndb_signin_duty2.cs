// *********************************************************************************
// 1. 程式描述：上下班刷卡系統 - 刷卡訊息資料–傳入「員工編號」、「刷卡種類–上班(1)；下班(2)」和「刷卡機IP」
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 上下班刷卡系統 - 刷卡訊息資料–傳入「員工編號」、「刷卡種類–上班(1)；下班(2)」和「刷卡機IP」
/// </summary>
public class ndb_signin_duty2 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_signin_duty2(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
		this.uf_InitializeSelect_CutQuote();
	}

	public ndb_signin_duty2()
	{
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
		this.uf_InitializeSelect_CutQuote();
	}

	#region Component Designer generated code
	///// <summary>
	///// 設計工具所需的變數。
	///// </summary>
	//private System.ComponentModel.Container components = null;

	/// <summary>
	/// 此為設計工具支援所必需的方法 - 請勿使用程式碼編輯器修改
	/// 這個方法的內容。
	/// </summary>
	private void InitializeComponent()
	{
		this.da_SQL_current = new System.Data.OleDb.OleDbDataAdapter();
		this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();
		// 
		// da_SQL_current
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "dbo.[usp_signin_duty2]";
		this.oleDbSelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
		this.oleDbSelectCommand.Connection = this.cn_DB;
		this.oleDbSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("as_empno", System.Data.OleDb.OleDbType.VarChar, 9));
		this.oleDbSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("as_type", System.Data.OleDb.OleDbType.VarChar, 1));
		this.oleDbSelectCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("as_ip", System.Data.OleDb.OleDbType.VarChar, 15));
		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).EndInit();

	}
	#endregion

	// =========================================================================
	/// <summary>
	/// 函式描述：自訂初始化函式（覆蓋上層）
	/// </summary>
	protected override void uf_InitializeComponent()
	{
		// 先將 DataSet 宣告為指定的結構再初始化–《《不可在此做初始化》》
		//this.ds_Data = new d_signin_duty2();
		//this.uf_Initialize();
	}
}
