use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_user01_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_user01_u
GO


CREATE TRIGGER trig_user01_u
ON user01

FOR UPDATE
AS 

/**************************************************
1. �{���y�z�G��ϥΪ̱b���Vuser01 �ק��Ʈɩҭn�����B�z

2. �{���B�J�G(0)�{�����ݰ������G���ʸ�Ƥ����� 1 ���h���B�z
   �@�@�@�@�@(1)�ק�m�ϥΪ̱b���ϥΪ̡Vsys02�n��檺��ơu�ϥΪ̱b���v�A���ѫh�P�w�x�s����

3. ���g�H���Gfen

4. �ק����G2006/5/15
**************************************************/

/* --------------------------------------------------------------------------------------- 
   �{�����ݰ������
--------------------------------------------------------------------------------------- */ 

-- ���ʸ�Ƥ����� 1 ���h���B�z
IF @@rowcount <> 1 RETURN

-- �P�_���ʸ����줣���u�ϥΪ̱b���v�h���B�z
IF (SELECT RTrim(user01_id) FROM inserted) = (SELECT RTrim(user01_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �ק�m�ϥΪ̱b���ϥΪ̡Vsys02�n��檺��ơu�ϥΪ̱b���v
UPDATE sys02
	SET s02_user_id = (SELECT user01_id FROM inserted)
	WHERE s02_user_id = (SELECT user01_id FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
