/****** Object:  Table [dbo].[Log]    ******/
CREATE TABLE [dbo].[Log] (
	[Id] BigInt IDENTITY(1, 1) NOT NULL
	, [Date] DateTime  NOT NULL
	, [Thread] VarChar(255)  NOT NULL
	, [Level] VarChar(50)  NOT NULL
	, [Logger] VarChar(255)  NOT NULL
	, [Message] VarChar(4000)  NOT NULL
	, [Exception] VarChar(2000)  NULL
	, PRIMARY KEY NONCLUSTERED (
		Id ASC
		)
);


