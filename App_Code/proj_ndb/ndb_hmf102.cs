// *********************************************************************************
// 1. 程式描述：hmf102資料元件–無傳入值
// 2. 撰寫人員：generated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmf102資料元件–無傳入值
/// </summary>
public class ndb_hmf102 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmf102(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// 將資料配接器設為 current
		da_SQL = da_SQL_current;
	}

	public ndb_hmf102()
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hmf102));
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
            new System.Data.Common.DataTableMapping("Table", "hmf102", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("hmf102_trainid", "hmf102_trainid"),
                        new System.Data.Common.DataColumnMapping("hmf102_courseid", "hmf102_courseid"),
                        new System.Data.Common.DataColumnMapping("hmf102_teacher", "hmf102_teacher"),
                        new System.Data.Common.DataColumnMapping("hmf102_liser", "hmf102_liser"),
                        new System.Data.Common.DataColumnMapping("hmf102_sdate", "hmf102_sdate"),
                        new System.Data.Common.DataColumnMapping("hmf102_starttime", "hmf102_starttime"),
                        new System.Data.Common.DataColumnMapping("hmf102_edate", "hmf102_edate"),
                        new System.Data.Common.DataColumnMapping("hmf102_endtime", "hmf102_endtime"),
                        new System.Data.Common.DataColumnMapping("hmf102_placeid", "hmf102_placeid"),
                        new System.Data.Common.DataColumnMapping("hmf102_maxno", "hmf102_maxno"),
                        new System.Data.Common.DataColumnMapping("hmf102_rstime", "hmf102_rstime"),
                        new System.Data.Common.DataColumnMapping("hmf102_retime", "hmf102_retime"),
                        new System.Data.Common.DataColumnMapping("hmf102_ps", "hmf102_ps"),
                        new System.Data.Common.DataColumnMapping("hmf102_hca214id", "hmf102_hca214id"),
                        new System.Data.Common.DataColumnMapping("hmf102_hours", "hmf102_hours"),
                        new System.Data.Common.DataColumnMapping("hmf102_aid", "hmf102_aid"),
                        new System.Data.Common.DataColumnMapping("hmf102_adt", "hmf102_adt"),
                        new System.Data.Common.DataColumnMapping("hmf102_uid", "hmf102_uid"),
                        new System.Data.Common.DataColumnMapping("hmf102_udt", "hmf102_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmf102] WHERE (([hmf102_trainid] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hmf102_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmf102_trainid", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmf102] ([hmf102_trainid], [hmf102_courseid], [hmf102_teacher], [hmf102_liser], [hmf102_sdate], [hmf102_starttime], [hmf102_edate], [hmf102_endtime], [hmf102_placeid], [hmf102_maxno], [hmf102_rstime], [hmf102_retime], [hmf102_ps], [hmf102_hca214id], [hmf102_hours], [hmf102_aid], [hmf102_adt], [hmf102_uid], [hmf102_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmf102_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_trainid"),
            new System.Data.OleDb.OleDbParameter("hmf102_courseid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_courseid"),
            new System.Data.OleDb.OleDbParameter("hmf102_teacher", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_teacher"),
            new System.Data.OleDb.OleDbParameter("hmf102_liser", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_liser"),
            new System.Data.OleDb.OleDbParameter("hmf102_sdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_sdate"),
            new System.Data.OleDb.OleDbParameter("hmf102_starttime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_starttime"),
            new System.Data.OleDb.OleDbParameter("hmf102_edate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_edate"),
            new System.Data.OleDb.OleDbParameter("hmf102_endtime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_endtime"),
            new System.Data.OleDb.OleDbParameter("hmf102_placeid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_placeid"),
            new System.Data.OleDb.OleDbParameter("hmf102_maxno", System.Data.OleDb.OleDbType.SmallInt, 0, "hmf102_maxno"),
            new System.Data.OleDb.OleDbParameter("hmf102_rstime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_rstime"),
            new System.Data.OleDb.OleDbParameter("hmf102_retime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_retime"),
            new System.Data.OleDb.OleDbParameter("hmf102_ps", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmf102_ps"),
            new System.Data.OleDb.OleDbParameter("hmf102_hca214id", System.Data.OleDb.OleDbType.WChar, 0, "hmf102_hca214id"),
            new System.Data.OleDb.OleDbParameter("hmf102_hours", System.Data.OleDb.OleDbType.Integer, 0, "hmf102_hours"),
            new System.Data.OleDb.OleDbParameter("hmf102_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_aid"),
            new System.Data.OleDb.OleDbParameter("hmf102_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_adt"),
            new System.Data.OleDb.OleDbParameter("hmf102_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_uid"),
            new System.Data.OleDb.OleDbParameter("hmf102_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmf102] WHERE (1=1) ";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmf102] SET [hmf102_trainid] = ?, [hmf102_courseid] = ?, [hmf102_teacher] = ?, [hmf102_liser] = ?, [hmf102_sdate] = ?, [hmf102_starttime] = ?, [hmf102_edate] = ?, [hmf102_endtime] = ?, [hmf102_placeid] = ?, [hmf102_maxno] = ?, [hmf102_rstime] = ?, [hmf102_retime] = ?, [hmf102_ps] = ?, [hmf102_hca214id] = ?, [hmf102_hours] = ?, [hmf102_aid] = ?, [hmf102_adt] = ?, [hmf102_uid] = ?, [hmf102_udt] = ? WHERE (([hmf102_trainid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hmf102_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_trainid"),
            new System.Data.OleDb.OleDbParameter("hmf102_courseid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_courseid"),
            new System.Data.OleDb.OleDbParameter("hmf102_teacher", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_teacher"),
            new System.Data.OleDb.OleDbParameter("hmf102_liser", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_liser"),
            new System.Data.OleDb.OleDbParameter("hmf102_sdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_sdate"),
            new System.Data.OleDb.OleDbParameter("hmf102_starttime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_starttime"),
            new System.Data.OleDb.OleDbParameter("hmf102_edate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_edate"),
            new System.Data.OleDb.OleDbParameter("hmf102_endtime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_endtime"),
            new System.Data.OleDb.OleDbParameter("hmf102_placeid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_placeid"),
            new System.Data.OleDb.OleDbParameter("hmf102_maxno", System.Data.OleDb.OleDbType.SmallInt, 0, "hmf102_maxno"),
            new System.Data.OleDb.OleDbParameter("hmf102_rstime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_rstime"),
            new System.Data.OleDb.OleDbParameter("hmf102_retime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_retime"),
            new System.Data.OleDb.OleDbParameter("hmf102_ps", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hmf102_ps"),
            new System.Data.OleDb.OleDbParameter("hmf102_hca214id", System.Data.OleDb.OleDbType.WChar, 0, "hmf102_hca214id"),
            new System.Data.OleDb.OleDbParameter("hmf102_hours", System.Data.OleDb.OleDbType.Integer, 0, "hmf102_hours"),
            new System.Data.OleDb.OleDbParameter("hmf102_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_aid"),
            new System.Data.OleDb.OleDbParameter("hmf102_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_adt"),
            new System.Data.OleDb.OleDbParameter("hmf102_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hmf102_uid"),
            new System.Data.OleDb.OleDbParameter("hmf102_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmf102_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hmf102_trainid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hmf102_trainid", System.Data.DataRowVersion.Original, null)});
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
		this.ds_Data = new d_hmf102();
		this.uf_Initialize();
	}
}
