 use Movies
 GO
IF (OBJECT_ID('[dbo].[AddorUpdateMovies]') IS NOT NULL)
   DROP PROCEDURE dbo.AddorUpdateMovies
GO 
CREATE PROCEDURE [dbo].[AddorUpdateMovies]
  @UserID INT,
  @Title VARCHAR(255),
  @Rating float

AS
BEGIN
    
	DECLARE @MovieID INT;
	SELECT @MovieID=MovieID FROM Movies WHERE Title=@Title

	IF EXISTS(SELECT 1 FROM WatchHistory WH RIGHT JOIN Movies M on M.MovieID=wh.MovieID where WH.UserId=@UserID and m.Title=@Title)
	BEGIN
	   UPDATE WatchHistory 
	   set Rating= @Rating
	   where @MovieID= @MovieID and UserId=@UserID 
	END
	ELSE
	BEGIN
	   INSERT INTO WatchHistory (MovieID,UserId,Rating)
	   VALUES (@MovieID,@UserID,@Rating)
	END

	 SELECT m.MovieID,m.Title,m.YearReleased,m.GenreType,wh.Rating FROM Movies m
     LEFT JOIN WatchHistory wh on wh.MovieID=m.MovieID
	 where wh.UserId=@UserID
	--select * from Movies
	--select * from WatchHistory
	
	
END
GO



