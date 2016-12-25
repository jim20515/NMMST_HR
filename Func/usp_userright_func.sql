use NMMST_HR
GO

-- =============================================
-- 將已存在的預存程序刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'usp_userright_func' 
	   AND 	  type = 'P')
    DROP PROCEDURE usp_userright_func
GO


CREATE PROCEDURE usp_userright_func(@as_userid varchar(20), @as_sysid varchar(10), @as_funcid varchar(10), @ab_showparent bit = 0)

AS

/**************************************************
1. 程式描述：環域科技共用函式庫–使用者權限單一操作項目資料清單

2. 程式步驟：(1)從《系統權限群組操作 sys03》、《系統操作 sys04》和《系統權限群組使用者 sys02》中找出相關資料

3. 使用方式：(1)參數：@as_userid		varchar(20)		使用者帳號
   　　　　　(2)參數：@as_sysid			varchar(10)		子系統代碼
   　　　　　(3)參數：@as_funcid		varchar(10)		操作代碼
   　　　　　(4)參數：@ab_showparent	bit				顯示父層資料–顯示(1)；不顯示(0)(預設值)
   　　　　　(5)回傳：					table			使用者權限單一操作項目資料清單

4. 撰寫人員：fen

5. 修改日期：2007/9/26
**************************************************/

                                                                      /* ☆ 宣告部份 ☆ */ 

-- 結果的暫存表格
CREATE TABLE #userright_func
(   rid					varchar(20)		null,       -- 1 權限代碼(子系統代碼 + 操作代碼)
	sys_id				varchar(10)		null,       -- 2 子系統代碼
    sys_text			varchar(50)		null,       -- 3 子系統名稱
    func_id				varchar(10)		null,       -- 4 操作代碼
    func_text			varchar(50)		null,       -- 5 操作名稱
    func_url			varchar(255)	null,       -- 6 操作 URL
    func_parent			varchar(10)		null,       -- 7 操作父層
    func_flag			char(1)			null,       -- 8 操作 flag
    func_item			varchar(255)	null,       -- 9 操作項目
	upd_flag			char(1)			null,		-- 10 可修改 flag
	check_flag			char(1)			null,		-- 11 可審核 flag
	func_level			smallint		null		-- 12 操作層級
)


-- ##### 宣告變數 #####
DECLARE @ll_count			int				-- 計量器



                                                                      /* ☆ 程式部份 ☆ */ 

/* --------------------------------------------------------------------------------------- 
   錯誤的執行條件
--------------------------------------------------------------------------------------- */ 

-- 如果沒有傳入使用者帳號則不處理
SELECT @as_userid = RTrim(@as_userid)
IF (IsNull(@as_userid, '') = '') GOTO Exit_Result

-- 如果沒有傳入子系統代碼則不處理
SELECT @as_sysid = RTrim(@as_sysid)
IF (IsNull(@as_sysid, '') = '') GOTO Exit_Result

-- 如果沒有傳入操作代碼則不處理
SELECT @as_funcid = RTrim(@as_funcid)
IF (IsNull(@as_funcid, '') = '') GOTO Exit_Result


/* --------------------------------------------------------------------------------------- 
   從《系統權限群組操作 sys03》、《系統操作 sys04》和《系統權限群組使用者 sys02》中找出相關資料
--------------------------------------------------------------------------------------- */ 

-- 到 #userright_func 新增使用者權限單一操作項目資料
INSERT INTO #userright_func
	SELECT DISTINCT rid = RTrim(s03_sys_id) + RTrim(s03_func_id), 
						  sys_id = RTrim(s03_sys_id), 
						  sys_text = (SELECT sys05.s05_sys_text FROM sys05 WHERE sys05.s05_sys_id = sys03.s03_sys_id), 
						  func_id = RTrim(s03_func_id), 
						  func_text = s04_func_text, 
						  func_url = s04_func_url, 
						  func_parent = s04_func_parent, 
						  func_flag = s04_func_flag, 
						  func_item = IsNull(RTrim(s04_func_item), ''), 
						  upd_flag = 'Y', 
						  check_flag = 'Y',
						  func_level = 1
		FROM sys03, sys04 
		WHERE (sys03.s03_sys_id = sys04.s04_sys_id) 
			AND (sys03.s03_func_id = sys04.s04_func_id) 
			AND ((sys03.s03_grp_id in (SELECT s02_grp_id
											FROM sys02
											WHERE s02_user_id = @as_userid)) 
			AND (sys03.s03_sys_id = @as_sysid) 
			AND (sys03.s03_func_id = @as_funcid))

-- 如果沒有符合的資料則不處理
IF (@@rowcount = 0) GOTO Exit_Result


-- 到 #userright_func 新增非實際操作，而是分支節點資料（父層）
IF (@ab_showparent = 1)
BEGIN	-- (1)
	SELECT @ll_count = 1
	WHILE @ll_count <= 5
	BEGIN
		INSERT INTO #userright_func
			SELECT DISTINCT rid = RTrim(s04_sys_id) + RTrim(s04_func_id), 
							sys_id = RTrim(s04_sys_id), 
							sys_text = Null, 
							func_id = RTrim(s04_func_id), 
							func_text = s04_func_text, 
							func_url = s04_func_url, 
							func_parent = s04_func_parent, 
							func_flag = s04_func_flag, 
							func_item = IsNull(RTrim(s04_func_item), ''), 
							upd_flag = 'Y', 
							check_flag = 'Y',
							func_level = @ll_count + 1
				FROM sys04
				WHERE (EXISTS (SELECT 1
									FROM #userright_func A
									WHERE A.func_parent = RTrim(sys04.s04_sys_id) + RTrim(sys04.s04_func_id)
										AND A.func_level = @ll_count))
	
		-- 如果沒有符合的資料則不處理
		IF (@@rowcount = 0) GOTO Exit_Result
	
		SELECT @ll_count = @ll_count + 1
	END
END		-- (1)


/* --------------------------------------------------------------------------------------- 
   處理完畢–取出《結果的暫存表格 #userright_func》的資料
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- 從《結果的暫存表格 #userright_func》取出資料
	SELECT *
		FROM #userright_func
		ORDER BY func_level, upd_flag DESC, check_flag DESC



GO


-- =============================================
-- 執行函式範例
-- =============================================

--EXEC dbo.usp_userright_func 'user', 'a01', '01'
--EXEC dbo.usp_userright_func 'user', 'a01', '0302', 0
--EXEC dbo.usp_userright_func 'user', 'a01', '0302', 1
GO
