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

DECLARE @BuildDate Datetime2 = GETDATE()

:r .\PostDeployment_DisableCheckContraints.sql
--Load the Initial System Data (status codes, ddl, etc.)
IF ('$(SqlCmdVar_LoadSystemInitilizationData)' = 'True')
BEGIN
		:r .\SystemInitializationData\InitLog.sql
	
END
IF ('$(SqlCmdVar_DumpTestData)' = 'True')
BEGIN
		:r .\SystemInitializationData\InitLog.sql
	
END

:r .\PostDeployment_EnableCheckContraints.sql


