use NMMST_HR
GO

-- =============================================
-- 將已存在的 Trigger 刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_user01_d' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_user01_d
GO


CREATE TRIGGER trig_user01_d
ON user01

FOR DELETE
AS 

/**************************************************
1. 程式描述：當使用者帳號–user01 刪除資料時所要做的處理

2. 程式步驟：(0)程式不需執行條件：當異動資料不等於 1 筆則不處理
   　　　　　(1)刪除《使用者帳號使用者–sys02》表格的資料，失敗則判定儲存失敗

3. 撰寫人員：fen

4. 修改日期：2006/5/15
**************************************************/

/* --------------------------------------------------------------------------------------- 
   程式不需執行條件
--------------------------------------------------------------------------------------- */ 

-- 當異動資料不等於 1 筆則不處理
IF @@rowcount <> 1 RETURN


/* --------------------------------------------------------------------------------------- 
   程式開始執行
--------------------------------------------------------------------------------------- */ 

-- 刪除《使用者帳號使用者–sys02》表格的資料
DELETE FROM sys02 WHERE s02_user_id in (SELECT user01_id FROM deleted)

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
