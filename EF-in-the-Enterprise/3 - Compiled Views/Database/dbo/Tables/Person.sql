CREATE TABLE [dbo].[Person] (
    [PersonID]       INT            IDENTITY (1, 1) NOT NULL,
    [LastName]       NVARCHAR (50)  NULL,
    [FirstName]      NVARCHAR (50)  NULL,
    [HireDate]       DATETIME       NULL,
    [EnrollmentDate] DATETIME       NULL,
    [Discriminator]  NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED ([PersonID] ASC)
);

