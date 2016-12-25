// *********************************************************************************
// 1. 程式描述：ActionLog資料元件–無傳入值
// 2. 撰寫人員：
// *********************************************************************************
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

/// <summary>
/// ActionLog資料元件–無傳入值
/// </summary>
public class ndb_ActionLog : WIT.Template.Project.n_dbbase
{
    private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
    private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
    private System.Data.OleDb.OleDbCommand oleDbSelectCommand;
    private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
    private System.Data.OleDb.OleDbDataAdapter da_SQL_current;

    public ndb_ActionLog(System.ComponentModel.IContainer container)
    {
        container.Add(this);
        InitializeComponent();
        // 將資料配接器設為 current
        da_SQL = da_SQL_current;
    }

    public ndb_ActionLog()
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
        this.da_SQL_current = new System.Data.OleDb.OleDbDataAdapter();
        this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbSelectCommand = new System.Data.OleDb.OleDbCommand();
        this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
        ((System.ComponentModel.ISupportInitialize)(this.ds_Data)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dv_View)).BeginInit();
        // 
        // cn_DB
        // 
        //this.cn_DB.ConnectionString = "Provider=SQLNCLI.1;Data Source=10.100.1.62;User ID=sa;Initial Catalog=NMMST_SA";
        // 
        // da_SQL_current
        // 
        this.da_SQL_current.DeleteCommand = this.oleDbDeleteCommand;
        this.da_SQL_current.InsertCommand = this.oleDbInsertCommand;
        this.da_SQL_current.SelectCommand = this.oleDbSelectCommand;
        this.da_SQL_current.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ActionLog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("A_Id", "A_Id"),
                        new System.Data.Common.DataColumnMapping("DeptName", "DeptName"),
                        new System.Data.Common.DataColumnMapping("UID", "UID"),
                        new System.Data.Common.DataColumnMapping("UName", "UName"),
                        new System.Data.Common.DataColumnMapping("PRG_ID", "PRG_ID"),
                        new System.Data.Common.DataColumnMapping("ACTION", "ACTION"),
                        new System.Data.Common.DataColumnMapping("PRG_DESC", "PRG_DESC"),
                        new System.Data.Common.DataColumnMapping("Keys", "Keys"),
                        new System.Data.Common.DataColumnMapping("LDate", "LDate"),
                        new System.Data.Common.DataColumnMapping("LIP", "LIP")})});
        this.da_SQL_current.UpdateCommand = this.oleDbUpdateCommand;
        // 
        // oleDbDeleteCommand
        // 
        this.oleDbDeleteCommand.CommandText = "DELETE FROM [ActionLog] WHERE (([A_Id] = ?))";
        this.oleDbDeleteCommand.Connection = this.cn_DB;
        this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_A_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "A_Id", System.Data.DataRowVersion.Original, null)});
        // 
        // oleDbInsertCommand
        // 
        this.oleDbInsertCommand.CommandText = "INSERT INTO [ActionLog] ([DeptName], [UID], [UName], [PRG_ID], [ACTION], [PRG_DES" +
            "C], [Keys], [LDate], [LIP]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
        this.oleDbInsertCommand.Connection = this.cn_DB;
        this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("DeptName", System.Data.OleDb.OleDbType.VarWChar, 0, "DeptName"),
            new System.Data.OleDb.OleDbParameter("UID", System.Data.OleDb.OleDbType.VarWChar, 0, "UID"),
            new System.Data.OleDb.OleDbParameter("UName", System.Data.OleDb.OleDbType.VarWChar, 0, "UName"),
            new System.Data.OleDb.OleDbParameter("PRG_ID", System.Data.OleDb.OleDbType.VarChar, 0, "PRG_ID"),
            new System.Data.OleDb.OleDbParameter("ACTION", System.Data.OleDb.OleDbType.Char, 0, "ACTION"),
            new System.Data.OleDb.OleDbParameter("PRG_DESC", System.Data.OleDb.OleDbType.VarChar, 0, "PRG_DESC"),
            new System.Data.OleDb.OleDbParameter("Keys", System.Data.OleDb.OleDbType.VarChar, 0, "Keys"),
            new System.Data.OleDb.OleDbParameter("LDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LDate"),
            new System.Data.OleDb.OleDbParameter("LIP", System.Data.OleDb.OleDbType.VarChar, 0, "LIP")});
        // 
        // oleDbSelectCommand
        // 
        this.oleDbSelectCommand.CommandText = "SELECT * FROM [ActionLog] WHERE (1=1) ";
        this.oleDbSelectCommand.Connection = this.cn_DB;
        // 
        // oleDbUpdateCommand
        // 
        this.oleDbUpdateCommand.CommandText = "UPDATE [ActionLog] SET [DeptName] = ?, [UID] = ?, [UName] = ?, [PRG_ID] = ?, [ACT" +
            "ION] = ?, [PRG_DESC] = ?, [Keys] = ?, [LDate] = ?, [LIP] = ? WHERE (([A_Id] = ?)" +
            ")";
        this.oleDbUpdateCommand.Connection = this.cn_DB;
        this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("DeptName", System.Data.OleDb.OleDbType.VarWChar, 0, "DeptName"),
            new System.Data.OleDb.OleDbParameter("UID", System.Data.OleDb.OleDbType.VarWChar, 0, "UID"),
            new System.Data.OleDb.OleDbParameter("UName", System.Data.OleDb.OleDbType.VarWChar, 0, "UName"),
            new System.Data.OleDb.OleDbParameter("PRG_ID", System.Data.OleDb.OleDbType.VarChar, 0, "PRG_ID"),
            new System.Data.OleDb.OleDbParameter("ACTION", System.Data.OleDb.OleDbType.Char, 0, "ACTION"),
            new System.Data.OleDb.OleDbParameter("PRG_DESC", System.Data.OleDb.OleDbType.VarChar, 0, "PRG_DESC"),
            new System.Data.OleDb.OleDbParameter("Keys", System.Data.OleDb.OleDbType.VarChar, 0, "Keys"),
            new System.Data.OleDb.OleDbParameter("LDate", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LDate"),
            new System.Data.OleDb.OleDbParameter("LIP", System.Data.OleDb.OleDbType.VarChar, 0, "LIP"),
            new System.Data.OleDb.OleDbParameter("Original_A_Id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "A_Id", System.Data.DataRowVersion.Original, null)});
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
        this.ds_Data = new d_ActionLog();
        this.uf_Initialize();
    }
}
