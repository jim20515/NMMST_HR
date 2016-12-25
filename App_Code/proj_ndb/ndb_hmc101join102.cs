// *********************************************************************************
// 1. 程式描述：人力資源主檔與分類
// 2. 撰寫人員：QFLin
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 人員類別資料元件–無傳入值
/// </summary>
public class ndb_hmc101join102 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hmc101join102(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmc101join102()
	{
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;

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
        this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
        ((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();
        
        // 
        // da_SQL_current
        // 
        this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
        this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "hmc101j102", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmc101_id", "A.hmc101_id"),
                        new System.Data.Common.DataColumnMapping("hmc101_cname", "A.hmc101_cname"),
                        new System.Data.Common.DataColumnMapping("hme102_id", "B.hme102_id")})});
        // 
        // oleDbSelectCommand
        // 
        this.oleDbSelectCommand.CommandText = "SELECT A.hmc101_id, A.hmc101_cname, B.hmc102_id FROM hmc101 as A, hmc101_102 as B WHERE A.hmc101_id = B.hmc101_id ";
        this.oleDbSelectCommand.Connection = this.cn_DB;
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
		// 先將 DataSet 宣告為指定的結構再初始化
		this.ds_Data = new d_hmc101j102();
		this.uf_Initialize();
	}
	
}
