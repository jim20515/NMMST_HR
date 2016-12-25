<%@ WebHandler Language="C#" Class="h_download_file" %>

// *********************************************************************************
// 1. 程式描述：環域科技共用函式庫–檔案下載
// 2. 撰寫人員：fen
// 3. 使用方式：(1)參數：key				Application 變數名稱
// 4. 前置條件：(1)變數：Application[ls_key] = 檔案內容 Bytes
//              (2)變數：Application["name:" + ls_key] = 檔案名稱(含副檔名)
// *********************************************************************************
using System;
using System.Web;
using System.Web.SessionState;

public class h_download_file : IHttpHandler, IReadOnlySessionState
{
    public void ProcessRequest (HttpContext context)
	{
		// 宣告並接收傳入值
		String ls_key = "", ls_filename = "";
		byte[] lba_file = null;

		if (context.Request["key"] != null)
			ls_key = context.Request["key"].Trim();

		if (context.Session["ss_user_id"] != null && ls_key != "")
		{
			if (context.Application[ls_key] != null)
			{
				// 取得檔案內容
				lba_file = (byte[])context.Application[ls_key];
				
				// 取得檔案名稱
				if (context.Application["name:" + ls_key] != null)
					ls_filename = (string)context.Application["name:" + ls_key];
				else
					ls_filename = ls_key;

				// 移除 Application 變數
				context.Application.Remove(ls_key);
				context.Application.Remove("name:" + ls_key);
			}
		}

		// 設定網頁類型
		if (ls_filename.ToLower().EndsWith(".xls"))
			context.Response.ContentType = "application/vnd.ms-excel";
		else if (ls_filename.ToLower().EndsWith(".doc"))
			context.Response.ContentType = "application/msword";
		else if (ls_filename.ToLower().EndsWith(".pdf"))
			context.Response.ContentType = "application/pdf";
		else
			context.Response.ContentType = "application/octet-stream";

		// 讀取檔案
		if (lba_file != null)
		{
			bool lb_IsOpen = false;

			if (context.Request["open"] != null)
				lb_IsOpen = true;

			context.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("big5");
			if (lb_IsOpen)
				context.Response.AddHeader("content-disposition", "filename=\"" + ls_filename + "\"");
			else
				context.Response.AddHeader("content-disposition", "attachment; filename=\"" + ls_filename + "\"");	// 設定下載檔案
			context.Response.BinaryWrite(lba_file);
		}
		context.Response.End();
	}

	public bool IsReusable
	{
		get { return false; }
	}
}