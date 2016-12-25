// *********************************************************************************
// 1. 程式描述：訓練開班作業 - 開班時間維護
// 2. 撰寫人員：rong
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

public partial class sys_f_f01_p_f0102_04 : p_sBase
{
	#region ☆ Declare Variables -------------------------------------- 撰寫人員：

	/// <summary>變數描述：資料元件</summary>
	protected ndb_hmf102a indb_hmf102a = new ndb_hmf102a();

	#endregion

	// =========================================================================
	/// <summary>
	/// 事件描述：網頁開啟
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
	{
		// 初始化
		this.uf_InitializeComponent(dwF, dgG, this.indb_hmf102a, u_Edit_F);
		this.dgG_Sort = string.Join(",", this.dgG_PrimaryKey);
		//this.IsQuery_SessionRemove = false;

		this.ue_DataInsert_PreEndEdit += new DataHandler(this.u_Edit_F_PreEndEdit);


		if (!IsPostBack)
		{

			// 接收傳入值
			if (this.Request["args"] != null)
				this.StoredKey = this.Request["args"].Trim();
			this.dgG_Retrieve = " AND hmf102a_trainid = '" + this.StoredKey + "'";

		}
	}

	// =========================================================================
	/// <summary>
	/// 事件描述：按下 u_Edit_F 按鈕資料結束編輯之前所做的處理（新增）
	/// </summary>
	private bool u_Edit_F_PreEndEdit(Control adwf, WIT.Template.Project.n_dbbase andb_Data, DataRow adr_Row, DataRowView adrv_Row)
	{
		
		/* 新增時..*/
		if (adrv_Row.IsNew)
		{

			string ls_maxno = "";
			DbMethods.uf_ExecSQL("SELECT Max(hmf102a_seq) FROM hmf102a WHERE hmf102a_trainid = '" + dwF_hmf102a_trainid.Text + "'", ref ls_maxno);
			if (ls_maxno == null || ls_maxno == "")
				adr_Row["hmf102a_seq"] = Convert.ToString(1).PadLeft(4, '0');
			else
				adr_Row["hmf102a_seq"] = Convert.ToString(Convert.ToInt64(ls_maxno) + 1).PadLeft(4, '0');
		}

		return true;
	}

	// =========================================================================
	/// <summary>
	/// 函式描述：資料控制項容器做相關處理之後針對特殊或不能處理的子控制項做相關處理（覆蓋上層）
	/// </summary>
	/// <param name="acto_Child">資料控制項容器上的子控制項</param>
	/// <param name="as_Value">子控制項對應欄位的值(如為取出則沒去空白)</param>
	/// <param name="a_Action">處理種類–新增(New)；取出(Get)；放入(Set)；繫結(Bind)</param>
	/// <param name="adrv_Row">當筆資料列</param>
	/// <returns>成功(true)；失敗(false)</returns>
	protected override bool uf_DwF_DataAfter(Control acto_Child, ref string as_Value, DwActions a_Action, DataRowView adrv_Row)
	{
		if (a_Action == DwActions.New || a_Action == DwActions.Get)
		{
			if (acto_Child == dwF_hmf102a_trainid && a_Action == DwActions.New)
			{
				dwF_hmf102a_trainid.Text = this.StoredKey;
				return true;
			}

			if (acto_Child == dwF_hmf102a_trainid_c)
			{
				string ls_string = "";
				DbMethods.uf_ExecSQL("SELECT hmf101_name FROM hmf101, hmf102 WHERE hmf101_courseid = hmf102_courseid AND hmf102_trainid = '" + this.StoredKey + "'", ref ls_string);
				dwF_hmf102a_trainid_c.Text = ls_string;
				return true;
			}
		}
		else if (a_Action == DwActions.Set)
		{
			// 日期
			if (acto_Child == dwF_hmf102a_date)
			{
				as_Value = (as_Value.Length > 10 ? as_Value.Substring(0, 10) : as_Value);
				return true;
			}
			// 開始時間、結束時間
			if (acto_Child == dwF_hmf102a_stime || acto_Child == dwF_hmf102a_etime)
			{
				if (Convert.ToInt16(Convert.ToDateTime(u_Time1.Value).ToString("HHmm")) >= Convert.ToInt16(Convert.ToDateTime(u_Time2.Value).ToString("HHmm")))
				{
					this.uf_Msg("「結束時間」必須大於「結束時間」！");
					return false;
				}

				as_Value = (as_Value.Substring(11, 8) == "00:00:00" ? "" : Convert.ToDateTime(adrv_Row["hmf102a_date"]).ToString("yyyy/MM/dd") + " " + as_Value.Substring(11, 8));
				return true;
			}
		}
		return true;
	}
}
