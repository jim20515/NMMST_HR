// *********************************************************************************
// 1. �{���y�z�G�A�ȶ԰Ⱥ޲z�V�԰Ȭ����޲z�V����
// 2. ���g�H���Gdemon
// *********************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WIT.Template.Project;

public partial class sys_e_e02_p_e0201_02 : p_hrBase
{
	#region �� Declare Variables -------------------------------------- ���g�H���GWITSETER (by QFLin)

	/// <summary>�ܼƴy�z�G�H�����O��Ƥ���</summary>
	protected ndb_hle201 indb_hle201 = new ndb_hle201();

	#endregion

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�G�����}��
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
		// ��l��
		this.uf_InitializeQuery(null, this.indb_hle201, null);
		this.uf_InitializeComponent(dwF, null, this.indb_hle201, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		this.IsQuery_SessionRemove = false;

		// ���U����ƥ�
        this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataUpdate_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);
        this.ue_DataInsert_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataUpdate_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);
		this.ue_DataDelete_AfterSave += new DataHandler(this.u_Edit_F_AfterSave);

		// �p�G�O�Ĥ@�����榹����
		if (!this.IsPostBack)
		{
			// �����ǤJ��
			if (this.Request["args"] != null)
				this.StoredKey = this.Request["args"].Trim();

			// �N���������즹��
			this.uf_AddJavaScript("uf_SelectFrame(2);");
		}

        this.indb_hle201.dv_View.Table.Columns["hle201_sdatetime"].DefaultValue = DbMethods.uf_GetDateTime().ToString();
        this.indb_hle201.dv_View.Table.Columns["hle201_cancel"].DefaultValue = "N";
        this.indb_hle201.dv_View.Table.Columns["hle201_cway"].DefaultValue = "2";


		// �N�D��ȰO�����M���ƪ�����
		this.dgG_FindValue = new object[1];
		this.dgG_FindValue[0] = this.StoredKey;

        bt_choose1.Attributes["OnClick"] = "uf_OpenWindow('p_e0201_03.aspx?ReturnFormID=" + this.uf_GetFormID() + "&ReturnObjectID=" + dwF_hle201_vid.ClientID + "&ReturnObjectID1=" + dwF_hle201_vname.ClientID + "', '', 640, 420, 'no', 'no')";

	}

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�G���U u_Edit_F ���s��Ƶ����s�褧�e�Ұ����B�z�]�s�W�^
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		if (adrv_Row == null) return true;
        IPAddress IPtest = new IPAddress(0);

		// �p�G��Ƭ��s�W��
		if (adrv_Row.IsNew)
		{
			// ���o�y�������t�νs���V��Ʈw�̤j��+1
            adrv_Row["hle201_lid"] = e01Project.uf_Get_SystemNo("hle201.hle201_lid", "Slog");
			dwF_hle201_lid.Text = adrv_Row["hle201_lid"].ToString();

            //adrv_Row["hle201_cdt"] = DbMethods.uf_GetDateTime();  //���ɮɶ�
            //dwF_hle201_cdt.Text = adrv_Row["hle201_cdt"].ToString();
		}

        if (dwF_hle201_ip.Text.Trim() != "")
        {
            if (!IPAddress.TryParse(dwF_hle201_ip.Text, out IPtest))
            {
                this.uf_Msg(dwF_hle201_ip.Text.Trim() + "���ŦXIP�榡�A�Эץ��I");
                return false;
            }
        }

		return true;
	}

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�G���U u_Edit_F ���s����x�s����Ұ����B�z�]�s�W�B�ק�B�R���^
	/// </summary>
	private bool u_Edit_F_AfterSave(Control adwF, n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		// ���s���X�d�ߤβM����
		this.uf_AddJavaScript("parent.frames[1].__doPostBack('',''); uf_SelectFrame(1);");
		return true;
	}

	#region �� Override Methods --------------------------------------- ���g�H���Gfen

	// =========================================================================
	/// <summary>
	/// �禡�y�z�G��Ʊ���e���������B�z����w��S��Τ���B�z���l����������B�z�]�л\�W�h�^
	/// </summary>
	/// <param name="acto_Child">��Ʊ���e���W���l���</param>
	/// <param name="as_Value">�l���������쪺��(�p�����X�h�S�h�ť�)</param>
	/// <param name="a_Action">�B�z�����V�s�W(New)�F���X(Get)�F��J(Set)�Fô��(Bind)</param>
	/// <param name="adrv_Row">����ƦC</param>
	/// <returns>���\(true)�F����(false)</returns>
	protected override bool uf_DwF_DataAfter(Control acto_Child, ref string as_Value, DwActions a_Action, DataRowView adrv_Row)
	{
        if (a_Action == DwActions.New || a_Action == DwActions.Get)
        {
            // ���ɤ覡
            if (acto_Child == dwF_hle201_cway_c)
            {
                dwF_hle201_cway_c.Text = uf_Dg_Bind(dwF_hle201_cway.Items, "2");
                return true;
            }
            // �Ӥu�m�W
            if (acto_Child == dwF_hle201_vname)
            {
                dwF_hle201_vname.Text = uf_Dg_Bind("hmd201", adrv_Row["hle201_vid"]);
                return true;
            }
            // ��d�ɶ�
            if (acto_Child == dwF_hle201_sdatetime)
            {
                DateTime ldt_date;
                ListItem lli_Item;
                ldt_date = Convert.ToDateTime(adrv_Row["hle201_sdatetime"]);
                lli_Item = dwF_SHour.Items.FindByValue(ldt_date.Hour.ToString("00"));
                if (lli_Item != null)
                    dwF_SHour.SelectedIndex = dwF_SHour.Items.IndexOf(lli_Item);

                lli_Item = dwF_SMin.Items.FindByValue(ldt_date.Minute.ToString("00"));
                if (lli_Item != null)
                    dwF_SMin.SelectedIndex = dwF_SMin.Items.IndexOf(lli_Item);

                lli_Item = dwF_SSec.Items.FindByValue(ldt_date.Second.ToString("00"));
                if (lli_Item != null)
                    dwF_SSec.SelectedIndex = dwF_SSec.Items.IndexOf(lli_Item);

                return true;
            }
        }
        else if (a_Action == DwActions.Set)
        {
            // ��d�ɶ�
            if (acto_Child == dwF_hle201_sdatetime)
            {
                as_Value = u_Date1.Value + " " + dwF_SHour.SelectedValue + ":" + dwF_SMin.SelectedValue + ":" + dwF_SSec.SelectedValue;
                return true;
            }
        }

        return true;
	}

	#endregion

}
