USE [NMMST_HR]
GO
/****** 物件:  Trigger [dbo].[trig_hmf102_i]    指令碼日期: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmf102_i]
ON [dbo].[hmf102]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO [NMMST_VW].[dbo].[hmf102]
   SELECT hmf102_trainid, hmf102_courseid, hmf102_teacher, hmf102_liser, hmf102_sdate, hmf102_starttime, hmf102_endtime, hmf102_placeid, hmf102_maxno, hmf102_rstime, hmf102_retime, null, hmf102_aid, hmf102_adt, hmf102_uid, hmf102_udt
   FROM inserted

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


