CREATE TABLE [dbo].[PerformanceLog]
(
	[PerformanceLogId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [Action] NVARCHAR(20) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [Query] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Execution] BIGINT NOT NULL, 
    [User] NVARCHAR(50) NULL, 
    [IPAddress] NVARCHAR(15) NULL, 
    [RequestUrl] NVARCHAR(MAX) NULL
)
