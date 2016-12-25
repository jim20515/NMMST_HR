use NMMST_HR
GO

-- =============================================
-- 將已存在的 Trigger 刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_sys01_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_sys01_u
GO


CREATE TRIGGER trig_sys01_u
ON sys01

FOR UPDATE
AS 

/**************************************************
1. 程式描述：當系統權限群組–sys01 修改資料時所要做的處理

2. 程式步驟：(0)程式不需執行條件：當異動資料不等於 1 筆則不處理
   　　　　　(1)修改《系統權限群組使用者–sys02》表格的資料「群組代碼」，失敗則判定儲存失敗
   　　　　　(2)修改《系統權限群組操作–sys03》表格的資料「群組代碼」，失敗則判定儲存失敗

3. 撰寫人員：fen

4. 修改日期：2004/6/14
**************************************************/

/* --------------------------------------------------------------------------------------- 
   程式不需執行條件
--------------------------------------------------------------------------------------- */ 

-- 當異動資料不等於 1 筆則不處理
IF @@rowcount <> 1 RETURN

-- 判斷異動資料欄位不為「群組代碼」則不處理
IF (SELECT RTrim(s01_grp_id) FROM inserted) = (SELECT RTrim(s01_grp_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   程式開始執行
--------------------------------------------------------------------------------------- */ 

-- 修改《系統權限群組使用者–sys02》表格的資料「群組代碼」
UPDATE sys02
	SET s02_grp_id = (SELECT s01_grp_id FROM inserted)
	WHERE s02_grp_id = (SELECT s01_grp_id FROM deleted)

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

-- 修改《系統權限群組操作–sys03》表格的資料「群組代碼」
UPDATE sys03
	SET s03_grp_id = (SELECT s01_grp_id FROM inserted)
	WHERE s03_grp_id = (SELECT s01_grp_id FROM deleted)

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
