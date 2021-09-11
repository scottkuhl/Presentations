CREATE TABLE [dbo].[Audit]
(
	[AuditId] INT IDENTITY (1, 1)NOT NULL PRIMARY KEY, 
    [TableId] INT NOT NULL, 
    [User] NVARCHAR(50) NOT NULL, 
    [TableName] VARCHAR(50) NOT NULL, 
    [Action] VARCHAR(20) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL, 
    [Before] XML NULL, 
    [After] XML NOT NULL
)
