use NMMST_HR
GO


-- =============================================
-- 將已存在的預存程序刪除
-- =============================================
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'usp_r_g0102'
	   AND 	  type = 'P')
    DROP PROCEDURE usp_r_g0102
GO


CREATE PROCEDURE usp_r_g0102(	
								@as_kid			Varchar(20),
								@adt_s			DateTime,
								@adt_e			DateTime
                        	)

AS

/**************************************************
1. 程式描述：海科館人力資源系統 – 考核獎懲管理 - 考核表

2. 程式步驟：(1)錯誤的執行條件
			 (2)取出需考核人員，計算相關資料
			 (3)取出暫存表格

3. 使用方式：(1)參數：@as_kid			Varchar(20)		考核主檔代碼
			 (2)      @adt_s			DateTime		發文日起
			 (3)      @adt_e			DateTime        發文日迄

   　　　　　(4)回傳：					tabledata		考核表

4. 撰寫人員：demon

5. 修改日期：2009/05/11
**************************************************/

                                                                      /* ☆ 宣告部份 ☆ */ 

-- 結果的暫存表格
CREATE TABLE #tmp_result
(	kname				nvarchar(255)		null,	-- 1  考核表名稱
    vid					nvarchar(20)		null,	-- 2  志工代碼
	tid					nvarchar(20)		null,	-- 3  志工隊代碼
	tname				nvarchar(10)		null,	-- 4  志工隊名稱
	cname				varchar(10)			null,	-- 5  志工性名
	serve_thour			float				null,	-- 6  應服勤時數
	serve_dhour			float				null,	-- 7  實際服勤時數
	serve_absent		float				null,	-- 8  缺勤時數
	serve_rate			float				null,	-- 9  服勤率
	train_thour1		float				null,	-- 10 應在職訓練總時數
	train_dhour1		float				null,	-- 11 實際在職訓練時數
	train_thour2		float				null,	-- 12 應成長訓練總時數
	train_dhour2		float				null,	-- 13 實際成長訓練時數
	serve_score			int					null,	-- 14 服勤表現分數
	serve_ps			varchar(1000)		null,	-- 15 服勤表現備註
	syear				char(4)				null,	-- 16 年	
	season				char(1)				null	-- 17 季	
)

																	/* ☆ 程式部份 ☆ */ 
/* --------------------------------------------------------------------------------------- 
   錯誤的執行條件
--------------------------------------------------------------------------------------- */ 

-- 如果沒有參數，則不處理

IF (IsNull(@as_kid, '') = '') GOTO Exit_Result
IF (IsNull(@adt_s, '') = '') GOTO Exit_Result
IF (IsNull(@adt_e,'') = '') GOTO Exit_Result


/* --------------------------------------------------------------------------------------- 
  1.取出考核主檔的志工資料
--------------------------------------------------------------------------------------- */ 
INSERT INTO #tmp_result 
Select 
		( Select hmg101a_name From hmg101a Where hmg101a_kid = hmg101b_kid ) ,
		hmg101b_vid ,
		( Select hmd201_tid From hmd201 Where hmd201_vid = hmg101b_vid ) ,
		( Select hmd101_tname From hmd101 Where hmd101_tid in ( Select hmd201_tid From hmd201 Where hmd201_vid = hmg101b_vid ) ),
		( Select hmd201_cname From hmd201 Where hmd201_vid = hmg101b_vid ) ,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		( Select hmg101a_syear From hmg101a Where hmg101a_kid = hmg101b_kid ) ,
		( Select hmg101a_sseason From hmg101a Where hmg101a_kid = hmg101b_kid ) 
From hmg101b 
Where hmg101b_kid = @as_kid
	
/* --------------------------------------------------------------------------------------- 
  2.更新
--------------------------------------------------------------------------------------- */ 

select hmf103_vid , hmf101_coursetype , ( CASE WHEN RTRIM(hmf101_coursetype) = '在職訓練' THEN '1' WHEN RTRIM(hmf101_coursetype) = '成長訓練' THEN '2' END ) as coursetype , SUM(hmf101_hourse) as thour , SUM(hmf103_onduty) as onduty , SUM(hmf103_absent) as absent1
INTO #tmp_table
From hmf103 
INNER JOIN hmf102 ON hmf103.hmf103_trainid = hmf102.hmf102_trainid 
INNER JOIN hmf101 ON hmf102.hmf102_courseid = hmf101.hmf101_courseid 
Where hmf102_sdate between @adt_s AND @adt_e
GROUP BY hmf103_vid , hmf101_coursetype

Update #tmp_result
set train_thour1 = thour,
    train_dhour1 = onduty
From #tmp_table
Where  hmf103_vid = vid
AND coursetype = '1'
    
Update #tmp_result
set train_thour2 = thour,
    train_dhour2 = onduty
From #tmp_table
Where  hmf103_vid = vid
AND coursetype = '2'

select hme101c_vid , SUM(hme101b_hour) as thour , SUM(hme101c_onduty) as onduty , SUM(hme101c_absent) as absent1 , Round(SUM(hme101c_onduty)/SUM(hme101b_hour),2) as rate
INTO #tmp_serve
From hme101c 
INNER JOIN hme101b ON hme101c.hme101c_pdid = hme101b.hme101b_pdid 
Where hme101b_sdate between @adt_s AND @adt_e
GROUP BY hme101c_vid 
    
Update #tmp_result
set serve_thour = thour,
    serve_dhour = onduty,
	serve_absent = absent1,
	serve_rate = rate
From #tmp_serve
Where  hme101c_vid = vid

Update #tmp_result
set serve_score = ( CASE WHEN #tmp_result.season = '1' THEN hle501_score1 
						 WHEN #tmp_result.season = '2' THEN hle501_score2
						 WHEN #tmp_result.season = '3' THEN hle501_score3
						 WHEN #tmp_result.season = '4' THEN hle501_score4
					 END ),
serve_ps = hle501_ps
From hle501
Where hle501_vid = vid
AND CAST(hle501_syear as int) - 1911 = CAST(#tmp_result.syear as int)



/* --------------------------------------------------------------------------------------- 
   處理完畢–取出《結果的暫存表格 #tmp_result》的資料
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- 從《結果的暫存表格 #tmp_result》取出資料
	SELECT kname , vid , tid , tname , cname , Isnull(serve_thour,0) as serve_thour	, Isnull(serve_dhour,0) as serve_dhour , Isnull(serve_absent,0) as serve_absent , IsNull(serve_rate,0) as serve_rate , IsNull(train_thour1,0) as train_thour1 , IsNull(train_dhour1,0) as train_dhour1	, IsNull(train_thour2,0) as train_thour2 , IsNull(train_dhour2,0) as train_dhour2  , IsNull(serve_score,0) as serve_score , IsNull(serve_ps,'') , syear , season
		FROM #tmp_result


GO
-- =============================================
-- 執行預存程序範例
-- =============================================

--EXECUTE usp_r_g0102  'E098-00001' , '2009/01/01 00:00:00','2009/12/31 23:59:59'
