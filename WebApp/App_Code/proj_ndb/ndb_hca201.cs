// *********************************************************************************
// 1. �{���y�z�Ghca201��Ƥ���V�L�ǤJ��
// 2. ���g�H���Ggenerated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hca201��Ƥ���V�L�ǤJ��
/// </summary>
public class ndb_hca201 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca201(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	public ndb_hca201()
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
		this.da_SQL_current = new System.Data.OleDb.OleDbDataAdapter();
		this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
		this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
		
		((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
		((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();

		// 
		// �e��
		// 
		this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
			
                                           new System.Data.Common.DataTableMapping("Table", "hca201", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hca201_id", "hca201_id"),
                                           new System.Data.Common.DataColumnMapping("hca201_name", "hca201_name"),
                                           new System.Data.Common.DataColumnMapping("hca201_stop", "hca201_stop"),
                                           new System.Data.Common.DataColumnMapping("hca201_aid", "hca201_aid"),
                                           new System.Data.Common.DataColumnMapping("hca201_adt", "hca201_adt"),
                                           new System.Data.Common.DataColumnMapping("hca201_uid", "hca201_uid"),
                                           new System.Data.Common.DataColumnMapping("hca201_udt", "hca201_udt")
                                           })
            });
                                           
		// 
		// �R���R�O
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca201] WHERE (([hca201_id] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hca201_id", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(5)), ((byte)(0)), "hca201_id", System.Data.DataRowVersion.Original, null)
		});


		// 
		// �s�W��
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca201] ([hca201_id],[hca201_name],[hca201_stop],[hca201_aid],[hca201_adt],[hca201_uid],[hca201_udt]) VALUES (?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca201_id", System.Data.OleDb.OleDbType.SmallInt, 0, "hca201_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca201_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_stop", System.Data.OleDb.OleDbType.Char, 0, "hca201_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca201_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca201_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca201_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca201_udt")
		});


		// 
		// �d�߰�
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hca201] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// ��s��
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca201] SET  [hca201_id] = ?, [hca201_name] = ?, [hca201_stop] = ?, [hca201_aid] = ?, [hca201_adt] = ?, [hca201_uid] = ?, [hca201_udt] = ?  WHERE (([hca201_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca201_id", System.Data.OleDb.OleDbType.SmallInt, 0, "hca201_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca201_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_stop", System.Data.OleDb.OleDbType.Char, 0, "hca201_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca201_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca201_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca201_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca201_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca201_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hca201_id", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((byte)(5)), ((byte)(0)), "hca201_id", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hca201();
		this.uf_Initialize();
	}
}