 use Movies
 GO
   IF NOT EXISTS (SELECT * FROM sys.objects where object_id=OBJECT_ID(N'[dbo].[Movies]') and type in (N'U'))
   BEGIN 
     CREATE TABLE [dbo].[Movies](
	    MovieID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
		Description VARCHAR(1000) NULL,
		YearReleased INT NULL,
		Title VARCHAR(255) null,
		GenreType VARCHAR(255) NULL
	 )

   END
   IF NOT EXISTS (SELECT * FROM sys.objects where object_id=OBJECT_ID(N'[dbo].[User]') and type in (N'U'))
   BEGIN 
     CREATE TABLE [dbo].[UserInfo](
		UserID INT PRIMARY KEY NOT NULL,
		FirstName VARCHAR(255),
		LastName VARCHAR(255)
		
	 )

   END

  

   IF NOT EXISTS (SELECT * FROM sys.objects where object_id=OBJECT_ID(N'[dbo].[WatchHistory]') and type in (N'U'))
   BEGIN 
     CREATE TABLE [dbo].[WatchHistory](
		ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
		MovieID INT NOT NULL,
		UserId INT NOT NULL,
		Rating FLOAT NULL,
		Comments VARCHAR(1000) NULL,
		
	 )

   END



  
 GO

	   
	   
	   




		
