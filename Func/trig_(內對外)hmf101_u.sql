use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmf101_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmf101_u
GO


CREATE TRIGGER trig_hmf101_u
ON hmf101

FOR UPDATE
AS 

IF @@rowcount <> 1 RETURN

-- �P�_���ʸ����줣���u�s�եN�X�v�h���B�z
--IF (SELECT RTrim(s01_grp_id) FROM inserted) = (SELECT RTrim(s01_grp_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �ק�m�t���v���s�ըϥΪ̡Vsys02�n��檺��ơu�s�եN�X�v
UPDATE [NMMST_VW].[dbo].hmf101
	SET hmf101_courseid = (SELECT hmf101_courseid FROM inserted), 
hmf101_name = (SELECT hmf101_name FROM inserted), 
hmf101_coursetype = (SELECT hmf101_coursetype FROM inserted), 
hmf101_hourse = (SELECT hmf101_hourse FROM inserted), 
hmf101_openfor = (SELECT hmf101_openfor FROM inserted), 
hmf101_force = (SELECT hmf101_force FROM inserted), 
hmf101_ps = null, 
hmf101_aid = (SELECT hmf101_aid FROM inserted), 
hmf101_adt = (SELECT hmf101_adt FROM inserted), 
hmf101_uid = (SELECT hmf101_uid FROM inserted), 
hmf101_udt = (SELECT hmf101_udt FROM inserted)
	WHERE hmf101_courseid = (SELECT hmf101_courseid FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END


GO
