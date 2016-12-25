USE [NMMST_HR]
GO
/****** 物件:  Trigger [dbo].[trig_hmf101a_i]    指令碼日期: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmf101a_i]
ON [dbo].[hmf101a]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO [NMMST_VW].[dbo].[hmf101a]
   SELECT  hmf101a_certid, hmf101a_name, hmf101a_stop, null, hmf101a_aid, hmf101a_adt, hmf101a_uid, hmf101a_udt
   FROM inserted

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


