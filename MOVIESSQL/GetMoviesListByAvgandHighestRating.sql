 use Movies
 GO
IF (OBJECT_ID('[dbo].[GetMoviesListByAvgRating]') IS NOT NULL)
   DROP PROCEDURE dbo.GetMoviesListByAvgRating
GO 
CREATE PROCEDURE [dbo].[GetMoviesListByAvgRating]
@Type VARCHAR(255) =NULL,
@Name VARCHAR(255)=NULL
AS
BEGIN
  
  IF @Type ='AvgRating'
  BEGIN
	  SELECT top 5 m.MovieID,m.Title,m.YearReleased,m.GenreType, ROUND(AVG(wh.Rating ) * 2, 0)/2.0    as Rating FROM Movies m 
	  LEFT JOIN WatchHistory wh ON wh.MovieID=m.MovieID
	  GROUP BY m.MovieID,m.Title,m.YearReleased,m.GenreType
	  HAVING AVG(wh.Rating) IS NOT NULL
	  Order by AVG(wh.Rating) desc , m.Title 

  END
  ELSE IF @Type ='HighestRating'
  BEGIN


	  SELECT top 5 m.MovieID,m.Title,m.YearReleased,m.GenreType, wh.Rating FROM Movies m 
	  LEFT JOIN WatchHistory wh ON wh.MovieID=m.MovieID
	  RIGHT JOIN UserInfo UI on UI.UserID=wh.UserId
	  where UI.FirstName like '%'+@Name+'%' OR UI.LastName like '%'+@Name+'%'
	  Order by  wh.Rating desc
  END

  END

GO









	

