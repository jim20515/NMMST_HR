// *********************************************************************************
// 1. �{���y�z�Ghmc101_102��Ƥ���V�L�ǤJ��
// 2. ���g�H���Ggenerated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmc101_102��Ƥ���V�L�ǤJ��
/// </summary>
public class ndb_hmc101_102 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmc101_102(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	public ndb_hmc101_102()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hmc101_102", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hmc102_id", "hmc102_id"),
                                           new System.Data.Common.DataColumnMapping("hmc101_id", "hmc101_id"),
                                           new System.Data.Common.DataColumnMapping("hmc101_102_uid", "hmc101_102_uid"),
                                           new System.Data.Common.DataColumnMapping("hmc101_102_udt", "hmc101_102_udt")
                                           })
            });
                                           
		// 
		// �R���R�O
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmc101_102] WHERE (([hmc102_id] = ?))  AND (([hmc101_id] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hmc102_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(0)), "hmc102_id", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmc101_id", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmc101_id", System.Data.DataRowVersion.Original, null)

		});


		// 
		// �s�W��
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmc101_102] ([hmc102_id],[hmc101_id],[hmc101_102_uid],[hmc101_102_udt]) VALUES (?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmc102_id", System.Data.OleDb.OleDbType.Integer, 0, "hmc102_id"),
                                                     new System.Data.OleDb.OleDbParameter("hmc101_id", System.Data.OleDb.OleDbType.VarChar, 0, "hmc101_id"),
                                                     new System.Data.OleDb.OleDbParameter("hmc101_102_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmc101_102_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmc101_102_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_102_udt")
		});


		// 
		// �d�߰�
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmc101_102] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// ��s��
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmc101_102] SET  [hmc102_id] = ?, [hmc101_id] = ?, [hmc101_102_uid] = ?, [hmc101_102_udt] = ?  WHERE (([hmc102_id] = ?)) AND (([hmc101_id] = ?)) ";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmc102_id", System.Data.OleDb.OleDbType.Integer, 0, "hmc102_id"),
                                                     new System.Data.OleDb.OleDbParameter("hmc101_id", System.Data.OleDb.OleDbType.VarChar, 0, "hmc101_id"),
                                                     new System.Data.OleDb.OleDbParameter("hmc101_102_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmc101_102_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmc101_102_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmc101_102_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmc102_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(0)), "hmc102_id", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmc101_id", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(20)), ((byte)(0)), "hmc101_id", System.Data.DataRowVersion.Original, null)
                                                });

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
		this.ds_Data = new d_hmc101_102();
		this.uf_Initialize();
	}
}