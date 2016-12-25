USE [NMMST_HR]
GO
/****** ����:  Trigger [dbo].[trig_hmf101b_i]    ���O�X���: 06/03/2009 12:37:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trig_hmf101b_i]
ON [dbo].[hmf101b]

FOR INSERT
AS 

IF @@rowcount <> 1 RETURN

INSERT INTO [NMMST_VW].[dbo].[hmf101b]
   SELECT hmf101b_certid, hmf101b_courseid, hmf101b_aid, hmf101b_adt, hmf101b_uid, hmf101b_udt
   FROM inserted

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


