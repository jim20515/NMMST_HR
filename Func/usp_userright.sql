use NMMST_HR
GO

-- =============================================
-- �N�w�s�b���w�s�{�ǧR��
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'usp_userright' 
	   AND 	  type = 'P')
    DROP PROCEDURE usp_userright
GO


CREATE PROCEDURE usp_userright(@as_userid varchar(20), @as_sysid varchar(10), @as_modid char(1) = '')

AS

/**************************************************
1. �{���y�z�G�����ަ@�Ψ禡�w�V�ϥΪ��v����ƲM��]�s���V�u���v���������h�^

2. �{���B�J�G(1)�q�m�t���v���s�վާ@ sys03�n�B�m�t�Τl�t�� sys05�n�M�m�t���v���s�ըϥΪ� sys02�n����X�������
   �@�@�@�@�@(2)�q�m�t���v���s�վާ@ sys03�n�M�m�t���v���s�ըϥΪ� sys02�n����X�������
   �@�@�@�@�@(3)�q�m�t�ξާ@ sys04�n����X������ơ]�ާ@�^��W�١B����W�١BURL�B���h�B�ާ@���O�^
   �@�@�@�@�@(4)�q�m�t�ξާ@ sys04�n����X������ơ]�D��ھާ@�A�ӬO����`�I��ơ^
   �@�@�@�@�@(5)�q�m�t�Τl�t�� sys05�n����X������ơ]�ҲեN�X�B�l�t�έ^��W�١B����W�١BURL�^
   �@�@�@�@�@(6)�q�m�t�μҲ� sys06�n����X������ơ]�ҲզW�١^

3. �ϥΤ覡�G(1)�ѼơG@as_userid		varchar(20)		�ϥΪ̱b��
   �@�@�@�@�@(2)�ѼơG@as_sysid			varchar(10)		�l�t�ΥN�X�V���X�����l�t���v��(menubar)�F
   �@�@�@�@�@   �@�@�@         			           		�@�@�@�@�@�@���X�Ĥ@�Ӥl�t�ξާ@�v��(menutree)�F
   �@�@�@�@�@   �@�@�@         			           		�@�@�@�@�@�@���X�����l�t�ξާ@�v��(�Ŧr��)�F
   �@�@�@�@�@   �@�@�@         			           		�@�@�@�@�@�@���X��Ӥl�t�ξާ@�v��(���w�l�t�ΥN�X)�V���Ҽ{�ҲեN�X
   �@�@�@�@�@(3)�ѼơG@as_modid			char(1)			�ҲեN�X�V���X�Ĥ@�ӼҲ��v��(0)�F
   �@�@�@�@�@   �@�@�@         			           		�@�@�@�@�@���X�����Ҳ��v��(�Ŧr��)�F
   �@�@�@�@�@   �@�@�@         			           		�@�@�@�@�@���X��ӼҲ��v��(���w�ҲեN�X)
   �@�@�@�@�@(4)�^�ǡG					table			�ϥΪ��v����ƲM��

4. ���g�H���Gfen

5. �ק����G2005/8/18
**************************************************/

                                                                      /* �� �ŧi���� �� */ 

-- ���G���Ȧs���
CREATE TABLE #userright
(   seq					smallint		null,		-- 1 �Ǹ�
	rid					varchar(20)		null,       -- 2 �v���N�X(�l�t�ΥN�X + �ާ@�N�X)
	mod_id				char(1)			null,       -- 3 �ҲեN�X
    mod_text			varchar(20)		null,       -- 4 �ҲզW��
    mod_img				varchar(255)	null,       -- 5 �Ҳչϥ�
    sys_id				varchar(10)		null,       -- 6 �l�t�ΥN�X
    sys_text			varchar(50)		null,       -- 7 �l�t�ΦW��
    sys_url				varchar(255)	null,       -- 8 �l�t�� URL(?menu_id=�l�t�ΥN�X)
    func_id				varchar(10)		null,       -- 9 �ާ@�N�X
    func_text			varchar(50)		null,       -- 10 �ާ@�W��
    func_url			varchar(255)	null,       -- 11 �ާ@ URL(?menu_id=�l�t�ΥN�X + '.' + �v���N�X)
    func_parent			varchar(10)		null,       -- 12 �ާ@���h
    func_flag			char(1)			null,       -- 13 �ާ@ flag
	upd_flag			char(1)			null,		-- 14 �i�ק� flag
	check_flag			char(1)			null		-- 15 �i�f�� flag
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

-- �p�G�S���ǤJ�l�t�ΥN�X�h���X�������
SELECT @as_sysid = IsNull(RTrim(@as_sysid), '')

-- �p�G�S���ǤJ�ҲեN�X�h���X�������
SELECT @as_modid = IsNull(RTrim(@as_modid), '')


/* --------------------------------------------------------------------------------------- 
   �q�m�t���v���s�վާ@ sys03�n�B�m�t�Τl�t�� sys05�n�M�m�t���v���s�ըϥΪ� sys02�n����X�������
--------------------------------------------------------------------------------------- */ 

-- ��X�ŦX���ҲեN�X
IF (Lower(@as_modid) = '0')							-- 2005/08/17, fen add ���X�Ĥ@�ӼҲ��v��
BEGIN
	-- ��X�Ĥ@�ӼҲեN�X
	SELECT @as_modid = Min(RTrim(s05_mod_id))
		FROM sys03, sys05
		WHERE (s03_grp_id in (SELECT s02_grp_id
									FROM sys02
									WHERE s02_user_id = @as_userid))
			AND (s03_sys_id = s05_sys_id)
			AND (IsNull(RTrim(s05_mod_id), '') <> '')

	SELECT @as_modid = IsNull(@as_modid, '')
END


/* --------------------------------------------------------------------------------------- 
   �q�m�t���v���s�վާ@ sys03�n�M�m�t���v���s�ըϥΪ� sys02�n����X�������
--------------------------------------------------------------------------------------- */ 

-- �� #userright �s�W�ϥΪ��v���ާ@���
IF (Lower(@as_sysid) = 'menubar')					-- 2004/06/14, fen add ���X�����l�t���v��
BEGIN	-- (1)
	INSERT INTO #userright (seq, rid, sys_id, func_id, func_flag)
		SELECT DISTINCT seq = 0,
						rid = RTrim(s03_sys_id),
						sys_id = RTrim(s03_sys_id),
						func_id = '',
						func_flag = 'S'
			FROM sys03
			WHERE (s03_grp_id in (SELECT s02_grp_id
										FROM sys02
										WHERE s02_user_id = @as_userid))
				AND (s03_sys_id in (SELECT s05_sys_id
										FROM sys05
										WHERE s05_mod_id = CASE WHEN @as_modid = '' THEN s05_mod_id ELSE @as_modid END))
	Goto Update_sys05
END
ELSE IF (Lower(@as_sysid) = 'menutree')				-- 2004/06/16, fen add ���X�Ĥ@�Ӥl�t�ξާ@�v���]�p�����w�Ҳիh���ҲղĤ@�Ӥl�t�Ρ^
BEGIN
	-- ��X�Ĥ@�Ӥl�t�ΥN�X
	SELECT @as_sysid = Min(RTrim(s03_sys_id))
		FROM sys03
		WHERE (s03_grp_id in (SELECT s02_grp_id
									FROM sys02
									WHERE s02_user_id = @as_userid))
			AND (s03_sys_id in (SELECT s05_sys_id
									FROM sys05
									WHERE s05_mod_id = CASE WHEN @as_modid = '' THEN s05_mod_id ELSE @as_modid END))

	SELECT @as_sysid = IsNull(@as_sysid, '')

	IF (@as_sysid <> '') Goto Find_sys03_singlesys
END
ELSE IF (@as_sysid = '')							-- 2004/06/14, fen add ���X�����l�t�ξާ@�v��
BEGIN
	INSERT INTO #userright (rid, sys_id, func_id, upd_flag, check_flag)
		SELECT DISTINCT rid = RTrim(s03_sys_id) + RTrim(s03_func_id),
			   			sys_id = RTrim(s03_sys_id),
			   			func_id = RTrim(s03_func_id),
			   			upd_flag = 'Y',
			   			check_flag = 'Y'
			FROM sys03
			WHERE (s03_grp_id in (SELECT s02_grp_id
										FROM sys02
										WHERE s02_user_id = @as_userid))
				AND (s03_sys_id in (SELECT s05_sys_id
										FROM sys05
										WHERE s05_mod_id = CASE WHEN @as_modid = '' THEN s05_mod_id ELSE @as_modid END))
END
ELSE												-- 2004/06/14, fen add ���X��Ӥl�t�ξާ@�v���V���Ҽ{�ҲեN�X
BEGIN
	Find_sys03_singlesys:
	INSERT INTO #userright (rid, sys_id, func_id, upd_flag, check_flag)
		SELECT DISTINCT rid = RTrim(s03_sys_id) + RTrim(s03_func_id),
			   			sys_id = RTrim(s03_sys_id),
			   			func_id = RTrim(s03_func_id),
			   			upd_flag = 'Y',
			   			check_flag = 'Y'
			FROM sys03
			WHERE (s03_grp_id in (SELECT s02_grp_id
										FROM sys02
										WHERE s02_user_id = @as_userid))
				AND (s03_sys_id = @as_sysid)
END


-- �� #userright �s�W�ϥΪ��v���l�t�θ��
INSERT INTO #userright (seq, rid, sys_id, func_id, func_flag)
	SELECT DISTINCT seq = 0,
					rid = sys_id,
					sys_id = sys_id,
					func_id = '',
					func_flag = 'S'
		FROM #userright


/* --------------------------------------------------------------------------------------- 
   �q�m�t�ξާ@ sys04�n����X�������
--------------------------------------------------------------------------------------- */ 

-- ��X #userright �l�t�ΥN�X�M�ާ@�N�X�ҹ������ާ@�^��W�١B����W�١BURL�B�h�šB�ާ@���O�Vsys04
UPDATE #userright
    SET seq = IsNull(s04_func_seq, 1),
		func_text = IsNull(RTrim(s04_func_text), ''),
		func_url = CASE WHEN IsNull(RTrim(s04_func_url), '') = '' THEN '' ELSE RTrim(s04_func_url) + '?menu_id=' + sys_id + '.' + rid END,
		func_parent = IsNull(RTrim(s04_func_parent), sys_id),
		func_flag = CASE WHEN IsNull(Upper(s04_func_flag), '') = 'N' THEN 'N' ELSE 'Y' END
    FROM sys04
    WHERE sys_id = s04_sys_id
		AND func_id = s04_func_id


-- �� #userright �s�W�D��ھާ@�A�ӬO����`�I��ơ]���v�������h�A�D�����^�V��������A�A�R���S���v����
INSERT INTO #userright (seq, rid, sys_id, func_id, func_text, func_url, func_parent, func_flag)
	SELECT seq = IsNull(s04_func_seq, 0),
		   rid = RTrim(s04_sys_id) + RTrim(s04_func_id),
		   sys_id = RTrim(s04_sys_id),
		   func_id = RTrim(s04_func_id),
		   func_text = IsNull(RTrim(s04_func_text), ''),
		   func_url = CASE WHEN IsNull(RTrim(s04_func_url), '') = '' THEN '' ELSE RTrim(s04_func_url) + '?menu_id=' + RTrim(s04_sys_id) + '.'  + RTrim(s04_sys_id) + RTrim(s04_func_id) END,
		   func_parent = IsNull(RTrim(s04_func_parent), RTrim(s04_sys_id)),
		   func_flag = 'N'
		FROM sys04
		WHERE (s04_sys_id in (SELECT DISTINCT sys_id FROM #userright))
			AND ((CASE WHEN IsNull(Upper(s04_func_flag), '') = 'N' THEN 'N' ELSE 'Y' END) = 'N')


-- �� #userright �R���D��ھާ@�A�ӬO����`�I��ơ]�S���v�������h�^
SELECT @ll_count = 1
WHILE @ll_count <= 5
BEGIN
	DELETE FROM #userright
		WHERE (NOT EXISTS (SELECT 1
								FROM #userright A
								WHERE A.func_parent = #userright.rid))
			AND (func_flag = 'N')
	SELECT @ll_count = @ll_count + 1
END


/* --------------------------------------------------------------------------------------- 
   �q�m�t�Τl�t�� sys05�n����X�������
--------------------------------------------------------------------------------------- */ 

Update_sys05:
-- ��X #userright �l�t�ΥN�X�ҹ������ҲեN�X�B�l�t�έ^��W�١B����W�١BURL�Vsys05
UPDATE #userright
    SET mod_id = IsNull(s05_mod_id, ''),
		sys_text = CASE WHEN func_flag = 'S' THEN IsNull(RTrim(s05_sys_text), '') ELSE Null END,
		sys_url = CASE WHEN func_flag = 'S' THEN CASE WHEN IsNull(RTrim(s05_sys_url), '') = '' THEN '' ELSE RTrim(s05_sys_url) + '?menu_id=' + sys_id END ELSE Null END,
		func_parent = CASE WHEN func_flag = 'S' THEN IsNull(s05_mod_id, '') ELSE func_parent END
    FROM sys05
    WHERE sys_id = s05_sys_id


-- �� #userright �s�W�ϥΪ��v���Ҳո��
INSERT INTO #userright (seq, rid, mod_id, sys_id, func_id, func_flag)
	SELECT DISTINCT seq = Null,
					rid = mod_id,
					mod_id = mod_id,
					sys_id = IsNull(Min(sys_id), ''),
					func_id = '',
					func_flag = 'M'
		FROM #userright
		WHERE func_flag = 'S'
		GROUP BY mod_id


/* --------------------------------------------------------------------------------------- 
   �q�m�t�μҲ� sys06�n����X�������
--------------------------------------------------------------------------------------- */ 

-- ��X #userright �ҲեN�X�ҹ������ҲզW�١B�ҲչϥܡVsys06
UPDATE #userright
    SET mod_text = IsNull(s06_mod_text, ''),
		mod_img = 'proj_img/g_Module.ico'
    FROM sys06
    WHERE mod_id = s06_mod_id
		AND func_flag = 'M'


-- �R�� #userright �����n�����
DELETE FROM #userright
    WHERE func_flag IS NULL


/* --------------------------------------------------------------------------------------- 
   �B�z�����V���X�m���G���Ȧs��� #userright�n�����
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- �q�m���G���Ȧs��� #userright�n���X���
	SELECT *
		FROM #userright
		ORDER BY mod_id ASC, sys_id ASC, seq ASC



GO


-- =============================================
-- ����禡�d��
-- =============================================

--EXEC dbo.usp_userright 'user', 'menubar'
--EXEC dbo.usp_userright 'user', 'menutree'
--EXEC dbo.usp_userright 'user', ''
--EXEC dbo.usp_userright 'user', 's01'
--EXEC dbo.usp_userright 'user', 'menubar', 'S'
--EXEC dbo.usp_userright 'user', 'menutree', 'S'
--EXEC dbo.usp_userright 'user', '', 'S'
--EXEC dbo.usp_userright 'user', 's01', 'S'
GO
