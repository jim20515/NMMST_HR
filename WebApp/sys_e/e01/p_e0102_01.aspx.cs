// *********************************************************************************
// 1. 程式描述：服務勤務管理–排班管理–預排轉正式班表–指定班表
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

public partial class sys_e_e01_p_e0102_01 : p_hrBase
{
    #region ☆ Declare Variables -------------------------------------- 撰寫人員：Linda

    /// <summary>變數描述：排班表需求班次資料元件</summary>
    protected ndb_hme101b indb_hme101b_1 = new ndb_hme101b();
    protected ndb_hme101b indb_hme101b_2 = new ndb_hme101b();
    protected ndb_hme101b indb_hme101b_3 = new ndb_hme101b();

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
            if (this.Request["args"] != null) //0:hme101a_psid 1:hme101a_syear 2:hme101a_smonth 3:hme101a_tid
            {
                string[] lsa_Arguments = null;
                lsa_Arguments = this.Request["args"].Split('|');

                this.StoredKey = lsa_Arguments[0];
                ViewState["Year"] = lsa_Arguments[1];
                ViewState["Month"] = lsa_Arguments[2];
                ViewState["tid"] = lsa_Arguments[3];

                // 將頁面切換到此頁
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }
        }
        uf_BindDgG();
    }

    private void uf_BindDgG()
    {
        if (ViewState["Year"] != null && ViewState["Month"] != null && ViewState["tid"] != null)
        {
            dwG_ShowMsg.Text = "★ " + uf_Dg_Bind("hmd101", ViewState["tid"]) + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月排班班表設定作業";
            dwG_msg1.Text = "◎需求不足的排班班別：" + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月";
            dwG_msg2.Text = "◎需求過多的排班班別：" + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月";
            dwG_msg3.Text = "◎需求足夠的排班班別：" + ViewState["Year"].ToString() + "年" + ViewState["Month"].ToString() + "月";

            indb_hme101b_1.uf_Retrieve(" AND hme101b_psid = '" + this.StoredKey + "' AND hme101b_needno > ( SELECT COUNT(*) FROM hme101c WHERE hme101c.hme101c_pdid = hme101b.hme101b_pdid ) ");
            indb_hme101b_2.uf_Retrieve(" AND hme101b_psid = '" + this.StoredKey + "' AND hme101b_needno < ( SELECT COUNT(*) FROM hme101c WHERE hme101c.hme101c_pdid = hme101b.hme101b_pdid ) ");
            indb_hme101b_3.uf_Retrieve(" AND hme101b_psid = '" + this.StoredKey + "' AND hme101b_needno = ( SELECT COUNT(*) FROM hme101c WHERE hme101c.hme101c_pdid = hme101b.hme101b_pdid ) ");

            indb_hme101b_1.uf_Sort("hme101b_sdate desc , hme101b_starttime desc , hme101b_endtime desc");
            indb_hme101b_2.uf_Sort("hme101b_sdate desc , hme101b_starttime desc , hme101b_endtime desc");
            indb_hme101b_3.uf_Sort("hme101b_sdate desc , hme101b_starttime desc , hme101b_endtime desc");

            dgG1.DataBind();
            dgG2.DataBind();
            dgG3.DataBind();

            Bt_VRef.Enabled = true;
            bt_check.Enabled = true;
        }
        else
        {
            Bt_VRef.Enabled = false;
            bt_check.Enabled = false;
        }
    }

    protected void dgG1_SelectedIndexChanged(object sender, EventArgs e)
    {
		uf_SetLog_Function(dgG1.DataKeys[dgG1.SelectedIndex].ToString());
        this.uf_AddJavaScript("uf_LinkFrame('p_e0102_02.aspx', '02Frame', '" + dgG1.DataKeys[dgG1.SelectedIndex].ToString() + "'); ");
    }
    protected void dgG2_SelectedIndexChanged(object sender, EventArgs e)
    {
		uf_SetLog_Function(dgG2.DataKeys[dgG2.SelectedIndex].ToString());
        this.uf_AddJavaScript("uf_LinkFrame('p_e0102_02.aspx', '02Frame', '" + dgG2.DataKeys[dgG2.SelectedIndex].ToString() + "'); ");
    }
    protected void dgG3_SelectedIndexChanged(object sender, EventArgs e)
    {
		uf_SetLog_Function(dgG3.DataKeys[dgG3.SelectedIndex].ToString());
        this.uf_AddJavaScript("uf_LinkFrame('p_e0102_02.aspx', '02Frame', '" + dgG3.DataKeys[dgG3.SelectedIndex].ToString() + "'); ");
    }
    protected void dgG1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        // ##### 宣告變數 #####
        Label lb_TName = new Label();
        Label lb_Note = new Label();
        Label lb_Add = new Label();
        System.Text.Encoding l_Encoding = System.Text.Encoding.GetEncoding(950);	// 得到指定的編碼方式

        DataRowView drvODetail;
        drvODetail = (DataRowView)e.Item.DataItem;

        if (drvODetail != null)
        {
            //直接蓋掉cell的欄位值
            //已排姓名
            string ls_hme101b_pdid = "", ls_TName = "", ls_TName_Tool = "";

            //活動事由
            ls_TName_Tool = e.Item.Cells[4].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 25)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Note.Text = ls_TName;
            lb_Note.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Note.Attributes["onmouseout"] = "UnTip()";
            lb_Note.ToolTip = "";

            e.Item.Cells[4].Controls.Add(lb_Note);

            //報到地點
            ls_TName_Tool = e.Item.Cells[5].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Add.Text = ls_TName;
            lb_Add.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Add.Attributes["onmouseout"] = "UnTip()";
            lb_Add.ToolTip = "";

            e.Item.Cells[5].Controls.Add(lb_Add);

            //已排姓名
            ls_hme101b_pdid = e.Item.Cells[8].Text.Trim();
            ls_TName_Tool = e01Project.uf_pname_hme101c(ls_hme101b_pdid);
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_TName.Text = ls_TName;
            lb_TName.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_TName.Attributes["onmouseout"] = "UnTip()";
            lb_TName.ToolTip = "";

            e.Item.Cells[8].Controls.Add(lb_TName);
        }
    }
    protected void dgG2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        // ##### 宣告變數 #####
        Label lb_TName = new Label();
        Label lb_Note = new Label();
        Label lb_Add = new Label();
        System.Text.Encoding l_Encoding = System.Text.Encoding.GetEncoding(950);	// 得到指定的編碼方式

        DataRowView drvODetail;
        drvODetail = (DataRowView)e.Item.DataItem;

        if (drvODetail != null)
        {
            //直接蓋掉cell的欄位值
            //已排姓名
            string ls_hme101b_pdid = "", ls_TName = "", ls_TName_Tool = "";

            //活動事由
            ls_TName_Tool = e.Item.Cells[4].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 25)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Note.Text = ls_TName;
            lb_Note.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Note.Attributes["onmouseout"] = "UnTip()";
            lb_Note.ToolTip = "";

            e.Item.Cells[4].Controls.Add(lb_Note);

            //報到地點
            ls_TName_Tool = e.Item.Cells[5].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Add.Text = ls_TName;
            lb_Add.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Add.Attributes["onmouseout"] = "UnTip()";
            lb_Add.ToolTip = "";

            e.Item.Cells[5].Controls.Add(lb_Add);

            //已排姓名
            ls_hme101b_pdid = e.Item.Cells[8].Text.Trim();
            ls_TName_Tool = e01Project.uf_pname_hme101c(ls_hme101b_pdid);
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_TName.Text = ls_TName;
            lb_TName.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_TName.Attributes["onmouseout"] = "UnTip()";
            lb_TName.ToolTip = "";

            e.Item.Cells[8].Controls.Add(lb_TName);
        }
    }

    protected void dgG3_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        // ##### 宣告變數 #####
        Label lb_TName = new Label();
        Label lb_Note = new Label();
        Label lb_Add = new Label();
        System.Text.Encoding l_Encoding = System.Text.Encoding.GetEncoding(950);	// 得到指定的編碼方式

        DataRowView drvODetail;
        drvODetail = (DataRowView)e.Item.DataItem;

        if (drvODetail != null)
        {
            //直接蓋掉cell的欄位值
            //已排姓名
            string ls_hme101b_pdid = "", ls_TName = "", ls_TName_Tool = "";

            //活動事由
            ls_TName_Tool = e.Item.Cells[4].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 25)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Note.Text = ls_TName;
            lb_Note.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Note.Attributes["onmouseout"] = "UnTip()";
            lb_Note.ToolTip = "";

            e.Item.Cells[4].Controls.Add(lb_Note);

            //報到地點
            ls_TName_Tool = e.Item.Cells[5].Text.Trim();
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_Add.Text = ls_TName;
            lb_Add.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_Add.Attributes["onmouseout"] = "UnTip()";
            lb_Add.ToolTip = "";

            e.Item.Cells[5].Controls.Add(lb_Add);

            //已排姓名
            ls_hme101b_pdid = e.Item.Cells[8].Text.Trim();
            ls_TName_Tool = e01Project.uf_pname_hme101c(ls_hme101b_pdid);
            ls_TName = ls_TName_Tool;
            for (int li_i = 0; li_i < ls_TName_Tool.Length; li_i++)
            {
                if (l_Encoding.GetByteCount(ls_TName_Tool.Substring(0, li_i + 1)) > 20)
                {
                    ls_TName = ls_TName.Substring(0, li_i) + "...";
                    break;
                }
            }

            lb_TName.Text = ls_TName;
            lb_TName.Attributes["onmouseover"] = "uf_Tip(\'" + ls_TName_Tool.Replace("'", "\\'").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />") + "')";
            lb_TName.Attributes["onmouseout"] = "UnTip()";
            lb_TName.ToolTip = "";

            e.Item.Cells[8].Controls.Add(lb_TName);
        }
    }

    protected void Bt_VRef_Click(object sender, EventArgs e)
    {
		uf_SetLog_Function(this.StoredKey);
        this.uf_AddJavaScript("uf_LinkFrame('p_e0102_03.aspx', '03Frame', '" + this.StoredKey + "|" + ViewState["Year"].ToString() + "|" + ViewState["Month"].ToString() + "|" + ViewState["tid"].ToString() + "'); ");
    }

    protected void bt_check_Click(object sender, EventArgs e)
    {
		//if (indb_hme101b_1.uf_RowCount() == 0 && indb_hme101b_2.uf_RowCount() == 0 && indb_hme101b_3.uf_RowCount() > 0)
		//{
		//    string ls_sql = "";
		//    ls_sql = "select count(*) from hme101a a, hme101b b, hme101c c";
		//    ls_sql += " where hme101a_psid = hme101b_psid";
		//    ls_sql += " and hme101b_pdid = hme101c_pdid";
		//    ls_sql += " and hme101a_psid = '" + this.StoredKey + "'";
		//    ls_sql += " and hme101a_syear = '" + ViewState["Year"].ToString() + "'";
		//    ls_sql += " and hme101a_smonth = '" + ViewState["Month"].ToString() + "'";
		//    ls_sql += " and hme101c_vid in (SELECT hme101c_vid FROM hme101a w,hme101b x,hme101c y WHERE  a.hme101a_syear = w.hme101a_syear and a.hme101a_smonth = w.hme101a_smonth and w.hme101a_psid = x.hme101b_psid and x.hme101b_pdid = y.hme101c_pdid and b.hme101b_pdid <> x.hme101b_pdid AND c.hme101c_vid = y.hme101c_vid AND b.hme101b_sdate = x.hme101b_sdate AND ((b.hme101b_starttime >= x.hme101b_starttime AND b.hme101b_starttime < x.hme101b_endtime) OR (b.hme101b_endtime > x.hme101b_starttime AND b.hme101b_endtime <= x.hme101b_endtime) OR (b.hme101b_starttime = x.hme101b_starttime AND b.hme101b_endtime = x.hme101b_endtime) OR (b.hme101b_starttime <= x.hme101b_starttime AND b.hme101b_endtime >= x.hme101b_endtime)))";
		//    int li_count = 0;
		//    DbMethods.uf_ExecSQL(ls_sql, ref li_count);
		//    if (li_count > 0)
		//    {
		//        uf_Msg("該班表已有志工重覆時間排班！");
		//        return;
		//    }
			uf_SetLog_Function(this.StoredKey);

            DbMethods.uf_ExecSQL(" UPDATE hme101a SET hme101a_okflag = 'Y' , hme101a_makeflag = 'N' WHERE hme101a_psid = '" + this.StoredKey + "' ");
            uf_Msg("已確定為正式班表！");
		//}
		//else
		//{
		//    uf_Msg("請確認所有排班需求足夠！");
		//    return;
		//}
    }

	protected void uf_SetLog_Function(object ao_key)
	{
		object[] lo_key = new object[1];
		lo_key[0] = ao_key;
		Log.uf_SetLogKeysValue(this.Page, lo_key);
	}
}
