use NMMST_HR
GO

-- =============================================
-- �N�w�s�b�� Trigger �R��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'trig_sys01_u' 
	   AND 	  type = 'TR')
    DROP TRIGGER trig_sys01_u
GO


CREATE TRIGGER trig_sys01_u
ON sys01

FOR UPDATE
AS 

/**************************************************
1. �{���y�z�G��t���v���s�աVsys01 �ק��Ʈɩҭn�����B�z

2. �{���B�J�G(0)�{�����ݰ������G���ʸ�Ƥ����� 1 ���h���B�z
   �@�@�@�@�@(1)�ק�m�t���v���s�ըϥΪ̡Vsys02�n��檺��ơu�s�եN�X�v�A���ѫh�P�w�x�s����
   �@�@�@�@�@(2)�ק�m�t���v���s�վާ@�Vsys03�n��檺��ơu�s�եN�X�v�A���ѫh�P�w�x�s����

3. ���g�H���Gfen

4. �ק����G2004/6/14
**************************************************/

/* --------------------------------------------------------------------------------------- 
   �{�����ݰ������
--------------------------------------------------------------------------------------- */ 

-- ���ʸ�Ƥ����� 1 ���h���B�z
IF @@rowcount <> 1 RETURN

-- �P�_���ʸ����줣���u�s�եN�X�v�h���B�z
IF (SELECT RTrim(s01_grp_id) FROM inserted) = (SELECT RTrim(s01_grp_id) FROM deleted) RETURN


/* --------------------------------------------------------------------------------------- 
   �{���}�l����
--------------------------------------------------------------------------------------- */ 

-- �ק�m�t���v���s�ըϥΪ̡Vsys02�n��檺��ơu�s�եN�X�v
UPDATE sys02
	SET s02_grp_id = (SELECT s01_grp_id FROM inserted)
	WHERE s02_grp_id = (SELECT s01_grp_id FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

-- �ק�m�t���v���s�վާ@�Vsys03�n��檺��ơu�s�եN�X�v
UPDATE sys03
	SET s03_grp_id = (SELECT s01_grp_id FROM inserted)
	WHERE s03_grp_id = (SELECT s01_grp_id FROM deleted)

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	RETURN
END

GO
