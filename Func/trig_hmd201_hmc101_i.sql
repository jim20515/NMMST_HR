USE [NMMST_HR]
GO
/****** 物件:  Trigger [dbo].[trig_hmd201_i]    指令碼日期: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmd201_hmc101_i' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmd201_hmc101_i
GO

CREATE TRIGGER [dbo].[trig_hmd201_hmc101_i]
ON [dbo].[hmd201]

FOR INSERT
AS 

-- =============================================
-- 先前比對的例外跳出區
-- =============================================

  --同時處理的筆數超過一個就跳出
  IF @@rowcount <> 1 RETURN

  --如果處理的資料有某欄是特定值，那就跳出

-- =============================================
-- 觸發以下事件
-- =============================================
-- 變數設定

DECLARE @PKV1 as varchar(50);
SET @PKV1 = (SELECT hmd201_vid FROM inserted);


-- =============================================

INSERT INTO hmc101
SELECT  
hmd201_id,
hmd201_cname,
hmd201_gent,
hmd201_bday,
hmd201_SSN,
null,
hmd201_eduid,
hmd201_jobid,
hmd201_joborg,
null,
hmd201_jobtitle,
hmd201_addid,
hmd201_addot,
hmd201_email,
hmd201_phnow,
hmd201_phnowex,
hmd201_phnoa,
hmd201_phnom,
null,
hmd201_memberid,
hmd201_memberpwd,
hmd201_passed,
hmd201_rejectepaper,
hmd201_ps,
hmd201_notel,
hmd201_expert,
(CASE hmd201_status WHEN '2' THEN 'Y' ELSE 'N' END),
hmd201_aid,
hmd201_adt,
hmd201_uid,
hmd201_udt
FROM hmd201 
WHERE  hmd201_vid = @PKV1

--WHERE O0o0O_PK = @PKV;

-- =============================================
-- 如果發生失敗的話，則Rollback後離開
-- =============================================
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

