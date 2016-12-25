// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排轉正式班表–編輯名單
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

public partial class sys_e_e01_p_e0102_02 : p_hrBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：demon

    /// <summary>變數描述：排班表需求資料元件</summary>
    protected ndb_hme101a_hme101b indb_hme101a_hme101b = new ndb_hme101a_hme101b();

    /// <summary>變數描述：志工資料元件</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();

    /// <summary>變數描述：班表志願資料元件</summary>
    protected ndb_hme101c indb_hme101c = new ndb_hme101c();

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

                indb_hme101a_hme101b.uf_Retrieve(" AND hme101b_pdid = '" + this.StoredKey + "' ");

                if (indb_hme101a_hme101b.uf_RowCount() > 0)
                {
                    dwF_hme101a_tid_c.Text = uf_Dg_Bind("hmd101", this.indb_hme101a_hme101b[0]["hme101a_tid"]);
                    dwF_hme101b_note.Text = this.indb_hme101a_hme101b[0]["hme101b_note"].ToString();
                    dwF_hme101b_time_c.Text = DateMethods.uf_YYYY_To_YYY(this.indb_hme101a_hme101b[0]["hme101b_sdate"], false).Substring(0, 3) + "年" + Convert.ToDateTime(this.indb_hme101a_hme101b[0]["hme101b_sdate"]).ToString("MM月dd日") + "  " + Convert.ToDateTime(this.indb_hme101a_hme101b[0]["hme101b_starttime"]).ToString("HH:mm") + " ~ " + Convert.ToDateTime(this.indb_hme101a_hme101b[0]["hme101b_endtime"]).ToString("HH:mm");
                    dwF_hme101b_addtext.Text = this.indb_hme101a_hme101b[0]["hme101b_addtext"].ToString();
                    dwF_hme101b_needno_c.Text = this.indb_hme101a_hme101b[0]["hme101b_needno"].ToString() + " 人";
                    ViewState["PosNo"] = this.indb_hme101a_hme101b[0]["hme101b_needno"].ToString();
                 
                    Bind_lb_all();
                }

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(3);");
            }
        }

        indb_hme101a_hme101b.uf_Retrieve(" AND hme101b_pdid = '" + this.StoredKey + "' ");

        if (indb_hme101a_hme101b.uf_RowCount() <= 0)
            uf_ShowBt(false);
        else
            uf_ShowBt(true);
    }

    protected void uf_ShowBt(bool ab_show)
    {
        bt_confirm.Enabled = ab_show;
        bt_toreset.Enabled = ab_show;
        bt_toright.Enabled = ab_show;
        bt_toleft.Enabled = ab_show;

        //判斷新增人數須小於編制人數
        if (ViewState["PosNo"] != null)
        {
            if (lb_go.Items.Count >= Convert.ToInt16(ViewState["PosNo"]))
                bt_toright.Enabled = false;
            else
                bt_toright.Enabled = true;
        }
    }

    protected void Bind_lb_all()
    {
        // ##### 宣告變數 #####
        string ls_show = "";
        int li_pc = 0, li_ts = 0, li_hour = 0;
        TimeSpan lts_period;

        lb_all.Items.Clear();
        lb_go.Items.Clear();

        if (indb_hme101a_hme101b.uf_RowCount() > 0)
        {
            lts_period = Convert.ToDateTime(this.indb_hme101a_hme101b[0]["hme101b_endtime"]) - Convert.ToDateTime(this.indb_hme101a_hme101b[0]["hme101b_starttime"]);
            li_hour = lts_period.Hours; //此需求班所需時數
            ViewState["THour"] = li_hour.ToString();

            //20130223 改由班表那先判斷，是否開放給其它小隊，顯示相對的人員資料。是：全部志工(不含服務狀態為離隊)；否：此班表小隊的所有志工(不含服務狀態為離隊)。
            string str_ifopen = "";
            DbMethods.uf_ExecSQL(" SELECT hme101a_openflag FROM hme101a inner join hme101b ON hme101a.hme101a_psid = hme101b.hme101b_psid where hme101b_pdid='" + this.StoredKey + "'", ref str_ifopen);
            //y表示開放給其它小隊
            if (str_ifopen == "Y")
            {
                indb_hmd201.uf_Retrieve(" AND hmd201_vid not in ( Select hme101c_vid From hme101c Where hme101c_pdid = '" + this.StoredKey + "' ) AND hmd201_status <> '2' ");
            }
            else
            {
                indb_hmd201.uf_Retrieve(" AND hmd201_vid not in ( Select hme101c_vid From hme101c Where hme101c_pdid = '" + this.StoredKey + "' ) AND hmd201_tid = '" + this.indb_hme101a_hme101b[0]["hme101a_tid"].ToString() + "' AND hmd201_status <> '2' ");

            }
            //indb_hmd201.uf_Retrieve(" AND hmd201_vid not in ( Select hme101c_vid From hme101c Where hme101c_pdid = '" + this.StoredKey + "' ) AND hmd201_tid = '" + this.indb_hme101a_hme101b[0]["hme101a_tid"].ToString() + "' ");
            //20130223停掉****indb_hmd201.uf_Retrieve(" AND hmd201_vid not in ( Select hme101c_vid From hme101c Where hme101c_pdid = '" + this.StoredKey + "' ) AND hmd201_status <> '2' ");
            if (indb_hmd201.uf_RowCount() > 0)
            {
                for (int li_row = 0; li_row < indb_hmd201.uf_RowCount(); li_row++)
                {
                    lb_all.Items.Add(new ListItem(uf_Dg_Bind("hmd201", indb_hmd201[li_row]["hmd201_vid"]) + " (" + e01Project.uf_pc_vid_all(indb_hmd201[li_row]["hmd201_vid"], indb_hme101a_hme101b[0]["hme101b_psid"]) + "班" + e01Project.uf_ts_vid_all(indb_hmd201[li_row]["hmd201_vid"], indb_hme101a_hme101b[0]["hme101b_psid"]) + "小時)", indb_hmd201[li_row]["hmd201_vid"].ToString().Trim()));
                }
            }

            //indb_hmd201.uf_Retrieve(" AND hmd201_vid in ( Select hme101c_vid From hme101c Where hme101c_pdid = '" + this.StoredKey + "' ) AND hmd201_tid = '" + this.indb_hme101a_hme101b[0]["hme101a_tid"].ToString() + "' ");
            indb_hmd201.uf_Retrieve(" AND hmd201_vid in ( Select hme101c_vid From hme101c Where hme101c_pdid = '" + this.StoredKey + "' ) ");
            if (indb_hmd201.uf_RowCount() > 0)
            {
                for (int li_row = 0; li_row < indb_hmd201.uf_RowCount(); li_row++)
                {
                    li_pc = Convert.ToInt32(e01Project.uf_pc_vid_all(indb_hmd201[li_row]["hmd201_vid"], indb_hme101a_hme101b[0]["hme101b_psid"], this.StoredKey)) + 1;
                    li_ts = Convert.ToInt32(e01Project.uf_ts_vid_all(indb_hmd201[li_row]["hmd201_vid"], indb_hme101a_hme101b[0]["hme101b_psid"], this.StoredKey)) + li_hour;
                    ls_show = uf_Dg_Bind("hmd201", indb_hmd201[li_row]["hmd201_vid"]) + " (" + li_pc.ToString() + "班" + li_ts.ToString() + "小時)";
                    lb_go.Items.Add(new ListItem(ls_show, indb_hmd201[li_row]["hmd201_vid"].ToString().Trim()));
                }
            }

			this.uf_SetLog_Function(this.StoredKey);
        }

        //判斷新增人數須小於編制人數
        if (ViewState["PosNo"] != null)
        {
            if (lb_go.Items.Count >= Convert.ToInt16(ViewState["PosNo"]))
               bt_toright.Enabled = false;
            else
               bt_toright.Enabled = true;
        }
    }

    protected void bt_toright_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        ListItem lli_Item;
        string ls_find = "", ls_show = "";
        int li_pc = 0, li_ts = 0;

        if (lb_all.SelectedIndex > -1)
        {
            ls_find = lb_all.SelectedValue;
            lli_Item = lb_all.Items.FindByValue(ls_find);
            int peopleno = 0;
            string str_hrneedno = "";

            //判斷此人是否還可以加入到班別裡
            DbMethods.uf_ExecSQL(" SELECT count(*) FROM hme101c inner join hme101b ON hme101c.hme101c_pdid = hme101b.hme101b_pdid where hme101c_vid='" + lli_Item.Value + "' and hme101b_psid='" + indb_hme101a_hme101b[0]["hme101b_psid"].ToString().Trim() + "'", ref peopleno);
            DbMethods.uf_ExecSQL(" SELECT isnull(hme101a_hrneedno,0) FROM hme101a inner join hme101b ON hme101a.hme101a_psid = hme101b.hme101b_psid where hme101b_pdid='" + this.StoredKey + "'", ref str_hrneedno);
  
            if (peopleno >= Convert.ToInt32(str_hrneedno))
            {

               // uf_Msg(int_classcount.ToString());
                uf_Msg("此人已達排班最高次數(" + str_hrneedno.Trim() + ")，不能再排班" );
            }else{
            if (lli_Item != null)
            {
               
              //  uf_Msg(peopleno.ToString());
                // 幾時幾班需重算
                li_pc = Convert.ToInt32(e01Project.uf_pc_vid_all(lli_Item.Value, indb_hme101a_hme101b[0]["hme101b_psid"], this.StoredKey)) + 1;
                li_ts = Convert.ToInt32(e01Project.uf_ts_vid_all(lli_Item.Value, indb_hme101a_hme101b[0]["hme101b_psid"], this.StoredKey)) + (ViewState["THour"] != null ? Convert.ToInt16(ViewState["THour"]) : Convert.ToInt16(0));
                ls_show = uf_Dg_Bind("hmd201", lli_Item.Value) + " (" + li_pc.ToString() + "班" + li_ts.ToString() + "小時)";

                lb_go.Items.Add(new ListItem(ls_show, lli_Item.Value));

                lb_all.Items.Remove(lli_Item);

				this.uf_SetLog_Function(this.StoredKey + "|" + lli_Item.Value);
            }

            //判斷新增人數須小於編制人數
            if (ViewState["PosNo"] != null)
            {
                if (lb_go.Items.Count >= Convert.ToInt16(ViewState["PosNo"]))
                {
                    bt_toright.Enabled = false;
                }
            }
            }
        }
        else
        {
            uf_Msg("請選擇欲挑選志工！");
            return;
        }
    }
    protected void bt_toleft_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        ListItem lli_Item;
        string ls_find = "", ls_show = "";
        int li_pc = 0, li_ts = 0;

        if (lb_go.SelectedIndex > -1)
        {
            ls_find = lb_go.SelectedValue;
            lli_Item = lb_go.Items.FindByValue(ls_find);
            if (lli_Item != null)
            {
                // 幾時幾班需重算
                li_pc = Convert.ToInt32(e01Project.uf_pc_vid_all(lli_Item.Value, indb_hme101a_hme101b[0]["hme101b_psid"], this.StoredKey));
                li_ts = Convert.ToInt32(e01Project.uf_ts_vid_all(lli_Item.Value, indb_hme101a_hme101b[0]["hme101b_psid"], this.StoredKey));
                ls_show = uf_Dg_Bind("hmd201", lli_Item.Value) + " (" + li_pc.ToString() + "班" + li_ts.ToString() + "小時)";

                lb_all.Items.Add(new ListItem(ls_show, lli_Item.Value));

                lb_go.Items.Remove(lli_Item);


				this.uf_SetLog_Function(this.StoredKey + "|" + lli_Item.Value);
            }

            //判斷新增人數須小於編制人數
            if (ViewState["PosNo"] != null)
            {
                if (lb_go.Items.Count < Convert.ToInt16(ViewState["PosNo"]))
                {
                    bt_toright.Enabled = true;
                }
            }
        }
        else
        {
            uf_Msg("請選擇欲挑選志工！");
            return;
        }

    }
    protected void bt_toreset_Click(object sender, EventArgs e)
    {
        Bind_lb_all();
    }
    protected void bt_confirm_Click(object sender, EventArgs e)
    {
        // ##### 宣告變數 #####
        DataRowView ldrv_Row;
		object[] lo_key = new object[1];
		lo_key[0] = this.StoredKey;
        indb_hme101c.uf_Retrieve(" AND hme101c_pdid = '" + indb_hme101a_hme101b[0]["hme101b_pdid"].ToString() + "' ");
        indb_hme101c.uf_Sort("hme101c_vid");
        // 1. 刪除被管理者刪除的資料
        foreach (ListItem lli_Item in lb_all.Items)
        {
            int li_find = -1;
            li_find = indb_hme101c.uf_FindSortIndex(lli_Item.Value);
            //若找到欲刪除的資料
            if ( li_find > -1 )
            {
                indb_hme101c.uf_DeleteRow(li_find);
            }
        }

        // 2. 新增原本不存在的資料
        foreach (ListItem lli_Item in lb_go.Items)
        {
            int li_find = -1;
            li_find = indb_hme101c.uf_FindSortIndex(lli_Item.Value);
            //若資料不存在
            if (li_find < 0)
            {
                this.indb_hme101c.uf_InsertRow(out ldrv_Row);

                ldrv_Row["hme101c_vid"] = lli_Item.Value;
                ldrv_Row["hme101c_pdid"] = this.StoredKey;
                ldrv_Row["hme101c_cway"] = "2";
                ldrv_Row["hme101c_aid"] = LoginUser.ID;
                ldrv_Row["hme101c_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hme101c_uid"] = LoginUser.ID;
                ldrv_Row["hme101c_udt"] = DbMethods.uf_GetDateTime();

                ldrv_Row.EndEdit();
            }
        }
		this.uf_SetLog_Function(this.StoredKey);
        // 儲存資料
        if (this.indb_hme101c.uf_Update() != 1)
        {
            this.indb_hme101c.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hme101c.ErrorMsg);
            return;
        }
        else
        {
            Bind_lb_all();
            // 重新取出查詢及清單資料
            this.uf_AddJavaScript("parent.frames[1].__doPostBack('','');  uf_LinkFrame('p_e0102_01.aspx', '01Frame', '" + indb_hme101a_hme101b[0]["hme101a_psid"].ToString().Trim() + "|" + indb_hme101a_hme101b[0]["hme101a_syear"].ToString().Trim() + "|" + indb_hme101a_hme101b[0]["hme101a_smonth"].ToString().Trim() + "|" + indb_hme101a_hme101b[0]["hme101a_tid"].ToString().Trim() + "|" + "'); ");
            this.uf_Msg("班表志願名單編輯完成！");
        }
    }

    //20150116獨贏科技先復原，因為功能還沒有解決辦法。
    //protected void bt_search_Click(object sender, EventArgs e)
    //{
    //    ListItem sitem;
    //    string name_find = "";
    //    name_find = c01Project.uf_Get_SystemNo("hmc101.hmc101_id", "");
    //    this.uf_Msg(name_find);
    //    //lb_all.Items.ClearSelected();
    //    //this.uf_Msg("班表志願名單編輯完成！");
    //    if (TextBox1.Text != "")
    //    {
    //        //this.uf_Msg("班表志願名單編輯完成！");
    //        for (int i = 0; i < lb_all.Items.Count; i++)
    //        {
    //            if (lb_all.Items[i].ToString().Contains(TextBox1.Text))
    //                //name_find = lb_all.SetSelected(i, true);
    //                //name_find = lb_all.SelectedValue;
    //                //name_find = TextBox1.Text;
    //                //sitem = lb_all.Items.FindByValue(name_find);
    //                //lb_all.SelectedItems.Add(lb_all.Items(i));
    //                //lb_all.SetSelected(i,true);
                    
    //            this.uf_Msg("班表志願名單編輯完成！");
    //        }
    //    }
    //}

	protected void uf_SetLog_Function(object ao_key)
	{
		string[] lsa_key = ao_key.ToString().Trim().Split('|');
		Log.uf_SetLogKeysValue(this.Page, lsa_key);
	}
}
