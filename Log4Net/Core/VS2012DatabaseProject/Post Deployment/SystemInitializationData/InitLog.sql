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
SET IDENTITY_INSERT [dbo].[Log] ON

/* This is a template of insert data into a table, either system initialization data or test data.
INSERT INTO [dbo].[Log]
(
		[Id]
		,[Date]
		,[Thread]
		,[Level]
		,[Logger]
		,[Message]
		,[Exception]
)
VALUES
(
		0
		,""
		,""
		,""
		,""
		,""
		,""
)



*/

SET IDENTITY_INSERT [dbo].[Log] OFF