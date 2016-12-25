use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmf102_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmf102_u
GO


CREATE TRIGGER trig_hmf102_u
ON hmf102

FOR UPDATE
AS 

IF @@rowcount <> 1 RETURN

-- �P�_���ʸ����줣���u�s�եN�X�v�h���B�z
--IF (SELECT RTrim(s01_grp_id) FROM inserted) = (SELECT RTrim(s01_grp_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �ק�m�t���v���s�ըϥΪ̡Vsys02�n��檺��ơu�s�եN�X�v
UPDATE [NMMST_VW].[dbo].hmf102
	SET hmf102_trainid = (SELECT hmf102_trainid FROM inserted), 
hmf102_courseid = (SELECT hmf102_courseid FROM inserted), 
hmf102_teacher = (SELECT hmf102_teacher FROM inserted), 
hmf102_liser = (SELECT hmf102_liser FROM inserted), 
hmf102_sdate = (SELECT hmf102_sdate FROM inserted), 
hmf102_starttime = (SELECT hmf102_starttime FROM inserted), 
hmf102_endtime = (SELECT hmf102_endtime FROM inserted), 
hmf102_placeid = (SELECT hmf102_placeid FROM inserted), 
hmf102_maxno = (SELECT hmf102_maxno FROM inserted), 
hmf102_rstime = (SELECT hmf102_rstime FROM inserted), 
hmf102_retime = (SELECT hmf102_retime FROM inserted), 
hmf102_ps = null, 
hmf102_aid = (SELECT hmf102_aid FROM inserted), 
hmf102_adt = (SELECT hmf102_adt FROM inserted), 
hmf102_uid = (SELECT hmf102_uid FROM inserted), 
hmf102_udt = (SELECT hmf102_udt FROM inserted)
	WHERE hmf102_trainid = (SELECT hmf102_trainid FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


GO
