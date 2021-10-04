 use Movies
 GO
IF (OBJECT_ID('[dbo].[GetMoviesListByFilter]') IS NOT NULL)
   DROP PROCEDURE dbo.GetMoviesListByFilter
GO 
CREATE PROCEDURE [dbo].[GetMoviesListByFilter]
@Title VARCHAR(MAX)=null,
@Year INT= NULL,
@GenreType VARCHAR(255)= NULL
AS
BEGIN
   SELECT m.*,wh.Rating,wh.UserId FROM Movies m
   LEFT JOIN WatchHistory wh on wh.MovieID=m.MovieID
   WHERE (@Title IS  NULL OR Title LIKE '%'+@Title+'%') 
   AND (@Year IS  NULL OR YearReleased =@Year) 
   AND (@GenreType IS  NULL OR GenreType =@GenreType)
END
GO


--exec GetMoviesListByFilter   @Title ='be', @Year=2010