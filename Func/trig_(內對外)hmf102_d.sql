use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmf102_d' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmf102_d
GO


CREATE TRIGGER trig_hmf102_d
ON hmf102
FOR DELETE
AS 


/* --------------------------------------------------------------------------------------- 
   �{�����ݰ������
--------------------------------------------------------------------------------------- */ 

-- ���ʸ�Ƥ����� 1 ���h���B�z
IF @@rowcount <> 1 RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �R���m�t���v���s�ըϥΪ̡Vsys02�n��檺���
DELETE FROM [NMMST_VW].[dbo].[hmf102]
WHERE hmf102_trainid = (SELECT hmf102_trainid FROM deleted);

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
