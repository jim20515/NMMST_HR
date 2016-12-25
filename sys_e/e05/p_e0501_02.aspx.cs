// *********************************************************************************
// 1. 程式描述：服務勤務管理–服勤表現管理–成績附註登錄
// 2. 撰寫人員：demon
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

public partial class sys_e_e05_p_e0501_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：排班主檔資料元件</summary>
    protected ndb_hle501 indb_hle501 = new ndb_hle501();

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
            if (this.Request["args"] != null) //0:hle501_tid 1:hle501_syear 2:hle501_sseason
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];
                ViewState["hle501_syear_c"] = lsa_Arguments[1];
                ViewState["hle501_syear"] = Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"]) + 1911);
                ViewState["hle501_sseason"] = lsa_Arguments[2];

				if (ViewState["hle501_sseason"].ToString() == "4")
					dwS_show.Text = "★ " + ViewState["hle501_syear_c"].ToString() + "年度" + uf_Dg_Bind("hmd101", this.StoredKey) + " 全年度服務表現登錄";
				else
					dwS_show.Text = "★ " + ViewState["hle501_syear_c"].ToString() + "年度" + uf_Dg_Bind("hmd101", this.StoredKey) + " 第" + ViewState["hle501_sseason"].ToString() + "季服務表現登錄";

                this.dgG_Retrieve = " AND hle501_tid = '" + this.StoredKey + "' AND hle501_syear = '" + ViewState["hle501_syear"].ToString() + "' ";

				DateTime dtS, dtE;

				dtS = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/01/01 00:00:00");
				dtE = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/12/31 23:59:59");

				switch (ViewState["hle501_sseason"].ToString())
				{
					case "1":
						dtS = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/01/01 00:00:00");
						dtE = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/03/31 23:59:59");
						break;

					case "2":
						dtS = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/04/01 00:00:00");
						dtE = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/06/30 23:59:59");
						break;

					case "3":
						dtS = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/07/01 00:00:00");
						dtE = Convert.ToDateTime("" + Convert.ToString(Convert.ToInt16(ViewState["hle501_syear_c"].ToString()) + 1911) + "/09/30 23:59:59");
						break;
					default:
						break;
				}

				ViewState["dtS"] = dtS.ToString("yyyy/MM/dd HH:mm:ss");
				ViewState["dtE"] = dtE.ToString("yyyy/MM/dd HH:mm:ss");

                if (this.StoredKey != "")
                    dgG_Bind();

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }
        }
	}

    protected void dgG_Bind()
    {
		int li_season = Convert.ToInt16(ViewState["hle501_sseason"].ToString()) * 2;
		for (int i = 0; i < li_season; i++)
		{
			dgG.Columns[i + 4].Visible = true;

		}
        // ##### 宣告變數 #####
        string ls_datastring = "";
        DataSet lds_data;
        DataView dv_data;

		ls_datastring = " Select hle501_vid , hle501_tid , hle501_syear , IsNull(hle501_score1,0) as hle501_score1, IsNull(hle501_tscore1,0) as hle501_tscore1 , IsNull(hle501_score2,0) as hle501_score2, IsNull(hle501_tscore2,0) as hle501_tscore2 , IsNull(hle501_score3,0) as hle501_score3 , IsNull(hle501_tscore3,0) as hle501_tscore3, hle501_score4 , hle501_tscore4, hle501_ps from hle501 Where hle501_tid = '" + this.StoredKey + "' AND hle501_syear = '" + ViewState["hle501_syear"].ToString() + "' AND ( ( hle501_score" + ViewState["hle501_sseason"].ToString() + " is not null ) OR ( hle501_vid in ( Select hmd201_vid From hmd201 Where hmd201_Status <> '2' AND hmd201_tid = '" + this.StoredKey + "'  ) ) ) " +
                        " Union " +
						" Select hmd201_vid , hmd201_tid , '" + ViewState["hle501_syear"].ToString() + "' , 0 , 0, 0, 0 , 0 , 0, 0, 0 ,null from hmd201 Where hmd201_Status <> '2' AND hmd201_tid = '" + this.StoredKey + "' AND hmd201_vid NOT IN ( Select hle501_vid  from hle501 Where hle501_tid = '" + this.StoredKey + "' AND hle501_syear = '" + ViewState["hle501_syear"].ToString() + "' ) ";


        // 利用 SQL 語法產生資料集
        DbMethods.uf_Retrieve_FromSQL(out lds_data, ls_datastring);
        dv_data = lds_data.Tables[0].DefaultView;
        dgG.DataSource = dv_data;
        dgG.DataBind();
    }

    protected bool uf_get_RO(object ao_col)
    {
        bool lb_return = true;
        if (ao_col != null && ao_col.ToString() != "")
        {
            if (ViewState["hle501_sseason"].ToString() == ao_col.ToString())
                lb_return = false;
        }
        return lb_return;
    }

    protected BorderStyle uf_get_BS(object ao_col)
    {
        BorderStyle lbs_return = BorderStyle.None;
        if (ao_col != null && ao_col.ToString() != "")
        {
            if (ViewState["hle501_sseason"].ToString() == ao_col.ToString())
                lbs_return = BorderStyle.NotSet;
        }
        return lbs_return;
    }

	protected bool uf_get_EN(object ao_col)
	{
		bool lb_return = false;
		if (ao_col != null && ao_col.ToString() != "")
		{
			if (ViewState["hle501_sseason"].ToString() == ao_col.ToString())
				lb_return = true;
		}
		return lb_return;
	}

    protected void bt_Conf_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        DataRowView ldrv_Row;

        indb_hle501.uf_Retrieve(dgG_Retrieve);
        indb_hle501.uf_Sort("hle501_vid");
        int li_find = -1, li_seq = 0;
        string ls_vid = "", ls_plid = "", ls_plid_i = "";

        ls_plid = e01Project.uf_Get_SystemNo("hle501.hle501_plid", "R" + ViewState["hle501_syear_c"].ToString() );
        li_seq = Convert.ToInt16(ls_plid.Substring(4));

        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            ls_vid = dgG.Items[li_row].Cells[1].Text.Trim();

			//if (((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).Text.Trim() == "")
			//{
			//    //若四個欄位皆為空值 則刪除
			//    if (((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score1_c")).Text.Trim() == "" && ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score2_c")).Text.Trim() == "" && ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score3_c")).Text.Trim() == "" && ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score4_c")).Text.Trim() == "")
			//    {
			//        li_find = indb_hle501.uf_FindSortIndex(ls_vid);
			//        //若找到欲刪除的資料
			//        if (li_find > -1)
			//        {
			//            indb_hle501.uf_DeleteRow(li_find);
			//        }
			//    }
			//}
			//else
			//{
                li_find = indb_hle501.uf_FindSortIndex(ls_vid);
                //indb_hle501.uf_Filter(" hle501_vid = '" + dgG.Items[li_row].Cells[1].Text.Trim() + "' ");
                if (li_find < 0)
                {
                    this.indb_hle501.uf_InsertRow(out ldrv_Row);

                    ls_plid_i = ls_plid.Substring(0, 4) + li_seq.ToString("000000");

                    ldrv_Row["hle501_plid"] = ls_plid_i;
                    ldrv_Row["hle501_vid"] = ls_vid;
                    ldrv_Row["hle501_tid"] = this.StoredKey;
                    ldrv_Row["hle501_syear"] = ViewState["hle501_syear"].ToString();
					if (ViewState["hle501_sseason"].ToString() == "4")
					{
						ldrv_Row["hle501_score" + ViewState["hle501_sseason"].ToString()] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).Text.Trim();
						ldrv_Row["hle501_tscore" + ViewState["hle501_sseason"].ToString()] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).Text.Trim();
					}
					else
					{
						ldrv_Row["hle501_score" + ViewState["hle501_sseason"].ToString()] = ((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue;
						ldrv_Row["hle501_tscore" + ViewState["hle501_sseason"].ToString()] = ((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue;
					}
					ldrv_Row["hle501_ps"] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_ps_c")).Text.Trim();
                    ldrv_Row["hle501_aid"] = LoginUser.ID;
                    ldrv_Row["hle501_adt"] = DbMethods.uf_GetDateTime();
                    ldrv_Row["hle501_uid"] = LoginUser.ID;
                    ldrv_Row["hle501_udt"] = DbMethods.uf_GetDateTime();

                    ldrv_Row.EndEdit();
                    li_seq++;
                }
                else
                {
					if (ViewState["hle501_sseason"].ToString() == "4")
					{
						indb_hle501[li_find]["hle501_score" + ViewState["hle501_sseason"].ToString()] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).Text.Trim();
						indb_hle501[li_find]["hle501_tscore" + ViewState["hle501_sseason"].ToString()] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).Text.Trim();
					}
					else
					{
						indb_hle501[li_find]["hle501_score" + ViewState["hle501_sseason"].ToString()] = ((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue;
						indb_hle501[li_find]["hle501_tscore" + ViewState["hle501_sseason"].ToString()] = ((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue;
					}
					indb_hle501[li_find]["hle501_ps"] = ((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_ps_c")).Text.Trim();
                    indb_hle501[li_find]["hle501_uid"] = LoginUser.ID;
                    indb_hle501[li_find]["hle501_udt"] = DbMethods.uf_GetDateTime();

                }
			//}
        }

		uf_SetLog_Function(this.StoredKey + "|" + ViewState["hle501_syear"].ToString() + "|" + ViewState["hle501_sseason"].ToString());
        // 儲存資料 
        if (this.indb_hle501.uf_Update() != 1)
        {
            this.indb_hle501.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hle501.ErrorMsg);
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

	protected void Bt_Print_Click(object sender, EventArgs e)
	{
		this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_e0501&format=PDF&query=tid=" + this.StoredKey + ";season=" + ViewState["hle501_sseason"].ToString() + ";adt_s=" + ViewState["dtS"].ToString() + ";adt_e=" + ViewState["dtE"].ToString() + "','',1024,768,'no','no');");
	}

	protected void uf_SetLog_Function(object ao_key)
	{
		string[] lsa_key = ao_key.ToString().Trim().Split('|');
		Log.uf_SetLogKeysValue(this.Page, lsa_key);
	}

	protected void bt_Select_Click(object sender, EventArgs e)
	{
		if (ViewState["hle501_sseason"] != null)
		{
			string ls_selectvalue = lb_all.SelectedValue;

			for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
			{
				if (ls_selectvalue == "1")
				{
					if (ViewState["hle501_sseason"].ToString() != "4")
					{
						((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue = "100";
						((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue = "100";
					}
					else
					{
						((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).Text = "100";
						((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).Text = "100";
					}
				}
				else if (ls_selectvalue == "2")
				{
					if (ViewState["hle501_sseason"].ToString() != "4")
					{
						((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue = "100";
					}
					else
					{
						((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_score" + ViewState["hle501_sseason"].ToString() + "_c")).Text = "100";
					}
				}
				else
				{
					if (ViewState["hle501_sseason"].ToString() != "4")
					{
						((DropDownList)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).SelectedValue = "100";
					}
					else
					{
						((TextBox)dgG.Items[li_row].FindControl("dwG_hle501_tscore" + ViewState["hle501_sseason"].ToString() + "_c")).Text = "100";
					}
				}

			}
		}
		
	}
}
