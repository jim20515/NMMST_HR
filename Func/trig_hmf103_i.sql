USE [NMMST_HR]
GO
/****** 物件:  Trigger [dbo].[trig_hmf103_i]    指令碼日期: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmf103_i]
ON [dbo].[hmf103]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO hmf302
   SELECT hmf103_trainid, hmf103_vid, null, null, null,
          hmf103_aid, hmf103_adt, hmf103_uid, hmf103_udt
   FROM inserted

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


