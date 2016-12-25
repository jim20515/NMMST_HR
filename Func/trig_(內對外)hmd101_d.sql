use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_hmd101_d' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_hmd101_d
GO


CREATE TRIGGER trig_hmd101_d
ON hmd101
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
DELETE FROM [NMMST_VW].[dbo].[hmd101]
WHERE hmd101_tid = (SELECT hmd101_tid FROM deleted);

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
