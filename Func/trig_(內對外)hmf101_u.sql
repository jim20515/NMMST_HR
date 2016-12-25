use NMMST_HR
GO

-- =============================================
-- 將已存在的 Trigger 刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmf101_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmf101_u
GO


CREATE TRIGGER trig_hmf101_u
ON hmf101

FOR UPDATE
AS 

IF @@rowcount <> 1 RETURN

-- 判斷異動資料欄位不為「群組代碼」則不處理
--IF (SELECT RTrim(s01_grp_id) FROM inserted) = (SELECT RTrim(s01_grp_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   程式開始執行
--------------------------------------------------------------------------------------- */ 

-- 修改《系統權限群組使用者–sys02》表格的資料「群組代碼」
UPDATE [NMMST_VW].[dbo].hmf101
	SET hmf101_courseid = (SELECT hmf101_courseid FROM inserted), 
hmf101_name = (SELECT hmf101_name FROM inserted), 
hmf101_coursetype = (SELECT hmf101_coursetype FROM inserted), 
hmf101_hourse = (SELECT hmf101_hourse FROM inserted), 
hmf101_openfor = (SELECT hmf101_openfor FROM inserted), 
hmf101_force = (SELECT hmf101_force FROM inserted), 
hmf101_ps = null, 
hmf101_aid = (SELECT hmf101_aid FROM inserted), 
hmf101_adt = (SELECT hmf101_adt FROM inserted), 
hmf101_uid = (SELECT hmf101_uid FROM inserted), 
hmf101_udt = (SELECT hmf101_udt FROM inserted)
	WHERE hmf101_courseid = (SELECT hmf101_courseid FROM deleted)

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


GO
