use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_sys04_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_sys04_u
GO


CREATE TRIGGER trig_sys04_u
ON sys04

FOR UPDATE
AS 

/**************************************************
1. �{���y�z�G��t�ξާ@�Vsys04 �ק��Ʈɩҭn�����B�z

2. �{���B�J�G(0)�{�����ݰ������G���ʸ�Ƥ����� 1 ���h���B�z
   �@�@�@�@�@(1)�ק�m�t���v���s�վާ@�Vsys03�n��檺��ơu�l�t�ΥN�X�v�M�u�ާ@�N�X�v�A���ѫh�P�w�x�s����

3. ���g�H���Gfen

4. �ק����G2004/6/14
**************************************************/

/* --------------------------------------------------------------------------------------- 
   �{�����ݰ������
--------------------------------------------------------------------------------------- */ 

-- ���ʸ�Ƥ����� 1 ���h���B�z
IF @@rowcount <> 1 RETURN

-- �P�_���ʸ����줣���u�l�t�ΥN�X�v�Ρu�ާ@�N�X�v�h���B�z
IF (SELECT RTrim(s04_sys_id) + RTrim(s04_func_id) FROM inserted) = (SELECT RTrim(s04_sys_id) + RTrim(s04_func_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �ק�m�t���v���s�վާ@�Vsys03�n��檺��ơu�l�t�ΥN�X�v�M�u�ާ@�N�X�v
UPDATE sys03
	SET s03_sys_id = (SELECT s04_sys_id FROM inserted),
		s03_func_id = (SELECT s04_func_id FROM inserted)
	WHERE s03_sys_id + s03_func_id = (SELECT s04_sys_id + s04_func_id FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
