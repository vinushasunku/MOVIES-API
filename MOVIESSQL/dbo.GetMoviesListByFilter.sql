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

   	  SELECT m.MovieID,m.Title,m.YearReleased,m.GenreType,ROUND(AVG(wh.Rating) * 2, 0) / 2   as Rating FROM Movies m 
	  LEFT JOIN WatchHistory wh ON wh.MovieID=m.MovieID
	  WHERE (@Title IS  NULL OR Title LIKE '%'+@Title+'%') 
	  AND (@Year IS  NULL OR YearReleased =@Year) 
	  AND (@GenreType IS  NULL OR GenreType =@GenreType)
	  GROUP BY m.MovieID,m.Title,m.YearReleased,m.GenreType


END
GO
