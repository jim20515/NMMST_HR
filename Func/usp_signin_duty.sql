USE [NMMST_HR]
GO
-- =============================================
-- 將已存在的預存程序刪除
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
1. 程式描述：國立海洋科技博物館-人力資源系統–上下班刷卡

2. 程式步驟：(1)錯誤的執行條件
   　　　　  (2)資料初始化
   　　　　  (3)從《志工主檔 hmd201》中找出相關資料–志工姓名
   　　　　  (4)從《班表 tcat02》中找出相關資料
   　　　　     1. 從 tcat02 取出資料–排班日在刷卡日前後一天之內的資料
   　　　　     2. 從 #tmp_tcat02, para041 取出資料–排班日的上下班時間
   　　　　     3. 判斷刷卡種類取出資料
   　　　　        a. 上班（下班時間 > 刷卡時間的最接近一筆）
   　　　　        b. 下班（上班時間 < 刷卡時間的最接近一筆）
   　　　　     4. 如果沒有符合的資料，表示當天沒有班表則存刷卡日前一天；否則則存排班日
   　　　　  (5)到《刷卡紀錄 tcat01》中新增資料
   　　　　     1. 判斷 tcat01 中同一刷卡日上一筆資料是否為一樣的刷卡種類，是則不允許刷卡
   　　　　     2. 否則到 tcat01 新增資料
   　　　　  (6)取出回傳資料

3. 使用方式：(1)參數：@as_empno			char(9)			員工編號
   　　　　　(2)參數：@as_type			char(1)			刷卡種類–上班(1)；下班(2)
   　　　　　(3)參數：@as_ip			char(15)		刷卡機IP
   　　　　　(4)存入：					tabledata		刷卡紀綠 tcat01 資料
   　　　　　(5)回傳：					table			刷卡訊息資料

4. 撰寫人員：demon

5. 修改日期：2009/5/14
**************************************************/

/* ☆ 宣告部份 ☆ */ 

-- ##### 宣告變數 #####
DECLARE @ls_errmsg		varchar(255),				-- 錯誤訊息
		@ls_vid			varchar(12),				-- 志工代碼
		@ls_lid			varchar(20),				-- 記錄代碼
		@ldt_time		datetime,					-- 刷卡時間
		@ls_empname		nvarchar(40),				-- 員工姓名
		@ldt_date		datetime,					-- 工作天
		@ldt_t02date	datetime,					-- 排班日
		@li_t02shuor	int,					-- 開始時
		@li_t02smin	int,					-- 開始分
		@li_t02ehuor	int,					-- 結束時
		@li_t02emin	int					-- 結束分



/* ☆ 程式部份 ☆ */ 

/* --------------------------------------------------------------------------------------- 
   錯誤的執行條件
--------------------------------------------------------------------------------------- */ 

-- 如果沒有傳入員工編號則不處理
SELECT @as_empno = IsNull(RTrim(@as_empno), '')
IF (Len(@as_empno) < 9)
BEGIN
	SELECT @ls_errmsg = '傳入的志工編號不正確'
	GOTO Exit_Result
END

-- 如果沒有傳入刷卡種類則不處理
SELECT @as_type = IsNull(RTrim(@as_type), '')
IF (@as_type <> '1' AND @as_type <> '2')
BEGIN
	SELECT @ls_errmsg = '傳入的刷卡種類不正確'
	GOTO Exit_Result
END


/* --------------------------------------------------------------------------------------- 
   資料初始化
--------------------------------------------------------------------------------------- */ 

-- 取得刷卡時間
SELECT @ldt_time = GetDate()

-- 取得工作天
SELECT @ldt_date = Convert(datetime, Convert(char(10), @ldt_time, 111))

-- 取得志工編號
SELECT @ls_vid = 'V' + Left(@as_empno,3) + '-' + SubString(@as_empno , 4 , 2) + '-' + Right(@as_empno,4)


/* --------------------------------------------------------------------------------------- 
   從《志工主檔 hmd201》中找出相關資料
--------------------------------------------------------------------------------------- */ 

-- 從 hmd201 取出資料
SELECT @ls_empname = hmd201_cname
	FROM hmd201
	WHERE hmd201_vid = @ls_vid

-- 如果沒有符合的資料則離開不處理
IF (@@rowcount < 1)
BEGIN
	SELECT @ls_errmsg = '非有效的志工編號'
	GOTO Exit_Result
END


/* --------------------------------------------------------------------------------------- 
   到《刷卡紀錄 hle201》中新增資料
--------------------------------------------------------------------------------------- */ 

-- 判斷 hle201 中同一刷卡日上一筆資料是否為一樣的刷卡種類，是則不允許刷卡
IF (IsNull((SELECT TOP 1 hle201_type FROM hle201 WHERE hle201_vid = @ls_vid AND Convert(char(10), hle201_sdatetime, 111) = Convert(char(10), @ldt_time, 111) ORDER BY hle201_sdatetime DESC), '') = @as_type)
BEGIN
	IF (@as_type = '1')
		SELECT @ls_errmsg = '不可連續刷２次上班卡，如有疑問請洽單位經辦協助處理'
	ELSE
		SELECT @ls_errmsg = '不可連續刷２次下班卡，如有疑問請洽單位經辦協助處理'
	GOTO Exit_Result
END

IF (@as_type = '2')  -- 若為下班須判斷是否於同日已刷上班卡
BEGIN
	IF (IsNull((SELECT TOP 1 hle201_type FROM hle201 WHERE hle201_vid = @ls_vid AND Convert(char(10), hle201_sdatetime, 111) = Convert(char(10), @ldt_time, 111) ORDER BY hle201_sdatetime DESC), '') <> '1' )
		SELECT @ls_errmsg = '尚無刷上班卡，無法刷入下班卡。請洽詢單位經辦協助補登'
END



--只取到分
SELECT @ldt_time = Convert(datetime, Convert(char(10), @ldt_time, 111) + ' ' + Convert(varchar(2), DATEPART(hh, @ldt_time)) + ':' + Convert(varchar(2), DATEPART(mi, @ldt_time)) + ':0')

-- 取得最大刷卡編號
Select @ls_lid = 'Slog' + Right( '000000000' + Cast( Cast( IsNull(Max(Right(hle201_lid,9)),'000000000') as int ) + 1 as varchar(10)) , 9 )
From hle201 

-- 到 hle201 新增資料
INSERT INTO hle201 (hle201_lid, hle201_vid, hle201_sdatetime, hle201_type, hle201_ps, hle201_cancel , hle201_checkflag , hle201_ip , hle201_cway , hle201_aid , hle201_adt , hle201_uid , hle201_udt)
	VALUES (@ls_lid, @ls_vid, @ldt_time, @as_type, '值勤' , 'N' , 'N' , @as_ip , '1' , 'system' , getdate() , 'system' , getdate() )

-- 判斷如果失敗則離開
IF @@ERROR <> 0
BEGIN
	ROLLBACK
	SELECT @ls_errmsg = '新增刷卡紀錄失敗'
	GOTO Exit_Result
END


/* --------------------------------------------------------------------------------------- 
   處理完畢–取出回傳資料
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- 取出回傳資料
	SELECT errmsg = @ls_errmsg, empno = @ls_vid , empname = @ls_empname, [type] = @as_type, [date] = @ldt_date, [time] = @ldt_time

GO


-- =============================================
-- 執行函式範例
-- =============================================

--EXEC dbo.usp_signin_duty '098010017', '2', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00052162', '2', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00052788', '1', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00052788', '2', '10.100.1.15'
--EXEC dbo.usp_signin_duty '00051888', '1', '10.100.1.15'
--EXEC dbo.usp_signin_duty '10011914', '1', '10.100.1.15'
GO
