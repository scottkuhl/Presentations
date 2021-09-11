/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
			   SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* 
	These are in the opposite order that they are listed in Clean.sql
	The test project should run these in the same order listed here.
	See UnitTests.Helper.
*/

PRINT 'Deleting existing test data.';
:r Scripts\Reset.sql

PRINT 'Populate test data.';
:r Scripts\TestData.sql