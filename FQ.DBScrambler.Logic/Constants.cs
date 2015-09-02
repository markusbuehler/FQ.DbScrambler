namespace FQ.DBScrambler.Logic
{
    public static class Constants
    {
        public static class SqlTemplates
        {
            public const string PrepareSensitiveData =
@"IF OBJECT_ID('dbo.DatabaseSensitiveData', 'U') IS NOT NULL
    DROP TABLE dbo.[DatabaseSensitiveData]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DatabaseSensitiveData](
	[Id] [int] IDENTITY(1000,1) NOT NULL,
	[Schema] [varchar](64) NOT NULL,
	[Table] [varchar](128) NOT NULL,
	[Column] [varchar](128) NOT NULL,
    CONSTRAINT [PK_DatabaseSensitiveData] PRIMARY KEY CLUSTERED 
(
	[Id]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO";

            public const string Insert = @"INSERT [dbo].[DatabaseSensitiveData] ([Schema], [Table], [Column]) VALUES (N'{0}', N'{1}', N'{2}')
GO";

            public const string RemoveUnnecessaryData1 = @"-- Attention: Set DATABASE Name at various places!
ALTER DATABASE {0}  SET RECOVERY SIMPLE
GO";

            public const string Delete = @"DELETE FROM {0}
GO";

            public const string RemoveUnnecessaryData2 = @"DECLARE @DatabaseName VARCHAR(256)
SET @DatabaseName = '{0}'
DECLARE @ShrinkCmd NVARCHAR(512) = N'DBCC SHRINKDATABASE (' + @DatabaseName + ');'
EXEC sp_executesql @ShrinkCmd
GO";

            public const string ScrambleData = @"CREATE TABLE #DatabaseSensitiveDataIds
(
    RowNumber INT,
    Id INT
)

INSERT INTO		#DatabaseSensitiveDataIds (RowNumber, Id)
SELECT DISTINCT row_number() OVER (ORDER BY id) AS rn, id
FROM			DatabaseSensitiveData

DECLARE @id INT
DECLARE @totalrows INT = (SELECT COUNT(*) FROM #DatabaseSensitiveDataIds)
DECLARE @currentrow INT = 0
DECLARE @ScrambleStmnt NVARCHAR(MAX)
DECLARE @BlindText VARCHAR(MAX) = '...Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc'
DECLARE @PrefixChars VARCHAR(2) = '3' -- Number of chars that should be left as is on beginning of string

WHILE @currentrow <  @totalrows  
BEGIN 
	SET @ScrambleStmnt = (
		SELECT N'UPDATE ' + [Schema] + '.' + [Table] + ' SET ' + [Column] + ' = SUBSTRING(' + [Column] + ', 0, ' + @PrefixChars + ')'
				+ ' + CASE WHEN LEN(' + [Column] + ') > ' + @PrefixChars + ' THEN SUBSTRING(''' + @BlindText + ''',0, LEN(' + [Column] + ') - ' + @PrefixChars + ') ELSE '''' END'
	FROM DatabaseSensitiveData
	WHERE Id = (SELECT id FROM #DatabaseSensitiveDataIds WHERE RowNumber = @currentrow)
	)

	EXEC sp_executesql @ScrambleStmnt
    SET @currentrow = @currentrow +1
END

drop table #DatabaseSensitiveDataIds";
        }
    }
}
