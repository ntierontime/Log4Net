--Delete all data in all tables
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
EXEC sp_MSForEachTable 'DELETE FROM ?'
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'


--reseed all tables with identity columns
declare @reseedsql nvarchar(MAX) = N'';

SELECT @reseedsql += N'
      DBCC CHECKIDENT(' + TABLE_NAME + ', RESEED, 0) WITH NO_INFOMSGS'
FROM 
    INFORMATION_SCHEMA.TABLES
WHERE 
    OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'TableHasIdentity') = 1
    AND TABLE_TYPE = 'BASE TABLE'

exec sp_executesql @reseedsql