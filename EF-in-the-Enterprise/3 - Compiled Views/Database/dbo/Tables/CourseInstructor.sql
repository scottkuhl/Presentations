CREATE TABLE [dbo].[CourseInstructor] (
    [CourseID] INT NOT NULL,
    [PersonID] INT NOT NULL,
    CONSTRAINT [PK_dbo.CourseInstructor] PRIMARY KEY CLUSTERED ([CourseID] ASC, [PersonID] ASC),
    CONSTRAINT [FK_dbo.CourseInstructor_dbo.Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.CourseInstructor_dbo.Person_PersonID] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CourseID]
    ON [dbo].[CourseInstructor]([CourseID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PersonID]
    ON [dbo].[CourseInstructor]([PersonID] ASC);

