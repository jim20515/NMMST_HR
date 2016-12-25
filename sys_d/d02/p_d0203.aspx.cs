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

public partial class sys_d_d02_p_d0203 : p_hrBase
{
    #region �� Declare Variables -------------------------------------- ���g�H���Gdemon

    /// <summary>�ܼƴy�z�G���i�޲z��Ƥ���</summary>
    protected ndb_hmd201 indb_hmd201 = new ndb_hmd201();
	protected ndb_hmd201_t indb_hmd201_t = new ndb_hmd201_t();
	protected ndb_hmc101_102 indb_hmc101_102 = new ndb_hmc101_102();
    private SIMCrypto io_Crypto = new SIMCrypto();

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

        this.Bt_SendMessage.Attributes["OnClick"] = "if (! confirm('�O�_�T�w��J�Ӥu��? ')) return false;";
        this.bt_delete.Attributes["OnClick"] = "if (! confirm('�O�_�T�w�R���w�Ŀ�Ӥu? ')) return false;";

        // �p�G�O�Ĥ@�����榹����
        if (!this.IsPostBack)
        {
            Dbcfg.uf_Bind(dwF_hmd201_tid, true);
            ViewState["query"] = "";
            uf_BindDgG();
        }
        else
        {
            ViewState["query"] = uf_getQuery();
        }

	}

    private void uf_BindDgG()
    {
        indb_hmd201_t.uf_Retrieve("");
        indb_hmd201_t.uf_Sort("hmd201_no");

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
        int li_find = -1, li_seq = 0, li_seq1 = 0;
        DataRowView ldrv_Row;
        string ls_SSN = "", ls_vid = "", ls_vid_i = "", ls_id = "", ls_id_i = "";

        indb_hmd201_t.uf_Retrieve("");
        indb_hmd201_t.uf_Sort("hmd201_no");

        indb_hmd201.uf_Retrieve("");

        string NY = "0000000000000000" + Convert.ToString((DateTime.Now.Year - 1911));
        NY = NY.Substring(NY.Length - 3, 3);

        string NM = "0000000000000000" + Convert.ToString((DateTime.Now.Month));
        NM = NM.Substring(NM.Length - 2, 2);

        string ND = "0000000000000000" + Convert.ToString((DateTime.Now.Day));
        ND = ND.Substring(ND.Length - 2, 2);

        // ���o�y�������t�νs���V��Ʈw�̤j��+1
        ls_vid = d02Project.uf_Get_SystemNo("hmd201.hmd201_vid", "V" + NY + "-");
        li_seq = Convert.ToInt16(ls_vid.Substring(5));

        ls_id = c01Project.uf_Get_SystemNo("hmc101.hmc101_id", "");
        li_seq1 = Convert.ToInt16(ls_id.Substring(5));

		object[] lo_key = new object[1];
		lo_key[0] = "";
        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

            ls_SSN = dgG.Items[li_row].Cells[2].Text.Trim();

            ls_vid_i = ls_vid.Substring(0, 5) + li_seq.ToString("00000");
            li_seq++;

            ls_id_i = ls_id.Substring(0, 5) + li_seq1.ToString("000000");
            li_seq1++;

            li_find = indb_hmd201_t.uf_FindSortIndex(dgG.DataKeys[li_row].ToString());

            if (li_find > -1)
            {
				if (lo_key[0].ToString().Trim() != "")
					lo_key[0] += "," + ls_vid_i;
				else
					lo_key[0] = ls_vid_i;
                this.indb_hmd201.uf_InsertRow(out ldrv_Row);
                ldrv_Row["hmd201_vid"] = ls_vid_i;
                ldrv_Row["hmd201_id"] = ls_id_i;
                ldrv_Row["hmd201_tid"] = dwF_hmd201_tid.SelectedValue;
                ldrv_Row["hmd201_cname"] = indb_hmd201_t[li_find]["hmd201_cname"];
				ldrv_Row["hmd201_ename"] = indb_hmd201_t[li_find]["hmd201_ename"];
                ldrv_Row["hmd201_gent"] = indb_hmd201_t[li_find]["hmd201_gent"];
                ldrv_Row["hmd201_bday"] = indb_hmd201_t[li_find]["hmd201_bday"];
                ldrv_Row["hmd201_SSN"] = indb_hmd201_t[li_find]["hmd201_SSN"];
                ldrv_Row["hmd201_eduid"] = indb_hmd201_t[li_find]["hmd201_eduid"];
                ldrv_Row["hmd201_jobid"] = indb_hmd201_t[li_find]["hmd201_jobid"];
                ldrv_Row["hmd201_joborg"] = indb_hmd201_t[li_find]["hmd201_joborg"];
                ldrv_Row["hmd201_jobtitle"] = indb_hmd201_t[li_find]["hmd201_jobtitle"];
                ldrv_Row["hmd201_addid"] = indb_hmd201_t[li_find]["hmd201_addid"];
                ldrv_Row["hmd201_addot"] = indb_hmd201_t[li_find]["hmd201_addot"];
                ldrv_Row["hmd201_email"] = indb_hmd201_t[li_find]["hmd201_email"];
                ldrv_Row["hmd201_phnow"] = indb_hmd201_t[li_find]["hmd201_phnow"];
                ldrv_Row["hmd201_phnowex"] = indb_hmd201_t[li_find]["hmd201_phnowex"];
                ldrv_Row["hmd201_phnoa"] = indb_hmd201_t[li_find]["hmd201_phnoa"];
                ldrv_Row["hmd201_phnom"] = indb_hmd201_t[li_find]["hmd201_phnom"];
				ldrv_Row["hmd201_marriage"] = indb_hmd201_t[li_find]["hmd201_marriage"];
				ldrv_Row["hmd201_children"] = indb_hmd201_t[li_find]["hmd201_children"];
                ldrv_Row["hmd201_rejectepaper"] = indb_hmd201_t[li_find]["hmd201_rejectepaper"];
                ldrv_Row["hmd201_ps"] = indb_hmd201_t[li_find]["hmd201_ps"];
                ldrv_Row["hmd201_notel"] = indb_hmd201_t[li_find]["hmd201_notel"];
                ldrv_Row["hmd201_expert"] = indb_hmd201_t[li_find]["hmd201_expert"];
                ldrv_Row["hmd201_ssntype"] = indb_hmd201_t[li_find]["hmd201_ssntype"];
                ldrv_Row["hmd201_bookid"] = indb_hmd201_t[li_find]["hmd201_bookid"];
                ldrv_Row["hmd201_weburl"] = indb_hmd201_t[li_find]["hmd201_weburl"];
                ldrv_Row["hmd201_introtext"] = indb_hmd201_t[li_find]["hmd201_introtext"];
				ldrv_Row["hmd201_serviceexp"] = indb_hmd201_t[li_find]["hmd201_serviceexp"];
                ldrv_Row["hmd201_lvid"] = "2";
                ldrv_Row["hmd201_status"] = "1";
                ldrv_Row["hmd201_workday"] = indb_hmd201_t[li_find]["hmd201_workday"];
                ldrv_Row["hmd201_creatway"] = "�Ӥu����J";
                ldrv_Row["hmd201_photo"] = indb_hmd201_t[li_find]["hmd201_photo"];
                ldrv_Row["hmd201_filetype"] = indb_hmd201_t[li_find]["hmd201_filetype"];
                ldrv_Row["hmd201_enCodeID"] = this.io_Crypto.uf_Encrypt(ls_vid_i.Replace("V", "").Replace("-", ""));
                ldrv_Row["hmd201_aid"] = LoginUser.ID;
                ldrv_Row["hmd201_adt"] = DbMethods.uf_GetDateTime();
                ldrv_Row["hmd201_uid"] = LoginUser.ID;
                ldrv_Row["hmd201_udt"] = DbMethods.uf_GetDateTime();

                ldrv_Row.EndEdit();

				indb_hmc101_102.uf_Retrieve(" AND hmc101_id = '" + ls_id_i + "' AND hmc102_id = 2");
				if (indb_hmc101_102.uf_RowCount() == 0)
				{
					DataRowView ldrv_Row2;
					this.indb_hmc101_102.uf_InsertRow(out ldrv_Row2);

					ldrv_Row2["hmc101_id"] = ls_id_i;
					ldrv_Row2["hmc102_id"] = 2;
					ldrv_Row2["hmc101_102_uid"] = LoginUser.ID;
					ldrv_Row2["hmc101_102_udt"] = DbMethods.uf_GetDateTime();

					ldrv_Row2.EndEdit();
				}
                //�R��
                //�Y�����R�������
                indb_hmd201_t.uf_DeleteRow(li_find);
            }
            else
            {
                uf_Msg("�פJ���`�A�Ь��t�κ޲z���I");
                this.indb_hmd201_t.dv_View.Table.RejectChanges();
                return;
            }
        }

		// add by rong 2010/10/19
		Log.uf_SetLogKeysValue(this.Page, lo_key);

        // �x�s���
		if (this.indb_hmd201_t.uf_Update(indb_hmd201, indb_hmc101_102) != 1)
        {
            this.indb_hmd201_t.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmd201_t.ErrorMsg);
            return;
        }
        else
        {
            uf_BindDgG();
            // ���s���X�d�ߤβM����
            this.uf_Msg("��ƶפJ�����I");
        }

    }
    protected void bt_delete_Click(object sender, EventArgs e)
    {
        int li_find = -1;

        indb_hmd201_t.uf_Retrieve("");
        indb_hmd201_t.uf_Sort("hmd201_no");

        for (int li_row = 0; li_row < dgG.Items.Count; li_row++)
        {
            if (!((CheckBox)dgG.Items[li_row].FindControl("dwg_check")).Checked) continue;

            li_find = indb_hmd201_t.uf_FindSortIndex(dgG.DataKeys[li_row].ToString());

            if (li_find > -1)
            {
                //�R��
                //�Y�����R�������
                indb_hmd201_t.uf_DeleteRow(li_find);
            }
            else
            {
                uf_Msg("�R����Ʋ��`�A�Ь��t�κ޲z���I");
                this.indb_hmd201_t.dv_View.Table.RejectChanges();
                return;
            }
        }

        // �x�s���
        if (this.indb_hmd201_t.uf_Update() != 1)
        {
            this.indb_hmd201_t.dv_View.Table.RejectChanges();
            this.uf_Msg(this.indb_hmd201_t.ErrorMsg);
            return;
        }
        else
        {
            uf_BindDgG();
            // ���s���X�d�ߤβM����
            this.uf_Msg("�R���Ӥu��Ƨ����I");
        }
    }

	protected void dwF_report2_Click(object sender, EventArgs e)
	{

		this.uf_AddJavaScript("uf_OpenWindow('" + this.Request.ApplicationPath + "/proj_uctrl/p_render.aspx?path=" + "/NMMST_HR_Report/rs_d0203&format=Excel','',1024,768,'no','no');");
	}
}
