// *********************************************************************************
// 1. �{���y�z�G�A�ȶ԰Ⱥ޲z�V�԰Ȭ����޲z�V�d�ߤβM��
// 2. ���g�H���Gdemon
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

public partial class sys_b_b02_p_b0201_02 : p_hrBase
{
    #region �� Declare Variables -------------------------------------- ���g�H���Gdemon

    /// <summary>�ܼƴy�z�G���i�޲z��Ƥ���</summary>
    protected ndb_hmc101 indb_hmc101 = new ndb_hmc101();

    #endregion

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�G�����}��
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
        // ��l��
        //this.uf_InitializeQuery(null, this.indb_hmc101, null);
        //this.uf_InitializeComponent(null, dgG, this.indb_hmc101, null);
        //this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        // �p�G�O�Ĥ@�����榹����
        if (!this.IsPostBack)
        {
            // �����ǤJ��
            if (this.Request["args"] != null) //0:�ֿ���� 1:���O
            {
                this.StoredKey = Request["args"];

                // �N���������즹��
                this.uf_AddJavaScript("uf_SelectFrame(2);");
            }

            ViewState["query"] = "";
			uf_BindDgG();
        }
		//else
		//{
		//    ViewState["query"] = uf_getQuery();
		//}
	}

    private void uf_BindDgG()
    {
        string ls_addsql = "";

        if (this.StoredKey != "")
        {
            ls_addsql = "'" + this.StoredKey.Replace("|", "','");
            ls_addsql = ls_addsql.Substring(0, ls_addsql.Length - 2);

            ls_addsql = " AND hmc101_id in (" + ls_addsql + " ) ";
        }
        else
        {
            ls_addsql = " AND ( 1 = 2 ) ";
        }

        indb_hmc101.uf_Retrieve(ls_addsql);

        dgG.DataBind();

    }

	//protected void lb_all_Click(object sender, EventArgs e)
	//{
	//    ViewState["query"] = uf_getQueryAll();
	//}

	//protected void lb_unall_Click(object sender, EventArgs e)
	//{
	//    // �M���e���W�w�Ŀ諸���
	//    for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
	//    {
	//        ((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked = false;
	//    }
	//    ViewState["query"] = "";
	//}

	//protected bool uf_check(object ao_vid)
	//{ 
	//    bool lb_return = false;
	//    if (ao_vid.ToString() != "" && ViewState["query"].ToString().IndexOf(ao_vid.ToString()) > -1 )
	//        lb_return = true;
	//    return lb_return;
	//}

	//protected string uf_getQueryAll()
	//{
	//    string ls_query = "";
	//    // �N DataGrid ��ܪ���Ʋզ��d�ߦr��
	//    for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
	//    {
	//        ((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked = true;
	//        // ��X������ƩҦb��Ƥ�����ަ�m
	//        ls_query += dgG.Items[li_row].Cells[2].Text.Trim() + "|";
	//    }
	//    return ls_query;
	//}

    protected string uf_getQuery()
    {
        string ls_query = "";
        // �N DataGrid ��ܪ���Ʋզ��d�ߦr��
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

            // ��X������ƩҦb��Ƥ�����ަ�m
            ls_query += dgG.Items[li_row].Cells[2].Text.Trim() + "|";
        }
        return ls_query;
    }

    protected string uf_getQueryMess()
    {
        string ls_query = "";
        // �N DataGrid ��ܪ���Ʋզ��d�ߦr��
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;
            if (dgG.Items[li_row].Cells[8].Text.Trim() == "" || dgG.Items[li_row].Cells[8].Text.Trim() == "&nbsp;") continue;

            // ��X������ƩҦb��Ƥ�����ަ�m
            ls_query += dgG.Items[li_row].Cells[4].Text.Trim() + "(" + dgG.Items[li_row].Cells[8].Text.Trim() + ")" + "|";
        }
        return ls_query;
    }

    protected string uf_getQueryMail()
    {
        string ls_query = "";
        // �N DataGrid ��ܪ���Ʋզ��d�ߦr��
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;
            if (dgG.Items[li_row].Cells[7].Text.Trim() == "" || dgG.Items[li_row].Cells[7].Text.Trim() == "&nbsp;") continue;

            // ��X������ƩҦb��Ƥ�����ަ�m
            ls_query += dgG.Items[li_row].Cells[4].Text.Trim() + "(" + dgG.Items[li_row].Cells[7].Text.Trim() + ")" + "|";
        }
        return ls_query;
    }

    protected void Bt_SelectFormat_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQuery();
        if (ls_query == "")
        {
            this.uf_Msg("�п�ܱ��C�L�H���I");
            return;
        }

        this.uf_AddJavaScript("uf_LinkFrame('p_b0201_03.aspx', '03Frame', '" + ls_query + "' ); ");

    }
    protected void Bt_SendMessage_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQueryMess();
        if (ls_query == "")
        {
            this.uf_Msg("�ФĿ�w��g������X���H���I");
            return;
        }
		Session["Query"] = ls_query;
        this.uf_AddJavaScript("uf_LinkFrame('p_b0201_04.aspx', '04Frame', '" + ls_query + "' );");

    }
    protected void Bt_SendCard_Click(object sender, EventArgs e)
    {
        string ls_query = uf_getQueryMail();
        if (ls_query == "")
        {
            this.uf_Msg("�ФĿ�w��gE-Mail���H���I");
            return;
        }
		Session["Query"] = ls_query;
        this.uf_AddJavaScript("uf_LinkFrame('p_b0201_05.aspx', '05Frame', '" + ls_query + "' );");

    }
}
