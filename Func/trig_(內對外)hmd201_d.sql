use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmd201_d' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmd201_d
GO


CREATE TRIGGER trig_hmd201_d
ON hmd201
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
DELETE FROM [NMMST_VW].[dbo].[hmd201]
WHERE hmd201_vid = (SELECT hmd201_vid FROM deleted);

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
