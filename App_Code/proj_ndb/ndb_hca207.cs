// *********************************************************************************
// 1. �{���y�z�Ghca207��Ƥ���V�L�ǤJ��
// 2. ���g�H���Ggenerated by WITSTER  0.2.2 beta (by QFLin)
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// hca207��Ƥ���V�L�ǤJ��
/// </summary>
public class ndb_hca207 : WIT.Template.Project.n_dbbase
{
	private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
	private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
	private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
	private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
	private System.Data.OleDb.OleDbDataAdapter da_SQL_current;
	
	public ndb_hca207(System.ComponentModel.IContainer container)
	{
		container.Add(this);
		InitializeComponent();
		// �N��ưt�����]�� current
		da_SQL = da_SQL_current;
	}

	public ndb_hca207()
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
			
                                           new System.Data.Common.DataTableMapping("Table", "hca207", new System.Data.Common.DataColumnMapping[] {
                                           new System.Data.Common.DataColumnMapping("hca207_id", "hca207_id"),
                                           new System.Data.Common.DataColumnMapping("hca207_name", "hca207_name"),
                                           new System.Data.Common.DataColumnMapping("hca207_stop", "hca207_stop"),
                                           new System.Data.Common.DataColumnMapping("hca207_aid", "hca207_aid"),
                                           new System.Data.Common.DataColumnMapping("hca207_adt", "hca207_adt"),
                                           new System.Data.Common.DataColumnMapping("hca207_uid", "hca207_uid"),
                                           new System.Data.Common.DataColumnMapping("hca207_udt", "hca207_udt")
                                           })
            });
                                           
		// 
		// �R���R�O
		// 
		this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
		this.oleDbDeleteCommand.CommandText = "DELETE FROM [hca207] WHERE (([hca207_id] = ?)) ";
		this.oleDbDeleteCommand.Connection = this.cn_DB;
		this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("Original_hca207_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(1)), ((byte)(0)), "hca207_id", System.Data.DataRowVersion.Original, null)
		});


		// 
		// �s�W��
		// 
		this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
		this.oleDbInsertCommand.CommandText = "INSERT INTO [hca207] ([hca207_id],[hca207_name],[hca207_stop],[hca207_aid],[hca207_adt],[hca207_uid],[hca207_udt]) VALUES (?,?,?,?,?,?,?)";
		this.oleDbInsertCommand.Connection = this.cn_DB;
		this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca207_id", System.Data.OleDb.OleDbType.Char, 0, "hca207_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca207_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_stop", System.Data.OleDb.OleDbType.Char, 0, "hca207_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca207_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca207_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca207_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca207_udt")
		});


		// 
		// �d�߰�
		// 
		this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;				this.oleDbSelectCommand.CommandText = "SELECT * FROM [hca207] WHERE (1=1) ";		this.oleDbSelectCommand.Connection = this.cn_DB;

		// 
		// ��s��
		// 
		this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
		this.oleDbUpdateCommand.CommandText = "UPDATE [hca207] SET  [hca207_id] = ?, [hca207_name] = ?, [hca207_stop] = ?, [hca207_aid] = ?, [hca207_adt] = ?, [hca207_uid] = ?, [hca207_udt] = ?  WHERE (([hca207_id] = ?))";
		this.oleDbUpdateCommand.Connection = this.cn_DB;
		this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
		                                                           new System.Data.OleDb.OleDbParameter("hca207_id", System.Data.OleDb.OleDbType.Char, 0, "hca207_id"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_name", System.Data.OleDb.OleDbType.VarChar, 0, "hca207_name"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_stop", System.Data.OleDb.OleDbType.Char, 0, "hca207_stop"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_aid", System.Data.OleDb.OleDbType.VarChar, 0, "hca207_aid"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_adt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca207_adt"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_uid", System.Data.OleDb.OleDbType.VarChar, 0, "hca207_uid"),
                                                     new System.Data.OleDb.OleDbParameter("hca207_udt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "hca207_udt"),
                                                     new System.Data.OleDb.OleDbParameter("Original_hca207_id", System.Data.OleDb.OleDbType.Char, 0, System.Data.ParameterDirection.Input, false, ((byte)(1)), ((byte)(0)), "hca207_id", System.Data.DataRowVersion.Original, null)                                                });

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
		this.ds_Data = new d_hca207();
		this.uf_Initialize();
	}
}