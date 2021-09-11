CREATE TABLE [dbo].[Department] (
    [DepartmentID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [Budget]       MONEY         NOT NULL,
    [StartDate]    DATETIME      NOT NULL,
    [PersonID]     INT           NULL,
    [RowVersion]   ROWVERSION    NOT NULL,
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL , 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    CONSTRAINT [PK_dbo.Department] PRIMARY KEY CLUSTERED ([DepartmentID] ASC),
    CONSTRAINT [FK_dbo.Department_dbo.Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID])
);


GO
CREATE NONCLUSTERED INDEX [IX_PersonID]
    ON [dbo].[Department]([PersonID] ASC);

