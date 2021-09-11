CREATE TABLE [dbo].[OfficeAssignment] (
    [PersonID] INT           NOT NULL,
    [Location] NVARCHAR (50) NULL,
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL , 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    CONSTRAINT [PK_dbo.OfficeAssignment] PRIMARY KEY CLUSTERED ([PersonID] ASC),
    CONSTRAINT [FK_dbo.OfficeAssignment_dbo.Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID])
);


GO
CREATE NONCLUSTERED INDEX [IX_PersonID]
    ON [dbo].[OfficeAssignment]([PersonID] ASC);

