use NMMST_HR
GO


-- =============================================
-- �N�w�s�b���w�s�{�ǧR��
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
1. �{���y�z�G�����]�H�O�귽�t�� �V �Үּ��g�޲z - �Ү֪�

2. �{���B�J�G(1)���~���������
			 (2)���X�ݦҮ֤H���A�p��������
			 (3)���X�Ȧs���

3. �ϥΤ覡�G(1)�ѼơG@as_kid			Varchar(20)		�Ү֥D�ɥN�X
			 (2)      @adt_s			DateTime		�o���_
			 (3)      @adt_e			DateTime        �o��騴

   �@�@�@�@�@(4)�^�ǡG					tabledata		�Ү֪�

4. ���g�H���Gdemon

5. �ק����G2009/05/11
**************************************************/

                                                                      /* �� �ŧi���� �� */ 

-- ���G���Ȧs���
CREATE TABLE #tmp_result
(	kname				nvarchar(255)		null,	-- 1  �Ү֪�W��
    vid					nvarchar(20)		null,	-- 2  �Ӥu�N�X
	tid					nvarchar(20)		null,	-- 3  �Ӥu���N�X
	tname				nvarchar(10)		null,	-- 4  �Ӥu���W��
	cname				varchar(10)			null,	-- 5  �Ӥu�ʦW
	serve_thour			float				null,	-- 6  ���A�Ԯɼ�
	serve_dhour			float				null,	-- 7  ��ڪA�Ԯɼ�
	serve_absent		float				null,	-- 8  �ʶԮɼ�
	serve_rate			float				null,	-- 9  �A�Բv
	train_thour1		float				null,	-- 10 ���b¾�V�m�`�ɼ�
	train_dhour1		float				null,	-- 11 ��ڦb¾�V�m�ɼ�
	train_thour2		float				null,	-- 12 �������V�m�`�ɼ�
	train_dhour2		float				null,	-- 13 ��ڦ����V�m�ɼ�
	serve_score			int					null,	-- 14 �A�Ԫ�{����
	serve_ps			varchar(1000)		null,	-- 15 �A�Ԫ�{�Ƶ�
	syear				char(4)				null,	-- 16 �~	
	season				char(1)				null	-- 17 �u	
)

																	/* �� �{������ �� */ 
/* --------------------------------------------------------------------------------------- 
   ���~���������
--------------------------------------------------------------------------------------- */ 

-- �p�G�S���ѼơA�h���B�z

IF (IsNull(@as_kid, '') = '') GOTO Exit_Result
IF (IsNull(@adt_s, '') = '') GOTO Exit_Result
IF (IsNull(@adt_e,'') = '') GOTO Exit_Result


/* --------------------------------------------------------------------------------------- 
  1.���X�Ү֥D�ɪ��Ӥu���
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
  2.��s
--------------------------------------------------------------------------------------- */ 

select hmf103_vid , hmf101_coursetype , ( CASE WHEN RTRIM(hmf101_coursetype) = '�b¾�V�m' THEN '1' WHEN RTRIM(hmf101_coursetype) = '�����V�m' THEN '2' END ) as coursetype , SUM(hmf101_hourse) as thour , SUM(hmf103_onduty) as onduty , SUM(hmf103_absent) as absent1
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
   �B�z�����V���X�m���G���Ȧs��� #tmp_result�n�����
--------------------------------------------------------------------------------------- */ 

Exit_Result:

	-- �q�m���G���Ȧs��� #tmp_result�n���X���
	SELECT kname , vid , tid , tname , cname , Isnull(serve_thour,0) as serve_thour	, Isnull(serve_dhour,0) as serve_dhour , Isnull(serve_absent,0) as serve_absent , IsNull(serve_rate,0) as serve_rate , IsNull(train_thour1,0) as train_thour1 , IsNull(train_dhour1,0) as train_dhour1	, IsNull(train_thour2,0) as train_thour2 , IsNull(train_dhour2,0) as train_dhour2  , IsNull(serve_score,0) as serve_score , IsNull(serve_ps,'') , syear , season
		FROM #tmp_result


GO
-- =============================================
-- ����w�s�{�ǽd��
-- =============================================

--EXECUTE usp_r_g0102  'E098-00001' , '2009/01/01 00:00:00','2009/12/31 23:59:59'
