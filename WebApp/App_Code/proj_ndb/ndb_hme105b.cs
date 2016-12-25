// *********************************************************************************
// 1. 程式描述：hme105b資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hme105b資料元件–無傳入值
/// </summary>
public class ndb_hme105b : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hme105b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hme105b()
	{
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	#region Component Designer generated code
	
	/// <summary>
	/// 此為設計工具支援所必需的方法 - 請勿使用程式碼編輯器修改
	/// 這個方法的內容。
	/// </summary>
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hme105b));
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
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "hme105b", new System.Data.Common.DataColumnMapping[] {
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
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hme105b] WHERE (([hme105b_sdid] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hme105b_sdid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hme105b_sdid", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hme105b] ([hme105b_sdid], [hme105b_ssid], [hme105b_type], [hme105b_sdate], [hme105b_weekday], [hme105b_starttime], [hme105b_endtime], [hme105b_hour], [hme105b_addtext], [hme105b_needno], [hme105b_note], [hme105b_fooda], [hme105b_foodb], [hme105b_foodct], [hme105b_hca213id], [hme105b_aid], [hme105b_adt], [hme105b_uid], [hme105b_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hme105b_sdid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_sdid"),
            new System.Data.OleDb.OleDbParameter("hme105b_ssid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_ssid"),
            new System.Data.OleDb.OleDbParameter("hme105b_type", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_type"),
            new System.Data.OleDb.OleDbParameter("hme105b_sdate", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_sdate"),
            new System.Data.OleDb.OleDbParameter("hme105b_weekday", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_weekday"),
            new System.Data.OleDb.OleDbParameter("hme105b_starttime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_starttime"),
            new System.Data.OleDb.OleDbParameter("hme105b_endtime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_endtime"),
            new System.Data.OleDb.OleDbParameter("hme105b_hour", System.Data.OleDb.OleDbType.Double, 0, "hme105b_hour"),
            new System.Data.OleDb.OleDbParameter("hme105b_addtext", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_addtext"),
            new System.Data.OleDb.OleDbParameter("hme105b_needno", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_needno"),
            new System.Data.OleDb.OleDbParameter("hme105b_note", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hme105b_note"),
            new System.Data.OleDb.OleDbParameter("hme105b_fooda", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_fooda"),
            new System.Data.OleDb.OleDbParameter("hme105b_foodb", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_foodb"),
            new System.Data.OleDb.OleDbParameter("hme105b_foodct", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_foodct"),
            new System.Data.OleDb.OleDbParameter("hme105b_hca213id", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_hca213id"),
            new System.Data.OleDb.OleDbParameter("hme105b_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_aid"),
            new System.Data.OleDb.OleDbParameter("hme105b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_adt"),
            new System.Data.OleDb.OleDbParameter("hme105b_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_uid"),
            new System.Data.OleDb.OleDbParameter("hme105b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT * FROM [hme105b] WHERE (1=1) ";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hme105b] SET [hme105b_sdid] = ?, [hme105b_ssid] = ?, [hme105b_type] = ?, [hme105b_sdate] = ?, [hme105b_weekday] = ?, [hme105b_starttime] = ?, [hme105b_endtime] = ?, [hme105b_hour] = ?, [hme105b_addtext] = ?, [hme105b_needno] = ?, [hme105b_note] = ?, [hme105b_fooda] = ?, [hme105b_foodb] = ?, [hme105b_foodct] = ?, [hme105b_hca213id] = ?, [hme105b_aid] = ?, [hme105b_adt] = ?, [hme105b_uid] = ?, [hme105b_udt] = ? WHERE (([hme105b_sdid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hme105b_sdid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_sdid"),
            new System.Data.OleDb.OleDbParameter("hme105b_ssid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_ssid"),
            new System.Data.OleDb.OleDbParameter("hme105b_type", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_type"),
            new System.Data.OleDb.OleDbParameter("hme105b_sdate", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_sdate"),
            new System.Data.OleDb.OleDbParameter("hme105b_weekday", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_weekday"),
            new System.Data.OleDb.OleDbParameter("hme105b_starttime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_starttime"),
            new System.Data.OleDb.OleDbParameter("hme105b_endtime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_endtime"),
            new System.Data.OleDb.OleDbParameter("hme105b_hour", System.Data.OleDb.OleDbType.Double, 0, "hme105b_hour"),
            new System.Data.OleDb.OleDbParameter("hme105b_addtext", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_addtext"),
            new System.Data.OleDb.OleDbParameter("hme105b_needno", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_needno"),
            new System.Data.OleDb.OleDbParameter("hme105b_note", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hme105b_note"),
            new System.Data.OleDb.OleDbParameter("hme105b_fooda", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_fooda"),
            new System.Data.OleDb.OleDbParameter("hme105b_foodb", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_foodb"),
            new System.Data.OleDb.OleDbParameter("hme105b_foodct", System.Data.OleDb.OleDbType.SmallInt, 0, "hme105b_foodct"),
            new System.Data.OleDb.OleDbParameter("hme105b_hca213id", System.Data.OleDb.OleDbType.WChar, 0, "hme105b_hca213id"),
            new System.Data.OleDb.OleDbParameter("hme105b_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_aid"),
            new System.Data.OleDb.OleDbParameter("hme105b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_adt"),
            new System.Data.OleDb.OleDbParameter("hme105b_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme105b_uid"),
            new System.Data.OleDb.OleDbParameter("hme105b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme105b_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hme105b_sdid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hme105b_sdid", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hme105b();
		this.uf_Initialize();
	}
}
