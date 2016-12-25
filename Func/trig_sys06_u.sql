use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_sys06_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_sys06_u
GO


CREATE TRIGGER trig_sys06_u
ON sys06

FOR UPDATE
AS 

/**************************************************
1. �{���y�z�G��t�μҲաVsys06 �ק��Ʈɩҭn�����B�z

2. �{���B�J�G(0)�{�����ݰ������G���ʸ�Ƥ����� 1 ���h���B�z
   �@�@�@�@�@(1)�ק�m�t�Τl�t�ΡVsys05�n��檺��ơu�ҲեN�X�v�A���ѫh�P�w�x�s����

3. ���g�H���Gfen

4. �ק����G2004/6/14
**************************************************/

/* --------------------------------------------------------------------------------------- 
   �{�����ݰ������
--------------------------------------------------------------------------------------- */ 

-- ���ʸ�Ƥ����� 1 ���h���B�z
IF @@rowcount <> 1 RETURN

-- �P�_���ʸ����줣���u�ҲեN�X�v�h���B�z
IF (SELECT RTrim(s06_mod_id) FROM inserted) = (SELECT RTrim(s06_mod_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �ק�m�t�Τl�t�ΡVsys05�n��檺��ơu�ҲեN�X�v
UPDATE sys05
	SET s05_mod_id = (SELECT s06_mod_id FROM inserted)
	WHERE s05_mod_id = (SELECT s06_mod_id FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
