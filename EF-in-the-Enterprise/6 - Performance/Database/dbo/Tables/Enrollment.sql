CREATE TABLE [dbo].[Enrollment] (
    [EnrollmentID] INT IDENTITY (1, 1) NOT NULL,
    [CourseID]     INT NOT NULL,
    [PersonID]     INT NOT NULL,
    [Grade]        INT NULL,
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL , 
    [UpdatedBy] NVARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    CONSTRAINT [PK_dbo.Enrollment] PRIMARY KEY CLUSTERED ([EnrollmentID] ASC),
    CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Enrollment_dbo.Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CourseID]
    ON [dbo].[Enrollment]([CourseID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PersonID]
    ON [dbo].[Enrollment]([PersonID] ASC);

