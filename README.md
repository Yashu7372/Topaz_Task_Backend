Created .Net core web api
Created the project using dependency injection pattern
pull this repo using - https://github.com/Yashu7372/Topaz_Task_Backend.git
after cloning this project install sql client to make the database connection
i have used the sql server as a database and use below schema to create database
after this changes click on the run in the visual studio


Database Schema:
create database Backend_Topaz;

create table:

CREATE TABLE UserActivity (
    ActivityId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    ActivityType NVARCHAR(50) NOT NULL,  -- 'Form Loaded' or 'Form Submitted'
    ActivityTime DATETIME NOT NULL,
    CONSTRAINT CHK_ActivityType CHECK (ActivityType IN ('Form Loaded', 'Form Submitted'))
);


Stored procedure for activity to get the activities as per the from and to date:

Create PROCEDURE [dbo].[GetUserActivity] 
	-- Add the parameters for the stored procedure here
	@StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UserId, ActivityType, ActivityTime
    FROM UserActivity
    WHERE ActivityTime BETWEEN @StartDate AND @EndDate
    ORDER BY UserId, ActivityTime;
END

Stored Procedure for activity to insert the activity:

CREATE PROCEDURE InsertUserActivity
    @UserId INT,
    @ActivityType NVARCHAR(50)
AS
BEGIN
    INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (@UserId, @ActivityType, GETDATE());
END;


InsertScript:

INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (1,Form Loaded, GETDATE());
INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (1,Form Submitted, GETDATE());
INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (2,Form Submitted, GETDATE());

INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (3,Form Loaded, GETDATE());

INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (4,Form Loaded, GETDATE());
INSERT INTO UserActivity (UserId, ActivityType, ActivityTime)
    VALUES (5,Form Loaded, GETDATE());
