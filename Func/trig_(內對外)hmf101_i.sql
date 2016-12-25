USE [NMMST_HR]
GO
/****** 物件:  Trigger [dbo].[trig_hmf101_i]    指令碼日期: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmf101_i]
ON [dbo].[hmf101]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO [NMMST_VW].[dbo].[hmf101]
   SELECT hmf101_courseid, hmf101_name, hmf101_coursetype, hmf101_hourse, 
          hmf101_openfor, hmf101_force, null, hmf101_aid, hmf101_adt, hmf101_uid, hmf101_udt
   FROM inserted

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


