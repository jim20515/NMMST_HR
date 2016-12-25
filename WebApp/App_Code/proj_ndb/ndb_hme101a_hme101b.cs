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
public class ndb_hme101a_hme101b : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

	public ndb_hme101a_hme101b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();

		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
		//this.uf_InitializeSybaseSize();
	}

	public ndb_hme101a_hme101b()
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
            new System.Data.Common.DataTableMapping("Table", "hme101a", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hme101a_psid", "hme101a_psid"),
                        new System.Data.Common.DataColumnMapping("hme101a_tid", "hme101a_tid"),
                        new System.Data.Common.DataColumnMapping("hme101a_syear", "hme101a_syear"),
                        new System.Data.Common.DataColumnMapping("hme101a_smonth", "hme101a_smonth"),
                        new System.Data.Common.DataColumnMapping("hme101a_makeflag", "hme101a_makeflag"),
                        new System.Data.Common.DataColumnMapping("hme101a_okflag", "hme101a_okflag"),
                        new System.Data.Common.DataColumnMapping("hme101a_aid", "hme101a_aid"),
                        new System.Data.Common.DataColumnMapping("hme101a_adt", "hme101a_adt"),
                        new System.Data.Common.DataColumnMapping("hme101a_uid", "hme101a_uid"),
                        new System.Data.Common.DataColumnMapping("hme101a_udt", "hme101a_udt"),
                        new System.Data.Common.DataColumnMapping("hme101a_hrneedno", "hme101a_hrneedno"),
                        new System.Data.Common.DataColumnMapping("hme101b_pdid", "hme101b_pdid"),
                        new System.Data.Common.DataColumnMapping("hme101b_psid", "hme101b_psid"),
                        new System.Data.Common.DataColumnMapping("hme101b_sdate", "hme101b_sdate"),
                        new System.Data.Common.DataColumnMapping("hme101b_starttime", "hme101b_starttime"),
                        new System.Data.Common.DataColumnMapping("hme101b_endtime", "hme101b_endtime"),
                        new System.Data.Common.DataColumnMapping("hme101b_hour", "hme101b_hour"),
                        new System.Data.Common.DataColumnMapping("hme101b_addtext", "hme101b_addtext"),
                        new System.Data.Common.DataColumnMapping("hme101b_needno", "hme101b_needno"),
                        new System.Data.Common.DataColumnMapping("hme101b_note", "hme101b_note"),
                        new System.Data.Common.DataColumnMapping("hme101b_fooda", "hme101b_fooda"),
                        new System.Data.Common.DataColumnMapping("hme101b_foodb", "hme101b_foodb"),
                        new System.Data.Common.DataColumnMapping("hme101b_foodct", "hme101b_foodct"),
                        new System.Data.Common.DataColumnMapping("hme101b_aid", "hme101b_aid"),
                        new System.Data.Common.DataColumnMapping("hme101b_adt", "hme101b_adt"),
                        new System.Data.Common.DataColumnMapping("hme101b_uid", "hme101b_uid"),
                        new System.Data.Common.DataColumnMapping("hme101b_udt", "hme101b_udt")})});
        // 
        // oleDbSelectCommand
        // 
        this.oleDbSelectCommand.CommandText = "Select hme101a.* , hme101b.*\r\nFrom hme101a , hme101b\r\nWhere hme101a.hme101a_psid " +
            "= hme101b.hme101b_psid";
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
		this.ds_Data = new d_hme101a_hme101b();
		this.uf_Initialize();
	}
}
