use NMMST_HR
GO

-- =============================================
-- 將已存在的 Trigger 刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmf101a_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmf101a_u
GO


CREATE TRIGGER trig_hmf101a_u
ON hmf101a

FOR UPDATE
AS 

IF @@rowcount <> 1 RETURN

-- 判斷異動資料欄位不為「群組代碼」則不處理
--IF (SELECT RTrim(s01_grp_id) FROM inserted) = (SELECT RTrim(s01_grp_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   程式開始執行
--------------------------------------------------------------------------------------- */ 

UPDATE [NMMST_VW].[dbo].hmf101a
	SET hmf101a_certid = (SELECT hmf101a_certid FROM inserted), 
        hmf101a_name = (SELECT hmf101a_name FROM inserted), 
        hmf101a_stop = (SELECT hmf101a_stop FROM inserted), 
        hmf101a_ps = null, hmf101a_aid = (SELECT hmf101a_aid FROM inserted), hmf101a_adt = (SELECT hmf101a_adt FROM inserted), hmf101a_uid = (SELECT hmf101a_uid FROM inserted), hmf101a_udt = (SELECT hmf101a_udt FROM inserted)
	WHERE hmf101a_certid = (SELECT hmf101a_certid FROM deleted)

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


GO
