// *********************************************************************************
// 1. �{���y�z�Ghmh201b��Ƥ���V�L�ǤJ��
// 2. ���g�H���Ggenerated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hmh201b��Ƥ���V�L�ǤJ��
/// </summary>
public class ndb_hmh201b : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hmh201b(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	public ndb_hmh201b()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hmh201b", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hmh201b_cid", "hmh201b_cid"),
                                           new System.Data.Common.DataColumnMapping("hmh201b_id", "hmh201b_id"),
                                           new System.Data.Common.DataColumnMapping("hmh201b_mail", "hmh201b_mail"),
                                           new System.Data.Common.DataColumnMapping("hmh201b_aid", "hmh201b_aid"),
                                           new System.Data.Common.DataColumnMapping("hmh201b_adt", "hmh201b_adt"),
                                           new System.Data.Common.DataColumnMapping("hmh201b_uid", "hmh201b_uid"),
                                           new System.Data.Common.DataColumnMapping("hmh201b_udt", "hmh201b_udt")
                                           })
            });
                                           
		// 
		// �R���R�O
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hmh201b] WHERE (([hmh201b_cid] = ?))  AND (([hmh201b_mail] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hmh201b_cid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(50)), ((byte)(0)), "hmh201b_cid", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmh201b_mail", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(255)), ((byte)(0)), "hmh201b_mail", System.Data.DataRowVersion.Original, null)

		});


		// 
		// �s�W��
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hmh201b] ([hmh201b_cid],[hmh201b_id],[hmh201b_mail],[hmh201b_aid],[hmh201b_adt],[hmh201b_uid],[hmh201b_udt]) VALUES (?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmh201b_cid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_cid"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_id", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_id"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_mail", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_mail"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh201b_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh201b_udt")
		});


		// 
		// �d�߰�
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hmh201b] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// ��s��
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hmh201b] SET  [hmh201b_cid] = ?, [hmh201b_id] = ?, [hmh201b_mail] = ?, [hmh201b_aid] = ?, [hmh201b_adt] = ?, [hmh201b_uid] = ?, [hmh201b_udt] = ?  WHERE (([hmh201b_cid] = ?)) AND (([hmh201b_mail] = ?)) ";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hmh201b_cid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_cid"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_id", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_id"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_mail", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_mail"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh201b_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hmh201b_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hmh201b_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hmh201b_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmh201b_cid", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(50)), ((byte)(0)), "hmh201b_cid", System.Data.DataRowVersion.Original, null),
                                                     new System.Data.OleDb.OleDbParameter("Original_hmh201b_mail", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(255)), ((byte)(0)), "hmh201b_mail", System.Data.DataRowVersion.Original, null)
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
		this.ds_Data = new d_hmh201b();
		this.uf_Initialize();
	}
}