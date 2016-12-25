// *********************************************************************************
// 1. �{���y�z�G�ާ@�O����x�VHttpModule
// 2. ���g�H���Gfen
// *********************************************************************************
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WIT.Template.Project
{
	/// <summary>
	/// �ާ@�O����x�VHttpModule
	/// </summary>
	public class ActionLogModule : IHttpModule
	{
		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�G������l��
		/// </summary>
		void IHttpModule.Init(HttpApplication context)
		{
			// ������C�@�� ASPX ���������,�|���] Init �ƥ�
			context.PostRequestHandlerExecute += new EventHandler(this.ue_PostRequestHandlerExecute);
		}

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�GDispose
		/// </summary>
		void IHttpModule.Dispose()
		{

		}

		// =========================================================================
		/// <summary>
		/// �ƥ�y�z�GPostRequestHandlerExecute
		/// </summary>
		private void ue_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;

			// �]���Ҧ��� Request �ҷ|�]��o�A�ҥH���O�C�س��i��� Session�A���[�H�L�o�ӷ�
			// ex. handler is {ASP.proj_right_p_menubar_aspx}, {System.Web.Handlers.AssemblyResourceLoader}, {System.Web.Handlers.ScriptResourceHandler}
			IHttpHandler handler = application.Context.Handler;
			if (!handler.ToString().Contains("_aspx")) return;

			try { if (LoginUser.MenuID == null || !LoginUser.MenuID.Contains(".")) return; }
			catch { return; }

			// �P�_�O�_�ݰO�� Log
			object lo_logfunc = HttpContext.GetGlobalResourceObject("r_LogFuncID", LoginUser.MenuID.Split('.')[1]);
			if (lo_logfunc == null) return;

			Control lctl_find = ((Page)handler).FindControl("ActionLogKeys");
			string ls_key = (lctl_find != null ? (lctl_find as HiddenField).Value : (application.Request["ActionLogKeys"] != null ? application.Request["ActionLogKeys"].ToString() : ""));

			// �g�J�ާ@��T *******************************************************
			Log.uf_ActionLog(application.Context, ls_key);
			//*********************************************************************
		}
	}
}
