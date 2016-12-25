use NMMST_HR
GO

-- =============================================
-- �N�w�s�b���w�s�{�ǧR��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'usp_userright_func' 
	   AND 	  type = 'P')
    DROP PROCEDURE usp_userright_func
GO


CREATE PROCEDURE usp_userright_func(@as_userid varchar(20), @as_sysid varchar(10), @as_funcid varchar(10), @ab_showparent bit = 0)

AS

/**************************************************
1. �{���y�z�G�����ަ@�Ψ禡�w�V�ϥΪ��v����@�ާ@���ظ�ƲM��

2. �{���B�J�G(1)�q�m�t���v���s�վާ@ sys03�n�B�m�t�ξާ@ sys04�n�M�m�t���v���s�ըϥΪ� sys02�n����X�������

3. �ϥΤ覡�G(1)�ѼơG@as_userid		varchar(20)		�ϥΪ̱b��
   �@�@�@�@�@(2)�ѼơG@as_sysid			varchar(10)		�l�t�ΥN�X
   �@�@�@�@�@(3)�ѼơG@as_funcid		varchar(10)		�ާ@�N�X
   �@�@�@�@�@(4)�ѼơG@ab_showparent	bit				��ܤ��h��ơV���(1)�F�����(0)(�w�]��)
   �@�@�@�@�@(5)�^�ǡG					table			�ϥΪ��v����@�ާ@���ظ�ƲM��

4. ���g�H���Gfen

5. �ק����G2007/9/26
**************************************************/

                                                                      /* �� �ŧi���� �� */ 

-- ���G���Ȧs���
CREATE TABLE #userright_func
(   rid					varchar(20)		null,       -- 1 �v���N�X(�l�t�ΥN�X + �ާ@�N�X)
	sys_id				varchar(10)		null,       -- 2 �l�t�ΥN�X
    sys_text			varchar(50)		null,       -- 3 �l�t�ΦW��
    func_id				varchar(10)		null,       -- 4 �ާ@�N�X
    func_text			varchar(50)		null,       -- 5 �ާ@�W��
    func_url			varchar(255)	null,       -- 6 �ާ@ URL
    func_parent			varchar(10)		null,       -- 7 �ާ@���h
    func_flag			char(1)			null,       -- 8 �ާ@ flag
    func_item			varchar(255)	null,       -- 9 �ާ@����
	upd_flag			char(1)			null,		-- 10 �i�ק� flag
	check_flag			char(1)			null,		-- 11 �i�f�� flag
	func_level			smallint		null		-- 12 �ާ@�h��
)


-- ##### �ŧi�ܼ� #####
DECLARE @ll_count			int				-- �p�q��



                                                                      /* �� �{������ �� */ 

/* --------------------------------------------------------------------------------------- 
   ���~���������
--------------------------------------------------------------------------------------- */ 

-- �p�G�S���ǤJ�ϥΪ̱b���h���B�z
SELECT @as_userid = RTrim(@as_userid)
IF (IsNull(@as_userid, '') = '') GOTO Exit_Result

-- �p�G�S���ǤJ�l�t�ΥN�X�h���B�z
SELECT @as_sysid = RTrim(@as_sysid)
IF (IsNull(@as_sysid, '') = '') GOTO Exit_Result

-- �p�G�S���ǤJ�ާ@�N�X�h���B�z
SELECT @as_funcid = RTrim(@as_funcid)
IF (IsNull(@as_funcid, '') = '') GOTO Exit_Result


/* --------------------------------------------------------------------------------------- 
   �q�m�t���v���s�վާ@ sys03�n�B�m�t�ξާ@ sys04�n�M�m�t���v���s�ըϥΪ� sys02�n����X�������
--------------------------------------------------------------------------------------- */ 

-- �� #userright_func �s�W�ϥΪ��v����@�ާ@���ظ��
INSERT INTO #userright_func
	SELECT DISTINCT rid = RTrim(s03_sys_id) + RTrim(s03_func_id), 
						  sys_id = RTrim(s03_sys_id), 
						  sys_text = (SELECT sys05.s05_sys_text FROM sys05 WHERE sys05.s05_sys_id = sys03.s03_sys_id), 
						  func_id = RTrim(s03_func_id), 
						  func_text = s04_func_text, 
						  func_url = s04_func_url, 
						  func_parent = s04_func_parent, 
						  func_flag = s04_func_flag, 
						  func_item = IsNull(RTrim(s04_func_item), ''), 
						  upd_flag = 'Y', 
						  check_flag = 'Y',
						  func_level = 1
		FROM sys03, sys04 
		WHERE (sys03.s03_sys_id = sys04.s04_sys_id) 
			AND (sys03.s03_func_id = sys04.s04_func_id) 
			AND ((sys03.s03_grp_id in (SELECT s02_grp_id
											FROM sys02
											WHERE s02_user_id = @as_userid)) 
			AND (sys03.s03_sys_id = @as_sysid) 
			AND (sys03.s03_func_id = @as_funcid))

-- �p�G�S���ŦX����ƫh���B�z
IF (@@rowcount = 0) GOTO Exit_Result


-- �� #userright_func �s�W�D��ھާ@�A�ӬO����`�I��ơ]���h�^
IF (@ab_showparent = 1)
BEGIN	-- (1)
	SELECT @ll_count = 1
	WHILE @ll_count <= 5
	BEGIN
		INSERT INTO #userright_func
			SELECT DISTINCT rid = RTrim(s04_sys_id) + RTrim(s04_func_id), 
							sys_id = RTrim(s04_sys_id), 
							sys_text = Null, 
							func_id = RTrim(s04_func_id), 
							func_text = s04_func_text, 
							func_url = s04_func_url, 
							func_parent = s04_func_parent, 
							func_flag = s04_func_flag, 
							func_item = IsNull(RTrim(s04_func_item), ''), 
							upd_flag = 'Y', 
							check_flag = 'Y',
							func_level = @ll_count + 1
				FROM sys04
				WHERE (EXISTS (SELECT 1
									FROM #userright_func A
									WHERE A.func_parent = RTrim(sys04.s04_sys_id) + RTrim(sys04.s04_func_id)
										AND A.func_level = @ll_count))
	
		-- �p�G�S���ŦX����ƫh���B�z
		IF (@@rowcount = 0) GOTO Exit_Result
	
		SELECT @ll_count = @ll_count + 1
	END
END		-- (1)


/* --------------------------------------------------------------------------------------- 
   �B�z�����V���X�m���G���Ȧs��� #userright_func�n�����
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- �q�m���G���Ȧs��� #userright_func�n���X���
	SELECT *
		FROM #userright_func
		ORDER BY func_level, upd_flag DESC, check_flag DESC



GO


-- =============================================
-- ����禡�d��
-- =============================================

--EXEC dbo.usp_userright_func 'user', 'a01', '01'
--EXEC dbo.usp_userright_func 'user', 'a01', '0302', 0
--EXEC dbo.usp_userright_func 'user', 'a01', '0302', 1
GO
