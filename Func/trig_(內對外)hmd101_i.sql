USE [NMMST_HR]
GO
/****** ����:  Trigger [dbo].[trig_hmd101_i]    ���O�X���: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmd101_i]
ON [dbo].[hmd101]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO [NMMST_VW].[dbo].[hmd101]
   SELECT hmd101_tid,hmd101_tname,'',hmd101_stop,hmd101_aid,hmd101_adt,hmd101_uid,hmd101_udt
   FROM inserted

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


