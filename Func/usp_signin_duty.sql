USE [NMMST_HR]
GO
-- =============================================
-- �N�w�s�b���w�s�{�ǧR��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'usp_signin_duty' 
	   AND 	  type = 'P')
    DROP PROCEDURE usp_signin_duty
GO

CREATE PROCEDURE usp_signin_duty(@as_empno char(9), @as_type char(1), @as_ip char(15))

AS

/**************************************************
1. �{���y�z�G��߮��v��޳ժ��]-�H�O�귽�t�ΡV�W�U�Z��d

2. �{���B�J�G(1)���~���������
   �@�@�@�@  (2)��ƪ�l��
   �@�@�@�@  (3)�q�m�Ӥu�D�� hmd201�n����X������ơV�Ӥu�m�W
   �@�@�@�@  (4)�q�m�Z�� tcat02�n����X�������
   �@�@�@�@     1. �q tcat02 ���X��ơV�ƯZ��b��d��e��@�Ѥ��������
   �@�@�@�@     2. �q #tmp_tcat02, para041 ���X��ơV�ƯZ�骺�W�U�Z�ɶ�
   �@�@�@�@     3. �P�_��d�������X���
   �@�@�@�@        a. �W�Z�]�U�Z�ɶ� > ��d�ɶ����̱���@���^
   �@�@�@�@        b. �U�Z�]�W�Z�ɶ� < ��d�ɶ����̱���@���^
   �@�@�@�@     4. �p�G�S���ŦX����ơA��ܷ�ѨS���Z��h�s��d��e�@�ѡF�_�h�h�s�ƯZ��
   �@�@�@�@  (5)��m��d���� tcat01�n���s�W���
   �@�@�@�@     1. �P�_ tcat01 ���P�@��d��W�@����ƬO�_���@�˪���d�����A�O�h�����\��d
   �@�@�@�@     2. �_�h�� tcat01 �s�W���
   �@�@�@�@  (6)���X�^�Ǹ��

3. �ϥΤ覡�G(1)�ѼơG@as_empno			char(9)			���u�s��
   �@�@�@�@�@(2)�ѼơG@as_type			char(1)			��d�����V�W�Z(1)�F�U�Z(2)
   �@�@�@�@�@(3)�ѼơG@as_ip			char(15)		��d��IP
   �@�@�@�@�@(4)�s�J�G					tabledata		��d���� tcat01 ���
   �@�@�@�@�@(5)�^�ǡG					table			��d�T�����

4. ���g�H���Gdemon

5. �ק����G2009/5/14
**************************************************/

/* �� �ŧi���� �� */ 

-- ##### �ŧi�ܼ� #####
DECLARE @ls_errmsg		varchar(255),				-- ���~�T��
		@ls_vid			varchar(12),				-- �Ӥu�N�X
		@ls_lid			varchar(20),				-- �O���N�X
		@ldt_time		datetime,					-- ��d�ɶ�
		@ls_empname		nvarchar(40),				-- ���u�m�W
		@ldt_date		datetime,					-- �u�@��
		@ldt_t02date	datetime,					-- �ƯZ��
		@li_t02shuor	int,					-- �}�l��
		@li_t02smin	int,					-- �}�l��
		@li_t02ehuor	int,					-- ������
		@li_t02emin	int					-- ������



/* �� �{������ �� */ 

/* --------------------------------------------------------------------------------------- 
   ���~���������
--------------------------------------------------------------------------------------- */ 

-- �p�G�S���ǤJ���u�s���h���B�z
SELECT @as_empno = IsNull(RTrim(@as_empno), '')
IF (Len(@as_empno) < 9)
BEGIN
	SELECT @ls_errmsg = '�ǤJ���Ӥu�s�������T'
	GOTO Exit_Result
END

-- �p�G�S���ǤJ��d�����h���B�z
SELECT @as_type = IsNull(RTrim(@as_type), '')
IF (@as_type <> '1' AND @as_type <> '2')
BEGIN
	SELECT @ls_errmsg = '�ǤJ����d���������T'
	GOTO Exit_Result
END


/* --------------------------------------------------------------------------------------- 
   ��ƪ�l��
--------------------------------------------------------------------------------------- */ 

-- ���o��d�ɶ�
SELECT @ldt_time = GetDate()

-- ���o�u�@��
SELECT @ldt_date = Convert(datetime, Convert(char(10), @ldt_time, 111))

-- ���o�Ӥu�s��
SELECT @ls_vid = 'V' + Left(@as_empno,3) + '-' + SubString(@as_empno , 4 , 2) + '-' + Right(@as_empno,4)


/* --------------------------------------------------------------------------------------- 
   �q�m�Ӥu�D�� hmd201�n����X�������
--------------------------------------------------------------------------------------- */ 

-- �q hmd201 ���X���
SELECT @ls_empname = hmd201_cname
	FROM hmd201
	WHERE hmd201_vid = @ls_vid

-- �p�G�S���ŦX����ƫh���}���B�z
IF (@@rowcount < 1)
BEGIN
	SELECT @ls_errmsg = '�D���Ī��Ӥu�s��'
	GOTO Exit_Result
END


/* --------------------------------------------------------------------------------------- 
   ��m��d���� hle201�n���s�W���
--------------------------------------------------------------------------------------- */ 

-- �P�_ hle201 ���P�@��d��W�@����ƬO�_���@�˪���d�����A�O�h�����\��d
IF (IsNull((SELECT TOP 1 hle201_type FROM hle201 WHERE hle201_vid = @ls_vid AND Convert(char(10), hle201_sdatetime, 111) = Convert(char(10), @ldt_time, 111) ORDER BY hle201_sdatetime DESC), '') = @as_type)
BEGIN
	IF (@as_type = '1')
		SELECT @ls_errmsg = '���i�s��ꢱ���W�Z�d�A�p���ðݽЬ����g���U�B�z'
	ELSE
		SELECT @ls_errmsg = '���i�s��ꢱ���U�Z�d�A�p���ðݽЬ����g���U�B�z'
	GOTO Exit_Result
END

IF (@as_type = '2')  -- �Y���U�Z���P�_�O�_��P��w��W�Z�d
BEGIN
	IF (IsNull((SELECT TOP 1 hle201_type FROM hle201 WHERE hle201_vid = @ls_vid AND Convert(char(10), hle201_sdatetime, 111) = Convert(char(10), @ldt_time, 111) ORDER BY hle201_sdatetime DESC), '') <> '1' )
		SELECT @ls_errmsg = '�|�L��W�Z�d�A�L�k��J�U�Z�d�C�Ь��߳��g���U�ɵn'
END



--�u�����
SELECT @ldt_time = Convert(datetime, Convert(char(10), @ldt_time, 111) + ' ' + Convert(varchar(2), DATEPART(hh, @ldt_time)) + ':' + Convert(varchar(2), DATEPART(mi, @ldt_time)) + ':0')

-- ���o�̤j��d�s��
Select @ls_lid = 'Slog' + Right( '000000000' + Cast( Cast( IsNull(Max(Right(hle201_lid,9)),'000000000') as int ) + 1 as varchar(10)) , 9 )
From hle201 

-- �� hle201 �s�W���
INSERT INTO hle201 (hle201_lid, hle201_vid, hle201_sdatetime, hle201_type, hle201_ps, hle201_cancel , hle201_checkflag , hle201_ip , hle201_cway , hle201_aid , hle201_adt , hle201_uid , hle201_udt)
	VALUES (@ls_lid, @ls_vid, @ldt_time, @as_type, '�ȶ�' , 'N' , 'N' , @as_ip , '1' , 'system' , getdate() , 'system' , getdate() )

-- �P�_�p�G���ѫh���}
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	SELECT @ls_errmsg = '�s�W��d��������'
	GOTO Exit_Result
END


/* --------------------------------------------------------------------------------------- 
   �B�z�����V���X�^�Ǹ��
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- ���X�^�Ǹ��
	SELECT errmsg = @ls_errmsg, empno = @ls_vid , empname = @ls_empname, [type] = @as_type, [date] = @ldt_date, [time] = @ldt_time

GO


-- =============================================
-- ����禡�d��
-- =============================================

--EXEC dbo.usp_signin_duty '098010017', '2', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00052162', '2', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00052788', '1', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00052788', '2', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00051888', '1', '10.100.1.15'
--EXEC dbo.usp_signin_duty '10011914', '1', '10.100.1.15'
GO
