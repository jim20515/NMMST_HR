
// *********************************************************************************
// 1. 程式描述：系統公告管理–系統公告
// 2. 撰寫人員：
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;
using System.IO;
using System.Data.OleDb;

public partial class sys_c_c01_p_c0103_01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

    /// <summary>變數描述：檔案存放的根目錄</summary>
    private string is_root = System.Web.HttpRuntime.AppDomainAppPath;
    /// <summary>變數描述：檔案存放的子目錄</summary>
    private string is_dir = "App_Data\\File";

	/// <summary>變數描述：公告管理資料元件</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        Bt_Import.OnClientClick = "return uf_Upload();";
	}


    protected void bt_Download_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        string ls_key = "C0103_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
        string ls_fileName = "C0103_人力資源基本資料批次匯入格式.xls";
        string ls_file = this.is_root + this.is_dir + "\\Template\\" + ls_fileName;

        // 將檔案內容讀入 Application 中
        this.Application[ls_key] = File.ReadAllBytes(ls_file);
        this.Application["name:" + ls_key] = ls_fileName.Replace("C0103_", "");

        // 下載檔案
        this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/h_download_file.ashx?key=" + ls_key + "','',1024,768,'no','no');");
    }

    protected void Bt_Import_Click(object sender, EventArgs e)
    {
        if (!dwU_filepath.HasFile)
        {
            this.uf_Msg("請先選擇匯入檔案！");
            return;
        }
        if (!dwU_filepath.FileName.ToLower().EndsWith(".xls"))
        {
            this.uf_Msg("匯入檔案類型需為 Excel 97-2003 活頁簿 (*.xls)！");
            return;
        }

        // 上傳暫存檔案 ------------------------------------------------------ ☆

        // ##### 宣告變數 #####
        string ls_key = "C0103_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + "_" + LoginUser.ID;
        string ls_file = this.is_root + this.is_dir + "\\" + ls_key + ".xls";

        // 上傳檔案
        try
        {
            dwU_filepath.SaveAs(ls_file);
        }
        catch
        {
            this.uf_Msg("檔案上傳失敗！");
            return;
        }

        // 檔案內容處理 ------------------------------------------------------ ☆
        try
        {
            string ls_udt;
            this.uf_Run(ls_file, out ls_udt);

            // 顯示成功訊息
            this.uf_AddJavaScript("alert(\"檔案匯入成功，將取出匯入資料！\");\nuf_listFrame(\"" + ls_udt + "\");");
        }
        catch (SystemException e1)
        {
            this.uf_Msg("檔案匯入失敗！\\n" + e1.Message);
        }
        catch (Exception e2)
        {
            this.uf_Msg("檔案匯入失敗！\\n" + e2.Message);
        }
        finally
        {
            // 刪除檔案
            try { File.Delete(ls_file); }
            catch { }
        }
    }

    // =========================================================================
    /// <summary>
    /// 函式描述：將上傳檔案資料匯入資料庫
    /// </summary>
    /// <param name="as_file">檔案名稱路徑</param>
    /// <param name="as_udt">異動日期</param>
    private void uf_Run(string as_file, out string as_udt)
    {
        // ##### 宣告變數 #####
        string ls_connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + as_file + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        OleDbConnection lcn_Conn = new OleDbConnection(ls_connstr);
        DataSet lds_data = new DataSet();
        DataView ldv_data = null;
        int li_row;
        DataRowView ldrv_Row_insert;

        as_udt = "";

        try
        {
            lcn_Conn.Open();

            // 判斷版本資訊是否正確 -------------------------------------- ☆ (1)
            string ls_Select = "Select * From [版本資訊$] ";
            #region Retrieve Data
            OleDbDataAdapter lda_DataAdapter = new OleDbDataAdapter(ls_Select, lcn_Conn);
            lda_DataAdapter.Fill(lds_data);
            ldv_data = lds_data.Tables[0].DefaultView;
            #endregion

            if (ldv_data.Table.Columns.IndexOf("copyright") < 0
                || ldv_data.Table.Columns.IndexOf("titile") < 0
                || ldv_data.Table.Columns.IndexOf("version") < 0
                || ldv_data.Count < 1
                || ldv_data[0]["copyright"].ToString() != "WIT"
                || ldv_data[0]["titile"].ToString() != "C0103")
                throw new Exception("範本檔案錯誤（非使用指定之範本檔案，請由步驟一下載）");

            if (ldv_data[0]["version"].ToString() != "1.0")
                throw new Exception("範本檔案版本錯誤（非使用指定之版本檔案，請由步驟一下載）");


            // 判斷匯入資料是否正確 -------------------------------------- ☆ (2)
            ls_Select = "Select [正確] as flag, hmc101_cname,hmc101_gent,hmc101_bday,hmc101_SSN,hmc101_deptid, " +
                                 " hmc101_eduid,hmc101_jobid,hmc101_joborg,hmc101_jobtitle,hmc101_addid, " +
                                 " hmc101_addot,hmc101_email,hmc101_phnow,hmc101_phnowex,hmc101_phnoa,hmc101_phnom, " +
                                 " hmc101_memberid,hmc101_memberpwd,hmc101_passed,hmc101_rejectepaper,hmc101_ps,hmc101_notel,hmc101_expert " +
                            "From [人力資源批次匯入資料$] WHERE [正確] <> ''";
            #region Retrieve Data
            lda_DataAdapter.SelectCommand.CommandText = ls_Select;
            lds_data.Reset();
            lda_DataAdapter.Fill(lds_data);
            lda_DataAdapter.Dispose();
            ldv_data = lds_data.Tables[0].DefaultView;
            #endregion
            //dgG.DataSource = ldv_data;	// Debug 用
            //dgG.DataBind();

            if (ldv_data.Count <= 0)
                throw new Exception("匯入檔案中沒有可匯入的資料，請修正後再重新匯入！");

            ldv_data.RowFilter = "flag = 'X'";
            if (ldv_data.Count > 0)
                throw new Exception("匯入檔案中有不正確的資料，請修正後重新匯入！");
            ldv_data.RowFilter = "";

            // ##### 宣告變數 #####
            DateTime ldt_Today = DbMethods.uf_GetDateTime();
            as_udt = ldt_Today.ToString("yyyy/MM/dd HH:mm:ss");
            string ls_hmc101_id = "", ls_hmc101_id_i = "";
            int li_seq = 0;
            string[] lsa_hmc101;
            string ls_hmc101 = "hmc101_cname,hmc101_gent,hmc101_bday,hmc101_SSN,hmc101_deptid,hmc101_deptname,hmc101_eduid,hmc101_eduname,hmc101_jobid,hmc101_jobname,hmc101_joborg,hmc101_jobtitle,hmc101_addid,hmc101_addname,hmc101_addot,hmc101_email,hmc101_phnow,hmc101_phnowex,hmc101_phnoa,hmc101_phnom,hmc101_memberid,hmc101_memberpwd,hmc101_passed,hmc101_rejectepaper,hmc101_ps,hmc101_notel,hmc101_expert";
            lsa_hmc101 = ls_hmc101.Split(',');

            DbMethods.uf_ExecSQL("SELECT hmc101_id FROM hmc101 WHERE Left(hmc101_id,4) = '" + "F" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000") + "' Order by hmc101_id desc ", ref ls_hmc101_id);

            if (ls_hmc101_id == null || ls_hmc101_id == "")				// 表格中沒有資料
            {
                ls_hmc101_id = "F" + Convert.ToInt16(DbMethods.uf_GetDate().Year - 1911).ToString("000") + "-000001";
            }
            else
            {
                li_seq = Convert.ToInt16(ls_hmc101_id.Substring(5));
            }

            this.StoredKey = ls_hmc101_id;

            // 依序處理每一筆資料
            foreach (DataRowView ldrv_Row in ldv_data)
            {
                // 設定初始值
                li_seq++;
                ls_hmc101_id_i = ls_hmc101_id.Substring(0, 5) + li_seq.ToString("000000");

                indb_hmc101.uf_InsertRow(out ldrv_Row_insert);
                ldrv_Row_insert["hmc101_id"] = ls_hmc101_id_i;
                ldrv_Row_insert["hmc101_aid"] = LoginUser.ID;
                ldrv_Row_insert["hmc101_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row_insert["hmc101_uid"] = LoginUser.ID;
                ldrv_Row_insert["hmc101_udt"] = DbMethods.uf_GetDateTime();

                // 依序處理每一個欄位
                foreach (DataColumn ldc_Column in ldv_data.Table.Columns)
                {
                    if (ldc_Column.ColumnName == "flag") continue;

                    if (ldrv_Row[ldc_Column.ColumnName] == DBNull.Value)
                    {
                        //if (ls_hmc101.IndexOf(ldc_Column.ColumnName) < 0) //不存在於基本資料中，若使用者未填寫，則毋需setnull
                        //    dsT.SetItemNull(li_row, ldc_Column.ColumnName);
                    }
                    else
                    {
                        switch (ldc_Column.ColumnName)
                        {
                            default:				// String
                                ldrv_Row_insert[ldc_Column.ColumnName] = ldrv_Row[ldc_Column.ColumnName].ToString().Trim();
                                break;
                        }
                    }
                }
                ldrv_Row_insert.EndEdit();
            }

            // 儲存資料
            if (this.indb_hmc101.uf_Update() != 1)
            {
                this.indb_hmc101.dv_View.Table.RejectChanges();
                this.uf_Msg(this.indb_hmc101.ErrorMsg);
                return;
            }
            else
            {
                // 重新取出查詢及清單資料
                this.uf_AddJavaScript("uf_LinkFrame('p_c0103_02.aspx', '02Frame', '" + this.StoredKey + "'); ");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (ldv_data != null) ldv_data.Dispose();
            if (lds_data != null) lds_data.Dispose();
            if (lcn_Conn != null)
            {
                lcn_Conn.Close();
                lcn_Conn.Dispose();
            }
        }
    }
}
