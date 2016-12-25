// *********************************************************************************
// 1. 程式描述：海科館 - 執班刷卡系統
// 2. 撰寫人員：fen
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
using System.Text;

public partial class Signin : p_BasePage
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：fen

	/// <summary>變數描述：加解密服務元件</summary>
	private SIMCrypto io_Crypto = new SIMCrypto();

    #endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁初始化
	/// </summary>
	protected void Page_Init(object sender, EventArgs e)
	{
		// 不驗證使用者
		this.IsCheckUser = false;
		// 不執行 KeyDown 事件
		this.IsOnKeyDown = false;
		// 不驗證 Frame
		this.IsCheckFrame = false;
		// 不顯示 Version
		this.IsShowVersion = false;
		// 不顯示網頁 Title
		this.IsShowTitle = false;
	}

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.IsAJAXScript = true;

        lb_realtime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        lb_ShowDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        lb_ShowTime.Text = DateTime.Now.ToString("HH:mm:ss");
        // 產生編碼條碼的語法
		//string ls_file = System.Web.HttpRuntime.AppDomainAppPath + "App_Data\\File\\list.txt";
		//for (int li_i = 50001; li_i <= 55000; li_i++)
		//    System.IO.File.AppendAllText(ls_file, li_i.ToString("00000000") + ":" + this.io_Crypto.uf_Encrypt(li_i.ToString("00000000")) + "\r\n");
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：輸入 tbx_SignIn 《刷上班卡》所做的處理
	/// </summary>
	protected void tbx_SignIn_TextChanged(object sender, EventArgs e)
	{
		this.uf_Sign(tbx_SignIn.Text, "1");
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：輸入 tbx_SignOut 《刷下班卡》所做的處理
	/// </summary>
	protected void tbx_SignOut_TextChanged(object sender, EventArgs e)
	{
		this.uf_Sign(tbx_SignOut.Text, "2");
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：輸入 tbx_SignOut 《刷下班卡》所做的處理
	/// </summary>
	/// <param name="as_EmpNo">加密之員工編號</param>
	/// <param name="as_Type">刷卡種類–上班(1)；下班(2)</param>
	private void uf_Sign(string as_EmpNo, string as_Type)
	{
        // ##### 宣告變數 #####
        ndb_signin_duty lndb_signin_duty = new ndb_signin_duty();
        StringBuilder lsb_html = new StringBuilder();
        string ls_errmsg;

        // 將加密之員工編號解密
        as_EmpNo = this.io_Crypto.uf_Decrypt(as_EmpNo);
        if (as_EmpNo != "")
        {
            try
            {
                // 呼叫 usp_XSignin 執行上下班刷卡的動作
                lndb_signin_duty.uf_Retrieve("", as_EmpNo, as_Type, this.Request.UserHostAddress);
                lndb_signin_duty.dv_View = lndb_signin_duty.ds_Data.Tables[0].DefaultView;

                // 判斷回傳值顯示刷卡訊息資料
                if (lndb_signin_duty.uf_RowCount() > 0)
                {
                    ls_errmsg = lndb_signin_duty[0]["errmsg"].ToString().Trim();

                    // 刷卡成功
                    if (ls_errmsg == "")
                    {
                        lsb_html.AppendFormat("<span>員工編號：{0}</span><br />", as_EmpNo);
                        lsb_html.AppendFormat("<span>員工姓名：{0}</span><br />", lndb_signin_duty[0]["empname"].ToString().Trim());
                        lsb_html.AppendFormat("<span>刷卡種類：{0}</span><br />", (as_Type == "1" ? "上班" : "下班"));
                        lsb_html.AppendFormat("<span>刷卡日期：{0}</span><br />", Convert.ToDateTime(lndb_signin_duty[0]["time"]).ToString("yyyy/MM/dd"));
                        lsb_html.AppendFormat("<span>刷卡時間：{0}</span><br />", Convert.ToDateTime(lndb_signin_duty[0]["time"]).ToString("HH:mm:ss"));
                    }
                }
                else
                    ls_errmsg = "無回傳訊息";
            }
            catch
            {
                ls_errmsg = "執行刷卡動作失敗";
            }
        }
        else
        {
            ls_errmsg = "非有效的員工條碼";
        }

        if (ls_errmsg == "")	// 刷卡成功
        {
            litr_ShowTitle.Text = "<span style=\"color: #A0A0FF\">【刷卡成功訊息】</span>";
            this.uf_AddJavaScript("uf_doSwitch(0);");
        }
        else					// 刷卡失敗
        {
            litr_ShowTitle.Text = "<span style=\"color: Red\">【刷卡失敗訊息】</span>";
            lsb_html.AppendFormat("<span>{0}</span><br />", ls_errmsg);
            this.uf_AddJavaScript("uf_doSwitch(0);");
            this.uf_Msg("刷卡失敗!!!");
            // 為了顯示 focus 需先呼叫 0
            //this.uf_AddJavaScript("uf_doSwitch(0); uf_doSwitch(" + as_Type + ");");
        }
        litr_ShowMsg.Text = lsb_html.ToString();
	}
}
