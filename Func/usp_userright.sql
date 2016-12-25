use NMMST_HR
GO

-- =============================================
-- 將已存在的預存程序刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'usp_userright' 
	   AND 	  type = 'P')
    DROP PROCEDURE usp_userright
GO


CREATE PROCEDURE usp_userright(@as_userid varchar(20), @as_sysid varchar(10), @as_modid char(1) = '')

AS

/**************************************************
1. 程式描述：環域科技共用函式庫–使用者權限資料清單（新版–只取權限有的父層）

2. 程式步驟：(1)從《系統權限群組操作 sys03》、《系統子系統 sys05》和《系統權限群組使用者 sys02》中找出相關資料
   　　　　　(2)從《系統權限群組操作 sys03》和《系統權限群組使用者 sys02》中找出相關資料
   　　　　　(3)從《系統操作 sys04》中找出相關資料（操作英文名稱、中文名稱、URL、父層、操作註記）
   　　　　　(4)從《系統操作 sys04》中找出相關資料（非實際操作，而是分支節點資料）
   　　　　　(5)從《系統子系統 sys05》中找出相關資料（模組代碼、子系統英文名稱、中文名稱、URL）
   　　　　　(6)從《系統模組 sys06》中找出相關資料（模組名稱）

3. 使用方式：(1)參數：@as_userid		varchar(20)		使用者帳號
   　　　　　(2)參數：@as_sysid			varchar(10)		子系統代碼–取出全部子系統權限(menubar)；
   　　　　　   　　　         			           		　　　　　　取出第一個子系統操作權限(menutree)；
   　　　　　   　　　         			           		　　　　　　取出全部子系統操作權限(空字串)；
   　　　　　   　　　         			           		　　　　　　取出單個子系統操作權限(指定子系統代碼)–不考慮模組代碼
   　　　　　(3)參數：@as_modid			char(1)			模組代碼–取出第一個模組權限(0)；
   　　　　　   　　　         			           		　　　　　取出全部模組權限(空字串)；
   　　　　　   　　　         			           		　　　　　取出單個模組權限(指定模組代碼)
   　　　　　(4)回傳：					table			使用者權限資料清單

4. 撰寫人員：fen

5. 修改日期：2005/8/18
**************************************************/

                                                                      /* ☆ 宣告部份 ☆ */ 

-- 結果的暫存表格
CREATE TABLE #userright
(   seq					smallint		null,		-- 1 序號
	rid					varchar(20)		null,       -- 2 權限代碼(子系統代碼 + 操作代碼)
	mod_id				char(1)			null,       -- 3 模組代碼
    mod_text			varchar(20)		null,       -- 4 模組名稱
    mod_img				varchar(255)	null,       -- 5 模組圖示
    sys_id				varchar(10)		null,       -- 6 子系統代碼
    sys_text			varchar(50)		null,       -- 7 子系統名稱
    sys_url				varchar(255)	null,       -- 8 子系統 URL(?menu_id=子系統代碼)
    func_id				varchar(10)		null,       -- 9 操作代碼
    func_text			varchar(50)		null,       -- 10 操作名稱
    func_url			varchar(255)	null,       -- 11 操作 URL(?menu_id=子系統代碼 + '.' + 權限代碼)
    func_parent			varchar(10)		null,       -- 12 操作父層
    func_flag			char(1)			null,       -- 13 操作 flag
	upd_flag			char(1)			null,		-- 14 可修改 flag
	check_flag			char(1)			null		-- 15 可審核 flag
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

-- 如果沒有傳入子系統代碼則取出全部資料
SELECT @as_sysid = IsNull(RTrim(@as_sysid), '')

-- 如果沒有傳入模組代碼則取出全部資料
SELECT @as_modid = IsNull(RTrim(@as_modid), '')


/* --------------------------------------------------------------------------------------- 
   從《系統權限群組操作 sys03》、《系統子系統 sys05》和《系統權限群組使用者 sys02》中找出相關資料
--------------------------------------------------------------------------------------- */ 

-- 找出符合的模組代碼
IF (Lower(@as_modid) = '0')							-- 2005/08/17, fen add 取出第一個模組權限
BEGIN
	-- 找出第一個模組代碼
	SELECT @as_modid = Min(RTrim(s05_mod_id))
		FROM sys03, sys05
		WHERE (s03_grp_id in (SELECT s02_grp_id
									FROM sys02
									WHERE s02_user_id = @as_userid))
			AND (s03_sys_id = s05_sys_id)
			AND (IsNull(RTrim(s05_mod_id), '') <> '')

	SELECT @as_modid = IsNull(@as_modid, '')
END


/* --------------------------------------------------------------------------------------- 
   從《系統權限群組操作 sys03》和《系統權限群組使用者 sys02》中找出相關資料
--------------------------------------------------------------------------------------- */ 

-- 到 #userright 新增使用者權限操作資料
IF (Lower(@as_sysid) = 'menubar')					-- 2004/06/14, fen add 取出全部子系統權限
BEGIN	-- (1)
	INSERT INTO #userright (seq, rid, sys_id, func_id, func_flag)
		SELECT DISTINCT seq = 0,
						rid = RTrim(s03_sys_id),
						sys_id = RTrim(s03_sys_id),
						func_id = '',
						func_flag = 'S'
			FROM sys03
			WHERE (s03_grp_id in (SELECT s02_grp_id
										FROM sys02
										WHERE s02_user_id = @as_userid))
				AND (s03_sys_id in (SELECT s05_sys_id
										FROM sys05
										WHERE s05_mod_id = CASE WHEN @as_modid = '' THEN s05_mod_id ELSE @as_modid END))
	Goto Update_sys05
END
ELSE IF (Lower(@as_sysid) = 'menutree')				-- 2004/06/16, fen add 取出第一個子系統操作權限（如有指定模組則為模組第一個子系統）
BEGIN
	-- 找出第一個子系統代碼
	SELECT @as_sysid = Min(RTrim(s03_sys_id))
		FROM sys03
		WHERE (s03_grp_id in (SELECT s02_grp_id
									FROM sys02
									WHERE s02_user_id = @as_userid))
			AND (s03_sys_id in (SELECT s05_sys_id
									FROM sys05
									WHERE s05_mod_id = CASE WHEN @as_modid = '' THEN s05_mod_id ELSE @as_modid END))

	SELECT @as_sysid = IsNull(@as_sysid, '')

	IF (@as_sysid <> '') Goto Find_sys03_singlesys
END
ELSE IF (@as_sysid = '')							-- 2004/06/14, fen add 取出全部子系統操作權限
BEGIN
	INSERT INTO #userright (rid, sys_id, func_id, upd_flag, check_flag)
		SELECT DISTINCT rid = RTrim(s03_sys_id) + RTrim(s03_func_id),
			   			sys_id = RTrim(s03_sys_id),
			   			func_id = RTrim(s03_func_id),
			   			upd_flag = 'Y',
			   			check_flag = 'Y'
			FROM sys03
			WHERE (s03_grp_id in (SELECT s02_grp_id
										FROM sys02
										WHERE s02_user_id = @as_userid))
				AND (s03_sys_id in (SELECT s05_sys_id
										FROM sys05
										WHERE s05_mod_id = CASE WHEN @as_modid = '' THEN s05_mod_id ELSE @as_modid END))
END
ELSE												-- 2004/06/14, fen add 取出單個子系統操作權限–不考慮模組代碼
BEGIN
	Find_sys03_singlesys:
	INSERT INTO #userright (rid, sys_id, func_id, upd_flag, check_flag)
		SELECT DISTINCT rid = RTrim(s03_sys_id) + RTrim(s03_func_id),
			   			sys_id = RTrim(s03_sys_id),
			   			func_id = RTrim(s03_func_id),
			   			upd_flag = 'Y',
			   			check_flag = 'Y'
			FROM sys03
			WHERE (s03_grp_id in (SELECT s02_grp_id
										FROM sys02
										WHERE s02_user_id = @as_userid))
				AND (s03_sys_id = @as_sysid)
END


-- 到 #userright 新增使用者權限子系統資料
INSERT INTO #userright (seq, rid, sys_id, func_id, func_flag)
	SELECT DISTINCT seq = 0,
					rid = sys_id,
					sys_id = sys_id,
					func_id = '',
					func_flag = 'S'
		FROM #userright


/* --------------------------------------------------------------------------------------- 
   從《系統操作 sys04》中找出相關資料
--------------------------------------------------------------------------------------- */ 

-- 找出 #userright 子系統代碼和操作代碼所對應的操作英文名稱、中文名稱、URL、層級、操作註記–sys04
UPDATE #userright
    SET seq = IsNull(s04_func_seq, 1),
		func_text = IsNull(RTrim(s04_func_text), ''),
		func_url = CASE WHEN IsNull(RTrim(s04_func_url), '') = '' THEN '' ELSE RTrim(s04_func_url) + '?menu_id=' + sys_id + '.' + rid END,
		func_parent = IsNull(RTrim(s04_func_parent), sys_id),
		func_flag = CASE WHEN IsNull(Upper(s04_func_flag), '') = 'N' THEN 'N' ELSE 'Y' END
    FROM sys04
    WHERE sys_id = s04_sys_id
		AND func_id = s04_func_id


-- 到 #userright 新增非實際操作，而是分支節點資料（有權限的父層，非全部）–先找全部，再刪除沒有權限的
INSERT INTO #userright (seq, rid, sys_id, func_id, func_text, func_url, func_parent, func_flag)
	SELECT seq = IsNull(s04_func_seq, 0),
		   rid = RTrim(s04_sys_id) + RTrim(s04_func_id),
		   sys_id = RTrim(s04_sys_id),
		   func_id = RTrim(s04_func_id),
		   func_text = IsNull(RTrim(s04_func_text), ''),
		   func_url = CASE WHEN IsNull(RTrim(s04_func_url), '') = '' THEN '' ELSE RTrim(s04_func_url) + '?menu_id=' + RTrim(s04_sys_id) + '.'  + RTrim(s04_sys_id) + RTrim(s04_func_id) END,
		   func_parent = IsNull(RTrim(s04_func_parent), RTrim(s04_sys_id)),
		   func_flag = 'N'
		FROM sys04
		WHERE (s04_sys_id in (SELECT DISTINCT sys_id FROM #userright))
			AND ((CASE WHEN IsNull(Upper(s04_func_flag), '') = 'N' THEN 'N' ELSE 'Y' END) = 'N')


-- 到 #userright 刪除非實際操作，而是分支節點資料（沒有權限的父層）
SELECT @ll_count = 1
WHILE @ll_count <= 5
BEGIN
	DELETE FROM #userright
		WHERE (NOT EXISTS (SELECT 1
								FROM #userright A
								WHERE A.func_parent = #userright.rid))
			AND (func_flag = 'N')
	SELECT @ll_count = @ll_count + 1
END


/* --------------------------------------------------------------------------------------- 
   從《系統子系統 sys05》中找出相關資料
--------------------------------------------------------------------------------------- */ 

Update_sys05:
-- 找出 #userright 子系統代碼所對應的模組代碼、子系統英文名稱、中文名稱、URL–sys05
UPDATE #userright
    SET mod_id = IsNull(s05_mod_id, ''),
		sys_text = CASE WHEN func_flag = 'S' THEN IsNull(RTrim(s05_sys_text), '') ELSE Null END,
		sys_url = CASE WHEN func_flag = 'S' THEN CASE WHEN IsNull(RTrim(s05_sys_url), '') = '' THEN '' ELSE RTrim(s05_sys_url) + '?menu_id=' + sys_id END ELSE Null END,
		func_parent = CASE WHEN func_flag = 'S' THEN IsNull(s05_mod_id, '') ELSE func_parent END
    FROM sys05
    WHERE sys_id = s05_sys_id


-- 到 #userright 新增使用者權限模組資料
INSERT INTO #userright (seq, rid, mod_id, sys_id, func_id, func_flag)
	SELECT DISTINCT seq = Null,
					rid = mod_id,
					mod_id = mod_id,
					sys_id = IsNull(Min(sys_id), ''),
					func_id = '',
					func_flag = 'M'
		FROM #userright
		WHERE func_flag = 'S'
		GROUP BY mod_id


/* --------------------------------------------------------------------------------------- 
   從《系統模組 sys06》中找出相關資料
--------------------------------------------------------------------------------------- */ 

-- 找出 #userright 模組代碼所對應的模組名稱、模組圖示–sys06
UPDATE #userright
    SET mod_text = IsNull(s06_mod_text, ''),
		mod_img = 'proj_img/g_Module.ico'
    FROM sys06
    WHERE mod_id = s06_mod_id
		AND func_flag = 'M'


-- 刪除 #userright 中不要的資料
DELETE FROM #userright
    WHERE func_flag IS NULL


/* --------------------------------------------------------------------------------------- 
   處理完畢–取出《結果的暫存表格 #userright》的資料
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- 從《結果的暫存表格 #userright》取出資料
	SELECT *
		FROM #userright
		ORDER BY mod_id ASC, sys_id ASC, seq ASC



GO


-- =============================================
-- 執行函式範例
-- =============================================

--EXEC dbo.usp_userright 'user', 'menubar'
--EXEC dbo.usp_userright 'user', 'menutree'
--EXEC dbo.usp_userright 'user', ''
--EXEC dbo.usp_userright 'user', 's01'
--EXEC dbo.usp_userright 'user', 'menubar', 'S'
--EXEC dbo.usp_userright 'user', 'menutree', 'S'
--EXEC dbo.usp_userright 'user', '', 'S'
--EXEC dbo.usp_userright 'user', 's01', 'S'
GO
