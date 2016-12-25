use NMMST_HR
GO

-- =============================================
-- 將已存在的 Trigger 刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmf101b_d' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmf101b_d
GO


CREATE TRIGGER trig_hmf101b_d
ON hmf101b
FOR DELETE
AS 


/* --------------------------------------------------------------------------------------- 
   程式不需執行條件
--------------------------------------------------------------------------------------- */ 

-- 當異動資料不等於 1 筆則不處理
IF @@rowcount <> 1 RETURN


/* --------------------------------------------------------------------------------------- 
   程式開始執行
--------------------------------------------------------------------------------------- */ 

-- 刪除《系統權限群組使用者–sys02》表格的資料
DELETE FROM [NMMST_VW].[dbo].[hmf101b]
WHERE hmf101b_certid = (SELECT hmf101b_certid FROM deleted)
     AND hmf101b_courseid = (SELECT hmf101b_courseid FROM deleted);

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
