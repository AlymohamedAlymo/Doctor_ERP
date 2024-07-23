USE MASTER

DECLARE @BackUpPath VARCHAR(255)
DECLARE @DataBaseName VARCHAR(128)
DECLARE @ApplicationName VARCHAR(128)

SET @BackUpPath = '%BackupPath%'
SET @DataBaseName = '%DBName%'

SET @ApplicationName = NEWID() -- Not Is use 



CREATE TABLE [#tempHearder]
	(
		LogicalName nvarchar (128) ,
		PhysicalName nvarchar(260),
		Type char(1),
		FileGroupName nvarchar(128),
		Size numeric(20,0),
		MaxSize numeric(20,0),
		FileID bigint,
		CreateLSN numeric(25,0),
		DropLSN numeric(25,0) NULL,
		UniqueID uniqueidentifier,
		ReadOnlyLSN numeric(25,0) NULL,
		ReadWriteLSN numeric(25,0) NULL,
		BackupSizeInBytes bigint,
		SourceBlockSize int,
		FileGroupID int,
		LogGroupGUID uniqueidentifier NULL,
		DifferentialBaseLSN numeric(25,0) NULL,
		DifferentialBaseGUID uniqueidentifier,
		IsReadOnly bit,
		IsPresent bit ,
		TDEThumbprint varchar(50) NULL 
	)

DECLARE @ListFiles VARCHAR (128)
DECLARE @DBName VARCHAR (128)
DECLARE @DBLog VARCHAR (128)

SET @ListFiles = 'RESTORE FILELISTONLY FROM DISK = ''' + @BackUpPath + ''''

INSERT INTO #tempHearder EXEC (@ListFiles)

SET @DBName = (SELECT RTRIM(LogicalName) FROM #tempHearder WHERE Type = 'D')
SET @DBLog = (SELECT RTRIM(LogicalName) FROM #tempHearder WHERE Type = 'L')

DROP TABLE #tempHearder


CREATE TABLE [#tempDBPath]
	(
		[DbPath] [VARCHAR](128) COLLATE ARABIC_CI_AI,
	)

CREATE TABLE [#tempLogPath]
	(
		[LogPath] [VARCHAR](128) COLLATE ARABIC_CI_AI,
	)

DECLARE @DbPath VARCHAR(128)
DECLARE @LogPath VARCHAR(128)

SET @DBPath = 'SELECT filename FROM '  + @DataBaseName + '..sysfiles WHERE fileid = 1'
INSERT INTO #tempDBPath EXEC(@DbPath)

SET @LogPath = 'SELECT filename FROM ' + @DataBaseName + '..sysfiles WHERE fileid = 2'
INSERT INTO #tempLogPath EXEC(@LogPath)

SET @DBPath = (Select RTRIM(DbPath) from #tempDBPath)
SET @LogPath = (Select RTRIM(LogPath) from #tempLogPath)

DROP TABLE #tempDBPath
DROP TABLE #tempLogPath

-- Kill other users 
DECLARE @PID CURSOR

DECLARE @GetSPID INT DECLARE @KillPID VARCHAR (15)

SET @PID = CURSOR FOR SELECT spid FROM master..sysprocesses 
JOIN master..sysdatabases ON master..sysprocesses.dbid = master..sysdatabases.dbid 
WHERE Name = @DataBaseName AND program_name <> @ApplicationName

OPEN @PID 
FETCH NEXT FROM @PID into @GetSPID 

WHILE @@FETCH_STATUS = 0 
BEGIN 
	SET @KILLPID = 'KILL ' + cast(@GetSPID as varchar(5)) 
	EXEC(@KILLPID) 
FETCH NEXT FROM @PID into @GetSPID 
END 

CLOSE @PID DEALLOCATE @PID

-- Start restoring 

RESTORE DATABASE @DataBaseName FROM DISK = @BackUpPath
WITH MOVE @DBName
TO @dbPath  ,
MOVE @DBLog                                                                                                                   
TO @LogPath ,                                                                                                                                                                                          
REPLACE
