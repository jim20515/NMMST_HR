USE [NMMST_VW]
GO
/****** 物件:  Trigger [dbo].[trig_hmd201_t_i]    指令碼日期: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmd201_t_i]
ON [dbo].[hmd201_t]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO [NMMST_HR].[dbo].[hmd201_t]
   SELECT hmd201_vid, hmd201_id, hmd201_cname, hmd201_gent,
          hmd201_bday, hmd201_SSN, hmd201_eduid, hmd201_jobid, hmd201_joborg,
          hmd201_jobtitle, hmd201_addid, hmd201_addot, hmd201_email,
          hmd201_phnow, hmd201_phnowex, hmd201_phnoa, hmd201_phnom,
          hmd201_memberid, hmd201_memberpwd, hmd201_passed,
          hmd201_rejectepaper, null, null, null, hmd201_tid, hmd201_account, hmd201_pwd,
          hmd201_ssntype, hmd201_bookid, hmd201_weburl, null,
          hmd201_lvid, hmd201_status, hmd201_workday,
          hmd201_lappdt, hmd201_creatway, null, hmd201_filetype, 
          hmd201_enCodeID, hmd201_aid, hmd201_adt, hmd201_uid, hmd201_udt
   FROM inserted

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


