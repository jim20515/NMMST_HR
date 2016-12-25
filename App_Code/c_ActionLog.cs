// *********************************************************************************
// 1. 程式描述：操作記錄日誌–HttpModule
// 2. 撰寫人員：fen
// *********************************************************************************
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WIT.Template.Project
{
	/// <summary>
	/// 操作記錄日誌–HttpModule
	/// </summary>
	public class ActionLogModule : IHttpModule
	{
		// =========================================================================
		/// <summary>
		/// 事件描述：網頁初始化
		/// </summary>
		void IHttpModule.Init(HttpApplication context)
		{
			// 當網站每一個 ASPX 網頁執行時,會先跑 Init 事件
			context.PostRequestHandlerExecute += new EventHandler(this.ue_PostRequestHandlerExecute);
		}

		// =========================================================================
		/// <summary>
		/// 事件描述：Dispose
		/// </summary>
		void IHttpModule.Dispose()
		{

		}

		// =========================================================================
		/// <summary>
		/// 事件描述：PostRequestHandlerExecute
		/// </summary>
		private void ue_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;

			// 因為所有的 Request 皆會跑到這，所以不是每種都可抓取 Session，應加以過濾來源
			// ex. handler is {ASP.proj_right_p_menubar_aspx}, {System.Web.Handlers.AssemblyResourceLoader}, {System.Web.Handlers.ScriptResourceHandler}
			IHttpHandler handler = application.Context.Handler;
			if (!handler.ToString().Contains("_aspx")) return;

			try { if (LoginUser.MenuID == null || !LoginUser.MenuID.Contains(".")) return; }
			catch { return; }

			// 判斷是否需記錄 Log
			object lo_logfunc = HttpContext.GetGlobalResourceObject("r_LogFuncID", LoginUser.MenuID.Split('.')[1]);
			if (lo_logfunc == null) return;

			Control lctl_find = ((Page)handler).FindControl("ActionLogKeys");
			string ls_key = (lctl_find != null ? (lctl_find as HiddenField).Value : (application.Request["ActionLogKeys"] != null ? application.Request["ActionLogKeys"].ToString() : ""));

			// 寫入操作資訊 *******************************************************
			Log.uf_ActionLog(application.Context, ls_key);
			//*********************************************************************
		}
	}
}
