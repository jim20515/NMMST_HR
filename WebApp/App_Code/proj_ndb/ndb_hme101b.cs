// *********************************************************************************
// 1. �{���y�z�Ghme101b��Ƥ���V�L�ǤJ��
// 2. ���g�H���Ggenerated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hme101b��Ƥ���V�L�ǤJ��
/// </summary>
public class ndb_hme101b : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hme101b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	public ndb_hme101b()
	{
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	#region Component Designer generated code
	
	/// <summary>
	/// �����]�p�u��䴩�ҥ��ݪ���k - �ФŨϥε{���X�s�边�ק�
	/// �o�Ӥ�k�����e�C
	/// </summary>
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndb_hme101b));
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
            new System.Data.Common.DataTableMapping("Table", "hme101b", new System.Data.Common.DataColumnMapping[] {
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
                        new System.Data.Common.DataColumnMapping("hme101b_hca213id", "hme101b_hca213id"),
                        new System.Data.Common.DataColumnMapping("hme101b_aid", "hme101b_aid"),
                        new System.Data.Common.DataColumnMapping("hme101b_adt", "hme101b_adt"),
                        new System.Data.Common.DataColumnMapping("hme101b_uid", "hme101b_uid"),
                        new System.Data.Common.DataColumnMapping("hme101b_udt", "hme101b_udt")})});
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		// 
		// oleDbDeleteCommand
		// 
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hme101b] WHERE (([hme101b_pdid] = ?))";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_hme101b_pdid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hme101b_pdid", System.Data.DataRowVersion.Original, null)});
		// 
		// oleDbInsertCommand
		// 
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hme101b] ([hme101b_pdid], [hme101b_psid], [hme101b_sdate], [hme101b_starttime], [hme101b_endtime], [hme101b_hour], [hme101b_addtext], [hme101b_needno], [hme101b_note], [hme101b_fooda], [hme101b_foodb], [hme101b_foodct], [hme101b_hca213id], [hme101b_aid], [hme101b_adt], [hme101b_uid], [hme101b_udt]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hme101b_pdid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_pdid"),
            new System.Data.OleDb.OleDbParameter("hme101b_psid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_psid"),
            new System.Data.OleDb.OleDbParameter("hme101b_sdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_sdate"),
            new System.Data.OleDb.OleDbParameter("hme101b_starttime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_starttime"),
            new System.Data.OleDb.OleDbParameter("hme101b_endtime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_endtime"),
            new System.Data.OleDb.OleDbParameter("hme101b_hour", System.Data.OleDb.OleDbType.Double, 0, "hme101b_hour"),
            new System.Data.OleDb.OleDbParameter("hme101b_addtext", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_addtext"),
            new System.Data.OleDb.OleDbParameter("hme101b_needno", System.Data.OleDb.OleDbType.SmallInt, 0, "hme101b_needno"),
            new System.Data.OleDb.OleDbParameter("hme101b_note", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hme101b_note"),
            new System.Data.OleDb.OleDbParameter("hme101b_fooda", System.Data.OleDb.OleDbType.WChar, 0, "hme101b_fooda"),
            new System.Data.OleDb.OleDbParameter("hme101b_foodb", System.Data.OleDb.OleDbType.WChar, 0, "hme101b_foodb"),
            new System.Data.OleDb.OleDbParameter("hme101b_foodct", System.Data.OleDb.OleDbType.SmallInt, 0, "hme101b_foodct"),
            new System.Data.OleDb.OleDbParameter("hme101b_hca213id", System.Data.OleDb.OleDbType.WChar, 0, "hme101b_hca213id"),
            new System.Data.OleDb.OleDbParameter("hme101b_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_aid"),
            new System.Data.OleDb.OleDbParameter("hme101b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_adt"),
            new System.Data.OleDb.OleDbParameter("hme101b_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_uid"),
            new System.Data.OleDb.OleDbParameter("hme101b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_udt")});
		// 
		// oleDbSelectCommand
		// 
		this.oleDbSelectCommand.CommandText = "SELECT * FROM [hme101b] WHERE (1=1) ";
		this.oleDbSelectCommand.Connection = this.cn_DB;
		// 
		// oleDbUpdateCommand
		// 
		this.oleDbUpdateCommand.CommandText = "UPDATE [hme101b] SET [hme101b_pdid] = ?, [hme101b_psid] = ?, [hme101b_sdate] = ?, [hme101b_starttime] = ?, [hme101b_endtime] = ?, [hme101b_hour] = ?, [hme101b_addtext] = ?, [hme101b_needno] = ?, [hme101b_note] = ?, [hme101b_fooda] = ?, [hme101b_foodb] = ?, [hme101b_foodct] = ?, [hme101b_hca213id] = ?, [hme101b_aid] = ?, [hme101b_adt] = ?, [hme101b_uid] = ?, [hme101b_udt] = ? WHERE (([hme101b_pdid] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("hme101b_pdid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_pdid"),
            new System.Data.OleDb.OleDbParameter("hme101b_psid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_psid"),
            new System.Data.OleDb.OleDbParameter("hme101b_sdate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_sdate"),
            new System.Data.OleDb.OleDbParameter("hme101b_starttime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_starttime"),
            new System.Data.OleDb.OleDbParameter("hme101b_endtime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_endtime"),
            new System.Data.OleDb.OleDbParameter("hme101b_hour", System.Data.OleDb.OleDbType.Double, 0, "hme101b_hour"),
            new System.Data.OleDb.OleDbParameter("hme101b_addtext", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_addtext"),
            new System.Data.OleDb.OleDbParameter("hme101b_needno", System.Data.OleDb.OleDbType.SmallInt, 0, "hme101b_needno"),
            new System.Data.OleDb.OleDbParameter("hme101b_note", System.Data.OleDb.OleDbType.LongVarWChar, 0, "hme101b_note"),
            new System.Data.OleDb.OleDbParameter("hme101b_fooda", System.Data.OleDb.OleDbType.WChar, 0, "hme101b_fooda"),
            new System.Data.OleDb.OleDbParameter("hme101b_foodb", System.Data.OleDb.OleDbType.WChar, 0, "hme101b_foodb"),
            new System.Data.OleDb.OleDbParameter("hme101b_foodct", System.Data.OleDb.OleDbType.SmallInt, 0, "hme101b_foodct"),
            new System.Data.OleDb.OleDbParameter("hme101b_hca213id", System.Data.OleDb.OleDbType.WChar, 0, "hme101b_hca213id"),
            new System.Data.OleDb.OleDbParameter("hme101b_aid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_aid"),
            new System.Data.OleDb.OleDbParameter("hme101b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_adt"),
            new System.Data.OleDb.OleDbParameter("hme101b_uid", System.Data.OleDb.OleDbType.VarWChar, 0, "hme101b_uid"),
            new System.Data.OleDb.OleDbParameter("hme101b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hme101b_udt"),
            new System.Data.OleDb.OleDbParameter("Original_hme101b_pdid", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "hme101b_pdid", System.Data.DataRowVersion.Original, null)});
		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).EndInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).EndInit();

	}
	#endregion

	// =========================================================================
	/// <summary>
	/// �禡�y�z�G�ۭq��l�ƨ禡�]�л\�W�h�^
	/// </summary>
	protected override void uf_InitializeComponent()
	{
		// ���N DataSet �ŧi�����w�����c�A��l��
		this.ds_Data = new d_hme101b();
		this.uf_Initialize();
	}
}