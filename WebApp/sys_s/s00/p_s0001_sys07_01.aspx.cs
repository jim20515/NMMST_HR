//// *********************************************************************************
//// 1. 程式描述：系統公告管理–最新公告 - 上傳附件
//// 2. 撰寫人員：demon
//// *********************************************************************************
//using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using WIT.Template.Project;
//using System.IO;
//using System.ComponentModel;
//using System.Drawing;
//using System.Web.SessionState;



//public partial class sys_s_s00_p_s0001_sys07_01 : p_sBase
//{
//	#region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

//	/// <summary>變數描述：公告附件資料元件</summary>
//	protected ndb_sys071 indb_sys071 = new ndb_sys071();

//	#endregion

//	// =========================================================================
//	/// <summary>
//	/// 事件描述：網頁開啟
//	/// </summary>
//	protected void Page_Load(object sender, EventArgs e)
//    {
//		this.IsAJAXScript = true;

//		// 初始化
//        this.uf_InitializeComponent(dwF, dgG, indb_sys071, null);
//        this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

//        // 如果是第一次執行此網頁
//        if (!this.IsPostBack)
//        {
//            // 取得傳遞過來的參數
//            if (this.Request["need_no"] != null)
//                this.StoredKey = this.Request["need_no"].Trim();
//        }

//        if (this.StoredKey != "")
//        {
//            this.dgG_Retrieve = " AND s071_s07_no = '" + this.StoredKey + "' ";
//            dwF_msg_t.Text = "您欲上傳附件的公告編號為：" + this.StoredKey;
//        }
//    }

//    // =========================================================================
//    // 事件
//    // =========================================================================
//    /// <summary>
//    /// 事件描述：按下 bt_Upload 《上傳》按鈕所做的處理
//    /// </summary>
//    protected void bt_Upload_Click(object sender, EventArgs e)
//    {

//        //宣告檔案變數
//        System.Web.HttpPostedFile upfile;

//        try
//        {
//            //上傳檔案
//            upfile = dwF_s07_fname.PostedFile;

//            //判斷上傳檔案變數是否成功
//            if (upfile.ContentLength == 0)   //上傳檔案失敗
//            {
//                uf_Msg("上傳檔案失敗！請重新選擇檔案！");
//                return;
//            }
//        }
//        catch (System.Exception e1)
//        {
//            uf_Msg("上傳檔案失敗！請重新選擇檔案！\\n" + e1.Message);
//            return;
//        }

//        //
//        //			 拆解出上傳的檔名
//        string[] filesplit = upfile.FileName.Split('\\');
//        string ls_filename = filesplit[filesplit.Length - 1];
//        //
//        //			 @@-----將檔案存於指定的資料夾下（App_Data/sys07/公告編號/檔案）-----@@
//        //
//        //			 ##### 宣告變數 #####
//        string ls_directory = this.Request.PhysicalApplicationPath + "\\app_file\\sys07\\" + this.StoredKey;
//        //
//        //			 判斷目錄是否存在，不存在則產生
//        if (!System.IO.Directory.Exists(ls_directory))
//            System.IO.Directory.CreateDirectory(ls_directory);
//        //
//        //			 判斷檔案是否上傳過，不允許上傳
//        if (System.IO.File.Exists(ls_directory + "\\" + ls_filename))
//        {
//            this.uf_Msg("此檔案已上傳過，如要重新上傳請先刪除！");
//            return;
//        }
//        //			
//        //			 將匯入資料存進資料夾中
//        try
//        {
//            upfile.SaveAs(ls_directory + "\\" + ls_filename);
//            this.uf_Msg("檔案上傳完畢！");
//        }
//        catch
//        {
//            this.uf_Msg("無法將指定的檔案存於Web所指定的匯入資料夾中！");
//            return;
//        }
//        //
//        //			 ##### 宣告變數 #####
//        DataRowView ldrv_Row;

//        this.indb_sys071.uf_InsertRow(out ldrv_Row);
//        ldrv_Row["s071_sno"] = Convert.ToInt32(WIT.Template.Project.sys_s.sProject.uf_Get_SystemNo("sys071.s071_sno", ""));
//        ldrv_Row["s071_s07_no"] = this.StoredKey;
//        ldrv_Row["s071_fname"] = ls_filename;
//        ldrv_Row["s071_uid"] = LoginUser.ID;
//        ldrv_Row["s071_udt"] = DbMethods.uf_GetDateTime();
//        ldrv_Row.EndEdit();
//        //
//        //			 儲存資料
//        if (this.indb_sys071.uf_Update() == 1)
//        {
//            return;
//        }
//        else
//        {
//            this.uf_Msg(this.indb_sys071.ErrorMsg);
//            goto Exit_Fail;
//        }

//    Exit_Fail:
//        if (ldrv_Row.IsEdit)
//            ldrv_Row.CancelEdit();
//        else
//            ldrv_Row.Delete();
//        this.indb_sys071.dv_View.Table.RejectChanges();
//    }

//    // =========================================================================
//    // 事件
//    // =========================================================================
//    /// <summary>
//    /// 事件描述：刪除 dgG 某筆資料所做的處理
//    /// </summary>
//    protected void dgG_DeleteCommand(object source, DataGridCommandEventArgs e)
//    {
//        //			 ##### 宣告變數 #####
//        string ls_FileNo = dgG.DataKeys[e.Item.ItemIndex].ToString().Trim();
//        int li_row = this.indb_sys071.uf_FindSortIndex(Convert.ToInt32(ls_FileNo));
//        if (li_row < 0) return;
//        //
//        //			 取得檔案名稱
//        string ls_filename = this.Request.PhysicalApplicationPath + "\\app_file\\sys07\\" + this.StoredKey + "\\" + this.indb_sys071[li_row]["s071_fname"].ToString().Trim();

//        //			 如果有找到符合的資料則刪除
//        this.indb_sys071.uf_DeleteRow(li_row);

//        //			 儲存資料
//        if (this.indb_sys071.uf_Update() == 1)
//        {
//            File.Delete(ls_filename);
//            return;
//        }
//        else
//        {
//            this.uf_Msg(this.indb_sys071.ErrorMsg);
//            goto Exit_Fail;
//        }


//    Exit_Fail:
//        this.indb_sys071.dv_View.Table.RejectChanges();

//    }	// End of dgG_DeleteCommand

//    protected void bt_back_Click(object sender, EventArgs e)
//    {
//        Response.Redirect("p_s0001_sys07.aspx?need_no=" + this.StoredKey);
//    }// End of bt_back_Click
//}
