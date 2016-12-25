// *********************************************************************************
// 1. 程式描述：志工基本資料管理-照片上傳
// 2. 撰寫人員：QFLin
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
using System.Data.OleDb;

public partial class sys_d_d02_p_d0201_03 : p_hrBase
{
	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
	{
        this.IsQuery_SessionRemove = false;

		// 不驗證 Frame
		//this.IsCheckFrame = false;
		// 不顯示 Version
		//this.IsShowVersion = false;
		// 不顯示網頁 Title
		//this.IsShowTitle = false;

		// 如果是第一次執行此網頁，顯示空白資料
		//if (!this.IsPostBack)
		//{
		//	// 接收傳入值
		//	WITCrypto lo_Crypto = new WITCrypto();
		//	this.StoredKey = lo_Crypto.uf_Decrypt(this.Request["Arg"] != null ? this.Request["Arg"].Trim() : "");
		//	// 傳入值不正確
		//	if (this.StoredKey == "")
		//		this.uf_AddJavaScriptAJAX("window.returnValue = ''; window.close();");
		//}
		
		// 如果是第一次執行此網頁
		if (!this.IsPostBack)
		{
			// 接收傳入值
            if (this.Request["args"] != null)
            {
                this.StoredKey = this.Request["args"].Trim();
            }
			//else
			//{
			//    uf_Msg("請先選擇志工資料！");
			//    this.uf_AddJavaScript("uf_SelectFrame(2);");
			//}

            string ax = "";
            DbMethods.uf_ExecSQL(" SELECT hmd201_cname FROM hmd201  WHERE hmd201_vid = '" + this.StoredKey + "' ", ref ax );
            dwF_hmd201_vid.Text = ax + "(" +  this.StoredKey + ")";

			// 將頁面切換到此頁
			//this.uf_AddJavaScript("uf_SelectFrame(2);");
		}		
		
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 bt_Upload 《上傳附件》按鈕所做的處理
	/// </summary>
	protected void bt_Upload_Click(object sender, EventArgs e)
	{
		if (this.StoredKey == null)
		{
			uf_Msg("請先選擇志工資料！");
			return;
		}

		if (!dwF_filepath.HasFile)
		{
			uf_Msg("請先選擇上傳檔案！");
			return;
		}

		// ##### 宣告變數 #####
		string[] lsa_ext = dwF_filepath.FileName.ToUpper().Split('.');
		string ls_ext = (lsa_ext.Length > 1 ? lsa_ext[lsa_ext.Length - 1] : "");

		if (".EXE.MSI.BAT.COM.SYS.TIF.TIFF.".Contains("." + ls_ext + "."))
		{
			uf_Msg("不支援此上傳檔案類型！");
			return;
		}

		OleDbConnection lcn_Conn = DbMethods.uf_GetConn();
        String ls_SqlCmd = "UPDATE hmd201 SET hmd201_photo = ?,hmd201_filetype='" + ls_ext + "', hmd201_uid = '" + LoginUser.ID + "', hmd201_udt = GetDate() WHERE hmd201_vid = '" + Session["md201vid"].ToString() + "'";
		OleDbCommand lcm_sql = new OleDbCommand(ls_SqlCmd, lcn_Conn);
		lcm_sql.Parameters.Add("@Image", OleDbType.Binary).Value = dwF_filepath.FileBytes;
		lcn_Conn.Open();
		try
		{
			lcm_sql.ExecuteNonQuery();
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("uf_LinkFrame('p_d0201_02.aspx', '02Frame', '" + Session["md201vid"].ToString() + "'); location='p_d0201_03.aspx?args=" + Session["md201vid"].ToString() + "'");
        }
		catch (SystemException e1)
		{
			this.uf_Msg("檔案上傳失敗！\\n" + e1.Message);
		}
		catch
		{
			this.uf_Msg("檔案上傳失敗！");
		}
		lcn_Conn.Close();
		lcn_Conn.Dispose();

    }
}
