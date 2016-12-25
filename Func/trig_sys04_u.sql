use NMMST_HR
GO

-- =============================================
-- 將已存在的 Trigger 刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_sys04_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_sys04_u
GO


CREATE TRIGGER trig_sys04_u
ON sys04

FOR UPDATE
AS 

/**************************************************
1. 程式描述：當系統操作–sys04 修改資料時所要做的處理

2. 程式步驟：(0)程式不需執行條件：當異動資料不等於 1 筆則不處理
   　　　　　(1)修改《系統權限群組操作–sys03》表格的資料「子系統代碼」和「操作代碼」，失敗則判定儲存失敗

3. 撰寫人員：fen

4. 修改日期：2004/6/14
**************************************************/

/* --------------------------------------------------------------------------------------- 
   程式不需執行條件
--------------------------------------------------------------------------------------- */ 

-- 當異動資料不等於 1 筆則不處理
IF @@rowcount <> 1 RETURN

-- 判斷異動資料欄位不為「子系統代碼」或「操作代碼」則不處理
IF (SELECT RTrim(s04_sys_id) + RTrim(s04_func_id) FROM inserted) = (SELECT RTrim(s04_sys_id) + RTrim(s04_func_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   程式開始執行
--------------------------------------------------------------------------------------- */ 

-- 修改《系統權限群組操作–sys03》表格的資料「子系統代碼」和「操作代碼」
UPDATE sys03
	SET s03_sys_id = (SELECT s04_sys_id FROM inserted),
		s03_func_id = (SELECT s04_func_id FROM inserted)
	WHERE s03_sys_id + s03_func_id = (SELECT s04_sys_id + s04_func_id FROM deleted)

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
