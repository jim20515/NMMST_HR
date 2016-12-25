
// *********************************************************************************
// 1. 程式描述：志工網管理–志工電子報管理
// 2. 撰寫人員：Linda
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

public partial class sys_h_h01_p_h0101_01 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

	/// <summary>變數描述：簡訊資料元件</summary>
    protected ndb_hlh101 indb_hlh101 = new ndb_hlh101();
    protected ndb_hlh102 indb_hlh102 = new ndb_hlh102();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	/// 
	protected void Page_Load(object sender, EventArgs e)
	{
        dwF_msg.Attributes["onBlur"] = "uf_ShowCount(" + dwF_msg.ClientID + ");";
        dwF_msg.Attributes["onKeyup"] = "uf_ShowCount(" + dwF_msg.ClientID + ");";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request.QueryString["args"] != null)
            {
				this.StoredKey = Session["Query"].ToString().Replace("|", "\r\n");
                dwF_list_hf.Value = this.StoredKey;
                dwF_list.Text = this.StoredKey;
                this.uf_AddJavaScript("uf_SelectFrame(4);");
            }
        }
	}

    protected void bt_Conf_Click(object sender, EventArgs e)
    {
        if (dwF_msg.Text.Trim() == "")
        {
            this.uf_Msg("請輸入欲傳送訊息！");
            return;
        }

        if (dwF_num.Text.Trim() == "" && dwF_list_hf.Value.Trim() == "")
        {
            this.uf_Msg("請輸入接收人員或接收門號！");
            return;
        }

        string ls_msg = "", ls_num = "", ls_sendmsg = dwF_msg.Text.Trim(), ls_list = dwF_list_hf.Value.Trim();
        int li_return = -1;
        li_return = h01Project.uf_SNS_Login(ref ls_msg);
        if (li_return != 0)
        {
            this.uf_Msg(ls_msg);
            return;
        }

        if (ls_list != "")
        {
            ls_num = uf_TranNum( ls_list );
            if (ls_list.Substring(ls_list.Length - 1) != ";")
                ls_num += ";";
        }

        if (dwF_num.Text.Trim() != "")
        {
            ls_num += uf_TranNum(dwF_num.Text.Trim());
        }

        string[] lsa_return = uf_SNS_MultiSubmit(ls_num, ls_sendmsg);
        string ls_show = "";

        for (int li_count = 0; li_count < lsa_return.Length; li_count++)
        {
            string[] lsa_show = lsa_return[li_count].Split('|');

            if (lsa_show.Length == 3)
            {
                if (lsa_show[1] != "0")
                    ls_show += "傳送" + lsa_show[0] + "失敗，原因為：" + lsa_show[2] + "\r\n";
            }
        }

        h01Project.uf_SNS_Logout(ref ls_msg);

        if (ls_show == "")
            ls_show = "訊息傳送中，可查詢簡訊發送狀態。";

        uf_Msg(ls_show);

        //li_return = h01Project.uf_SNS_QueryStatus(ls_num, ls_msgid, ref ls_msg);
        //Label5.Text += ls_msg;

        //li_return = h01Project.uf_SNS_GetMsg(ref ls_msg);
        //Label6.Text += ls_msg;

    }

    protected string[] uf_SNS_MultiSubmit(string as_num , string as_msg)
    {
        string ls_msg = "", ls_logid = "", ls_tolist = "";
        int li_return = -1 , li_year = DbMethods.uf_GetDate().Year - 1911;
        DataRowView ldrv_Row;

        string[] lsa_return , lsa_num;
        lsa_return = as_num.Split(';');
        lsa_num = as_num.Split(';');

        ls_logid = h01Project.uf_Get_SystemNo("hlh101.hlh101_logid", "M" + li_year.ToString("000"));

        for (int li_count = 0; li_count < lsa_num.Length; li_count++)
        {
            if (lsa_num[li_count] != "" && ls_tolist.IndexOf(lsa_num[li_count]) < 0 )
            {
                string ls_to = "", ls_cname = "";

                if (lsa_num[li_count].IndexOf("(") > -1) //志工清單
                {
                    ls_to = lsa_num[li_count].Substring(lsa_num[li_count].IndexOf("(") + 1 , lsa_num[li_count].IndexOf(")") - lsa_num[li_count].IndexOf("(") - 1);
                    ls_cname = lsa_num[li_count].Substring(0, lsa_num[li_count].IndexOf("("));
                    ls_tolist += lsa_num[li_count] + ";";
                }
                else
                {
                    ls_to = lsa_num[li_count];
                    ls_cname = "(手動加入)";
                    ls_tolist += lsa_num[li_count] + ";";
                }

                li_return = h01Project.uf_SNS_Submit(ls_to, as_msg, ref ls_msg);
                lsa_return[li_count] += "|" + li_return.ToString() + "|" + ls_msg;

                indb_hlh102.uf_InsertRow(out ldrv_Row);
                ldrv_Row["hlh102_logid"] = ls_logid;
                ldrv_Row["hlh102_to"] = ls_to;
                ldrv_Row["hlh102_cname"] = ls_cname;
                ldrv_Row["hlh102_msgid"] = (li_return == 0 ? ls_msg : "");
                ldrv_Row["hlh102_message"] = as_msg;
                ldrv_Row["hlh102_status"] = (li_return != 0 ? ls_msg : "");
                ldrv_Row["hlh102_aid"] = LoginUser.ID;
                ldrv_Row["hlh102_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hlh102_uid"] = LoginUser.ID;
                ldrv_Row["hlh102_udt"] = DbMethods.uf_GetDateTime();
                ldrv_Row.EndEdit();
            }
        }


        indb_hlh101.uf_InsertRow(out ldrv_Row);
        ldrv_Row["hlh101_logid"] = ls_logid;
        ldrv_Row["hlh101_tolist"] = ls_tolist;
        ldrv_Row["hlh101_message"] = as_msg;
        ldrv_Row["hlh101_aid"] = LoginUser.ID;
        ldrv_Row["hlh101_adt"] = DbMethods.uf_GetDateTime();
        ldrv_Row["hlh101_uid"] = LoginUser.ID;
        ldrv_Row["hlh101_udt"] = DbMethods.uf_GetDateTime();
        ldrv_Row.EndEdit();


        // 儲存資料
        if (indb_hlh101.uf_Update(indb_hlh102) != 1)
        {
            this.uf_Msg(indb_hlh101.ErrorMsg);
            indb_hlh101.dv_View.Table.RejectChanges();
        }

        return lsa_return;        
    }

    protected string uf_TranNum(string as_num)
    {
        string ls_return;
        ls_return = as_num.Replace(',',';');
        ls_return = ls_return.Replace('|', ';');
        ls_return = ls_return.Replace("\r\n" , ";");
        return ls_return;
    }

    protected void bt_list_Click(object sender, EventArgs e)
    {
        this.uf_AddJavaScript("uf_OpenWindow('p_h0101_04.aspx?ReturnFormID=" + this.uf_GetFormID() + "&ReturnObjectID=" + dwF_list.ClientID + "&ObjectValue=" + dwF_list_hf.Value.Replace("\r\n", ";") + "&ReturnObjectID1=" + dwF_list_hf.ClientID + "', '', 640, 450, 'no', 'no')");
        //bt_list.Attributes["OnClick"] = "uf_OpenWindow('p_h0101_04.aspx?ReturnFormID=" + this.uf_GetFormID() + "&ReturnObjectID=" + dwF_list.ClientID + "', '', 640, 420, 'no', 'no')";
    }

    // =========================================================================
    // 事件
    // =========================================================================
    /// <summary>
    /// 事件描述：Html 送出前所要做的動作
    /// </summary>
    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        dwF_list.Text = dwF_list_hf.Value;
    }
}
