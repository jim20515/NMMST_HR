// *********************************************************************************
// 1. 程式描述：排班表主檔–無傳入值
// 2. 撰寫人員：demon
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// 人員類別資料元件–無傳入值
/// </summary>
public class ndb_hmc102_g8 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hmc102_g8(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_hmc102_g8()
	{
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmc102_g8));
        this.da_SQL_current = new System.Data.OleDb.OleDbDataAdapter();
        this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
        ((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();
        // 
        // da_SQL_current
        // 
        this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
        this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "hmc102_G8", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("G1", "G1"),
                        new System.Data.Common.DataColumnMapping("G2", "G2"),
                        new System.Data.Common.DataColumnMapping("G3", "G3"),
                        new System.Data.Common.DataColumnMapping("G4", "G4"),
                        new System.Data.Common.DataColumnMapping("G5", "G5"),
                        new System.Data.Common.DataColumnMapping("G6", "G6"),
                        new System.Data.Common.DataColumnMapping("G7", "G7"),
                        new System.Data.Common.DataColumnMapping("G8", "G8")})});
        // 
        // oleDbSelectCommand
        // 
        this.oleDbSelectCommand.CommandText = "SELECT     G1, G2, G3, G4, G5, G6, G7, G8\r\nFROM         hmc102_G8\r\nWHERE     (1 =" +
            " 1)";
        this.oleDbSelectCommand.Connection = this.cn_DB;

	}
	#endregion

	// =========================================================================
	/// <summary>
	/// 函式描述：自訂初始化函式（覆蓋上層）
	/// </summary>
	protected override void uf_InitializeComponent()
	{
		// 先將 DataSet 宣告為指定的結構再初始化
		this.ds_Data = new d_hmc102_g8();
		this.uf_Initialize();
	}
}
