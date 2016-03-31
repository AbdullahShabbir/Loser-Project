Create database LoserDatabase
Go

Use LoserDatabase
Go

Create Table [User]
(
	soul_id int IDENTITY PRIMARY KEY,
	soul_name varchar(50) NOT NULL,
	email varchar(50) NOT NULL,
	[password] varchar(50) NOT NULL,
	[satisfaction] varchar(50) NULL,
	[info] varchar(MAX) NULL,
	[privacy] varchar(50) NOT NULL
)
Go

Create Table [UserPref]
(
	soul_name varchar(50),
	cat_1 varchar(50),
	cat_2 varchar(50),
	cat_3 varchar(50),
)

Go

Create Table [Case]
(
	case_id int IDENTITY PRIMARY KEY,
	title varchar(50) NOT NULL,
	[description] varchar(MAX) NOT NULL,
	category varchar(50) NOT NULL,
	[date] varchar(50) NOT NULL,
	[time] varchar(50) NOT NULL,
	soul_id int NOT NULL,
	rating float NULL default 0,
	[security] varchar(50) Not NULL,
	count_sym int NOT NULL default 0,
	count_oppor int NOT NULL default 0,
	count_fac int NOT NULL default 0,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id)
)

Go

Create Table CaseImage
(
	case_id int NOT NULL,
	soul_id int NOT NULL,
	caseimage varbinary(MAX) NOT NULL,
	FOREIGN KEY (case_id) REFERENCES [Case](case_id) ON DELETE CASCADE,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id)
)

Go

Create Table CaseVideo
(
	case_id int NOT NULL,
	soul_id int NOT NULL,
	name varchar(50),
	content_type varchar(50),
	data varbinary(MAX) NOT NULL,
	FOREIGN KEY (case_id) REFERENCES [Case](case_id) ON DELETE CASCADE,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id)
)

Go

Create Table [Categories]
(
	category_id int IDENTITY PRIMARY KEY,
	category_name varchar(50) NOT NULL
)

Go

Insert Into [Categories] VALUES('Education')
Go
Insert Into [Categories] VALUES('Bussiness')
Go
Insert Into [Categories] VALUES('Social')
Go
Insert Into [Categories] VALUES('Relationship')
Go
Insert Into [Categories] VALUES('Family')

Go

Create Table [Rating]
(
	soul_id int NOT NULL,
	category_id int NOT NULL,
	points int NOT NULL
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id),
	FOREIGN KEY (category_id) REFERENCES [Categories](category_id),
)

Go

Create Table [Follow]
(
	soul_id int NOT NULL,
	friend_soul_id int NOT NULL,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id),
	FOREIGN KEY (friend_soul_id) REFERENCES [User](soul_id)
)
Go

Create Table [Comment]
(
	comment_id int IDENTITY PRIMARY KEY,
	[description] varchar(MAX) NOT NULL,
	[type] varchar(50) NOT NULL,
	[date] varchar(50) NOT NULL,
	[time] varchar(50) NOT NULL,
	[isbest] varchar(50) NOT NULL,
	soul_id int NOT NULL,
	case_id int NOT NULL,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id),
	FOREIGN KEY (case_id) REFERENCES [Case](case_id) ON DELETE CASCADE
)
Go

Create Table ReComment
(
	comment_id int NOT NULL,
	re_comment_id int NOT NULL,
	FOREIGN KEY (comment_id) REFERENCES Comment(comment_id),
	FOREIGN KEY (re_comment_id) REFERENCES Comment(comment_id)
)
Go

Create Table Block
(
	soul_id int NOT NULL,
	blocked_soul_id int NOT NULL,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id),
	FOREIGN KEY (blocked_soul_id) REFERENCES [User](soul_id),
)
Go

Create Table Trophy
(
	trophy_id int IDENTITY PRIMARY KEY,
	picture_url varchar(100) NOT NULL,
	[description] varchar(100) NOT NULL,
)
Go

Insert Into Trophy Values('~/Trophy/trophy_1.jpg','This Trophy is given to a Person who helped other in Education Category')
Go
Insert Into Trophy Values('~/Trophy/trophy_2.jpg','This Trophy is given to a Person who helped other in Bussiness Category')
Go
Insert Into Trophy Values('~/Trophy/trophy_3.jpg','This Trophy is given to a Person who helped other in Social Category')
Go
Insert Into Trophy Values('~/Trophy/trophy_4.jpg','This Trophy is given to a Person who helped other in Relationship Category')
Go
Insert Into Trophy Values('~/Trophy/trophy_5.jpg','This Trophy is given to a Person who helped other in Family Category')

Go

Create Table Achievement
(
	soul_id int NOT NULL,
	trophy_id int NOT NULL,
	giver_id int NOT NULL,
	[date] varchar(50) NOT NULL,
	[time] varchar(50) NOT NULL,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id),
	FOREIGN KEY (trophy_id) REFERENCES Trophy(trophy_id),
	FOREIGN KEY (giver_id) REFERENCES [User](soul_id)
)
Go

Create Table Quotation
(
	quot_id int IDENTITY PRIMARY KEY,
	[description] varchar(MAX) NOT NULL,
	soul_id int NOT NULL,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id)
)
Go

Create Table Quiz
(
	quiz_id int IDENTITY PRIMARY KEY,
	name varchar(50) NOT NULL 
)
Go

Create Table NotificationType
(
	notificationtype_id int IDENTITY PRIMARY KEY,
	typeof varchar(50) NOT NULL
)
Go

Insert Into NotificationType Values('Comment')
Go
Insert Into NotificationType Values('Follow')

Go

Create Table CaseNotification
(
	casenotification_id int IDENTITY PRIMARY KEY,
	notificationtype_id int NOT NULL,
	from_id int NOT NULL,
	to_id int NOT NULL,
	case_id int NOT NULL,
	[date] varchar(50) NOT NULL,
	[time] varchar(50) NOT NULL,
	isreaded varchar(50) NOT NULL,
	FOREIGN KEY (from_id) REFERENCES [User](soul_id),
	FOREIGN KEY (to_id) REFERENCES [User](soul_id),
	FOREIGN KEY (case_id) REFERENCES [Case](case_id),
	FOREIGN KEY (notificationtype_id) REFERENCES NotificationType(notificationtype_id)
)

Go

Create Table FollowNotification
(
	follownotification_id int IDENTITY PRIMARY KEY,
	notificationtype_id int NOT NULL,
	from_id int NOT NULL,
	to_id int NOT NULL,
	[date] varchar(50) NOT NULL,
	[time] varchar(50) NOT NULL,
	isreaded varchar(50) NOT NULL,
	FOREIGN KEY (from_id) REFERENCES [User](soul_id),
	FOREIGN KEY (to_id) REFERENCES [User](soul_id),
	FOREIGN KEY (notificationtype_id) REFERENCES NotificationType(notificationtype_id)
)

Go

Create Table Question
(
	ques_id int IDENTITY PRIMARY KEY,
	description varchar(MAX) NOT NULL,
	ans_1 varchar(50) NOT NULL,
	ans_2 varchar(50) NOT NULL,
	ans_3 varchar(50) NOT NULL,
	ans_4 varchar(50) NOT NULL,
	right_ans varchar(50) NOT NULL,
	quiz_id int NOT NULL,
	FOREIGN KEY (quiz_id) REFERENCES Quiz(quiz_id)
)
Go

Create Table User_Quiz
(
	soul_id int NOT NULL,
	quiz_id int NOT NULL,
	[date] varchar(50) NOT NULL,
	result int NOT NULL,
	FOREIGN KEY (soul_id) REFERENCES [User](soul_id),
	FOREIGN KEY (quiz_id) REFERENCES Quiz(quiz_id)
)
Go

CREATE PROCEDURE [dbo].[sp_RegisterUser]
@SoulName varchar(50),
@Email varchar(50),
@Password varchar(50)
AS
Begin
	Insert Into [User] Values(@SoulName, @Email, @Password, 'No Opinion', '', 'Private');
End

Go

CREATE PROCEDURE [dbo].[sp_LoginCheck]
	@SoulName varchar(50),
	@Password varchar(50)
AS
Begin
	Select * From [User] Where soul_name=@SoulName and [password]=@Password;
End

Go

CREATE PROCEDURE [dbo].[sp_AddCase]
	@Title varchar(50),
	@Description varchar(MAX),
	@Category varchar(50),
	@PostDate varchar(50),
	@PostTime varchar(50),
	@SoulId varchar(50),
	@Security varchar(50)
AS
Begin
	Insert Into [Case] Values(@Title, @Description, @Category, @PostDate, @PostTime, @SoulId, 0, @Security, 0, 0, 0);
End

Go

CREATE PROCEDURE [dbo].[sp_UpdateCase]
@CaseID int,
@Title varchar(50),
@Description varchar(MAX),
@Category varchar(50),
@PostDate varchar(50),
@PostTime varchar(50),
@SoulId varchar(50),
@Security varchar(50)
AS
Begin
	Update [dbo].[Case] 
	Set [title]=@Title, [description]=@Description, [category]=@Category, [date]=@PostDate, [time]=@PostTime, [security]=@Security 
	Where case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_ShowCase]
	@SoulId int
AS
Begin
	Select C.[case_id], C.[title], C.[description], C.[category], C.[security], C.[rating], 
	C.[date], C.[time], U.[soul_name], C.[count_oppor], C.[count_sym], C.[count_fac] 
	From [Case] as C,[User] as U 
	Where C.[soul_id] = U.[soul_id] AND C.[soul_id] = @SoulId  Order By case_id DESC;
End

Go

CREATE PROCEDURE [dbo].[sp_AddComment]
	@Description varchar(MAX),
	@Type varchar(50),
	@PostDate varchar(50),
	@PostTime varchar(50),
	@SoulId int,
	@CaseId int
AS
begin
	Insert Into [Comment] Values(@Description, @Type, @PostDate, @PostTime, 'No', @SoulId, @CaseId);
end

Go

CREATE PROCEDURE [dbo].[sp_ShowComment]
@SoulId int
AS
Begin
	Select * From [Comment] Where soul_id = @SoulId;
End

Go

CREATE PROCEDURE [dbo].[sp_GiveCaseRating]
@Rating float,
@CaseId int
AS
Begin
	Update [dbo].[Case] Set rating = @Rating Where case_id = @CaseId
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseRating]
@CaseId int
AS
Begin
	Select rating From [dbo].[Case] Where case_id = @CaseId
End

Go

CREATE PROCEDURE [dbo].[sp_ShowPublicCaseByID]
	@SoulID int
AS
Begin
	Select C.[case_id], C.[title], C.[description], U.[soul_name], C.[date], C.[time], C.[count_fac], C.[count_oppor], C.[count_sym], C.category 
	From [Case] as C, [User] as U 
	Where U.[soul_id] = C.[soul_id] AND U.[soul_id] = @SoulID  
	AND C.[security] = 'Public' Order By C.case_id DESC;
End

Go

CREATE PROCEDURE [dbo].[sp_ShowPrivateCaseByID]
	@SoulID int
AS
Begin
	Select C.[case_id], C.[title], C.[description], U.[soul_name], C.[date], C.[time], C.[count_fac], C.[count_oppor], C.[count_sym], C.category 
	From [Case] as C, [User] as U 
	Where U.[soul_id] = C.[soul_id] AND U.[soul_id] = @SoulID  
	AND C.[security] = 'Private' Order By C.case_id DESC;
End

Go

CREATE PROCEDURE [dbo].[sp_DefaultUserPref]
	@SoulName varchar(50)
AS
Begin
	Insert Into UserPref Values(@SoulName, 'Bussiness','Social','Education');
End

Go

CREATE PROCEDURE [dbo].[sp_UpdateUserPref]
	@SoulName varchar(50),
	@Cat_1 varchar(50),
	@Cat_2 varchar(50),
	@Cat_3 varchar(50)	
AS
Begin
	Update [UserPref] Set cat_1 = @Cat_1, cat_2 = @Cat_2, cat_3 = @Cat_3 Where soul_name = @SoulName;
End

Go

CREATE PROCEDURE [dbo].[sp_GetUserDetail]
@SoulName varchar(50)
AS
Begin
	Select cat_1, cat_2, cat_3, email, info, satisfaction, privacy
	From [UserPref], [User] 
	Where [UserPref].[soul_name] = [User].[soul_name] AND [UserPref].[soul_name] = @SoulName
End

Go

CREATE PROCEDURE [dbo].[sp_GetCasebyCategory]
@Category varchar(50),
@SoulId int
AS
Begin
	Select C.[case_id], U.[soul_name], C.[title], C.[description], C.[date], C.[time], C.count_fac, C.count_oppor, C.count_sym
	From [dbo].[Case] as C , [dbo].[User] as U
	Where U.[soul_id] = C.[soul_id] AND C.[category] = @Category AND [security] = 'Public' And U.soul_id <> @SoulId
	Order By C.count_fac + C.count_oppor + C.count_sym DESC
End

Go

CREATE PROCEDURE [dbo].[sp_DeleteCasebyID]
	@CaseID int
AS
Begin
	Delete From [Case] Where case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_GetCasebyID]
	@CaseID int
AS
Begin
	Select C.[case_id], C.[title], C.[description], C.[category], C.[rating], C.[date], 
	C.[time], U.[soul_name], C.[security], C.[count_sym], C.[count_oppor], C.[count_fac]
	From [Case] as C, [User] as U
	Where C.soul_id = U.soul_id AND case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_GetCommentbyCase]
@CaseId int
AS
Begin
	Select C.[comment_id], U.[soul_name], C.[description], C.[type], C.[time], C.[date]
	From [Comment] as C,[User] as U 
	Where C.soul_id = U.soul_id AND case_id = @CaseId AND isbest = 'No';
End

Go

CREATE PROCEDURE [dbo].[sp_GetIDbySoulName]
	@SoulName varchar(50)
AS
Begin
	Select soul_id From [User] Where soul_name = @SoulName
End

Go

CREATE PROCEDURE [dbo].[sp_IsFollower]
	@SoulId int,
	@FollowerID int
AS
Begin
	Select * From Follow Where soul_id = @SoulId AND friend_soul_id = @FollowerID
End

Go

CREATE PROCEDURE [dbo].[sp_FollowUser]
	@SoulID int,
	@FriendID int
AS
Begin
	Insert into [Follow] Values(@SoulID, @FriendID);
End

Go

CREATE PROCEDURE [dbo].[sp_UnFollowUser]
	@SoulID int,
	@FriendID int
AS
Begin
	Delete From Follow Where soul_id = @SoulID AND friend_soul_id = @FriendID
End

Go

CREATE PROCEDURE [dbo].[sp_UpdateUserDetail]
	@SoulId int,
	@Email varchar(50),
	@Satisfaction varchar(50),
	@Info varchar(MAX),
	@Privacy varchar(50)
AS
Begin
	Update [User] Set email = @Email, satisfaction = @Satisfaction, info = @Info, privacy = @Privacy Where soul_id = @SoulId;
End

Go

CREATE PROCEDURE [dbo].[sp_GetSoulNamebyCaseID]
	@CaseId int
AS
Begin
	Select U.soul_name
	From [Case] as C, [User] as U
	Where C.soul_id = U.soul_id AND C.case_id = @CaseId
End

Go

CREATE PROCEDURE [dbo].[sp_AddQuotation]
	@Description varchar(MAX),
	@SoulId int
AS
Begin
	Insert Into [Quotation] Values(@Description, @SoulId);
End

Go

CREATE PROCEDURE [dbo].[sp_GetQuotationbySoulID]
	@SoulId int
AS
Begin
	Select [description] From Quotation where soul_id = @SoulId
End

Go

CREATE PROCEDURE [dbo].[sp_BlockUser]
	@SoulID int,
	@BlockID int
AS
Begin
	Insert into [Block] Values(@SoulID, @BlockID);
End

Go

CREATE PROCEDURE [dbo].[sp_UnBlockUser]
	@SoulID int,
	@BlockID int
AS
Begin
	Delete From Block Where soul_id = @SoulID AND blocked_soul_id = @BlockID
End

Go

CREATE PROCEDURE [dbo].[sp_IsBlocked]
	@SoulId int,
	@BlockID int
AS
Begin
	Select * From Block Where soul_id = @SoulId AND blocked_soul_id = @BlockID
End

Go

CREATE PROCEDURE [dbo].[sp_GetCount]
	@CaseID int
AS
Begin
	Select count_sym, count_oppor, count_fac
	From [Case]
	Where case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_GetFollowing]
	@SoulID int
AS
Begin
	Select soul_name, email, SUBSTRING(info,1,67) as info From [User] Where soul_id IN 
	(
		Select friend_soul_id From Follow Where soul_id = @SoulID
	)
End

Go

CREATE PROCEDURE [dbo].[sp_GetFollower]
	@FriendID int
AS
Begin
Select soul_name, email, SUBSTRING(info,1,67) as info From [User] Where soul_id IN 
(
	Select soul_id From Follow Where friend_soul_id = @FriendID
)
End

Go

CREATE PROCEDURE [dbo].[sp_GetMutualFriend]
	@SoulID int,
	@SearchID int
AS
Begin
	Select U.soul_name, U.email, U.info From [User] AS U Where U.soul_id In 
	(
		SELECT F.friend_soul_id FROM [Follow] AS F Where F.soul_id = @SoulID
		INTERSECT
		SELECT F.friend_soul_id FROM [Follow] AS F Where F.soul_id = @SearchID
	)
End

Go

CREATE PROCEDURE [dbo].[sp_UpdateCount]
@CaseID int,
@CountSym int,
@CountOppor int,
@CountFac int
AS
Begin
	Update [dbo].[Case] 
	Set count_sym = @CountSym, count_oppor = @CountOppor, count_fac = @CountFac
	Where case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_FilterCase]
	@SoulId int,
	@Category varchar(50),
	@Security varchar(50)
AS
Begin
	IF @Category = 'Any' AND @Security = 'Any'
		Select C.[case_id], C.[title], C.[description], C.[category], C.[security], C.[rating], 
				C.[date], C.[time], U.[soul_name], C.[count_oppor], C.[count_sym], C.[count_fac]  
		From [Case] as C, [User] as U 
		Where C.soul_id = @SoulId AND C.soul_id = U.soul_id
		Order By case_id DESC;
	
	ELSE IF @Category = 'Any'
		Select C.[case_id], C.[title], C.[description], C.[category], C.[security], C.[rating], 
			   C.[date], C.[time], U.[soul_name], C.[count_oppor], C.[count_sym], C.[count_fac]  
		From [Case] as C, [User] as U  
		Where C.soul_id = @SoulId AND [security] = @Security AND C.soul_id = U.soul_id
		Order By case_id DESC;
	
	ELSE IF @Security = 'Any'
		Select C.[case_id], C.[title], C.[description], C.[category], C.[security], C.[rating], 
			   C.[date], C.[time], U.[soul_name], C.[count_oppor], C.[count_sym], C.[count_fac]  
		From [Case] as C, [User] as U  
		Where C.soul_id = @SoulId AND category = @Category AND C.soul_id = U.soul_id
		Order By case_id DESC;
	
	Else
		Select C.[case_id], C.[title], C.[description], C.[category], C.[security], C.[rating], 
			   C.[date], C.[time], U.[soul_name], C.[count_oppor], C.[count_sym], C.[count_fac]  
		From [Case] as C, [User] as U 
		Where C.soul_id = @SoulId AND category = @Category AND [security] = @Security AND C.soul_id = U.soul_id
		Order By case_id DESC;
End

Go

CREATE PROCEDURE [dbo].[sp_ChooseBestComment]
@CommentId int
AS
Begin
	Update [dbo].[Comment] Set isbest = 'Yes' Where comment_id = @CommentId
End

Go

CREATE PROCEDURE [dbo].[sp_RemoveBestComment]
@CaseId int
AS
Begin
	Update [dbo].[Comment] Set isbest = 'No' Where case_id = @CaseId AND isbest = 'Yes'
End

Go

CREATE PROCEDURE [dbo].[sp_GetBestComment]
@CaseId int
AS
Begin
	Select U.[soul_name], C.[description], C.[date], C.[time], C.[type] 
	From [Comment] as C,[User] as U 
	Where C.soul_id = U.soul_id AND case_id = @CaseId AND isbest = 'Yes';
End

Go

CREATE PROCEDURE [dbo].[sp_SetRating]
	@SoulID int
AS
Begin
	Insert Into [Rating] Values(@SoulID,1,0);
	Insert Into [Rating] Values(@SoulID,2,0);
	Insert Into [Rating] Values(@SoulID,3,0);
	Insert Into [Rating] Values(@SoulID,4,0);
	Insert Into [Rating] Values(@SoulID,5,0);
End

Go

CREATE PROCEDURE [dbo].[sp_GetCategoryIDbyName]
	@CategoryName varchar(50)
AS
Begin
	Select category_id From [Categories] Where category_name = @CategoryName
End

Go

CREATE PROCEDURE [dbo].[sp_GetSoulIDbyCommentID]
	@CommentID int
AS
Begin
	Select soul_id From [Comment] Where comment_id = @CommentID
End

Go

CREATE PROCEDURE [dbo].[sp_GetPreviousRating]
	@SoulID int,
	@CategoryID int
AS
Begin
	Select soul_id, category_id, points From [Rating] Where soul_id = @SoulID AND category_id = @CategoryID
End

Go

CREATE PROCEDURE [dbo].[sp_UpdateRating]
	@SoulID int,
	@CategoryID int,
	@Points int
AS
Begin
	Update Rating Set points = @Points Where soul_id = @SoulID AND category_id = @CategoryID
End

Go

CREATE PROCEDURE [dbo].[sp_ShowAllTrophy]
AS
Begin
	Select * From Trophy 
End

Go

CREATE PROCEDURE [dbo].[sp_GiveTrophy]
	@ToID int,
	@FromID int,
	@TrophyID int,
	@GivenDate varchar(50),
	@GivenTime varchar(50)
AS
Begin
	Insert Into [Achievement] Values(@ToID, @TrophyID, @FromID, @GivenDate, @GivenTime);
End

Go

CREATE PROCEDURE [dbo].[sp_GetUserAchievement]
	@SoulID int
AS
Begin
	Select T.[description], T.[picture_url], COUNT(A.trophy_id) AS 'trophy_count'
	From Trophy as T, Achievement as A
	Where T.trophy_id = A.trophy_id AND A.soul_id = @SoulID
	Group By A.trophy_id, T.[description], T.[picture_url]
End

Go

CREATE PROCEDURE [dbo].[sp_IsAchievementGiven]
	@ToID int,
	@FromID int,
	@TrophyID int
AS
Begin
	Select * From Achievement Where soul_id = @ToID AND giver_id = @FromID AND trophy_id = @TrophyID
End

Go

CREATE PROCEDURE [dbo].[sp_GetCategoryStatsbyID]
	@SoulId int
AS
Begin
	Select 'Education' AS category, COUNT(category) AS Total From [Case] where category = 'Education' AND soul_id = @SoulId
	UNION
	Select 'Bussiness' AS category, COUNT(category) AS Total From [Case] where category = 'Bussiness' AND soul_id = @SoulId
	UNION
	Select 'Social' AS category, COUNT(category) AS Total From [Case] where category = 'Social' AND soul_id = @SoulId
	UNION
	Select 'Relationship' AS category, COUNT(category) AS Total From [Case] where category = 'Relationship' AND soul_id = @SoulId
	UNION
	Select 'Family' AS category, COUNT(category) AS Total From [Case] where category = 'Family' AND soul_id = @SoulId
End

Go

CREATE PROCEDURE [dbo].[sp_GetTotalCategoryStatsbyID]
	@SoulId int
AS
Begin
	Select 'Total Case' category , SUM(tbl.total) as total From 
	(
		Select category , COUNT(category) AS total From [Case] Where soul_id = @SoulId Group By category
	) AS tbl
	UNION
	Select category , COUNT(category) AS total From [Case] Where soul_id = @SoulId Group By category
End

Go

CREATE PROCEDURE [dbo].[sp_GetSecurityStatsbyID]
	@SoulId int
AS
Begin
	Select 'Private' AS [Security],  COUNT([security]) AS Total From [Case] where [security] = 'Private' AND soul_id = @SoulId
	Union
	Select 'Public' AS [Security],  COUNT([security]) AS Total From [Case] where [security] = 'Public' AND soul_id = @SoulId
End

GO

CREATE PROCEDURE [dbo].[sp_GetRatingStatsbyID]
	@SoulId int
AS
Begin
	Select C.category_name, R.points
	From Rating As R, Categories As C
	Where R.category_id = C.category_id AND R.soul_id = @SoulId
End

Go

CREATE PROCEDURE [dbo].[sp_GetTotalRatingStatsbyID]
	@SoulId int
AS
Begin
	Select C.category_name, R.points From Rating As R, Categories As C Where R.category_id = C.category_id AND R.soul_id = @SoulId
	Union
	Select 'Average Points' as category_name, Avg(points) as points From Rating Where soul_id = @SoulId
	Union
	Select 'Total Points' as category_name, SUM(points) as points From Rating Where soul_id = @SoulId
End

Go

CREATE PROCEDURE [dbo].[sp_GetLastestCaseIDbySoulId]
	@SoulID int
AS
Begin
	Select TOP(1) case_id From [Case] Where soul_id = @SoulID Order by case_id desc
End

Go

CREATE PROCEDURE [dbo].[sp_AddCaseImage]
	@CaseID int,
	@SoulID int,
	@Image varbinary(MAX)
AS
Begin
	Insert Into CaseImage Values (@CaseID, @SoulID, @Image)
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseImagebyCaseID]
	@CaseID int
AS
Begin
	Select caseimage From CaseImage where case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseImagebySoulID]
	@SoulID int
AS
Begin
	Select case_id, soul_id, caseimage From CaseImage where soul_id = @SoulID
End

Go

CREATE PROCEDURE [dbo].[sp_GetOtherCaseImage]
	@SoulID int
AS
Begin
	Select case_id, soul_id, caseimage From CaseImage where soul_id <> @SoulID
End

Go

CREATE PROCEDURE [dbo].[sp_AddCaseVideo]
	@CaseID int,
	@SoulID int,
	@Name varchar(50),
	@ContentType varchar(50),
	@Data varbinary(MAX)
AS
Begin
	Insert Into CaseVideo Values (@CaseID, @SoulID, @Name, @ContentType, @Data)
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseVideobyCaseID]
	@CaseID int
AS
Begin
	Select name, content_type, data From CaseVideo where case_id = @CaseID
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseVideobySoulID]
	@SoulID int
AS
Begin
	Select case_id, soul_id, data From CaseVideo where soul_id = @SoulID
End

Go

CREATE PROCEDURE [dbo].[sp_GetOtherCaseVideo]
	@SoulID int
AS
Begin
	Select case_id, soul_id, data From CaseVideo where soul_id <> @SoulID
End

Go

CREATE PROCEDURE [dbo].[sp_SendCaseNotification]
	@NotificationType int,
	@FromID int,
	@ToID int,
	@CaseID int,
	@GivenDate varchar(50),
	@GivenTime varchar(50),
	@IsReaded varchar(50)
AS
Begin
	Insert Into CaseNotification Values (@NotificationType, @FromID , @ToID, @CaseID, @GivenDate, @GivenTime, @IsReaded)
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseNotificationCountbySoulID]
	@SoulID int
AS
Begin
	Select COUNT(casenotification_id) AS 'Total' From CaseNotification Where to_id = @SoulID AND isreaded = 'No'
End

Go

CREATE PROCEDURE [dbo].[sp_SendFollowNotification]
	@NotificationType int,
	@FromID int,
	@ToID int,
	@GivenDate varchar(50),
	@GivenTime varchar(50),
	@IsReaded varchar(50)
AS
Begin
	Insert Into FollowNotification Values (@NotificationType, @FromID , @ToID, @GivenDate, @GivenTime, @IsReaded)
End

Go

CREATE PROCEDURE [dbo].[sp_GetFollowNotificationCountbySoulID]
	@SoulID int
AS
Begin
	Select COUNT(follownotification_id) AS 'Total' From FollowNotification Where to_id = @SoulID AND isreaded = 'No'
End

Go

CREATE PROCEDURE [dbo].[sp_GetCaseNotificationbySoulID]
	@SoulID int
AS
Begin
	Select CN.casenotification_id, U.soul_name, C.title, CN.[date], CN.[time], C.case_id
	From CaseNotification AS CN, [User] AS U, [Case] AS C
	Where U.soul_id = CN.from_id AND CN.case_id = C.case_id AND to_id = @SoulID AND isreaded = 'No'
End

Go

CREATE PROCEDURE [dbo].[sp_GetFollowNotificationbySoulID]
	@SoulID int
AS
Begin
	Select FN.follownotification_id, U.soul_name, FN.[date], FN.[time]
	From FollowNotification AS FN, [User] AS U
	Where U.soul_id = FN.from_id AND to_id = @SoulID AND isreaded = 'No'
End

Go

CREATE PROCEDURE [dbo].[sp_SetCaseMarkAsReadbyID]
	@CaseNotificationID int
AS
Begin
	Update CaseNotification Set isreaded = 'Yes' Where casenotification_id = @CaseNotificationID
End

Go

CREATE PROCEDURE [dbo].[sp_SetFollowMarkAsReadbyID]
	@FollowNotificationID int
AS
Begin
	Update FollowNotification Set isreaded = 'Yes' Where follownotification_id = @FollowNotificationID
End

-----------------------------------------------------------------------------------------------------------------
-- Stored Procedure for Android App

Go

CREATE PROCEDURE [dbo].[sp_ShowOtherCase]
AS
Begin
	Select C.[case_id], C.[title], C.[description], C.[category], C.[security], C.[rating], 
	C.[date], C.[time], U.[soul_name], C.[count_oppor], C.[count_sym], C.[count_fac] 
	From [Case] as C,[User] as U 
	Where C.[soul_id] = U.[soul_id] Order By case_id DESC;
End