
// *********************************************************************************
// 1. 程式描述：志工網管理–志工電子報管理
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

public partial class sys_h_h01_p_h0101_03 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：排班主檔資料元件</summary>
    protected ndb_hlh102 indb_hlh102 = new ndb_hlh102();
    protected ndb_hlh101 indb_hlh101 = new ndb_hlh101();

    #endregion

    // =========================================================================
    /// <summary>
    /// 事件描述：網頁開啟
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        // 初始化
        this.uf_InitializeComponent(null, dgG, this.indb_hlh102, null);
        this.dgG_Sort = "hlh102_udt desc , hlh102_uid";

        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            // 將頁面切換到此頁
            this.uf_AddJavaScript("uf_SelectFrame(3);");

        }

        uf_BinddwF();
        uf_dgGBind();

    }

    protected void uf_BinddwF()
    {
        string ls_retrieve = " AND hlh101_logid = '" + this.StoredKey + "' ";
        indb_hlh101.uf_Retrieve(ls_retrieve);

        if (indb_hlh101.uf_RowCount() > 0)
        {
            dwF_hlh101_uid.Text = uf_Dg_Bind("user01", indb_hlh101[0]["hlh101_uid"]);
            dwF_hlh101_udt.Text = DateMethods.uf_YYYY_To_YYY(indb_hlh101[0]["hlh101_udt"], true);
            dwF_hlh101_ToList.Text = indb_hlh101[0]["hlh101_ToList"].ToString().Trim();
            dwF_hlh101_Message.Text = indb_hlh101[0]["hlh101_Message"].ToString().Trim();
        }
    }

    protected void uf_dgGBind()
    {
        this.dgG_Retrieve = " AND hlh102_logid = '" + this.StoredKey + "' ";
        indb_hlh102.uf_Retrieve(dgG_Retrieve);

        string ls_msg = "";
        int li_return = -1;
        li_return = h01Project.uf_SNS_Login(ref ls_msg);
        if (li_return != 0)
        {
            this.uf_Msg(ls_msg);
            return;
        }

        for (int li_count = 0; li_count < indb_hlh102.uf_RowCount(); li_count++)
        {
            if (indb_hlh102[li_count]["hlh102_msgid"].ToString().Trim() != "")
            {
                if (indb_hlh102[li_count]["hlh102_status"].ToString().IndexOf("簡訊成功") > -1) continue;
                li_return = h01Project.uf_SNS_QueryStatus(indb_hlh102[li_count]["hlh102_to"].ToString().Trim(), indb_hlh102[li_count]["hlh102_msgid"].ToString().Trim(), ref ls_msg);
                indb_hlh102[li_count]["hlh102_status"] = ls_msg;
            }
        }

        indb_hlh102.uf_Update();

        h01Project.uf_SNS_Logout(ref ls_msg);

        this.dgG.DataBind();
    }
}
