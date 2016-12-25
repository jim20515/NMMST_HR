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
public class ndb_hme105a_hme105b : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hme105a_hme105b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_hme105a_hme105b()
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
            new System.Data.Common.DataTableMapping("Table", "hme105a", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hme105a_ssid", "hme105a_ssid"),
                        new System.Data.Common.DataColumnMapping("hme105a_tid", "hme105a_tid"),
                        new System.Data.Common.DataColumnMapping("hme105a_name", "hme105a_name"),
                        new System.Data.Common.DataColumnMapping("hme105a_aid", "hme105a_aid"),
                        new System.Data.Common.DataColumnMapping("hme105a_adt", "hme105a_adt"),
                        new System.Data.Common.DataColumnMapping("hme105a_uid", "hme105a_uid"),
                        new System.Data.Common.DataColumnMapping("hme105a_udt", "hme105a_udt"),
                        new System.Data.Common.DataColumnMapping("hme105b_sdid", "hme105b_sdid"),
                        new System.Data.Common.DataColumnMapping("hme105b_ssid", "hme105b_ssid"),
                        new System.Data.Common.DataColumnMapping("hme105b_type", "hme105b_type"),
                        new System.Data.Common.DataColumnMapping("hme105b_sdate", "hme105b_sdate"),
                        new System.Data.Common.DataColumnMapping("hme105b_weekday", "hme105b_weekday"),
                        new System.Data.Common.DataColumnMapping("hme105b_starttime", "hme105b_starttime"),
                        new System.Data.Common.DataColumnMapping("hme105b_endtime", "hme105b_endtime"),
                        new System.Data.Common.DataColumnMapping("hme105b_hour", "hme105b_hour"),
                        new System.Data.Common.DataColumnMapping("hme105b_addtext", "hme105b_addtext"),
                        new System.Data.Common.DataColumnMapping("hme105b_needno", "hme105b_needno"),
                        new System.Data.Common.DataColumnMapping("hme105b_note", "hme105b_note"),
                        new System.Data.Common.DataColumnMapping("hme105b_fooda", "hme105b_fooda"),
                        new System.Data.Common.DataColumnMapping("hme105b_foodb", "hme105b_foodb"),
                        new System.Data.Common.DataColumnMapping("hme105b_foodct", "hme105b_foodct"),
                        new System.Data.Common.DataColumnMapping("hme105b_hca213id", "hme105b_hca213id"),
                        new System.Data.Common.DataColumnMapping("hme105b_aid", "hme105b_aid"),
                        new System.Data.Common.DataColumnMapping("hme105b_adt", "hme105b_adt"),
                        new System.Data.Common.DataColumnMapping("hme105b_uid", "hme105b_uid"),
                        new System.Data.Common.DataColumnMapping("hme105b_udt", "hme105b_udt")})});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "Select hme105a.* , hme105b.*\r\nFrom hme105a , hme105b\r\nWhere hme105a.hme105a_ssid " +
			"= hme105b.hme105b_ssid";
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
		this.ds_Data = new d_hme105a_hme105b();
		this.uf_Initialize();
	}
}
