// *********************************************************************************
// 1. 程式描述：訓練班成績單登錄
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

public partial class sys_f_f03_p_f0301_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：QFLin

    /// <summary>變數描述：排班主檔資料元件</summary>
    protected ndb_hmf302 indb_hmf302 = new ndb_hmf302();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        // 如果是第一次執行此網頁
        if (!this.IsPostBack)
        {
            // 接收傳入值
            if (this.Request["args"] != null) 
            {
                this.StoredKey = this.Request["args"].Trim();

                string CName = "";
                DbMethods.uf_ExecSQL("SELECT hmf101_name FROM hmf101 WHERE hmf101_courseid IN (SELECT top 1 hmf102_courseid FROM hmf102 WHERE hmf102_trainid = '" + this.StoredKey.Trim() + "' );", ref CName);

                dwS_show.Text = "★輸入訓練班【"+CName+"(" + this.StoredKey + ")】的成績單";

                if (this.StoredKey != "")
                    dgG_Bind();

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }
        }

	}

    protected void dgG_Bind()
    {
        // ##### 宣告變數 #####
        string ls_datastring = "";
        DataSet lds_data;
        DataView dv_data;

        ls_datastring = " Select * FROM hmf302 WHERE hmf302_trainid = '" + this.StoredKey + "'  ";
        dgG_Retrieve = " AND hmf302_trainid = '" + this.StoredKey + "'  ";

        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_datastring);
        dv_data = lds_data.Tables[0].DefaultView;
        lds_data.Tables[0].DefaultView.Sort = "hmf302_trainid , hmf302_vid";
        dgG.DataSource = dv_data;
        dgG.DataBind();
    }

    protected void bt_Conf_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####

        indb_hmf302.uf_Retrieve(dgG_Retrieve);
        indb_hmf302.uf_Sort("hmf302_trainid , hmf302_vid");
        int li_find = -1;
        string ls_vid = "", ls_sc = "", ls_pass = "";
        this.dgG_FindValue = new object[2];

        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {            
            ls_vid = dgG.Items[li_row].Cells[1].Text.Trim();

            dgG_FindValue[0] = this.StoredKey;
            dgG_FindValue[1] = ls_vid;

            li_find = indb_hmf302.uf_FindSortIndex(dgG_FindValue);
            //indb_hmf302.uf_Filter(" hmf302_vid = '" + dgG.Items[li_row].Cells[1].Text.Trim() + "' ");
            
            if (li_find > -1)
            {
                ls_sc = ((TextBox)dgG.Items[li_row].FindControl("dwG_hmf302_score")).Text.Trim();
                if (ls_sc != "")
                    indb_hmf302[li_find]["hmf302_score"] = Convert.ToInt32(ls_sc);
                else
                    indb_hmf302[li_find]["hmf302_score"] = DBNull.Value;
                ls_pass = ((CheckBox)dgG.Items[li_row].FindControl("dwG_hmf302_passed")).Checked == true ? "Y" : "N";
                indb_hmf302[li_find]["hmf302_passed"] = ls_pass;
                indb_hmf302[li_find]["hmf302_ps"] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hmf302_ps")).Text.Trim();
                indb_hmf302[li_find]["hmf302_uid"] = LoginUser.ID;
                indb_hmf302[li_find]["hmf302_udt"] = DbMethods.uf_GetDateTime();

            }
        }

		this.uf_SetLog_Function(this.StoredKey);

        // 儲存資料
        if (this.indb_hmf302.uf_Update() != 1)
        {
            this.indb_hmf302.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmf302.ErrorMsg);
            return;
        }
        else
        {
            dgG_Bind();
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); ");
            this.uf_Msg("分數編輯完成！");
        }
    }

	protected bool uf_get_visible(object ao_vid)
	{
		string ls_return = "";
		DbMethods.uf_ExecSQL("SELECT hmd201_lvid FROM hmd201 WHERE hmd201_vid = '" + ao_vid.ToString().Trim() + "'", ref ls_return);
		if (ls_return.Trim() == "3")
			return true;
		else
			return false;
	}

	protected void uf_SetLog_Function(object ao_key)
	{
		string[] lsa_key = ao_key.ToString().Trim().Split('|');
		Log.uf_SetLogKeysValue(this.Page, lsa_key);
	}
}
