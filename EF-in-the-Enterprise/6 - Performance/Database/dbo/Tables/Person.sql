CREATE TABLE [dbo].[Person] (
	[PersonID]       INT            IDENTITY (1, 1) NOT NULL,
	[LastName]       NVARCHAR (50)  NULL,
	[FirstName]      NVARCHAR (50)  NULL,
	[HireDate]       DATETIME       NULL,
	[EnrollmentDate] DATETIME       NULL,
	[Discriminator]  NVARCHAR (128) NOT NULL,
	[UserName] NVARCHAR(256) NULL,     
	[Email] NVARCHAR(256) NOT NULL,
	[CreatedBy] NVARCHAR(50) NOT NULL, 
	[CreatedOn] DATETIME NOT NULL , 
	[UpdatedBy] NVARCHAR(50) NULL, 
	[UpdatedOn] DATETIME NULL, 

	CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED ([PersonID] ASC)
);

