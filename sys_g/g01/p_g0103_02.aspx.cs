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

public partial class sys_g_g01_p_g0103_02 : p_hrBase
{
    #region �� Declare Variables -------------------------------------- ���g�H���Gdemon

    /// <summary>�ܼƴy�z�G���i�޲z��Ƥ���</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
    protected ndb_hmg101b indb_hmg101b = new ndb_hmg101b();
    protected ndb_hmg101a indb_hmg101a = new ndb_hmg101a();

    #endregion

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�G�����}��
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
        // ��l��
        //this.uf_InitializeQuery(null, this.indb_hmd201, null);
        //this.uf_InitializeComponent(null, dgG, this.indb_hmd201, null);
        //this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);

        this.Bt_SendMessage.Attributes["OnClick"] = "if (! confirm('�O�_�T�w�Ү�? ')) return false;";

        // �p�G�O�Ĥ@�����榹����
        if (!this.IsPostBack)
        {
            if (this.Request["args"] != null)
                this.StoredKey = this.Request["args"].Trim();

            ViewState["query"] = "";
            uf_BindDgG();

            // �N���������즹��
            this.uf_AddJavaScript("uf_SelectFrame(2);");
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }

	}

    private void uf_BindDgG()
    {
        indb_hmg101a.uf_Retrieve(" And hmg101a_kid = '"+ this.StoredKey +"' ");
        indb_hmg101b.uf_Retrieve(" And hmg101b_kid = '" + this.StoredKey + "' ");
        indb_hmg101b.uf_Sort("hmg101b_kid,hmg101b_vid");

        if (indb_hmg101b.uf_RowCount() > 0 && !this.IsPostBack)
        {
            string ls_query = "";
            for (int li_row = 0; li_row < indb_hmg101b.uf_RowCount(); li_row++)
            {
                if (indb_hmg101b[li_row]["hmg101b_passed"].ToString().Trim() == "Y")
                    ls_query += indb_hmg101b[li_row]["hmg101b_vid"].ToString() + "|";
            }
            ViewState["query"] = ls_query;
        }

        if (indb_hmg101a.uf_RowCount() > 0)
        {
            dwQ_hmd101_tid_t.Text = indb_hmg101a[0]["hmg101a_name"].ToString();

            indb_hmd201.uf_Retrieve(" AND hmd201_vid in ( Select hmg101b_vid From hmg101b Where hmg101b_kid = '"+ this.StoredKey +"' ) ");
            indb_hmd201.uf_Sort("hmd201_vid");
        }

        dgG.DataBind();

    }

    protected void lb_all_Click(object sender, EventArgs e)
    {
        ViewState["query"] = uf_getQueryAll();
        uf_BindDgG();
    }

    protected void lb_unall_Click(object sender, EventArgs e)
    {
        ViewState["query"] = "";
        uf_BindDgG();
    }

    protected bool uf_check(object ao_vid)
    { 
        bool lb_return = false;
        if (ao_vid.ToString() != "" && ViewState["query"].ToString().IndexOf(ao_vid.ToString()) > -1 )
            lb_return = true;
        return lb_return;
    }

    protected string uf_getQueryAll()
    {
        string ls_query = "";
        // �N DataGrid ��ܪ���Ʋզ��d�ߦr��
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            // ��X������ƩҦb��Ƥ�����ަ�m
            ls_query += dgG.Items[li_row].Cells[2].Text.Trim() + "|";
        }
        return ls_query;
    }

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

    protected void Bt_SendMessage_Click(object sender, EventArgs e)
    {
        if (this.StoredKey.Trim() == "")
        {
            uf_Msg("�п�ܱ��Үָ�ơI");
            return;
        }

        int li_find = -1;
        DataRowView ldrv_Row;
        string ls_vid = "";

        indb_hmg101b.uf_Retrieve(" And hmg101b_kid = '" + this.StoredKey + "' ");
        indb_hmg101b.uf_Sort("hmg101b_kid,hmg101b_vid");

        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            ls_vid = dgG.Items[li_row].Cells[2].Text.Trim();

            this.dgG_FindValue = new object[2];
            this.dgG_FindValue[0] = this.StoredKey;
            this.dgG_FindValue[1] = ls_vid;

            li_find = indb_hmg101b.uf_FindSortIndex(dgG_FindValue);

            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) //�Y�s�b�A�h�R��
            {
                if (li_find > -1)
                {
                    if (indb_hmg101b[li_row]["hmg101b_passed"].ToString() != "Y")
                    {
                        indb_hmg101b[li_row]["hmg101b_passed"] = "N";
                    }
                }
            }
            else
            {
                if (li_find > -1)
                {
                    indb_hmg101b[li_row]["hmg101b_passed"] = "Y";
                }
            }
        }

        // �x�s���
        if (this.indb_hmg101b.uf_Update() != 1)
        {
            this.indb_hmg101b.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmg101b.ErrorMsg);
            return;
        }
        else
        {
            uf_BindDgG();
            // ���s���X�d�ߤβM����
            this.uf_Msg("�Үֵ��G�s�觹���I");
        }

    }
    
}
