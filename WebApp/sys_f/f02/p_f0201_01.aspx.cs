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

public partial class sys_f_f02_p_f0201_01 : p_hrBase
{
	#region �� Declare Variables -------------------------------------- ���g�H���GWITSETER (QFLin)

	/// <summary>�ܼƴy�z�G��Ƥ���</summary>
	protected ndb_hlf201 indb_hlf201 = new ndb_hlf201();

	#endregion

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�G�����}��
	/// </summary>
	
	protected void Page_Load(object sender, EventArgs e)
    {
		// ��l��
		this.uf_InitializeQuery(dwQ, this.indb_hlf201, bt_Query);
		this.uf_InitializeComponent(null, dgG, this.indb_hlf201, null);
		this.dgG_Sort = "hlf201_vid , hlf201_sdatetime desc";

        // �p�G�O�Ĥ@�����榹����
        if (!this.IsPostBack)
        {
            u_Date1.Value = DbMethods.uf_GetDate().ToString();
            u_Date2.Value = DbMethods.uf_GetDate().ToString();
        }
	}

	// =========================================================================
	/// <summary>
	/// �ƥ�y�z�GdgG ��ܬY����Ʃҭn�����B�z
	/// </summary>
	protected override void idgG_SelectedIndexChanged(object sender, EventArgs e)
    {
		this.uf_AddJavaScript("uf_LinkFrame('p_f0201_02.aspx', '02Frame', '" + dgG.DataKeys[dgG.SelectedIndex].ToString() + "')");
	}

    // =========================================================================
    /// <summary>
    /// �禡�y�z�G��Ʊ���e������զX�X�d�߻y�k����w��S��Τ���B�z���l����A�ק�զX�X���d�߻y�k�]�@�ӱ���B�z�@���^�]�л\�W�h�^
    /// </summary>
    /// <param name="acto_Child">��Ʊ���e���W���l���</param>
    /// <param name="as_ColType">�l���������쪺���A�����V�M�Ů�(�Ŧr��)�F�r�굥��(S)�F�r��ۦ�(SL)�F����ɶ�(DT)�F���(D)�F�ɶ�(T)�F�ƭ�(N)</param>
    /// <param name="as_Value">�l���������쪺��(�w�h�ť�)�V�ǤJ���Ȥw�B�z���w�����e�A�p���ܧ�ݦۦ�T�{��w����</param>
    /// <param name="a_Action">�B�z�����V�M��(New)�F�d��(Set)</param>
    /// <param name="as_AddSQL">�M��(New)���Ŧr��F�d��(Set)�h�ǤJ���e�զX�X���d�߻y�k(�|���[�J������y�k)</param>
    /// <param name="ab_IsAdd">�O�_�[�J������y�k�ΰѼơV�O(true)�F�_(false)</param>
    /// <param name="a_Kind">��Ƭd�ߺ����V�y�k(AddSQL)�F�Ѽ�(AddArg)</param>
    /// <returns>���\(true)�F����(false)</returns>
    protected override bool uf_DwQ_SQLAfter(Control acto_Child, ref string as_ColType, ref string as_Value, DwActions a_Action, ref string as_AddSQL, ref bool ab_IsAdd, DwQKinds a_Kind)
    {
        if (a_Action == DwActions.Set)
        {
            // �H���m�W
            if (acto_Child == dwQ_hlf201_vname)
            {
                if (dwQ_hlf201_vname.Text.Trim() != "")
                {
                    as_AddSQL += " AND hlf201_vid in ( SELECT Hmd201_vid From Hmd201 Where Hmd201_id in ( Select hmc101_id From hmc101 where hmc101_cname like '%" + dwQ_hlf201_vname.Text.Trim() + "%') ) ";
                }
                return true;
            }

            // �Ӥu��
            if (acto_Child == dwQ_hlf201_tid)
            {
                if (dwQ_hlf201_tid.SelectedValue != "")
                {
                    as_AddSQL += " AND hlf201_vid in ( SELECT Hmd201_vid From Hmd201 Where hmd201_tid = '" + dwQ_hlf201_tid.SelectedValue + "' ) ";
                }
                return true;
            }

            // ��d�ɶ�-�_
            if (acto_Child == dwQ_hlf201_sdatetime_s)
            {
                if (u_Date1.Value != "")
                {
                    as_AddSQL += " AND hlf201_sdatetime >= '" + u_Date1.Value + "' ";
                }
                return true;
            }

            // ��d�ɶ�-��
            if (acto_Child == dwQ_hlf201_sdatetime_e)
            {
                if (u_Date2.Value != "")
                {
                    as_AddSQL += " AND hlf201_sdatetime < DateAdd(dd , 1 , CAST ('" + u_Date2.Value + "' as datetime)) ";
                }
                return true;
            }

        }
        return true;
    }
}
